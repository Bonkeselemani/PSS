Imports System.Windows.Forms
Imports Crownwood.Magic.Menus

Imports PSS.Core.[Global]
Imports PSS.Gui
Imports PSS.Data.Buisness.Security
Imports PSS.Misc

Namespace Gui.MainWin

    Public Class Menu
        Inherits Crownwood.Magic.Menus.MenuControl

        'frmReadyToTransfer.vb

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
        'Friend WithEvents admRec As New MenuCommand("Admini&stration Functions", Shortcut.CtrlA)
        'Friend WithEvents admFunc As New MenuCommand("&Administration Functions")
        Friend WithEvents admMenu_Cellular As New MenuCommand("Cellular")
        Friend WithEvents admMenu_Messaging As New MenuCommand("Messaging")
        Friend WithEvents admMenu_SP As New MenuCommand("Special Processes")
        Friend WithEvents admMenu_SP_UpdateAvgPartsCostGoal As New MenuCommand("Update Average Parts Cost Goal")
        Friend WithEvents admMenu_IncentivePrgData As New MenuCommand("Productivity Incentive Data")

        'Friend WithEvents admFunc_Messaging As New MenuCommand("Messaging", Shortcut.CtrlA)

        Friend WithEvents admFunc_Messaging As New MenuCommand("Edit Messaging")
        Friend WithEvents admFunc_EditSKU As New MenuCommand("Edit SKU (MSG)")
        Friend WithEvents admFunc_MoveTray As New MenuCommand("Assign Tray to another line")

        ''*****************************************
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        ''*****************************************
        'Friend WithEvents admFunc_Cellular As New MenuCommand("Cellular", Shortcut.CtrlC)
        'Friend WithEvents admFunc_EditFreq As New MenuCommand("Edit Frequency")
        'Friend WithEvents admFunc_Cellular As New MenuCommand("Edit Cellular")
        'Friend WithEvents admShipLocChange As New MenuCommand("Shipping Location Change")
        ''*****************************************

        Friend WithEvents admFunc_EditBillMap As New MenuCommand("Edit Bill Map")
        Friend WithEvents admFunc_WOdata As New MenuCommand("Workorder Lookup - COUNTS")

        Friend WithEvents admFunc_CellTrayAdmin As New MenuCommand("Cellular Tray Administration")

        Friend WithEvents admSecurity As New MenuCommand("Security")
        Friend WithEvents admCellWrty As New MenuCommand("Cell Warranty")
        Friend WithEvents admDefineRMA As New MenuCommand("Define RMA Defaults")
        Friend WithEvents admSPAddSJUG As New MenuCommand("Add Motorola SJUG Number")
        Friend WithEvents admSPAddSofVer As New MenuCommand("Add Motorola Software Version")

        Friend WithEvents admSPconsumption As New MenuCommand("Create Part Consumption File")

        Friend WithEvents admChangeSN As New MenuCommand("Change SN")
        Friend WithEvents admChangeModel As New MenuCommand("Change Model")
        Friend WithEvents admDockRec As New MenuCommand("Dock Receive")

        Friend WithEvents admDSCPalletBuild As New MenuCommand("Discrepant Pallet Build")

        ''********************************************
        ''Commented by Lan 10/31/2007 INACTIVE SCREEN
        'BRIGHT POINT CUSTOMER
        ''********************************************
        'Friend WithEvents rptCellstarDailyShippingManifest As New MenuCommand("Brightpoint Daily Shipping Manifest")
        'Friend WithEvents rptRecBrightpointReceivedDev As New MenuCommand("Brightpoint Received Devices")
        'Friend WithEvents rptAdminRevDetailCellstar As New MenuCommand("Admin Revenue Detail Brightpoint AB")
        'Friend WithEvents prodBrightpointOpts As New MenuCommand("Brightpoint Operations")
        'Friend WithEvents admBrightpointPartNumUpdate As New MenuCommand("Brightpoint Part Number Update")
        'Friend WithEvents rptAdminRevCellstar As New MenuCommand("Admin Revenue Summary Brightpoint AB")
        'Friend WithEvents admBrightpoint As New MenuCommand("Brightpoint XML Administration")
        ''Friend WithEvents admResendBrightpointXMLFiles As New MenuCommand("Resend Brightpoint XML Files")
        'Friend WithEvents admAssignAwaitParts As New MenuCommand("Warehouse Assign Awaiting Parts")
        ''********************************************

        Friend WithEvents admWFadmin As New MenuCommand("Weight Factor Administration")
        Friend WithEvents admContBilladmin As New MenuCommand("Contingent Billing Administration")

        Friend WithEvents admBillcodeConsumption As New MenuCommand("Billcode Consumption (Individual)")
        Friend WithEvents admNEWrec As New MenuCommand("NEW REC SCREEN TESTING")

        Friend WithEvents admValidateRejects As New MenuCommand("Validate ATCLE Rejects")
        'Friend WithEvents prodTechTools As New MenuCommand("Cell Tray Assignment")
        Friend WithEvents prodCreatePSSISNs As New MenuCommand("Create PSSI Serial Numbers")
        'Friend WithEvents admLogicTray As New MenuCommand("Logic Tray Administration")

        'COST CENTER MAIN MENU
        Friend WithEvents prodCCMain As New MenuCommand("Cost Center")
        Friend WithEvents prodCC_TimeTracking As New MenuCommand("Cost Center Time Tracking")
        Friend WithEvents prodCC_ScanDevToCC As New MenuCommand("Scan Devices into Cost Center")
        Friend WithEvents prodCC_SetUPH As New MenuCommand("Set UPH")

        '// system menus
        Friend WithEvents sysSecurity As New MenuCommand("Se&curity")
        Friend WithEvents sysInfo As New MenuCommand("System &Information")
        Friend WithEvents sysWCL As New MenuCommand("Work Center &Locations")

        '// customer service menus

        ''********************************************
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents csCompanyAddress As New MenuCommand("Company Address")
        ''********************************************

        Friend WithEvents csCompany As New MenuCommand("Customer Info")
        Friend WithEvents csCustCompany As New MenuCommand("Customer Information")

        Friend WithEvents csCompanySearch As New MenuCommand("Customer Search Info")
        Friend WithEvents csOrderEntry As New MenuCommand("Order Entry")
        Friend WithEvents csModelTarget As New MenuCommand("Set Model Target")
        Friend WithEvents csSpecialBillingDetails As New MenuCommand("Special Billing Detail")
        ''********************************************M-CLAIM
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents csMClaims As New MenuCommand("M-Claims")
        'Friend WithEvents csEditASCClaims As New MenuCommand("Edit ASC Claims")
        'Friend WithEvents csEditSubClaims As New MenuCommand("Edit SUB Claims")
        'Friend WithEvents csMclaimsReconciliation As New MenuCommand("Load Claim Batch Analysis Data")
        ''********************************************
        Friend WithEvents csSalesPerson As New MenuCommand("SalesPerson Info")
        Friend WithEvents csWOPreload As New MenuCommand("Workorder Preload Info")
        ''********************************************CUSTOMER SERVICES
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents csWOPreloadCamera As New MenuCommand("Workorder Preload Camera Info")
        'Friend WithEvents csWOPreloadCamera35 As New MenuCommand("Workorder Preload 35 mm Camera Info")
        'Friend WithEvents csWOPreloadUSAMobility As New MenuCommand("Workorder Preload USA Mobility")
        ''********************************************
        Friend WithEvents csExceptionBillItems As New MenuCommand("Define Exception Bill Items")
        Friend WithEvents csPalletPackingSlipInfo As New MenuCommand("Packing Slip Info")
        Friend WithEvents csEditRURPriceException As New MenuCommand("RUR Price Exception")

        '***************************
        'Report => Human Resource 
        '***************************
        'Friend WithEvents hrLeaveCnt As New MenuCommand("HR Leave Count")
        'Friend WithEvents hrLeave As New MenuCommand("HR Leave")
        'Friend WithEvents hrWorkHours As New MenuCommand("HR Work Hours")

        '***************************
        'Human Resource => Human Resource 
        '***************************
        Friend WithEvents hrLegiantEEData As New MenuCommand("Employee Data")
        Friend WithEvents hrIncentiveData As New MenuCommand("Incentive Data")

        '// Quality Control Menus
        Friend WithEvents QCTechFailureRate As New MenuCommand("Technician Failure Rate")

        '// inventory menus
        Friend WithEvents invASCPrice As New MenuCommand("&ASC Price")
        Friend WithEvents invBillCodes As New MenuCommand("&Bill Codes")
        Friend WithEvents invFailCodes As New MenuCommand("&Fail Codes")
        Friend WithEvents invLaborLvl As New MenuCommand("Labor Level Info")
        Friend WithEvents invRepairCodes As New MenuCommand("&Repair Codes")
        Friend WithEvents invServInv As New MenuCommand("&Service Inventory")
        Friend WithEvents invPartsPrice As New MenuCommand("&Parts / Service Pricing")
        Friend WithEvents invPartsMap As New MenuCommand("&Parts Mapping")
        Friend WithEvents invBillIssueCellDetail As New MenuCommand("Billed/Issued Cell Detail")
        Friend WithEvents invReceiptSummary As New MenuCommand("Receipt Summary")
        Friend WithEvents invUsageSummary As New MenuCommand("Usage Summary")
        Friend WithEvents invAwaitingParts As New MenuCommand("Awaiting Parts")
        Friend WithEvents invBenchCycleCountVarReport As New MenuCommand("Bench Cycle Count Variance Report")
        Friend WithEvents invAvailableForProdSumRpt As New MenuCommand("Available for Production - Summary")
        Friend WithEvents invCogsRpts As New MenuCommand("Cogs Reports")
        Friend WithEvents invInactivateBillCodes As New MenuCommand("Inactivate Bill Codes")
        Friend WithEvents invInactivateBillCodesC As New MenuCommand("Inactivate Bill Codes by Customer")
        Friend WithEvents invCreateBillGroups As New MenuCommand("Create Bill Groups")
        Friend WithEvents invBillGroupAdmin As New MenuCommand("Bill Group Admin")
        Friend WithEvents invPartsRelated As New MenuCommand("Parts-Related")
        'invCreateBillGroups As New MenuCommand("Create Bill Groups")

        '// production menus
        'Friend WithEvents prodBetterSearch As New MenuCommand("New Search Engine", Shortcut.CtrlS)
        Friend WithEvents prodSearch As New MenuCommand("&Search", Shortcut.CtrlS)
        'Friend WithEvents prodCellSearch As New MenuCommand("Cell Search")
        Friend WithEvents prodDisplayCount As New MenuCommand("Line Counts")

        ''*****************************************
        ''Comment by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents prodMachineModelMap As New MenuCommand("Assign Models to Machines")
        ''*****************************************

        ''*****************************************
        ''Comment by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents prodStageRMA As New MenuCommand("Staging-R&MA", Shortcut.CtrlM)
        ''*****************************************

        Friend WithEvents prodBulkShipping As New MenuCommand("Ship Pallets")
        ''*****************************************
        ''Comment by Lan 06/03/2008 INACTIVE SCREEN
        'Friend WithEvents prodCellShipPallet As New MenuCommand("Build ATCLE Ship Pallets")
        ''*****************************************
        Friend WithEvents prodGenericShipPallet As New MenuCommand("Build Ship Pallets")
        Friend WithEvents prodAutoShipRWPallet As New MenuCommand("Auto Build and Ship Rework Pallets")

        '******************************************
        'REFURB
        '******************************************
        Friend WithEvents prodPreBillLot As New MenuCommand("Pre-Bill Lot")
        Friend WithEvents prodRefurb As New MenuCommand("Refurb")
        Friend WithEvents prodRefurb_ProductivityTracker As New MenuCommand("Tracker")
        Friend WithEvents prodRefurb_Auditor As New MenuCommand("Auditor")

        ''*****************************************
        ''Comment by Lan 10/31/2007 INACTIVE SCREEN
        'Friend WithEvents ProdProcessFlow As New MenuCommand("Work Flow")
        ''*****************************************
        ''Comment by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents prodStageBULK As New MenuCommand("Staging-BU&LK", Shortcut.CtrlL)
        ''*****************************************

        'Friend WithEvents prodTech As New MenuCommand("&Tech Center", Shortcut.CtrlT)
        'Friend WithEvents prodTechNEW As New MenuCommand("&Tech Center")
        Friend WithEvents prodTechHS As New MenuCommand("&Tech Center High Speed")

        Friend WithEvents prodPreTest As New MenuCommand("&PreTest")

        ''*****************************************PRESTEST
        ''Comment by Lan 01/18/2007 INACTIVE SCREEN 
        'Friend WithEvents prodPreTestCamera As New MenuCommand("Pre&Test Camera")
        'Friend WithEvents prodPreTestCamera35 As New MenuCommand("PreTest 35 mm Camera")
        'Friend WithEvents prodPreTestBrightpoint As New MenuCommand("Brightpoint Triage")
        ''*****************************************
        

        ''*****************************************
        ''Comment by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents prodDisposition As New MenuCommand("&Disposition")
        ''*****************************************

        'Friend WithEvents prodHScell As New MenuCommand("&Special CELL Receiving")

        ''*****************************************
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        ''*****************************************
        'Friend WithEvents prodTrayTrans As New MenuCommand("Tra&y Transfer", Shortcut.CtrlY)
        'Friend WithEvents prodFinishedGoodsTransfer As New MenuCommand("Transfer to Finished Goods")
        ''*****************************************
        ''Commented by Lan 10/31/2007 INACTIVE SCREEN
        ''*****************************************
        'Friend WithEvents prodAwaitingParts As New MenuCommand("Awaiting Parts")
        ''*****************************************

        'Friend WithEvents prodTrayScan As New MenuCommand("End of Line Tray Scan")

        'Friend WithEvents prodMotoSubContShip As New MenuCommand("Customer Specific Shipping")

        'QUALITY CONTROL
        Friend WithEvents prodQCMain As New MenuCommand("Quality Control")
        Friend WithEvents prodQC_Codes As New MenuCommand("QC Failure Code management")
        Friend WithEvents prodQC As New MenuCommand("QC")

        'MESSAGING
        Friend WithEvents prodMessagingMain As New MenuCommand("Messaging")
        Friend WithEvents prodMessagingMain_BuildPallet As New MenuCommand("&Build Messaging Ship Pallet")
        'Friend WithEvents prodMessagingMain_Bill As New MenuCommand("&Billing", Shortcut.CtrlB)
        Friend WithEvents prodMessagingMain_Label As New MenuCommand("Label")
        Friend WithEvents prodMessagingMain_Rec As New MenuCommand("&Receiving", Shortcut.CtrlR)

        Friend WithEvents prodMessaging_AMS As New MenuCommand("American Messaging")
        Friend WithEvents prodMessaging_AMS_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessaging_AMS_DBRManifest As New MenuCommand("Build AMS DBR/Other Ship Pallet")
        Friend WithEvents prodMessaging_AMS_MapLvl3RepReason As New MenuCommand("Map Level 3 Repair Reason")
        Friend WithEvents prodMessaging_AMS_OptConsole As New MenuCommand("Operations Console")
        Friend WithEvents prodMessaging_AMS_DemandData As New MenuCommand("Product WIP Data")
        Friend WithEvents prodMessaging_AMS_ShipOld As New MenuCommand("S&hipping", Shortcut.CtrlH)
        'SkyTel  
        Friend WithEvents prodMessagingMain_SkyTel As New MenuCommand("SkyTel")
        Friend WithEvents prodMessagingMain_SkyTel_DBRManifest As New MenuCommand("Build SkyTel Other Ship Pallet")
        Friend WithEvents prodMessagingMain_SkyTel_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_SkyTel_BB As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_SkyTel_LoadASN As New MenuCommand("Load ASN Files")
        Friend WithEvents prodMessagingMain_SkyTel_Ship As New MenuCommand("Ship Box")
        Friend WithEvents prodMessagingMain_SkyTel_Rec As New MenuCommand("Receiving")

        'Morris Communication
        Friend WithEvents prodMessagingMain_MorrisCom As New MenuCommand("Morris Communication")
        Friend WithEvents prodMessagingMain_MorrisCom_DBRManifest As New MenuCommand("Build MorrisCom Other Ship Pallet")
        Friend WithEvents prodMessagingMain_MorrisCom_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_MorrisCom_BB As New MenuCommand("Build Ship Box")
        'Friend WithEvents prodMessagingMain_SkyTel_LoadASN As New MenuCommand("Load ASN Files")
        Friend WithEvents prodMessagingMain_MorrisCom_Ship As New MenuCommand("Ship Box")
        Friend WithEvents prodMessagingMain_MorrisCom_Rec As New MenuCommand("Receiving")

        'Propage
        Friend WithEvents prodMessagingMain_Propage As New MenuCommand("Propage")
        Friend WithEvents prodMessagingMain_Propage_DBRManifest As New MenuCommand("Build Propage Other Ship Pallet")
        Friend WithEvents prodMessagingMain_Propage_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_Propage_BB As New MenuCommand("Build Ship Box")
        'Friend WithEvents prodMessagingMain_SkyTel_LoadASN As New MenuCommand("Load ASN Files")
        Friend WithEvents prodMessagingMain_Propage_Ship As New MenuCommand("Ship Box")
        Friend WithEvents prodMessagingMain_Propage_Rec As New MenuCommand("Receiving")

        'Aquis
        Friend WithEvents prodMessagingMain_Aquis As New MenuCommand("Aquis")
        Friend WithEvents prodMessagingMain_Aquis_ModelSetup As New MenuCommand("Model Setup")
        Friend WithEvents prodMessagingMain_Aquis_WHRec As New MenuCommand("Warehouse Receiving")
        Friend WithEvents prodMessagingMain_Aquis_ProdRec As New MenuCommand("Production Receiving")
        Friend WithEvents prodMessagingMain_Aquis_Billing As New MenuCommand("Billing")
        Friend WithEvents prodMessagingMain_Aquis_BB As New MenuCommand("Build Ship Box")
        Friend WithEvents prodMessagingMain_Aquis_Ship As New MenuCommand("Ship Box")

        'Native Instruments
        Friend WithEvents prodNInst_Main As New MenuCommand("Native Instruments")
        Friend WithEvents prodNInst_Main_ShipReturnLabel As New MenuCommand("Ship Return Label")
        Friend WithEvents prodNInst_Main_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodNInst_Main_Triage As New MenuCommand("Triage")
        Friend WithEvents prodNInst_Main_Repair As New MenuCommand("Repair/Tech")
        Friend WithEvents prodNInst_Main_AQL As New MenuCommand("AQL")
        Friend WithEvents prodNInst_Main_Ship As New MenuCommand("Produce && Ship")
        Friend WithEvents prodNInst_Main_OBA As New MenuCommand("OBA")
        Friend WithEvents prodNInst_Main_Reports As New MenuCommand("Reports")
        Friend WithEvents prodNInst_Main_ManageActiveModels As New MenuCommand("Managing Active Model")

        'PANTECH
        Friend WithEvents prodPantechMain As New MenuCommand("Pantech")
        Friend WithEvents prodPantechMain_EndUser As New MenuCommand("EndUser")
        Friend WithEvents prodPantechMain_Jabil As New MenuCommand("Jabil")
        Friend WithEvents prodPantechMain_Label As New MenuCommand("Label")
        Friend WithEvents prodPantechMain_Admin As New MenuCommand("Admin")

        '*******************************************
        'PRODUCT => Pantech => End User
        '*******************************************

        Friend WithEvents prodPantechMain_EndUser_CustService As New MenuCommand("Customer Service")
        Friend WithEvents prodPantechMain_EndUser_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodPantechMain_EndUser_Ship As New MenuCommand("Shipping")
        Friend WithEvents prodPantechMain_EndUser_Search As New MenuCommand("Search")

        '*******************************************
        'PRODUCT => Pantech => Jabil
        '*******************************************
        Friend WithEvents prodPantechMain_Jabil_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodPantechMain_Jabil_BuildShipBox As New MenuCommand("Build Ship Box")
        Friend WithEvents prodPantechMain_Jabil_ProduceBox As New MenuCommand("Production Ship")

        'GAMING
        Friend WithEvents prodGamingMain As New MenuCommand("Gaming")
        Friend WithEvents prodGaming_GS As New MenuCommand("GameStop")
        Friend WithEvents prodGaming_GS_WHStageRec As New MenuCommand("Warehouse and Stage Receive")
        Friend WithEvents prodGaming_GS_Opts As New MenuCommand("Operations Console")

        'GENERIC PROCESS
        Friend WithEvents prodGenericProcMain As New MenuCommand("Generic Process")
        Friend WithEvents prodGenericProcMain_CreateWO As New MenuCommand("Create Work Order")
        Friend WithEvents prodGenericProcMain_BuildShipLot As New MenuCommand("Build Ship Lot")
        Friend WithEvents prodGenericProcMain_ProduceLot As New MenuCommand("Produce Lot")
        'Friend WithEvents prodGenericProcMain_ProduceSpecialLot As New MenuCommand("Produce Lot Without Serial")
        Friend WithEvents prodGenericProcMain_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodGenericProcMain_Test As New MenuCommand("Testing")
        Friend WithEvents prodGenericProcMain_Test_PreTest As New MenuCommand("Pretest")
        Friend WithEvents prodGenericProcMain_Test_QC As New MenuCommand("Quality Control")

        'GENESIS PROCESS
        Friend WithEvents prodGenesisProcMain As New MenuCommand("Genesis")
        Friend WithEvents prodGenesisProcMain_BuildShipLot As New MenuCommand("Build Ship Lot")
        Friend WithEvents prodGenesisProcMain_ProduceLot As New MenuCommand("Produce Lot")
        Friend WithEvents prodGenesisProcMain_Rec As New MenuCommand("Receiving")

#Region "HTC"
        ''HTC
        'Friend WithEvents prodHTC_Main As New MenuCommand("HTC")
        'Friend WithEvents prodHTC_MainAdmin As New MenuCommand("Admin")
        'Friend WithEvents prodHTC_MainInventory As New MenuCommand("Inventory")
        'Friend WithEvents prodHTC_MainProd As New MenuCommand("Production")
        'Friend WithEvents prodHTC_MainReports As New MenuCommand("Reports")
        'Friend WithEvents prodHTC_MainSearch As New MenuCommand("Search")
        'Friend WithEvents prodHTC_MainWarehouse As New MenuCommand("Warehouse")
        'Friend WithEvents prodHTC_MainAdmin_Admin As New MenuCommand("Admin")
        'Friend WithEvents prodHTC_MainAdmin_AdminEdit As New MenuCommand("Admin Edit Function")
        'Friend WithEvents prodHTC_MainAdmin_ProdTracking As New MenuCommand("Productivity Tracking")
        'Friend WithEvents prodHTC_MainAdmin_RMAProcessing As New MenuCommand("RMA Processing")
        'Friend WithEvents prodHTC_MainInventory_MBLabel As New MenuCommand("Create Main Board Label")
        'Friend WithEvents prodHTC_MainInventory_LCD_MainBoard_Search As New MenuCommand("LCD && Main Boarch Search")
        'Friend WithEvents prodHTC_MainInventory_LCDMBRec As New MenuCommand("LCD/MB Receiving")
        'Friend WithEvents prodHTC_MainInventory_ReclaimParts As New MenuCommand("Reclaim Parts")
        'Friend WithEvents prodHTC_MainProd_ProdRec As New MenuCommand("Production Receiving")
        'Friend WithEvents prodHTC_MainProd_Diagnosis As New MenuCommand("Diagnostic Test")
        'Friend WithEvents prodHTC_MainProd_PreBill As New MenuCommand("Pre-Bill")
        'Friend WithEvents prodHTC_MainProd_Repair As New MenuCommand("Repair")
        'Friend WithEvents prodHTC_MainProd_BillingAuditor As New MenuCommand("Billing Auditor")
        'Friend WithEvents prodHTC_MainProd_ReLabel As New MenuCommand("Relabel")
        'Friend WithEvents prodHTC_MainProd_PIA As New MenuCommand("PIA Test")
        'Friend WithEvents prodHTC_MainProd_RF As New MenuCommand("RF Test")
        'Friend WithEvents prodHTC_MainProd_Final As New MenuCommand("Final Test")
        'Friend WithEvents prodHTC_MainProd_BuildBox As New MenuCommand("Build Box")
        'Friend WithEvents prodHTC_MainProd_OOBA As New MenuCommand("OOBA Test")
        'Friend WithEvents prodHTC_MainProd_ShipBox As New MenuCommand("Ship Box")
        'Friend WithEvents prodHTC_MainWarehouse_DockRec As New MenuCommand("Dock Receiving")
        'Friend WithEvents prodHTC_MainWarehouse_PackingList As New MenuCommand("Create Packing List")
#End Region

        ''Appliance
        'Friend WithEvents prodAppliance_Main As New MenuCommand("Appliance")
        'Friend WithEvents prodAppliance_Main_Nespresso As New MenuCommand("Nespresso")
        'Friend WithEvents prodAppliance_Main_Nespresso_MgRecyleModel As New MenuCommand("Manage Recycle Model")
        'Friend WithEvents prodAppliance_Main_Nespresso_Rec As New MenuCommand("Receiving")
        'Friend WithEvents prodAppliance_Main_Nespresso_PreTest As New MenuCommand("Pre Test")
        'Friend WithEvents prodAppliance_Main_Nespresso_QC As New MenuCommand("QC")
        'Friend WithEvents prodAppliance_Main_Nespresso_PartRecovery As New MenuCommand("Parts Recovery")
        'Friend WithEvents prodAppliance_Main_Nespresso_BuildShipBox As New MenuCommand("Build Ship Box")
        'Friend WithEvents prodAppliance_Main_Nespresso_Produced As New MenuCommand("Produce")

        ''CONN'S
        'Friend WithEvents prodConns_Main As New MenuCommand("Conn's")
        'Friend WithEvents prodConns_Main_Rec As New MenuCommand("Receiving")
        'Friend WithEvents prodConns_Main_MagHigLowValModel As New MenuCommand("Manage High/Low Value Model")
        'Friend WithEvents prodConns_Main_Audit As New MenuCommand("Audit")
        'Friend WithEvents prodConns_Main_Rep As New MenuCommand("Repair")
        'Friend WithEvents prodConns_Main_Produce As New MenuCommand("Receiving")
        'Friend WithEvents prodConns_Main_FillOutBoudOrder As New MenuCommand("Fill Out Bound Order")
        'Friend WithEvents prodConns_Main_Manifest As New MenuCommand("Manifest")

        'DRIVECAM
        Friend WithEvents prodDriveCam_Main As New MenuCommand("DriveCam")
        Friend WithEvents prodDriveCam_Main_Admin As New MenuCommand("Admin")
        Friend WithEvents prodDriveCam_Main_Billing As New MenuCommand("Billing")
        Friend WithEvents prodDriveCam_Main_BSB As New MenuCommand("Build and Ship Box")
        Friend WithEvents prodDriveCam_Main_DockShipment As New MenuCommand("Dock Shipment")
        Friend WithEvents prodDriveCam_Main_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodDriveCam_Main_Search As New MenuCommand("Search")
        Friend WithEvents prodDriveCam_Main_ShipBox As New MenuCommand("Ship Box")

        ''Liquidity Services/DYSCERN
        'Friend WithEvents prodDyscern_Main As New MenuCommand("Liquidity Services")
        'Friend WithEvents prodDyscern_Admin As New MenuCommand("Admin")
        'Friend WithEvents prodDyscern_Rec As New MenuCommand("Receiving")

        'Peek
        Friend WithEvents prodPeek_Main As New MenuCommand("Peek")
        Friend WithEvents prodPeek_KittingProcess As New MenuCommand("Kitting")
        Friend WithEvents prodPeek_Rec As New MenuCommand("Receiving")


        'SONITROL
        Friend WithEvents prodSonitroL_Main As New MenuCommand("Reverse Logistics")
        Friend WithEvents prodSonitrol_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodSonitroL_PBilling As New MenuCommand("Plexus Billing")
        Friend WithEvents prodSonitroL_SBilling As New MenuCommand("Sonitrol Billing")

        'SENSUS
        Friend WithEvents prodSensus_Main As New MenuCommand("Sensus")
        Friend WithEvents prodSensus_Admin As New MenuCommand("Admin")
        Friend WithEvents prodSensus_BSPallet As New MenuCommand("Build Ship Pallet")
        Friend WithEvents prodSensus_PackingList As New MenuCommand("Packing List")
        Friend WithEvents prodSensus_Search As New MenuCommand("Search")

        'SYX
        Friend WithEvents prodSyx_Main As New MenuCommand("Syx")
        Friend WithEvents prodSyx_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodSyx_Triage As New MenuCommand("Triage")
        Friend WithEvents prodSyx_TechBilling As New MenuCommand("Tech/Billing")
        Friend WithEvents prodSyx_FQA As New MenuCommand("FQA")
        Friend WithEvents prodSyx_Kitting As New MenuCommand("Kitting")
        Friend WithEvents prodSyx_AQL As New MenuCommand("AQL")
        Friend WithEvents prodSyx_Produce As New MenuCommand("Produce")
        Friend WithEvents prodSyx_Warehouse As New MenuCommand("Warehouse")
        Friend WithEvents prodSyx_ImageLib As New MenuCommand("Image Library")
        Friend WithEvents prodSyx_Reports As New MenuCommand("Reports")
        Friend WithEvents prodSyx_Reports_Excel As New MenuCommand("Excel")
        Friend WithEvents prodSyx_Reports_Crystal As New MenuCommand("Crystal")
        Friend WithEvents prodSyx_Tools As New MenuCommand("Tools")
        Friend WithEvents prodSyx_Tools_Admin As New MenuCommand("Admin Tools")
        Friend WithEvents prodSyx_PartsReceiving As New MenuCommand("Parts Receiving")
        Friend WithEvents prodSyx_PartsConsumption As New MenuCommand("Parts Consumption")
        Friend WithEvents prodSyx_WipTransf As New MenuCommand("WIP Transfer")
        Friend WithEvents prodSyx_EditModel As New MenuCommand("Edit Model")

        'TMI
        Friend WithEvents prodTMI_Main As New MenuCommand("TMI")
        Friend WithEvents prodTMI_Main_ShipReturnLabel As New MenuCommand("Ship Return Label")
        Friend WithEvents prodTMI_Main_Rec As New MenuCommand("Receiving")
        'Friend WithEvents prodTMI_Main_Pretest As New MenuCommand("Pretest")
        Friend WithEvents prodTMI_Main_Repair As New MenuCommand("Repair/Tech")
        Friend WithEvents prodTMI_Main_AQL As New MenuCommand("AQL")
        Friend WithEvents prodTMI_Main_Ship As New MenuCommand("Produce && Ship")
        Friend WithEvents prodTMI_Main_OBA As New MenuCommand("OBA")
        Friend WithEvents prodTMI_Main_Reports As New MenuCommand("Reports")

        'TRACFONE
        Friend WithEvents prodTF_Main As New MenuCommand("TracFone")
        Friend WithEvents prodTF_Main_Admin As New MenuCommand("Admin Functions")
        Friend WithEvents prodTF_Main_Billing As New MenuCommand("Billing")
        Friend WithEvents prodTF_Main_Tech As New MenuCommand("Tech")
        Friend WithEvents prodTF_Main_Label As New MenuCommand("Labeling")
        Friend WithEvents prodTF_Main_ProdTrack As New MenuCommand("Productivity Tracking")
        Friend WithEvents prodTF_Main_Rec As New MenuCommand("Receiving")
        Friend WithEvents prodTF_Main_Ship As New MenuCommand("Shipping")
        Friend WithEvents prodTF_Main_Test As New MenuCommand("Testing")
        Friend WithEvents prodTF_Main_Warehouse As New MenuCommand("Warehouse")
        Friend WithEvents prodTF_Main_Wip As New MenuCommand("Wip Transfer")

        Friend WithEvents prodTF_Main_Tech_BER As New MenuCommand("BER Screen")
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
        Friend WithEvents prodTF_Main_Test_SoftRef As New MenuCommand("Software Refurbish")

        Friend WithEvents prodTF_Ship_BuildShipPallet As New MenuCommand("Build Ship Box")
        Friend WithEvents prodTF_Ship_BuildShipPalletAcc As New MenuCommand("Build Ship Box Accessory")
        Friend WithEvents prodTF_Ship_ShipPallet As New MenuCommand("Produce Box")

        Friend WithEvents prodTF_Main_Warehouse_AssignBatteryCover As New MenuCommand("Assign Battery Cover")
        Friend WithEvents prodTF_Main_Warehouse_AssignWHLoc As New MenuCommand("Assign Warehouse Location")
        Friend WithEvents prodTF_Main_Warehouse_SearchWHRecInfo As New MenuCommand("Search Receive Data")
        Friend WithEvents prodTF_Main_Warehouse_FillOpenOrder As New MenuCommand("Fill Open Order")
        Friend WithEvents prodTF_Main_Warehouse_Manifest As New MenuCommand("Manifest")
        Friend WithEvents prodTF_Main_Warehouse_ManifestBER As New MenuCommand("Manifest BER")

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

        ''*****************************************
        ''Commented by Lan 10/31/2007 INACTIVE SCREEN
        ''*****************************************
        'WIP
        Friend WithEvents prodWIPMain As New MenuCommand("WIP")
        Friend WithEvents prodTransferDevicesToPreCell As New MenuCommand("Transfer Devices to Pre-Cell")
        Friend WithEvents prodTransferDevicesToHold As New MenuCommand("Transfer Devices to Hold")
        'Friend WithEvents prodRemoveDevicesFromPallet As New MenuCommand("Remove Devices from Pallet")
        'Friend WithEvents prodTakeWIPOwnerShip As New MenuCommand("Take WIP Ownership")
        'Friend WithEvents prodAssignWIPOwnership As New MenuCommand("Assign WIP Ownership")
        'Friend WithEvents prodReadyToTransfer As New MenuCommand("Pending Waiting for Parts")
        'Friend WithEvents prodTempTransferWIPOwnership As New MenuCommand("Temporarily Transfer Ownership")
        ''*****************************************
        ''*****************************************
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        ''*****************************************
        ''******** Flashing Menu
        'Friend WithEvents prodFlashing As New MenuCommand("Flashing")
        'Friend WithEvents smFlashing_BuildFlashingShipPallet As New MenuCommand("Build Flashing Ship Pallets")
        ''Friend WithEvents smFlashing_CollectMClaimData As New MenuCommand("Collect MClaim Data")
        ''******** Flashing Menu

        Friend WithEvents prodAudit As New MenuCommand("Audit")
        Friend WithEvents prodAudit_DevBillHist As New MenuCommand("Device Billing History")

        'Friend WithEvents prodCustomerSpecificShipping As New MenuCommand("Shipping")
        'Friend WithEvents prodCustomerSpecificShipping_Regular As New MenuCommand("Re&gular", Shortcut.CtrlG)
        'Friend WithEvents prodCustomerSpecificShipping_RUR As New MenuCommand("R&UR", Shortcut.CtrlU)
        'Friend WithEvents prodCustomerSpecificShipping_BER As New MenuCommand("B&ER", Shortcut.CtrlE)
        'Friend WithEvents prodCustomerSpecificShipping_RTM As New MenuCommand("&RTM", Shortcut.CtrlShiftR)

        '//Friend WithEvents prodMotoRLShippig As New MenuCommand("Motorola RL Shipping") 'Added by Asif 04/19/2004
        '**************Commented by Asif on 02/15/2006
        'Friend WithEvents prodMotoRLShippig As New MenuCommand("RL Shipping") 'Added by Asif 04/19/2004
        'Friend WithEvents prodMotoRLShipping_Regular As New MenuCommand("Re&gular", Shortcut.CtrlShiftG)
        'Friend WithEvents prodMotoRLShipping_RUR As New MenuCommand("R&UR", Shortcut.CtrlShiftU)
        'Friend WithEvents prodMotoRLShipping_BER As New MenuCommand("B&ER", Shortcut.CtrlShiftE)
        '**************
        'Friend WithEvents prodMotoRLShipping_RNR As New MenuCommand("RNR", Shortcut.CtrlShiftN)

        ''*****************************************CUSTOMER SPECIFIC RECEIVING
        ''Comment by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents prodMotoRec As New MenuCommand("&Motorola Receiving", Shortcut.CtrlM)

        'Friend WithEvents prodMotoRLRec As New MenuCommand("M&otorola RL Receiving", Shortcut.CtrlO)
        'Friend WithEvents prodCSRec As New MenuCommand("&Brightpoint Receiving", Shortcut.CtrlA)
        ''*****************************************
        ''Comment by Lan 06/19/2008 INACTIVE SCREEN
        'Friend WithEvents prodATCLEFileRec As New MenuCommand("Customer File Receiving", Shortcut.CtrlA)
        ''*****************************************

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
        'Admin_Revenue_DailyProduction.rpt

        Friend WithEvents rptAdminWIP As New MenuCommand("&Admin WIP")
        Friend WithEvents rptAdminWIPDetail As New MenuCommand("Admin WIP Detail")
        Friend WithEvents rptAdminWIPDetailByLocation As New MenuCommand("Admin WIP Detail by Location")
        Friend WithEvents rptMessagingWIPByCustomerAndModel As New MenuCommand("Messaging WIP by Customer and Model")
        'Friend WithEvents rptATCLEReworkWIPbyModel As New MenuCommand("Admin ATCLE Rework WIP by Model")

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
        ' Friend WithEvents rptCellSpec As New MenuCommand("Special Excel Report")
        'Friend WithEvents rptAdminUSAMobWORpt As New MenuCommand("USA Mobility WO Report")
        Friend WithEvents rptAdminWCDetail As New MenuCommand("Work Center Report")
        '***************************

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

        'rptTechRefurbQtyRpt
        Friend WithEvents rptTechRefurbQtyRpt As New MenuCommand("Technician Refurb Qty Report")
        Friend WithEvents rptMessLblProdRpt As New MenuCommand("Messaging Label Production")
        Friend WithEvents rptSNsByRcvedPalletRpt As New MenuCommand("Print SN barcodes by Received Pallet Name")

        Friend WithEvents rptMotoWrty As New MenuCommand("Motorolla ASC Warranty")

        Friend WithEvents rptPartsB2IDetail As New MenuCommand("Parts Billed to Issued Detail")
        Friend WithEvents rptPartsB2ISumm As New MenuCommand("Parts Billed to Issued Summary")
        Friend WithEvents rptPartsAnalysis As New MenuCommand("Parts Analysis")
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
        Friend WithEvents smAdmin_Revenue As New MenuCommand("Revenue")
        Friend WithEvents smAdmin_Revenue_Summary As New MenuCommand("Summary Special Project")
        Friend WithEvents smAdmin_Revenue_Detail As New MenuCommand("Detail Special Project")

        Friend WithEvents smCellSpec As New MenuCommand("Excel Output")
        Friend WithEvents smBilling As New MenuCommand("Billing")
        Friend WithEvents smFinance As New MenuCommand("Finance")
        Friend WithEvents smHumanResources As New MenuCommand("Human Resources")
        Friend WithEvents smQualityControl As New MenuCommand("Quality Control")
        Friend WithEvents smParts As New MenuCommand("Inventory")
        Friend WithEvents smReceiving As New MenuCommand("Receiving")
        Friend WithEvents smShipping As New MenuCommand("Shipping")
        Friend WithEvents smProduction As New MenuCommand("Production")

        'Finance
        Friend WithEvents smFinance_NavReports As New MenuCommand("Navision Reports")

        ''//Production SubMenu - Special Receiving
        'Friend WithEvents smpCustSpecRec As New MenuCommand("Customer Specific Receiving")

        '**************************
        'Menu Production ==> Line 
        '**************************
        'Friend WithEvents ProdLine As New MenuCommand("Line")
        'Friend WithEvents ProdWarehouseRec As New MenuCommand("Receiving")
        'Friend WithEvents ProdWarehouseRec_OEM As New MenuCommand("Receiving")
        '**************************

        Friend WithEvents prodInventory As New MenuCommand("Inventory")
        Friend WithEvents ProdReplenishRecover As New MenuCommand("Replenish/Recover Parts")
        Friend WithEvents ProdGroupLineSideBenchMap As New MenuCommand("Manage Groups, Lines, Sides, Benches, Cost Centers")

        ''********************************************PRODUCTION/INVENTORY
        ''Commented by Lan 01/18/2007 INACTIVE SCREEN
        'Friend WithEvents ProdInventoryTracking As New MenuCommand("Inventory Tracking")
        'Friend WithEvents ProdReplenishNavFile As New MenuCommand("Create Replenished Parts File for NAV")
        'Friend WithEvents ProdBenchCycleCountVarianceFile As New MenuCommand("Create Bench Cycle Count Variance File")
        'Friend WithEvents ProdPartsReplenishPickTicket As New MenuCommand("Parts Replenish Pick Ticket")
        ''********************************************

        '//Production SubMenu - Pretest
        Friend WithEvents smPretestOptions As New MenuCommand("Pretest Options")
        ''********************************************
        ''Commented by Lan 06/19/2008 INACTIVE SCREEN
        ''//Production SubMenu - Tech Options
        'Friend WithEvents smTechOptions As New MenuCommand("Tech Options")
        ''********************************************

        ' Incentive program submenus
        'Friend WithEvents sm_CellularIncentivePrg As New MenuCommand("Cellular")

        'frmReplenishPickTicket

        '***************************************************************
        'WAREHOUSE
        '***************************************************************
        Friend WithEvents prodWarehouse As New MenuCommand("Warehouse")
        Friend WithEvents prodWarehouse_DockShipment As New MenuCommand("Dock Shipment")
        Friend WithEvents prodWarehouse_SendPalletPackingListFiles As New MenuCommand("Manifest Processing")
        'Friend WithEvents prodWarehouse_OrderFulfilment As New MenuCommand("Order Fulfilment")
        Friend WithEvents prodWarehouse_PrintUPCLabel As New MenuCommand("Print UPC Label")

        '***************************************************************
        'ENGINEERING
        '***************************************************************
        'mnuEngineering
        Friend WithEvents engManageManufCodes As New MenuCommand("Manage Manufacturer Codes Map")
        '***************************************************************

        Public Sub New()
            MyBase.New()

            InitializeComponent()
        End Sub

        '***************************************************************
        Private Sub InitializeComponent()
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

            '// add our file menus
            'If//security====================
            'mnuFile.MenuCommands.AddRange(New MenuCommand() {filSystem, mnuDiv})
            'End If//security===============^^
            mnuFile.MenuCommands.AddRange(New MenuCommand() {filClose, filCloseA, mnuDiv, filExit})

            '// add our system menus
            'If//security====================
            filSystem.MenuCommands.Add(sysSecurity)
            'End If//security===============^^
            filSystem.MenuCommands.Add(mnuDiv)
            'If//security====================
            filSystem.MenuCommands.Add(sysInfo)
            'End If//security===============^^
            filSystem.MenuCommands.Add(mnuDiv)
            'If//security====================
            filSystem.MenuCommands.Add(sysWCL)

            '// add our admin menus
            Dim iMessagingSecure As Integer = 0
            Dim iCelSecure As Integer = 0
            Dim iRMASecure As Integer = 0
            Dim iShipLocChg As Integer = 0


            mnuAdmin.MenuCommands.AddRange(New MenuCommand() {prodDisplayCount, mnuDiv})

            'Messaging Security
            '*********************************
            'DO NOT UNCOMMENT THIS - ASIF
            '*********************************
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

            ''*****************************************
            ''Commented by Lan 01/18/2007 INACTIVE SCREEN
            ''*****************************************
            'If ApplicationUser.GetPermission("frmShippingLocGroup") > 0 Then
            '    'mnuAdmin.MenuCommands.Add(admShipLocChange)
            '    iShipLocChg = 1
            'End If
            ''*****************************************

            'If ApplicationUser.GetPermission("frmPreDefineRMArec") > 0 Then
            '    mnuAdmin.MenuCommands.Add(admDefineRMA)
            'End If

            'Commented by Asif 11/20/2003
            'If ApplicationUser.GetPermission("CellWrty") > 0 Then
            '    mnuAdmin.MenuCommands.Add(admCellWrty)
            'End If

            '// add our customer service menus
            'If//security====================
            If ApplicationUser.GetPermission("frmCustMaint") > 0 Then
                mnuCustServ.MenuCommands.Add(csCompany)
            End If
            If ApplicationUser.GetPermission("frmCustMaintNew") > 0 Then
                mnuCustServ.MenuCommands.Add(csCustCompany)
            End If

            If ApplicationUser.GetPermission("frmPreload_Workorder") > 0 Then
                mnuCustServ.MenuCommands.Add(csWOPreload)
            End If

            ''********************************************CUSTOMER SERVICES
            ''Commented by Lan 01/18/2007 INACTIVE SCREEN
            'If ApplicationUser.GetPermission("frmPreload_Workorder") > 0 Then
            '    mnuCustServ.MenuCommands.Add(csWOPreloadCamera)
            'End If
            'If ApplicationUser.GetPermission("frmPreload_Workorder") > 0 Then
            '    mnuCustServ.MenuCommands.Add(csWOPreloadCamera35)
            'End If
            'If ApplicationUser.GetPermission("frmPreload_Workorder") > 0 Then
            '    mnuCustServ.MenuCommands.Add(csWOPreloadUSAMobility)
            'End If
            ''********************************************

            If ApplicationUser.GetPermission("frmCustMaintSearch") > 0 Then
                mnuCustServ.MenuCommands.Add(csCompanySearch)
            End If
            If ApplicationUser.GetPermission("CompAdmin") > 0 Then
                mnuCustServ.MenuCommands.Add(csSalesPerson)
            End If

            ''********************************************
            ''Commented by Lan 01/18/2007 INACTIVE SCREEN
            'If ApplicationUser.GetPermission("CompAddress") > 0 Then
            '    mnuCustServ.MenuCommands.Add(csCompanyAddress)
            'End If
            ''********************************************

            If ApplicationUser.GetPermission("frmOrderEntrySelect") > 0 Then
                mnuCustServ.MenuCommands.Add(csOrderEntry)
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

            ''********************************************
            ''Commented by Lan 01/18/2007 INACTIVE SCREEN
            ''************************************************************
            ''MClaims menu item added by Asif on 06/28/2004
            'mnuCustServ.MenuCommands.Add(csMClaims)

            'If ApplicationUser.GetPermission("frmEditClaims") > 0 Then
            '    csMClaims.MenuCommands.Add(csEditASCClaims)
            'End If
            'If ApplicationUser.GetPermission("frmEditClaims") > 0 Then
            '    csMClaims.MenuCommands.Add(csEditSubClaims)
            'End If
            'If ApplicationUser.GetPermission("frmMotoClaimReconcile") > 0 Then
            '    csMClaims.MenuCommands.Add(csMclaimsReconciliation)
            'End If
            ''********************************************

            '************************************************************
            '            mnuCustServ.MenuCommands.Add(csCompany)
            '            mnuCustServ.MenuCommands.Add(csOrderEntry)
            'End If//security===============^^
            'mnuCustServ.MenuCommands.Add(mnuDiv)


            '// add our inventory menus
            If PSS.Core.ApplicationUser.GetPermission("ASCPriceWin") > 0 Then
                mnuInventory.MenuCommands.Add(invASCPrice)
            End If
            If PSS.Core.ApplicationUser.GetPermission("BillCodeWin") > 0 Then
                mnuInventory.MenuCommands.Add(invBillCodes)
                'mnuInventory.MenuCommands.Add(mnuDiv)
            End If
            If PSS.Core.ApplicationUser.GetPermission("FailCodeWin") > 0 Then
                mnuInventory.MenuCommands.Add(invFailCodes)
            End If
            If ApplicationUser.GetPermission("LaborLvl") > 0 Then
                mnuInventory.MenuCommands.Add(invLaborLvl)
            End If
            If PSS.Core.ApplicationUser.GetPermission("RepairCodeWin") > 0 Then
                mnuInventory.MenuCommands.Add(invRepairCodes)
                mnuInventory.MenuCommands.Add(mnuDiv)
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
            If PSS.Core.ApplicationUser.GetPermission("InactivateBillCodes") > 0 Then
                mnuInventory.MenuCommands.Add(invInactivateBillCodes)
            End If
            If PSS.Core.ApplicationUser.GetPermission("InactivateBillCodesC") > 0 Then
                mnuInventory.MenuCommands.Add(invInactivateBillCodesC)
            End If
            If PSS.Core.ApplicationUser.GetPermission("CreateBillGroups") > 0 Then
                mnuInventory.MenuCommands.Add(invCreateBillGroups)
            End If
            If PSS.Core.ApplicationUser.GetPermission("BillGroupAdmin") > 0 Then
                mnuInventory.MenuCommands.Add(invBillGroupAdmin)
            End If
            If PSS.Core.ApplicationUser.GetPermission("PartsRelated") > 0 Then
                mnuInventory.MenuCommands.Add(invPartsRelated)
            End If

            'If PSS.Core.ApplicationUser.GetPermission("CycleCountVarianceReport") > 0 Then
            '    mnuInventory.MenuCommands.Add(invCycleCountVarianceReport)
            'End If

            '********************************
            'PRODUCTION MENU
            '// add our production menus
            '********************************
            'mnuProduction.MenuCommands.AddRange(New MenuCommand() {prodBetterSearch, mnuDiv})
            mnuProduction.MenuCommands.AddRange(New MenuCommand() {prodSearch, mnuDiv})
            'mnuProduction.MenuCommands.AddRange(New MenuCommand() {prodCellSearch, mnuDiv})

            '*********************************************
            'PRODUCTION => COST CENTER 
            '*********************************************
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

            ''**********************************************
            ''PRODUCTION => CUSTOMER SPECIFIC RECEIVING
            ''**********************************************
            'mnuProduction.MenuCommands.Add(smpCustSpecRec)
            'If ApplicationUser.GetPermission("NEW_CellReceiving") > 0 Then
            '    smpCustSpecRec.MenuCommands.Add(prodHScell)
            'End If
            ''***************************************** CUSTOMER SPECIFIC RECEIVING
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''If//security====================
            'If ApplicationUser.GetPermission("frmMOTO_Receiving") > 0 Then
            '    smpCustSpecRec.MenuCommands.Add(prodMotoRec)
            '    'mnuProduction.MenuCommands.Add(prodMotoRec)
            'End If

            ''If//security====================
            'If ApplicationUser.GetPermission("frmMOTORL_Receiving") > 0 Then
            '    smpCustSpecRec.MenuCommands.Add(prodMotoRLRec)
            '    'mnuProduction.MenuCommands.Add(prodMotoRLRec)
            'End If

            ''If//security====================
            'If ApplicationUser.GetPermission("frmCSRec") > 0 Then
            '    smpCustSpecRec.MenuCommands.Add(prodCSRec)
            'End If
            ''*****************************************
            ''Comment by Lan 06/19/2008 INACTIVE SCREEN
            '''*****************************************
            ''If//security====================
            'If ApplicationUser.GetPermission("frmATCLE_Receiving") > 0 Then
            '    smpCustSpecRec.MenuCommands.Add(prodATCLEFileRec)
            '    'mnuProduction.MenuCommands.Add(prodATCLEFileRec)
            'End If
            ''*****************************************

            '***************************************************
            'PRODUCTION => FLASHING 
            '***************************************************
            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''************* Flashing menu
            'mnuProduction.MenuCommands.Add(prodFlashing)
            'If ApplicationUser.GetPermission("Build Flashing Ship Pallets") > 0 Then
            '    prodFlashing.MenuCommands.Add(smFlashing_BuildFlashingShipPallet)
            'End If
            ''If ApplicationUser.GetPermission("CollectMClaimData") > 0 Then
            ''    prodFlashing.MenuCommands.Add(smFlashing_CollectMClaimData)
            ''End If
            ''************* Flashing menu

            '***************************************************
            'PRODUCTION => INVENTORY 
            '***************************************************
            mnuProduction.MenuCommands.Add(prodInventory)
            If ApplicationUser.GetPermission("ManageGroupLineSideBenchMap") > 0 Then
                prodInventory.MenuCommands.Add(ProdGroupLineSideBenchMap)
            End If

            If ApplicationUser.GetPermission("Replenish/Recover Parts") > 0 Then
                prodInventory.MenuCommands.Add(ProdReplenishRecover)
            End If
            ''********************************************PRODUCTION/INVENTORY
            ''CommentED by Lan 01/18/2007 INACTIVE SCREEN
            'If ApplicationUser.GetPermission("Inventory_Tracking") > 0 Then
            '    prodInventory.MenuCommands.Add(ProdInventoryTracking)
            'End If
            'If ApplicationUser.GetPermission("Create_Replenish_Parts_File") > 0 Then
            '    prodInventory.MenuCommands.Add(ProdReplenishNavFile)
            'End If

            'If ApplicationUser.GetPermission("BenchCycleCountVarianceFile") > 0 Then
            '    prodInventory.MenuCommands.Add(ProdBenchCycleCountVarianceFile)
            'End If
            'If ApplicationUser.GetPermission("Parts_Replenish_Pick_Ticket") > 0 Then
            '    prodInventory.MenuCommands.Add(ProdPartsReplenishPickTicket)
            'End If
            ''********************************************

            ''***************************************************
            ''PRODUCTION => LINE 
            ''***************************************************
            'mnuProduction.MenuCommands.Add(ProdLine)
            'If ApplicationUser.GetPermission("frmWarehouseRec") > 0 Then
            '    'ProdLine.MenuCommands.Add(ProdWarehouseRec)
            '    ProdLine.MenuCommands.Add(ProdWarehouseRec_OEM)
            'End If

            '**********************************************
            'PRODUCTION => PRETEST
            '**********************************************
            mnuProduction.MenuCommands.Add(smPretestOptions)
            'If//security====================
            If ApplicationUser.GetPermission("rfPreTest") > 0 Then
                'mnuProduction.MenuCommands.Add(prodPreTest)
                smPretestOptions.MenuCommands.Add(prodPreTest)
            End If
            'End If//security===============^^

            ''*****************************************PRESTEST
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''If//security====================
            'If ApplicationUser.GetPermission("rfPreTestCamera") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodPreTestCamera)
            '    smPretestOptions.MenuCommands.Add(prodPreTestCamera)
            'End If
            ''End If//security===============^^
            'If ApplicationUser.GetPermission("rfPreTestCamera35") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodPreTestCamera35)
            '    smPretestOptions.MenuCommands.Add(prodPreTestCamera35)
            'End If
            ''End If//security===============^^
            'If ApplicationUser.GetPermission("rfPreTestCellstar") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodPreTestCamera35)
            '    smPretestOptions.MenuCommands.Add(prodPreTestBrightpoint)
            'End If
            ''*****************************************

            ''*****************************************
            'PRODUCTION => WIP
            ''*****************************************
            mnuProduction.MenuCommands.Add(prodWIPMain)
            If ApplicationUser.GetPermission("TransferDevIntoWorkableWIP") > 0 Then
                prodWIPMain.MenuCommands.Add(prodTransferDevicesToPreCell)
            End If

            If ApplicationUser.GetPermission("TransferDevIntoWorkableWIP") > 0 Then
                prodWIPMain.MenuCommands.Add(prodTransferDevicesToHold)
            End If
            'If ApplicationUser.GetPermission("RemoveDevicesFromPallet") > 0 Then
            '    prodWIPMain.MenuCommands.Add(prodRemoveDevicesFromPallet)
            'End If
            'If ApplicationUser.GetPermission("TakeWIPOwnership") > 0 Then
            '    prodWIPMain.MenuCommands.Add(prodTakeWIPOwnerShip)
            'End If
            'If ApplicationUser.GetPermission("TakeWIPOwnership") > 0 Then
            '    prodWIPMain.MenuCommands.Add(prodAssignWIPOwnership)
            'End If
            'If ApplicationUser.GetPermission("ReadyToTransferWIP") > 0 Then
            '    prodWIPMain.MenuCommands.Add(prodReadyToTransfer)
            'End If

            'If ApplicationUser.GetPermission("TempTransferWIP") > 0 And ApplicationUser.IsCellular(ApplicationUser.GroupID) Then
            '    prodWIPMain.MenuCommands.Add(prodTempTransferWIPOwnership)
            'End If
            ''*****************************************

            mnuProduction.MenuCommands.Add(mnuDiv)

            ''*******************************************
            ''PRODUCT => Appliance
            ''*******************************************
            'If ApplicationUser.GetPermission("Nespresso") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodAppliance_Main)
            '    prodAppliance_Main.MenuCommands.Add(prodAppliance_Main_Nespresso)

            '    If ApplicationUser.GetPermission("NespressoShipping") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_BuildShipBox)
            '    If ApplicationUser.GetPermission("NespressoMgRecycleModel") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_MgRecyleModel)
            '    If ApplicationUser.GetPermission("PartRecovery") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_PartRecovery)
            '    If ApplicationUser.GetPermission("NespressoPreTest") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_PreTest)
            '    If ApplicationUser.GetPermission("NespressoShipping") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_Produced)
            '    If ApplicationUser.GetPermission("NespressoQC") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_QC)
            '    If ApplicationUser.GetPermission("NespressoReceiving") > 0 Then prodAppliance_Main_Nespresso.MenuCommands.Add(prodAppliance_Main_Nespresso_Rec)
            'End If

            ''*******************************************
            ''PRODUCT => CONN'S
            ''*******************************************
            'If ApplicationUser.GetPermission("ConnsProcess") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodConns_Main)
            '    'sub menuf
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_Rec)
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_Audit)
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_Rep)
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_Produce)
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_FillOutBoudOrder)
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_Manifest)
            '    prodConns_Main.MenuCommands.Add(mnuDiv)
            '    prodConns_Main.MenuCommands.Add(prodConns_Main_MagHigLowValModel)
            'End If

            '*******************************************
            'PRODUCT => DRIVECAM
            '*******************************************
            If ApplicationUser.GetPermission("DC") > 0 Then
                mnuProduction.MenuCommands.Add(prodDriveCam_Main)
                prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Admin)
                prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Billing)

                If ApplicationUser.GetPermission("DC_Admin") > 0 Then
                End If
                If ApplicationUser.GetPermission("DC_BuildShipBox") > 0 Then
                    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_BSB)
                End If
                If ApplicationUser.GetPermission("DC_DockShipment") > 0 Then
                    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_DockShipment)
                End If
                If ApplicationUser.GetPermission("DC_Receiving") > 0 Then
                    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Rec)
                End If
                'If ApplicationUser.GetPermission("DC_Search") > 0 Then
                '    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_Search)
                'End If
                If ApplicationUser.GetPermission("DC_BuildShipBox") > 0 Then
                    prodDriveCam_Main.MenuCommands.Add(prodDriveCam_Main_ShipBox)
                End If
            End If

            '*******************************************
            'PRODUCTION => GAMING
            '*******************************************
            mnuProduction.MenuCommands.Add(prodGamingMain)
            prodGamingMain.MenuCommands.Add(prodGaming_GS)
            If ApplicationUser.GetPermission("GamestopOpts") > 0 Then
                prodGaming_GS.MenuCommands.Add(prodGaming_GS_Opts)
            End If
            If ApplicationUser.GetPermission("WHStageRec") > 0 Then
                prodGaming_GS.MenuCommands.Add(prodGaming_GS_WHStageRec)
            End If

            '*******************************************
            'PRODUCTION => GENERIC PROCESS
            '*******************************************
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
                    'prodGenericProcMain.MenuCommands.Add(prodGenericProcMain_ProduceSpecialLot)
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
            '*******************************************
            'PRODUCTION => GENESIS
            '*******************************************
            If ApplicationUser.GetPermission("GenesisProcess") > 0 Then
                mnuProduction.MenuCommands.Add(prodGenesisProcMain)
                If ApplicationUser.GetPermission("Genesis_BuildAndProduceLot") > 0 Then
                    prodGenesisProcMain.MenuCommands.Add(prodGenesisProcMain_BuildShipLot)
                    prodGenesisProcMain.MenuCommands.Add(prodGenesisProcMain_ProduceLot)
                End If
                If ApplicationUser.GetPermission("Genesis_Receiving") > 0 Then
                    prodGenesisProcMain.MenuCommands.Add(prodGenesisProcMain_Rec)
                End If
            End If

            ''*******************************************
            ''PRODUCT => HTC
            ''*******************************************
            'If ApplicationUser.GetPermission("HTC") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodHTC_Main)
            '    prodHTC_Main.MenuCommands.AddRange(New MenuCommand() {prodHTC_MainAdmin, mnuDiv})
            '    prodHTC_Main.MenuCommands.AddRange(New MenuCommand() {prodHTC_MainInventory, mnuDiv})
            '    prodHTC_Main.MenuCommands.AddRange(New MenuCommand() {prodHTC_MainProd, mnuDiv})
            '    prodHTC_Main.MenuCommands.Add(prodHTC_MainReports)
            '    prodHTC_Main.MenuCommands.Add(prodHTC_MainSearch)
            '    prodHTC_Main.MenuCommands.AddRange(New MenuCommand() {mnuDiv, prodHTC_MainWarehouse})

            '    'admin
            '    If ApplicationUser.GetPermission("HTC_Admin") > 0 Then
            '        prodHTC_MainAdmin.MenuCommands.Add(prodHTC_MainAdmin_Admin)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_AdminEdit") > 0 Then
            '        prodHTC_MainAdmin.MenuCommands.Add(prodHTC_MainAdmin_AdminEdit)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_ProdTracking") > 0 Then
            '        prodHTC_MainAdmin.MenuCommands.Add(prodHTC_MainAdmin_ProdTracking)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_RMAProcessing") > 0 Then
            '        prodHTC_MainAdmin.MenuCommands.Add(prodHTC_MainAdmin_RMAProcessing)
            '    End If

            '    'inventory
            '    If ApplicationUser.GetPermission("HTC_MBLabel") > 0 Then
            '        prodHTC_MainInventory.MenuCommands.Add(prodHTC_MainInventory_MBLabel)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_LCD_MainBoard_Search") > 0 Then
            '        prodHTC_MainInventory.MenuCommands.Add(prodHTC_MainInventory_LCD_MainBoard_Search)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_LCDMB_REC") > 0 Then
            '        prodHTC_MainInventory.MenuCommands.Add(prodHTC_MainInventory_LCDMBRec)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_ReclaimParts") > 0 Then
            '        prodHTC_MainInventory.MenuCommands.Add(prodHTC_MainInventory_ReclaimParts)
            '    End If

            '    'production
            '    If ApplicationUser.GetPermission("HTC_ProdRec") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_ProdRec)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_Test") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_Diagnosis)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_Repair") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_PreBill)
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_Repair)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_BillingAuditor") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_BillingAuditor)
            '    End If

            '    If ApplicationUser.GetPermission("HTC_Relabel") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_ReLabel)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_Test") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_PIA)
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_RF)
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_Final)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_Ship") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_BuildBox)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_Test") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_OOBA)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_Ship") > 0 Then
            '        prodHTC_MainProd.MenuCommands.Add(prodHTC_MainProd_ShipBox)
            '    End If

            '    'warehouse
            '    If ApplicationUser.GetPermission("HTC_DockRec") > 0 Then
            '        prodHTC_MainWarehouse.MenuCommands.Add(prodHTC_MainWarehouse_DockRec)
            '    End If
            '    If ApplicationUser.GetPermission("HTC_PackingList") > 0 Then
            '        prodHTC_MainWarehouse.MenuCommands.Add(prodHTC_MainWarehouse_PackingList)
            '    End If
            'End If

            ''*******************************************
            ''PRODUCT => Liquidity Services/DYSCERN
            ''*******************************************
            'mnuProduction.MenuCommands.Add(prodDyscern_Main)
            'If ApplicationUser.GetPermission("Dyscern_Admin") > 0 Then
            '    prodDyscern_Main.MenuCommands.Add(prodDyscern_Admin)
            'End If
            'If ApplicationUser.GetPermission("DyscernReceiving") > 0 Then
            '    prodDyscern_Main.MenuCommands.Add(prodDyscern_Rec)
            'End If

            '*******************************************
            'PRODUCTION => MESSAGING
            '*******************************************
            mnuProduction.MenuCommands.Add(prodMessagingMain)
            prodMessagingMain.MenuCommands.Add(prodMessaging_AMS)
            If ApplicationUser.GetPermission("AMDBRManifest") > 0 Then prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_DBRManifest)
            If ApplicationUser.GetPermission("AMS_MapLvl3RepReason") > 0 Then prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_MapLvl3RepReason)
            If ApplicationUser.GetPermission("MessAMSBilling") > 0 Then prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_Billing)

            'If//security====================
            If ApplicationUser.GetPermission("frmPalletBuild") > 0 Then
                '//July(14, 2006)
                'mnuProduction.MenuCommands.Add(prodMessagingMain_BuildPallet)
            End If
            'End If//security===============^^
            If ApplicationUser.GetPermission("MessOpConsole") > 0 Then
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_OptConsole)
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_DemandData)
            End If
            If ApplicationUser.GetPermission("frmShipping") > 0 Then
                prodMessaging_AMS.MenuCommands.Add(prodMessaging_AMS_ShipOld)
            End If

            'Skytel
            prodMessagingMain.MenuCommands.Add(mnuDiv)
            prodMessagingMain.MenuCommands.Add(prodMessagingMain_SkyTel)
            If ApplicationUser.GetPermission("SkyTel") > 0 Then
                prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_DBRManifest) 'Other Ship Manifest
                prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_Billing)
                prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_BB) 'Build ship box
                prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_Ship) 'ship box
                prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_LoadASN)
                prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_Rec)
            End If

            'Morris Communication
            If ApplicationUser.GetPermission("MorrisCom") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_MorrisCom)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_DBRManifest) 'Other Ship Manifest
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_Billing)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_BB) 'Build ship box
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_Ship) 'ship box
                'prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_LoadASN)
                prodMessagingMain_MorrisCom.MenuCommands.Add(prodMessagingMain_MorrisCom_Rec)
            End If

            'Propage
            If ApplicationUser.GetPermission("Propage") > 0 Then
                prodMessagingMain.MenuCommands.Add(mnuDiv)
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_Propage)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_DBRManifest) 'Other Ship Manifest
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_Billing)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_BB) 'Build ship box
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_Ship) 'ship box
                'prodMessagingMain_SkyTel.MenuCommands.Add(prodMessagingMain_SkyTel_LoadASN)
                prodMessagingMain_Propage.MenuCommands.Add(prodMessagingMain_Propage_Rec)
            End If

            'Aquis
            prodMessagingMain.MenuCommands.Add(mnuDiv)
            prodMessagingMain.MenuCommands.Add(prodMessagingMain_Aquis)
            If ApplicationUser.GetPermission("Aquis") > 0 Then
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_ModelSetup)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_ProdRec)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_WHRec)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_Billing)
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_BB) 'Build ship box
                prodMessagingMain_Aquis.MenuCommands.Add(prodMessagingMain_Aquis_Ship) 'Ship box
            End If

            prodMessagingMain.MenuCommands.Add(mnuDiv)
            'Hung 12/23/2011 comment out
            '// Billing
            'If ApplicationUser.GetPermission("BillingWin") > 0 Then
            'prodMessagingMain.MenuCommands.Add(prodMessagingMain_Bill)
            'End If

            If ApplicationUser.GetPermission("MessLabel") > 0 Then
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_Label)
            End If
            'American Messaging
            If ApplicationUser.GetPermission("frmReceiving") > 0 Then
                prodMessagingMain.MenuCommands.Add(prodMessagingMain_Rec)
            End If

            '*******************************************
            'PRODUCT => Native Instruments
            '*******************************************
            If ApplicationUser.GetPermission("NativeInstruments") > 0 Then
                mnuProduction.MenuCommands.Add(prodNInst_Main)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_ShipReturnLabel)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_Rec)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_Triage)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_Repair)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_AQL)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_Ship)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_OBA)
                prodNInst_Main.MenuCommands.Add(mnuDiv)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_ManageActiveModels)
                prodNInst_Main.MenuCommands.Add(mnuDiv)
                prodNInst_Main.MenuCommands.Add(prodNInst_Main_Reports)
            End If

            '*******************************************
            'PRODUCT => PANTECH
            '*******************************************
            If ApplicationUser.GetPermission("Pantech") > 0 Then
                mnuProduction.MenuCommands.Add(prodPantechMain)
                If ApplicationUser.GetPermission("PantechAdmin") > 0 Then prodPantechMain.MenuCommands.Add(prodPantechMain_Admin)
                prodPantechMain.MenuCommands.Add(prodPantechMain_EndUser)
                prodPantechMain.MenuCommands.Add(prodPantechMain_Jabil)
                prodPantechMain.MenuCommands.Add(prodPantechMain_Label)

                'End user
                If ApplicationUser.GetPermission("PantechCustomerService") > 0 Then prodPantechMain_EndUser.MenuCommands.Add(prodPantechMain_EndUser_CustService)
                If ApplicationUser.GetPermission("PantechRec") > 0 Then prodPantechMain_EndUser.MenuCommands.Add(prodPantechMain_EndUser_Rec)
                prodPantechMain_EndUser.MenuCommands.Add(prodPantechMain_EndUser_Search)
                If ApplicationUser.GetPermission("PantechShip") > 0 Then prodPantechMain_EndUser.MenuCommands.Add(prodPantechMain_EndUser_Ship)

                'Jabil
                If ApplicationUser.GetPermission("JabilShipping") > 0 Then
                    prodPantechMain_Jabil.MenuCommands.Add(prodPantechMain_Jabil_BuildShipBox)
                    prodPantechMain_Jabil.MenuCommands.Add(prodPantechMain_Jabil_ProduceBox)
                End If
                If ApplicationUser.GetPermission("JabilReceiving") > 0 Then prodPantechMain_Jabil.MenuCommands.Add(prodPantechMain_Jabil_Rec)
            End If

            '*******************************************
            'PRODUCT => PEEK
            '*******************************************
            mnuProduction.MenuCommands.Add(prodPeek_Main)
            If ApplicationUser.GetPermission("PeekReceiving") > 0 Then
                prodPeek_Main.MenuCommands.Add(prodPeek_KittingProcess)
                prodPeek_Main.MenuCommands.Add(prodPeek_Rec)
            End If

            '*******************************************
            'PRODUCT => SONITROL
            '*******************************************
            mnuProduction.MenuCommands.Add(prodSonitroL_Main)
            'Sonitrol
            If ApplicationUser.GetPermission("SonitrolReceiving") > 0 Then
                prodSonitroL_Main.MenuCommands.Add(prodSonitroL_PBilling)
                prodSonitroL_Main.MenuCommands.Add(prodSonitrol_Rec)
                prodSonitroL_Main.MenuCommands.Add(prodSonitroL_SBilling)
            End If

            '*******************************************
            'PRODUCT => SENSUS
            '*******************************************
            mnuProduction.MenuCommands.Add(prodSensus_Main)
            If ApplicationUser.GetPermission("Sensus_Admin") > 0 Then
                prodSensus_Main.MenuCommands.Add(prodSensus_Admin)
            End If
            If ApplicationUser.GetPermission("Sensus_BuildShipPallet") > 0 Then
                prodSensus_Main.MenuCommands.Add(prodSensus_BSPallet)
            End If
            If ApplicationUser.GetPermission("Sensus_PackingList") > 0 Then
                prodSensus_Main.MenuCommands.Add(prodSensus_PackingList)
            End If
            prodSensus_Main.MenuCommands.Add(prodSensus_Search)

            '*******************************************
            'PRODUCT => SYX
            '*******************************************
            If ApplicationUser.GetPermission("SyxMain") > 0 Then
                mnuProduction.MenuCommands.Add(prodSyx_Main)
                If ApplicationUser.GetPermission("SyxRec") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_Rec)
                If ApplicationUser.GetPermission("SyxTest") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_Triage)
                If ApplicationUser.GetPermission("SyxTechBilling") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_TechBilling)
                If ApplicationUser.GetPermission("SyxTest") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_FQA)
                If ApplicationUser.GetPermission("SyxShip") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_Kitting)
                If ApplicationUser.GetPermission("SyxTest") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_AQL)
                If ApplicationUser.GetPermission("SyxProduce") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_Produce)
                If ApplicationUser.GetPermission("SyxWarehouse") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_Warehouse)
                prodSyx_Main.MenuCommands.Add(mnuDiv)
                prodSyx_Main.MenuCommands.Add(prodSyx_ImageLib)
                If ApplicationUser.GetPermission("WIP") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_WipTransf)

                If ApplicationUser.GetPermission("SyxPartRelate") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_PartsReceiving)
                If ApplicationUser.GetPermission("SyxPartRelate") > 0 Then prodSyx_Main.MenuCommands.Add(prodSyx_PartsConsumption)
                prodSyx_Main.MenuCommands.Add(mnuDiv)
                prodSyx_Main.MenuCommands.Add(prodSyx_Reports)
                If ApplicationUser.GetPermission("SyxReport") > 0 Then prodSyx_Reports.MenuCommands.Add(prodSyx_Reports_Excel)
                If ApplicationUser.GetPermission("SyxReport") > 0 Then prodSyx_Reports.MenuCommands.Add(prodSyx_Reports_Crystal)
                prodSyx_Main.MenuCommands.Add(mnuDiv)
                prodSyx_Main.MenuCommands.Add(prodSyx_Tools)
                If ApplicationUser.GetPermission("SyxTools") > 0 Then prodSyx_Tools.MenuCommands.Add(prodSyx_Tools_Admin)

                If ApplicationUser.GetPermission("SyxEditModel") > 0 Then prodSyx_Tools.MenuCommands.Add(prodSyx_EditModel)
                prodSyx_Main.MenuCommands.Add(mnuDiv)
            End If

            '*******************************************
            'PRODUCT => TMI
            '*******************************************
            If ApplicationUser.GetPermission("TMI") > 0 Then
                mnuProduction.MenuCommands.Add(prodTMI_Main)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_ShipReturnLabel)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_Rec)
                'prodTMI_Main_Prod.MenuCommands.Add(prodTMI_Main_Prod_Pretest)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_Repair)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_AQL)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_Ship)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_OBA)

                prodTMI_Main.MenuCommands.Add(mnuDiv)
                prodTMI_Main.MenuCommands.Add(prodTMI_Main_Reports)
            End If

            '*******************************************
            'PRODUCT => TRACFONE
            '*******************************************
            If ApplicationUser.GetPermission("TracFone") > 0 Then
                mnuProduction.MenuCommands.Add(prodTF_Main)
                If ApplicationUser.GetPermission("TFAdminFunctions") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Admin)
                End If

                If ApplicationUser.GetPermission("TFAdminBilling") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Billing)
                End If

                If ApplicationUser.GetPermission("TFBillingRepair") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Tech)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_BER)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_PreBill)
                    prodTF_Main_Tech.MenuCommands.Add(prodTF_Main_Tech_Refurbished)
                End If

                If ApplicationUser.GetPermission("TFLabel") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Label)
                End If

                If ApplicationUser.GetPermission("ProductivityTracking") > 0 Then prodTF_Main.MenuCommands.Add(prodTF_Main_ProdTrack)

                If ApplicationUser.GetPermission("TFReceiving") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Rec)
                    prodTF_Main_Rec.MenuCommands.Add(prodTF_Main_Rec_Cell)
                    prodTF_Main_Rec.MenuCommands.Add(prodTF_Main_Rec_WH)
                End If

                If ApplicationUser.GetPermission("TFShipping") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Ship)
                    prodTF_Main_Ship.MenuCommands.Add(prodTF_Ship_BuildShipPallet)
                End If

                If ApplicationUser.GetPermission("TFWarehouse") > 0 Then prodTF_Main_Ship.MenuCommands.Add(prodTF_Ship_BuildShipPalletAcc)
                If ApplicationUser.GetPermission("TFShipping") > 0 Then prodTF_Main_Ship.MenuCommands.Add(prodTF_Ship_ShipPallet)

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
                    prodTF_Main_Test.MenuCommands.Add(prodTF_Main_Test_SoftRef)
                End If

                prodTF_Main.MenuCommands.Add(mnuDiv)
                prodTF_Main.MenuCommands.Add(prodTF_Main_Warehouse)
                If ApplicationUser.GetPermission("TFWarehouse") > 0 Then
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_AssignBatteryCover)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_AssignWHLoc)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_FillOpenOrder)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_Manifest)
                    prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_ManifestBER)
                End If
                prodTF_Main_Warehouse.MenuCommands.Add(prodTF_Main_Warehouse_SearchWHRecInfo)

                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Or ApplicationUser.GetPermission("TFWipTransferWH") > 0 Then
                    prodTF_Main.MenuCommands.Add(mnuDiv)
                    prodTF_Main.MenuCommands.Add(prodTF_Main_Wip)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToAWAP)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToBER)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToBERComplete)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToBERScreen)
                End If
                If ApplicationUser.GetPermission("TFWipTransferEng") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToEngineering)
                End If
                'If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                '    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToFFBS)
                '    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToFFCP)
                '    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToFFTF)
                'End If
                If ApplicationUser.GetPermission("TFWipTransferWH") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToObsolete)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToPreBill)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToPretest)
                End If
                If ApplicationUser.GetPermission("TFWipTransferWH") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToProdHold)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToStaging)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToQuarantine)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToRF1)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToTeardown)
                End If

                If ApplicationUser.GetPermission("TFWipTransferWH") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToWHRB)
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_ToWHWIP)
                End If
                If ApplicationUser.GetPermission("TFWipTransferProd") > 0 Then
                    prodTF_Main_Wip.MenuCommands.Add(prodTF_Main_WipTrans_RemoveFrFailAWP)
                End If
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

            '*******************************************
            'PRODUCTION
            '*******************************************
            ''*****************************************
            ''Comment by Lan 06/03/2008 INACTIVE SCREEN
            ''*****************************************
            'If ApplicationUser.GetPermission("BuildCellShipPallet") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodCellShipPallet)
            'End If
            ''*****************************************
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

            '*******************************************
            'PRODUCTION 
            '*******************************************
            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            'If ApplicationUser.GetPermission("AssignModelsToMachines") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodMachineModelMap)
            'End If
            ''*****************************************

            '*********************************
            'prodATCLEShip
            'mnuProduction.MenuCommands.Add(prodATCLEShip)

            '//Removed By Craig Haney 8-27-04
            'If ApplicationUser.GetPermission("frmATCLEShipping") > 0 Then
            'prodATCLEShip.MenuCommands.Add(prodATCLEShipping)
            'End If
            '//Removed By Craig Haney 8-27-04
            '*********************************

            '********************************* Added by Asif
            'mnuProduction.MenuCommands.Add(prodMotoSubContShip)

            'If ApplicationUser.GetPermission("frmMotoSubContShipping") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodCustomerSpecificShipping)
            '    prodMotoSubContShip.MenuCommands.Add(prodCustomerSpecificShipping)
            'End If


            '**************Commented by Asif on 02/15/2006
            'If ApplicationUser.GetPermission("frmMoto_RL_Shipping") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodMotoRLShippig)
            '    prodMotoSubContShip.MenuCommands.Add(prodMotoRLShippig)
            'End If


            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''If//security====================
            'If ApplicationUser.GetPermission("frmStaging") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodStageRMA)
            'End If
            ''*****************************************

            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''If//security====================
            'If ApplicationUser.GetPermission("frmStaging") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodStageBULK)
            'End If
            ''*****************************************
            ''Comment by Lan 10/31/2007 INACTIVE SCREEN
            ''*****************************************
            'If ApplicationUser.GetPermission("ProcessFlow") > 0 Then
            '    mnuProduction.MenuCommands.Add(ProdProcessFlow)
            'End If
            ''*****************************************

            '*******************************************
            'PRODUCTION
            '*******************************************
            If ApplicationUser.GetPermission("rfTechTools") > 0 Then
                'mnuProduction.MenuCommands.Add(prodTechTools)
                mnuProduction.MenuCommands.Add(prodCreatePSSISNs)
            End If
            'If ApplicationUser.GetPermission("frmWCTrayScan") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodTrayScan)
            'End If

            ''*****************************************
            ''Comment by Lan 06/19/2008 INACTIVE SCREEN
            ''*****************************************
            'mnuProduction.MenuCommands.Add(mnuDiv)
            'mnuProduction.MenuCommands.Add(smTechOptions)

            ''If//security====================
            'If ApplicationUser.GetPermission("frmProgramming") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodTechProg)
            '    smTechOptions.MenuCommands.Add(prodTechProg)
            'End If
            ''End If//security===============^^
            ''mnuProduction.MenuCommands.Add(mnuDiv)
            ''*****************************************

            'If//security====================
            'If ApplicationUser.GetPermission("frmNewTechScreen") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodTechNEW)
            '    smTechOptions.MenuCommands.Add(prodTechNEW)
            'End If
            '********************************************

            'If//security====================
            'mnuProduction.MenuCommands.Add(prodTech)
            'End If//security===============^^

            'mnuProduction.MenuCommands.Add(mnuDiv)

            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''If//security====================
            ''If ApplicationUser.GetPermission("rfPreTest") > 0 Then
            ''mnuProduction.MenuCommands.Add(prodDisposition)
            'smTechOptions.MenuCommands.Add(prodDisposition)
            ''End If
            ''End If//security===============^^
            ''*****************************************

            ''*****************************************
            ''Commented by Lan 01/18/2007 INACTIVE SCREEN
            ''*****************************************
            'If ApplicationUser.GetPermission("frmTrayTransfer") > 0 Then
            '    'mnuProduction.MenuCommands.Add(prodTrayTrans)
            'End If

            'If ApplicationUser.GetPermission("frmFGTransfer") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodFinishedGoodsTransfer)
            'End If
            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            ''*****************************************
            'If ApplicationUser.GetPermission("frmAwaitingParts") > 0 Then
            'mnuProduction.MenuCommands.Add(prodAwaitingParts)
            'End If
            ''*****************************************

            'If ApplicationUser.GetPermission("frmQC") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodQC)
            'End If

            'If ApplicationUser.GetPermission("frmCreateARFiles") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodAssetRecoveryFiles)
            'End If

            'If ApplicationUser.GetPermission("BrightpointOpts") > 0 Then
            '    mnuProduction.MenuCommands.Add(prodBrightpointOpts)
            'End If

            '*********************************************
            'PRODUCTION => WAREHOUSE
            '*********************************************
            mnuProduction.MenuCommands.AddRange(New MenuCommand() {mnuDiv, prodWarehouse})
            If ApplicationUser.GetPermission("SendPalletPackingListFiles") > 0 Then
                prodWarehouse.MenuCommands.Add(prodWarehouse_SendPalletPackingListFiles)
                prodWarehouse.MenuCommands.Add(prodWarehouse_DockShipment)
            End If
            'If ApplicationUser.GetPermission("OrderFulfilment") > 0 Then prodWarehouse.MenuCommands.Add(prodWarehouse_OrderFulfilment)
            If ApplicationUser.GetPermission("SendPalletPackingListFiles") > 0 Then
                prodWarehouse.MenuCommands.Add(prodWarehouse_PrintUPCLabel)
            End If

            '// add our report menus
            If ApplicationUser.GetPermission("rfAdminRev") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminRev)
            End If

            'If ApplicationUser.GetPermission("rfAdminRevDetail") > 0 Then
            '    smAdmin.MenuCommands.Add(rptAdminRevDetail)
            'End If

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
            'rptAdmin563RevRpt
            'AdminConsumedVSAutoBillRev

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
            'rptAdminWIPDetailByLocation
            If ApplicationUser.GetPermission("WIP_Detail_by_Group") > 0 Then
                mnuReports.MenuCommands.Add(rptAdminWIPDetailByLocation)
            End If
            'rptMessagingWIPByCustomerAndModel
            If ApplicationUser.GetPermission("MessagingWIPByCustomerAndModel") > 0 Then
                mnuReports.MenuCommands.Add(rptMessagingWIPByCustomerAndModel)
            End If

            ''rptATCLEReworkWIPbyModel
            'If ApplicationUser.GetPermission("ATCLEReworkWIPbyModel") > 0 Then
            '    mnuReports.MenuCommands.Add(rptATCLEReworkWIPbyModel)
            'End If

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

            '///
            If ApplicationUser.GetPermission("Scrap Quantity") > 0 Then
                mnuReports.MenuCommands.Add(rptScrapsCount)
            End If
            If ApplicationUser.GetPermission("Shop Floor Quantity report") > 0 Then
                mnuReports.MenuCommands.Add(rptShopFloorQtyReport)
            End If
            '//

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
            'If ApplicationUser.GetPermission("AmericanMessStagedNotRcvd") > 0 Then
            '    mnuReports.MenuCommands.Add(rptAmericanMessStagedNotRcvd)
            'End If

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

            'rptCellShippedPallets
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

            '************************************************************
            '// DOCUMENT MENU
            '************************************************************
            If ApplicationUser.GetPermission("DocumentLocationMap") > 0 Then
                mnuDocuments.MenuCommands.Add(mnuDocuments_DocLocMap)
            End If
            mnuDocuments.MenuCommands.Add(mnuDocuments_WorkInstruction)
            '************************************************************
            '// ENGINEERING MENU
            '************************************************************
            If ApplicationUser.GetPermission("ManageWrtyCodes") > 0 Then
                mnuEngineering.MenuCommands.Add(engManageManufCodes)
            End If

            '************************************************************

            '// add our help menus
            mnuHelp.MenuCommands.AddRange(New MenuCommand() {helpHelp, mnuDiv, helpAbout})

            '//Report split out ***********************************************************************
            '// add our Admin report menus
            'Report ->Administration -> Revenue
            smAdmin.MenuCommands.Add(smAdmin_Revenue)
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
            'rptAdminWIPDetailByLocation
            If ApplicationUser.GetPermission("WIP_Detail_by_Group") > 0 Then
                smAdmin.MenuCommands.Add(rptAdminWIPDetailByLocation)
            End If
            ''rptMessagingWIPByCustomerAndModel
            If ApplicationUser.GetPermission("MessagingWIPByCustomerAndModel") > 0 Then
                smAdmin.MenuCommands.Add(rptMessagingWIPByCustomerAndModel)
            End If

            ''rptATCLEReworkWIPbyModel
            'If ApplicationUser.GetPermission("ATCLEReworkWIPbyModel") > 0 Then
            '    smAdmin.MenuCommands.Add(rptATCLEReworkWIPbyModel)
            'End If

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

            ''New Revenue
            If ApplicationUser.GetPermission("AdRev_Summary_SpecialProj") > 0 Then
                smAdmin_Revenue.MenuCommands.AddRange(New MenuCommand() {smAdmin_Revenue_Summary})
            End If

            If ApplicationUser.GetPermission("AdRev_Detail_SpecialProj") > 0 Then
                smAdmin_Revenue.MenuCommands.AddRange(New MenuCommand() {mnuDiv, smAdmin_Revenue_Detail})
            End If ''New Revenue

            '***************************
            'REPORT-> EXCEL OUTPUT 
            '***************************
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
            'If ApplicationUser.GetPermission("rfCellSpec") > 0 Then smCellSpec.MenuCommands.Add(rptCellSpec)
            'If ApplicationUser.GetPermission("rfAdminUSAMobWORpt") > 0 Then  smCellSpec.MenuCommands.Add(rptAdminUSAMobWORpt)
            If ApplicationUser.GetPermission("rfAdminWCDetail") > 0 Then smCellSpec.MenuCommands.Add(rptAdminWCDetail)

            '***************************

            '// add our Billing report menu
            If ApplicationUser.GetPermission("rfBillEmpCnt") > 0 Then
                smBilling.MenuCommands.Add(rptBillEmpCnt)
            End If

            'FINANCE
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
            'Report => Human Resource 
            '***************************
            'If ApplicationUser.GetPermission("rfHRLeaveCount") > 0 Then
            '    smHumanResources.MenuCommands.Add(hrLeaveCnt)
            'End If
            'If ApplicationUser.GetPermission("rfHRLeave") > 0 Then
            '    smHumanResources.MenuCommands.Add(hrLeave)
            'End If
            'If ApplicationUser.GetPermission("rfHRWorkhours") > 0 Then
            '    smHumanResources.MenuCommands.Add(hrWorkHours)
            'End If
            'If ApplicationUser.GetPermission("rfHRWorkhours") > 0 Then
            '    smHumanResources.MenuCommands.Add(hrWorkHours)
            'End If

            '***************************
            'Human Resource
            '***************************
            If ApplicationUser.GetPermission("IncentiveData") > 0 Then mnuHR.MenuCommands.Add(hrIncentiveData)
            If ApplicationUser.GetPermission("LegiantEEData") > 0 Then mnuHR.MenuCommands.Add(hrLegiantEEData)

            '***************************


            'smQualityControl QCTechFailureRate
            If ApplicationUser.GetPermission("Technician_Failure_Rate") > 0 Then
                smQualityControl.MenuCommands.Add(QCTechFailureRate)
            End If


            '**********************************************************************
            'Admin Menu

            'Cellular sub-menus
            'If iRMASecure = 1 Or iCelSecure = 1 Then
            mnuAdmin.MenuCommands.Add(admMenu_Cellular)
            'End If

            ''*****************************************
            ''Commented by Lan 01/18/2007 INACTIVE SCREEN
            ''*****************************************
            'If iCelSecure = 1 Then
            '    admMenu_Cellular.MenuCommands.Add(admFunc_Cellular)
            'End If
            ''*****************************************

            If iRMASecure = 1 Then
                admMenu_Cellular.MenuCommands.Add(admDefineRMA)
            End If

            If iRMASecure = 1 Or iCelSecure = 1 Then
                admMenu_Cellular.MenuCommands.Add(admFunc_EditBillMap)
            End If

            'admFunc_CellTrayAdmin
            If ApplicationUser.GetPermission("Cell_Tray_Administration") > 0 Then
                admMenu_Cellular.MenuCommands.Add(admFunc_CellTrayAdmin)
            End If

            'Messaging Sub-menus
            If iMessagingSecure = 1 Or iShipLocChg = 1 Then
                mnuAdmin.MenuCommands.Add(admMenu_Messaging)
            End If
            If iMessagingSecure = 1 Then
                admMenu_Messaging.MenuCommands.Add(admFunc_Messaging)
                admMenu_Messaging.MenuCommands.Add(admFunc_EditSKU)

                ''*****************************************
                ''Commented by Lan 01/18/2007 INACTIVE SCREEN
                ''*****************************************
                'admMenu_Messaging.MenuCommands.Add(admFunc_EditFreq)
                'admMenu_Messaging.MenuCommands.Add(prodStageRMA)
                'admMenu_Messaging.MenuCommands.Add(prodStageBULK)
                'admMenu_Messaging.MenuCommands.Add(prodTrayTrans)
                'admMenu_Messaging.MenuCommands.Add(admLogicTray)
                ''*****************************************

                admMenu_Messaging.MenuCommands.Add(admFunc_MoveTray)
                admMenu_Messaging.MenuCommands.Add(admFunc_WOdata)
                admMenu_Messaging.MenuCommands.Add(prodMessagingMain_BuildPallet)
            End If

            ''*****************************************
            ''Comment by Lan 01/18/2007 INACTIVE SCREEN
            'If iShipLocChg = 1 Then
            '    admMenu_Messaging.MenuCommands.Add(admShipLocChange)
            'End If
            ''*****************************************


            'Admin -> Security
            If ApplicationUser.GetPermission("SecurityAdmin") > 0 Then
                mnuAdmin.MenuCommands.Add(admSecurity)
            End If

            '*********************************************
            'Admin -> Special Processes
            '*********************************************
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
            '*********************************************

            ''********************************************
            ''Commented by Lan 10/31/2007 INACTIVE SCREEN
            'BRIGHT POINT
            ''********************************************
            'If ApplicationUser.GetPermission("CellstarDailyShippingManifest") > 0 Then
            '    mnuReports.MenuCommands.Add(rptCellstarDailyShippingManifest)
            'End If
            'If ApplicationUser.GetPermission("rfRecCntDly") > 0 Then
            '    smReceiving.MenuCommands.Add(rptRecBrightpointReceivedDev)
            'End If
            'If ApplicationUser.GetPermission("rfAdminRevDetail") > 0 Then
            '    smAdmin.MenuCommands.Add(rptAdminRevDetailCellstar)
            'End If

            'If ApplicationUser.GetPermission("SPCellStarPartNumUpdate") > 0 Then
            '       admMenu_SP.MenuCommands.Add(admBrightpointPartNumUpdate)
            '   End If
            'If ApplicationUser.GetPermission("rfAdminRev") > 0 Then
            '    mnuReports.MenuCommands.Add(rptAdminRevCellstar)
            'End If
            'If ApplicationUser.GetPermission("rfAdminRev") > 0 Then
            '    smAdmin.MenuCommands.Add(rptAdminRevCellstar)
            'End If
            'If ApplicationUser.GetPermission("rfCellstarXML") > 0 Then
            '    admMenu_SP.MenuCommands.Add(admBrightpoint)
            'End If
            'If ApplicationUser.GetPermission("ResendCSXMLFiles") > 0 Then
            '    admMenu_SP.MenuCommands.Add(admResendBrightpointXMLFiles)
            'End If
            'If ApplicationUser.GetPermission("rfAssignAwaitParts") > 0 Then
            '    admMenu_SP.MenuCommands.Add(admAssignAwaitParts)
            'End If
            ''********************************************

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
                'admMenu_IncentivePrgData.MenuCommands.Add(sm_CellularIncentivePrg)
            End If

            '**********************************************************************
            '//Motorola Sub contract shipping sub menus

            'If ApplicationUser.GetPermission("frmMotoSubContShipping") > 0 Then
            '    prodCustomerSpecificShipping.MenuCommands.Add(prodCustomerSpecificShipping_Regular)
            '    prodCustomerSpecificShipping.MenuCommands.Add(prodCustomerSpecificShipping_RUR)
            '    prodCustomerSpecificShipping.MenuCommands.Add(prodCustomerSpecificShipping_BER)
            '    'prodCustomerSpecificShipping.MenuCommands.Add(prodCustomerSpecificShipping_RNR)
            '    prodCustomerSpecificShipping.MenuCommands.Add(prodCustomerSpecificShipping_RTM)

            'End If

            '**************Commented by Asif on 02/15/2006
            'If ApplicationUser.GetPermission("frmMoto_RL_Shipping") > 0 Then
            '    prodMotoRLShippig.MenuCommands.Add(prodMotoRLShipping_Regular)
            '    prodMotoRLShippig.MenuCommands.Add(prodMotoRLShipping_RUR)
            '    prodMotoRLShippig.MenuCommands.Add(prodMotoRLShipping_BER)
            '    'prodMotoRLShippig.MenuCommands.Add(prodMotoRLShipping_RNR)
            'End If
            '**********************************************************************

            '// add our Parts report menu
            If ApplicationUser.GetPermission("rfPartsB2Idetail") > 0 Then
                smParts.MenuCommands.Add(rptPartsB2IDetail)
            End If
            If ApplicationUser.GetPermission("rfPartsB2Isumm") > 0 Then
                smParts.MenuCommands.Add(rptPartsB2ISumm)
            End If
            If ApplicationUser.GetPermission("rfPartsAnalysis") > 0 Then
                smParts.MenuCommands.Add(rptPartsAnalysis)
            End If
            If ApplicationUser.GetPermission("rfPartsCount") > 0 Then
                smParts.MenuCommands.Add(rptPartsCount)
            End If

            '/////
            If ApplicationUser.GetPermission("Scrap Quantity") > 0 Then
                smParts.MenuCommands.Add(rptScrapsCount)
            End If
            If ApplicationUser.GetPermission("Shop Floor Quantity report") > 0 Then
                smParts.MenuCommands.Add(rptShopFloorQtyReport)
            End If

            '////
            If ApplicationUser.GetPermission("rfInvAwaitingParts") > 0 Then
                smParts.MenuCommands.Add(invAwaitingParts)
            End If

            If ApplicationUser.GetPermission("rfPartsMappedAnal") > 0 Then
                smParts.MenuCommands.Add(rptPartsMappedAnalysis)
            End If
            If ApplicationUser.GetPermission("rfBilledIssuedCell") > 0 Then
                smParts.MenuCommands.Add(rptBilledIssuedCell)
            End If
            If ApplicationUser.GetPermission("rfNonMappedCellParts") > 0 Then
                smParts.MenuCommands.Add(rptNonMappedCellParts)
            End If
            If ApplicationUser.GetPermission("rfInvModelMap") > 0 Then
                smParts.MenuCommands.Add(rptInvModelMap)
            End If
            If ApplicationUser.GetPermission("rptPartsAndBillCodesByModel") > 0 Then
                smParts.MenuCommands.Add(rptPartsAndBillCodesByModel)
            End If

            If ApplicationUser.GetPermission("rfInvBICellDetail") > 0 Then
                smParts.MenuCommands.Add(invBillIssueCellDetail)
            End If
            If ApplicationUser.GetPermission("rfInvReceptiSummary") > 0 Then
                smParts.MenuCommands.Add(invReceiptSummary)
            End If
            If ApplicationUser.GetPermission("rfInvUsageSummary") > 0 Then
                smParts.MenuCommands.Add(invUsageSummary)
            End If

            If ApplicationUser.GetPermission("CycleCountVarianceReport") > 0 Then
                smParts.MenuCommands.Add(invBenchCycleCountVarReport)
            End If
            If ApplicationUser.GetPermission("Available_for_Production") > 0 Then
                smParts.MenuCommands.Add(invAvailableForProdSumRpt)
            End If
            'If ApplicationUser.GetPermission("RVPartSaving") > 0 Then
            '    smParts.MenuCommands.Add(invRVSavingRpt)
            'End If
            If ApplicationUser.GetPermission("CogsReports") > 0 Then
                smParts.MenuCommands.Add(invCogsRpts)
            End If

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
            '

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

            '// add report test menus
            mnuReport.MenuCommands.Add(smAdmin)
            mnuReport.MenuCommands.Add(smBilling)
            mnuReport.MenuCommands.Add(smFinance)
            mnuReport.MenuCommands.Add(smHumanResources)
            mnuReport.MenuCommands.Add(smQualityControl)
            mnuReport.MenuCommands.Add(smParts)
            mnuReport.MenuCommands.Add(smReceiving)
            mnuReport.MenuCommands.Add(smShipping)
            mnuReport.MenuCommands.Add(smCellSpec)
            mnuReport.MenuCommands.Add(smProduction)

            '//Report split out ***********************************************************************

            '// add our root menus
            Me.MenuCommands.Add(mnuFile)
            Me.MenuCommands.Add(mnuAdmin)
            Me.MenuCommands.Add(mnuCustServ)
            If ApplicationUser.GetPermission("Engineering") > 0 Then Me.MenuCommands.Add(mnuEngineering)
            'Me.MenuCommands.Add(mnuFinance)
            If ApplicationUser.GetPermission("HR") > 0 Then Me.MenuCommands.Add(mnuHR)
            Me.MenuCommands.Add(mnuInventory)
            Me.MenuCommands.Add(mnuProduction)
            'Me.MenuCommands.Add(mnuReports)
            Me.MenuCommands.Add(mnuReport)
            Me.MenuCommands.Add(mnuDocuments)
            Me.MenuCommands.Add(mnuHelp)
        End Sub



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
                    If PSS.Core.[Global].ApplicationUser.IDuser > 0 Then
                        If objMisc.ResetLastLogonMachine(PSS.Core.[Global].ApplicationUser.IDuser) = 0 Then
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

        Public Sub prodMessShip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodMessaging_AMS_ShipOld.Click
            Const strTabPageTitle As String = "Shipping"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Shipping.frmShipping())
        End Sub

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
        Public Sub admFunc_Messaging_Click(ByVal sender As Object, ByVal e As EventArgs) Handles admFunc_Messaging.Click
            Const strTabPageTitle As String = "Edit(Messaging)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frmRecEdit())
        End Sub

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

        Private Sub prodMessRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Rec.Click
            Const strTabPageTitle As String = "Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frmReceiving())
        End Sub

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

        Private Sub prodWHStageRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGaming_GS_WHStageRec.Click
            Const strTabPageTitle As String = "Warehouse/Stage Rec"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmWHRecWithoutFile())
        End Sub

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

        ''*******************************************
        ''PRODUCT => Appliance => Nespresso
        ''*******************************************
        'Private Sub prodAppliance_Main_Nespresso_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_Rec.Click
        '    Const strTabPageTitle As String = "Nespresso Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Nespresso.frmReceiving())
        'End Sub
        'Private Sub prodAppliance_Main_Nespresso_PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_PreTest.Click
        '    Const strTabPageTitle As String = "Nespresso PreTest"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.pretest.frmPreTest(strTabPageTitle, PSS.Data.Buisness.Nespresso.Nespresso.intCustID))
        'End Sub
        'Private Sub prodAppliance_Main_Nespresso_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_QC.Click
        '    Const strTabPageTitle As String = "Nespresso QC"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strTabPageTitle, PSS.Data.Buisness.Nespresso.Nespresso.intCustID, 2))
        'End Sub
        'Private Sub prodAppliance_Main_Nespresso_PartRecovery_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_PartRecovery.Click
        '    Const strTabPageTitle As String = "Nespresso Parts Recovery"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Inventory.frmPartRecovery(strTabPageTitle))
        'End Sub
        'Private Sub prodAppliance_Main_Nespresso_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_BuildShipBox.Click
        '    Const strTabPageTitle As String = "Nespresso Build Ship Box"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Nespresso.frmBuildShipBox())
        'End Sub
        'Private Sub prodAppliance_Main_Nespresso_Produced_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_Produced.Click
        '    Const strTabPageTitle As String = "Nespresso Produce"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Nespresso.frmProduce())
        'End Sub
        'Private Sub prodAppliance_Main_Nespresso_MgRecyleModel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAppliance_Main_Nespresso_MgRecyleModel.Click
        '    Const strTabPageTitle As String = "Nespresso Manage Recycle Model"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Nespresso.frmManageRecycleModel())
        'End Sub

        ''*******************************************
        ''PRODUCT => CONN'S
        ''*******************************************
        'Private Sub prodConns_Main_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodConns_Main_Rec.Click
        '    Const strTabPageTitle As String = "Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ConnsRec(strTabPageTitle))
        'End Sub

        ''prodDriveCam_Main.MenuCommands.Add(prodConns_Main_Audit)

        'Private Sub prodConns_Main_Rep_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodConns_Main_Rep.Click
        '    Const strTabPageTitle As String = "Repair"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.Conn.CUSTOMERID, strTabPageTitle, , ))
        'End Sub

        'Private Sub prodConns_Main_MagHigLowValModel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodConns_Main_MagHigLowValModel.Click
        '    Const strTabPageTitle As String = "Conn's - Manage High/Low Value Model"
        '    Dim win As Crownwood.Magic.Controls.TabPage
        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ConnManageHighLowValModel(strTabPageTitle))
        'End Sub

        ''prodDriveCam_Main.MenuCommands.Add(prodConns_Main_Produce)
        ''prodDriveCam_Main.MenuCommands.Add(prodConns_Main_Manifest)
        ''prodDriveCam_Main.MenuCommands.Add(prodConns_Main_FillOutBoudOrder )

        '*******************************************
        'PRODUCT => DRIVECAM
        '*******************************************
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

        ''*******************************************
        ''PRODUCT => GENERIC PROCESS
        ''*******************************************
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
        Private Sub prodGenesisProcMain_BuildShipLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenesisProcMain_BuildShipLot.Click
            Const strTabPageTitle As String = "Build Ship Lot"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Genesis.frmBuildShipLot())
        End Sub
        Private Sub prodGenesisProcMain_ProduceLot_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenesisProcMain_ProduceLot.Click
            Const strTabPageTitle As String = "Produce Lot"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Genesis.frmProduceLot())
        End Sub
        Private Sub prodGenesisProcMain_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGenesisProcMain_Rec.Click
            Const strTabPageTitle As String = "Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Genesis.frmReceiving())
        End Sub

        '*******************************************
        'PRODUCT => Native Instruments   
        '*******************************************
        ' prodNInst_Main
        'prodNInst_Main_ShipReturnLabel
        'prodNInst_Main_Rec
        'prodNInst_Main_Triage
        'prodNInst_Main_Repair
        'prodNInst_Main_AQL
        'prodNInst_Main_Ship
        'prodNInst_Main_OBA
        'prodNInst_Main_ManageRepModels
        'prodNInst_Main_Reports
        Private Sub prodNInst_Main_Reports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Reports.Click
            Const strTabPageTitle As String = "NI Reports" : Const strScreenName As String = "NI Reports"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmReports(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID))
        End Sub
        Private Sub prodNInst_Main_ManageActiveModels_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_ManageActiveModels.Click
            Const strTabPageTitle As String = "Model Criteria" : Const strScreenName As String = "Model Criteria"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ManageModelCriteria(PSS.Data.Buisness.NI.CUSTOMERID, PSS.Data.Buisness.NI.MANUFID, PSS.Data.Buisness.NI.PRODID, , False))
        End Sub
        Private Sub prodNInst_Main_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Rec.Click
            Const strTabPageTitle As String = "NI Rec" : Const strScreenName As String = "Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmRec(strScreenName))
        End Sub
        Private Sub prodNInst_Main_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Ship.Click
            Const strTabPageTitle As String = "NI Produce" : Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmShip(strScreenName))
        End Sub
        Private Sub prodNInst_Main_Triage_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Triage.Click
            Const strTabPageTitle As String = "Triage" : Const strScreenName As String = "Triage"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.pretest.frmPreTest(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID, PSS.Data.Buisness.NI.PRODID, True, False))
        End Sub
        Private Sub prodNInst_Main_Repair_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_Repair.Click
            Const strTabPageTitle As String = "Repair/Tech" : Const strScreenName As String = "Repair"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.NativeInstruments.frmBilling(strScreenName))
        End Sub
        Private Sub prodNInst_Main_AQL_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodNInst_Main_AQL.Click
            Const strTabPageTitle As String = "AQL" : Const strScreenName As String = "AQL"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC(strScreenName, PSS.Data.Buisness.NI.CUSTOMERID, 4))
        End Sub

        '*******************************************
        'PRODUCT => PANTECH
        '*******************************************
        Private Sub prodPantechMain_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_Label.Click
            Const strTabPageTitle As String = "Pantech Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Pantech.frmPantechLabel("Pantech Label"))
        End Sub

        'End User
        Private Sub prodPantechMain_EndUser_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_Admin.Click
            Const strTabPageTitle As String = "PT End User Admin"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Pantech.frmAdmin())
        End Sub
        Private Sub prodPantechMain_EndUser_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_EndUser_Rec.Click
            Const strTabPageTitle As String = "PT End User Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Pantech.frmReceiving_1())
        End Sub
        Private Sub prodPantechMain_EndUser_CustService_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_EndUser_CustService.Click
            Const strTabPageTitle As String = "PT Customer Service"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Pantech.frmCustServices())
        End Sub
        Private Sub prodPantechMain_EndUser_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_EndUser_Ship.Click
            Const strTabPageTitle As String = "PT End User Shipping"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Pantech.frmShipping())
        End Sub
        Private Sub prodPantechMain_EndUser_Search_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_EndUser_Search.Click
            Const strTabPageTitle As String = "PT End User Search"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Pantech.frmSearch())
        End Sub

        '*******************************************
        'PRODUCT => Pantech => Jabil
        '*******************************************
        Private Sub prodPantechMain_Jabil_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_Jabil_Rec.Click
            Const strTabPageTitle As String = "Jabil Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Jabil.frmReceiving(strTabPageTitle))
        End Sub
        Private Sub prodPantechMain_Jabil_BuildShipBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_Jabil_BuildShipBox.Click
            Const strTabPageTitle As String = "Jabil Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Jabil.frmBuildShipBox(strTabPageTitle))
        End Sub
        Private Sub prodPantechMain_Jabil_ProduceBox_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPantechMain_Jabil_ProduceBox.Click
            Const strTabPageTitle As String = "Jabil Produce Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmProduceLot(strTabPageTitle, PSS.Data.Buisness.Jabil.CUSTOMER_ID, PSS.Data.Buisness.Jabil.LOC_ID))
        End Sub

        '*******************************************
        'PRODUCT => PEEK
        '*******************************************
        Private Sub prodPeek_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPeek_Rec.Click
            Const strTabPageTitle As String = "Peek Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Peek.frmPeekRec())
        End Sub
        Private Sub prodPeek_KittingProcess_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPeek_KittingProcess.Click
            Const strTabPageTitle As String = "Kitting"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Peek.frmKittingFunctions(2288))
        End Sub

        '*******************************************
        'PRODUCT => SONNITROL
        '*******************************************
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

        '*******************************************
        'PRODUCT => TMI
        '*******************************************
        Private Sub prodTMI_Main_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_Rec.Click
            Const strTabPageTitle As String = "Receiving"
            Const strScreenName As String = "RECEIVING"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMIRec(strScreenName))
        End Sub

        'Private Sub prodTMI_Main_Triage_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_Pretest.Click
        '    Const strTabPageTitle As String = "Pretest"
        '    Const strScreenName As String = "PRETEST"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.pretest.frmPreTest(strScreenName, PSS.Data.Buisness.TMI.CUSTOMERID))
        'End Sub

        Private Sub prodTMI_Main_ShipReturnLabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_ShipReturnLabel.Click
            Const strTabPageTitle As String = "Ship Return Label"
            Const strScreenName As String = "SHIP RETURN LABEL"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMIShipReturnLabel(strScreenName))
        End Sub

        Private Sub prodTMI_Main_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_Ship.Click
            Const strTabPageTitle As String = "Ship Product"
            Const strScreenName As String = "SHIP PRODUCT"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMISShipProduct(strScreenName))
        End Sub
        Private Sub prodTMI_Main_Repair_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_Repair.Click
            Const strTabPageTitle As String = "Repair"
            Const strScreenName As String = "REPAIR"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMIRepairBilling(, PSS.Data.Buisness.TMI.CUSTOMERID, strScreenName, , ))
        End Sub

        Private Sub prodTMI_Main_Reports_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_Reports.Click
            Const strTabPageTitle As String = "Reports"
            Const strScreenName As String = "Reports"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMIReports(strScreenName, PSS.Data.Buisness.TMI.CUSTOMERID))
        End Sub

        Private Sub prodTMI_Main_AQL_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_AQL.Click
            Const strTabPageTitle As String = "AQL"
            Const strScreenName As String = "AQL"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMI_QC(strScreenName, PSS.Data.Buisness.TMI.CUSTOMERID, 4))
        End Sub
        Private Sub prodTMI_Main_OBA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTMI_Main_OBA.Click
            Const strTabPageTitle As String = "OBA"
            Const strScreenName As String = "OBA"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TMI_OBA(strScreenName, PSS.Data.Buisness.TMI.CUSTOMERID, 5))
        End Sub

        '*******************************************
        'PRODUCT => TRACFONE
        '*******************************************
        Private Sub prodTF_Main_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Admin.Click
            Const strTabPageTitle As String = "TF Admin"
            Const strScreenName As String = "Admin Functions"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmAdmin())
        End Sub

        Private Sub prodTF_Main_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Billing.Click
            Const strTabPageTitle As String = "Billing"
            Const strScreenName As String = "Billing"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(1, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName, 0))
        End Sub

        Private Sub prodTF_Main_Tech_BER_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Tech_BER.Click
            Const strTabPageTitle As String = "BER Screen"
            Const strScreenName As String = "BER Screen"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmBERScreen(PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
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

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(2, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, strScreenName))
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
        Private Sub prodTF_Main_Test_SoftRef_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Test_SoftRef.Click
            Const strTabPageTitle As String = "Software Refurbish"
            Const strScreenName As String = "Software Refurbish"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.frmSoftwareRefurbish(strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 14))
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

        Private Sub prodTF_Main_Warehouse_AssignBatteryCover_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTF_Main_Warehouse_AssignBatteryCover.Click
            Const strTabPageTitle As String = "Assigning Battery Cover"
            Const strScreenName As String = "Assigning Battery Cover"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.TracFone.AssignBateryCover(strScreenName))
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

        ''*****************************************
        ''Comment by Lan 6/19/2008 INACTIVE SCREEN
        ''*****************************************
        'Private Sub ATCReceiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodATCLEFileRec.Click
        '    Const strTabPageTitle As String = "File Receiving"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frmFileRec())
        'End Sub

        'Private Sub TechProg_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTechProg.Click
        '    Const strTabPageTitle As String = "Technician (Programming)"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Programming.frmProgramming())
        'End Sub
        ''*****************************************

        Private Sub TechHS_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTechHS.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech())
        End Sub

        Private Sub PreTest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodPreTest.Click
            Const strTabPageTitle As String = "PreTest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New pretest.frmPreTest())
        End Sub

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

        'Private Sub prodTechTools_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTechTools.Click
        '    Const strTabPageTitle As String = "Cellular Tray Assignment"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New TechTools.TechTools())
        'End Sub

        Private Sub prodCreatePSSISNs_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodCreatePSSISNs.Click
            Const strTabPageTitle As String = "Create PSSI Serial Numbers"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New PSSISNs.CreatePSSISNs())
        End Sub

        '******************************************
        'COST CENTER
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
        '******************************************

        Private Sub admDefineRMA_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles admDefineRMA.Click
            Const strTabPageTitle As String = "Define RMA Defaults"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Receiving.frmPREdefineRMArec())
        End Sub

        'Private Sub prodTrayScan_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTrayScan.Click
        '    Const strTabPageTitle As String = "End of Line Tray Scan"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmWCTrayScan())
        'End Sub

        Private Sub prodQC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodQC.Click
            Const strTabPageTitle As String = "Quality Control"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmQC())
        End Sub

        '***********************************
        'MESSAGING
        '***********************************
        Private Sub prodMessagingMain_Label_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Label.Click
            Const strTabPageTitle As String = "Messaging Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessLabel())
        End Sub

        'American Messaging
        Private Sub prodMessaging_AMS_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, 14))
        End Sub
        Private Sub prodReceive_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_OptConsole.Click
            Const strTabPageTitle As String = "Messaging Operations Console"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessConsole())
        End Sub

        'Skytel
        Private Sub prodMessagingMain_SkyTel_DBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_DBRManifest.Click
            Const strTabPageTitle As String = "SkyTel Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_SkyTel_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_SkyTel_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_Rec.Click
            Const strTabPageTitle As String = "SkyTel Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_SkyTel_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_BB.Click
            Const strTabPageTitle As String = "SkyTel Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_SkyTel_LoadASN_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_LoadASN.Click
            Const strTabPageTitle As String = "Load ASN"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelLoadASN())
        End Sub
        Private Sub prodMessagingMain_SkyTel_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_SkyTel_Ship.Click
            Const strTabPageTitle As String = "SkyTel Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strTabPageTitle, PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID))
        End Sub

        ''Morris Communication
        Private Sub prodMessagingMain_MorrisCom_DBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_DBRManifest.Click
            Const strTabPageTitle As String = "Morris Comm. Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_Rec.Click
            Const strTabPageTitle As String = "Morris Communication Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_BB.Click
            Const strTabPageTitle As String = "Morris Communication Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_MorrisCom_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_MorrisCom_Ship.Click
            Const strTabPageTitle As String = "Morris Communication Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strTabPageTitle, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID))
        End Sub

        'Propage
        Private Sub prodMessagingMain_Propage_DBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_DBRManifest.Click
            Const strTabPageTitle As String = "Propage Other Ship Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_Billing.Click
            Const strTabPageTitle As String = "Technician (High Speed)"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_Rec.Click
            Const strTabPageTitle As String = "Propage Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelRec(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_BB.Click
            Const strTabPageTitle As String = "Propage Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Propage_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Propage_Ship.Click
            Const strTabPageTitle As String = "Propage Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strTabPageTitle, PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID))
        End Sub

        'Aquis
        Private Sub prodMessagingMain_Aquis_ModelSetup_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_ModelSetup.Click
            Const strTabPageTitle As String = "Aquis Model Setup"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAquisModelSetup())
        End Sub
        Private Sub prodMessagingMain_Aquis_WHRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_WHRec.Click
            Const strTabPageTitle As String = "Aquis WH Rec"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAquisWHRec())
        End Sub
        Private Sub prodMessagingMain_Aquis_ProdRec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_ProdRec.Click
            Const strTabPageTitle As String = "Aquis Prod Rec"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.frmAquisProdRec())
        End Sub
        Private Sub prodMessagingMain_Aquis_Billing_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_Billing.Click
            Const strTabPageTitle As String = "Billing"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New techscreen.frmNewTech(, PSS.Data.Buisness.Messaging.Aquis_Cust_ID, strTabPageTitle))
        End Sub
        Private Sub prodMessagingMain_Aquis_BB_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_BB.Click
            Const strTabPageTitle As String = "Aquis Build Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSkyTelBuildShipBox(strTabPageTitle, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID))
        End Sub
        Private Sub prodMessagingMain_Aquis_Ship_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessagingMain_Aquis_Ship.Click
            Const strTabPageTitle As String = "Aquis Ship Box"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessProdShip(strTabPageTitle, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID))
        End Sub

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
#End Region

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

        '************************
        'SENSUS 
        '************************
        Private Sub prodSensus_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSensus_Admin.Click
            Const strTabPageTitle As String = "Sensus Admin"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSensusAdmin())
        End Sub
        Private Sub prodSensus_BSPallet_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSensus_BSPallet.Click
            Const strTabPageTitle As String = "Sensus Build Ship Pallet"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSensusBuildShipPallet())
        End Sub
        Private Sub prodSensus_PackingList_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSensus_PackingList.Click
            Const strTabPageTitle As String = "Packing List"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSensusPackingList())
        End Sub
        Private Sub prodSensus_Search_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSensus_Search.Click
            Const strTabPageTitle As String = "Sensus Search"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSensusSearch())
        End Sub

        '************************
        'PRODUCTION => SYX 
        '************************
        Private Sub prodSyx_Rec_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Rec.Click
            Const strTabPageTitle As String = "Syx Rec"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxRec())
        End Sub
        Private Sub prodSyx_Triage_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Triage.Click
            Const strTabPageTitle As String = "Syx Triage"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.syxtriage("TRIAGE", PSS.Data.Buisness.Syx.CUSTOMERID))
        End Sub
        Private Sub prodSyx_TechBilling_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_TechBilling.Click
            Const strTabPageTitle As String = "Tech/Billing"
            Dim win As Crownwood.Magic.Controls.TabPage

            'If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.techscreen.frmNewTech(, PSS.Data.Buisness.Syx.CUSTOMERID, "Tech/Billing", , PSS.Data.Buisness.Syx.ScreenID_Billing))
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxTechBilling(, PSS.Data.Buisness.Syx.CUSTOMERID, "REPAIR", , PSS.Data.Buisness.Syx.ScreenID_Billing))
        End Sub
        Private Sub prodSyx_QC_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_FQA.Click, prodSyx_AQL.Click
            Dim strTabPageTitle As String = ""
            Dim strScreenName As String = ""
            Dim iQCType As Integer = 0
            If sender.text.ToString = "FQA" Then
                strTabPageTitle = "FQA" : strScreenName = "FQA" : iQCType = 2
            ElseIf sender.text.ToString = "AQL" Then
                strTabPageTitle = "AQL" : strScreenName = "AQL" : iQCType = 4
            End If
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxQC(strScreenName, PSS.Data.Buisness.Syx.CUSTOMERID, iQCType))
        End Sub
        Private Sub prodSyx_Kitting_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Kitting.Click
            Const strTabPageTitle As String = "Syx Kitting"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxKitting())
        End Sub
        Private Sub prodSyx_Produce_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Produce.Click
            Const strTabPageTitle As String = "Syx Produce"
            Const strScreenName As String = "Produce"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxProduce(strScreenName))
        End Sub
        Private Sub prodSyx_Warehouse_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Warehouse.Click
            Const strTabPageTitle As String = "Syx Warehouse"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSendPalletPackingListFiles(2485))
        End Sub

        Private Sub prodSyx_PartsReceiving_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_PartsReceiving.Click
            Const strTabPageTitle As String = "Syx Parts Receiving"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxPartsReceiving())
        End Sub
        Private Sub prodSyx_PartsConsumption_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_PartsConsumption.Click
            Const strTabPageTitle As String = "Parts Consumption"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxPartsConsumption())
        End Sub

        Private Sub prodSyx_Reports_Excel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Reports_Excel.Click
            Const strTabPageTitle As String = "Syx Excel Reports"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxExcelReports())
        End Sub

        Private Sub prodSyx_Reports_Crystal_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Reports_Crystal.Click
            Const strTabPageTitle As String = "Syx Crystal Reports"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxCrystalReports())
        End Sub

        Private Sub prodSyx_Tools_Admin_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_Tools_Admin.Click
            Const strTabPageTitle As String = "Syx Admin Tools"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxAdminTools())
        End Sub
        Private Sub prodSyx_EditModel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_EditModel.Click
            Const strTabPageTitle As String = "Edit Model"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxEditModel())
        End Sub
        Private Sub prodSyx_WipTransf_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_WipTransf.Click
            Const strTabPageTitle As String = "Wip Tranfer"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.SyxWIPTranser(PSS.Data.Buisness.Syx.CUSTOMERID))
        End Sub
        Private Sub prodSyx_ImageLib_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodSyx_ImageLib.Click
            Const strTabPageTitle As String = "Image Library"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.syxImageLibrary())
        End Sub

        '************************
        'PRODUCTION => Game Stop
        '************************
        Private Sub prodGamestopOpts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodGaming_GS_Opts.Click
            Const strTabPageTitle As String = "Gamestop Operations"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmGamestopOperations())
        End Sub

        Private Sub prodAMDBRManifest_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_DBRManifest.Click
            Const strTabPageTitle As String = "AM Manifest"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAMDBRManifest(strTabPageTitle, PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID))
        End Sub

        Private Sub prodMessaging_AMS_MapLvl3RepReason_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_MapLvl3RepReason.Click
            Const strTabPageTitle As String = "AMS-Map Level3 Rep Reason"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Messaging.AmericanMessaging.frmAmsLevel3Map())
        End Sub

        ''*****************************************
        ''Commented by Lan 10/31/2007 INACTIVE SCREEN
        ''*****************************************
        'Private Sub prodAssignWIPOwnership_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAssignWIPOwnership.Click
        '    Const strTabPageTitle As String = "Assign WIP Ownership"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAssignWIPOwnership())
        'End Sub

        'Private Sub prodReadyToTransfer_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodReadyToTransfer.Click
        '    Const strTabPageTitle As String = "Ready to Transfer WIP"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmReadyToTransfer())
        'End Sub

        'Private Sub prodTempTransferWIPOwnership_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodTempTransferWIPOwnership.Click
        '    Const strTabPageTitle As String = "Temporarily Transfer WIP Ownership"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmTemporarilyTransferWIPOwnership())
        'End Sub

        'Private Sub prodAwaitingParts_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodAwaitingParts.Click
        '    Const strTabPageTitle As String = "Awaiting Parts"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmAwaitingParts())
        'End Sub
        ''*****************************************

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

        Private Sub csOrderEntry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csOrderEntry.Click
            Const strTabPageTitle As String = "Order Entry"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New OrderEntry.frmOrderEntrySelect())
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

        Private Sub csCustCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csCustCompany.Click
            Const strTabPageTitle As String = "Customer"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmCustmaintNew())
        End Sub

        Private Sub csWOPreload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csWOPreload.Click
            Const strTabPageTitle As String = "Workorder Preload"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New CustomerMaint.frmPreload_Workorder(2))
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

        '***************************************************
        'DOCUMENTS MENU
        '***************************************************
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

        '***************************************************
        'ENGINEERING MENU
        '***************************************************
        Private Sub engManageManufCodes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles engManageManufCodes.Click
            Const strTabPageTitle As String = "Warranty Code Map"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.codes.frmManageManufCodes())
        End Sub

        '***************************************************

        Private Sub About_Click(ByVal sender As Object, ByVal e As EventArgs) Handles helpAbout.Click
            Dim win As New PSS.Gui.About.AboutWin()
            win.ShowDialog()
        End Sub

        '''prodBetterSearch
        'Private Sub prodBetterSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodBetterSearch.Click
        '    Const strTabPageTitle As String = "New Search Engine"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmBetterSearch())
        'End Sub

        Private Sub Search_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodSearch.Click
            Const strTabPageTitle As String = "Search"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Search.SearchWin())
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

        Public Sub rptAdminWIPDetailByLocation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptAdminWIPDetailByLocation.Click
            Const strTabPageTitle As String = "WIP Detail by Location"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New frmWIPReports())
                OpenWin(strTabPageTitle, win, New WIP.frmWIPReports_1())
            End If
        End Sub

        'rptMessagingWIPByCustomerAndModel
        Public Sub rptMessagingWIPByCustomerAndModel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptMessagingWIPByCustomerAndModel.Click
            Const strTabPageTitle As String = "Messaging WIP by Customer and Model"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Messaging WIP by Customer and Model.rpt"))
        End Sub

        ''rptATCLEReworkWIPbyModel
        'Private Sub rptATCLEReworkWIPbyModel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles rptATCLEReworkWIPbyModel.Click
        '    Const strTabPageTitle As String = "Admin ATCLE Rework WIP by Model"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("ATCLE Rework WIP by Model.rpt"))
        'End Sub

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

        Private Sub smAdmin_Revenue_Summary_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles smAdmin_Revenue_Summary.Click
            Const strTabPageTitle As String = "Admin Revenue Summary Special Projects"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_SUMMARY_SPECIAL_PROJECTS))
            End If
            'Dim strTabPageTitle As String = ""
            'Dim win As Crownwood.Magic.Controls.TabPage

            'Select Case sender.text
            '    Case "Summary"
            '        strTabPageTitle = "Admin Revenue Summary"
            '    Case "Detail"
            '        strTabPageTitle = "Admin Revenue Detail"
            'End Select

            'If Not CheckOpenTabs(strTabPageTitle) Then
            '    OpenWin(strTabPageTitle, win, New frmAdminRevenueRpt(strTabPageTitle))
            'End If
        End Sub

        Private Sub smAdmin_Revenue_Detail_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles smAdmin_Revenue_Detail.Click
            Const strTabPageTitle As String = "Admin Revenue Detail Special Projects"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.ADMIN_REVENUE_DETAIL_SPECIAL_PROJECTS))
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

        'Private Sub rptCellSpec_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptCellSpec.Click
        '    Const strTabPageTitle As String = "Special Excel Reports"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmExcelOutput())
        'End Sub

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

        'Private Sub rptAdminUSAMobWORpt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rptAdminUSAMobWORpt.Click
        '    Const strTabPageTitle As String = "USA Mobility WO Report"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.ReportViewer.frmUSAMobWOReport())
        'End Sub

        'rptAdminQCRpt & rptAdminPretestRpt
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
        '***************************

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
                'OpenWin(strTabPageTitle, win, New RptViewer("Bill_EmplCnt.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.BILL_EMPLOYEE_COUNT))
            End If
        End Sub

        '****************************************
        'FINANCE
        '****************************************
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

        '****************************************

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

        '***************************
        'Report => Human Resource 
        '***************************
        'Private Sub hrLeaveCnt_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrLeaveCnt.Click
        '    Const strTabPageTitle As String = "Human Resource Leave Count"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("HR_LeaveCnt.rpt"))
        'End Sub

        'Private Sub hrLeave_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrLeave.Click
        '    Const strTabPageTitle As String = "Human Resource Leave"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("HR_Leave.rpt"))
        'End Sub

        'Private Sub hrWorkhours_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles hrWorkHours.Click
        '    Const strTabPageTitle As String = "Human Resource Workhours"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("HR_Workhours.rpt"))
        'End Sub

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

        ''smQualityControl QCTechFailureRate
        Private Sub QCTechFailureRate_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles QCTechFailureRate.Click
            Const strTabPageTitle As String = "Technician Failure Rate"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then
                'OpenWin(strTabPageTitle, win, New RptViewer("QC_Tech Failure Rate Report.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.TECHNICIAN_FAILURE_RATE))
            End If
        End Sub

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
                'If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New RptViewer("Production Rcvd Quantity by Customer.rpt"))
                OpenWin(strTabPageTitle, win, New frmReportParameters(strTabPageTitle, Data.CrystalReports.Report_Call.PRODUCTION_RECEIVED_QTY_BY_CUST))
            End If
        End Sub

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

        Private Sub DemanData_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodMessaging_AMS_DemandData.Click
            Const strTabPageTitle As String = "Messaging Product WIP"
            Dim win As Crownwood.Magic.Controls.TabPage
            Dim objCrystalReports As PSS.Data.CrystalReports

            If Not CheckOpenTabs(strTabPageTitle & " Report") Then
                Cursor.Current = Cursors.WaitCursor
                Me.Enabled = False

                objCrystalReports = New PSS.Data.CrystalReports(strTabPageTitle, Data.CrystalReports.Report_Call.MESSAGING_PRODUCT_WIP)

                win = New Crownwood.Magic.Controls.TabPage(strTabPageTitle & " Report", New RptViewer(strTabPageTitle & " Push.rpt", objCrystalReports.GetReportData(), objCrystalReports.GetSubReportNames()))
                MainWin.wrkArea.TabPages.Add(win)
                win.Selected = True

                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End If

            'If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmMessDemandData())
        End Sub

        '***********************
        'WAREHOUSE
        '***********************
        Public Sub ProdSendPalletPackingListFiles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles prodWarehouse_SendPalletPackingListFiles.Click
            Const strTabPageTitle As String = "Manifest Processing"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmSendPalletPackingListFiles())
        End Sub
        Private Sub prodSensus_DockShipData_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWarehouse_DockShipment.Click
            Const strTabPageTitle As String = "Dock Shipment"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New frmDockShipping())
        End Sub
        'Private Sub prodWarehouse_OrderFulfilment_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWarehouse_OrderFulfilment.Click
        '    Const strTabPageTitle As String = "Order Fulfilment"
        '    Dim win As Crownwood.Magic.Controls.TabPage

        '    If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmOrderfulfilment())
        'End Sub
        Private Sub prodWarehouse_PrintUPCLabel_Clicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles prodWarehouse_PrintUPCLabel.Click
            Const strTabPageTitle As String = "Print UPC Label"
            Dim win As Crownwood.Magic.Controls.TabPage

            If Not CheckOpenTabs(strTabPageTitle) Then OpenWin(strTabPageTitle, win, New Gui.Warehouse.frmPrintUPCLabel())
        End Sub


    End Class

End Namespace
