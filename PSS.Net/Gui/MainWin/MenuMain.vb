Imports System.Windows.Forms
Imports Crownwood.Magic.Menus
Imports PSS.Core.Global
Imports PSS.Gui
Imports PSS.Data.Buisness.Security
Imports PSS.Misc

Namespace Gui.MainWin
    Public Class Menu
        Inherits Crownwood.Magic.Menus.MenuControl
#Region "DECLARATIONS"

        '// Generic menu divider.
        Protected mnuDiv As New MenuCommand("-")

        '// root menus
        Friend WithEvents mnuFile As New MenuCommand("&File")
        Friend WithEvents mnuAdmin As New MenuCommand("&Admin")
        Friend WithEvents mnuCustServ As New MenuCommand("&Customer Service")
        Friend WithEvents mnuFinance As New MenuCommand("F&inance")
        Friend WithEvents mnuHR As New MenuCommand("&Human Resource")
        Friend WithEvents mnuInventory As New MenuCommand("I&nventory")
        Friend WithEvents mnuProduction As New MenuCommand("&Production")
        Friend WithEvents mnuDocuments As New MenuCommand("Documents")
        Friend WithEvents mnuReports As New MenuCommand("Repor&ts")
        Friend WithEvents mnuEngineering As New MenuCommand("Engineering")
        Friend WithEvents mnuHelp As New MenuCommand("&Help")
        Friend WithEvents mnuReport As New MenuCommand("&Reports")

        '// file menus
        Friend WithEvents filSystem As New MenuCommand("&System")
        Friend WithEvents filClose As New MenuCommand("&Close")
        Friend WithEvents filCloseA As New MenuCommand("Close &All")
        Friend WithEvents filExit As New MenuCommand("E&xit")

        '// admin menus
        Friend WithEvents admMenu_Cellular As New MenuCommand("Cellular")
        Friend WithEvents admMenu_Messaging As New MenuCommand("Messaging")
        Friend WithEvents admMenu_SP As New MenuCommand("Special Processes")
        Friend WithEvents admMenu_SP_UpdateAvgPartsCostGoal As New MenuCommand("Update Average Parts Cost Goal")
        Friend WithEvents admMenu_IncentivePrgData As New MenuCommand("Productivity Incentive Data")



        Friend WithEvents admMenu_AppCfg As New MenuCommand("Application Configuration")
        Friend WithEvents admMenu_AppCfg_DispList As New MenuCommand("Dispositions")
        Friend WithEvents admMenu_AppCfg_CustProdLocList As New MenuCommand("Customer Product Locations")
        Friend WithEvents admMenu_AppCfg_CustProdWfList As New MenuCommand("Customer Product Workflow")
        Friend WithEvents admMenu_AppCfg_ProductList As New MenuCommand("Products")

        Friend WithEvents admFunc_EditSKU As New MenuCommand("Edit SKU (MSG)")
        Friend WithEvents admFunc_MoveTray As New MenuCommand("Assign Tray to another line")
        Friend WithEvents admFunc_EditBillMap As New MenuCommand("Edit Bill Map")
        Friend WithEvents admFunc_WOdata As New MenuCommand("Workorder Lookup - COUNTS")
        Friend WithEvents admFunc_CellTrayAdmin As New MenuCommand("Cellular Tray Administration")
        Friend WithEvents admSecurity As New MenuCommand("Security")
        Friend WithEvents admCellWrty As New MenuCommand("Cell Warranty")
        Friend WithEvents admSPAddSJUG As New MenuCommand("Add Motorola SJUG Number")
        Friend WithEvents admSPAddSofVer As New MenuCommand("Add Motorola Software Version")
        Friend WithEvents admSPconsumption As New MenuCommand("Create Part Consumption File")
        Friend WithEvents admChangeSN As New MenuCommand("Change SN")
        Friend WithEvents admChangeModel As New MenuCommand("Change Model")
        Friend WithEvents admDockRec As New MenuCommand("Dock Receive")
        Friend WithEvents admDSCPalletBuild As New MenuCommand("Discrepant Pallet Build")
        Friend WithEvents admWFadmin As New MenuCommand("Weight Factor Administration")
        Friend WithEvents admContBilladmin As New MenuCommand("Contingent Billing Administration")
        Friend WithEvents admBillcodeConsumption As New MenuCommand("Billcode Consumption (Individual)")
        Friend WithEvents admNEWrec As New MenuCommand("NEW REC SCREEN TESTING")
        Friend WithEvents admValidateRejects As New MenuCommand("Validate ATCLE Rejects")
        Friend WithEvents prodCreatePSSISNs As New MenuCommand("Create PSSI Serial Numbers")
        'COST CENTER MAIN MENU
        Friend WithEvents prodCCMain As New MenuCommand("Cost Center")
        Friend WithEvents prodCC_TimeTracking As New MenuCommand("Cost Center Time Tracking")
        Friend WithEvents prodCC_ScanDevToCC As New MenuCommand("Scan Devices into Cost Center")
        Friend WithEvents prodCC_SetUPH As New MenuCommand("Set UPH")
        Friend WithEvents prodCC_MapEmpDept As New MenuCommand("Map Employee and Department")
        '// system menus
        Friend WithEvents sysSecurity As New MenuCommand("Se&curity")
        Friend WithEvents sysInfo As New MenuCommand("System &Information")
        Friend WithEvents sysWCL As New MenuCommand("Work Center &Locations")
        '// customer service menus
        Friend WithEvents csCompany As New MenuCommand("Customer Info")
        Friend WithEvents csCompanySearch As New MenuCommand("Customer Search Info")
        Friend WithEvents csModelTarget As New MenuCommand("Set Model Target")
        Friend WithEvents csSpecialBillingDetails As New MenuCommand("Special Billing Detail")
        Friend WithEvents csSalesPerson As New MenuCommand("SalesPerson Info")
        Friend WithEvents csExceptionBillItems As New MenuCommand("Define Exception Bill Items")
        Friend WithEvents csPalletPackingSlipInfo As New MenuCommand("Packing Slip Info")
        Friend WithEvents csEditRURPriceException As New MenuCommand("RUR Price Exception")
        '***************************
        'Human Resource => Human Resource 
        '***************************
        Friend WithEvents hrLegiantEEData As New MenuCommand("Employee Data")
        Friend WithEvents hrIncentiveData As New MenuCommand("Incentive Data")
        '// Quality Control Menus
        Friend WithEvents QCTechFailureRate As New MenuCommand("Technician Failure Rate")
        '// inventory menus
        Friend WithEvents invASCPrice As New MenuCommand("&ASC Price")
        Friend WithEvents invAvailableForProdSumRpt As New MenuCommand("Available for Production - Summary")
        Friend WithEvents invAwaitingParts As New MenuCommand("Awaiting Parts")
        Friend WithEvents invBenchCycleCountVarReport As New MenuCommand("Bench Cycle Count Variance Report")
        Friend WithEvents invBillCodes As New MenuCommand("&Bill Codes")
        Friend WithEvents invBillGroupAdmin As New MenuCommand("Bill Group Admin")
        Friend WithEvents invBillIssueCellDetail As New MenuCommand("Billed/Issued Cell Detail")
        Friend WithEvents invCogsRpts As New MenuCommand("Cogs Reports")
        Friend WithEvents invCreateBillGroups As New MenuCommand("Create Bill Groups")
        Friend WithEvents invFailCodes As New MenuCommand("&Fail Codes")
        Friend WithEvents invInactivateBillCodes As New MenuCommand("Inactivate Bill Codes")
        Friend WithEvents invInactivateBillCodesC As New MenuCommand("Inactivate Bill Codes by Customer")
        Friend WithEvents invLaborLvl As New MenuCommand("Labor Level Info")
        Friend WithEvents invPartsPrice As New MenuCommand("&Parts / Service Pricing")
        Friend WithEvents invPartsMap As New MenuCommand("&Parts Mapping")
        Friend WithEvents invPartsRelated As New MenuCommand("Parts-Related")
        Friend WithEvents invPartsSNCapture As New MenuCommand("Part S/N Capture")
        Friend WithEvents invRepairCodes As New MenuCommand("&Repair Codes")
        Friend WithEvents invServInv As New MenuCommand("&Service Inventory")
        Friend WithEvents invReceiptSummary As New MenuCommand("Receipt Summary")
        Friend WithEvents invUsageSummary As New MenuCommand("Usage Summary")
        '// production menus
        Friend WithEvents prodSearch As New MenuCommand("&Search", Shortcut.CtrlS)
        Friend WithEvents prodDeviceActivity As New MenuCommand("Device Activity")
        Friend WithEvents prodDeviceActivityStats As New MenuCommand("Device Activity Statistics")

        Friend WithEvents prodDisplayCount As New MenuCommand("Line Counts")
        Friend WithEvents prodBulkShipping As New MenuCommand("Ship Pallets")
        Friend WithEvents prodGenericShipPallet As New MenuCommand("Build Ship Pallets")
        Friend WithEvents prodAutoShipRWPallet As New MenuCommand("Auto Build and Ship Rework Pallets")
        '******************************************
        'REFURB
        '******************************************
        Friend WithEvents prodPreBillLot As New MenuCommand("Pre-Bill Lot")
        Friend WithEvents prodRefurb As New MenuCommand("Refurb")
        Friend WithEvents prodRefurb_ProductivityTracker As New MenuCommand("Tracker")
        Friend WithEvents prodRefurb_Auditor As New MenuCommand("Auditor")
        Friend WithEvents prodTechHS As New MenuCommand("&Tech Center High Speed")
        Friend WithEvents prodPreTest As New MenuCommand("&PreTest")
        'QUALITY CONTROL
        Friend WithEvents prodQCMain As New MenuCommand("Quality Control")
        Friend WithEvents prodQC_Codes As New MenuCommand("QC Failure Code management")
        Friend WithEvents prodQC As New MenuCommand("QC")


        'MESSAGING
        Friend WithEvents prodMessagingMain As New MenuCommand("Messaging")
        Friend WithEvents prodMessagingMain_BuildPallet As New MenuCommand("&Build Messaging Ship Pallet")
        Friend WithEvents prodMessagingMain_ManageActiveModels As New MenuCommand("Managing Repair Model")
        Friend WithEvents prodMessagingMain_FreqCodeMap As New MenuCommand("Customer FreqCode Map")
        Friend WithEvents prodMessagingMain_Label As New MenuCommand("Label")


        Friend WithEvents prodMessagingOpenLinesQueue As New MenuCommand("Open Line Queue")
        Friend WithEvents prodMessagingMain_Reports As New MenuCommand("Reports")
        Friend WithEvents prodMessagingMain_UploadForecast As New MenuCommand("Upload Forecast")
        Friend WithEvents prodMessagingMain_FCVsLabel As New MenuCommand("Forecast vs LQP")
        Friend WithEvents prodMessagingMain_WIPTransfer As New MenuCommand("WIP Transfer")

        Friend WithEvents prodMessagingMain_WhToPreEval As New MenuCommand("Warehouse to Pre-Eval Transfer")


        Friend WithEvents prodMessaging_AMS As New MenuCommand("American Messaging")
        Friend WithEvents prodMessaging_AMS_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_AMS_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessaging_AMS_DBRManifest As New MenuCommand("Build AMS DBR/Other Ship Pallet")
        Friend WithEvents prodMessaging_AMS_MapLvl3RepReason As New MenuCommand("Map Level 3 Repair Reason")
        Friend WithEvents prodMessaging_AMS_OptConsole As New MenuCommand("Operations Console")
        Friend WithEvents prodMessaging_AMS_FreqCapcodeMgmt As New MenuCommand("Freq/Capcode Management")
        Friend WithEvents prodMessagingMain_AMS_BB As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_AMS_Ship As New MenuCommand("Produce Box")
        Friend WithEvents prodMessaging_AMS_EvalProcess As New MenuCommand("Eval Process")
        Friend WithEvents prodMessaging_AMS_DBRNERPallet As New MenuCommand("Build AMS DBR/NER Pallet")

        'Other Messaging Customers
        Friend WithEvents prodMessaging_OtherCust As New MenuCommand("Other Msg Customers")
        Friend WithEvents prodMessaging_OtherCust_Anna As New MenuCommand("Anna")
        Friend WithEvents prodMessaging_OtherCust_Lahey As New MenuCommand("Lahey")
        Friend WithEvents prodMessaging_OtherCust_Masco As New MenuCommand("Masco")
        Friend WithEvents prodMessaging_OtherCust_Franciscan As New MenuCommand("Franciscan")
        Friend WithEvents prodMessaging_OtherCust_Maine As New MenuCommand("Maine")
        Friend WithEvents prodMessaging_OtherCust_SMHC As New MenuCommand("SMHC")
        Friend WithEvents prodMessaging_OtherCust_Anna_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_OtherCust_Anna_QC As New MenuCommand("QC")
        Friend WithEvents prodMessaging_OtherCust_Anna_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessaging_OtherCust_Anna_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessaging_OtherCust_Lahey_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_OtherCust_Lahey_QC As New MenuCommand("QC")
        Friend WithEvents prodMessaging_OtherCust_Lahey_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessaging_OtherCust_Lahey_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessaging_OtherCust_Masco_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_OtherCust_Masco_QC As New MenuCommand("QC")
        Friend WithEvents prodMessaging_OtherCust_Masco_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessaging_OtherCust_Masco_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessaging_OtherCust_Franciscan_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_OtherCust_Franciscan_QC As New MenuCommand("QC")
        Friend WithEvents prodMessaging_OtherCust_Franciscan_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessaging_OtherCust_Franciscan_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessaging_OtherCust_Maine_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_OtherCust_Maine_QC As New MenuCommand("QC")
        Friend WithEvents prodMessaging_OtherCust_Maine_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessaging_OtherCust_Maine_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessaging_OtherCust_SMHC_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_OtherCust_SMHC_QC As New MenuCommand("QC")
        Friend WithEvents prodMessaging_OtherCust_SMHC_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessaging_OtherCust_SMHC_ShipBox As New MenuCommand("Produce Box")

        'A-1 Wireless Communications
        Friend WithEvents prodMessagingMain_A1WC As New MenuCommand("A1 Wireless")
        Friend WithEvents prodMessagingMain_A1WC_CreateWO As New MenuCommand("Create Work Order")
        Friend WithEvents prodMessagingMain_A1WC_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodMessagingMain_A1WC_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_A1WC_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_A1WC_QC As New MenuCommand("QC")
        Friend WithEvents prodMessagingMain_A1WC_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_A1WC_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessagingMain_A1WC_BuildOtherShipPallet As New MenuCommand("Build Other Ship Pallet")

        'ATS
        Friend WithEvents prodMessagingMain_ATS As New MenuCommand("ATS")
        Friend WithEvents prodMessagingMain_ATS_CreateWO As New MenuCommand("Create Work Order")
        Friend WithEvents prodMessagingMain_ATS_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodMessagingMain_ATS_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_ATS_QC As New MenuCommand("QC")
        Friend WithEvents prodMessagingMain_ATS_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_ATS_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessagingMain_ATS_BuildOtherShipPallet As New MenuCommand("Build Other Ship Pallet")

        'Contact Wireless
        Friend WithEvents prodMessagingMain_CW As New MenuCommand("Contact Wireless")
        Friend WithEvents prodMessagingMain_CW_CreateWO As New MenuCommand("Create Work Order")
        Friend WithEvents prodMessagingMain_CW_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodMessagingMain_CW_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_CW_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_CW_QC As New MenuCommand("QC")
        Friend WithEvents prodMessagingMain_CW_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_CW_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessagingMain_CW_BuildOtherShipPallet As New MenuCommand("Build Other Ship Pallet")

        'Cook Pager
        Friend WithEvents prodMessagingMain_CP As New MenuCommand("Cook Pager")
        Friend WithEvents prodMessagingMain_CP_FreqCapcodeMgmt As New MenuCommand("Freq/Capcode Management")
        Friend WithEvents prodMessagingMain_CP_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_CP_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_CP_BuildOtherShipPallet As New MenuCommand("Build Other Ship Pallet")
        Friend WithEvents prodMessagingMain_CP_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_CP_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessagingMain_CP_QC As New MenuCommand("QC")

        'CoolPad
        Friend WithEvents prodCoolPad_Main As New MenuCommand("CoolPad")
        Friend WithEvents prodCoolPad_Main_Receiving As New MenuCommand("Receiving")
        Friend WithEvents prodCoolPad_Main_PreTest As New MenuCommand("PreTest")
        Friend WithEvents prodCoolPad_Main_RFTest As New MenuCommand("RF Test")
        Friend WithEvents prodCoolPad_Main_FlashTest As New MenuCommand("Flash Test")
        Friend WithEvents prodCoolPad_Main_TechBill As New MenuCommand("Tech Bill")
        Friend WithEvents prodCoolPad_Main_REF2Seed As New MenuCommand("REF to Seedstock")
        Friend WithEvents prodCoolPad_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodCoolPad_Main_Swap As New MenuCommand("Swap Device")
        Friend WithEvents prodCoolPad_Main_BuildBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodCoolPad_Main_ProduceBox As New MenuCommand("Produce Ship Box")
        Friend WithEvents prodCoolPad_Main_FulfillEndUserOrder As New MenuCommand("Fulfill EndUser Order")
        Friend WithEvents prodCoolPad_Main_Report As New MenuCommand("Report")

        'Critical Alert
        Friend WithEvents prodMessagingMain_CA As New MenuCommand("Critical Alert")
        Friend WithEvents prodMessagingMain_CA_FreqCapcodeMgmt As New MenuCommand("Freq/Capcode Management")
        Friend WithEvents prodMessagingMain_CA_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_CA_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_CA_BuildOtherShipPallet As New MenuCommand("Build Other Ship Pallet")
        Friend WithEvents prodMessagingMain_CA_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_CA_ShipBox As New MenuCommand("Produce Box")
        Friend WithEvents prodMessagingMain_CA_QC As New MenuCommand("QC")

        'Morris Communication
        Friend WithEvents prodMessagingMain_MorrisCom As New MenuCommand("Morris Communication")
        Friend WithEvents prodMessagingMain_MorrisCom_DBRManifest As New MenuCommand("Build MorrisCom Other Ship Pallet")
        Friend WithEvents prodMessagingMain_MorrisCom_FreqCapcodeMgmt As New MenuCommand("Freq/Capcode Management")
        Friend WithEvents prodMessagingMain_MorrisCom_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_MorrisCom_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_MorrisCom_BB As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_MorrisCom_Ship As New MenuCommand("Produce Box")

        'Propage
        Friend WithEvents prodMessagingMain_Propage As New MenuCommand("Propage")
        Friend WithEvents prodMessagingMain_Propage_DBRManifest As New MenuCommand("Build Propage Other Ship Pallet")
        Friend WithEvents prodMessagingMain_Propage_FreqCapcodeMgmt As New MenuCommand("Freq/Capcode Management")
        Friend WithEvents prodMessagingMain_Propage_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_Propage_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_Propage_BB As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_Propage_Ship As New MenuCommand("Produce Box")
        'Aquis
        Friend WithEvents prodMessagingMain_Aquis As New MenuCommand("Aquis")
        Friend WithEvents prodMessagingMain_Aquis_ModelSetup As New MenuCommand("Model Setup")
        'Friend WithEvents prodMessagingMain_Aquis_ProdRec As New MenuCommand("Production Receiving")
        Friend WithEvents prodMessagingMain_Aquis_FreqCapcodeMgmt As New MenuCommand("Freq/Capcode Management")
        Friend WithEvents prodMessagingMain_Aquis_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_Aquis_AQLOBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodMessagingMain_Aquis_BB As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_Aquis_Ship As New MenuCommand("Produce Box")

        'AMS InfraStructure
        Friend WithEvents prodMessagingMain_AMSInfraStructure As New MenuCommand("AMS InfraStructure")
        Friend WithEvents prodMessagingMain_AMSInfraStructure_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_AMSInfraStructure_Ship As New MenuCommand("Dock Ship")
        Friend WithEvents prodMessagingMain_AMSInfraStructure_Rec As New MenuCommand("Receiving")

        'NABCO
        Friend WithEvents prodNABCO_Main As New MenuCommand("NABCO")
        Friend WithEvents prodNABCO_Main_AddCharge As New MenuCommand("Add Charges")

        'Native Instruments
        Friend WithEvents prodNInst_Main As New MenuCommand("Native Instruments")
        Friend WithEvents prodNInst_Main_ShipReturnLabel As New MenuCommand("Ship Return Label")
        Friend WithEvents prodNInst_Main_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodNInst_Main_WipTransfFrWHToPreTest As New MenuCommand("Move from Warehouse to Pre-Test")
        Friend WithEvents prodNInst_Main_Triage As New MenuCommand("Pre-Test")
        Friend WithEvents prodNInst_Main_Testing As New MenuCommand("Test, Triage and Sort")
        Friend WithEvents prodNIstr_Main_PartReclaim As New MenuCommand("Reclaims Part")
        Friend WithEvents prodNInst_Main_Repair As New MenuCommand("Repair/Tech")
        Friend WithEvents prodNInst_Main_AQL As New MenuCommand("AQL")
        Friend WithEvents prodNInst_Main_Ship As New MenuCommand("Produce && Ship")
        Friend WithEvents prodNInst_Main_OBA As New MenuCommand("OBA")
        Friend WithEvents prodNInst_Main_Reports As New MenuCommand("Reports")
        Friend WithEvents prodNInst_Main_ManageActiveModels As New MenuCommand("Managing Repair Model")
        Friend WithEvents prodNInst_Main_MapNIProductPSSIMode As New MenuCommand("NI Product and PSSI Model Mapping")
        Friend WithEvents prodNInst_Main_BuildPackageMaterials As New MenuCommand("Build Package Materials")
        Friend WithEvents prodNInst_Main_ChangeCosmeticGrade As New MenuCommand("Change Cosmetic Grade")
        Friend WithEvents prodNInst_Main_Warehouse As New MenuCommand("Warehouse")
        Friend WithEvents prodNInst_Main_Warehouse_FillOrders As New MenuCommand("Fill Orders")
        Friend WithEvents prodNInst_Main_Warehous_AddWHCharge As New MenuCommand("Add Charges")
        Friend WithEvents prodNInst_Main_DataMagment As New MenuCommand("Data Management")
        Friend WithEvents prodNInst_Main_WipTransf As New MenuCommand("Wip Transfer")
        'GENERIC PROCESS
        Friend WithEvents prodGenericProcMain As New MenuCommand("Generic Process")
        Friend WithEvents prodGenericProcMain_CreateWO As New MenuCommand("Create Work Order")
        Friend WithEvents prodGenericProcMain_BuildShipLot As New MenuCommand("Build Ship Lot")
        Friend WithEvents prodGenericProcMain_ProduceLot As New MenuCommand("Produce Lot")
        Friend WithEvents prodGenericProcMain_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodGenericProcMain_Test As New MenuCommand("Testing")
        Friend WithEvents prodGenericProcMain_Test_PreTest As New MenuCommand("Pretest")
        Friend WithEvents prodGenericProcMain_Test_QC As New MenuCommand("Quality Control")
        'DRIVECAM
        Friend WithEvents prodDriveCam_Main As New MenuCommand("DriveCam")
        Friend WithEvents prodDriveCam_Main_Admin As New MenuCommand("Admin")
        Friend WithEvents prodDriveCam_Main_Billing As New MenuCommand("Billing")
        Friend WithEvents prodDriveCam_Main_BSB As New MenuCommand("Build and Ship Box")
        Friend WithEvents prodDriveCam_Main_DockShipment As New MenuCommand("Dock Shipment")
        Friend WithEvents prodDriveCam_Main_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodDriveCam_Main_Search As New MenuCommand("Search")
        Friend WithEvents prodDriveCam_Main_ShipBox As New MenuCommand("Ship Box")
        'SONITROL
        Friend WithEvents prodSonitroL_Main As New MenuCommand("Reverse Logistics")
        Friend WithEvents prodSonitrol_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodSonitroL_PBilling As New MenuCommand("Plexus Billing")
        Friend WithEvents prodSonitroL_SBilling As New MenuCommand("Sonitrol Billing")

        'TextNow, Inc (TN)
        Friend WithEvents prodTextNow_Main As New MenuCommand("Text Now, Inc.")
        Friend WithEvents prodTextNow_Main_Warehouse_DashBoard As New MenuCommand("TextNow SIMS Dashboard")
        Friend WithEvents prodTextNow_Main_Warehouse_Rec As New MenuCommand("Warehouse Receiving")
        Friend WithEvents prodTextNow_Main_Warehouse_FillOrders As New MenuCommand("Fill Order and Shipping")
        'Friend WithEvents prodTextNow_Main_Admin As New MenuCommand("Administration")
        'Friend WithEvents prodTextNow_Main_Admin_ASNImport As New MenuCommand("ASN File Import")
        'Friend WithEvents prodTextNow_Main_Admin_MdlPrfx_Config As New MenuCommand("Model Prefix Configuration")
        Friend WithEvents prodTextNow_Main_Reports As New MenuCommand("Reports")
        'Friend WithEvents prodTextNow_Main_Reports_Inv As New MenuCommand("Inventory")
        'Friend WithEvents prodTextNow_Main_Reports_Ord As New MenuCommand("Orders")

        'Vivint
        Friend WithEvents prodVivint_Main As New MenuCommand("Vivint")
        Friend WithEvents prodVivint_Main_WoDockRecv As New MenuCommand("WO Dock Receiving")
        Friend WithEvents prodVivint_Main_DeviceRecv As New MenuCommand("Device Receiving")
        Friend WithEvents prodVivint_Main_PreTest As New MenuCommand("PreTest")
        Friend WithEvents prodVivint_Main_TechBill As New MenuCommand("Tech Bill")
        'Friend WithEvents prodWIKO_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodVivint_Main_BuildBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodVivint_Main_ProduceBox As New MenuCommand("Produce Ship Box")
        Friend WithEvents prodVivint_Main_KittingLabelUnit As New MenuCommand("Kitting")
        Friend WithEvents prodVivint_Main_KittingSetup As New MenuCommand("Kitting Setup")
        Friend WithEvents prodVivint_Main_AQL_OBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodVivint_Main_Manifest As New MenuCommand("Manifest")
        Friend WithEvents prodVivint_Main_FulfillOrder As New MenuCommand("Fulfill Order")
        Friend WithEvents prodVivint_Main_PoRequest As New MenuCommand("PO Request")
        Friend WithEvents prodVivint_Main_OnHold As New MenuCommand("Manage On-Hold")
        Friend WithEvents prodVivint_Main_Report As New MenuCommand("Report")

        'WIKO
        Friend WithEvents prodWIKO_Main As New MenuCommand("WIKO")
        Friend WithEvents prodWIKO_Main_GenericConfig As New MenuCommand("Software Version")
        Friend WithEvents prodWIKO_Main_Receiving As New MenuCommand("Receiving")
        Friend WithEvents prodWIKO_Main_PreTest As New MenuCommand("PreTest")
        Friend WithEvents prodWIKO_Main_RFTest As New MenuCommand("RF Test")
        Friend WithEvents prodWIKO_Main_FlashTest As New MenuCommand("Flash Test")
        Friend WithEvents prodWIKO_Main_TechBill As New MenuCommand("Tech Bill")
        Friend WithEvents prodWIKO_Main_REF2Seed As New MenuCommand("REF to Seedstock")
        Friend WithEvents prodWIKO_Main_Swap As New MenuCommand("Swap Device")
        Friend WithEvents prodWIKO_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodWIKO_Main_BuildBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodWIKO_Main_ProduceBox As New MenuCommand("Produce Ship Box")
        Friend WithEvents prodWIKO_Main_Report As New MenuCommand("Report")
        Friend WithEvents prodWIKO_Main_SpecialBuildBox As New MenuCommand("Special Build Box")
        Friend WithEvents prodWIKO_Main_SpecialRecv As New MenuCommand("Special Receiving")
        Friend WithEvents prodWIKO_Main_SpecialKitting As New MenuCommand("Special SIM Card Install (Kit)")

        'WingTech T-Mobile
        Friend WithEvents prodWingTech_Main As New MenuCommand("WingTech")
        Friend WithEvents prodWingTech_Main_Receiving As New MenuCommand("Receiving")
        Friend WithEvents prodWingTech_Main_GenericConfig As New MenuCommand("Software Version")
        Friend WithEvents prodWingTech_Main_PreTest As New MenuCommand("PreTest")
        Friend WithEvents prodWingTech_Main_RFTest As New MenuCommand("RF Test")
        Friend WithEvents prodWingTech_Main_FlashTest As New MenuCommand("Flash Test")
        Friend WithEvents prodWingTech_Main_TechBill As New MenuCommand("Tech Bill")
        Friend WithEvents prodWingTech_Main_REF2Seed As New MenuCommand("REF to Seedstock")
        'Friend WithEvents prodWingTech_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodWingTech_Main_Swap As New MenuCommand("Swap Device")
        Friend WithEvents prodWingTech_Main_BuildBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodWingTech_Main_ProduceBox As New MenuCommand("Produce Ship Box")
        'Friend WithEvents prodWingTech_Main_FulfillEndUserOrder As New MenuCommand("Fulfill EndUser Order")
        Friend WithEvents prodWingTech_Main_Report As New MenuCommand("Report")

        'WingTech ATT
        Friend WithEvents prodWingTechATT_Main As New MenuCommand("WingTechATT")
        Friend WithEvents prodWingTechATT_Main_Receiving As New MenuCommand("Receiving")
        Friend WithEvents prodWingTechATT_Main_PreTest As New MenuCommand("PreTest")
        Friend WithEvents prodWingTechATT_Main_RFTest As New MenuCommand("RFTest")
        Friend WithEvents prodWingTechATT_Main_FlashTest As New MenuCommand("Flash Test")
        Friend WithEvents prodWingTechATT_Main_TechBill As New MenuCommand("TechBill")
        Friend WithEvents prodWingTechATT_Main_REF2Seed As New MenuCommand("REF to Seedstock")
        Friend WithEvents prodWingTechATT_Main_Swap As New MenuCommand("Swap Device")
        Friend WithEvents prodWingTechATT_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodWingTechATT_Main_BuildBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodWingTechATT_Main_ProduceBox As New MenuCommand("Produce Ship Box")
        Friend WithEvents prodWingTechATT_Main_SpecialBuildBox As New MenuCommand("Special Build Box")
        Friend WithEvents prodWingTechATT_Main_SpecialRecv As New MenuCommand("Special Receiving")
        Friend WithEvents prodWingTechATT_Main_SpecialKitting As New MenuCommand("Special SIM Card Install (Kit)")
        Friend WithEvents prodWingTechATT_Main_Report As New MenuCommand("Report")

        'VINSMART
        Friend WithEvents prodVinsmart_Main As New MenuCommand("Vinsmart")
        Friend WithEvents prodVinsmart_Main_Receiving As New MenuCommand("Receiving")
        Friend WithEvents prodVinsmart_Main_PreTest As New MenuCommand("PreTest")
        Friend WithEvents prodVinsmart_Main_RFTest As New MenuCommand("RF Test")
        Friend WithEvents prodVinsmart_Main_FlashTest As New MenuCommand("Flash Test")
        Friend WithEvents prodVinsmart_Main_TechBill As New MenuCommand("Tech Bill")
        Friend WithEvents prodVinsmart_Main_REF2Seed As New MenuCommand("REF to Seedstock")
        Friend WithEvents prodVinsmart_Main_Swap As New MenuCommand("Swap Device")
        Friend WithEvents prodVinsmart_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodVinsmart_Main_BuildBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodVinsmart_Main_ProduceBox As New MenuCommand("Produce Ship Box")
        Friend WithEvents prodVinsmart_Main_SpecialBuildBox As New MenuCommand("Special Build Box")
        Friend WithEvents prodVinsmart_Main_SpecialRecv As New MenuCommand("Special Receiving")
        Friend WithEvents prodVinsmart_Main_AQL_OBA As New MenuCommand("AQL-OBA Test")
        'Friend WithEvents prodVinsmart_Main_SpecialKitting As New MenuCommand("Special SIM Card Install (Kit)")
        Friend WithEvents prodVinsmart_Main_Report As New MenuCommand("Report")

        'Ziosk
        Friend WithEvents prodZiosk_Main As New MenuCommand("Ziosk")
        Friend WithEvents prodZiosk_Main_Label As New MenuCommand("Labeling")


#Region "TRACFONE"
        Friend WithEvents prodTF_Main As New MenuCommand("TracFone")
        Friend WithEvents prodTF_Main_ExcelRpt As New MenuCommand("Excel Report")
        Friend WithEvents prodTF_Main_Admin As New MenuCommand("Admin Functions")
        Friend WithEvents prodTF_Main_SetModelStatus As New MenuCommand("Set Model Status")
        Friend WithEvents prodTF_Main_Billing As New MenuCommand("Billing")
        Friend WithEvents prodTF_Main_Tech As New MenuCommand("Tech")
        Friend WithEvents prodTF_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodTF_Main_ProdTrack As New MenuCommand("Productivity Tracking")
        Friend WithEvents prodTF_Main_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodTF_Main_Ship As New MenuCommand("Shipping")
        Friend WithEvents prodTF_Main_Test As New MenuCommand("Testing")
        Friend WithEvents prodTF_Main_Warehouse As New MenuCommand("Warehouse")
        Friend WithEvents prodTF_Main_Wip As New MenuCommand("Wip Transfer")

        Friend WithEvents prodTF_Main_PreEval As New MenuCommand("Pre-Eval")
        Friend WithEvents prodTF_Main_Tech_PartReclaim As New MenuCommand("Reclaims Part")
        Friend WithEvents prodTF_Main_Tech_BER As New MenuCommand("BER Screen")
        Friend WithEvents prodTF_Main_PreBuff As New MenuCommand("Pre-Buff")
        Friend WithEvents prodTF_Main_Tech_PreBill As New MenuCommand("Pre-Bill")
        Friend WithEvents prodTF_Main_Tech_Refurbished As New MenuCommand("Refurbished")

        Friend WithEvents prodTF_Main_Rec_WH As New MenuCommand("Warehouse")
        Friend WithEvents prodTF_Main_Rec_Cell As New MenuCommand("Cell")

        Friend WithEvents prodTF_Main_Test_AQL_OBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodTF_Main_Test_BERCheck As New MenuCommand("BER Check")
        Friend WithEvents prodTF_Main_Test_Final As New MenuCommand("FQA Test")
        Friend WithEvents prodTF_Main_Test_Pretest As New MenuCommand("Pretest Test")
        Friend WithEvents prodTF_Main_Test_PSD As New MenuCommand("PSD Test")
        Friend WithEvents prodTF_Main_Test_RF1 As New MenuCommand("RF 1 Test")
        Friend WithEvents prodTF_Main_Test_RF2 As New MenuCommand("RF 2 Test")
        Friend WithEvents prodTF_Main_Test_SWScreening As New MenuCommand("Software Screening")
        Friend WithEvents prodTF_Main_Test_SoftRef As New MenuCommand("Software Refurbish")
        Friend WithEvents prodTF_Main_Test_Triage As New MenuCommand("Triage")
        Friend WithEvents prodTF_Main_Test_BuildTriagedBox As New MenuCommand("Build Triaged Box")

        Friend WithEvents prodTF_Ship_BuildShipPallet As New MenuCommand("Build Ship Box")
        Friend WithEvents prodTF_Ship_BuildShipPalletAcc As New MenuCommand("Build Ship Box Accessory")
        Friend WithEvents prodTF_Ship_ShipPallet As New MenuCommand("Produce Box")

        Friend WithEvents prodTF_Main_Warehouse_AssignBatteryCover As New MenuCommand("Assign Battery Cover")
        Friend WithEvents prodTF_Main_Warehouse_UnassignBatteryCover As New MenuCommand("Unassign Battery Cover")
        Friend WithEvents prodTF_Main_Warehouse_AssignWHLoc As New MenuCommand("Assign Warehouse Location")
        Friend WithEvents prodTF_Main_Warehouse_SearchWHRecInfo As New MenuCommand("Search Receive Data")
        Friend WithEvents prodTF_Main_Warehouse_FillOpenOrder As New MenuCommand("Fill Open Order")
        Friend WithEvents prodTF_Main_Warehouse_Manifest As New MenuCommand("Manifest")
        Friend WithEvents prodTF_Main_Warehouse_ManifestBER As New MenuCommand("Manifest BER")

        Friend WithEvents prodTF_Main_TransferBoxes As New MenuCommand("Transfer Boxes")
        Friend WithEvents prodTF_Main_WipTrans_ToEngineering As New MenuCommand("To Engineering")
        Friend WithEvents prodTF_Main_WipTrans_ToObsolete As New MenuCommand("To Obsolete")
        Friend WithEvents prodTF_Main_WipTrans_ToProdHold As New MenuCommand("To Production Hold")
        Friend WithEvents prodTF_Main_WipTrans_ToBERComplete As New MenuCommand("To BER Complete")
        Friend WithEvents prodTF_Main_WipTrans_ToBER As New MenuCommand("To BER")
        Friend WithEvents prodTF_Main_WipTrans_ToBERScreen As New MenuCommand("To BER Screen")
        Friend WithEvents prodTF_Main_WipTrans_ToTeardown As New MenuCommand("To Teardown")
        Friend WithEvents prodTF_Main_WipTrans_ToQuarantine As New MenuCommand("To QUARANTINE")
        'Friend WithEvents prodTF_Main_WipTrans_ToFFBS As New MenuCommand("To Functional Fail BS")
        'Friend WithEvents prodTF_Main_WipTrans_ToFFCP As New MenuCommand("To Functional Fail CP")
        'Friend WithEvents prodTF_Main_WipTrans_ToFFTF As New MenuCommand("To Functional Fail TF")

        Friend WithEvents prodTF_Main_WipTrans_ToPreBill As New MenuCommand("To Pre-Bill")
        Friend WithEvents prodTF_Main_WipTrans_ToPretest As New MenuCommand("To Pretest")
        Friend WithEvents prodTF_Main_WipTrans_ToStaging As New MenuCommand("To Production Staging")
        Friend WithEvents prodTF_Main_WipTrans_ToRF1 As New MenuCommand("To RF1")
        Friend WithEvents prodTF_Main_WipTrans_ToWHRB As New MenuCommand("To WH-RB")
        Friend WithEvents prodTF_Main_WipTrans_ToWHWIP As New MenuCommand("To WH-WIP")
        Friend WithEvents prodTF_Main_WipTrans_ToAWAP As New MenuCommand("To AWAP")
        Friend WithEvents prodTF_Main_WipTrans_RemoveFrFailAWP As New MenuCommand("Remove From Fail and AWAP")
        Friend WithEvents prodTF_Main_WipTrans_Admin As New MenuCommand("Admin")

#End Region

#Region "TracFone FulfillmentKit"
        Friend WithEvents prodTFFK_Main As New MenuCommand("TracFone FulfillmentKit")
        Friend WithEvents prodTFFK_Main_Admin As New MenuCommand("Admin Functions")
        Friend WithEvents prodTFFK_Main_Rec As New MenuCommand("WH Receiving")
        Friend WithEvents prodTFFK_Main_Transfer As New MenuCommand("WH Transfer")
        Friend WithEvents prodTFFK_Main_Pick As New MenuCommand("Printer/Pick")
        Friend WithEvents prodTFFK_Main_Pack As New MenuCommand("Pack and Ship")
        Friend WithEvents prodTFFK_Main_Relabel As New MenuCommand("Relabel")
        Friend WithEvents prodTFFK_Main_Ship As New MenuCommand("Shipment")
        Friend WithEvents prodTFFK_Main_Item_History As New MenuCommand("Item History")
        Friend WithEvents prodTFFK_Main_Report As New MenuCommand("Report")
        Friend WithEvents prodTFFK_Main_QC As New MenuCommand("Kitting QC")
        Friend WithEvents prodTFFK_Main_KittedRpt As New MenuCommand("Kitted Report")
        Friend WithEvents prodTFFK_Main_BYOP_Kitting As New MenuCommand("BYOP Kitting")
        Friend WithEvents prodTFFK_Main_BYOP_Kitting_Setup As New MenuCommand("Kitting Setup")
        Friend WithEvents prodTFFK_Main_BYOP_Kitting_Pack As New MenuCommand("Build Pack")
        Friend WithEvents prodTFFK_Main_BYOP_Kitting_MCarton As New MenuCommand("Build Master Carton")
        Friend WithEvents prodTFFK_Main_BYOP_Kitting_Pallet As New MenuCommand("Build Pallet")
        Friend WithEvents prodTFFK_Main_BYOP_SimplePacking As New MenuCommand("Simple Pack (Re-pack)")
        Friend WithEvents prodTFFK_Main_RAC_GIN As New MenuCommand("TFFK RAC/GIN Fulfillment")
        Friend WithEvents prodTFFK_Main_RAC_GIN_FillOrder As New MenuCommand("TFFK RAC/GIN FillOrder")

#End Region

#Region "WFM (Tracfone)"

        Friend WithEvents prodWFM_Main As New MenuCommand("WFM (TracFone)")
        Friend WithEvents prodWFM_Main_Receiving As New MenuCommand("Receiving")
        Friend WithEvents prodWFM_Main_BldBx As New MenuCommand("Build Box")
        Friend WithEvents prodWFM_Main_BldBx_BldIBBx As New MenuCommand("Build Inbound Box")
        Friend WithEvents prodWFM_Main_BldBx_BldTrgdBx As New MenuCommand("Build Triaged Box")
        Friend WithEvents prodWFM_Main_ProduceNTFBox As New MenuCommand("Produce NTF Box")
        Friend WithEvents prodWFM_Main_WT As New MenuCommand("WIP Transfer")
        Friend WithEvents prodWFM_Main_WT_ToTrgStgngBulk As New MenuCommand("To Triage Staging")
        Friend WithEvents prodWFM_Main_WT_ToTrg As New MenuCommand("To Triage")
        Friend WithEvents prodWFM_Main_Tstng As New MenuCommand("Testing")
        Friend WithEvents prodWFM_Main_Tstng_Trg As New MenuCommand("Triage")
        Friend WithEvents prodWFM_Main_Tstng_AQL_OBA As New MenuCommand("AQL-OBA Test")
        Friend WithEvents prodWFM_Main_WH As New MenuCommand("Warehouse")
        Friend WithEvents prodWFM_Main_WH_AsgnWhLoc As New MenuCommand("Assign Warehoue Location")
        Friend WithEvents prodWFM_Main_WH_SNSearch As New MenuCommand("Serial Number Search")
        Friend WithEvents prodWFM_Main_Admin As New MenuCommand("Administration")
        Friend WithEvents prodWFM_Main_Admin_ASN_Imp As New MenuCommand("ASN File Import")
        Friend WithEvents prodWFM_Main_Admin_MdlPrfx_Cnfg As New MenuCommand("Model Prefix Configuration")
        Friend WithEvents prodWFM_Main_Reports As New MenuCommand("Reports")
        Friend WithEvents prodWFM_Main_Warehouse_FillOpenOrder As New MenuCommand("Fill Open Order")
        Friend WithEvents prodWFM_Main_Warehouse_Manifest As New MenuCommand("Manifest")
        Friend WithEvents prodWFM_Main_Ship As New MenuCommand("Shipping")
        Friend WithEvents prodWFM_Ship_BuildShipPalletAcc As New MenuCommand("Build Ship Box Accessory")
        Friend WithEvents prodWFM_Ship_SplitOutboundBox As New MenuCommand("Split Outbound Box")
#End Region



        Friend WithEvents prodWIPMain As New MenuCommand("WIP")
        Friend WithEvents prodTransferDevicesToPreCell As New MenuCommand("Transfer Devices to Pre-Cell")
        Friend WithEvents prodTransferDevicesToHold As New MenuCommand("Transfer Devices to Hold")
        Friend WithEvents prodAudit As New MenuCommand("Audit")
        Friend WithEvents prodAudit_DevBillHist As New MenuCommand("Device Billing History")

        '// reports menus
        Friend WithEvents rptAdminRev As New MenuCommand("Admin Revenue Summary")
        Friend WithEvents rptAdminRevDetail As New MenuCommand("Admin Revenue Detail")
        Friend WithEvents rptAdminOpsSumm As New MenuCommand("Admin Operation Summary")
        Friend WithEvents rptAdminCycMonth As New MenuCommand("Admin Cycle Monthly")
        Friend WithEvents rptAdminCycWeek As New MenuCommand("Admin Cycle Weekly")
        Friend WithEvents rptAdminCntLessWrty As New MenuCommand("Admin Count Less Warranty")
        Friend WithEvents rptAdminAUPCustMod As New MenuCommand("Admin Revenue/AUP by Customer and Model")
        Friend WithEvents rptAdminAUPForProduced As New MenuCommand("Admin Revenue/AUP Daily Production")
        Friend WithEvents rptAdminRevForProduced As New MenuCommand("Admin Revenue Daily Production")
        Friend WithEvents rptAdmin563RevRpt As New MenuCommand("563 Revenue Report")
        Friend WithEvents rptAdminWIP As New MenuCommand("&Admin WIP")
        Friend WithEvents rptAdminWIPDetail As New MenuCommand("Admin WIP Detail")
        Friend WithEvents rptAdminWIPDetailByLocation As New MenuCommand("Admin WIP Detail by Location")
        Friend WithEvents rptMessagingWIPByCustomerAndModel As New MenuCommand("Messaging WIP by Customer and Model")
        Friend WithEvents rptAdminAUP As New MenuCommand("Admin Average Unit Price")
        Friend WithEvents rptAdminCustLocAdd As New MenuCommand("Admin Customer Locations")
        Friend WithEvents rptAdminRURcnt As New MenuCommand("Admin Location RUR Count")
        Friend WithEvents rptAdminSent2Ftry As New MenuCommand("Admin Sent To Factory")
        Friend WithEvents rptAdminBilledNotShipped As New MenuCommand("Admin Billed Not Shipped")
        Friend WithEvents rptAdminCustPartsCount As New MenuCommand("Admin Customer Parts Count")
        Friend WithEvents rptAdminMotoBatchRecon As New MenuCommand("Motorola-NSC Batch Claim Reconciliation")
        Friend WithEvents rptAdminDBRDuplicate As New MenuCommand("Admin DBR Duplicate")
        Friend WithEvents rptAdminMotoWrtyCount As New MenuCommand("Admin Motorola Warranty Count")
        Friend WithEvents rptAdminSpecialBT As New MenuCommand("Admin Special BT")
        Friend WithEvents rptAdminOpsSumWkly As New MenuCommand("Admin Ops Sum Weekly")
        Friend WithEvents rptAdminDeviceCnt As New MenuCommand("Admin Device Count")
        Friend WithEvents rptAdminMessagingProductWIP As New MenuCommand("Messaging Product WIP")
        Friend WithEvents rptRURRTMCheck As New MenuCommand("RUR/RTM Check")
        Friend WithEvents rptWIPStatusReport As New MenuCommand("WIP Status Report")
        'added by Amazech-Thanga 11.10.2021
        Friend WithEvents rptAdminRAUpload As New MenuCommand("Admin RA Upload/Received Report")

        '***************************
        'REPORT-> EXCEL OUTPUT 
        '***************************
        Friend WithEvents rptEO_EGR As New MenuCommand("Excel General Reports")
        Friend WithEvents rptAdminCostCenterRpt As New MenuCommand("Cost Center Report")
        Friend WithEvents rptAdminPretestRpt As New MenuCommand("Pretest Report")
        Friend WithEvents rptAdminPretQCH_Rpt As New MenuCommand("Pretest/QC History Report")
        Friend WithEvents rptAdminQCRpt As New MenuCommand("QC Report")
        Friend WithEvents rptAdminQR_Rpt As New MenuCommand("QR Report")
        Friend WithEvents rptAdminRepRefRURRpt As New MenuCommand("Repair/Refurbish/RUR Report")
        Friend WithEvents rptAdminRH_Rpt As New MenuCommand("Repair History Report")
        Friend WithEvents rptAdminRF_Rpt As New MenuCommand("RF Report")
        Friend WithEvents rptAdminSWRefTestResult_Rpt As New MenuCommand("Software Refurbish Report")
        Friend WithEvents rptAdminWCDetail As New MenuCommand("Work Center Report")
        Friend WithEvents rptDupSerial As New MenuCommand("Admin Duplicate Serial Numbers")
        Friend WithEvents rptWeeklyDevices As New MenuCommand("Admin Weekly Devices")
        Friend WithEvents rptBillEmpCnt As New MenuCommand("Bill Employee Count")
        Friend WithEvents rptFinInvCCrd As New MenuCommand("&Finance Invoice Credit Card")
        Friend WithEvents rptFinCCrdRecon As New MenuCommand("&Finance Credit Card Reconciliation")
        Friend WithEvents rptFinInvDetail As New MenuCommand("Finance Invoice Detail")
        Friend WithEvents rptFinInvManifCnt As New MenuCommand("Finance Invoice by Manifest")
        Friend WithEvents rptFinTwoWayRevenue As New MenuCommand("&Finance Two Way Revenue")
        Friend WithEvents rptFinEmplWCCnt As New MenuCommand("&Finance Employee WC Count")
        Friend WithEvents rptFinWCHrsCnt As New MenuCommand("&Finance WC Hours Count")
        Friend WithEvents rptFinDeviceCnt As New MenuCommand("&Finance Device Count")
        Friend WithEvents rptFinPallettInvoice As New MenuCommand("&Finance Pallett Invoice")
        Friend WithEvents rptFinWHStatusDetail As New MenuCommand("&Finance WorkHours Status Detail")
        Friend WithEvents rptFinWHStatusSummary As New MenuCommand("&Finance WorkHours Status Summary")
        Friend WithEvents rptFinBatchRecon As New MenuCommand("Batch Reconciliation")
        Friend WithEvents rptFinBatchRejects As New MenuCommand("Batch Rejects")
        Friend WithEvents rptFinReconStatus As New MenuCommand("Recon Status")
        Friend WithEvents rptProdRcvdDevCntByCust As New MenuCommand("Production Received Device Count by Customer")
        Friend WithEvents rptRecCntDly As New MenuCommand("Receiving Count Daily")
        Friend WithEvents rptRecCntDly2Lvl As New MenuCommand("Receiving Count Daily (Extended Detail)")
        Friend WithEvents rptRecCntMnthly2Lvl As New MenuCommand("Receiving Count Monthly (Extended Detail)")
        Friend WithEvents rptRecCntDlyMWrty As New MenuCommand("Receiving Count Daily by M/nonM Warranty")
        Friend WithEvents rptRecEmpCnt As New MenuCommand("Receiving Employee Count")
        Friend WithEvents rptRecCntMonth As New MenuCommand("Receiving Count Monthly")
        Friend WithEvents rptVerExc As New MenuCommand("Receiving Verizon Exception")
        Friend WithEvents rptRecDetail As New MenuCommand("Receiving Detail")
        Friend WithEvents rptRecCntDailyStaged As New MenuCommand("Receiving Count Daily Staged")
        Friend WithEvents rptRecAmericanMessStagedNotRcvd As New MenuCommand("American Messaging Staged but not Received Report")
        Friend WithEvents rptRecAmericanMessWIP As New MenuCommand("American Messaging WIP Report")
        Friend WithEvents rptCellLineProd As New MenuCommand("Cell Line Production")
        Friend WithEvents rptCellProdSummary As New MenuCommand("Cell Production Summary")
        Friend WithEvents rptShipDevQtyByShipType As New MenuCommand("Shipped Device Qty by Ship Type")
        Friend WithEvents rptWHPalletsNotRcvd As New MenuCommand("Warehouse Pallets not Received into Prod WIP")
        Friend WithEvents rptCellShippedPallets As New MenuCommand("Cell Shipped Pallets")
        Friend WithEvents rptAllSNsShippedOnDateForCust As New MenuCommand("All SNs Shipped on a Date for a Customer")
        Friend WithEvents rptShipCntDly As New MenuCommand("Shipping Count Daily")
        Friend WithEvents rptShipCntDly2Lvl As New MenuCommand("Shipping Count Daily (Extended Detail)")
        Friend WithEvents rptShipEmpCnt As New MenuCommand("Shipping Employee Count")
        Friend WithEvents rptShipRLRMASum As New MenuCommand("Shipping RL RMA Sum")
        Friend WithEvents rptATCLEPassFail As New MenuCommand("ATCLE Pass/Fail")
        Friend WithEvents rptAmericanMessagingShipDemand As New MenuCommand("American Messaging Ship Demand")
        Friend WithEvents rptTechRefurbQtyRpt As New MenuCommand("Technician Refurb Qty Report")
        Friend WithEvents rptMessLblProdRpt As New MenuCommand("Messaging Label Production")
        Friend WithEvents rptSNsByRcvedPalletRpt As New MenuCommand("Print SN barcodes by Received Pallet Name")
        Friend WithEvents rptMotoWrty As New MenuCommand("Motorolla ASC Warranty")
        'REPORTS => INVENTORY
        Friend WithEvents rptPartsB2IDetail As New MenuCommand("Parts Billed to Issued Detail")
        Friend WithEvents rptPartsB2ISumm As New MenuCommand("Parts Billed to Issued Summary")
        Friend WithEvents rptPartsAnalysis As New MenuCommand("Parts Analysis")
        Friend WithEvents rptInvPartsConsumption As New MenuCommand("Parts Consumption")
        Friend WithEvents rptPartsCount As New MenuCommand("Parts Count")
        Friend WithEvents rptScrapsCount As New MenuCommand("Scrap Quantity")
        Friend WithEvents rptShopFloorQtyReport As New MenuCommand("Shop Floor Quantity Report")
        Friend WithEvents rptPartsMappedAnalysis As New MenuCommand("Parts Mapped Analysis")
        Friend WithEvents rptInvModelMap As New MenuCommand("Inventory Model Mapping")
        Friend WithEvents rptPartsAndBillCodesByModel As New MenuCommand("Parts and Bill Codes by Model")
        Friend WithEvents rptBilledIssuedCell As New MenuCommand("Billed Issued Cell")
        Friend WithEvents rptNonMappedCellParts As New MenuCommand("Non Mapped Cell Parts")
        '// DOCUMENTS menus
        Friend WithEvents mnuDocuments_DocLocMap As New MenuCommand("Document Location Map")
        Friend WithEvents mnuDocuments_WorkInstruction As New MenuCommand("Work Instruction")
        '// help menus
        Friend WithEvents helpHelp As New MenuCommand("&Help", System.Windows.Forms.Shortcut.F1)
        Friend WithEvents helpAbout As New MenuCommand("&About PSS.Net...")
        '// report test menus
        Friend WithEvents smAdmin As New MenuCommand("Administration")
        Friend WithEvents smCellSpec As New MenuCommand("Excel Output")
        Friend WithEvents smBilling As New MenuCommand("Billing")
        Friend WithEvents smFinance As New MenuCommand("Finance")
        Friend WithEvents smHumanResources As New MenuCommand("Human Resources")
        Friend WithEvents smQualityControl As New MenuCommand("Quality Control")
        Friend WithEvents smInventory As New MenuCommand("Inventory")
        Friend WithEvents smReceiving As New MenuCommand("Receiving")
        Friend WithEvents smShipping As New MenuCommand("Shipping")
        Friend WithEvents smProduction As New MenuCommand("Production")
        'Finance
        Friend WithEvents smFinance_NavReports As New MenuCommand("Navision Reports")
        Friend WithEvents prodInventory As New MenuCommand("Inventory")
        Friend WithEvents ProdReplenishRecover As New MenuCommand("Replenish/Recover Parts")
        Friend WithEvents ProdGroupLineSideBenchMap As New MenuCommand("Manage Groups, Lines, Sides, Benches, Cost Centers")
        '//Production SubMenu - Pretest
        Friend WithEvents smPretestOptions As New MenuCommand("Pretest Options")

#Region "WAREHOUSE"
        Friend WithEvents prodWarehouse As New MenuCommand("Warehouse")
        Friend WithEvents prodWarehouse_DockShipment As New MenuCommand("Dock Shipment")
        Friend WithEvents prodWarehouse_SendPalletPackingListFiles As New MenuCommand("Manifest Processing")
        Friend WithEvents prodWarehouse_PrintUPCLabel As New MenuCommand("Print UPC Label")
        'ENGINEERING
        Friend WithEvents engManageManufCodes As New MenuCommand("Manage Manufacturer Codes Map")
#End Region

#End Region
#Region "PAGE EVENTS"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
        End Sub
        Private Sub InitializeComponent()
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            mnuFile.MenuCommands.AddRange(New MenuCommand() {filClose, filCloseA, mnuDiv, filExit})
            filSystem.MenuCommands.Add(sysSecurity)
            filSystem.MenuCommands.Add(mnuDiv)
            filSystem.MenuCommands.Add(sysInfo)
            filSystem.MenuCommands.Add(mnuDiv)
            filSystem.MenuCommands.Add(sysWCL)

            '// add our admin menus
            Dim iMessagingSecure As Integer = 0
            Dim iCelSecure As Integer = 0
            Dim iRMASecure As Integer = 0
            Dim iShipLocChg As Integer = 0

            mnuAdmin.MenuCommands.AddRange(New MenuCommand() {prodDisplayCount, mnuDiv})

            'Messaging Security
            If ApplicationUser.GetPermission("frmRecEdit") > 0 Then
                iMessagingSecure = 1
            End If
            If ApplicationUser.GetPermission("frmEdit_SKU") > 0 Then
                iMessagingSecure = 1
            End If
            If ApplicationUser.GetPermission("SkuEdit_Messaging") > 0 Then
                iMessagingSecure = 1
            End If
            'Cellular Security
            If ApplicationUser.GetPermission("frmPreDefineRMArec") > 0 Then
                iRMASecure = 1
            End If
            If ApplicationUser.GetPermission("frmCelAdmin") > 0 Then
                iCelSecure = 1
            End If
            '// add our customer service menus
            If ApplicationUser.GetPermission("frmCustMaint") > 0 Then
                mnuCustServ.MenuCommands.Add(csCompany)
            End If
            If ApplicationUser.GetPermission("frmCustMaintSearch") > 0 Then
                mnuCustServ.MenuCommands.Add(csCompanySearch)
            End If
            If ApplicationUser.GetPermission("CompAdmin") > 0 Then
                mnuCustServ.MenuCommands.Add(csSalesPerson)
            End If
            If ApplicationUser.GetPermission("frmModelTarget") > 0 Then
                mnuCustServ.MenuCommands.Add(csModelTarget)
            End If
            If ApplicationUser.GetPermission("frmSpecialBillingDetails") > 0 Then
                mnuCustServ.MenuCommands.Add(csSpecialBillingDetails)
            End If
            If ApplicationUser.GetPermission("frmExceptionBillItems") > 0 Then
                mnuCustServ.MenuCommands.Add(csExceptionBillItems)
            End If
            If ApplicationUser.GetPermission("PalletPackingSlipInfo") > 0 Then
                mnuCustServ.MenuCommands.Add(csPalletPackingSlipInfo)
            End If
            If ApplicationUser.GetPermission("RURPriceException") > 0 Then
                mnuCustServ.MenuCommands.Add(csEditRURPriceException)
            End If
            'INVENTORY MENU
            If PSS.Core.ApplicationUser.GetPermission("ASCPriceWin") > 0 Then
                mnuInventory.MenuCommands.Add(invASCPrice)
            End If
            If PSS.Core.ApplicationUser.GetPermission("BillCodeWin") > 0 Then
                mnuInventory.MenuCommands.Add(invBillCodes)
            End If
            If PSS.Core.ApplicationUser.GetPermission("BillGroupAdmin") > 0 Then
                mnuInventory.MenuCommands.Add(invBillGroupAdmin)
            End If
            If PSS.Core.ApplicationUser.GetPermission("CreateBillGroups") > 0 Then
                mnuInventory.MenuCommands.Add(invCreateBillGroups)
            End If
            If PSS.Core.ApplicationUser.GetPermission("FailCodeWin") > 0 Then
                mnuInventory.MenuCommands.Add(invFailCodes)
            End If
            If PSS.Core.ApplicationUser.GetPermission("InactivateBillCodes") > 0 Then
                mnuInventory.MenuCommands.Add(invInactivateBillCodes)
            End If
            If PSS.Core.ApplicationUser.GetPermission("InactivateBillCodesC") > 0 Then
                mnuInventory.MenuCommands.Add(invInactivateBillCodesC)
            End If
            If ApplicationUser.GetPermission("LaborLvl") > 0 Then
                mnuInventory.MenuCommands.Add(invLaborLvl)
            End If
            If PSS.Core.ApplicationUser.GetPermission("ModManufWin") > 0 Then
                mnuInventory.MenuCommands.Add(invServInv)
            End If
            If PSS.Core.ApplicationUser.GetPermission("PricingWin") > 0 Then
                mnuInventory.MenuCommands.Add(invPartsPrice)
            End If
            If PSS.Core.ApplicationUser.GetPermission("PartsMap") > 0 Then
                mnuInventory.MenuCommands.Add(invPartsMap)
            End If
            If PSS.Core.ApplicationUser.GetPermission("PartsRelated") > 0 Then
                mnuInventory.MenuCommands.Add(invPartsRelated)
            End If
            If PSS.Core.ApplicationUser.GetPermission("PartSNCapture") > 0 Then
                mnuInventory.MenuCommands.Add(invPartsSNCapture)
            End If
            If PSS.Core.ApplicationUser.GetPermission("RepairCodeWin") > 0 Then
                mnuInventory.MenuCommands.Add(invRepairCodes)
                mnuInventory.MenuCommands.Add(mnuDiv)
            End If

            'PRODUCTION MENU
            mnuProduction.MenuCommands.AddRange(New MenuCommand() {prodSearch})
            If ApplicationUser.GetPermission("MessAdmin") > 0 Then
                mnuProduction.MenuCommands.AddRange(New MenuCommand() {mnuDiv, prodDeviceActivity})
                mnuProduction.MenuCommands.AddRange(New MenuCommand() {prodDeviceActivityStats, mnuDiv})
            End If

            'PRODUCTION => COST CENTER 
            mnuProduction.MenuCommands.Add(prodCCMain)
            If ApplicationUser.GetPermission("CC_TimeTracking") > 0 Then
                prodCCMain.MenuCommands.Add(prodCC_TimeTracking)
            End If
            If ApplicationUser.GetPermission("ScanDevicesIntoCostCenter") > 0 Then
                prodCCMain.MenuCommands.AddRange(New MenuCommand() {mnuDiv, prodCC_ScanDevToCC})
            End If
            If ApplicationUser.GetPermission("CCUPHUpdate") > 0 Then
                prodCCMain.MenuCommands.AddRange(New MenuCommand() {prodCC_SetUPH, mnuDiv})
            End If
            prodCCMain.MenuCommands.AddRange(New MenuCommand() {prodCC_MapEmpDept, mnuDiv})

            'PRODUCTION => INVENTORY 
            mnuProduction.MenuCommands.Add(prodInventory)
            If ApplicationUser.GetPermission("ManageGroupLineSideBenchMap") > 0 Then
                prodInventory.MenuCommands.Add(ProdGroupLineSideBenchMap)
            End If

            If ApplicationUser.GetPermission("Replenish/Recover Parts") > 0 Then
                prodInventory.MenuCommands.Add(ProdReplenishRecover)
            End If
            'PRODUCTION => PRETEST
            mnuProduction.MenuCommands.Add(smPretestOptions)
            If ApplicationUser.GetPermission("rfPreTest") > 0 Then
                smPretestOptions.MenuCommands.Add(prodPreTest)
            End If
            'PRODUCTION => WIP
            mnuProduction.MenuCommands.Add(prodWIPMain)
            If ApplicationUser.GetPermission("TransferDevIntoWorkableWIP") > 0 Then
                prodWIPMain.MenuCommands.Add(prodTransferDevicesToPreCell)
            End If

            If ApplicationUser.GetPermission("TransferDevIntoWorkableWIP") > 0 Then
                prodWIPMain.MenuCommands.Add(prodTransferDevicesToHold)
            End If
            mnuProduction.MenuCommands.Add(mnuDiv)

            'PRODUCTION - CoolPad
            mnuProduction.MenuCommands.Add(prodCoolPad_Main)
            If ApplicationUser.GetPermission("CoolPad_Receiving") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_Receiving)
            End If
            If ApplicationUser.GetPermission("CoolPad_PreTest") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_PreTest)
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_RFTest)
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_FlashTest)
            End If
            If ApplicationUser.GetPermission("CoolPad_TechBill") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_TechBill)
            End If
            'If ApplicationUser.GetPermission("CoolPad_Label") > 0 Then
            '    prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_Label)
            'End If
            If ApplicationUser.GetPermission("CoolPad_REF2Seed") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_REF2Seed)
            End If
            If ApplicationUser.GetPermission("CoolPad_Swap") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_Swap)
            End If
            If ApplicationUser.GetPermission("CoolPad_BuildBox") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_BuildBox)
            End If
            If ApplicationUser.GetPermission("CoolPad_ProduceBox") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_ProduceBox)
            End If
            If ApplicationUser.GetPermission("CoolPad_FulfillOrder") > 0 Then
                prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_FulfillEndUserOrder)
            End If

            prodCoolPad_Main.MenuCommands.Add(prodCoolPad_Main_Report)

            'PRODUCT => DRIVECAM
            'If ApplicationUser.GetPermission("DC") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodDriveCam_Main)
            '    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Admin)
            '    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Billing)

            '    If ApplicationUser.GetPermission("DC_Admin") > 0 Then
            '    End If
            '    If ApplicationUser.GetPermission("DC_BuildShipBox") > 0 Then
            '        prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_BSB)
            '    End If
            '    If ApplicationUser.GetPermission("DC_DockShipment") > 0 Then
            '        prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_DockShipment)
            '    End If
            '    If ApplicationUser.GetPermission("DC_Receiving") > 0 Then
            '        prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Rec)
            '    End If
            '    If ApplicationUser.GetPermission("DC_BuildShipBox") > 0 Then
            '        prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_ShipBox)
            '    End If
            'End If

            'PRODUCTION => GENERIC PROCESS
            If ApplicationUser.GetPermission("GenericProcess") > 0 Then
                mnuProduction.MenuCommands.Add(prodGenericProcMain)
                If ApplicationUser.GetPermission("GP_CreateWO") > 0 Then
                    prodGenericProcMain.MenuCommands.Add(prodGenericProcMain_CreateWO)
                End If
                If ApplicationUser.GetPermission("GP_BuildShipLot") > 0 Then
                    prodGenericProcMain.MenuCommands.Add(prodGenericProcMain_BuildShipLot)
                End If
                If ApplicationUser.GetPermission("GP_ProduceLot") > 0 Then
                    prodGenericProcMain.MenuCommands.Add(prodGenericProcMain_ProduceLot)
                End If
                If ApplicationUser.GetPermission("GP_Receiving") > 0 Then
                    prodGenericProcMain.MenuCommands.Add(prodGenericProcMain_Rec)
                End If
                prodGenericProcMain.MenuCommands.Add(prodGenericProcMain_Test)
                If ApplicationUser.GetPermission("GP_Pretest") > 0 Then
                    prodGenericProcMain_Test.MenuCommands.Add(prodGenericProcMain_Test_PreTest)
                End If
                If ApplicationUser.GetPermission("GP_QC") > 0 Then
                    prodGenericProcMain_Test.MenuCommands.Add(prodGenericProcMain_Test_QC)
                End If
            End If
            'PRODUCTION => MESSAGING
            mnuProduction.MenuCommands.Add(prodMessagingMain)
            prodMessagingMain.MenuCommands.Add(prodMessaging_AMS)
            If ApplicationUser.GetPermission("MessOpConsole") > 0 Then
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_OptConsole)
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_FreqCapcodeMgmt)       'may need a seperate permission?
            End If
            If ApplicationUser.GetPermission("MessEvalProcess") > 0 Then
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_EvalProcess)
            End If
            If ApplicationUser.GetPermission("MessAMSBilling") > 0 Then
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_Billing)
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_AQLOBA)
            End If
            If ApplicationUser.GetPermission("frmShipping") > 0 Then
                prodMessaging_AMS.MenuCommands.Add(prodMessagingMain_AMS_BB)
                prodMessaging_AMS.MenuCommands.Add(prodMessagingMain_AMS_Ship)
            End If
            If ApplicationUser.GetPermission("frmPalletBuild") > 0 Then
            End If
            If ApplicationUser.GetPermission("AMS_MapLvl3RepReason") > 0 Then prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_MapLvl3RepReason)
            If ApplicationUser.GetPermission("AMDBRManifest") > 0 Then prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_DBRManifest)
            'AMS InfraStructure
            If ApplicationUser.GetPermission("AMSInfraStructure") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_AMSInfraStructure)
                prodMessagingMain_AMSInfraStructure.MenuCommands.Add(prodMessagingMain_AMSInfraStructure_Rec)       'receiving 
                prodMessagingMain_AMSInfraStructure.MenuCommands.Add(prodMessagingMain_AMSInfraStructure_Billing)
                prodMessagingMain_AMSInfraStructure.MenuCommands.Add(prodMessagingMain_AMSInfraStructure_Ship)       'dock ship
            End If
            'Aquis
            If ApplicationUser.GetPermission("Aquis") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_Aquis)
                'prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_ProdRec)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_FreqCapcodeMgmt)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_Billing)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_AQLOBA)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_BB)       'Build ship box
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_Ship)       'Ship box
                prodMessagingMain_Aquis.MenuCommands.Add(mnuDiv)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_ModelSetup)
            End If

            'A-1 Wireless Comunications
            If ApplicationUser.GetPermission("MessA1WirelessComm") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_A1WC)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_CreateWO)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_Rec)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_Billing)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_AQLOBA)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_QC)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_BuildShipBox)       'Build ship box
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_ShipBox)       'ship box
                prodMessagingMain_A1WC.MenuCommands.Add(mnuDiv)
                prodMessagingMain_A1WC.MenuCommands.Add(prodMessagingMain_A1WC_BuildOtherShipPallet)
            End If

            'ATS
            If ApplicationUser.GetPermission("MessATS") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_ATS)
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_CreateWO)
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_Rec)
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_Billing)
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_QC)
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_BuildShipBox)       'Build ship box
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_ShipBox)       'ship box
                prodMessagingMain_ATS.MenuCommands.Add(mnuDiv)
                prodMessagingMain_ATS.MenuCommands.Add(prodMessagingMain_ATS_BuildOtherShipPallet)
            End If

            'Contact Wireless
            If ApplicationUser.GetPermission("MessContactWireless") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_CW)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_CreateWO)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_Rec)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_Billing)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_AQLOBA)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_QC)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_BuildShipBox)       'Build ship box
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_ShipBox)       'ship box
                prodMessagingMain_CW.MenuCommands.Add(mnuDiv)
                prodMessagingMain_CW.MenuCommands.Add(prodMessagingMain_CW_BuildOtherShipPallet)
            End If
            'Cook Pager
            If ApplicationUser.GetPermission("MessCookPager") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_CP)
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_FreqCapcodeMgmt)
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_Billing)
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_AQLOBA)
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_QC)
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_BuildShipBox)       'Build ship box
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_ShipBox)       'ship box
                prodMessagingMain_CP.MenuCommands.Add(mnuDiv)
                prodMessagingMain_CP.MenuCommands.Add(prodMessagingMain_CP_BuildOtherShipPallet)
            End If
            'Critical Alert
            If ApplicationUser.GetPermission("MessCriticalAlert") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_CA)
                prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_FreqCapcodeMgmt)
                prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_Billing)
                prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_AQLOBA)
                prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_QC)
                prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_BuildShipBox)       'Build ship box
                prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_ShipBox)       'ship box
                'prodMessagingMain_CA.MenuCommands.Add(mnuDiv)
                'prodMessagingMain_CA.MenuCommands.Add(prodMessagingMain_CA_BuildOtherShipPallet)
            End If
            'Morris Communication
            If ApplicationUser.GetPermission("MorrisCom") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_MorrisCom)
                'prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_LoadASN)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_FreqCapcodeMgmt)
                'prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_Rec)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_Billing)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_AQLOBA)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_BB)       'Build ship box
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_Ship)       'ship box
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_DBRManifest)       'Other Ship Manifest
            End If

            'Propage
            If ApplicationUser.GetPermission("Propage") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_Propage)
                'prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_LoadASN)
                'prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_Rec)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_FreqCapcodeMgmt)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_Billing)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_AQLOBA)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_BB)       'Build ship box
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_Ship)       'ship box
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_DBRManifest)       'Other Ship Manifest
            End If

            'Other messaging Customers
            If ApplicationUser.GetPermission("MessOtherCustomers") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessaging_OtherCust)
                prodMessaging_OtherCust.MenuCommands.Add(prodMessaging_OtherCust_Anna)
                prodMessaging_OtherCust.MenuCommands.Add(prodMessaging_OtherCust_Franciscan)
                prodMessaging_OtherCust.MenuCommands.Add(prodMessaging_OtherCust_Lahey)
                prodMessaging_OtherCust.MenuCommands.Add(prodMessaging_OtherCust_Maine)
                prodMessaging_OtherCust.MenuCommands.Add(prodMessaging_OtherCust_Masco)
                prodMessaging_OtherCust.MenuCommands.Add(prodMessaging_OtherCust_SMHC)

                prodMessaging_OtherCust_Anna.MenuCommands.Add(prodMessaging_OtherCust_Anna_Billing)
                prodMessaging_OtherCust_Anna.MenuCommands.Add(prodMessaging_OtherCust_Anna_QC)
                prodMessaging_OtherCust_Anna.MenuCommands.Add(prodMessaging_OtherCust_Anna_BuildShipBox)
                prodMessaging_OtherCust_Anna.MenuCommands.Add(prodMessaging_OtherCust_Anna_ShipBox)


                prodMessaging_OtherCust_Franciscan.MenuCommands.Add(prodMessaging_OtherCust_Franciscan_Billing)
                prodMessaging_OtherCust_Franciscan.MenuCommands.Add(prodMessaging_OtherCust_Franciscan_QC)
                prodMessaging_OtherCust_Franciscan.MenuCommands.Add(prodMessaging_OtherCust_Franciscan_BuildShipBox)
                prodMessaging_OtherCust_Franciscan.MenuCommands.Add(prodMessaging_OtherCust_Franciscan_ShipBox)


                prodMessaging_OtherCust_Lahey.MenuCommands.Add(prodMessaging_OtherCust_Lahey_Billing)
                prodMessaging_OtherCust_Lahey.MenuCommands.Add(prodMessaging_OtherCust_Lahey_QC)
                prodMessaging_OtherCust_Lahey.MenuCommands.Add(prodMessaging_OtherCust_Lahey_BuildShipBox)
                prodMessaging_OtherCust_Lahey.MenuCommands.Add(prodMessaging_OtherCust_Lahey_ShipBox)


                prodMessaging_OtherCust_Maine.MenuCommands.Add(prodMessaging_OtherCust_Maine_Billing)
                prodMessaging_OtherCust_Maine.MenuCommands.Add(prodMessaging_OtherCust_Maine_QC)
                prodMessaging_OtherCust_Maine.MenuCommands.Add(prodMessaging_OtherCust_Maine_BuildShipBox)
                prodMessaging_OtherCust_Maine.MenuCommands.Add(prodMessaging_OtherCust_Maine_ShipBox)


                prodMessaging_OtherCust_Masco.MenuCommands.Add(prodMessaging_OtherCust_Masco_Billing)
                prodMessaging_OtherCust_Masco.MenuCommands.Add(prodMessaging_OtherCust_Masco_QC)
                prodMessaging_OtherCust_Masco.MenuCommands.Add(prodMessaging_OtherCust_Masco_BuildShipBox)
                prodMessaging_OtherCust_Masco.MenuCommands.Add(prodMessaging_OtherCust_Masco_ShipBox)


                prodMessaging_OtherCust_SMHC.MenuCommands.Add(prodMessaging_OtherCust_SMHC_Billing)
                prodMessaging_OtherCust_SMHC.MenuCommands.Add(prodMessaging_OtherCust_SMHC_QC)
                prodMessaging_OtherCust_SMHC.MenuCommands.Add(prodMessaging_OtherCust_SMHC_BuildShipBox)
                prodMessaging_OtherCust_SMHC.MenuCommands.Add(prodMessaging_OtherCust_SMHC_ShipBox)
            End If

            prodMessagingMain.MenuCommands.Add(mnuDiv)
            prodMessagingMain.MenuCommands.Add(mnuDiv)
            prodMessagingMain.MenuCommands.Add(prodMessaging_AMS_DBRNERPallet)
            prodMessagingMain.MenuCommands.Add(mnuDiv)

            If ApplicationUser.GetPermission("MessModelActiveMgmt") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_ManageActiveModels)
            If ApplicationUser.GetPermission("AMS-CustomerFreqCodeMap") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_FreqCodeMap)
            If ApplicationUser.GetPermission("MessLabel") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_Label)

            If ApplicationUser.GetPermission("MsgOpenLinesQueue") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingOpenLinesQueue)

            prodMessagingMain.MenuCommands.Add(prodMessagingMain_FCVsLabel)
            If ApplicationUser.GetPermission("MessReport1") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_Reports)
            If ApplicationUser.GetPermission("AMS-UploadForecast") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_UploadForecast)
            If ApplicationUser.GetPermission("AMS-WipTransfer") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_WIPTransfer)
            If ApplicationUser.GetPermission("AMS-WipTransfer") > 0 Then prodMessagingMain.MenuCommands.Add(prodMessagingMain_WhToPreEval)

            'PRODUCT => Native Instruments
            'If ApplicationUser.GetPermission("NativeInstruments") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodNInst_Main)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_ShipReturnLabel)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_Rec)
            '    If ApplicationUser.GetPermission("NI-WipTransfer") > 0 Then prodNInst_Main.MenuCommands.Add(prodNInst_Main_WipTransfFrWHToPreTest)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_Triage)
            '    prodNInst_Main.MenuCommands.Add(prodNIstr_Main_PartReclaim)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_Repair)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_AQL)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_Ship)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_OBA)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_BuildPackageMaterials)
            '    If ApplicationUser.GetPermission("NI-DataMagment") > 0 Then
            '        prodNInst_Main.MenuCommands.Add(mnuDiv)
            '        prodNInst_Main.MenuCommands.Add(prodNInst_Main_DataMagment)
            '    End If
            '    prodNInst_Main.MenuCommands.Add(mnuDiv)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_ManageActiveModels)
            '    If ApplicationUser.GetPermission("NI-ProductModelMap") > 0 Then prodNInst_Main.MenuCommands.Add(prodNInst_Main_MapNIProductPSSIMode)
            '    If ApplicationUser.GetPermission("NI-ChangeOutBoundCosmGrade") > 0 Then prodNInst_Main.MenuCommands.Add(prodNInst_Main_ChangeCosmeticGrade)
            '    prodNInst_Main.MenuCommands.Add(mnuDiv)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_Reports)
            '    prodNInst_Main.MenuCommands.Add(mnuDiv)
            '    prodNInst_Main.MenuCommands.Add(prodNInst_Main_Warehouse)
            '    prodNInst_Main_Warehouse.MenuCommands.Add(prodNInst_Main_Warehous_AddWHCharge)
            '    If ApplicationUser.GetPermission("NI-FillOrder") > 0 Then
            '        prodNInst_Main_Warehouse.MenuCommands.Add(prodNInst_Main_Warehouse_FillOrders)
            '    End If
            '    If ApplicationUser.GetPermission("NI-WipTransfer") > 0 Then
            '        prodNInst_Main.MenuCommands.Add(mnuDiv)
            '        prodNInst_Main.MenuCommands.Add(prodNInst_Main_WipTransf)
            '    End If
            'End If
            'PRODUCT => NABCO
            If ApplicationUser.GetPermission("NABCO") > 0 Then
                mnuProduction.MenuCommands.Add(prodNABCO_Main)
                If ApplicationUser.GetPermission("NABCO_AddCharge") > 0 Then prodNABCO_Main.MenuCommands.Add(prodNABCO_Main_AddCharge)
            End If
            'PRODUCT => SONITROL
            mnuProduction.MenuCommands.Add(prodSonitroL_Main)
            'Sonitrol
            If ApplicationUser.GetPermission("SonitrolReceiving") > 0 Then
                prodSonitroL_Main.MenuCommands.Add(prodSonitroL_PBilling)
                prodSonitroL_Main.MenuCommands.Add(prodSonitrol_Rec)
                prodSonitroL_Main.MenuCommands.Add(prodSonitroL_SBilling)
            End If
            'PRODUCT => Text Now Inc
            mnuProduction.MenuCommands.Add(prodTextNow_Main)
            If ApplicationUser.GetPermission("TextNowInc") > 0 Then
                prodTextNow_Main.MenuCommands.Add(prodTextNow_Main_Warehouse_DashBoard)
                prodTextNow_Main.MenuCommands.Add(prodTextNow_Main_Warehouse_Rec)
                prodTextNow_Main.MenuCommands.Add(prodTextNow_Main_Warehouse_FillOrders)
                'prodTextNow_Main.MenuCommands.Add(mnuDiv)
                'prodTextNow_Main.MenuCommands.Add(prodTextNow_Main_Admin)
                'prodTextNow_Main_Admin.MenuCommands.Add(prodTextNow_Main_Admin_ASNImport)
                'prodTextNow_Main_Admin.MenuCommands.Add(prodTextNow_Main_Admin_MdlPrfx_Config)
                prodTextNow_Main.MenuCommands.Add(prodTextNow_Main_Reports)
                'prodTextNow_Main_Reports.MenuCommands.Add(prodTextNow_Main_Reports_Inv)
                'prodTextNow_Main_Reports.MenuCommands.Add(prodTextNow_Main_Reports_Ord)
            End If
            ' "PRODUCT => TRACFONE"
            If ApplicationUser.GetPermission("TracFone") > 0 Then
                mnuProduction.MenuCommands.Add(prodTF_Main)
                If ApplicationUser.GetPermission("TFAdminFunctions") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Admin)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_SetModelStatus)
                End If

                If ApplicationUser.GetPermission("ProductivityTracking") > 0 Then prodTF_Main.MenuCommands.Add(prodTF_Main_ProdTrack)
                prodTF_Main.MenuCommands.Add(Me.prodTF_Main_ExcelRpt)

                If ApplicationUser.GetPermission("TFAdminBilling") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Billing)
                End If

                If ApplicationUser.GetPermission("TFReceiving") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Rec)
                    prodTF_Main_Rec.MenuCommands.Add(prodTF_Main_Rec_Cell)
                    prodTF_Main_Rec.MenuCommands.Add(prodTF_Main_Rec_WH)
                End If

                If ApplicationUser.GetPermission("TFPreBuff") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_PreBuff)
                End If

                If ApplicationUser.GetPermission("TFBillingRepair") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_PreEval)
                End If

                If ApplicationUser.GetPermission("TFLabel") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Label)
                End If

                If ApplicationUser.GetPermission("TFBillingRepair") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Tech)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_PartReclaim)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_BER)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_PreBill)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_Refurbished)
                End If

                If ApplicationUser.GetPermission("TFTesting") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Test)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_AQL_OBA)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_BERCheck)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_Final)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_Pretest)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_PSD)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_RF1)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_RF2)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_SWScreening)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_SoftRef)

                    prodTF_Main_Test.MenuCommands.Add(mnuDiv)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_Triage)
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_BuildTriagedBox)
                End If

                If ApplicationUser.GetPermission("TFShipping") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Ship)
                    prodTF_Main_Ship.MenuCommands.Add(prodTF_Ship_BuildShipPallet)
                End If

                If ApplicationUser.GetPermission("TFWarehouse") > 0 Then prodTF_Main_Ship.MenuCommands.Add(prodTF_Ship_BuildShipPalletAcc)
                If ApplicationUser.GetPermission("TFShipping") > 0 Then prodTF_Main_Ship.MenuCommands.Add(prodTF_Ship_ShipPallet)

                prodTF_Main.MenuCommands.Add(mnuDiv)
                prodTF_Main.MenuCommands.Add(prodTF_Main_Warehouse)
                If ApplicationUser.GetPermission("TFWarehouse") > 0 Then
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_AssignBatteryCover)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_UnassignBatteryCover)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_AssignWHLoc)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_FillOpenOrder)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_Manifest)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_ManifestBER)
                End If
                prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_SearchWHRecInfo)

                ' PRODUCTION/TRACFONE/WIP TRANSFERS.
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Or _
                ApplicationUser.GetPermission("TFWipTransferWH") > 0 Or _
                ApplicationUser.GetPermission("TFWipTransferMat") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Wip)
                End If



                ' TODO: ADD SECURITY.
                ' PRODUCTION/TRACFONE/WIP TRANSFER/BOXES TO STAGING.
                'Dim _add_PROD_TF_MAIN_WIPTRANS_TO_STAGING As Boolean
                '_add_PROD_TF_MAIN_WIPTRANS_TO_STAGING = _
                ' ApplicationUser.GetPermission("TFWipTransferMat") > 0 Or _
                ' ApplicationUser.GetPermission("TFWipTransferWH") > 0 Or _
                ' ApplicationUser.GetPermission("TFWipTransferProd") > 0
                'If _add_PROD_TF_MAIN_WIPTRANS_TO_STAGING Then
                prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_TransferBoxes)
                'End If



                ' PRODUCTION/TRACFONE/WIP TRANSFER/TO/WH_RB.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_WHRB As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_WHRB = _
                 ApplicationUser.GetPermission("TFWipTransferMat") > 0 Or _
                 ApplicationUser.GetPermission("TFWipTransferWH") > 0 Or _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_WHRB Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToWHRB)
                End If

                ' PRODUCTION/TRACFONE/WIP TRANSFER/TO/STAGING.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_STAGING As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_STAGING = _
                 ApplicationUser.GetPermission("TFWipTransferMat") > 0 Or _
                 ApplicationUser.GetPermission("TFWipTransferWH") > 0 Or _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_STAGING Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToStaging)
                End If

                ' PRODUCTION/TRACFONE/WIP TRANSFER/TO/WH_WIP.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_WHWIP As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_WHWIP = _
                 ApplicationUser.GetPermission("TFWipTransferMat") > 0 Or _
                 ApplicationUser.GetPermission("TFWipTransferWH") > 0 Or _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_WHWIP Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToWHWIP)
                End If

                ' PRODUCTION/TRACFONE/WIP TRANSFERS/TO/AWAP.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_AWAP As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_AWAP = _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_AWAP Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToAWAP)
                End If

                ' PRODUCTION/TRACFONE/WIP TRANSFERS/TO/BER.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_BER As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_BER = _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_BER Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToBER)
                End If

                ' PRODUCTION/TRACFONE/WIP TRANSFERS/TO/BERCOMPLETE.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_BERCOMPLETE As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_BERCOMPLETE = _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_BERCOMPLETE Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToBERComplete)
                End If

                ' PRODUCTION/TRACFONE/WIP TRANSFERS/TO/BERSCREEN.
                Dim _add_PROD_TF_MAIN_WIPTRANS_TO_BERSCREEN As Boolean
                _add_PROD_TF_MAIN_WIPTRANS_TO_BERSCREEN = _
                 ApplicationUser.GetPermission("TFWipTransferProd") > 0
                If _add_PROD_TF_MAIN_WIPTRANS_TO_BERSCREEN Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToBERScreen)
                End If

                If ApplicationUser.GetPermission("TFWipTransferEng") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToEngineering)
                End If
                If ApplicationUser.GetPermission("TFWipTransferWH") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToObsolete)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToPreBill)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToPretest)
                End If
                If ApplicationUser.GetPermission("TFWipTransferWH") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToProdHold)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToQuarantine)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToRF1)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToTeardown)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_RemoveFrFailAWP)
                End If
                If ApplicationUser.GetPermission("TFWipTransferAdmin") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_Admin)
                End If

            End If

            'PRODUCTION - TracFone FulfillmentKit---------------------------------------------------
            If ApplicationUser.GetPermission("TracFone_FK_MainMenu") > 0 Then
                mnuProduction.MenuCommands.Add(prodTFFK_Main)

                'prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Admin)

                'If ApplicationUser.GetPermission("TracFone_FK_WhRec") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Rec)
                'End If

                'If ApplicationUser.GetPermission("TracFone_FK_WhTransfer") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Transfer)
                'End If

                'If ApplicationUser.GetPermission("TracFone_FK_Relabel") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Relabel)
                'End If

                'If ApplicationUser.GetPermission("TracFone_FK_Pick") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Pick)
                'End If

                'If ApplicationUser.GetPermission("TracFone_FK_Pack") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Pack)
                'End If

                'If ApplicationUser.GetPermission("TracFone_FK_Ship") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Ship)
                'End If

                'If ApplicationUser.GetPermission("TracFone_FK_Item_History") > 0 Then
                '    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Item_History)
                'End If

                'prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_Report)

                If ApplicationUser.GetPermission("TracFone_FK_QC") > 0 Then
                    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_QC)
                End If
                'prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_KittedRpt)

                'BYOP Kitting------------------------------------------------------------
                prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_BYOP_Kitting)
                If ApplicationUser.GetPermission("TracFone_FK_BYOP_Kitting_Setup") > 0 Then
                    prodTFFK_Main_BYOP_Kitting.MenuCommands.Add(prodTFFK_Main_BYOP_Kitting_Setup)
                End If
                If ApplicationUser.GetPermission("TracFone_FK_BYOP_Kitting_Pack") > 0 Then
                    prodTFFK_Main_BYOP_Kitting.MenuCommands.Add(prodTFFK_Main_BYOP_Kitting_Pack)
                End If
                If ApplicationUser.GetPermission("TracFone_FK_BYOP_Kitting_MCarton") > 0 Then
                    prodTFFK_Main_BYOP_Kitting.MenuCommands.Add(prodTFFK_Main_BYOP_Kitting_MCarton)
                End If
                If ApplicationUser.GetPermission("TracFone_FK_BYOP_Kitting_Pallet") > 0 Then
                    prodTFFK_Main_BYOP_Kitting.MenuCommands.Add(prodTFFK_Main_BYOP_Kitting_Pallet)
                End If
                If ApplicationUser.GetPermission("TracFone_FK_BYOP_SimplePack") > 0 Then
                    prodTFFK_Main_BYOP_Kitting.MenuCommands.Add(prodTFFK_Main_BYOP_SimplePacking)
                End If

                'RAC/GIN fulfillment ----------------------------------------------------------
                If ApplicationUser.GetPermission("TracFone_FK_RAC_GIN") > 0 Then
                    prodTFFK_Main.MenuCommands.Add(prodTFFK_Main_RAC_GIN)

                    If ApplicationUser.GetPermission("TracFone_FK_RAC_GIN_FillOrder") > 0 Then
                        prodTFFK_Main_RAC_GIN.MenuCommands.Add(prodTFFK_Main_RAC_GIN_FillOrder)
                    End If

                End If

            End If

            'PRODUCTION - Vivint ----------------------------------------------------------------------------
            'mnuProduction.MenuCommands.Add(prodVivint_Main)
            'If ApplicationUser.GetPermission("Vivint_WoReceipt") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_WoDockRecv)
            'End If
            'If ApplicationUser.GetPermission("Vivint_DeviceReceiving") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_DeviceRecv)
            'End If
            'If ApplicationUser.GetPermission("Vivint_PreTest") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_PreTest)
            'End If
            'If ApplicationUser.GetPermission("Vivint_TechBill") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_TechBill)
            'End If
            'If ApplicationUser.GetPermission("Vivint_Kitting") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_KittingLabelUnit)
            'End If
            'If ApplicationUser.GetPermission("Vivint_KittingSetup") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_KittingSetup)
            'End If
            'If ApplicationUser.GetPermission("Vivint_BuildBox") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_BuildBox)
            'End If
            'If ApplicationUser.GetPermission("Vivint_AQL_OBA_Test") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_AQL_OBA)
            'End If
            'If ApplicationUser.GetPermission("Vivint_ProduceBox") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_ProduceBox)
            'End If

            'prodVivint_Main.MenuCommands.Add(prodVivint_Main_Manifest)

            'If ApplicationUser.GetPermission("Vivint_PoRequest") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_PoRequest)
            'End If
            'If ApplicationUser.GetPermission("Vivint_FulfillOrder") > 0 Then
            '    prodVivint_Main.MenuCommands.Add(prodVivint_Main_FulfillOrder)
            'End If

            'prodVivint_Main.MenuCommands.Add(prodVivint_Main_OnHold)
            'prodVivint_Main.MenuCommands.Add(prodVivint_Main_Report)

            '----------------------------------------------------------------------------------------

            ' "PRODUCT => WFM (TRACFONE)"
            'If ApplicationUser.GetPermission("frmWfmBoxing") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodWFM_Main)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_Receiving)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_BldBx)
            '    prodWFM_Main_BldBx.MenuCommands.Add(prodWFM_Main_BldBx_BldIBBx)
            '    prodWFM_Main_BldBx.MenuCommands.Add(prodWFM_Main_BldBx_BldTrgdBx)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_ProduceNTFBox)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_WT)
            '    prodWFM_Main_WT.MenuCommands.Add(prodWFM_Main_WT_ToTrgStgngBulk)
            '    prodWFM_Main_WT.MenuCommands.Add(prodWFM_Main_WT_ToTrg)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_Tstng)
            '    prodWFM_Main_Tstng.MenuCommands.Add(prodWFM_Main_Tstng_Trg)
            '    prodWFM_Main_Tstng.MenuCommands.Add(prodWFM_Main_Tstng_AQL_OBA)
            '    'prodWFM_Main.MenuCommands.Add(prodWFM_Main_WH)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_Admin)
            '    prodWFM_Main_Admin.MenuCommands.Add(prodWFM_Main_Admin_ASN_Imp)
            '    prodWFM_Main_Admin.MenuCommands.Add(prodWFM_Main_Admin_MdlPrfx_Cnfg)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_Reports)
            'End If
            'If ApplicationUser.GetPermission("WFMShipping") > 0 Then
            '    prodWFM_Main.MenuCommands.Add(mnuDiv)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_Ship)
            '    'prodWFM_Main_Ship.MenuCommands.Add(prodWFM_Ship_BuildShipPallet)
            'End If
            'If ApplicationUser.GetPermission("frmWfmBoxing") > 0 OrElse ApplicationUser.GetPermission("WFMWarehouse") Then
            '    prodWFM_Main.MenuCommands.Add(mnuDiv)
            '    prodWFM_Main.MenuCommands.Add(prodWFM_Main_WH)
            '    prodWFM_Main_WH.MenuCommands.Add(prodWFM_Main_WH_AsgnWhLoc)
            '    prodWFM_Main_WH.MenuCommands.Add(prodWFM_Main_WH_SNSearch)
            'End If
            'If ApplicationUser.GetPermission("WFMWarehouse") > 0 Then
            '    prodWFM_Main_WH.MenuCommands.Add(prodWFM_Main_Warehouse_FillOpenOrder)
            '    prodWFM_Main_WH.MenuCommands.Add(prodWFM_Main_Warehouse_Manifest)
            '    prodWFM_Main_Ship.MenuCommands.Add(prodWFM_Ship_BuildShipPalletAcc)
            '    prodWFM_Main_Ship.MenuCommands.Add(prodWFM_Ship_SplitOutboundBox)
            'End If

            'PRODUCTION - WIKO
            mnuProduction.MenuCommands.Add(prodWIKO_Main)
            prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_GenericConfig)

            If ApplicationUser.GetPermission("WIKO_Receiving") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_Receiving)
            End If
            If ApplicationUser.GetPermission("WIKO_PreTest") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_PreTest)
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_RFTest)
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_FlashTest)
            End If
            If ApplicationUser.GetPermission("WIKO_TechBill") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_TechBill)
            End If
            If ApplicationUser.GetPermission("WIKO_Label") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_Label)
            End If
            If ApplicationUser.GetPermission("WIKO_REF2Seed") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_REF2Seed)
            End If
            If ApplicationUser.GetPermission("WIKO_Swap") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_Swap)
            End If
            If ApplicationUser.GetPermission("WIKO_BuildBox") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_BuildBox)
            End If
            If ApplicationUser.GetPermission("WIKO_ProduceBox") > 0 Then
                prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_ProduceBox)
            End If
            prodWIKO_Main.MenuCommands.Add(mnuDiv)
            prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_SpecialRecv)
            prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_SpecialKitting)
            prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_SpecialBuildBox)
            prodWIKO_Main.MenuCommands.Add(mnuDiv)

            prodWIKO_Main.MenuCommands.Add(prodWIKO_Main_Report)

            'PRODUCTION - WingTech
            mnuProduction.MenuCommands.Add(prodWingTech_Main)
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_GenericConfig)

            'If ApplicationUser.GetPermission("WingTech_Receiving") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_Receiving)
            'End If
            'If ApplicationUser.GetPermission("WingTech_PreTest") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_PreTest)
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_RFTest)
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_FlashTest)
            'End If
            'If ApplicationUser.GetPermission("WingTech_TechBill") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_TechBill)
            'End If
            ''If ApplicationUser.GetPermission("WingTech_Label") > 0 Then
            '    prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_Label)
            ''End If
            'If ApplicationUser.GetPermission("WingTech_REF2Seed") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_REF2Seed)
            'End If
            'If ApplicationUser.GetPermission("WingTech_Swap") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_Swap)
            'End If
            'If ApplicationUser.GetPermission("WingTech_BuildBox") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_BuildBox)
            'End If
            'If ApplicationUser.GetPermission("WingTech_ProduceBox") > 0 Then
            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_ProduceBox)
            'End If
            'If ApplicationUser.GetPermission("WingTech_FulfillOrder") > 0 Then
            ' prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_FulfillEndUserOrder)
            'End If

            prodWingTech_Main.MenuCommands.Add(prodWingTech_Main_Report)

            'PRODUCTION - WingTechATT
            mnuProduction.MenuCommands.Add(prodWingTechATT_Main)
            'prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_Receiving)
            'prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_PreTest)
            'prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_RFTest)
            'prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_TechBill)
            'prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_BuildBox)

            'If ApplicationUser.GetPermission("WingTechATT_Receiving") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_Receiving)
            'End If
            'If ApplicationUser.GetPermission("WingTechATT_PreTest") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_PreTest)
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_RFTest)
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_FlashTest)
            'End If
            ''If ApplicationUser.GetPermission("WingTechATT_TechBill") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_TechBill)
            ''End If
            'If ApplicationUser.GetPermission("WingTechATT_Label") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_Label)
            'End If
            'If ApplicationUser.GetPermission("WingTechATT_REF2Seed") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_REF2Seed)
            'End If
            'If ApplicationUser.GetPermission("WingTechATT_Swap") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_Swap)
            'End If
            'If ApplicationUser.GetPermission("WingTechATT_BuildBox") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_BuildBox)
            'End If
            'If ApplicationUser.GetPermission("WingTechATT_ProduceBox") > 0 Then
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_ProduceBox)
            prodWingTechATT_Main.MenuCommands.Add(mnuDiv)
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_SpecialBuildBox)
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_SpecialKitting)
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_SpecialRecv)
            prodWingTechATT_Main.MenuCommands.Add(mnuDiv)
            'End If
            prodWingTechATT_Main.MenuCommands.Add(prodWingTechATT_Main_Report)

            'PRODUCTION - Vinsmart
            mnuProduction.MenuCommands.Add(prodVinsmart_Main)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_Receiving)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_PreTest)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_RFTest)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_FlashTest)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_TechBill)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_Label)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_REF2Seed)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_Swap)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_BuildBox)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_ProduceBox)
            prodVinsmart_Main.MenuCommands.Add(mnuDiv)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_SpecialBuildBox)
            'prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_SpecialKitting)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_SpecialRecv)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_AQL_OBA)
            prodVinsmart_Main.MenuCommands.Add(mnuDiv)
            prodVinsmart_Main.MenuCommands.Add(prodVinsmart_Main_Report)


            'PRODUCTION - Ziosk
            If ApplicationUser.GetPermission("ZioskMenu") > 0 Then
                mnuProduction.MenuCommands.Add(prodZiosk_Main)
                'If ApplicationUser.GetPermission("TFAdminFunctions") > 0 Then
                prodZiosk_Main.MenuCommands.Add(mnuDiv)
                prodZiosk_Main.MenuCommands.Add(prodZiosk_Main_Label)
                ' End If
            End If

            mnuProduction.MenuCommands.Add(mnuDiv)


            '*******************************************
            'PRODUCTION => QUALITY CONTROL
            '*******************************************
            mnuProduction.MenuCommands.Add(prodQCMain)
            If ApplicationUser.GetPermission("frmQC") > 0 Then
                prodQCMain.MenuCommands.Add(prodQC)
            End If
            If ApplicationUser.GetPermission("frmQC_Codes") > 0 Then
                prodQCMain.MenuCommands.Add(prodQC_Codes)
            End If

            '*******************************************
            'PRODUCTION => REFURB
            '*******************************************
            mnuProduction.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("PreBillLot") > 0 Then mnuProduction.MenuCommands.Add(prodPreBillLot)

            mnuProduction.MenuCommands.Add(prodRefurb)
            If ApplicationUser.GetPermission("RefurbTracker") > 0 Then
                prodRefurb.MenuCommands.Add(prodRefurb_Auditor)
                prodRefurb.MenuCommands.Add(prodRefurb_ProductivityTracker)
            End If
            If ApplicationUser.GetPermission("frmNewTech") > 0 Then mnuProduction.MenuCommands.Add(prodTechHS)
            mnuProduction.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("AutoShipRWPallet") > 0 Then
                mnuProduction.MenuCommands.Add(prodAutoShipRWPallet)
            End If
            If ApplicationUser.GetPermission("BuildGenericShipPallet") > 0 Then
                mnuProduction.MenuCommands.Add(prodGenericShipPallet)
            End If
            If ApplicationUser.GetPermission("Bulk Shipping") > 0 Then
                mnuProduction.MenuCommands.Add(prodBulkShipping)
            End If

            '*******************************************
            'PRODUCTION => AUDIT
            '*******************************************
            mnuProduction.MenuCommands.Add(mnuDiv)
            mnuProduction.MenuCommands.Add(prodAudit)
            If ApplicationUser.GetPermission("frmDeviceBillingHistory") > 0 Then
                prodAudit.MenuCommands.Add(prodAudit_DevBillHist)
            End If
            If ApplicationUser.GetPermission("rfTechTools") > 0 Then
                mnuProduction.MenuCommands.Add(prodCreatePSSISNs)
            End If
            'PRODUCTION => WAREHOUSE
            mnuProduction.MenuCommands.AddRange(New MenuCommand() {mnuDiv, prodWarehouse})
            If ApplicationUser.GetPermission("SendPalletPackingListFiles") > 0 Then
                prodWarehouse.MenuCommands.Add(prodWarehouse_SendPalletPackingListFiles)
                prodWarehouse.MenuCommands.Add(prodWarehouse_DockShipment)
            End If
            If ApplicationUser.GetPermission("SendPalletPackingListFiles") > 0 Then
                prodWarehouse.MenuCommands.Add(prodWarehouse_PrintUPCLabel)
            End If
            '// add our report menus
            If ApplicationUser.GetPermission("rfAdminRev") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminRev)
            End If
            If ApplicationUser.GetPermission("rfAdminAUPCustMod") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminAUPCustMod)
            End If
            If ApplicationUser.GetPermission("rfAdminAUPForProduced") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminAUPForProduced)
            End If
            If ApplicationUser.GetPermission("rfAdminRevForProduced") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminRevForProduced)
            End If
            If ApplicationUser.GetPermission("563RevenueRpt") > 0 Then
                mnuReports.MenuCommands.Add(rptAdmin563RevRpt)
            End If
            If ApplicationUser.GetPermission("rfAdminOpsSumm") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminOpsSumm)
            End If
            If ApplicationUser.GetPermission("rfAdminCycMonth") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminCycMonth)
            End If
            If ApplicationUser.GetPermission("rfAdminCycWeek") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminCycWeek)
            End If
            If ApplicationUser.GetPermission("rfACLessWrty") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminCntLessWrty)
            End If
            If ApplicationUser.GetPermission("rfAdminWIP") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminWIP)
            End If
            If ApplicationUser.GetPermission("rfAdminSent2Ftry") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminSent2Ftry)
            End If
            If ApplicationUser.GetPermission("rfAdminWIPDetail") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminWIPDetail)
            End If
            If ApplicationUser.GetPermission("WIP_Detail_by_Group") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminWIPDetailByLocation)
            End If

            'If ApplicationUser.GetPermission("rptWIPStatusReport") > 0 Then
            mnuReports.MenuCommands.Add(rptWIPStatusReport)
            'End If


            If ApplicationUser.GetPermission("MessagingWIPByCustomerAndModel") > 0 Then
                mnuReports.MenuCommands.Add(rptMessagingWIPByCustomerAndModel)
            End If
            If ApplicationUser.GetPermission("rfAdminAUP") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminAUP)
            End If
            If ApplicationUser.GetPermission("rfAdminCustLocAdd") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminCustLocAdd)
            End If
            If ApplicationUser.GetPermission("rfAdminRURcnt") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminRURcnt)
            End If
            If ApplicationUser.GetPermission("rfAdminDupSerial") > 0 Then
                mnuReports.MenuCommands.Add(rptDupSerial)
            End If
            If ApplicationUser.GetPermission("rfAdminWeeklyDevices") > 0 Then
                mnuReports.MenuCommands.Add(rptWeeklyDevices)
            End If
            If ApplicationUser.GetPermission("rfAdminBilledNotShipped") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminBilledNotShipped)
            End If
            If ApplicationUser.GetPermission("rfAdminCustPartsCount") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminCustPartsCount)
            End If
            If ApplicationUser.GetPermission("MotoBatchClaimRecon") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminMotoBatchRecon)
            End If
            If ApplicationUser.GetPermission("rfAdminDBRDuplicate") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminDBRDuplicate)
            End If
            If ApplicationUser.GetPermission("rfAdminMotoWrtyCount") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminMotoWrtyCount)
            End If
            If ApplicationUser.GetPermission("rfAdminSpecialBT") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminSpecialBT)
            End If
            If ApplicationUser.GetPermission("rfAdminOpsSumWkly") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminOpsSumWkly)
            End If
            If ApplicationUser.GetPermission("rfAdminDeviceCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminDeviceCnt)
            End If
            If ApplicationUser.GetPermission("rfAdminWIP") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminMessagingProductWIP)
            End If
            mnuReports.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("rfBillEmpCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptBillEmpCnt)
            End If
            mnuReports.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("rfFinInvCCrd") > 0 Then
                mnuReports.MenuCommands.Add(rptFinInvCCrd)
            End If
            If ApplicationUser.GetPermission("rfFinCCrdRecon") > 0 Then
                mnuReports.MenuCommands.Add(rptFinCCrdRecon)
            End If
            If ApplicationUser.GetPermission("rfFinInvDtl") > 0 Then
                mnuReports.MenuCommands.Add(rptFinInvDetail)
            End If
            If ApplicationUser.GetPermission("rfFinInvManifCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptFinInvManifCnt)
            End If
            If ApplicationUser.GetPermission("rfFinTwoWayRevenue") > 0 Then
                mnuReports.MenuCommands.Add(rptFinTwoWayRevenue)
            End If
            If ApplicationUser.GetPermission("rfFinEmplWCCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptFinEmplWCCnt)
            End If
            If ApplicationUser.GetPermission("rfFinWCHrsCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptFinWCHrsCnt)
            End If
            If ApplicationUser.GetPermission("rfFinDeviceCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptFinDeviceCnt)
            End If
            If ApplicationUser.GetPermission("rfFinPalletInvoice") > 0 Then
                mnuReports.MenuCommands.Add(rptFinPallettInvoice)
            End If
            If ApplicationUser.GetPermission("rfFinWHStatusDetail") > 0 Then
                mnuReports.MenuCommands.Add(rptFinWHStatusDetail)
            End If
            If ApplicationUser.GetPermission("rfFinWHStatusSummary") > 0 Then
                mnuReports.MenuCommands.Add(rptFinWHStatusSummary)
            End If
            If ApplicationUser.GetPermission("rfFinBatchRejects") > 0 Then
                mnuReports.MenuCommands.Add(rptFinBatchRejects)
            End If
            If ApplicationUser.GetPermission("rfFinReconStatus") > 0 Then
                mnuReports.MenuCommands.Add(rptFinReconStatus)
            End If
            mnuReports.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("rfPartsB2Idetail") > 0 Then
                mnuReports.MenuCommands.Add(rptPartsB2IDetail)
            End If
            If ApplicationUser.GetPermission("rfPartsB2Isumm") > 0 Then
                mnuReports.MenuCommands.Add(rptPartsB2ISumm)
            End If
            If ApplicationUser.GetPermission("rfPartsAnalysis") > 0 Then
                mnuReports.MenuCommands.Add(rptPartsAnalysis)
            End If
            If ApplicationUser.GetPermission("rfPartsCount") > 0 Then
                mnuReports.MenuCommands.Add(rptPartsCount)
            End If
            If ApplicationUser.GetPermission("Scrap Quantity") > 0 Then
                mnuReports.MenuCommands.Add(rptScrapsCount)
            End If
            If ApplicationUser.GetPermission("Shop Floor Quantity report") > 0 Then
                mnuReports.MenuCommands.Add(rptShopFloorQtyReport)
            End If
            If ApplicationUser.GetPermission("rfPartsMappedAnal") > 0 Then
                mnuReports.MenuCommands.Add(rptPartsMappedAnalysis)
            End If
            If ApplicationUser.GetPermission("rfBilledIssuedCell") > 0 Then
                mnuReports.MenuCommands.Add(rptBilledIssuedCell)
            End If
            If ApplicationUser.GetPermission("rfNonMappedCellParts") > 0 Then
                mnuReports.MenuCommands.Add(rptNonMappedCellParts)
            End If
            If ApplicationUser.GetPermission("rfInvModelMap") > 0 Then
                mnuReports.MenuCommands.Add(rptInvModelMap)
            End If
            If ApplicationUser.GetPermission("rptPartsAndBillCodesByModel") > 0 Then
                mnuReports.MenuCommands.Add(rptPartsAndBillCodesByModel)
            End If
            mnuReports.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("ProductionRcvdDevCntByCust") > 0 Then
                mnuReports.MenuCommands.Add(rptProdRcvdDevCntByCust)
            End If
            If ApplicationUser.GetPermission("rfRecCntDly") > 0 Then
                mnuReports.MenuCommands.Add(rptRecCntDly)
            End If
            If ApplicationUser.GetPermission("rfRecCntDly2Lvl") > 0 Then
                mnuReports.MenuCommands.Add(rptRecCntDly2Lvl)
            End If
            If ApplicationUser.GetPermission("rfRecCntMnthly2Lvl") > 0 Then
                mnuReports.MenuCommands.Add(rptRecCntMnthly2Lvl)
            End If
            If ApplicationUser.GetPermission("rfRecCntDlyMWrty") > 0 Then
                mnuReports.MenuCommands.Add(rptRecCntDlyMWrty)
            End If
            If ApplicationUser.GetPermission("rfRecEmpCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptRecEmpCnt)
            End If
            If ApplicationUser.GetPermission("rfRecCntMonth") > 0 Then
                mnuReports.MenuCommands.Add(rptRecCntMonth)
            End If
            If ApplicationUser.GetPermission("rfRecDetail") > 0 Then
                mnuReports.MenuCommands.Add(rptRecDetail)
            End If
            If ApplicationUser.GetPermission("rfRecVerExc") > 0 Then
                mnuReports.MenuCommands.Add(rptVerExc)
            End If
            If ApplicationUser.GetPermission("rfAdminDBRDuplicate") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminDBRDuplicate)
            End If
            If ApplicationUser.GetPermission("rfAdminMotoWrtyCount") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminMotoWrtyCount)
            End If
            If ApplicationUser.GetPermission("rfRecCntDailyStaged") > 0 Then
                mnuReports.MenuCommands.Add(rptRecCntDailyStaged)
            End If
            mnuReports.MenuCommands.Add(mnuDiv)
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                mnuReports.MenuCommands.Add(rptCellLineProd)
            End If
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                mnuReports.MenuCommands.Add(rptCellProdSummary)
            End If
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                mnuReports.MenuCommands.Add(rptShipDevQtyByShipType)
            End If
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                mnuReports.MenuCommands.Add(rptWHPalletsNotRcvd)
            End If
            If ApplicationUser.GetPermission("CellShippedPallets") > 0 Then
                mnuReports.MenuCommands.Add(rptCellShippedPallets)
            End If
            If ApplicationUser.GetPermission("AllSNsShippedOnDateForCust") > 0 Then
                mnuReports.MenuCommands.Add(rptAllSNsShippedOnDateForCust)
            End If
            If ApplicationUser.GetPermission("rfShipCCntDly") > 0 Then
                mnuReports.MenuCommands.Add(rptShipCntDly)
            End If
            If ApplicationUser.GetPermission("rfShipCCntDly2Lvl") > 0 Then
                mnuReports.MenuCommands.Add(rptShipCntDly2Lvl)
            End If
            If ApplicationUser.GetPermission("rfShipEmpCnt") > 0 Then
                mnuReports.MenuCommands.Add(rptShipEmpCnt)
            End If
            If ApplicationUser.GetPermission("rfShipRLRMASum") > 0 Then
                mnuReports.MenuCommands.Add(rptShipRLRMASum)
            End If
            If ApplicationUser.GetPermission("rfATCLEPassFail") > 0 Then
                mnuReports.MenuCommands.Add(rptATCLEPassFail)
            End If
            If ApplicationUser.GetPermission("rfAmericanMessagingShipDemand") > 0 Then
                mnuReports.MenuCommands.Add(rptAmericanMessagingShipDemand)
            End If
            If ApplicationUser.GetPermission("rptMotoWrty") > 0 Then
                mnuReports.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptMotoWrty})
            End If
            If ApplicationUser.GetPermission("rptTechRefurbQtyRpt") > 0 Then
                mnuReports.MenuCommands.Add(rptTechRefurbQtyRpt)
            End If
            If ApplicationUser.GetPermission("MessLabelProductionRpt") > 0 Then
                mnuReports.MenuCommands.Add(rptMessLblProdRpt)
            End If
            If ApplicationUser.GetPermission("rptSNsByRcvedPalletRpt") > 0 Then
                mnuReports.MenuCommands.Add(rptSNsByRcvedPalletRpt)
            End If

            '// DOCUMENT MENU
            If ApplicationUser.GetPermission("DocumentLocationMap") > 0 Then
                mnuDocuments.MenuCommands.Add(mnuDocuments_DocLocMap)
            End If
            mnuDocuments.MenuCommands.Add(mnuDocuments_WorkInstruction)
            '// ENGINEERING MENU
            If ApplicationUser.GetPermission("ManageWrtyCodes") > 0 Then
                mnuEngineering.MenuCommands.Add(engManageManufCodes)
            End If
            '// add our help menus
            mnuHelp.MenuCommands.AddRange(New MenuCommand() {helpHelp, mnuDiv, helpAbout})

            '//Report split out ***********************************************************************
            '// add our Admin report menus
            If ApplicationUser.GetPermission("rfAdminRev") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminRev)
            End If
            If ApplicationUser.GetPermission("rfAdminRevDetail") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminRevDetail)
            End If
            If ApplicationUser.GetPermission("rfAdminAUPCustMod") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminAUPCustMod)
            End If
            If ApplicationUser.GetPermission("rfAdminAUPForProduced") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminAUPForProduced)
            End If
            If ApplicationUser.GetPermission("rfAdminRevForProduced") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminRevForProduced)
            End If
            If ApplicationUser.GetPermission("563RevenueRpt") > 0 Then
                smAdmin.MenuCommands.Add(rptAdmin563RevRpt)
            End If

            If ApplicationUser.GetPermission("rfAdminOpsSumm") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminOpsSumm)
            End If
            If ApplicationUser.GetPermission("rfAdminCycMonth") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminCycMonth)
            End If
            If ApplicationUser.GetPermission("rfAdminCycWeek") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminCycWeek)
            End If
            If ApplicationUser.GetPermission("rfACLessWrty") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminCntLessWrty)
            End If
            If ApplicationUser.GetPermission("rfAdminSent2Ftry") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminSent2Ftry)
            End If

            If ApplicationUser.GetPermission("rfAdminWIP") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminWIP)
            End If
            If ApplicationUser.GetPermission("rfAdminWIPDetail") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminWIPDetail)
            End If
            If ApplicationUser.GetPermission("WIP_Detail_by_Group") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminWIPDetailByLocation)
            End If
            If ApplicationUser.GetPermission("MessagingWIPByCustomerAndModel") > 0 Then
                smAdmin.MenuCommands.Add(rptMessagingWIPByCustomerAndModel)
            End If
            smAdmin.MenuCommands.Add(rptWIPStatusReport)
            If ApplicationUser.GetPermission("rfAdminAUP") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminAUP)
            End If
            If ApplicationUser.GetPermission("rfAdminCustLocAdd") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminCustLocAdd)
            End If
            If ApplicationUser.GetPermission("rfAdminRURcnt") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminRURcnt)
            End If
            If ApplicationUser.GetPermission("rfAdminDupSerial") > 0 Then
                smAdmin.MenuCommands.Add(rptDupSerial)
            End If
            If ApplicationUser.GetPermission("rfAdminWeeklyDevices") > 0 Then
                smAdmin.MenuCommands.Add(rptWeeklyDevices)
            End If
            If ApplicationUser.GetPermission("rfAdminBilledNotShipped") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminBilledNotShipped)
            End If
            If ApplicationUser.GetPermission("rfAdminCustPartsCount") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminCustPartsCount)
            End If
            If ApplicationUser.GetPermission("MotoBatchClaimRecon") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminMotoBatchRecon)
            End If
            'added by Amazech-Thanga 11.10.2021
            'If ApplicationUser.GetPermission("rptAdminRAUpload") > 0 Then
            smAdmin.MenuCommands.Add(rptAdminRAUpload)
            'End If

            If ApplicationUser.GetPermission("rptMotoWrty") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptMotoWrty})
            End If
            If ApplicationUser.GetPermission("rfAdminDBRDuplicate") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptAdminDBRDuplicate})
            End If
            If ApplicationUser.GetPermission("rfAdminMotoWrtyCount") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptAdminMotoWrtyCount})
            End If
            If ApplicationUser.GetPermission("rfAdminSpecialBT") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptAdminSpecialBT})
            End If
            If ApplicationUser.GetPermission("rfAdminOpsSumWkly") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptAdminOpsSumWkly})
            End If

            If ApplicationUser.GetPermission("rfAdminDeviceCnt") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptAdminDeviceCnt})
            End If

            If ApplicationUser.GetPermission("rfAdminWIP") > 0 Then
                smAdmin.MenuCommands.AddRange(New MenuCommand() {mnuDiv, rptAdminMessagingProductWIP})
            End If

            'REPORT-> EXCEL OUTPUT 
            If ApplicationUser.GetPermission("ExcelGeneralReports") > 0 Then
                smCellSpec.MenuCommands.Add(rptEO_EGR)
            End If
            If ApplicationUser.GetPermission("frmDashBoardReports") > 0 Then smCellSpec.MenuCommands.Add(rptAdminCostCenterRpt)


            If ApplicationUser.GetPermission("frmPretestReports") > 0 Then
                smCellSpec.MenuCommands.Add(rptAdminPretestRpt)
                smCellSpec.MenuCommands.Add(rptAdminPretQCH_Rpt)
            End If
            If ApplicationUser.GetPermission("frmQCReports") > 0 Then
                smCellSpec.MenuCommands.Add(rptAdminQCRpt)
                smCellSpec.MenuCommands.Add(rptAdminQR_Rpt)
            End If
            If ApplicationUser.GetPermission("frmQCReports") > 0 Then smCellSpec.MenuCommands.Add(rptAdminRepRefRURRpt)
            If ApplicationUser.GetPermission("RepairHistoryReports") > 0 Then smCellSpec.MenuCommands.Add(rptAdminRH_Rpt)
            If ApplicationUser.GetPermission("frmQCReports") > 0 Then smCellSpec.MenuCommands.Add(rptAdminRF_Rpt)
            If ApplicationUser.GetPermission("RURRTMCheck") > 0 Then smCellSpec.MenuCommands.Add(rptRURRTMCheck)
            If ApplicationUser.GetPermission("SoftwareRefTestResultRpt") > 0 Then smCellSpec.MenuCommands.Add(rptAdminSWRefTestResult_Rpt)

            If ApplicationUser.GetPermission("rfAdminWCDetail") > 0 Then smCellSpec.MenuCommands.Add(rptAdminWCDetail)

            '// add our Billing report menu
            If ApplicationUser.GetPermission("rfBillEmpCnt") > 0 Then
                smBilling.MenuCommands.Add(rptBillEmpCnt)
            End If

            '********************************
            'REPORT => FINANCE
            '********************************
            '// add our Finance report menu
            If ApplicationUser.GetPermission("rfFinInvCCrd") > 0 Then
                smFinance.MenuCommands.Add(rptFinInvCCrd)
            End If
            If ApplicationUser.GetPermission("rfFinCCrdRecon") > 0 Then
                smFinance.MenuCommands.Add(rptFinCCrdRecon)
            End If
            If ApplicationUser.GetPermission("rfFinInvDtl") > 0 Then
                smFinance.MenuCommands.Add(rptFinInvDetail)
            End If

            If ApplicationUser.GetPermission("rfFinInvManifCnt") > 0 Then
                smFinance.MenuCommands.Add(rptFinInvManifCnt)
            End If
            If ApplicationUser.GetPermission("rfFinTwoWayRevenue") > 0 Then
                smFinance.MenuCommands.Add(rptFinTwoWayRevenue)
            End If
            If ApplicationUser.GetPermission("rfFinEmplWCCnt") > 0 Then
                smFinance.MenuCommands.Add(rptFinEmplWCCnt)
            End If
            If ApplicationUser.GetPermission("rfFinWCHrsCnt") > 0 Then
                smFinance.MenuCommands.Add(rptFinWCHrsCnt)
            End If
            If ApplicationUser.GetPermission("rfFinDeviceCnt") > 0 Then
                smFinance.MenuCommands.Add(rptFinDeviceCnt)
            End If
            If ApplicationUser.GetPermission("rfFinPallettInvoice") > 0 Then
                smFinance.MenuCommands.Add(rptFinPallettInvoice)
            End If
            If ApplicationUser.GetPermission("rfFinWHStatusDetail") > 0 Then
                smFinance.MenuCommands.Add(rptFinWHStatusDetail)
            End If
            If ApplicationUser.GetPermission("rfFinWHStatusSummary") > 0 Then
                smFinance.MenuCommands.Add(rptFinWHStatusSummary)
            End If
            If ApplicationUser.GetPermission("rfFinBatchRecon") > 0 Then
                smFinance.MenuCommands.Add(rptFinBatchRecon)
            End If

            If ApplicationUser.GetPermission("rfFinBatchRejects") > 0 Then
                smFinance.MenuCommands.Add(rptFinBatchRejects)
            End If

            If ApplicationUser.GetPermission("rfFinReconStatus") > 0 Then
                smFinance.MenuCommands.Add(rptFinReconStatus)
            End If

            '***************************
            'Finance = > Navision Reports
            '***************************
            If ApplicationUser.GetPermission("FinanceReports") > 0 Then
                smFinance.MenuCommands.Add(smFinance_NavReports)
            End If


            '***************************
            'Human Resource MENU
            '***************************
            If ApplicationUser.GetPermission("IncentiveData") > 0 Then mnuHR.MenuCommands.Add(hrIncentiveData)
            If ApplicationUser.GetPermission("LegiantEEData") > 0 Then mnuHR.MenuCommands.Add(hrLegiantEEData)

            '***************************
            'Report => Inventory
            '***************************
            If ApplicationUser.GetPermission("Available_for_Production") > 0 Then
                smInventory.MenuCommands.Add(invAvailableForProdSumRpt)
            End If
            If ApplicationUser.GetPermission("rfInvAwaitingParts") > 0 Then
                smInventory.MenuCommands.Add(invAwaitingParts)
            End If
            If ApplicationUser.GetPermission("CycleCountVarianceReport") > 0 Then
                smInventory.MenuCommands.Add(invBenchCycleCountVarReport)
            End If
            If ApplicationUser.GetPermission("rfBilledIssuedCell") > 0 Then
                smInventory.MenuCommands.Add(rptBilledIssuedCell)
            End If
            If ApplicationUser.GetPermission("rfInvBICellDetail") > 0 Then
                smInventory.MenuCommands.Add(invBillIssueCellDetail)
            End If
            If ApplicationUser.GetPermission("CogsReports") > 0 Then
                smInventory.MenuCommands.Add(invCogsRpts)
            End If
            If ApplicationUser.GetPermission("rfInvModelMap") > 0 Then
                smInventory.MenuCommands.Add(rptInvModelMap)
            End If
            If ApplicationUser.GetPermission("rfPartsAnalysis") > 0 Then
                smInventory.MenuCommands.Add(rptPartsAnalysis)
            End If
            If ApplicationUser.GetPermission("rptPartsAndBillCodesByModel") > 0 Then
                smInventory.MenuCommands.Add(rptPartsAndBillCodesByModel)
            End If
            If ApplicationUser.GetPermission("rfPartsB2Idetail") > 0 Then
                smInventory.MenuCommands.Add(rptPartsB2IDetail)
            End If
            If ApplicationUser.GetPermission("rfPartsB2Isumm") > 0 Then
                smInventory.MenuCommands.Add(rptPartsB2ISumm)
            End If
            If ApplicationUser.GetPermission("rptInvPartsConsumption") > 0 Then
                smInventory.MenuCommands.Add(rptInvPartsConsumption)
            End If
            If ApplicationUser.GetPermission("rfPartsCount") > 0 Then
                smInventory.MenuCommands.Add(rptPartsCount)
            End If
            If ApplicationUser.GetPermission("rfPartsMappedAnal") > 0 Then
                smInventory.MenuCommands.Add(rptPartsMappedAnalysis)
            End If
            If ApplicationUser.GetPermission("rfInvReceptiSummary") > 0 Then
                smInventory.MenuCommands.Add(invReceiptSummary)
            End If
            If ApplicationUser.GetPermission("Scrap Quantity") > 0 Then
                smInventory.MenuCommands.Add(rptScrapsCount)
            End If
            If ApplicationUser.GetPermission("Shop Floor Quantity report") > 0 Then
                smInventory.MenuCommands.Add(rptShopFloorQtyReport)
            End If

            If ApplicationUser.GetPermission("rfInvUsageSummary") > 0 Then
                smInventory.MenuCommands.Add(invUsageSummary)
            End If
            If ApplicationUser.GetPermission("Technician_Failure_Rate") > 0 Then
                smQualityControl.MenuCommands.Add(QCTechFailureRate)
            End If

            mnuAdmin.MenuCommands.Add(admMenu_Cellular)


            If iRMASecure = 1 Or iCelSecure = 1 Then
                admMenu_Cellular.MenuCommands.Add(admFunc_EditBillMap)
            End If

            If ApplicationUser.GetPermission("Cell_Tray_Administration") > 0 Then
                admMenu_Cellular.MenuCommands.Add(admFunc_CellTrayAdmin)
            End If

            If iMessagingSecure = 1 Or iShipLocChg = 1 Then
                mnuAdmin.MenuCommands.Add(admMenu_Messaging)
            End If
            If iMessagingSecure = 1 Then
                admMenu_Messaging.MenuCommands.Add(admFunc_EditSKU)
                admMenu_Messaging.MenuCommands.Add(admFunc_MoveTray)
                admMenu_Messaging.MenuCommands.Add(admFunc_WOdata)
                admMenu_Messaging.MenuCommands.Add(prodMessagingMain_BuildPallet)
            End If

            'Admin -> Security
            If ApplicationUser.GetPermission("SecurityAdmin") > 0 Then
                mnuAdmin.MenuCommands.Add(admSecurity)
            End If

            'Admin -> Special Processes
            mnuAdmin.MenuCommands.Add(admMenu_SP)
            If ApplicationUser.GetPermission("admSPAddSJUG") > 0 Then
                admMenu_SP.MenuCommands.Add(admSPAddSJUG)
                admMenu_SP.MenuCommands.Add(admSPAddSofVer)
            End If
            If ApplicationUser.GetPermission("SPconsumption") > 0 Then
                admMenu_SP.MenuCommands.Add(admSPconsumption)
            End If

            If ApplicationUser.GetPermission("ChangeSN") > 0 Then
                admMenu_SP.MenuCommands.Add(admChangeSN)
            End If

            If ApplicationUser.GetPermission("ChangeModel") > 0 Then
                admMenu_SP.MenuCommands.Add(admChangeModel)
            End If

            If ApplicationUser.GetPermission("SPDockRec") > 0 Then
                admMenu_SP.MenuCommands.Add(admDockRec)
            End If
            If ApplicationUser.GetPermission("SPDSCPalletBuild") > 0 Then
                admMenu_SP.MenuCommands.Add(admDSCPalletBuild)
            End If
            If ApplicationUser.GetPermission("SPValidateRejects") > 0 Then
                admMenu_SP.MenuCommands.Add(admValidateRejects)
            End If
            If ApplicationUser.GetPermission("SPUpdateAvgPartsCostGoal") > 0 Then
                admMenu_SP.MenuCommands.Add(admMenu_SP_UpdateAvgPartsCostGoal)
            End If
            If ApplicationUser.GetPermission("rfWFadmin") > 0 Then
                admMenu_SP.MenuCommands.Add(admWFadmin)
            End If
            If ApplicationUser.GetPermission("rfCBadmin") > 0 Then
                admMenu_SP.MenuCommands.Add(admContBilladmin)
            End If
            If ApplicationUser.GetPermission("rfNEWrecadmin") > 0 Then
                admMenu_SP.MenuCommands.Add(admNEWrec)
            End If
            If ApplicationUser.GetPermission("rfBillcodeConsumption") > 0 Then
                admMenu_SP.MenuCommands.Add(admBillcodeConsumption)
            End If
            'Admin -> Employee Incentive Program
            If ApplicationUser.GetPermission("EmpIncentiveProgram") > 0 Then
                mnuAdmin.MenuCommands.Add(admMenu_IncentivePrgData)
            End If

            ' Application Configuration Menus.
            Dim _sec As New Data.Buisness.Security()
            If _sec.DoesUserHaveSpecialPerm(PSS.Core.ApplicationUser.IDuser, "App Configuration") Then
                mnuAdmin.MenuCommands.Add(admMenu_AppCfg)
                admMenu_AppCfg.MenuCommands.Add(admMenu_AppCfg_DispList)
                admMenu_AppCfg.MenuCommands.Add(admMenu_AppCfg_CustProdLocList)
                admMenu_AppCfg.MenuCommands.Add(admMenu_AppCfg_CustProdWfList)
                admMenu_AppCfg.MenuCommands.Add(admMenu_AppCfg_ProductList)
            End If
            _sec = Nothing

            '// add our Receiving report menu
            If ApplicationUser.GetPermission("ProductionRcvdDevCntByCust") > 0 Then
                smReceiving.MenuCommands.Add(rptProdRcvdDevCntByCust)
            End If
            If ApplicationUser.GetPermission("rfRecCntDly") > 0 Then
                smReceiving.MenuCommands.Add(rptRecCntDly)
            End If
            If ApplicationUser.GetPermission("rfRecCntDly2Lvl") > 0 Then
                smReceiving.MenuCommands.Add(rptRecCntDly2Lvl)
            End If
            If ApplicationUser.GetPermission("rfRecCntMnthly2Lvl") > 0 Then
                smReceiving.MenuCommands.Add(rptRecCntMnthly2Lvl)
            End If
            If ApplicationUser.GetPermission("rfRecCntDlyMWrty") > 0 Then
                smReceiving.MenuCommands.Add(rptRecCntDlyMWrty)
            End If
            If ApplicationUser.GetPermission("rfRecEmpCnt") > 0 Then
                smReceiving.MenuCommands.Add(rptRecEmpCnt)
            End If
            If ApplicationUser.GetPermission("rfRecCntMonth") > 0 Then
                smReceiving.MenuCommands.Add(rptRecCntMonth)
            End If
            If ApplicationUser.GetPermission("rfRecDetail") > 0 Then
                smReceiving.MenuCommands.Add(rptRecDetail)
            End If
            If ApplicationUser.GetPermission("rfRecVerExc") > 0 Then
                smReceiving.MenuCommands.Add(rptVerExc)
            End If
            If ApplicationUser.GetPermission("rfRecCntDailyStaged") > 0 Then
                smReceiving.MenuCommands.Add(rptRecCntDailyStaged)
            End If
            If ApplicationUser.GetPermission("AmericanMessStagedNotRcvd") > 0 Then
                smReceiving.MenuCommands.Add(rptRecAmericanMessStagedNotRcvd)
            End If
            If ApplicationUser.GetPermission("AmericanMessWIP") > 0 Then
                smReceiving.MenuCommands.Add(rptRecAmericanMessWIP)
            End If
            '// add our Shipping report menu
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                smShipping.MenuCommands.Add(rptCellLineProd)
            End If
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                smShipping.MenuCommands.Add(rptCellProdSummary)
            End If
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                smShipping.MenuCommands.Add(rptShipDevQtyByShipType)
            End If
            If ApplicationUser.GetPermission("CellLineProduction") > 0 Then
                smShipping.MenuCommands.Add(rptWHPalletsNotRcvd)
            End If
            If ApplicationUser.GetPermission("CellShippedPallets") > 0 Then
                smShipping.MenuCommands.Add(rptCellShippedPallets)
            End If
            If ApplicationUser.GetPermission("AllSNsShippedOnDateForCust") > 0 Then
                smShipping.MenuCommands.Add(rptAllSNsShippedOnDateForCust)
            End If
            If ApplicationUser.GetPermission("rfShipCCntDly") > 0 Then
                smShipping.MenuCommands.Add(rptShipCntDly)
            End If
            If ApplicationUser.GetPermission("rfShipCCntDly2Lvl") > 0 Then
                smShipping.MenuCommands.Add(rptShipCntDly2Lvl)
            End If
            If ApplicationUser.GetPermission("rfShipEmpCnt") > 0 Then
                smShipping.MenuCommands.Add(rptShipEmpCnt)
            End If
            If ApplicationUser.GetPermission("rfShipRLRMASum") > 0 Then
                smShipping.MenuCommands.Add(rptShipRLRMASum)
            End If
            If ApplicationUser.GetPermission("rfATCLEPassFail") > 0 Then
                smShipping.MenuCommands.Add(rptATCLEPassFail)
            End If
            If ApplicationUser.GetPermission("rfAmericanMessagingShipDemand") > 0 Then
                smShipping.MenuCommands.Add(rptAmericanMessagingShipDemand)
            End If
            '// Add Production Report Menu
            If ApplicationUser.GetPermission("rptTechRefurbQtyRpt") > 0 Then
                smProduction.MenuCommands.Add(rptTechRefurbQtyRpt)
            End If
            If ApplicationUser.GetPermission("MessLabelProductionRpt") > 0 Then
                smProduction.MenuCommands.Add(rptMessLblProdRpt)
            End If

            If ApplicationUser.GetPermission("rptSNsByRcvedPalletRpt") > 0 Then
                smProduction.MenuCommands.Add(rptSNsByRcvedPalletRpt)
            End If

            '********************************************
            'REPORT MENU
            '********************************************
            mnuReport.MenuCommands.Add(smAdmin)
            mnuReport.MenuCommands.Add(smBilling)
            mnuReport.MenuCommands.Add(smCellSpec)
            mnuReport.MenuCommands.Add(smFinance)
            mnuReport.MenuCommands.Add(smHumanResources)
            mnuReport.MenuCommands.Add(smInventory)
            mnuReport.MenuCommands.Add(smProduction)
            mnuReport.MenuCommands.Add(smQualityControl)
            mnuReport.MenuCommands.Add(smReceiving)
            mnuReport.MenuCommands.Add(smShipping)
            '//Report split out ***********************************************************************

            '// add our root menus
            Me.MenuCommands.Add(mnuFile)
            Me.MenuCommands.Add(mnuAdmin)
            Me.MenuCommands.Add(mnuCustServ)
            If ApplicationUser.GetPermission("Engineering") > 0 Then Me.MenuCommands.Add(mnuEngineering)
            If ApplicationUser.GetPermission("HR") > 0 Then Me.MenuCommands.Add(mnuHR)
            Me.MenuCommands.Add(mnuInventory)
            Me.MenuCommands.Add(mnuProduction)
            Me.MenuCommands.Add(mnuReport)
            Me.MenuCommands.Add(mnuDocuments)
            Me.MenuCommands.Add(mnuHelp)
        End Sub
#End Region
#Region "CONTROL EVENTS"

#Region "FILE MENU"

        Private Sub Close_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles filClose.Click
            If MainWin.wrkArea.TabPages.Count > 0 Then
                MainWin.wrkArea.TabPages.RemoveAt(MainWin.wrkArea.SelectedIndex)
            Else
                MainWin.wrkArea.TabPages.Clear()
            End If
        End Sub
        Private Sub CloseAll_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles filCloseA.Click
            MainWin.wrkArea.TabPages.Clear()
        End Sub
        Private Sub Exit_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles filExit.Click
            Dim objMisc As New Data.Buisness.Security()

            If MessageBox.Show("Are you sure you want to exit?", "Exit", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '**************************
                'Reset Last Logon Machine
                Try
                    If PSS.Core.Global.ApplicationUser.IDuser > 0 Then
                        If objMisc.ResetLastLogonMachine(PSS.Core.Global.ApplicationUser.IDuser) = 0 Then
                            Throw New Exception("Reset 'Last Logon Machine' for this user failed. Inform your lead.")
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Gui.MainWin.Main.Exit_Clicked: " & Environment.NewLine & "Error in resetting the 'Last Logon machine'. " & Environment.NewLine & ex.Message, "End App", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
                '**************************
                End
            End If
        End Sub

#End Region
#Region "UNDETERMINED MENU LOCATION"

        'Public Sub prodMessShip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodMessaging_AMS_ShipOld.Click
        '    Const strTabPageTitle As String = "Shipping"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Shipping.frmShipping())
        'End Sub

        Public Sub BuildingPallet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodMessagingMain_BuildPallet.Click
            Const strTabPageTitle As String = "Build Pallet"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Shipping.frmPalletBuild())
        End Sub

        '**********************************************
        'Admin sub-menu click events  
        '**********************************************

        '**********************************************
        'DO NOT UNCOMMENT THIS CODE - ASIF
        '**********************************************
        ''Commented by Lan 03/15/2013 INACTIVE SCREEN
        'Public Sub admFunc_Messaging_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_Messaging.Click
        '    Const strTabPageTitle As String = "Edit(Messaging)"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frmRecEdit())
        'End Sub

        Public Sub admFunc_MoveTray_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_MoveTray.Click
            Const strTabPageTitle As String = "Assign Tray to Another Line"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Edit.frmMoveTray())
        End Sub

        Public Sub admFunc_EditSKU_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_EditSKU.Click
            Const strTabPageTitle As String = "Edit SKU (MSG)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Edit.frmEdit_SKU())
        End Sub

        Public Sub admFunc_EditBillMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_EditBillMap.Click
            Const strTabPageTitle As String = "Edit Bill Map"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Edit_BillMap.frmEdit_BillMap())
        End Sub

        Public Sub admFunc_WOdata_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_WOdata.Click
            Const strTabPageTitle As String = "Workorder Data Counts"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SpecialProcess.frmWOdata())
        End Sub

        Public Sub admFunc_CellTrayAdmin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_CellTrayAdmin.Click
            Const strTabPageTitle As String = "Cell Tray Administration"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New LogicalTray.frmLogicTrayAdmin())
        End Sub

        Public Sub prodBulkShipping_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodBulkShipping.Click
            Const strTabPageTitle As String = "Ship Cell Pallets"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmBulkShipping())
        End Sub

        ''*****************************************
        ''Comment by Lan 06/03/2007 INACTIVE SCREEN
        ''*****************************************
        ''prodCellShipPallet
        'Public Sub prodCellShipPallet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodCellShipPallet.Click
        '    Const strTabPageTitle As String = "Build ATCLE Ship Pallets"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCellShipPallet())
        'End Sub
        ''*****************************************

        'prodGenericShipPallet
        Public Sub prodGenericShipPallet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodGenericShipPallet.Click
            Const strTabPageTitle As String = "Build Ship Pallets"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCellShipPallet_Generic())
        End Sub

        Public Sub prodAutoShipRWPallet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodAutoShipRWPallet.Click
            Const strTabPageTitle As String = "Auto Ship Rework Pallets"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAutoBuildRWPallet())
        End Sub

        '******************************
        'REFURB
        '******************************
        Public Sub prodPreBillLot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodPreBillLot.Click
            Const strTabPageTitle As String = "Pre-Bill Lot"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(3, , "Pre-Bill Lot", ))
        End Sub
        'ProdProductivityTracker
        Public Sub prodRefurb_ProductivityTracker_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodRefurb_ProductivityTracker.Click
            Const strTabPageTitle As String = "Refurb Tracker"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmProductivityTracker())
        End Sub
        'prodRefurb_Auditor
        Public Sub prodRefurb_Auditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodRefurb_Auditor.Click
            Const strTabPageTitle As String = "Refurb Auditor"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmRefurbAudit())
        End Sub
        '******************************

        ''ProdTranfDevToPre-Cell
        Public Sub prodTransferDevicesToPreCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodTransferDevicesToPreCell.Click
            Const strTabPageTitle As String = "Transfer Devices into Pre-Cell"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmTransferDevices(2))
        End Sub

        'prodTransferDevicesToHold
        Public Sub prodTransferDevicesToHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodTransferDevicesToHold.Click
            Const strTabPageTitle As String = "Transfer Devices into Hold"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmTransferDevices(6))
        End Sub

        ''*****************************************
        ''Comment by Lan 10/31/2007 INACTIVE SCREEN
        ''*****************************************
        'Public Sub ProdProcessFlow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ProdProcessFlow.Click
        '    Const strTabPageTitle As String = "Work Flow"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmProcessFlow())
        'End Sub
        ''*****************************************
        'Comment by Hung 12/23/2011 
        'Public Sub Billing_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodMessagingMain_Bill.Click
        '    Const strTabPageTitle As String = "Billing"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Billing.BillingWin())
        'End Sub

        'Private Sub prodMessRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Rec.Click
        '    Const strTabPageTitle As String = "Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frmReceiving())
        'End Sub

        'Private Sub prodHScell_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHScell.Click
        '    Const strTabPageTitle As String = "High Speed Cell Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.NEW_CellReceiving())
        'End Sub

        ''**************************
        ''Menu Production ==> Line 
        ''**************************
        'Private Sub ProdWarehouseRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProdWarehouseRec.Click
        '    Const strTabPageTitle As String = "Line Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New warehouse.frmWarehouseRec())
        'End Sub

        'Private Sub ProdWarehouseRec_OEM_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProdWarehouseRec_OEM.Click
        '    Const strTabPageTitle As String = "Line Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New warehouse.frmWarehouseRec_OEM())
        'End Sub

        Private Sub ProdReplenishRecover_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProdReplenishRecover.Click
            Const strTabPageTitle As String = "Replenish/Recover Parts"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Inventory.frmReplenishRecover())
        End Sub

        Private Sub ProdGroupLineSideBenchMap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProdGroupLineSideBenchMap.Click
            Const strTabPageTitle As String = "Manage Groups, Lines, Sides, Benches and Cost Centers"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Inventory.frmGrpLineSideBenchMap())
        End Sub

#End Region
#Region "PRODUCT => CoolPad"
        Private Sub prodCoolPad_Main_Receiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_Receiving.Click
            Const strTabPageTitle As String = "CoolPad Recv"
            Const strScreenName As String = "CoolPad Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_Receiving(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodCoolPad_Main_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_PreTest.Click
            Const strTabPageTitle As String = "PreTest" : Const strScreenName As String = "Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID, PSS.Data.Buisness.CP.CoolPad.CoolPad_Product_ID, , , True))
            End If
        End Sub

        Private Sub prodCoolPad_Main_RFTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_RFTest.Click
            Const strTabPageTitle As String = "RF Test" : Const strScreenName As String = "RF Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID, 2))
            End If
        End Sub

        Private Sub prodCoolPad_Main_FlashTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_FlashTest.Click
            Const strTabPageTitle As String = "Flash Test" : Const strScreenName As String = "Flash Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_FlashTest(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodCoolPad_Main_TechBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_TechBill.Click
            Const strTabPageTitle As String = "TechBill" : Const strScreenName As String = "Tech/Bill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID, , , , ))
            End If
        End Sub

        Private Sub prodCoolPad_Main_REF2Seed_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_REF2Seed.Click
            Const strTabPageTitle As String = "REF to Seedstock" : Const strScreenName As String = "REF to Seedstock"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_REF2Seed(PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodCoolPad_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_Label.Click
            Const strTabPageTitle As String = "Label"
            Const strScreenName As String = "Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmLabel(PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID, strScreenName))

        End Sub

        Private Sub prodCoolPad_Main_Swap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_Swap.Click
            Const strTabPageTitle As String = "Swap"
            Const strScreenName As String = "Swap"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_Swap(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))

        End Sub

        Private Sub prodCoolPad_Main_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_BuildBox.Click
            Const strTabPageTitle As String = "BuildBox" : Const strScreenName As String = "Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_BuildBox(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodCoolPad_Main_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_ProduceBox.Click
            Const strTabPageTitle As String = "ProduceBox" : Const strScreenName As String = "Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_ProduceBox(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodCoolPad_Main_FulfillEndUserOrder_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_FulfillEndUserOrder.Click

            Const strTabPageTitle As String = "Fulfill Order" : Const strScreenName As String = "Fulfill Order"

            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_FulfillOrder(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodCoolPad_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCoolPad_Main_Report.Click
            Const strTabPageTitle As String = "Report" : Const strScreenName As String = "Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_Report(strScreenName, PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID))
            End If
        End Sub


#End Region
#Region "PRODUCT => DRIVE CAM"

        Private Sub prodDriveCam_Main_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_Admin.Click
            Const strTabPageTitle As String = "DC Admin"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.DriveCam.frmDCAdmin())
        End Sub
        Private Sub prodDriveCam_Main_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_Billing.Click
            Const strTabPageTitle As String = "Billing"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech())
        End Sub
        Private Sub prodDriveCam_Main_BSB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_BSB.Click
            Const strTabPageTitle As String = "DC Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.DriveCam.frmDCBuildShipBox())
        End Sub
        Private Sub prodDriveCam_Main_DockShipment_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_DockShipment.Click
            Const strTabPageTitle As String = "DC Dock Shipping"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.DriveCam.frmDCDockshipping())
        End Sub
        Private Sub prodDriveCam_Main_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_Rec.Click
            Const strTabPageTitle As String = "DC Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.DriveCam.frmDCRec())
        End Sub
        Private Sub prodDriveCam_Main_Search_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_Search.Click
            Const strTabPageTitle As String = "DC Search"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.DriveCam.frmDCSearch())
        End Sub
        Private Sub prodDriveCam_Main_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDriveCam_Main_ShipBox.Click
            Const strTabPageTitle As String = "DC Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.DriveCam.frmDCShipBox())
        End Sub

#End Region
#Region "PRODUCT => GENERIC PROCESS"
        Private Sub prodGenericProcMain_CreateWO_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenericProcMain_CreateWO.Click
            Const strTabPageTitle As String = "GP Create WO"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmGPCreateWO())
        End Sub
        Private Sub prodGenericProcMain_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenericProcMain_Rec.Click
            Const strTabPageTitle As String = "GP Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmGPProdRec())
        End Sub
        Private Sub prodGenericProcMain_BuildShipLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenericProcMain_BuildShipLot.Click
            Const strTabPageTitle As String = "GP Build Ship Lot"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmBuildShipLot())
        End Sub
        Private Sub prodGenericProcMain_ProduceLot_BuildShipLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenericProcMain_ProduceLot.Click
            Const strTabPageTitle As String = "GP Produce Lot"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmGPProduceLot())
        End Sub
        'Private Sub prodGenericProcMain_ProduceSpecialLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenericProcMain_ProduceSpecialLot.Click
        '    Const strTabPageTitle As String = "GP Produce Special Lot"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmProduceSpecialLot())
        'End Sub
        ''*******************************************
        ''PRODUCT => GENESIS
        ''*******************************************
        'Private Sub prodGenesisProcMain_BuildShipLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenesisProcMain_BuildShipLot.Click
        '    Const strTabPageTitle As String = "Build Ship Lot"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Genesis.frmBuildShipLot())
        'End Sub
        'Private Sub prodGenesisProcMain_ProduceLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenesisProcMain_ProduceLot.Click
        '    Const strTabPageTitle As String = "Produce Lot"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Genesis.frmProduceLot())
        'End Sub
        'Private Sub prodGenesisProcMain_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenesisProcMain_Rec.Click
        '    Const strTabPageTitle As String = "Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Genesis.frmReceiving())
        'End Sub
#End Region
#Region "PRODUCT => Native Instruments"
        Private Sub prodNInst_Main_ShipReturnLabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_ShipReturnLabel.Click
            Const strTabPageTitle As String = "NI - Ship Return Label"
            Const strScreenName As String = "NI - Ship Return Label"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmNIShipReturnLabel(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Ship.Click
            Const strTabPageTitle As String = "Ship Product"
            Const strScreenName As String = "Ship Product"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmNIShipProduct(strScreenName))
        End Sub
        Private Sub prodNInst_Main_Reports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Reports.Click
            Const strTabPageTitle As String = "NI - Reports"
            Const strScreenName As String = "NI - Reports"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmReports(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_ManageActiveModels_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_ManageActiveModels.Click
            Const strTabPageTitle As String = "Model Criteria" : Const strScreenName As String = "Model Criteria"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ManageModelCriteria(PSS.Data.Buisness.NI.CUSTOMERID, PSS.Data.Buisness.NI.MANUFID, PSS.Data.Buisness.NI.PRODID, , False))
        End Sub
        Private Sub prodNInst_Main_MapNIProductPSSIMode_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_MapNIProductPSSIMode.Click
            Const strTabPageTitle As String = "Product/Model Map"
            Const strScreenName As String = "Product/Model Map"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmProductModelMap(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_ChangeCosmeticGrade_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_ChangeCosmeticGrade.Click
            Const strTabPageTitle As String = "Change Cosmetic Grade"
            Const strScreenName As String = "Change Cosmetic Grade"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmChangeCosmeticGrade(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Rec.Click
            Const strTabPageTitle As String = "NI Rec" : Const strScreenName As String = "Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmRec(strScreenName))
        End Sub
        Private Sub prodNInst_Main_WipTransfFrWHToPreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_WipTransfFrWHToPreTest.Click
            Const strTabPageTitle As String = "NI Wip Transfer" : Const strScreenName As String = "Transfer From Warehouse To Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmNIWipTransfer(strScreenName))
        End Sub
        Private Sub prodNInst_Main_Triage_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Triage.Click
            Const strTabPageTitle As String = "NI Pre-Test" : Const strScreenName As String = "Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.pretest.frmPreTest(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID, PSS.Data.Buisness.NI.PRODID, True, False))
        End Sub
        Private Sub prodNIstr_Main_PartReclaim_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNIstr_Main_PartReclaim.Click
            Const strTabPageTitle As String = "Reclaims Part"
            Const strScreenName As String = "Relaims Part"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmPartReclaim(PSS.Data.Buisness.NI.CUSTOMERID, Data.Buisness.NI.LOCID, strScreenName))
        End Sub
        Private Sub prodNInst_Main_Repair_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Repair.Click
            Const strTabPageTitle As String = "Repair/Tech" : Const strScreenName As String = "Repair"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmBilling(, PSS.Data.Buisness.NI.CUSTOMERID, strScreenName, , ))
        End Sub
        Private Sub prodNInst_Main_AQL_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_AQL.Click
            Const strTabPageTitle As String = "AQL" : Const strScreenName As String = "AQL"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID, 4))
        End Sub
        Private Sub prodNInst_Main_Warehouse_FillOrders_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Warehouse_FillOrders.Click
            Const strTabPageTitle As String = "NI Fill Order" : Const strScreenName As String = "Fill Order"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New warehouse.frmFillOrders(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_OBA.Click
            Const strTabPageTitle As String = "OBA"
            Const strScreenName As String = "OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMI_OBA(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID, 5))
        End Sub
        Private Sub prodNInst_Main_BuildPackageMaterials_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_BuildPackageMaterials.Click
            Const strTabPageTitle As String = "Build Package Materials"
            Const strScreenName As String = "Build Package Materials"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmBuildPackageMaterials(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID, PSS.Data.Buisness.NI.MANUFID))
        End Sub
        Private Sub prodNInst_Main_DataMagment_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_DataMagment.Click
            Const strTabPageTitle As String = "Data Management"
            ' Const strScreenName As String = "OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmDataManagement())
        End Sub
        Private Sub prodNInst_Main_Warehous_AddWHCharge_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Warehous_AddWHCharge.Click
            Const strTabPageTitle As String = "Add WH Charge"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmStorage(PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_WipTransf_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_WipTransf.Click
            Const strTabPageTitle As String = "Wip Tranfer"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxWIPTranser(PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
#End Region
#Region "PRODUCT => NABCO"

        Private Sub prodNABCO_Main_AddCharge_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNABCO_Main_AddCharge.Click
            Const strTabPageTitle As String = "Add WH Charge"
            ' Const strScreenName As String = "OBA"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmStorage(2539))
        End Sub

#End Region
#Region "PRODUCT => SONNITROL"

        Private Sub prodSonitrolRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSonitrol_Rec.Click
            Const strTabPageTitle As String = "Sonitrol Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSonitrolReceiving())
        End Sub
        'SonitroL/Plexus Billing
        Private Sub prodSonitroL_PBilling_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSonitroL_PBilling.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, 2254))
        End Sub
        Private Sub prodSonitroL_SBilling_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSonitroL_SBilling.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, 2242))
        End Sub

#End Region
#Region "PRODUCT => TEXTNOW INC"
        Private Sub prodTextNow_Main_Warehouse_Dashboard_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTextNow_Main_Warehouse_DashBoard.Click
            Const strTabPageTitle As String = "TextNow SIMS Dashboard"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New TextNow.frmTNSimDashboard())
        End Sub
        Private Sub prodTextNow_Main_Warehouse_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTextNow_Main_Warehouse_Rec.Click
            Const strTabPageTitle As String = "TextNow SIMS Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New TextNow.frmTNSimReceiving())
        End Sub
        Private Sub pprodTextNow_Main_Warehouse_FillOrders_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTextNow_Main_Warehouse_FillOrders.Click
            Const strTabPageTitle As String = "Fill Order"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSIMOrderFulfillment(PSS.Data.Buisness.TN.CUSTOMERID))
        End Sub
        Private Sub prodTextNow_Main_Reports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTextNow_Main_Reports.Click
            Const strTabPageTitle As String = "Order Reports"
            Const strReportName As String = "Order Reports"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmTNReports(strReportName, PSS.Data.Buisness.TN.CUSTOMERID))
        End Sub
        'Private Sub pprodTextNow_Main_Reports_Inv_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTextNow_Main_Reports_Inv.Click
        '	Const strTabPageTitle As String = "Inventory Reports"
        '	Dim win As Crownwood.Magic.Controls.TabPage
        '	If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSIMInventoryReports(PSS.Data.Buisness.TN.CUSTOMERID))
        'End Sub
        'Private Sub pprodTextNow_Main_Reports_Ord_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTextNow_Main_Reports_Ord.Click
        '	Const strTabPageTitle As String = "Order Reports"
        '	Dim win As Crownwood.Magic.Controls.TabPage
        '	If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSIMOrderReports(PSS.Data.Buisness.TN.CUSTOMERID))
        'End Sub
#End Region
#Region "PRODUCT => TRACFONE"
        Private Sub prodTF_Main_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Admin.Click
            Const strTabPageTitle As String = "TF Admin"
            Const strScreenName As String = "Admin Functions"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmAdmin())
        End Sub

        Private Sub prodTF_Main_SetModelStatus_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_SetModelStatus.Click
            Const strTabPageTitle As String = "Model Status"
            Const strScreenName As String = "Model Status"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ManageModelStatus(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 57, 2, True))
        End Sub

        Private Sub prodTF_Main_ExcelRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_ExcelRpt.Click
            Const strTabPageTitle As String = "Excel Rpt"
            'Const strScreenName As String = "Excel Rpt"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmExcelRpt(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID))
        End Sub

        Private Sub prodTF_Main_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Billing.Click
            Const strTabPageTitle As String = "Billing"
            Const strScreenName As String = "Billing"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(1, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName, 0, , True))
        End Sub
        Private Sub prodTF_Main_Tech_PartReclaim_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Tech_PartReclaim.Click
            Const strTabPageTitle As String = "Reclaims Part"
            Const strScreenName As String = "Reclaims Part"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmPartReclaim(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, Data.Buisness.TracFone.BuildShipPallet.TracFone_LOC_ID, strScreenName))
        End Sub
        Private Sub prodTF_Main_Tech_BER_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Tech_BER.Click
            Const strTabPageTitle As String = "BER Screen"
            Const strScreenName As String = "BER Screen"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmBERScreen(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub
        Private Sub prodTF_Main_PreEval_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_PreEval.Click
            Const strTabPageTitle As String = "Pre-Eval"
            Const strScreenName As String = "Pre-Evalulation"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmPreEval(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub
        Private Sub prodTF_Main_Tech_PreBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Tech_PreBill.Click
            Const strTabPageTitle As String = "Pre-Bill"
            Const strScreenName As String = "Pre-Bill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(1, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub
        Private Sub prodTF_Main_Tech_Refurbished_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Tech_Refurbished.Click
            Const strTabPageTitle As String = "Refurbished/Tech"
            Const strScreenName As String = "Refurbished/Tech"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(2, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName, , , True))
        End Sub

        Private Sub prodTF_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Label.Click
            Const strTabPageTitle As String = "Label"
            Const strScreenName As String = "LABEL"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmLabel(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub

        Private Sub prodTF_Main_ProdTrack_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_ProdTrack.Click
            Const strTabPageTitle As String = "Prod Track"
            Const strScreenName As String = "Productivity Tracking"
            Dim win As Crownwood.Magic.Controls.TabPage

            OpenWin(strTabPageTitle, win, New Gui.Production.frmWSProductivityTracker())
        End Sub

        Private Sub prodTF_Main_Rec_Cell_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Rec_Cell.Click
            Const strTabPageTitle As String = "Cell Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmCCRec(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID))
        End Sub
        Private Sub prodTF_Main_Rec_WH_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Rec_WH.Click
            Const strTabPageTitle As String = "Warehouse Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmRec())
        End Sub
        Private Sub prodTF_Main_PreBuff_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_PreBuff.Click
            Const strTabPageTitle As String = "Pre-Buff"
            Const strScreenName As String = "Pre-Buff"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmPreBuff(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub

        Private Sub prodTF_Ship_BuildShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Ship_BuildShipPallet.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Const strScreenName As String = "BOX"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmBuildShipPallet(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub
        Private Sub prodTF_Ship_BuildShipPalletAcc_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Ship_BuildShipPalletAcc.Click
            Const strTabPageTitle As String = "Build Ship Box Accessory"
            Const strScreenName As String = "BOX ACCESSORY"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmBuildAccessShipBox())
        End Sub
        Private Sub prodTF_Ship_ShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Ship_ShipPallet.Click
            Const strTabPageTitle As String = "Ship Box"
            Const strScreenName As String = "PRODUCE"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmProdShip(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
        End Sub

        Private Sub prodTF_Main_Test_AQL_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_AQL_OBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodTF_Main_Test_BERCheck_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_BERCheck.Click
            Const strTabPageTitle As String = "DBR CHECK"
            Const strScreenName As String = "DBR CHECK"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmDBRVerify(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID))
        End Sub
        Private Sub prodTF_Main_Test_Final_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_Final.Click
            Const strTabPageTitle As String = "Quality Control"
            Const strScreenName As String = "FQA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 2))
        End Sub
        Private Sub prodTF_Main_Test_Pretest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_Pretest.Click
            Const strTabPageTitle As String = "PreTest"
            Const strScreenName As String = "PreTest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID))
        End Sub
        Private Sub prodTF_Main_Test_RF1_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_RF1.Click
            Const strTabPageTitle As String = "RF Test"
            Const strScreenName As String = "RF1"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 2))
        End Sub
        Private Sub prodTF_Main_Test_RF2_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_RF2.Click
            Const strTabPageTitle As String = "RF Test"
            Const strScreenName As String = "RF2"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 10))
        End Sub
        Private Sub prodTF_Main_Test_PSD_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_PSD.Click
            Const strTabPageTitle As String = "PSD Test"
            Const strScreenName As String = "PSD"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 11))
        End Sub
        Private Sub prodTF_Main_Test_SWScreening_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_SWScreening.Click
            Const strTabPageTitle As String = "Software Screening"
            Const strScreenName As String = "TFSWScreening"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFone.TFSWScreening())
            End If
        End Sub
        Private Sub prodTF_Main_Test_SoftRef_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_SoftRef.Click
            Const strTabPageTitle As String = "Software Refurbish"
            Const strScreenName As String = "Software Refurbish"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmSoftwareRefurbish(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 14))
        End Sub

        Private Sub prodTF_Main_Test_Triage_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_Triage.Click
            Const strTabPageTitle As String = "Triage"
            Const strScreenName As String = "Triage"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFTriage(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID))
        End Sub
        Private Sub prodTF_Main_Test_BuildTriagedBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_BuildTriagedBox.Click
            Const strTabPageTitle As String = "Build Triaged Box"
            Const strScreenName As String = "Build Triaged Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTriagedBox(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID))
        End Sub

        'Transfer Boxes

        Private Sub prodTF_Main_TransferBoxes_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_TransferBoxes.Click
            Const strTabPageTitle As String = "Transfer Boxes"
            Const strScreenName As String = "Transfer Boxes"
            Dim win As Crownwood.Magic.Controls.TabPage
            Try
                If Not CheckOpenTabs(strTabPageTitle) Then
                    OpenWin(strTabPageTitle, win, New Gui.frmTrnasferBoxes())
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Menu Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub



        'wip transfer
        Private Sub prodTF_Main_WipTransf_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_WipTrans_ToPreBill.Click, prodTF_Main_WipTrans_ToPretest.Click, prodTF_Main_WipTrans_ToStaging.Click, prodTF_Main_WipTrans_ToWHRB.Click, prodTF_Main_WipTrans_ToQuarantine.Click, prodTF_Main_WipTrans_ToAWAP.Click, prodTF_Main_WipTrans_ToWHWIP.Click, prodTF_Main_WipTrans_RemoveFrFailAWP.Click, prodTF_Main_WipTrans_ToRF1.Click, prodTF_Main_WipTrans_ToBERComplete.Click, prodTF_Main_WipTrans_ToBER.Click, prodTF_Main_WipTrans_ToBERScreen.Click, prodTF_Main_WipTrans_ToTeardown.Click, prodTF_Main_WipTrans_ToObsolete.Click, prodTF_Main_WipTrans_ToProdHold.Click, prodTF_Main_WipTrans_ToEngineering.Click  'prodTF_Main_WipTrans_ToFFBS.Click, prodTF_Main_WipTrans_ToFFCP.Click, prodTF_Main_WipTrans_ToFFTF.Click,
            Const strTabPageTitle As String = "Wip Transfer"
            Dim strScreenName As String = ""
            Dim win As Crownwood.Magic.Controls.TabPage

            Try
                If sender.text.ToString = "To Pre-Bill" Then
                    strScreenName = "To Prebill"
                ElseIf sender.text.ToString = "To Pretest" Then
                    strScreenName = "To Pretest"
                ElseIf sender.text.ToString = "To Production Staging" Then
                    strScreenName = "To Staging"
                ElseIf sender.text.ToString = "To WH-RB" Then
                    strScreenName = "To WH-RB"
                ElseIf sender.text.ToString = "To QUARANTINE" Then
                    strScreenName = "To QUARANTINE"
                ElseIf sender.text.ToString = "To AWAP" Then
                    strScreenName = "To AWAP"
                ElseIf sender.text.ToString.Trim.StartsWith("To Functional Fail") Then
                    strScreenName = sender.text.ToString.Trim
                ElseIf sender.text.ToString.Trim = "To WH-WIP" Then
                    strScreenName = "To WH-WIP"
                ElseIf sender.text.ToString.Trim = "Remove From Fail and AWAP" Then
                    strScreenName = "Remove From Fail and AWAP"
                ElseIf sender.text.ToString.Trim = "To RF1" Then
                    strScreenName = "To RF1"
                ElseIf sender.text.ToString.Trim = "To Teardown" Then
                    strScreenName = "To Teardown"
                ElseIf sender.text.ToString.Trim = "To BER" Then
                    strScreenName = "To BER"
                ElseIf sender.text.ToString.Trim = "To BER Complete" Then
                    strScreenName = "To BER Complete"
                ElseIf sender.text.ToString.Trim = "To BER Screen" Then
                    strScreenName = "To BER Screen"
                ElseIf sender.text.ToString.Trim = "To Obsolete" Then
                    strScreenName = "To Obsolete"
                ElseIf sender.text.ToString.Trim = "To Production Hold" Then
                    strScreenName = "To Production Hold"
                ElseIf sender.text.ToString.Trim = "To Engineering" Then
                    strScreenName = "To Engineering"
                End If

                If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmWorkStationTrans(strScreenName))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Menu Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub prodTF_Main_WipTrans_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_WipTrans_Admin.Click
            Const strTabPageTitle As String = "Wip Transfer"
            Dim strScreenName As String = ""
            Dim win As Crownwood.Magic.Controls.TabPage
            Try
                strScreenName = "Wip Transfer Admin"
                If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmTF_AdminStationTrans_CreateWHBox(strScreenName))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Menu Click Event", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub prodTF_Main_Warehouse_AssignBatteryCover_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_AssignBatteryCover.Click
            Const strTabPageTitle As String = "Assigning Battery Cover"
            Const strScreenName As String = "Assigning Battery Cover"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.AssignBateryCover(strScreenName))
        End Sub
        Private Sub prodTF_Main_Warehouse_UnassignBatteryCover_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_UnassignBatteryCover.Click
            Const strTabPageTitle As String = "Unssigning Battery Cover"
            Const strScreenName As String = "Unassigning Battery Cover"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmUnAssignBatteryCover(strScreenName))

        End Sub
        Private Sub prodTF_Main_Warehouse_AssignWHLoc_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_AssignWHLoc.Click
            Const strTabPageTitle As String = "Assigning WH Location"
            Const strScreenName As String = "Assigning Warehouse Location"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmAsignWHBoxToWHLoc(strScreenName))
        End Sub

        Private Sub prodTF_Main_Warehouse_FillOpenOrder_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_FillOpenOrder.Click
            Const strTabPageTitle As String = "Fill Open Order"
            Const strScreenName As String = "Fill Open Order"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmWHFillingOrder(strScreenName))
        End Sub
        Private Sub prodTF_Main_Warehouse_Manifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_Manifest.Click
            Const strTabPageTitle As String = "Manifest"
            Const strScreenName As String = "Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmWHManifest(strScreenName))
        End Sub
        Private Sub prodTF_Main_Warehouse_ManifestBER_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_ManifestBER.Click
            Const strTabPageTitle As String = "Manifest BER"
            Const strScreenName As String = "Manifest BER"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmManifestBERBoxes(strScreenName))
        End Sub

        Private Sub prodTF_Main_Warehouse_SearchWHRecInfo_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_SearchWHRecInfo.Click
            Const strTabPageTitle As String = "WH Search"
            Const strScreenName As String = "Search Warehouse Receive Information"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmWorkStationTrans(strScreenName))
        End Sub

#End Region
#Region "PRODUCT => TRACFONE FulfillmentKit"
        Private Sub prodTFFK_Main_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Admin.Click
            Const strTabPageTitle As String = "Admin Functions"
            Const strScreenName As String = "Admin Functions"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_Admin())
            End If
        End Sub
        Private Sub prodTFFK_Main_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Rec.Click
            Const strTabPageTitle As String = "TF FK Receiving"
            Const strScreenName As String = "TF FK Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_Receiving())
            End If
        End Sub
        Private Sub prodTFFK_Main_Transfer_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Transfer.Click
            Const strTabPageTitle As String = "TF FK WH Transfer"
            Const strScreenName As String = "TF FK WH Transfer"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_WH_Transfer())
            End If
        End Sub
        Private Sub prodTFFK_Main_Pick_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Pick.Click
            Const strTabPageTitle As String = "TF FK Pick"
            Const strScreenName As String = "TF FK Pick"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_Pick())
            End If
        End Sub
        Private Sub prodTFFK_Main_Pack_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Pack.Click
            Const strTabPageTitle As String = "TF FK Pack"
            Const strScreenName As String = "TF FK Pack"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_Pack())
            End If
        End Sub
        Private Sub prodTFFK_Main_Relabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Relabel.Click
            Const strTabPageTitle As String = "TF FK Relabel"
            Const strScreenName As String = "TF FK Relabel"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_RelabelModel())
            End If
        End Sub
        'Private Sub prodTFFK_Main_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Ship.Click
        '    Const strTabPageTitle As String = "TF FK Ship"
        '    Const strScreenName As String = "TF FK Ship"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_Shipment())
        '    End If
        'End Sub
        'Private Sub prodTFFK_Main_Item_History_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Item_History.Click
        '    Const strTabPageTitle As String = "TF FK Item History"
        '    Const strScreenName As String = "TF FK Item History"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_ItemHistory())
        '    End If
        'End Sub
        Private Sub prodTFFK_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_Report.Click
            Const strTabPageTitle As String = "TF FK Report"
            Const strScreenName As String = "TF FK Report"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_Reports())
            End If
        End Sub
        Private Sub prodTFFK_Main_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_QC.Click
            Const strTabPageTitle As String = "Kitting QC"
            Const strScreenName As String = "Kitting QC"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_QC())
            End If
        End Sub
        Private Sub prodTFFK_Main_KittedRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_KittedRpt.Click
            Const strTabPageTitle As String = "Kitted Report"
            Const strScreenName As String = "Kitted Report"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_KittedReport())
            End If
        End Sub

        'BYOP Kitting
        Private Sub prodTFFK_Main_BYOP_Kitting_Setup_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_BYOP_Kitting_Setup.Click
            Const strTabPageTitle As String = "Kitting Setup"
            Const strScreenName As String = "Kitting Setup"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_BYOP_Kitting_Setup())
            End If
        End Sub
        Private Sub prodTFFK_Main_BYOP_Kitting_Pack_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_BYOP_Kitting_Pack.Click
            Const strTabPageTitle As String = "Build Pack"
            Const strScreenName As String = "Build Pack"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_BYOP_Kitting_Pack())
            End If
        End Sub
        Private Sub prodTFFK_Main_BYOP_Kitting_MCarton_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_BYOP_Kitting_MCarton.Click
            Const strTabPageTitle As String = "Build Master Carton"
            Const strScreenName As String = "Build Master Carton"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_BYOP_Kitting_MCarton())
            End If
        End Sub
        Private Sub prodTFFK_Main_BYOP_Kitting_Pallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_BYOP_Kitting_Pallet.Click
            Const strTabPageTitle As String = "Build Pallet"
            Const strScreenName As String = "Build Pallet"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_BYOP_Kitting_Pallet())
            End If
        End Sub
        Private Sub prodTFFK_Main_BYOP_SimplePacking_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_BYOP_SimplePacking.Click
            Const strTabPageTitle As String = "Re-pack"
            Const strScreenName As String = "Re-pack"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_BYOP_SimplePackProcess())
            End If
        End Sub

        'RAC/GIN Fulfillment
        Private Sub prodTFFK_Main_RAC_GIN_FillOrder_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTFFK_Main_RAC_GIN_FillOrder.Click
            Const strTabPageTitle As String = "RAC/GIN FillOrder"
            Const strScreenName As String = "RAC/GIN FillOrder"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.TracFoneFulfillmentKit.frmTFFK_RAC_GIN_FillOrder())
            End If
        End Sub
#End Region

#Region "PRODUCT => Vivint"
        Private Sub prodVivint_Main_WoDockRecv_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_WoDockRecv.Click
            Const strTabPageTitle As String = "WO/DockRecv"
            Const strScreenName As String = "WO/DockRecv"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_WO_DockRecv(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_DeviceRecv_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_DeviceRecv.Click
            Const strTabPageTitle As String = "Device Recv"
            Const strScreenName As String = "Device Recv"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_DeviceRecv(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_PreTest.Click
            Const strTabPageTitle As String = "PreTest"
            Const strScreenName As String = "PreTest"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID, PSS.Data.Buisness.VV.Vivint.Vivint_Product_ID, , , True))
            End If
        End Sub

        Private Sub prodVivint_Main_TechBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_TechBill.Click
            Const strTabPageTitle As String = "TechBill" : Const strScreenName As String = "Tech/Bill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID, , , , ))
            End If
        End Sub

        Private Sub prodVivint_Main_Kitting_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_KittingLabelUnit.Click
            Const strTabPageTitle As String = "Kitting"
            Const strScreenName As String = "Kitting"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_kitting(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_KittingSetup_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_KittingSetup.Click
            Const strTabPageTitle As String = "Kitting Setup"
            Const strScreenName As String = "Kitting Setup"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_KittingSetup(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_AQL_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_AQL_OBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID, 4))
        End Sub

        Private Sub prodVivint_Main_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_BuildBox.Click
            Const strTabPageTitle As String = "Build Box"
            Const strScreenName As String = "Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_BuildBox(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_ProduceBox.Click
            Const strTabPageTitle As String = "Produce Box"
            Const strScreenName As String = "Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_ProduceBox(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_Manifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_Manifest.Click
            Const strTabPageTitle As String = "Manifest"
            Const strScreenName As String = "Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmSendPalletPackingListFiles(PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_PoRequest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_PoRequest.Click
            Const strTabPageTitle As String = "PO Request"
            Const strScreenName As String = "PO Request"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_PoRequest(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_FulfillOrder_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_FulfillOrder.Click
            Const strTabPageTitle As String = "Fulfill Order"
            Const strScreenName As String = "Fulfill Order"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_FulfillOrder(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_OnHold_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_OnHold.Click
            Const strTabPageTitle As String = "Manage On-Hold"
            Const strScreenName As String = "Manage On-Hold"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_OnHold(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVivint_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVivint_Main_Report.Click
            Const strTabPageTitle As String = "Report"
            Const strScreenName As String = "Report"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.VV.frmVivint_Report(strScreenName, PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID))
            End If
        End Sub
#End Region


#Region "PRODUCT => WFM (Tracfone)"

        ' WFM (TRACFONE) - prodWFM_Main
        ' prodWFM_Main_Receiving
        Private Sub prodWFM_Main_Receiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Receiving.Click
            Const strTabPageTitle As String = "Receiving"
            Const strScreenName As String = "Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWFMPalletCartonPhoneRec())
            End If
        End Sub

        ' BOXING - prodWFM_Main_BldBx
        ' prodWFM_Main_BldBx_BldIBBx
        Private Sub prodWFM_Main_BldBx_BldIBBx_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_BldBx_BldIBBx.Click
            Const strTabPageTitle As String = "Build Inbound Box"
            Const strScreenName As String = "Build Inbound Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmBoxing(Warehouse.frmBoxing.BOXING_PROCESS.INITIAL_BOXING, 2597, 3402, 8, False, True, True, strScreenName))     'Gui.WFMTracfone.frmTmoBoxing())
            End If
        End Sub
        ' prodWFM_Main_BldBx_BldTrgdBx
        Private Sub prodWFM_Main_BldBx_BldTrgdBx_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_BldBx_BldTrgdBx.Click
            Const strTabPageTitle As String = "Build Triage Box"
            Const strScreenName As String = "Build Triage Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmBoxing(Warehouse.frmBoxing.BOXING_PROCESS.TRIAGE_BOXING, 2597, 3402, 11, True, True, False, strScreenName))     ' Gui.WFMTracfone.frmTmoBoxing())		
            End If
        End Sub

        'Produce NTF Box
        Private Sub prodWFM_Main_ProduceNTFBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_ProduceNTFBox.Click

            Const strTabPageTitle As String = "Produce NTF Box"
            Const strScreenName As String = "Produce NTF Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmWFMProduceBox(2597, 3402, strScreenName))     'Gui.WFMTracfone.frmTmoBoxing())
            End If
        End Sub

        ' WIP TRANSFER - prodWFM_Main_WT
        ' prodWFM_Main_WT_ToTrgStgngBulk
        Private Sub prodWFM_Main_WT_ToTrgStgngBulk_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_WT_ToTrgStgngBulk.Click
            Const strTabPageTitle As String = "To Triage-Staging"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmWhToStaging(2597, 2, 4, False)) 'New Gui.Warehouse.frmWhToStaging(2597, 2, 4, False))
        End Sub

        'Private Sub prodWFM_Main_WT_ToPreTrgBulk_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_WT_ToTrgStgngBulk.Click
        '	Const strTabPageTitle As String = "From Triage-Staging"
        '	Dim win As Crownwood.Magic.Controls.TabPage
        '	If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmWhToStaging(2597, 2, 9, True))
        'End Sub

        ' prodWFM_Main_WT_ToTrg
        Private Sub prodWFM_Main_WT_ToTrg_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_WT_ToTrg.Click
            Const strTabPageTitle As String = "To Triage"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmSimpleBoxTransfer(2597, 2, 0, 9, 10))
        End Sub

        ' TESTING - prodWFM_Main_Tstng
        ' prodWFM_Main_Tstng_Trg
        Private Sub prodWFM_Main_Tstng_Trg_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Tstng_Trg.Click
            Const strTabPageTitle As String = "WFM Triage"
            Const strScreenName As String = "WFM Triage"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWfmTriage())
            End If
        End Sub
        ' prodWFM_Main_Tstng_AQL_OBA
        Private Sub prodWFM_Main_Tstng_AQL_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Tstng_AQL_OBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWFMOOBA(strScreenName, 2597, 4))
        End Sub
        ' WAREHOUSE - prodWFM_Main_WH
        ' prodWFM_Main_WH_AsgnWhLoc
        Private Sub prodWFM_Main_WH_AsgnWhLoc_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_WH_AsgnWhLoc.Click
            Const strTabPageTitle As String = "Assign Warehouse Location"
            Const strScreenName As String = "Assign Warehouse Location"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWfmAssignWHLoc())
            End If
        End Sub
        ' prodWFM_Main_WH_SNSearch
        Private Sub prodWFM_Main_WH_SNSearch_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_WH_SNSearch.Click
            Const strTabPageTitle As String = "WFM Serial Number Search"
            Const strScreenName As String = "WFM Serial Number Search"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWfmSNSearch())
            End If
        End Sub


        ' ADMINISTRATION - prodWFM_Main_Admin
        ' prodWFM_Main_Admin_ASN_Imp
        Private Sub prodWFM_Main_Admin_ASN_Imp_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Admin_ASN_Imp.Click
            Const strTabPageTitle As String = "ASN File Import"
            Const strScreenName As String = "ASN File Import"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmTmoAsnImport())
            End If
        End Sub
        ' prodWFM_Main_Admin_MdlPrfx_Cnfg
        Private Sub prodWFM_Main_Admin_MdlPrfx_Cnfg_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Admin_MdlPrfx_Cnfg.Click
            Const strTabPageTitle As String = "Model Prefix Configuration"
            Const strScreenName As String = "Model Prefix Configuration"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWFMModelPrefixes())
            End If
        End Sub

        'Build Ship Pallet Accessary
        Private Sub prodWFM_Ship_BuildShipPalletAcc_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Ship_BuildShipPalletAcc.Click
            Const strTabPageTitle As String = "WFM BuildShipBox Accessory"
            Const strScreenName As String = "WFM BOX ACCESSORY"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmBuildAccessShipBox(PSS.Data.Buisness.WFM.CUSTOMER_ID))
        End Sub

        'WH Fill Open Order, Manifest
        Private Sub prodWFM_Main_Warehouse_FillOpenOrder_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Warehouse_FillOpenOrder.Click
            Const strTabPageTitle As String = "WFM Fill Order"
            Const strScreenName As String = "WFM Fill Order"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmWHFillingOrder(strScreenName, PSS.Data.Buisness.WFM.CUSTOMER_ID))
        End Sub
        Private Sub prodWFM_Main_Warehouse_Manifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Warehouse_Manifest.Click
            Const strTabPageTitle As String = "WFM Manifest"
            Const strScreenName As String = "WFM Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmWHManifest(strScreenName, PSS.Data.Buisness.WFM.CUSTOMER_ID))
        End Sub
        'prodWFM_Ship_SplitOutboundBox
        Private Sub prodWFM_Ship_SplitOutboundBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Ship_SplitOutboundBox.Click
            Const strTabPageTitle As String = "WFM Split Outbound Box"
            Const strScreenName As String = "WFM Split Outbound Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWFMSplitBox(strScreenName, PSS.Data.Buisness.WFM.CUSTOMER_ID))
        End Sub

        ' REPORTS - prodWFM_Main_Reports
        Private Sub prodWFM_Main_Reports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWFM_Main_Reports.Click
            Const strTabPageTitle As String = "WFM Reporting"
            Const strScreenName As String = "WFM Reporting"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WFMTracfone.frmWfmReports())
            End If
        End Sub

#End Region
#Region "PRODUCT => WAREHOUSE"
        Public Sub ProdSendPalletPackingListFiles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodWarehouse_SendPalletPackingListFiles.Click
            Const strTabPageTitle As String = "Manifest Processing"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSendPalletPackingListFiles())
        End Sub
        Private Sub prodWarehouse_PrintUPCLabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWarehouse_PrintUPCLabel.Click
            Const strTabPageTitle As String = "Print UPC Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmPrintUPCLabel())
        End Sub
#End Region
#Region "PRODUCT => WIKO"
        Private Sub prodWIKO_Main_GenericConfig_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_GenericConfig.Click
            Const strTabPageTitle As String = "WIKO Software Ver."
            Const strScreenName As String = "WIKO Software Ver."
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_GenericSoftwareConfig(strScreenName, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID))
            End If
        End Sub
        Private Sub prodWIKO_Main_Receiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_Receiving.Click
            Const strTabPageTitle As String = "WIKO Recv"
            Const strScreenName As String = "WIKO Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_Receiving(strScreenName, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWIKO_Main_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_PreTest.Click
            Const strTabPageTitle As String = "PreTest" : Const strScreenName As String = "Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, PSS.Data.Buisness.WIKO.WIKO.WIKO_Product_ID, , , True))
            End If
        End Sub

        Private Sub prodWIKO_Main_RFTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_RFTest.Click
            Const strTabPageTitle As String = "RF Test" : Const strScreenName As String = "RF Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, 2))
            End If
        End Sub

        Private Sub prodWIKO_Main_FlashTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_FlashTest.Click
            Const strTabPageTitle As String = "Flash Test" : Const strScreenName As String = "Flash Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_FlashTest(strScreenName, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWIKO_Main_TechBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_TechBill.Click
            Const strTabPageTitle As String = "TechBill" : Const strScreenName As String = "Tech/Bill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, , , , ))
            End If
        End Sub

        Private Sub prodWIKO_Main_REF2Seed_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_REF2Seed.Click
            Const strTabPageTitle As String = "REF to Seedstock" : Const strScreenName As String = "REF to Seedstock"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_REF2Seed(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodWIKO_Main_Swap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_Swap.Click
            Const strTabPageTitle As String = "Swap"
            Const strScreenName As String = "Swap"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_Swap(strScreenName, PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID))

        End Sub

        Private Sub prodWIKO_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_Label.Click
            Const strTabPageTitle As String = "Label"
            Const strScreenName As String = "Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmLabel(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, strScreenName))

        End Sub

        Private Sub prodWIKO_Main_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_BuildBox.Click
            Const strTabPageTitle As String = "BuildBox" : Const strScreenName As String = "Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_BuildBox(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodWIKO_Main_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_ProduceBox.Click
            Const strTabPageTitle As String = "ProduceBox" : Const strScreenName As String = "Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_ProduceBox(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, strScreenName))
            End If
        End Sub


        Private Sub prodWIKO_Main_SpecialBuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_SpecialBuildBox.Click

            Const strTabPageTitle As String = "Special Build Box" : Const strScreenName As String = "Special Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_SPecialBuildBox(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID, strScreenName))
            End If
        End Sub

        Private Sub prodWIKO_Main_SpecialRecv_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_SpecialRecv.Click

            Const strTabPageTitle As String = "Special Receiving" : Const strScreenName As String = "Special Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_SpecialReceiving(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID, strScreenName))
            End If
        End Sub

        'Private Sub prodWIKO_Main_SpecialKitting_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_SpecialKitting.Click

        '    Const strTabPageTitle As String = "SIM Card Kit" : Const strScreenName As String = "SIM Card Kit"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_SpecialKit(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID, strScreenName))
        '    End If
        'End Sub

        Private Sub prodWIKO_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWIKO_Main_Report.Click
            Const strTabPageTitle As String = "Report" : Const strScreenName As String = "WIKO Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWiko_Report(PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID, strScreenName))
                'OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWiko_Report())
            End If
        End Sub

#End Region
#Region "PRODUCT => WingTech T-Mobile"

        Private Sub prodWingTech_Main_GenericConfig_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_GenericConfig.Click
            Const strTabPageTitle As String = "WingTech Software Ver."
            Const strScreenName As String = "WingTech Software Ver."
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWIKO_GenericSoftwareConfig(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub
        Private Sub prodWingTech_Main_Receiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_Receiving.Click
            Const strTabPageTitle As String = "WingTech Recv"
            Const strScreenName As String = "WingTech Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTech.frmWingTech_Receiving(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWingTech_Main_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_PreTest.Click
            Const strTabPageTitle As String = "PreTest" : Const strScreenName As String = "Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID, PSS.Data.Buisness.WingTech.WingTech.WingTech_Product_ID, , , True))
            End If
        End Sub

        Private Sub prodWingTech_Main_RFTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_RFTest.Click
            Const strTabPageTitle As String = "RF Test" : Const strScreenName As String = "RF Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID, 2))
            End If
        End Sub

        Private Sub prodWingTech_Main_FlashTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_FlashTest.Click
            Const strTabPageTitle As String = "Flash Test" : Const strScreenName As String = "Flash Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_FlashTest(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWingTech_Main_TechBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_TechBill.Click
            Const strTabPageTitle As String = "TechBill" : Const strScreenName As String = "Tech/Bill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID, , , , ))
            End If
        End Sub

        Private Sub prodWingTech_Main_REF2Seed_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_REF2Seed.Click
            Const strTabPageTitle As String = "REF to Seedstock" : Const strScreenName As String = "REF to Seedstock"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTech.frmWingTech_REF2Seed(PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        'Private Sub prodWingTech_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_Label.Click
        '    Const strTabPageTitle As String = "Label"
        '    Const strScreenName As String = "Label"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmLabel(PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID, strScreenName))

        'End Sub

        Private Sub prodWingTech_Main_Swap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_Swap.Click
            Const strTabPageTitle As String = "Swap"
            Const strScreenName As String = "Swap"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTech.frmWingTech_Swap(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWingTech_Main_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_BuildBox.Click
            Const strTabPageTitle As String = "BuildBox" : Const strScreenName As String = "Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTech.frmWingTech_BuildBox(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWingTech_Main_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_ProduceBox.Click
            Const strTabPageTitle As String = "ProduceBox" : Const strScreenName As String = "Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTech.frmWingTech_ProduceBox(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub

        ''Private Sub prodWingTech_Main_FulfillEndUserOrder_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_FulfillEndUserOrder.Click

        ''    Const strTabPageTitle As String = "Fulfill Order" : Const strScreenName As String = "Fulfill Order"

        ''    Dim win As Crownwood.Magic.Controls.TabPage

        ''    If Not CheckOpenTabs(strTabPageTitle) Then
        ''        OpenWin(strTabPageTitle, win, New Gui.WingTech.frmWingTech_FulfillOrder(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
        ''    End If
        ''End Sub

        Private Sub prodWingTech_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTech_Main_Report.Click
            Const strTabPageTitle As String = "Report" : Const strScreenName As String = "Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_Report(strScreenName, PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID))
            End If
        End Sub



#End Region
#Region "PRODUCT=>WINGTECHATT"
        Private Sub prodWingTechATT_Main_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_BuildBox.Click
            Const strTabPageTitle As String = "Build Box" : Const strScreenName As String = "Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_buildBox(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodWingTechATT_Main_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_PreTest.Click
            Const strTabPageTitle As String = "PreTest"
            Const strScreenName As String = "PreTest"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Product_ID, , , True))
            End If
        End Sub

        Private Sub prodWingTechATT_Main_RFTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_RFTest.Click
            Const strTabPageTitle As String = "RF Test" : Const strScreenName As String = "RF Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New WingTechATT.frmWingTechATT_RFTest(strScreenName, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, 2))
            End If
        End Sub
        Private Sub prodWingTechATT_Main_FlashTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_FlashTest.Click
            Const strTabPageTitle As String = "Flash Test" : Const strScreenName As String = "Flash Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_FlashTest(strScreenName, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID))
            End If
        End Sub
        Private Sub prodWingTechATT_Main_TechBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_TechBill.Click
            Const strTabPageTitle As String = "TechBill" : Const strScreenName As String = "TechBill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, , , , ))
            End If
        End Sub


        Private Sub prodWingTechATT_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_Label.Click
            Const strTabPageTitle As String = "WingTechATT Label"
            Const strScreenName As String = "WingTechATT Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_label(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, strScreenName))

        End Sub

        Private Sub prodWingTechATT_Main_REF2Seed_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_REF2Seed.Click
            Const strTabPageTitle As String = "REF to Seedstock" : Const strScreenName As String = "REF to Seedstock"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_REF2Seed(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodWingTechATT_Main_Swap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_Swap.Click
            Const strTabPageTitle As String = "Swap"
            Const strScreenName As String = "Swap"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_Swap(strScreenName, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID))

        End Sub
        Private Sub prodWingTechATT_Main_Receiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_Receiving.Click
            Const strTabPageTitle As String = "Receiving"
            Const strScreenName As String = "Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_Receiving(strScreenName, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodWingTechATT_Main_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_ProduceBox.Click
            Const strTabPageTitle As String = "ProduceBox" : Const strScreenName As String = "Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_ProduceBox(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, strScreenName))
            End If
        End Sub
        Private Sub prodWingTechATT_Main_SpecialBuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_SpecialBuildBox.Click

            Const strTabPageTitle As String = "Special Build Box" : Const strScreenName As String = "Special Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_SPecialBuildBox(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID, strScreenName))
            End If
        End Sub

        Private Sub prodWingTechATT_Main_SpecialRecv_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_SpecialRecv.Click

            Const strTabPageTitle As String = "Special Receiving" : Const strScreenName As String = "Special Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_SpecialReceiving(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID, strScreenName))
            End If
        End Sub

        'Private Sub prodWingTechATT_Main_SpecialKitting_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_SpecialKitting.Click

        '    Const strTabPageTitle As String = "SIM Card Kit" : Const strScreenName As String = "SIM Card Kit"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_SpecialKit(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID, strScreenName))
        '    End If
        'End Sub
        Private Sub prodWingTechATT_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWingTechATT_Main_Report.Click
            Const strTabPageTitle As String = "Report" : Const strScreenName As String = "WingTechATT Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWiko_Report(PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID, strScreenName))
                'OpenWin(strTabPageTitle, win, New Gui.WingTechATT.frmWingTechATT_Report())
            End If
        End Sub


#End Region
#Region "PRODUCT => Vinsmart"
        Private Sub prodVinsmart_Main_Receiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_Receiving.Click
            Const strTabPageTitle As String = "Vinsmart Receiving"
            Const strScreenName As String = "Vinsmart Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_Receiving(strScreenName, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVinsmart_Main_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_PreTest.Click
            Const strTabPageTitle As String = "PreTest" : Const strScreenName As String = "Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Product_ID, , , True))
            End If
        End Sub

        Private Sub prodVinsmart_Main_RFTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_RFTest.Click
            Const strTabPageTitle As String = "RF Test" : Const strScreenName As String = "RF Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New TracFone.frmTFRF(strScreenName, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, 2))
            End If
        End Sub

        Private Sub prodVinsmart_Main_FlashTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_FlashTest.Click
            Const strTabPageTitle As String = "Flash Test" : Const strScreenName As String = "Flash Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.CP.frmCoolPad_FlashTest(strScreenName, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID))
            End If
        End Sub

        Private Sub prodVinsmart_Main_TechBill_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_TechBill.Click
            Const strTabPageTitle As String = "TechBill" : Const strScreenName As String = "Tech/Bill"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, , , , ))
            End If
        End Sub

        Private Sub prodVinsmart_Main_REF2Seed_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_REF2Seed.Click
            Const strTabPageTitle As String = "REF to Seedstock" : Const strScreenName As String = "REF to Seedstock"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_REF2Seed(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodVinsmart_Main_Swap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_Swap.Click
            Const strTabPageTitle As String = "Swap"
            Const strScreenName As String = "Swap"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_Swap(strScreenName, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID))

        End Sub

        Private Sub prodVinsmart_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_Label.Click
            Const strTabPageTitle As String = "Label"
            Const strScreenName As String = "Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_label(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, strScreenName))

        End Sub

        Private Sub prodVinsmart_Main_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_BuildBox.Click
            Const strTabPageTitle As String = "BuildBox" : Const strScreenName As String = "Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_BuildBox(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodVinsmart_Main_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_ProduceBox.Click
            Const strTabPageTitle As String = "ProduceBox" : Const strScreenName As String = "Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_ProduceBox(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, strScreenName))
            End If
        End Sub

        Private Sub prodVinsmart_Main_SpecialBuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_SpecialBuildBox.Click

            Const strTabPageTitle As String = "Special Build Box" : Const strScreenName As String = "Special Build Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_SPecialBuildBox(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID, strScreenName))
            End If
        End Sub

        Private Sub prodVinsmart_Main_SpecialRecv_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_SpecialRecv.Click

            Const strTabPageTitle As String = "Special Receiving" : Const strScreenName As String = "Special Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_SpecialReceiving(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID, strScreenName))
            End If
        End Sub
        Private Sub prodVinsmart_Main_AQL_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_AQL_OBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, 4))
        End Sub
        'Private Sub prodVinsmart_Main_SpecialKitting_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_SpecialKitting.Click

        '    Const strTabPageTitle As String = "SIM Card Kit" : Const strScreenName As String = "SIM Card Kit"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_SpecialKit(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID, strScreenName))
        '    End If
        'End Sub
        Private Sub prodVinsmart_Main_Report_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodVinsmart_Main_Report.Click
            Const strTabPageTitle As String = "Report" : Const strScreenName As String = "Vinsmart Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.WIKO.frmWiko_Report(PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID, strScreenName))
                'OpenWin(strTabPageTitle, win, New Gui.Vinsmart.frmVinsmart_Report())
            End If
        End Sub

#End Region
#Region "PRODUCT => ZIOSK"
        Private Sub prodZiosk_Main_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodZiosk_Main_Label.Click
            Const strTabPageTitle As String = "Ziosk Labeling"
            Const strScreenName As String = "Ziosk Labeling"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New Gui.Ziosk.frmLabel(strScreenName, PSS.Data.Buisness.Ziosk.CUSTOMER_ID))
            End If
        End Sub
#End Region
#Region "UNDETERMINED MENU LOCATION"

        Private Sub TechHS_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTechHS.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech())
        End Sub

        Private Sub PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPreTest.Click
            Const strTabPageTitle As String = "PreTest" : Const strScreenName As String = "Pre-Test"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New pretest.frmPreTest(strScreenName, , , , ))
        End Sub

#End Region
#Region "ADMIN MENU"

        Private Sub admSecurity_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admSecurity.Click
            Const strTabPageTitle As String = "Security Administration"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Security.SecurityAdmin())
        End Sub

        'Admin -> special process
        Private Sub admSPAddSJUG_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admSPAddSJUG.Click
            Const strTabPageTitle As String = "Add SJUG No"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAddSUG())
        End Sub

        Private Sub admSPAddSofVer_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admSPAddSofVer.Click
            Const strTabPageTitle As String = "Add Soft Version"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Motorola.frmAddSofVer())
        End Sub

        Private Sub admSPconsumption_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admSPconsumption.Click
            Const strTabPageTitle As String = "Part Consumption File Creation"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SpecialProcess.frmCreateConsumptionFile())
        End Sub

        Private Sub admDSCPalletBuild_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admDSCPalletBuild.Click
            Const strTabPageTitle As String = "Discrepant Pallet Build"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New DSCPalletBuild.frmDscPalletBuild())
        End Sub

        Private Sub admChangeSN_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admChangeSN.Click
            Const strTabPageTitle As String = "Change SN"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmChangeSN())
        End Sub

        Private Sub admChangeModel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admChangeModel.Click
            Const strTabPageTitle As String = "Change Model"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.AdminFunctions.frmChangeModel())
        End Sub

        Private Sub admDockRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admDockRec.Click
            Const strTabPageTitle As String = "Dock Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New DockReceive.frmDockReceive())
        End Sub

        ''********************************************
        ''Commented by Lan 10/31/2007 INACTIVE SCREEN
        'BRIGHT POINT
        ''********************************************
        'Private Sub rptCellstarDailyShippingManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptCellstarDailyShippingManifest.Click
        '    Const strTabPageTitle As String = "Brightpoint Daily Shipping Manifest"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Brightpoint Daily Shipping Manifest.rpt"))
        'End Sub
        'Private Sub rptRecBrightpointRepairedDev_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecBrightpointReceivedDev.Click
        '    Const strTabPageTitle As String = "Brightpoint Received Devices"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New frmExcelReportParameters(strTabPageTitle, Data.ExcelReports.Excel_Report_Call.BRIGHTPOINT_RECEIVED_DEVICES))
        '    End If
        'End Sub
        'Private Sub rptAdminRevenueDetailCellstar_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRevDetailCellstar.Click
        '    Const strTabPageTitle As String = "Admin Revenue Detail Brightpoint AB"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_DETAIL_BRIGHTPOINT_AB))
        '    End If
        'End Sub
        'Private Sub prodBrightpointOpts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodBrightpointOpts.Click
        '    Const strTabPageTitle As String = "Brightpoint Operations"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmBrightpointOperations())
        'End Sub
        'Private Sub admBrightpointPartNumUpdate_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admBrightpointPartNumUpdate.Click
        '    Const strTabPageTitle As String = "Brightpoint Part Number Update"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCellStarPartNumUpdate())
        'End Sub
        'Private Sub rptAdminRevenueCellstar_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRevCellstar.Click
        '    Const strTabPageTitle As String = "Admin Revenue Summary Brightpoint AB"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then
        '        OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_SUMMARY_BRIGHTPOINT_AB))
        '    End If
        'End Sub
        'Private Sub admBrightpoint_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admBrightpoint.Click
        '    Const strTabPageTitle As String = "Brightpoint Admin"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAdminBrightPoint())
        'End Sub
        'Private Sub admResendBrightpointXMLFiles_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admResendBrightpointXMLFiles.Click
        '    Const strTabPageTitle As String = "Resend Brightpoint XML Files"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmResendCellstarXMLFile())
        'End Sub

        'Private Sub CellStarReceiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCSRec.Click
        '    Const strTabPageTitle As String = "Brightpoint Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frm_custspecREC_CellStar())
        'End Sub

        'Private Sub admAssignAwaitParts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admAssignAwaitParts.Click
        '    Const strTabPageTitle As String = "Warehouse Assign Awaiting Parts"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New warehouse.frmAssignAwaitParts())
        'End Sub
        ''********************************************

        Private Sub admWFadmin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admWFadmin.Click
            Const strTabPageTitle As String = "Weight Factor Admin"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.WFadmin.frmCellModelFactor())
        End Sub

        Private Sub admCBadmin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admContBilladmin.Click
            Const strTabPageTitle As String = "Contingent Billing Admin"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ContBillAdmin.frmContBillAdmin())
        End Sub

        Private Sub admBillcodeConsumption_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admBillcodeConsumption.Click
            Const strTabPageTitle As String = "Billcode Consumption (IND)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.BCconsume_IND.frmBillcodeConsumption())
        End Sub

        Private Sub admValidateRejects_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admValidateRejects.Click
            Const strTabPageTitle As String = "Validate Rejects"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ValidateRejects.frmValidateRejects())
        End Sub
        Private Sub admMenu_SP_UpdateAvgPartsCostGoal_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admMenu_SP_UpdateAvgPartsCostGoal.Click
            Const strTabPageTitle As String = "Avg Parts Cost Goal"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSetAvgPartCostGoal())
        End Sub

        ''Admin -> Employee Incentive Program
        'Private Sub sm_CellularIncentivePrg_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles sm_CellularIncentivePrg.Click
        '    Const strTabPageTitle As String = "Cellular Incentive Program"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmEmpIncentive())
        'End Sub

        Private Sub admMenu_IncentivePrgData_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admMenu_IncentivePrgData.Click
            Dim strTabPageTitle As String = sender.text.ToString
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmIncentivePrg())
        End Sub
        Private Sub admMenu_AppCfg_DispList_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admMenu_AppCfg_DispList.Click
            Dim strTabPageTitle As String = sender.text.ToString
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDispostionList())
        End Sub
        Private Sub admMenu_AppCfg_CustProdLocList_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admMenu_AppCfg_CustProdLocList.Click
            Dim strTabPageTitle As String = sender.text.ToString
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCustProdLocationList())
        End Sub
        Private Sub admMenu_AppCfg_CustProdWfList_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admMenu_AppCfg_CustProdWfList.Click
            Dim strTabPageTitle As String = sender.text.ToString
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCustProdWorkflowList())
        End Sub

        Private Sub admMenu_AppCfg_ProductList_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admMenu_AppCfg_ProductList.Click
            Dim strTabPageTitle As String = sender.text.ToString
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmProductList())
        End Sub
#End Region
#Region "UNDETERMINED MENU LOCATION"
        Private Sub prodCreatePSSISNs_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCreatePSSISNs.Click
            Const strTabPageTitle As String = "Create PSSI Serial Numbers"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New PSSISNs.CreatePSSISNs())
        End Sub
#End Region
#Region "COST CENTER"

        Private Sub prodCC_ScanDevToCC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCC_ScanDevToCC.Click
            Const strTabPageTitle As String = "Scan Devices into Cost Center"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmScanDevicesIntoCostCenter())
        End Sub

        Private Sub prodCC_SetUPH_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCC_SetUPH.Click
            Const strTabPageTitle As String = "Set UPH"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.PIP.frmPIPModelUPH())
        End Sub

        Private Sub prodCC_TimeTracking_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCC_TimeTracking.Click
            Const strTabPageTitle As String = "Time Tracking"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCostCenterTimeTracking())
        End Sub

        Private Sub prodCC_MapEmpDept_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCC_MapEmpDept.Click
            Const strTabPageTitle As String = "Map Emp Dept"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCostCenterEmpDeptMapping())
        End Sub
#End Region
#Region "UNDETERMINED MENU LOCATION"
        Private Sub prodQC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodQC.Click
            Const strTabPageTitle As String = "Quality Control"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC())
        End Sub
#End Region
#Region "MESSAGING"

        '***********************************
        'MESSAGING
        '***********************************

        Private Sub prodMessagingOpenLinesQueue_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingOpenLinesQueue.Click
            Const strTabPageTitle As String = "Messaging Open Lines Queue"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmOpenLineQueue())
        End Sub

        Private Sub prodMessagingMain_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Label.Click
            Const strTabPageTitle As String = "Messaging Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessLabel())
        End Sub




        Private Sub prodMessagingMain_Reports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Reports.Click
            Const strTabPageTitle As String = "Messaging Reports"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmMessReports1())
        End Sub
        Private Sub prodMessagingMain_FCVsLabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_FCVsLabel.Click
            Const strTabPageTitle As String = "FC vs Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmMess_FC_vs_Label())
        End Sub

        'American Messaging
        Private Sub prodMessaging_AMS_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, 14))
        End Sub
        Private Sub prodMessaging_AMS_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodReceive_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_OptConsole.Click
            Const strTabPageTitle As String = "Messaging Operations Console"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessConsole())
        End Sub

        Private Sub prodMessaging_AMS_EvalProcess_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_EvalProcess.Click
            Const strTabPageTitle As String = "Messaging Eval Process"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmMessEvaluation())
        End Sub
        'prodMessaging_AMS_FreqCapcodeMgmt
        'prodMessagingMain_ManageActiveModels 
        Private Sub prodMessagingMain_ManageActiveModels_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ManageActiveModels.Click
            Const strTabPageTitle As String = "Managing Models"
            Const strScreenName As String = "Managing Models"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmMessActiveModels())
        End Sub
        Private Sub prodMessagingMain_FreqCodeMap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_FreqCodeMap.Click
            Const strTabPageTitle As String = "Customer FreqCode Map"
            Const strScreenName As String = "Customer FreqCode Map"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmCustomerFreqCodeMap())
        End Sub
        Private Sub prodMessagingMain_UploadForecast_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_UploadForecast.Click
            Const strTabPageTitle As String = "AMS Forecast Uploading"
            Const strScreenName As String = "AMS Forecast Uploading"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAMSForecast())
        End Sub
        Private Sub prodMessagingMain_WIPTransfer_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_WIPTransfer.Click
            Const strTabPageTitle As String = "AMS WIP Tansfer"
            Const strScreenName As String = "AMS WIP Tansfer"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAMSWIPTransfer())
        End Sub

        ' prodMessagingMain_WhToPreEval
        Private Sub prodMessagingMain_WhToPreEval_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_WhToPreEval.Click
            Const strTabPageTitle As String = "AMS Warehouse to Pre-Eval Tansfer"
            Const strScreenName As String = "AMS Warehouse to Pre-Eval Tansfer"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAmsWhToPreEvalTransfer())
        End Sub

        Private Sub prodMessaging_AMS_FreqCapcodeMgmt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_FreqCapcodeMgmt.Click
            Const strTabPageTitle As String = "Freq/Capcode Mgmt""AMS WIP Tansfer"
            Const strScreenName As String = "AMS - Freq/Capcode Mgmt."
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmFreqCapcodeManagement(14, strScreenName))
        End Sub
        Private Sub prodMessagingMain_AMS_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_AMS_BB.Click
            Const strTabPageTitle As String = "AMS Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_AMS_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_AMS_Ship.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID))
        End Sub

        'A-1 Wireless Communications
        Private Sub prodMessagingMain_A1WC_CreateWO_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_CreateWO.Click
            Try
                Const strTabPageTitle As String = "Create"
                Dim win As Crownwood.Magic.Controls.TabPage

                If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmGPCreateWO(PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.A1WirelessComm_PRODID, PSS.Data.Buisness.SkyTel.A1WirelessComm_GROUPID))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub prodMessagingMain_A1WC_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_Rec.Click
            Const strTabPageTitle As String = "Receiving"
            Const strScreenDesc As String = "A-1 Wireless Comunications"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID, strScreenDesc))
        End Sub
        Private Sub prodMessagingMain_A1WC_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_A1WC_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessagingMain_A1WC_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_A1WC_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_A1WC_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_A1WC_BuildOtherShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_A1WC_BuildOtherShipPallet.Click
            Const strTabPageTitle As String = "Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.A1WirelessComm_CUSTOMER_ID, Data.Buisness.SkyTel.A1WirelessComm_LOC_ID))
        End Sub

        'ATS ------------------------------------
        Private Sub prodMessagingMain_ATS_CreateWO_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_CreateWO.Click
            Try
                Const strTabPageTitle As String = "Create"
                Dim win As Crownwood.Magic.Controls.TabPage

                If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmGPCreateWO(PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.ATS_PRODID, PSS.Data.Buisness.SkyTel.ATS_GROUPID))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub prodMessagingMain_ATS_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_Rec.Click
            Const strTabPageTitle As String = "Receiving"
            Const strScreenDesc As String = "ATS"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID, strScreenDesc))
        End Sub
        Private Sub prodMessagingMain_ATS_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_ATS_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessagingMain_ATS_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_ATS_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_ATS_BuildOtherShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_ATS_BuildOtherShipPallet.Click
            Const strTabPageTitle As String = "Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.ATS_CUSTOMER_ID, Data.Buisness.SkyTel.ATS_LOC_ID))
        End Sub


        'Contact Wireless
        Private Sub prodMessagingMain_CW_CreateWO_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_CreateWO.Click
            Try
                Const strTabPageTitle As String = "Create"
                Dim win As Crownwood.Magic.Controls.TabPage

                If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.GenericProcess.frmGPCreateWO(PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.ContactWireless_PRODID, PSS.Data.Buisness.SkyTel.ContactWireless_GROUPID))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub prodMessagingMain_CW_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_Rec.Click
            Const strTabPageTitle As String = "Receiving"
            Const strScreenDesc As String = "Contact Wireless"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID, strScreenDesc))
        End Sub

        Private Sub prodMessagingMain_CW_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CW_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessagingMain_CW_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_CW_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CW_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CW_BuildOtherShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CW_BuildOtherShipPallet.Click
            Const strTabPageTitle As String = "Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.ContactWireless_CUSTOMER_ID, Data.Buisness.SkyTel.ContactWireless_LOC_ID))
        End Sub

        'Cook Pager
        'Private Sub prodMessagingMain_CP_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_Rec.Click
        '    Const strTabPageTitle As String = "Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID))
        'End Sub

        Private Sub prodMessagingMain_CP_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CP_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessagingMain_CP_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_CP_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CP_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CP_BuildOtherShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_BuildOtherShipPallet.Click
            Const strTabPageTitle As String = "Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID, Data.Buisness.SkyTel.CookPager_LOC_ID))
        End Sub
        Private Sub prodMessagingMain_CP_FreqCapcodeMgmt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CP_FreqCapcodeMgmt.Click
            Const strTabPageTitle As String = "Freq/Capcode Mgmt"
            Const strScreenName As String = "CP - Freq/Capcode Mgmt."
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmFreqCapcodeManagement(PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID, strScreenName))
        End Sub

        'Critical Alert
        Private Sub prodMessagingMain_CA_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CA_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CA_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CA_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessagingMain_CA_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CA_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_CA_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CA_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_CA_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CA_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID))
        End Sub
        'Private Sub prodMessagingMain_CA_BuildOtherShipPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Ca_BuildOtherShipPallet.Click
        '    Const strTabPageTitle As String = "Other Ship Manifest"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID, Data.Buisness.SkyTel.CriticalAlertNorth_LOC_ID))
        'End Sub
        Private Sub prodMessagingMain_CA_FreqCapcodeMgmt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_CA_FreqCapcodeMgmt.Click
            Const strTabPageTitle As String = "Freq/Capcode Mgmt"
            Const strScreenName As String = "CA - Freq/Capcode Mgmt."
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmFreqCapcodeManagement(PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID, strScreenName))
        End Sub

        ''Skytel
        'Private Sub prodMessagingMain_SkyTel_DBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_DBRManifest.Click
        '    Const strTabPageTitle As String = "SkyTel Other Ship Manifest"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        'End Sub
        'Private Sub prodMessagingMain_SkyTel_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_Billing.Click
        '    Const strTabPageTitle As String = "Technician (High Speed)"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        'End Sub
        'Private Sub prodMessagingMain_SkyTel_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_Rec.Click
        '    Const strTabPageTitle As String = "SkyTel Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        'End Sub
        'Private Sub prodMessagingMain_SkyTel_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_BB.Click
        '    Const strTabPageTitle As String = "SkyTel Build Ship Box"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        'End Sub
        'Private Sub prodMessagingMain_SkyTel_LoadASN_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_LoadASN.Click
        '    Const strTabPageTitle As String = "Load ASN"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelLoadASN())
        'End Sub
        'Private Sub prodMessagingMain_SkyTel_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_Ship.Click
        '    Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        'End Sub

        ''Morris Communication
        Private Sub prodMessagingMain_MorrisCom_DBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_DBRManifest.Click
            Const strTabPageTitle As String = "Morris Comm. Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID, Data.Buisness.SkyTel.MorrisCom_LOC_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        'Private Sub prodMessagingMain_MorrisCom_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_Rec.Click
        '    Const strTabPageTitle As String = "Morris Communication Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        'End Sub
        Private Sub prodMessagingMain_MorrisCom_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_BB.Click
            Const strTabPageTitle As String = "Morris Communication Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_Ship.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_FreqCapcodeMgmt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_FreqCapcodeMgmt.Click
            Const strTabPageTitle As String = "Freq/Capcode Mgmt"
            Const strScreenName As String = "Morris - Freq/Capcode Mgmt."
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmFreqCapcodeManagement(PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID, strScreenName))
        End Sub

        'Propage
        Private Sub prodMessagingMain_Propage_DBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_DBRManifest.Click
            Const strTabPageTitle As String = "Propage Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID, Data.Buisness.SkyTel.Propage_LOC_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        'Private Sub prodMessagingMain_Propage_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_Rec.Click
        '    Const strTabPageTitle As String = "Propage Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        'End Sub
        Private Sub prodMessagingMain_Propage_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_Propage_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_BB.Click
            Const strTabPageTitle As String = "Propage Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_Ship.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_FreqCapcodeMgmt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_FreqCapcodeMgmt.Click
            Const strTabPageTitle As String = "Freq/Capcode Mgmt"
            Const strScreenName As String = "CP - Freq/Capcode Mgmt."
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmFreqCapcodeManagement(PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID, strScreenName))
        End Sub

        'Aquis
        Private Sub prodMessagingMain_Aquis_ModelSetup_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_ModelSetup.Click
            Const strTabPageTitle As String = "Aquis Model Setup"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAquisModelSetup())
        End Sub
        'Private Sub prodMessagingMain_Aquis_WHRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_WHRec.Click
        '    Const strTabPageTitle As String = "Aquis WH Rec"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAquisWHRec())
        'End Sub
        'Private Sub prodMessagingMain_Aquis_ProdRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_ProdRec.Click
        '    Const strTabPageTitle As String = "Aquis Prod Rec"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAquisProdRec())
        'End Sub
        'Private Sub prodMessagingMain_Aquis_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_Rec.Click
        '    Const strTabPageTitle As String = "Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID))
        'End Sub
        Private Sub prodMessagingMain_Aquis_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_Billing.Click
            Const strTabPageTitle As String = "Billing"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.Messaging.Aquis_Cust_ID, strTabPageTitle))
        End Sub
        Private Sub prodMessagingMain_Aquis_AQLOBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_AQLOBA.Click
            Const strTabPageTitle As String = "AQL-OBA"
            Const strScreenName As String = "AQL-OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmTFOOBA(strScreenName, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID, 4))
        End Sub
        Private Sub prodMessagingMain_Aquis_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_BB.Click
            Const strTabPageTitle As String = "Aquis Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Aquis_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_Ship.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Aquis_FreqCapcodeMgmt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_FreqCapcodeMgmt.Click
            Const strTabPageTitle As String = "Freq/Capcode Mgmt"
            Const strScreenName As String = "CP - Freq/Capcode Mgmt."
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmFreqCapcodeManagement(PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID, strScreenName))
        End Sub

        Private Sub prodMessaging_AMS_DBRNERPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_DBRNERPallet.Click
            Const strTabPageTitle As String = "Build AMS DBR/NER Pallet"
            Const strScreenName As String = "Build AMS DBR/NER Pallet"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessDBRNERManifest(strScreenName))
        End Sub
        '

        'AMS InfraStructure
        Private Sub prodMessagingMain_AMSInfraStructure_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_AMSInfraStructure_Rec.Click
            Const strTabPageTitle As String = "AMS InfraStructure Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMSInfraStructureRec(strTabPageTitle, PSS.Data.Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_AMSInfraStructure_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_AMSInfraStructure_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID, , , ))
        End Sub
        Private Sub prodMessagingMain_AMSInfraStructure_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_AMSInfraStructure_Ship.Click
            Const strTabPageTitle As String = "AMS InfraStructure Dock Shipping"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMSInfraStructureDockShip(strTabPageTitle, PSS.Data.Buisness.AMSInfraStructure.AMSInfraStructure_CUSTOMER_ID))
        End Sub

#End Region
#Region "Other Messaging Customers"
        'Anna Jacques Hospital
        Private Sub pprodMessaging_OtherCust_Anna_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Anna_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Anna_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Anna_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessaging_OtherCust_Anna_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Anna_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Anna_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Anna_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID))
        End Sub

        'Lahey Clinic
        Private Sub pprodMessaging_OtherCust_Lahey_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Lahey_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Lahey_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Lahey_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessaging_OtherCust_Lahey_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Lahey_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Lahey_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Lahey_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID))
        End Sub

        'Masco Services
        Private Sub pprodMessaging_OtherCust_Masco_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Masco_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Masco_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Masco_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessaging_OtherCust_Masco_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Masco_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Masco_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Masco_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID))
        End Sub

        'Franciscan Children's Hospital
        Private Sub pprodMessaging_OtherCust_Franciscan_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Franciscan_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Franciscan_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Franciscan_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessaging_OtherCust_Franciscan_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Franciscan_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Franciscan_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Franciscan_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID))
        End Sub

        'Maine Medical Center
        Private Sub pprodMessaging_OtherCust_Maine_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Maine_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Maine_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Maine_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessaging_OtherCust_Maine_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Maine_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_Maine_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_Maine_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID))
        End Sub

        'SMHC-Biddeford Medical Center
        Private Sub pprodMessaging_OtherCust_SMHC_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_SMHC_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_SMHC_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_SMHC_QC.Click
            Const strTabPageTitle As String = "QC" : Const strScreenName As String = "QC Functional"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID, 1))
        End Sub
        Private Sub prodMessaging_OtherCust_SMHC_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_SMHC_BuildShipBox.Click
            Const strTabPageTitle As String = "Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID))
        End Sub
        Private Sub prodMessaging_OtherCust_SMHC_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_OtherCust_SMHC_ShipBox.Click
            Const strTabPageTitle As String = "Produce Box" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strScreenName, PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID))
        End Sub

#End Region
#Region "HTC"
        ''************************
        ''HTC Section
        ''************************
        ''adnmin
        'Private Sub prodHTC_MainAdmin_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainAdmin_Admin.Click
        '    Const strTabPageTitle As String = "Admin"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCAdmin())
        'End Sub
        'Private Sub prodHTC_MainAdmin_AdminEdit_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainAdmin_AdminEdit.Click
        '    Const strTabPageTitle As String = "Admin Edit Function"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTC_Edit_Function())
        'End Sub
        'Private Sub prodHTC_MainAdmin_ProdTracking_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainAdmin_ProdTracking.Click
        '    Const strTabPageTitle As String = "Productivity Tracking"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCProdTracking())
        'End Sub
        'Private Sub prodHTC_MainAdmin_RMAProcessing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainAdmin_RMAProcessing.Click
        '    Const strTabPageTitle As String = "HTC_RMAProcessing"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCProcessRMA())
        'End Sub

        ''inventory
        'Private Sub prodHTC_MainInventory_MBLabel_AND_prodHTC_ProdRec_Relabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainInventory_MBLabel.Click, prodHTC_MainProd_ReLabel.Click
        '    'Const strTabPageTitle As String = "HTC Relabel"
        '    Dim strScreenName As String = ""
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If sender.text.ToString.Trim.ToUpper = "RELABEL" Then
        '        strScreenName = sender.text.ToString.Trim
        '    Else
        '        strScreenName = "MB Label"
        '    End If

        '    If Not CheckOpenTabs(strScreenName) Then OpenWin(strScreenName, win, New frmLabel(strScreenName))
        'End Sub
        'Private Sub prodHTC_LCDMBRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainInventory_LCDMBRec.Click
        '    Const strTabPageTitle As String = "LCD/MB Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTC_LCD_MainBoard_Receiving())
        'End Sub
        'Private Sub prodHTC_MainInventory_LCD_MainBoard_Search_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainInventory_LCD_MainBoard_Search.Click
        '    Const strTabPageTitle As String = "HTC Part Search"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTC_LCD_MainBoard_Search())
        'End Sub

        ''production
        'Private Sub prodHTC_MainProd_ProdRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_ProdRec.Click
        '    Const strTabPageTitle As String = "Production Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCProdRec())
        'End Sub
        'Private Sub prodHTC_MainProd_DiagnosticTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_Diagnosis.Click
        '    Dim strTabPageTitle As String = sender.text.ToString
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    Dim strScreenName As String = "Diagnostic"

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDiagnosticTest(strTabPageTitle, strScreenName.ToUpper))
        'End Sub
        'Private Sub prodHTC_MainProd_Repair_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_Repair.Click, prodHTC_MainProd_PreBill.Click
        '    Const strTabPageTitle As String = "Technician (High Speed)"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    Dim iBillType As Integer = 0 '1:Pre-Bill, 2:Tech

        '    If sender.text.ToString.Trim.ToUpper = "Pre-Bill".ToUpper Then
        '        iBillType = 1
        '    Else
        '        iBillType = 2
        '    End If

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(iBillType))
        'End Sub
        'Private Sub prodHTC_MainProd_BillingAudit_AND_prodHTC_MainInventory_ReclaimParts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_BillingAuditor.Click, prodHTC_MainInventory_ReclaimParts.Click
        '    Dim strTabPageTitle As String = sender.text.ToString
        '    Dim strScreenName As String = sender.text.ToString
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmBillingAuditAndPartsReclaim(strScreenName))
        'End Sub
        'Private Sub prodHTC_MainProd_RF_Final_OOBA_Tests_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_PIA.Click, prodHTC_MainProd_RF.Click, prodHTC_MainProd_Final.Click, prodHTC_MainProd_OOBA.Click
        '    Dim strTabPageTitle As String = sender.text.ToString
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    Dim strScreenName As String = ""

        '    Select Case sender.text.ToString.Trim
        '        Case "PIA Test"
        '            strScreenName = "PIA"
        '        Case "RF Test"
        '            strScreenName = "RF"
        '        Case "Final Test"
        '            strScreenName = "Final"
        '        Case "OOBA Test"
        '            strScreenName = "OOBA"
        '    End Select

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmTest(strTabPageTitle, strScreenName.ToUpper))
        'End Sub
        'Private Sub prodHTC_MainProd_BuildBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_BuildBox.Click
        '    Const strTabPageTitle As String = "Build Box"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCBuilBox())
        'End Sub
        'Private Sub prodHTC_MainProd_ShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainProd_ShipBox.Click
        '    Const strTabPageTitle As String = "Ship Box"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCShipping())
        'End Sub

        ''reports
        'Private Sub prodHTC_MainReports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainReports.Click
        '    Const strTabPageTitle As String = "Reports"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCReports())
        'End Sub

        ''search
        'Private Sub prodHTC_MainSearch_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainSearch.Click
        '    Const strTabPageTitle As String = "HTC Search"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCSearch())
        'End Sub

        ''warehouse
        'Private Sub prodHTC_MainWarehouse_DockRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainWarehouse_DockRec.Click
        '    Const strTabPageTitle As String = "HTC Dock Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCDockRec())
        'End Sub
        'Private Sub prodHTC_MainWarehouse_PackingList_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodHTC_MainWarehouse_PackingList.Click
        '    Const strTabPageTitle As String = "Packing List"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmHTCPackingList())
        'End Sub
        ''************************
        ''END HTC SECTION
        ''************************


        ''************************
        ''Liquidity Services/DYSCERN Section
        ''************************
        'Private Sub prodDyscern_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDyscern_Admin.Click
        '    Const strTabPageTitle As String = "Liquidity Services Admin"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDyscernAdmin())
        'End Sub

        ''*******************************************
        'Private Sub prodDyscernRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDyscern_Rec.Click
        '    Const strTabPageTitle As String = "Liquidity Services Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDyscernReceiving())
        'End Sub



#End Region
#Region "UNDETERMINED MENU LOCATION"

        Private Sub prodAMDBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_DBRManifest.Click
            Const strTabPageTitle As String = "AM Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID, Data.Buisness.SkyTel.AMS_LOC_ID))
        End Sub
        Private Sub prodMessaging_AMS_MapLvl3RepReason_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_MapLvl3RepReason.Click
            Const strTabPageTitle As String = "AMS-Map Level3 Rep Reason"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Messaging.AmericanMessaging.frmAmsLevel3Map())
        End Sub
        Private Sub prodAudit_DevBillHist_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAudit_DevBillHist.Click
            Const strTabPageTitle As String = "Device Billing History"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDeviceBillingHistory())
        End Sub
        Private Sub prodQC_Codes_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodQC_Codes.Click
            Const strTabPageTitle As String = "QC Failure Codes Management"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC_Codes())
        End Sub
        Private Sub csModelTarget_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csModelTarget.Click
            Const strTabPageTitle As String = "Model Target"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmModelTarget())
        End Sub
        Private Sub csSpecialBillingDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csSpecialBillingDetails.Click
            Const strTabPageTitle As String = "Special Billing Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSpecialBillingDetails())
        End Sub
        Private Sub csCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csCompany.Click
            Const strTabPageTitle As String = "Customer"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New CustomerMaint.frmCustMaint())
        End Sub
        Private Sub csCompanySearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csCompanySearch.Click
            Const strTabPageTitle As String = "Customer Search"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New CustomerMaint.frmCustMaintSearch())
        End Sub
        Private Sub csSalesPerson_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csSalesPerson.Click
            Const strTabPageTitle As String = "Salesperson"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New CompanyAdmin.CompAdmin())
        End Sub
        Private Sub csExceptionBillItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csExceptionBillItems.Click
            Const strTabPageTitle As String = "Define Exception Bill Items"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New ExceptionBillItems.frmExceptionBillItems())
        End Sub
        Private Sub csPalletPackingSlipInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csPalletPackingSlipInfo.Click
            Const strTabPageTitle As String = "Packing Slip"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmPackingSlip())
        End Sub
        Private Sub csEditRURPriceException_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csEditRURPriceException.Click
            Const strTabPageTitle As String = "RUR Price Exception"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmRURPriceException())
        End Sub
        Private Sub invLaborLvl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles invLaborLvl.Click
            Const strTabPageTitle As String = "Labor Level"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New codes.LaborLvl())
        End Sub
        'DOCUMENTS MENU
        Private Sub mnuDocuments_WorkInstruction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuDocuments_WorkInstruction.Click
            Const strTabPageTitle As String = "Doc"
            Const strScreenName As String = "Document"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Document.frmDocumentMap())
        End Sub
        Private Sub mnuDocuments_DocLocMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuDocuments_DocLocMap.Click
            Const strTabPageTitle As String = "Doc Loc Map"
            Const strScreenName As String = "ocument Location Map"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Document.frmDocMapFileLoc())
        End Sub
        'ENGINEERING MENU
        Private Sub engManageManufCodes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles engManageManufCodes.Click
            Const strTabPageTitle As String = "Warranty Code Map"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.codes.frmManageManufCodes())
        End Sub
        Private Sub About_Click(ByVal sender As Object, ByVal e As EventArgs) Handles helpAbout.Click
            Dim win As New PSS.Gui.About.AboutWin()
            win.ShowDialog()
        End Sub
        Private Sub Search_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodSearch.Click
            Const strTabPageTitle As String = "Search"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Search.SearchWin())
        End Sub

        Private Sub prodDeviceActivity_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDeviceActivity.Click
            Const strTabPageTitle As String = "Device Activity"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDeviceActivity())
        End Sub

        Private Sub prodDeviceActivityStats_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodDeviceActivityStats.Click
            Const strTabPageTitle As String = "Device Activity Statistics"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDeviceActivityStats())
        End Sub

        Private Sub DisplayCount_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodDisplayCount.Click
            Const strTabPageTitle As String = "Display Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Search.frmCountDisplay())
        End Sub
        Private Sub ServiceInv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles invServInv.Click
            Const strTabPageTitle As String = "Service Inventory"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New ModManufWin())
        End Sub
        Private Sub PricingInv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles invPartsPrice.Click
            Const strTabPageTitle As String = "Parts/Service Pricing"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New PricingWin())
        End Sub
#End Region
#Region "REPORTS -> ADMINISTRATION"

        Private Sub rptAdminRevenue_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRev.Click
            Const strTabPageTitle As String = "Admin Revenue Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_SUMMARY))
            End If
        End Sub

        Private Sub rptAdminRevenueDetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRevDetail.Click
            Const strTabPageTitle As String = "Admin Revenue Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_DETAIL))
            End If
        End Sub

        Private Sub rptAdminAUPCustMod_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminAUPCustMod.Click
            Const strTabPageTitle As String = "Revenue AUP Summary by Customer and Model"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_RevenueAUP_ByCustMod.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_AUP_BY_CUSTOMER_AND_MODEL))
            End If
        End Sub

        Private Sub rptAdminAUPForProduced_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminAUPForProduced.Click
            Const strTabPageTitle As String = "Admin Revenue-AUP Daily Production"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_RevenueAUP_ByCustMod_DailyProduction.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_AUP_DAILY_PRODUCTION))
            End If
        End Sub

        Private Sub rptAdminRevForProduced_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRevForProduced.Click
            Const strTabPageTitle As String = "Admin Revenue Daily Production"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_Revenue_DailyProduction.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_DAILY_PRODUCTION))
            End If
        End Sub
        'added by Amazech-thanga 11.10.2021
        Private Sub rptAdminRAUpload_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRAUpload.Click
            Const strTabPageTitle As String = "Admin RA Upload/Received Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New frmRAUploadandReceivedReport(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_RAUPLOAD_RECEIVED_REPORT))
            End If
        End Sub

        Private Sub rptAdmin563RevRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdmin563RevRpt.Click
            Const strTabPageTitle As String = "563 Revenue Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New PSS.frmCompare_Consumed_AutoBilled_Revenue())
        End Sub

        Private Sub rptAdminCntLessWrty_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminCntLessWrty.Click
            Const strTabPageTitle As String = "Admin Count Less Warranty"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_CntlessWrty.rpt"))
        End Sub

        Private Sub rptAdminCycMonth_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminCycMonth.Click
            Const strTabPageTitle As String = "Admin Cycle Monthly"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_CycleMonthly.rpt"))
        End Sub

        Private Sub rptAdminCycWeek_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminCycWeek.Click
            Const strTabPageTitle As String = "Admin Cycle Weekly"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_CycleWeekly.rpt"))
        End Sub

        Private Sub rptAdminSent2Ftry_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminSent2Ftry.Click
            Const strTabPageTitle As String = "Admin Sent To Factory"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_SentFactory.rpt"))
        End Sub

        Private Sub rptAdminWIP_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminWIP.Click
            Const strTabPageTitle As String = "Admin WIP"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_WIP.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_WIP))
            End If
        End Sub

        Private Sub rptAdminWIPDetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminWIPDetail.Click
            Const strTabPageTitle As String = "Admin WIP Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_WIPDetail.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_WIP_DETAIL))
            End If
        End Sub
        Private Sub rptWIPStatusReport_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptWIPStatusReport.Click
            Const strTabPageTitle As String = "WIP Status Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_WIPDetail.rpt"))
                'OpenWin(strTabPageTitle, win, New frmWipStatusReport())
            End If
        End Sub

        Public Sub rptAdminWIPDetailByLocation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptAdminWIPDetailByLocation.Click
            Const strTabPageTitle As String = "WIP Detail by Location"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New frmWIPReports())
                OpenWin(strTabPageTitle, win, New WIP.frmWIPReports_1())
            End If
        End Sub
        Public Sub rptMessagingWIPByCustomerAndModel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptMessagingWIPByCustomerAndModel.Click
            Const strTabPageTitle As String = "Messaging WIP by Customer and Model"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Messaging WIP by Customer and Model.rpt"))
        End Sub
        Private Sub rptAdminAUP_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminAUP.Click
            Const strTabPageTitle As String = "Admin Average Unit Price"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_AUP.rpt"))
        End Sub
        Private Sub rptAdminCustLocAdd_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminCustLocAdd.Click
            ' Open the report directly from here since no input parameters are needed.
            Const strTabPageTitle As String = "Admin Customer Locations"
            Dim win As Crownwood.Magic.Controls.TabPage
            Dim objCrystalReports As PSS.Data.CrystalReports

            'If Not CheckOpenTabs(strTabPageTitle) Then
            '    OpenWin(strTabPageTitle, win, New RptViewer("Admin_LocAdd.rpt"))
            'End If

            If Not CheckOpenTabs(strTabPageTitle & " Report") Then
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False

                objCrystalReports = New PSS.Data.CrystalReports(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_CUSTOMER_LOCATIONS)

                win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle & " Report", New RptViewer(strTabPageTitle & " Push.rpt", objCrystalReports.GetReportData(), objCrystalReports.GetSubReportNames()))
                MainWin.wrkArea.TabPages.Add(win)
                win.Selected = True

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If
        End Sub
        Private Sub rptAdminRURcnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminRURcnt.Click
            Const strTabPageTitle As String = "Admin Location RUR Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_LocationRURcnt.rpt"))
        End Sub
        Private Sub rptAdminBilledNotShipped_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminBilledNotShipped.Click
            Const strTabPageTitle As String = "Admin Billed Not Shipped"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_Billed_not_Shipped.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_BILLED_NOT_SHIPPED))
            End If
        End Sub
        Private Sub rptAdminCustPartsCount_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminCustPartsCount.Click
            Const strTabPageTitle As String = "Admin Customer Parts Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_Cust_Parts_Cnt.rpt"))
        End Sub
        Private Sub rptAdminMotoBatchRecon_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminMotoBatchRecon.Click
            Const strTabPageTitle As String = "Motorola-NSC Batch Claim Reconciliation"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("MotoNSCBatchRecon_Accepted.rpt"))
        End Sub
        Private Sub rptAdminDBRDuplicate_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminDBRDuplicate.Click
            Const strTabPageTitle As String = "Admin DBR Duplicate"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_DBRDuplicate.rpt"))
        End Sub
        Private Sub rptAdminMotoWrtyCount_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminMotoWrtyCount.Click
            Const strTabPageTitle As String = "Admin Motorola Warranty Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_MotoWrty_Count.rpt"))
        End Sub
        Private Sub rptAdminSpecialBT_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminSpecialBT.Click
            Const strTabPageTitle As String = "Admin Special BT"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_Special_BT.rpt"))
        End Sub
        Private Sub rptAdminOpsSumWkly_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminOpsSumWkly.Click
            Const strTabPageTitle As String = "Admin Ops Sum Weekly"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_Ops_Sum_Wkly.rpt"))
        End Sub
        Private Sub rptAdminDeviceCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminDeviceCnt.Click
            Const strTabPageTitle As String = "Admin Device Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_DeviceCnt.rpt"))
        End Sub
        Private Sub rptAdminMessagingProductWIP_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminMessagingProductWIP.Click
            Const strTabPageTitle As String = "Messaging Product WIP"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Admin_DeviceCnt.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.MESSAGING_PRODUCT_WIP))
            End If
        End Sub
        '***************************
        'REPORT-> EXCEL OUTPUT 
        '***************************
        Private Sub rptEO_EGR_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptEO_EGR.Click
            Const strTabPageTitle As String = "Excel Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmGenRptCriteria())
        End Sub
        Private Sub rptRURRTMCheck_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptRURRTMCheck.Click
            Const strTabPageTitle As String = "RUR/RTM Check"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmRURRTMCheck())
        End Sub
        Private Sub rptAdminWCDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptAdminWCDetail.Click
            Const strTabPageTitle As String = "Work Center Reports"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmExcel())
        End Sub
        Private Sub rptAdminQC_Pretst_CC_Rpt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptAdminQCRpt.Click, rptAdminPretestRpt.Click, rptAdminCostCenterRpt.Click, rptAdminQR_Rpt.Click, rptAdminRepRefRURRpt.Click, rptAdminRF_Rpt.Click, rptAdminSWRefTestResult_Rpt.Click
            'Const strTabPageTitle As String = "QC Reports"
            Dim strTabPageTitle As String = sender.text.ToString
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmQCReports(strTabPageTitle))
        End Sub
        Private Sub rptAdminRH_Rpt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptAdminRH_Rpt.Click, rptAdminPretQCH_Rpt.Click
            Dim strTabPageTitle As String = ""
            Dim win As Crownwood.Magic.Controls.TabPage
            Dim strTitle As String = ""

            If sender.text.ToString = "Repair History Report" Then
                strTabPageTitle = "RH Reports"
                strTitle = "Repair History Report"
            ElseIf sender.text.ToString = "Pretest/QC History Report" Then
                strTabPageTitle = "Pre/QC History Rpt"
                strTitle = "Pretest/QC History Report"
            End If

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmRepairHistoryRpt(strTitle))
        End Sub

#End Region
#Region "UNDETERMINED MENU LOCATION"
        Private Sub rptWeeklyDevices_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptWeeklyDevices.Click
            Const strTabPageTitle As String = "Admin Weekly Devices"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_WeeklyDevices.rpt"))
        End Sub

        Private Sub rptDupSerial_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptDupSerial.Click
            Const strTabPageTitle As String = "Admin Duplicate Serial Number"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_DupSerial.rpt"))
        End Sub

        Private Sub rptBillEmpCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptBillEmpCnt.Click
            Const strTabPageTitle As String = "Bill Employee Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.BILL_EMPLOYEE_COUNT))
            End If
        End Sub
#End Region
#Region "REPORTS -> FINANCE"

        Private Sub rptFinInvCCrd_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinInvCCrd.Click
            Const strTabPageTitle As String = "Admin Duplicate Serial Number"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Bill_EmplCnt.rpt"))
        End Sub

        Private Sub rptFinInvDetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinInvDetail.Click
            Const strTabPageTitle As String = "Finance Invoice Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_InvoiceDetail.rpt"))
        End Sub

        Private Sub rptFinInvManifCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinInvManifCnt.Click
            Const strTabPageTitle As String = "Finance Invoice by Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_Invoice_ManifCnt.rpt"))
        End Sub

        Private Sub rptFinTwoWayRevenue_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinTwoWayRevenue.Click
            Const strTabPageTitle As String = "Finance Two-Way Revenue"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_TwoWay_Revenue.rpt"))
        End Sub

        Private Sub rptAdminOpsSumm_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAdminOpsSumm.Click
            Const strTabPageTitle As String = "Admin Operations Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Admin_Ops_Sum.rpt"))
        End Sub

        Private Sub rptFinCCrdRecon_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinCCrdRecon.Click
            Const strTabPageTitle As String = "Credit Card Reconciliation"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_ReconCrCD.rpt"))
        End Sub

        Private Sub rptFinEmplWCCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinEmplWCCnt.Click
            Const strTabPageTitle As String = "Employee WC Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Finance_EmplWCCnt.rpt"))
        End Sub

        Private Sub rptFinWCHrsCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinWCHrsCnt.Click
            Const strTabPageTitle As String = "WC Hours Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Finance_WCHrsCnt.rpt"))
        End Sub

        Private Sub rptFinDeviceCNt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinDeviceCnt.Click
            Const strTabPageTitle As String = "Finance Device Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_DeviceCnt.rpt"))
        End Sub

        Private Sub rptFinPallettInvoice_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinPallettInvoice.Click
            Const strTabPageTitle As String = "Pallett Invoice"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_Pallett Invoice Report.rpt"))
        End Sub

        Private Sub rptFinWHStatusDetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinWHStatusDetail.Click
            Const strTabPageTitle As String = "WorkHours Status Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_WorkHours_Status_Detail.rpt"))
        End Sub

        Private Sub rptFinWHStatusSummary_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinWHStatusSummary.Click
            Const strTabPageTitle As String = "WorkHours Status Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_WorkHours_Status_Summary.rpt"))
        End Sub

        Private Sub rptFinBatchRecon_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinBatchRecon.Click
            Const strTabPageTitle As String = "Batch Reconciliation"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Finance_MotoRec.rpt"))
        End Sub

        Private Sub rptFinBatchRejects_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinBatchRejects.Click
            Const strTabPageTitle As String = "Batch Rejects"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_BatchRejects.rpt"))
        End Sub

        Private Sub rptFinReconStatus_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptFinReconStatus.Click
            Const strTabPageTitle As String = "Reconciliation Status"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Fin_ReconStatus.rpt"))
        End Sub

        Private Sub smFinance_NavReports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles smFinance_NavReports.Click
            Const strTabPageTitle As String = "Navision Reports"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmNavisionReports())
        End Sub

#End Region
#Region "REPORTS -> INVENTORY"

        Private Sub rptPartsB2Idetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptPartsB2IDetail.Click
            Const strTabPageTitle As String = "Parts Billed to Issued Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_BilledIssued_Detail.rpt"))
        End Sub

        Private Sub rptPartsB2Isumm_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptPartsB2ISumm.Click
            Const strTabPageTitle As String = "Parts Billed to Issued Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_BilledIssued_Sum.rpt"))
        End Sub

        Private Sub rptPartsAnalysis_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptPartsAnalysis.Click
            Const strTabPageTitle As String = "Parts Analysis"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_PartsAnalysis.rpt"))
        End Sub

        Private Sub rptPartsCount_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptPartsCount.Click
            Const strTabPageTitle As String = "Parts Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_PartsCnt.rpt"))
        End Sub

        Private Sub rptScrapsCount_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptScrapsCount.Click
            Const strTabPageTitle As String = "Scrap Quantity"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Scrap Quantity.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.INVENTORY_SCRAP_QUANTITY))
            End If
        End Sub

        Private Sub rptShopFloorQtyReport_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptShopFloorQtyReport.Click
            Const strTabPageTitle As String = "Shop Floor Quantity Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False

                OpenWin(strTabPageTitle, win, New Inventory.frmSHopFloorOnHandRpt())

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If
        End Sub

        Private Sub rptPartsMappedAnalysis_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptPartsMappedAnalysis.Click
            Const strTabPageTitle As String = "Mapped Parts Analysis"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Mapped Parts Analysis.rpt"))
        End Sub

        Private Sub rptInvModelMap_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptInvModelMap.Click
            Const strTabPageTitle As String = "Inventory Model Mapping"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_Model_Mapping.rpt"))
        End Sub

        Private Sub rptPartsAndBillCodesByModel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptPartsAndBillCodesByModel.Click
            Const strTabPageTitle As String = "Parts and Bill Codes by Model"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Parts and Bill Codes by Model.rpt"))
        End Sub

        Private Sub rptBilledIssuedCell_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptBilledIssuedCell.Click
            Const strTabPageTitle As String = "Inventory Billed Issued Cell"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_BilledIssued_Cell.rpt"))
        End Sub

        Private Sub invUsageSummary_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invUsageSummary.Click
            Const strTabPageTitle As String = "Inventory Usage Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_Usage_Summary.rpt"))
        End Sub

        'invAwaitingParts
        Private Sub invAwaitingParts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invAwaitingParts.Click
            Const strTabPageTitle As String = "Inventory Awaiting Parts"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_AwaitingParts.rpt"))
        End Sub

        'invBenchCycleCountVarReport
        Private Sub invBenchCycleCountVarReport_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invBenchCycleCountVarReport.Click
            Const strTabPageTitle As String = "Bench Cycle Count Variance Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_CycleCount.rpt"))
        End Sub

        'invAvailableForProdSumRpt
        Private Sub invAvailableForProdSumRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invAvailableForProdSumRpt.Click
            Const strTabPageTitle As String = "Available for Production - Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAvailForProdRpt())
        End Sub
        'Report->Inventory->Cogs Reports
        Private Sub invCogsRpts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invCogsRpts.Click
            Const strTabPageTitle As String = "Cogs Reports"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmGenRptCriteria("Cogs Reports", ReportViewer.frmGenRptCriteria.InputValType.VisibleRequired, , , , ))
        End Sub
        'Report->Inventory->Part Comsumption
        Private Sub rptInvPartsConsumption_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptInvPartsConsumption.Click
            Const strTabPageTitle As String = "Part Consumption by Date Range"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmGenRptCriteria("Part Consumption by Date Range", ReportViewer.frmGenRptCriteria.InputValType.VisibleRequired, ReportViewer.frmGenRptCriteria.InputValType.VisibleRequired, , , ))
        End Sub

        Private Sub invBilledIssuedCellDetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invBillIssueCellDetail.Click
            Const strTabPageTitle As String = "Inventory Billed Issued Cell Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_BilledIssued_CellDetail.rpt"))
        End Sub

        Private Sub invReceiptSummary_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles invReceiptSummary.Click
            Const strTabPageTitle As String = "Inventory Receipt Summary"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_Receipt_Summary.rpt"))
        End Sub

#End Region
#Region "REPORTS -> HUMAN RESOURCES"

        '***************************
        'Human Resource 
        '***************************
        Private Sub hrLegiantEEData_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrLegiantEEData.Click
            Const strTabPageTitle As String = "EE Data"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.HR.frmLegiantEEData())
        End Sub
        Private Sub hrIncentiveData_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrIncentiveData.Click
            Const strTabPageTitle As String = "PID Data"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.HR.frmIncentiveData())
        End Sub

#End Region
#Region "REPORTS -> QUALITY CONTROL"

        ''smQualityControl QCTechFailureRate
        Private Sub QCTechFailureRate_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles QCTechFailureRate.Click
            Const strTabPageTitle As String = "Technician Failure Rate"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.TECHNICIAN_FAILURE_RATE))
            End If
        End Sub

#End Region
#Region "UNDETERMINED MENU LOCATION"
        Private Sub rptNonMappedCellParts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptNonMappedCellParts.Click
            Const strTabPageTitle As String = "Inventory Non Mapped Cell Parts"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Inventory_Non_Mapped_Cell_Parts.rpt"))
        End Sub

        'rptProdRcvdDevCntByCust
        Private Sub rptProdRcvdDevCntByCust_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptProdRcvdDevCntByCust.Click
            Const strTabPageTitle As String = "Production Received Device Count by Customer"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.PRODUCTION_RECEIVED_QTY_BY_CUST))
            End If
        End Sub
#End Region
#Region "REPORTS -> RECEIVING"

        Private Sub rptRecCntDly_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecCntDly.Click
            Const strTabPageTitle As String = "Receiving Count Daily"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Rec_CntDaily.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.RECEIVING_COUNT_DAILY))
            End If
        End Sub

        Private Sub rptRecCntDly2Lvl_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecCntDly2Lvl.Click
            Const strTabPageTitle As String = "Receiving Count Daily Extended Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Rec_CntDaily_2lvls.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.RECEIVING_COUNT_DAILY_EXTENDED_DETAIL))
            End If
        End Sub

        Private Sub rptRecCntMnthly2Lvl_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecCntMnthly2Lvl.Click
            Const strTabPageTitle As String = "Receiving Count Monthly Extended Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Rec_CntMonthly_2lvls.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.RECEIVING_COUNT_MONTHLY_EXTENDED_DETAIL))
            End If
        End Sub

        Private Sub rptRecCntDlyMWrty_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecCntDlyMWrty.Click
            Const strTabPageTitle As String = "Receiving Count Daily MWrty"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Rec_CntDaily_MWrty.rpt"))
        End Sub

        Private Sub rptRecCntMonth_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecCntMonth.Click
            Const strTabPageTitle As String = "Receiving Count Monthly"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Rec_CntMonthly.rpt"))
        End Sub

        Private Sub rptRecEmpCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecEmpCnt.Click
            Const strTabPageTitle As String = "Receiving Employee Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Rec_EmplCnt.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.RECEIVING_EMPLOYEE_COUNT))
            End If
        End Sub

        Private Sub rptRecDetail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecDetail.Click
            Const strTabPageTitle As String = "Receiving Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Rec_Detail.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.RECEIVING_DETAIL))
            End If
        End Sub

        Private Sub rptRecCntDailyStaged_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecCntDailyStaged.Click
            Const strTabPageTitle As String = "Receiving Count Daily Staged"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Rec_CntDaily_Staged.rpt"))
        End Sub

        Private Sub rptRecAmericanMessStagedNotRcvd_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecAmericanMessStagedNotRcvd.Click
            ' Open the report directly from here since no input parameters are needed.
            Const strTabPageTitle As String = "American Messaging Staged But Not Received"
            Dim win As Crownwood.Magic.Controls.TabPage
            Dim objCrystalReports As PSS.Data.CrystalReports

            If Not CheckOpenTabs(strTabPageTitle & " Report") Then
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False

                'OpenWin(strTabPageTitle, win, New RptViewer("AMERICAN MESSAGING STAGED BUT NOT RECEIVED.rpt"))
                objCrystalReports = New PSS.Data.CrystalReports(strTabPageTitle, Data.CrystalReports.Report_Call.AMERICAN_MESSAGING_STAGED_BUT_NOT_RECEIVED)

                'win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle & " Report", New RptViewer(strTabPageTitle & " Push.rpt", New String() {"American Messaging Staged But Not Received Push.rpt"}, objCrystalReports.GetReportData()))
                win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle & " Report", New RptViewer(strTabPageTitle & " Push.rpt", objCrystalReports.GetReportData(), objCrystalReports.GetSubReportNames()))
                MainWin.wrkArea.TabPages.Add(win)
                win.Selected = True

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If
        End Sub

        Private Sub rptRecAmericanMessWIP_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptRecAmericanMessWIP.Click
            ' Open the report directly from here since no input parameters are needed.
            Const strTabPageTitle As String = "American Messaging WIP"
            Dim win As Crownwood.Magic.Controls.TabPage
            Dim objCrystalReports As PSS.Data.CrystalReports

            If Not CheckOpenTabs(strTabPageTitle & " Report") Then
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False

                'OpenWin(strTabPageTitle, win, New RptViewer("American Messaging WIP Report.rpt"))
                objCrystalReports = New PSS.Data.CrystalReports(strTabPageTitle, Data.CrystalReports.Report_Call.AMERICAN_MESSAGING_WIP)

                win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle & " Report", New RptViewer(strTabPageTitle & " Push.rpt", objCrystalReports.GetReportData(), objCrystalReports.GetSubReportNames()))
                MainWin.wrkArea.TabPages.Add(win)
                win.Selected = True

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If
        End Sub

#End Region
#Region "UNDETERMINED MENU LOCATION"
        Private Sub rptVerExc_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptVerExc.Click
            Const strTabPageTitle As String = "Receiving Verizon Exception"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Rec_VerizonException.rpt"))
        End Sub

        ''rptCellLineProd
        Private Sub rptCellLineProd_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptCellLineProd.Click
            Const strTabPageTitle As String = "Cell Line Production Parameters"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Cell Line Production.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.CELL_LINE_PRODUCTION))
            End If
        End Sub

        'rptTechRefurbQtyRpt
        Private Sub rptTechRefurbQtyRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptTechRefurbQtyRpt.Click
            Const strTabPageTitle As String = "Technician Refurb Qty Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Technician Refurb Qty Report.rpt"))
        End Sub

        'rptMessLblProdRpt
        Private Sub rptMessLblProdRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptMessLblProdRpt.Click
            Const strTabPageTitle As String = "Messaging Label Production Report"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Messaging Label Production.rpt"))
        End Sub

        'rptSNsByRcvedPalletRpt
        Private Sub rptSNsByRcvedPalletRpt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptSNsByRcvedPalletRpt.Click
            Const strTabPageTitle As String = "Print SNs by Received Pallet Name"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("SNs by Received Pallet.rpt"))
        End Sub

        ''rptCellProdSummary
        Private Sub rptCellProdSummary_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptCellProdSummary.Click
            Const strTabPageTitle As String = "Cell Production Summary Parameters"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Cell Production Summary.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.CELL_PRODUCTION_SUMMARY))
            End If
        End Sub

        'rptShipDevQtyByShipType
        Private Sub rptShipDevQtyByShipType_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptShipDevQtyByShipType.Click
            Const strTabPageTitle As String = "Shipped Device Quantity by Ship Type"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Shipped Device Qty by Ship Type.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.SHIPPING_SHIPPED_DEVICE_QTY_BY_SHIP_TYPE))
            End If
        End Sub

        Private Sub rptWHPalletsNotRcvd_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptWHPalletsNotRcvd.Click
            Const strTabPageTitle As String = "Warehouse Pallets not Received into Prod WIP"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Warehouse Pallets not Received in to Prod WIP.rpt"))
        End Sub

        Private Sub rptCellShippedPallets_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptCellShippedPallets.Click
            Const strTabPageTitle As String = "Cell Shipped Pallets"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Cell Shipped Pallets.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.CELL_SHIPPED_PALLETS))
            End If
        End Sub

        Private Sub rptAllSNsShippedOnDateForCust_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAllSNsShippedOnDateForCust.Click
            Const strTabPageTitle As String = "All SNs Shipped on a Date for a Customer"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("All SNs Shipped on a Date for a Customer.rpt"))
        End Sub

        Private Sub rptShipCntDly_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptShipCntDly.Click
            Const strTabPageTitle As String = "Shipping Count Daily"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Ship_CntDaily.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.SHIPPING_COUNT_DAILY))
            End If
        End Sub

        Private Sub rptShipCntDly2lvl_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptShipCntDly2Lvl.Click
            Const strTabPageTitle As String = "Shipping Count Daily Extended Detail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Ship_CntDaily_2Lvls.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.SHIPPING_COUNT_DAILY_EXTENDED_DETAIL))
            End If
        End Sub

        Private Sub rptShipEmpCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptShipEmpCnt.Click
            Const strTabPageTitle As String = "Shipping Employee Count"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("Ship_EmplCnt.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.SHIPPING_EMPLOYEE_COUNT))
            End If
        End Sub

        Private Sub rptShipRLRMASum_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptShipRLRMASum.Click
            Const strTabPageTitle As String = "Shipping RL RMA Sum"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Ship_RL_RMASum.rpt"))
        End Sub

        Private Sub rptATCLEPassFail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptATCLEPassFail.Click
            Const strTabPageTitle As String = "ATCLE Pass-Fail"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.SHIPPING_ATCLE_PASS_FAIL))
            End If
        End Sub

        Private Sub rptAmericanMessagingShipDemand_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptAmericanMessagingShipDemand.Click
            Const strTabPageTitle As String = "American Messaging Ship Demand"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.AMERICAN_MESSAGING_SHIP_DEMAND))
            End If
        End Sub

        Private Sub rptMotoWrty_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles rptMotoWrty.Click
            Dim r As New MotoAscWrty.MotoAsc()
            r.ShowDialog()
        End Sub

        Private Sub invASCPrice_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invASCPrice.Click
            Const strTabPageTitle As String = "ASC Price"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New codes.ASCPriceCodes())
        End Sub

        Private Sub invBillCodes_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invBillCodes.Click
            Const strTabPageTitle As String = "Bill Codes"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New BillCodeWin())
        End Sub

        Private Sub invFailCodes_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invFailCodes.Click
            Const strTabPageTitle As String = "Fail Codes"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New codes.FailCodes())
        End Sub

        Private Sub invRepairCodes_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invRepairCodes.Click
            Const strTabPageTitle As String = "Repair Codes"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New codes.RepairCodes())
        End Sub

        Private Sub invPartsMap_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invPartsMap.Click
            Const strTabPageTitle As String = "Parts Mapping"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New PartsMapWin())
        End Sub
        Private Sub invPartsSNCapture_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invPartsSNCapture.Click
            Const strTabPageTitle As String = "Parts SN Capture"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmPartSNCapture())
        End Sub

        Private Sub invInactivateBillCodes_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invInactivateBillCodes.Click
            Const strTabPageTitle As String = "Inactivate Bill Codes"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.HideBillCodes.frmHideBillCodes())
        End Sub

        Private Sub invInactivateBillCodesC_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invInactivateBillCodesC.Click
            Const strTabPageTitle As String = "Inactivate Bill Codes by Customer"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.HideBillCodesCustomer.frmHideBillCodesCustomer())
        End Sub

        Private Sub invCreateBillGroups_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invCreateBillGroups.Click
            Const strTabPageTitle As String = "Create Bill Groups"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmBillGroups())
        End Sub

        Private Sub invBillGroupAdmin_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invBillGroupAdmin.Click
            Const strTabPageTitle As String = "Bill Group Admin"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmBillGroupsAdmin())
        End Sub

        ' 'invPartsRelated As New MenuCommand("Parts-Related")
        Private Sub invPartsRelated_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles invPartsRelated.Click
            Const strTabPageTitle As String = "Parts-Related"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmPartRelated())
        End Sub
#End Region

#End Region
    End Class
End Namespace
