
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text.RegularExpressions

Namespace Gui.AIG
    Public Class frmDataManagement
        Inherits System.Windows.Forms.Form

        Private _booLoadData As Boolean = False

        'For Add/EditView RMA data-------------------------------
        Private _objNIDataM As NIDataManagement
        Private _objNI As NI
        Private _iMenuCustID As Integer
        Private _iGroupID As Integer
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _bIsTheFirstTime As Boolean = True
        Private _tmpStrText As String = ""
        Private _IsEndUserData As Boolean = False
        Private _IsBulkData As Boolean = False
        Private _booSelectModel As Boolean = True

        'Approval-------------------------------------------------
        Private _objAIG As PSS.Data.Buisness.AIG
        Private _iWO_ID As Integer = 0
        Private _iCellOpt_ID As Integer = 0
        Private _strWorkStation As String = ""
        Private _iApprovalCondition As Integer = 0  '1=Quote Approval, 2=Warranty Approval, 3=SN Discrepancy Approval
        Private _EstimatedPartCost As Double = 0
        Private _dbTotalCharge As Double = 0.0
        '---------------------------------------------------------

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal iGroupID As Integer, _
                       Optional ByVal booSelectModel As Boolean = True)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            Me._iGroupID = iGroupID
            _booSelectModel = booSelectModel
            Me._objAIG = New PSS.Data.Buisness.AIG()
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
        Friend WithEvents tpRMAData As System.Windows.Forms.TabPage
        Friend WithEvents cmbTypeSwitch As System.Windows.Forms.ComboBox
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents rbtAddNew As System.Windows.Forms.RadioButton
        Friend WithEvents rbtView As System.Windows.Forms.RadioButton
        Friend WithEvents rbtEdit As System.Windows.Forms.RadioButton
        Friend WithEvents tdgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgData_Detail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlDataUpdate As System.Windows.Forms.Panel
        Friend WithEvents lblUpdateReason As System.Windows.Forms.Label
        Friend WithEvents UpdateReason As System.Windows.Forms.TextBox
        Friend WithEvents S_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblWO_Quantity As System.Windows.Forms.Label
        Friend WithEvents WO_Quantity As System.Windows.Forms.TextBox
        Friend WithEvents lblPurchaseDate As System.Windows.Forms.Label
        Friend WithEvents lblSenderReference As System.Windows.Forms.Label
        Friend WithEvents SenderReference As System.Windows.Forms.TextBox
        Friend WithEvents lblAccount As System.Windows.Forms.Label
        Friend WithEvents Account As System.Windows.Forms.TextBox
        Friend WithEvents lblLanguage As System.Windows.Forms.Label
        Friend WithEvents Language As System.Windows.Forms.TextBox
        Friend WithEvents lblErrorDescription As System.Windows.Forms.Label
        Friend WithEvents ErrorDescription As System.Windows.Forms.TextBox
        Friend WithEvents lblDefectType2 As System.Windows.Forms.Label
        Friend WithEvents DefectType2 As System.Windows.Forms.TextBox
        Friend WithEvents lblDefectType1 As System.Windows.Forms.Label
        Friend WithEvents PurchaseDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Warranty As System.Windows.Forms.ComboBox
        Friend WithEvents lblWarranty As System.Windows.Forms.Label
        Friend WithEvents RepairType As System.Windows.Forms.ComboBox
        Friend WithEvents lblRepairType As System.Windows.Forms.Label
        Friend WithEvents ServiceLevel As System.Windows.Forms.ComboBox
        Friend WithEvents lblServiceLevel As System.Windows.Forms.Label
        Friend WithEvents DefectType1 As System.Windows.Forms.TextBox
        Friend WithEvents lblHardwareSerial As System.Windows.Forms.Label
        Friend WithEvents HardwareSerial As System.Windows.Forms.TextBox
        Friend WithEvents Device_DateShip As System.Windows.Forms.Label
        Friend WithEvents TrackCreatedDateTime As System.Windows.Forms.Label
        Friend WithEvents lblFinal_PSSI2Cust_TrackNo As System.Windows.Forms.Label
        Friend WithEvents RowID As System.Windows.Forms.TextBox
        Friend WithEvents pnlSelectCountryState As System.Windows.Forms.Panel
        Friend WithEvents pnlDataUpdate_Center As System.Windows.Forms.Panel
        Friend WithEvents cmbCountry2 As System.Windows.Forms.ComboBox
        Friend WithEvents cmbState2 As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCountry As System.Windows.Forms.ComboBox
        Friend WithEvents cmbState As System.Windows.Forms.ComboBox
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents Cntry_ID As System.Windows.Forms.TextBox
        Friend WithEvents State_ID As System.Windows.Forms.TextBox
        Friend WithEvents btnSelectCountryState As System.Windows.Forms.Button
        Friend WithEvents lblZipCode As System.Windows.Forms.Label
        Friend WithEvents ZipCode As System.Windows.Forms.TextBox
        Friend WithEvents WO_ID As System.Windows.Forms.TextBox
        Friend WithEvents lblPanel As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents Status As System.Windows.Forms.TextBox
        Friend WithEvents Cust2PSSI_TrackNo As System.Windows.Forms.TextBox
        Friend WithEvents lblPSSI2Cust_TrackNo As System.Windows.Forms.Label
        Friend WithEvents PSSI2Cust_TrackNo As System.Windows.Forms.TextBox
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents Email As System.Windows.Forms.TextBox
        Friend WithEvents lblCountry As System.Windows.Forms.Label
        Friend WithEvents Country As System.Windows.Forms.TextBox
        Friend WithEvents lblState As System.Windows.Forms.Label
        Friend WithEvents State As System.Windows.Forms.TextBox
        Friend WithEvents lblCity As System.Windows.Forms.Label
        Friend WithEvents City As System.Windows.Forms.TextBox
        Friend WithEvents lblAddress2 As System.Windows.Forms.Label
        Friend WithEvents Address2 As System.Windows.Forms.TextBox
        Friend WithEvents lblAddress1 As System.Windows.Forms.Label
        Friend WithEvents Address1 As System.Windows.Forms.TextBox
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents Phone As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents EW_ID As System.Windows.Forms.TextBox
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents lblRMANo As System.Windows.Forms.Label
        Friend WithEvents RMA_No As System.Windows.Forms.TextBox
        Friend WithEvents Final_PSSI2Cust_TrackNo As System.Windows.Forms.TextBox
        Friend WithEvents lblCust2PSSI_TrackNo As System.Windows.Forms.Label
        Friend WithEvents lblRecNum_Detail As System.Windows.Forms.Label
        Friend WithEvents lblCurrentRecNum_Detail As System.Windows.Forms.Label
        Friend WithEvents lblCurrentRecNum As System.Windows.Forms.Label
        Friend WithEvents lblRecNum As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents tpApproval As System.Windows.Forms.TabPage
        Friend WithEvents btnApproval As System.Windows.Forms.Button
        Friend WithEvents lblDisplay As System.Windows.Forms.Label
        Friend WithEvents btnRefreshApproval As System.Windows.Forms.Button
        Friend WithEvents tdgDataApproval As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents cboApprovedBy As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents pnlApprovedBy As System.Windows.Forms.Panel
        Friend WithEvents cboApprovedVal As C1.Win.C1List.C1Combo
        Friend WithEvents pnlEnterModel As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtMake As System.Windows.Forms.TextBox
        Friend WithEvents txtModel As System.Windows.Forms.TextBox
        Friend WithEvents pnlSelectModel As System.Windows.Forms.Panel
        Friend WithEvents lblProduct As System.Windows.Forms.Label
        Friend WithEvents pnlProduct As System.Windows.Forms.Panel
        Friend WithEvents btnProductSelect As System.Windows.Forms.Button
        Friend WithEvents btnProductClose As System.Windows.Forms.Button
        Friend WithEvents Product As System.Windows.Forms.TextBox
        Friend WithEvents cmbProduct As System.Windows.Forms.ComboBox
        Friend WithEvents btnSelectProduct As System.Windows.Forms.Button
        Friend WithEvents Prod_Code As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDataManagement))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpRMAData = New System.Windows.Forms.TabPage()
            Me.pnlDataUpdate = New System.Windows.Forms.Panel()
            Me.btnSelectProduct = New System.Windows.Forms.Button()
            Me.pnlProduct = New System.Windows.Forms.Panel()
            Me.cmbProduct = New System.Windows.Forms.ComboBox()
            Me.btnProductSelect = New System.Windows.Forms.Button()
            Me.btnProductClose = New System.Windows.Forms.Button()
            Me.pnlSelectModel = New System.Windows.Forms.Panel()
            Me.Prod_Code = New System.Windows.Forms.TextBox()
            Me.Product = New System.Windows.Forms.TextBox()
            Me.lblProduct = New System.Windows.Forms.Label()
            Me.pnlEnterModel = New System.Windows.Forms.Panel()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtMake = New System.Windows.Forms.TextBox()
            Me.txtModel = New System.Windows.Forms.TextBox()
            Me.lblServiceLevel = New System.Windows.Forms.Label()
            Me.ServiceLevel = New System.Windows.Forms.ComboBox()
            Me.lblUpdateReason = New System.Windows.Forms.Label()
            Me.UpdateReason = New System.Windows.Forms.TextBox()
            Me.S_ID = New System.Windows.Forms.TextBox()
            Me.lblWO_Quantity = New System.Windows.Forms.Label()
            Me.WO_Quantity = New System.Windows.Forms.TextBox()
            Me.lblPurchaseDate = New System.Windows.Forms.Label()
            Me.lblSenderReference = New System.Windows.Forms.Label()
            Me.SenderReference = New System.Windows.Forms.TextBox()
            Me.lblAccount = New System.Windows.Forms.Label()
            Me.Account = New System.Windows.Forms.TextBox()
            Me.lblLanguage = New System.Windows.Forms.Label()
            Me.Language = New System.Windows.Forms.TextBox()
            Me.lblErrorDescription = New System.Windows.Forms.Label()
            Me.ErrorDescription = New System.Windows.Forms.TextBox()
            Me.lblDefectType2 = New System.Windows.Forms.Label()
            Me.DefectType2 = New System.Windows.Forms.TextBox()
            Me.lblDefectType1 = New System.Windows.Forms.Label()
            Me.PurchaseDate = New System.Windows.Forms.DateTimePicker()
            Me.Warranty = New System.Windows.Forms.ComboBox()
            Me.lblWarranty = New System.Windows.Forms.Label()
            Me.RepairType = New System.Windows.Forms.ComboBox()
            Me.lblRepairType = New System.Windows.Forms.Label()
            Me.DefectType1 = New System.Windows.Forms.TextBox()
            Me.lblHardwareSerial = New System.Windows.Forms.Label()
            Me.HardwareSerial = New System.Windows.Forms.TextBox()
            Me.Device_DateShip = New System.Windows.Forms.Label()
            Me.TrackCreatedDateTime = New System.Windows.Forms.Label()
            Me.lblFinal_PSSI2Cust_TrackNo = New System.Windows.Forms.Label()
            Me.RowID = New System.Windows.Forms.TextBox()
            Me.pnlSelectCountryState = New System.Windows.Forms.Panel()
            Me.pnlDataUpdate_Center = New System.Windows.Forms.Panel()
            Me.cmbCountry2 = New System.Windows.Forms.ComboBox()
            Me.cmbState2 = New System.Windows.Forms.ComboBox()
            Me.cmbCountry = New System.Windows.Forms.ComboBox()
            Me.cmbState = New System.Windows.Forms.ComboBox()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.Cntry_ID = New System.Windows.Forms.TextBox()
            Me.State_ID = New System.Windows.Forms.TextBox()
            Me.btnSelectCountryState = New System.Windows.Forms.Button()
            Me.lblZipCode = New System.Windows.Forms.Label()
            Me.ZipCode = New System.Windows.Forms.TextBox()
            Me.WO_ID = New System.Windows.Forms.TextBox()
            Me.lblPanel = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.Status = New System.Windows.Forms.TextBox()
            Me.Cust2PSSI_TrackNo = New System.Windows.Forms.TextBox()
            Me.lblPSSI2Cust_TrackNo = New System.Windows.Forms.Label()
            Me.PSSI2Cust_TrackNo = New System.Windows.Forms.TextBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.Email = New System.Windows.Forms.TextBox()
            Me.lblCountry = New System.Windows.Forms.Label()
            Me.Country = New System.Windows.Forms.TextBox()
            Me.lblState = New System.Windows.Forms.Label()
            Me.State = New System.Windows.Forms.TextBox()
            Me.lblCity = New System.Windows.Forms.Label()
            Me.City = New System.Windows.Forms.TextBox()
            Me.lblAddress2 = New System.Windows.Forms.Label()
            Me.Address2 = New System.Windows.Forms.TextBox()
            Me.lblAddress1 = New System.Windows.Forms.Label()
            Me.Address1 = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.Phone = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.EW_ID = New System.Windows.Forms.TextBox()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.lblRMANo = New System.Windows.Forms.Label()
            Me.RMA_No = New System.Windows.Forms.TextBox()
            Me.Final_PSSI2Cust_TrackNo = New System.Windows.Forms.TextBox()
            Me.lblCust2PSSI_TrackNo = New System.Windows.Forms.Label()
            Me.tdgData_Detail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.rbtAddNew = New System.Windows.Forms.RadioButton()
            Me.rbtView = New System.Windows.Forms.RadioButton()
            Me.rbtEdit = New System.Windows.Forms.RadioButton()
            Me.cmbTypeSwitch = New System.Windows.Forms.ComboBox()
            Me.lblCurrentRecNum_Detail = New System.Windows.Forms.Label()
            Me.lblCurrentRecNum = New System.Windows.Forms.Label()
            Me.lblRecNum = New System.Windows.Forms.Label()
            Me.lblRecNum_Detail = New System.Windows.Forms.Label()
            Me.tpApproval = New System.Windows.Forms.TabPage()
            Me.cboApprovedVal = New C1.Win.C1List.C1Combo()
            Me.pnlApprovedBy = New System.Windows.Forms.Panel()
            Me.cboApprovedBy = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.tdgDataApproval = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnRefreshApproval = New System.Windows.Forms.Button()
            Me.lblDisplay = New System.Windows.Forms.Label()
            Me.btnApproval = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.tpRMAData.SuspendLayout()
            Me.pnlDataUpdate.SuspendLayout()
            Me.pnlProduct.SuspendLayout()
            Me.pnlSelectModel.SuspendLayout()
            Me.pnlEnterModel.SuspendLayout()
            Me.pnlSelectCountryState.SuspendLayout()
            Me.pnlDataUpdate_Center.SuspendLayout()
            CType(Me.tdgData_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpApproval.SuspendLayout()
            CType(Me.cboApprovedVal, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlApprovedBy.SuspendLayout()
            CType(Me.tdgDataApproval, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpRMAData, Me.tpApproval})
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(16, 16)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1192, 680)
            Me.TabControl1.TabIndex = 0
            '
            'tpRMAData
            '
            Me.tpRMAData.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDataUpdate, Me.tdgData_Detail, Me.tdgData, Me.btnRefresh, Me.rbtAddNew, Me.rbtView, Me.rbtEdit, Me.cmbTypeSwitch, Me.lblCurrentRecNum_Detail, Me.lblCurrentRecNum, Me.lblRecNum, Me.lblRecNum_Detail})
            Me.tpRMAData.Location = New System.Drawing.Point(4, 22)
            Me.tpRMAData.Name = "tpRMAData"
            Me.tpRMAData.Size = New System.Drawing.Size(1184, 654)
            Me.tpRMAData.TabIndex = 1
            Me.tpRMAData.Text = "Add/Edit/View RMA Data"
            '
            'pnlDataUpdate
            '
            Me.pnlDataUpdate.BackColor = System.Drawing.Color.LightGray
            Me.pnlDataUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlDataUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSelectProduct, Me.pnlProduct, Me.pnlSelectModel, Me.pnlEnterModel, Me.lblServiceLevel, Me.ServiceLevel, Me.lblUpdateReason, Me.UpdateReason, Me.S_ID, Me.lblWO_Quantity, Me.WO_Quantity, Me.lblPurchaseDate, Me.lblSenderReference, Me.SenderReference, Me.lblAccount, Me.Account, Me.lblLanguage, Me.Language, Me.lblErrorDescription, Me.ErrorDescription, Me.lblDefectType2, Me.DefectType2, Me.lblDefectType1, Me.PurchaseDate, Me.Warranty, Me.lblWarranty, Me.RepairType, Me.lblRepairType, Me.DefectType1, Me.lblHardwareSerial, Me.HardwareSerial, Me.Device_DateShip, Me.TrackCreatedDateTime, Me.lblFinal_PSSI2Cust_TrackNo, Me.RowID, Me.pnlSelectCountryState, Me.Cntry_ID, Me.State_ID, Me.btnSelectCountryState, Me.lblZipCode, Me.ZipCode, Me.WO_ID, Me.lblPanel, Me.lblStatus, Me.Status, Me.Cust2PSSI_TrackNo, Me.lblPSSI2Cust_TrackNo, Me.PSSI2Cust_TrackNo, Me.lblEmail, Me.Email, Me.lblCountry, Me.Country, Me.lblState, Me.State, Me.lblCity, Me.City, Me.lblAddress2, Me.Address2, Me.lblAddress1, Me.Address1, Me.lblPhone, Me.Phone, Me.lblName, Me.txtName, Me.EW_ID, Me.btnUpdate, Me.lblRMANo, Me.RMA_No, Me.Final_PSSI2Cust_TrackNo, Me.lblCust2PSSI_TrackNo})
            Me.pnlDataUpdate.Location = New System.Drawing.Point(8, 232)
            Me.pnlDataUpdate.Name = "pnlDataUpdate"
            Me.pnlDataUpdate.Size = New System.Drawing.Size(1168, 392)
            Me.pnlDataUpdate.TabIndex = 69
            '
            'btnSelectProduct
            '
            Me.btnSelectProduct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectProduct.Location = New System.Drawing.Point(616, 92)
            Me.btnSelectProduct.Name = "btnSelectProduct"
            Me.btnSelectProduct.Size = New System.Drawing.Size(56, 32)
            Me.btnSelectProduct.TabIndex = 2024
            Me.btnSelectProduct.Text = "Select Product"
            '
            'pnlProduct
            '
            Me.pnlProduct.BackColor = System.Drawing.Color.Lavender
            Me.pnlProduct.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbProduct, Me.btnProductSelect, Me.btnProductClose})
            Me.pnlProduct.Location = New System.Drawing.Point(672, 88)
            Me.pnlProduct.Name = "pnlProduct"
            Me.pnlProduct.Size = New System.Drawing.Size(256, 40)
            Me.pnlProduct.TabIndex = 2023
            '
            'cmbProduct
            '
            Me.cmbProduct.Location = New System.Drawing.Point(8, 8)
            Me.cmbProduct.Name = "cmbProduct"
            Me.cmbProduct.Size = New System.Drawing.Size(128, 21)
            Me.cmbProduct.TabIndex = 0
            '
            'btnProductSelect
            '
            Me.btnProductSelect.Location = New System.Drawing.Point(152, 8)
            Me.btnProductSelect.Name = "btnProductSelect"
            Me.btnProductSelect.Size = New System.Drawing.Size(40, 24)
            Me.btnProductSelect.TabIndex = 63
            Me.btnProductSelect.Text = "OK"
            '
            'btnProductClose
            '
            Me.btnProductClose.Location = New System.Drawing.Point(200, 8)
            Me.btnProductClose.Name = "btnProductClose"
            Me.btnProductClose.Size = New System.Drawing.Size(48, 24)
            Me.btnProductClose.TabIndex = 64
            Me.btnProductClose.Text = "Cancel"
            '
            'pnlSelectModel
            '
            Me.pnlSelectModel.BackColor = System.Drawing.Color.LightGray
            Me.pnlSelectModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Prod_Code, Me.Product, Me.lblProduct})
            Me.pnlSelectModel.Location = New System.Drawing.Point(328, 96)
            Me.pnlSelectModel.Name = "pnlSelectModel"
            Me.pnlSelectModel.Size = New System.Drawing.Size(288, 24)
            Me.pnlSelectModel.TabIndex = 2022
            '
            'Prod_Code
            '
            Me.Prod_Code.BackColor = System.Drawing.Color.LightGray
            Me.Prod_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.Prod_Code.Font = New System.Drawing.Font("Calibri", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Prod_Code.ForeColor = System.Drawing.Color.Gray
            Me.Prod_Code.Location = New System.Drawing.Point(24, 7)
            Me.Prod_Code.Name = "Prod_Code"
            Me.Prod_Code.ReadOnly = True
            Me.Prod_Code.Size = New System.Drawing.Size(16, 11)
            Me.Prod_Code.TabIndex = 2026
            Me.Prod_Code.Text = ""
            Me.Prod_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Product
            '
            Me.Product.BackColor = System.Drawing.SystemColors.Window
            Me.Product.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Product.Location = New System.Drawing.Point(112, 1)
            Me.Product.Name = "Product"
            Me.Product.Size = New System.Drawing.Size(172, 22)
            Me.Product.TabIndex = 105
            Me.Product.Text = ""
            '
            'lblProduct
            '
            Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProduct.Location = New System.Drawing.Point(48, 4)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(56, 16)
            Me.lblProduct.TabIndex = 104
            Me.lblProduct.Text = "Product:"
            Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlEnterModel
            '
            Me.pnlEnterModel.BackColor = System.Drawing.Color.LightGray
            Me.pnlEnterModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.Label4, Me.txtMake, Me.txtModel})
            Me.pnlEnterModel.Location = New System.Drawing.Point(376, 40)
            Me.pnlEnterModel.Name = "pnlEnterModel"
            Me.pnlEnterModel.Size = New System.Drawing.Size(248, 64)
            Me.pnlEnterModel.TabIndex = 2021
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(0, 28)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 16)
            Me.Label5.TabIndex = 103
            Me.Label5.Text = "Model:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(0, 2)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 16)
            Me.Label4.TabIndex = 101
            Me.Label4.Text = "Make:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtMake
            '
            Me.txtMake.BackColor = System.Drawing.SystemColors.Window
            Me.txtMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMake.Location = New System.Drawing.Point(62, 2)
            Me.txtMake.Name = "txtMake"
            Me.txtMake.Size = New System.Drawing.Size(176, 22)
            Me.txtMake.TabIndex = 0
            Me.txtMake.Text = ""
            '
            'txtModel
            '
            Me.txtModel.BackColor = System.Drawing.SystemColors.Window
            Me.txtModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtModel.Location = New System.Drawing.Point(62, 28)
            Me.txtModel.Name = "txtModel"
            Me.txtModel.Size = New System.Drawing.Size(176, 22)
            Me.txtModel.TabIndex = 1
            Me.txtModel.Text = ""
            '
            'lblServiceLevel
            '
            Me.lblServiceLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblServiceLevel.Location = New System.Drawing.Point(344, 128)
            Me.lblServiceLevel.Name = "lblServiceLevel"
            Me.lblServiceLevel.Size = New System.Drawing.Size(96, 24)
            Me.lblServiceLevel.TabIndex = 76
            Me.lblServiceLevel.Text = "Service Level:"
            Me.lblServiceLevel.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'ServiceLevel
            '
            Me.ServiceLevel.Location = New System.Drawing.Point(440, 128)
            Me.ServiceLevel.Name = "ServiceLevel"
            Me.ServiceLevel.Size = New System.Drawing.Size(176, 21)
            Me.ServiceLevel.TabIndex = 13
            '
            'lblUpdateReason
            '
            Me.lblUpdateReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUpdateReason.ForeColor = System.Drawing.Color.DarkSlateBlue
            Me.lblUpdateReason.Location = New System.Drawing.Point(648, 16)
            Me.lblUpdateReason.Name = "lblUpdateReason"
            Me.lblUpdateReason.Size = New System.Drawing.Size(112, 24)
            Me.lblUpdateReason.TabIndex = 99
            Me.lblUpdateReason.Text = "Update Reason:"
            Me.lblUpdateReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'UpdateReason
            '
            Me.UpdateReason.BackColor = System.Drawing.SystemColors.Window
            Me.UpdateReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UpdateReason.Location = New System.Drawing.Point(648, 40)
            Me.UpdateReason.Name = "UpdateReason"
            Me.UpdateReason.Size = New System.Drawing.Size(224, 22)
            Me.UpdateReason.TabIndex = 30
            Me.UpdateReason.Text = ""
            '
            'S_ID
            '
            Me.S_ID.BackColor = System.Drawing.Color.LightGray
            Me.S_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.S_ID.Enabled = False
            Me.S_ID.Font = New System.Drawing.Font("Calibri", 8.25!)
            Me.S_ID.ForeColor = System.Drawing.Color.Gray
            Me.S_ID.Location = New System.Drawing.Point(1064, 48)
            Me.S_ID.Name = "S_ID"
            Me.S_ID.ReadOnly = True
            Me.S_ID.Size = New System.Drawing.Size(80, 14)
            Me.S_ID.TabIndex = 97
            Me.S_ID.Text = ""
            Me.S_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblWO_Quantity
            '
            Me.lblWO_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWO_Quantity.Location = New System.Drawing.Point(888, 8)
            Me.lblWO_Quantity.Name = "lblWO_Quantity"
            Me.lblWO_Quantity.Size = New System.Drawing.Size(88, 15)
            Me.lblWO_Quantity.TabIndex = 96
            Me.lblWO_Quantity.Text = "WO_Quantity:"
            Me.lblWO_Quantity.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'WO_Quantity
            '
            Me.WO_Quantity.BackColor = System.Drawing.SystemColors.Window
            Me.WO_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.WO_Quantity.Location = New System.Drawing.Point(984, 8)
            Me.WO_Quantity.Name = "WO_Quantity"
            Me.WO_Quantity.Size = New System.Drawing.Size(64, 22)
            Me.WO_Quantity.TabIndex = 29
            Me.WO_Quantity.Text = ""
            '
            'lblPurchaseDate
            '
            Me.lblPurchaseDate.BackColor = System.Drawing.Color.LightGray
            Me.lblPurchaseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPurchaseDate.Location = New System.Drawing.Point(136, 8)
            Me.lblPurchaseDate.Name = "lblPurchaseDate"
            Me.lblPurchaseDate.Size = New System.Drawing.Size(104, 24)
            Me.lblPurchaseDate.TabIndex = 94
            Me.lblPurchaseDate.Text = "Purchase Date:"
            Me.lblPurchaseDate.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblSenderReference
            '
            Me.lblSenderReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSenderReference.Location = New System.Drawing.Point(320, 272)
            Me.lblSenderReference.Name = "lblSenderReference"
            Me.lblSenderReference.Size = New System.Drawing.Size(120, 24)
            Me.lblSenderReference.TabIndex = 93
            Me.lblSenderReference.Text = "Sender Reference:"
            Me.lblSenderReference.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'SenderReference
            '
            Me.SenderReference.BackColor = System.Drawing.SystemColors.Window
            Me.SenderReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.SenderReference.Location = New System.Drawing.Point(440, 272)
            Me.SenderReference.Name = "SenderReference"
            Me.SenderReference.Size = New System.Drawing.Size(176, 22)
            Me.SenderReference.TabIndex = 19
            Me.SenderReference.Text = ""
            '
            'lblAccount
            '
            Me.lblAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccount.Location = New System.Drawing.Point(328, 248)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(112, 24)
            Me.lblAccount.TabIndex = 91
            Me.lblAccount.Text = "Account:"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Account
            '
            Me.Account.BackColor = System.Drawing.SystemColors.Window
            Me.Account.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Account.Location = New System.Drawing.Point(440, 248)
            Me.Account.Name = "Account"
            Me.Account.Size = New System.Drawing.Size(176, 22)
            Me.Account.TabIndex = 18
            Me.Account.Text = ""
            '
            'lblLanguage
            '
            Me.lblLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLanguage.Location = New System.Drawing.Point(328, 224)
            Me.lblLanguage.Name = "lblLanguage"
            Me.lblLanguage.Size = New System.Drawing.Size(112, 24)
            Me.lblLanguage.TabIndex = 89
            Me.lblLanguage.Text = "Language:"
            Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Language
            '
            Me.Language.BackColor = System.Drawing.SystemColors.Window
            Me.Language.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Language.Location = New System.Drawing.Point(440, 224)
            Me.Language.Name = "Language"
            Me.Language.Size = New System.Drawing.Size(176, 22)
            Me.Language.TabIndex = 2017
            Me.Language.Text = ""
            '
            'lblErrorDescription
            '
            Me.lblErrorDescription.BackColor = System.Drawing.Color.LightGray
            Me.lblErrorDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblErrorDescription.Location = New System.Drawing.Point(648, 272)
            Me.lblErrorDescription.Name = "lblErrorDescription"
            Me.lblErrorDescription.Size = New System.Drawing.Size(120, 16)
            Me.lblErrorDescription.TabIndex = 87
            Me.lblErrorDescription.Text = "Error Description:"
            '
            'ErrorDescription
            '
            Me.ErrorDescription.BackColor = System.Drawing.SystemColors.Window
            Me.ErrorDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ErrorDescription.Location = New System.Drawing.Point(648, 288)
            Me.ErrorDescription.Multiline = True
            Me.ErrorDescription.Name = "ErrorDescription"
            Me.ErrorDescription.Size = New System.Drawing.Size(280, 72)
            Me.ErrorDescription.TabIndex = 25
            Me.ErrorDescription.Text = ""
            '
            'lblDefectType2
            '
            Me.lblDefectType2.BackColor = System.Drawing.Color.LightGray
            Me.lblDefectType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDefectType2.Location = New System.Drawing.Point(344, 320)
            Me.lblDefectType2.Name = "lblDefectType2"
            Me.lblDefectType2.Size = New System.Drawing.Size(96, 24)
            Me.lblDefectType2.TabIndex = 85
            Me.lblDefectType2.Text = "Defect Type2:"
            Me.lblDefectType2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'DefectType2
            '
            Me.DefectType2.BackColor = System.Drawing.SystemColors.Window
            Me.DefectType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DefectType2.Location = New System.Drawing.Point(440, 320)
            Me.DefectType2.Name = "DefectType2"
            Me.DefectType2.Size = New System.Drawing.Size(176, 22)
            Me.DefectType2.TabIndex = 21
            Me.DefectType2.Text = ""
            '
            'lblDefectType1
            '
            Me.lblDefectType1.BackColor = System.Drawing.Color.LightGray
            Me.lblDefectType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDefectType1.Location = New System.Drawing.Point(344, 296)
            Me.lblDefectType1.Name = "lblDefectType1"
            Me.lblDefectType1.Size = New System.Drawing.Size(96, 24)
            Me.lblDefectType1.TabIndex = 83
            Me.lblDefectType1.Text = "Defect Type1:"
            Me.lblDefectType1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'PurchaseDate
            '
            Me.PurchaseDate.CustomFormat = ""
            Me.PurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.PurchaseDate.Location = New System.Drawing.Point(240, 8)
            Me.PurchaseDate.Name = "PurchaseDate"
            Me.PurchaseDate.Size = New System.Drawing.Size(112, 20)
            Me.PurchaseDate.TabIndex = 26
            '
            'Warranty
            '
            Me.Warranty.Location = New System.Drawing.Point(440, 176)
            Me.Warranty.Name = "Warranty"
            Me.Warranty.Size = New System.Drawing.Size(176, 21)
            Me.Warranty.TabIndex = 15
            '
            'lblWarranty
            '
            Me.lblWarranty.BackColor = System.Drawing.Color.LightGray
            Me.lblWarranty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarranty.Location = New System.Drawing.Point(344, 176)
            Me.lblWarranty.Name = "lblWarranty"
            Me.lblWarranty.Size = New System.Drawing.Size(96, 24)
            Me.lblWarranty.TabIndex = 80
            Me.lblWarranty.Text = "Warranty:"
            Me.lblWarranty.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'RepairType
            '
            Me.RepairType.Location = New System.Drawing.Point(440, 152)
            Me.RepairType.Name = "RepairType"
            Me.RepairType.Size = New System.Drawing.Size(176, 21)
            Me.RepairType.TabIndex = 14
            '
            'lblRepairType
            '
            Me.lblRepairType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRepairType.Location = New System.Drawing.Point(344, 152)
            Me.lblRepairType.Name = "lblRepairType"
            Me.lblRepairType.Size = New System.Drawing.Size(96, 24)
            Me.lblRepairType.TabIndex = 78
            Me.lblRepairType.Text = "Repair Type:"
            Me.lblRepairType.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'DefectType1
            '
            Me.DefectType1.BackColor = System.Drawing.SystemColors.Window
            Me.DefectType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DefectType1.Location = New System.Drawing.Point(440, 296)
            Me.DefectType1.Name = "DefectType1"
            Me.DefectType1.Size = New System.Drawing.Size(176, 22)
            Me.DefectType1.TabIndex = 20
            Me.DefectType1.Text = ""
            '
            'lblHardwareSerial
            '
            Me.lblHardwareSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHardwareSerial.Location = New System.Drawing.Point(328, 200)
            Me.lblHardwareSerial.Name = "lblHardwareSerial"
            Me.lblHardwareSerial.Size = New System.Drawing.Size(112, 24)
            Me.lblHardwareSerial.TabIndex = 72
            Me.lblHardwareSerial.Text = "Hardware Serial:"
            Me.lblHardwareSerial.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'HardwareSerial
            '
            Me.HardwareSerial.BackColor = System.Drawing.SystemColors.Window
            Me.HardwareSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.HardwareSerial.Location = New System.Drawing.Point(440, 200)
            Me.HardwareSerial.Name = "HardwareSerial"
            Me.HardwareSerial.Size = New System.Drawing.Size(176, 22)
            Me.HardwareSerial.TabIndex = 16
            Me.HardwareSerial.Text = ""
            '
            'Device_DateShip
            '
            Me.Device_DateShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Device_DateShip.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.Device_DateShip.Location = New System.Drawing.Point(960, 240)
            Me.Device_DateShip.Name = "Device_DateShip"
            Me.Device_DateShip.Size = New System.Drawing.Size(104, 24)
            Me.Device_DateShip.TabIndex = 70
            Me.Device_DateShip.Text = "Tricking Date"
            Me.Device_DateShip.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'TrackCreatedDateTime
            '
            Me.TrackCreatedDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TrackCreatedDateTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.TrackCreatedDateTime.Location = New System.Drawing.Point(960, 184)
            Me.TrackCreatedDateTime.Name = "TrackCreatedDateTime"
            Me.TrackCreatedDateTime.Size = New System.Drawing.Size(112, 24)
            Me.TrackCreatedDateTime.TabIndex = 69
            Me.TrackCreatedDateTime.Text = "Tricking Date"
            Me.TrackCreatedDateTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblFinal_PSSI2Cust_TrackNo
            '
            Me.lblFinal_PSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFinal_PSSI2Cust_TrackNo.Location = New System.Drawing.Point(648, 216)
            Me.lblFinal_PSSI2Cust_TrackNo.Name = "lblFinal_PSSI2Cust_TrackNo"
            Me.lblFinal_PSSI2Cust_TrackNo.Size = New System.Drawing.Size(280, 24)
            Me.lblFinal_PSSI2Cust_TrackNo.TabIndex = 68
            Me.lblFinal_PSSI2Cust_TrackNo.Text = "Final Ship Tracking No:"
            Me.lblFinal_PSSI2Cust_TrackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'RowID
            '
            Me.RowID.BackColor = System.Drawing.Color.LightGray
            Me.RowID.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.RowID.Enabled = False
            Me.RowID.Font = New System.Drawing.Font("Calibri", 8.25!)
            Me.RowID.ForeColor = System.Drawing.Color.Gray
            Me.RowID.Location = New System.Drawing.Point(1064, 32)
            Me.RowID.Name = "RowID"
            Me.RowID.ReadOnly = True
            Me.RowID.Size = New System.Drawing.Size(80, 14)
            Me.RowID.TabIndex = 66
            Me.RowID.Text = ""
            Me.RowID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'pnlSelectCountryState
            '
            Me.pnlSelectCountryState.BackColor = System.Drawing.Color.Lavender
            Me.pnlSelectCountryState.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDataUpdate_Center})
            Me.pnlSelectCountryState.Location = New System.Drawing.Point(8, 240)
            Me.pnlSelectCountryState.Name = "pnlSelectCountryState"
            Me.pnlSelectCountryState.Size = New System.Drawing.Size(312, 80)
            Me.pnlSelectCountryState.TabIndex = 8
            '
            'pnlDataUpdate_Center
            '
            Me.pnlDataUpdate_Center.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCountry2, Me.cmbState2, Me.cmbCountry, Me.cmbState, Me.btnOK, Me.btnCancel})
            Me.pnlDataUpdate_Center.Location = New System.Drawing.Point(16, 8)
            Me.pnlDataUpdate_Center.Name = "pnlDataUpdate_Center"
            Me.pnlDataUpdate_Center.Size = New System.Drawing.Size(288, 64)
            Me.pnlDataUpdate_Center.TabIndex = 65
            '
            'cmbCountry2
            '
            Me.cmbCountry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cmbCountry2.Enabled = False
            Me.cmbCountry2.Location = New System.Drawing.Point(8, 8)
            Me.cmbCountry2.Name = "cmbCountry2"
            Me.cmbCountry2.Size = New System.Drawing.Size(48, 21)
            Me.cmbCountry2.TabIndex = 69
            '
            'cmbState2
            '
            Me.cmbState2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cmbState2.Enabled = False
            Me.cmbState2.Location = New System.Drawing.Point(8, 32)
            Me.cmbState2.Name = "cmbState2"
            Me.cmbState2.Size = New System.Drawing.Size(48, 21)
            Me.cmbState2.TabIndex = 70
            '
            'cmbCountry
            '
            Me.cmbCountry.Location = New System.Drawing.Point(64, 8)
            Me.cmbCountry.Name = "cmbCountry"
            Me.cmbCountry.Size = New System.Drawing.Size(104, 21)
            Me.cmbCountry.TabIndex = 0
            '
            'cmbState
            '
            Me.cmbState.Location = New System.Drawing.Point(64, 32)
            Me.cmbState.Name = "cmbState"
            Me.cmbState.Size = New System.Drawing.Size(104, 21)
            Me.cmbState.TabIndex = 1
            '
            'btnOK
            '
            Me.btnOK.Location = New System.Drawing.Point(176, 8)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(48, 48)
            Me.btnOK.TabIndex = 63
            Me.btnOK.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(232, 8)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(48, 48)
            Me.btnCancel.TabIndex = 64
            Me.btnCancel.Text = "Cancel"
            '
            'Cntry_ID
            '
            Me.Cntry_ID.BackColor = System.Drawing.Color.LightGray
            Me.Cntry_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.Cntry_ID.Font = New System.Drawing.Font("Calibri", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Cntry_ID.ForeColor = System.Drawing.Color.Gray
            Me.Cntry_ID.Location = New System.Drawing.Point(8, 216)
            Me.Cntry_ID.Name = "Cntry_ID"
            Me.Cntry_ID.ReadOnly = True
            Me.Cntry_ID.Size = New System.Drawing.Size(16, 11)
            Me.Cntry_ID.TabIndex = 64
            Me.Cntry_ID.Text = ""
            Me.Cntry_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'State_ID
            '
            Me.State_ID.BackColor = System.Drawing.Color.LightGray
            Me.State_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.State_ID.Font = New System.Drawing.Font("Calibri", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.State_ID.ForeColor = System.Drawing.Color.Gray
            Me.State_ID.Location = New System.Drawing.Point(8, 200)
            Me.State_ID.Name = "State_ID"
            Me.State_ID.ReadOnly = True
            Me.State_ID.Size = New System.Drawing.Size(16, 11)
            Me.State_ID.TabIndex = 63
            Me.State_ID.Text = ""
            Me.State_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'btnSelectCountryState
            '
            Me.btnSelectCountryState.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectCountryState.Location = New System.Drawing.Point(224, 195)
            Me.btnSelectCountryState.Name = "btnSelectCountryState"
            Me.btnSelectCountryState.Size = New System.Drawing.Size(88, 40)
            Me.btnSelectCountryState.TabIndex = 7
            Me.btnSelectCountryState.Text = "Select Country/State"
            '
            'lblZipCode
            '
            Me.lblZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblZipCode.Location = New System.Drawing.Point(16, 168)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(72, 24)
            Me.lblZipCode.TabIndex = 59
            Me.lblZipCode.Text = "Zip Code:"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'ZipCode
            '
            Me.ZipCode.BackColor = System.Drawing.SystemColors.Window
            Me.ZipCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ZipCode.Location = New System.Drawing.Point(88, 168)
            Me.ZipCode.Name = "ZipCode"
            Me.ZipCode.Size = New System.Drawing.Size(224, 22)
            Me.ZipCode.TabIndex = 4
            Me.ZipCode.Text = ""
            '
            'WO_ID
            '
            Me.WO_ID.BackColor = System.Drawing.Color.LightGray
            Me.WO_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.WO_ID.Enabled = False
            Me.WO_ID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.WO_ID.ForeColor = System.Drawing.Color.Gray
            Me.WO_ID.Location = New System.Drawing.Point(1064, 16)
            Me.WO_ID.Name = "WO_ID"
            Me.WO_ID.ReadOnly = True
            Me.WO_ID.Size = New System.Drawing.Size(80, 14)
            Me.WO_ID.TabIndex = 57
            Me.WO_ID.Text = ""
            Me.WO_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblPanel
            '
            Me.lblPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPanel.ForeColor = System.Drawing.Color.Navy
            Me.lblPanel.Location = New System.Drawing.Point(368, 0)
            Me.lblPanel.Name = "lblPanel"
            Me.lblPanel.Size = New System.Drawing.Size(216, 24)
            Me.lblPanel.TabIndex = 56
            Me.lblPanel.Text = "Edit and Update Record"
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Green
            Me.lblStatus.Location = New System.Drawing.Point(376, 24)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(64, 24)
            Me.lblStatus.TabIndex = 55
            Me.lblStatus.Text = "Status:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Status
            '
            Me.Status.BackColor = System.Drawing.Color.LightGray
            Me.Status.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Status.ForeColor = System.Drawing.Color.Green
            Me.Status.Location = New System.Drawing.Point(440, 24)
            Me.Status.Name = "Status"
            Me.Status.ReadOnly = True
            Me.Status.Size = New System.Drawing.Size(184, 15)
            Me.Status.TabIndex = 54
            Me.Status.Text = ""
            '
            'Cust2PSSI_TrackNo
            '
            Me.Cust2PSSI_TrackNo.BackColor = System.Drawing.SystemColors.Window
            Me.Cust2PSSI_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Cust2PSSI_TrackNo.Location = New System.Drawing.Point(648, 192)
            Me.Cust2PSSI_TrackNo.Name = "Cust2PSSI_TrackNo"
            Me.Cust2PSSI_TrackNo.Size = New System.Drawing.Size(280, 22)
            Me.Cust2PSSI_TrackNo.TabIndex = 23
            Me.Cust2PSSI_TrackNo.Text = ""
            '
            'lblPSSI2Cust_TrackNo
            '
            Me.lblPSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSI2Cust_TrackNo.Location = New System.Drawing.Point(648, 128)
            Me.lblPSSI2Cust_TrackNo.Name = "lblPSSI2Cust_TrackNo"
            Me.lblPSSI2Cust_TrackNo.Size = New System.Drawing.Size(296, 24)
            Me.lblPSSI2Cust_TrackNo.TabIndex = 49
            Me.lblPSSI2Cust_TrackNo.Text = "Empty Box - PSSI to Customer Tracking No:"
            Me.lblPSSI2Cust_TrackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'PSSI2Cust_TrackNo
            '
            Me.PSSI2Cust_TrackNo.BackColor = System.Drawing.SystemColors.Window
            Me.PSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.PSSI2Cust_TrackNo.Location = New System.Drawing.Point(648, 152)
            Me.PSSI2Cust_TrackNo.Name = "PSSI2Cust_TrackNo"
            Me.PSSI2Cust_TrackNo.Size = New System.Drawing.Size(280, 22)
            Me.PSSI2Cust_TrackNo.TabIndex = 22
            Me.PSSI2Cust_TrackNo.Text = ""
            '
            'lblEmail
            '
            Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEmail.Location = New System.Drawing.Point(32, 352)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(56, 24)
            Me.lblEmail.TabIndex = 37
            Me.lblEmail.Text = "Email:"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Email
            '
            Me.Email.BackColor = System.Drawing.SystemColors.Window
            Me.Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Email.Location = New System.Drawing.Point(88, 352)
            Me.Email.Name = "Email"
            Me.Email.Size = New System.Drawing.Size(224, 22)
            Me.Email.TabIndex = 10
            Me.Email.Text = ""
            '
            'lblCountry
            '
            Me.lblCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCountry.Location = New System.Drawing.Point(32, 216)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(56, 24)
            Me.lblCountry.TabIndex = 35
            Me.lblCountry.Text = "Country:"
            Me.lblCountry.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Country
            '
            Me.Country.BackColor = System.Drawing.Color.OldLace
            Me.Country.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Country.Location = New System.Drawing.Point(88, 216)
            Me.Country.Name = "Country"
            Me.Country.ReadOnly = True
            Me.Country.Size = New System.Drawing.Size(136, 22)
            Me.Country.TabIndex = 6
            Me.Country.Text = ""
            '
            'lblState
            '
            Me.lblState.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblState.Location = New System.Drawing.Point(32, 192)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(56, 24)
            Me.lblState.TabIndex = 33
            Me.lblState.Text = "State:"
            Me.lblState.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'State
            '
            Me.State.BackColor = System.Drawing.Color.OldLace
            Me.State.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.State.Location = New System.Drawing.Point(88, 192)
            Me.State.Name = "State"
            Me.State.ReadOnly = True
            Me.State.Size = New System.Drawing.Size(136, 22)
            Me.State.TabIndex = 5
            Me.State.Text = ""
            '
            'lblCity
            '
            Me.lblCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCity.Location = New System.Drawing.Point(32, 144)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(56, 24)
            Me.lblCity.TabIndex = 31
            Me.lblCity.Text = "City:"
            Me.lblCity.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'City
            '
            Me.City.BackColor = System.Drawing.SystemColors.Window
            Me.City.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.City.Location = New System.Drawing.Point(88, 144)
            Me.City.Name = "City"
            Me.City.Size = New System.Drawing.Size(224, 22)
            Me.City.TabIndex = 3
            Me.City.Text = ""
            '
            'lblAddress2
            '
            Me.lblAddress2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress2.Location = New System.Drawing.Point(16, 120)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(72, 24)
            Me.lblAddress2.TabIndex = 29
            Me.lblAddress2.Text = "Address 2:"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Address2
            '
            Me.Address2.BackColor = System.Drawing.SystemColors.Window
            Me.Address2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Address2.Location = New System.Drawing.Point(88, 120)
            Me.Address2.Name = "Address2"
            Me.Address2.Size = New System.Drawing.Size(224, 22)
            Me.Address2.TabIndex = 2
            Me.Address2.Text = ""
            '
            'lblAddress1
            '
            Me.lblAddress1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress1.Location = New System.Drawing.Point(16, 96)
            Me.lblAddress1.Name = "lblAddress1"
            Me.lblAddress1.Size = New System.Drawing.Size(72, 24)
            Me.lblAddress1.TabIndex = 27
            Me.lblAddress1.Text = "Address 1:"
            Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Address1
            '
            Me.Address1.BackColor = System.Drawing.SystemColors.Window
            Me.Address1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Address1.Location = New System.Drawing.Point(88, 96)
            Me.Address1.Name = "Address1"
            Me.Address1.Size = New System.Drawing.Size(224, 22)
            Me.Address1.TabIndex = 1
            Me.Address1.Text = ""
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPhone.Location = New System.Drawing.Point(32, 328)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(56, 24)
            Me.lblPhone.TabIndex = 23
            Me.lblPhone.Text = "Phone:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Phone
            '
            Me.Phone.BackColor = System.Drawing.SystemColors.Window
            Me.Phone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Phone.Location = New System.Drawing.Point(88, 328)
            Me.Phone.Name = "Phone"
            Me.Phone.Size = New System.Drawing.Size(224, 22)
            Me.Phone.TabIndex = 9
            Me.Phone.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblName.Location = New System.Drawing.Point(16, 72)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(72, 24)
            Me.lblName.TabIndex = 21
            Me.lblName.Text = "Name:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtName.Location = New System.Drawing.Point(88, 72)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(224, 22)
            Me.txtName.TabIndex = 0
            Me.txtName.Text = ""
            '
            'EW_ID
            '
            Me.EW_ID.BackColor = System.Drawing.Color.LightGray
            Me.EW_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.EW_ID.Enabled = False
            Me.EW_ID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.EW_ID.ForeColor = System.Drawing.Color.Gray
            Me.EW_ID.Location = New System.Drawing.Point(1064, 0)
            Me.EW_ID.Name = "EW_ID"
            Me.EW_ID.ReadOnly = True
            Me.EW_ID.Size = New System.Drawing.Size(80, 14)
            Me.EW_ID.TabIndex = 18
            Me.EW_ID.Text = ""
            Me.EW_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'btnUpdate
            '
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.RoyalBlue
            Me.btnUpdate.Location = New System.Drawing.Point(8, 8)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(112, 32)
            Me.btnUpdate.TabIndex = 1
            Me.btnUpdate.Text = "Update"
            '
            'lblRMANo
            '
            Me.lblRMANo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMANo.Location = New System.Drawing.Point(8, 48)
            Me.lblRMANo.Name = "lblRMANo"
            Me.lblRMANo.Size = New System.Drawing.Size(72, 24)
            Me.lblRMANo.TabIndex = 14
            Me.lblRMANo.Text = "RMA_No:"
            Me.lblRMANo.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'RMA_No
            '
            Me.RMA_No.BackColor = System.Drawing.Color.LightGray
            Me.RMA_No.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.RMA_No.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RMA_No.ForeColor = System.Drawing.Color.Black
            Me.RMA_No.Location = New System.Drawing.Point(88, 48)
            Me.RMA_No.Name = "RMA_No"
            Me.RMA_No.ReadOnly = True
            Me.RMA_No.Size = New System.Drawing.Size(224, 15)
            Me.RMA_No.TabIndex = 13
            Me.RMA_No.Text = ""
            '
            'Final_PSSI2Cust_TrackNo
            '
            Me.Final_PSSI2Cust_TrackNo.BackColor = System.Drawing.SystemColors.Window
            Me.Final_PSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Final_PSSI2Cust_TrackNo.Location = New System.Drawing.Point(648, 240)
            Me.Final_PSSI2Cust_TrackNo.Name = "Final_PSSI2Cust_TrackNo"
            Me.Final_PSSI2Cust_TrackNo.Size = New System.Drawing.Size(280, 22)
            Me.Final_PSSI2Cust_TrackNo.TabIndex = 24
            Me.Final_PSSI2Cust_TrackNo.Text = ""
            '
            'lblCust2PSSI_TrackNo
            '
            Me.lblCust2PSSI_TrackNo.BackColor = System.Drawing.Color.LightGray
            Me.lblCust2PSSI_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCust2PSSI_TrackNo.Location = New System.Drawing.Point(648, 168)
            Me.lblCust2PSSI_TrackNo.Name = "lblCust2PSSI_TrackNo"
            Me.lblCust2PSSI_TrackNo.Size = New System.Drawing.Size(280, 24)
            Me.lblCust2PSSI_TrackNo.TabIndex = 51
            Me.lblCust2PSSI_TrackNo.Text = "Customer to PSSI Tracking No:"
            Me.lblCust2PSSI_TrackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'tdgData_Detail
            '
            Me.tdgData_Detail.AllowUpdate = False
            Me.tdgData_Detail.AlternatingRows = True
            Me.tdgData_Detail.BackColor = System.Drawing.Color.LightGray
            Me.tdgData_Detail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData_Detail.FetchRowStyles = True
            Me.tdgData_Detail.FilterBar = True
            Me.tdgData_Detail.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData_Detail.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData_Detail.Location = New System.Drawing.Point(728, 8)
            Me.tdgData_Detail.Name = "tdgData_Detail"
            Me.tdgData_Detail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData_Detail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData_Detail.PreviewInfo.ZoomFactor = 75
            Me.tdgData_Detail.Size = New System.Drawing.Size(64, 32)
            Me.tdgData_Detail.TabIndex = 68
            Me.tdgData_Detail.Text = "C1TrueDBGrid1"
            Me.tdgData_Detail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Le" & _
            "monChiffon;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inacti" & _
            "ve{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}C" & _
            "aption{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highl" & _
            "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSele" & _
            "ctor{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Rais" & _
            "ed,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz" & _
            ":Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1True" & _
            "DBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" M" & _
            "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vert" & _
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>30</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 62, 30</ClientRect><BorderSide>0</B" & _
            "orderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spl" & _
            "its><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headi" & _
            "ng"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption""" & _
            " /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" " & _
            "/><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" " & _
            "/><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><St" & _
            "yle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar""" & _
            " /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits>" & _
            "<horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRe" & _
            "cSelWidth><ClientArea>0, 0, 62, 30</ClientArea><PrintPageHeaderStyle parent="""" m" & _
            "e=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgData
            '
            Me.tdgData.AllowUpdate = False
            Me.tdgData.AlternatingRows = True
            Me.tdgData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData.FetchRowStyles = True
            Me.tdgData.FilterBar = True
            Me.tdgData.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData.Location = New System.Drawing.Point(8, 40)
            Me.tdgData.Name = "tdgData"
            Me.tdgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData.PreviewInfo.ZoomFactor = 75
            Me.tdgData.Size = New System.Drawing.Size(936, 168)
            Me.tdgData.TabIndex = 28
            Me.tdgData.Text = "C1TrueDBGrid1"
            Me.tdgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>166</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 934, 166</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 934, 166</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnRefresh
            '
            Me.btnRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.Location = New System.Drawing.Point(520, 3)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(144, 32)
            Me.btnRefresh.TabIndex = 24
            Me.btnRefresh.Text = "Refresh Grid Data"
            '
            'rbtAddNew
            '
            Me.rbtAddNew.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtAddNew.Location = New System.Drawing.Point(184, 8)
            Me.rbtAddNew.Name = "rbtAddNew"
            Me.rbtAddNew.Size = New System.Drawing.Size(80, 24)
            Me.rbtAddNew.TabIndex = 27
            Me.rbtAddNew.Text = "Add New"
            '
            'rbtView
            '
            Me.rbtView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtView.Location = New System.Drawing.Point(400, 8)
            Me.rbtView.Name = "rbtView"
            Me.rbtView.Size = New System.Drawing.Size(88, 24)
            Me.rbtView.TabIndex = 26
            Me.rbtView.Text = "View Data"
            '
            'rbtEdit
            '
            Me.rbtEdit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtEdit.Location = New System.Drawing.Point(288, 8)
            Me.rbtEdit.Name = "rbtEdit"
            Me.rbtEdit.Size = New System.Drawing.Size(96, 24)
            Me.rbtEdit.TabIndex = 25
            Me.rbtEdit.Text = "Edit Data"
            '
            'cmbTypeSwitch
            '
            Me.cmbTypeSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbTypeSwitch.ForeColor = System.Drawing.Color.Red
            Me.cmbTypeSwitch.Location = New System.Drawing.Point(8, 8)
            Me.cmbTypeSwitch.Name = "cmbTypeSwitch"
            Me.cmbTypeSwitch.Size = New System.Drawing.Size(144, 28)
            Me.cmbTypeSwitch.TabIndex = 0
            '
            'lblCurrentRecNum_Detail
            '
            Me.lblCurrentRecNum_Detail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentRecNum_Detail.ForeColor = System.Drawing.Color.DarkGray
            Me.lblCurrentRecNum_Detail.Location = New System.Drawing.Point(232, 208)
            Me.lblCurrentRecNum_Detail.Name = "lblCurrentRecNum_Detail"
            Me.lblCurrentRecNum_Detail.Size = New System.Drawing.Size(216, 16)
            Me.lblCurrentRecNum_Detail.TabIndex = 72
            '
            'lblCurrentRecNum
            '
            Me.lblCurrentRecNum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentRecNum.ForeColor = System.Drawing.Color.DarkGray
            Me.lblCurrentRecNum.Location = New System.Drawing.Point(16, 208)
            Me.lblCurrentRecNum.Name = "lblCurrentRecNum"
            Me.lblCurrentRecNum.Size = New System.Drawing.Size(216, 16)
            Me.lblCurrentRecNum.TabIndex = 71
            '
            'lblRecNum
            '
            Me.lblRecNum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum.ForeColor = System.Drawing.Color.DarkGray
            Me.lblRecNum.Location = New System.Drawing.Point(696, 208)
            Me.lblRecNum.Name = "lblRecNum"
            Me.lblRecNum.Size = New System.Drawing.Size(216, 16)
            Me.lblRecNum.TabIndex = 70
            Me.lblRecNum.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblRecNum_Detail
            '
            Me.lblRecNum_Detail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum_Detail.ForeColor = System.Drawing.Color.DarkGray
            Me.lblRecNum_Detail.Location = New System.Drawing.Point(456, 208)
            Me.lblRecNum_Detail.Name = "lblRecNum_Detail"
            Me.lblRecNum_Detail.Size = New System.Drawing.Size(216, 16)
            Me.lblRecNum_Detail.TabIndex = 73
            Me.lblRecNum_Detail.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'tpApproval
            '
            Me.tpApproval.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboApprovedVal, Me.pnlApprovedBy, Me.Label2, Me.lblSN, Me.tdgDataApproval, Me.btnRefreshApproval, Me.lblDisplay, Me.btnApproval})
            Me.tpApproval.Location = New System.Drawing.Point(4, 22)
            Me.tpApproval.Name = "tpApproval"
            Me.tpApproval.Size = New System.Drawing.Size(1184, 654)
            Me.tpApproval.TabIndex = 2
            Me.tpApproval.Text = "Approval"
            '
            'cboApprovedVal
            '
            Me.cboApprovedVal.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboApprovedVal.AutoCompletion = True
            Me.cboApprovedVal.AutoDropDown = True
            Me.cboApprovedVal.AutoSelect = True
            Me.cboApprovedVal.Caption = ""
            Me.cboApprovedVal.CaptionHeight = 17
            Me.cboApprovedVal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboApprovedVal.ColumnCaptionHeight = 17
            Me.cboApprovedVal.ColumnFooterHeight = 17
            Me.cboApprovedVal.ColumnHeaders = False
            Me.cboApprovedVal.ContentHeight = 15
            Me.cboApprovedVal.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboApprovedVal.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboApprovedVal.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboApprovedVal.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboApprovedVal.EditorHeight = 15
            Me.cboApprovedVal.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboApprovedVal.ItemHeight = 15
            Me.cboApprovedVal.Location = New System.Drawing.Point(496, 112)
            Me.cboApprovedVal.MatchEntryTimeout = CType(2000, Long)
            Me.cboApprovedVal.MaxDropDownItems = CType(10, Short)
            Me.cboApprovedVal.MaxLength = 32767
            Me.cboApprovedVal.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboApprovedVal.Name = "cboApprovedVal"
            Me.cboApprovedVal.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboApprovedVal.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboApprovedVal.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboApprovedVal.Size = New System.Drawing.Size(248, 21)
            Me.cboApprovedVal.TabIndex = 3
            Me.cboApprovedVal.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'pnlApprovedBy
            '
            Me.pnlApprovedBy.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboApprovedBy, Me.Label1})
            Me.pnlApprovedBy.Location = New System.Drawing.Point(487, 8)
            Me.pnlApprovedBy.Name = "pnlApprovedBy"
            Me.pnlApprovedBy.Size = New System.Drawing.Size(272, 64)
            Me.pnlApprovedBy.TabIndex = 2
            Me.pnlApprovedBy.Visible = False
            '
            'cboApprovedBy
            '
            Me.cboApprovedBy.Items.AddRange(New Object() {"Customer", "End User"})
            Me.cboApprovedBy.Location = New System.Drawing.Point(8, 32)
            Me.cboApprovedBy.Name = "cboApprovedBy"
            Me.cboApprovedBy.Size = New System.Drawing.Size(248, 21)
            Me.cboApprovedBy.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.TabIndex = 65
            Me.Label1.Text = "Approved By"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(496, 88)
            Me.Label2.Name = "Label2"
            Me.Label2.TabIndex = 67
            Me.Label2.Text = "Approved Type"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblSN.Location = New System.Drawing.Point(496, 216)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(336, 24)
            Me.lblSN.TabIndex = 63
            Me.lblSN.Text = "Label1"
            '
            'tdgDataApproval
            '
            Me.tdgDataApproval.AllowColMove = False
            Me.tdgDataApproval.AllowUpdate = False
            Me.tdgDataApproval.AlternatingRows = True
            Me.tdgDataApproval.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgDataApproval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgDataApproval.FetchRowStyles = True
            Me.tdgDataApproval.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDataApproval.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgDataApproval.Location = New System.Drawing.Point(16, 40)
            Me.tdgDataApproval.Name = "tdgDataApproval"
            Me.tdgDataApproval.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDataApproval.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDataApproval.PreviewInfo.ZoomFactor = 75
            Me.tdgDataApproval.Size = New System.Drawing.Size(456, 432)
            Me.tdgDataApproval.TabIndex = 1
            Me.tdgDataApproval.Text = "C1TrueDBGrid1"
            Me.tdgDataApproval.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
            ",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView AllowColMove=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHe" & _
            "ight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True""" & _
            " MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ve" & _
            "rticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>430</Height><CaptionStyl" & _
            "e parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Eve" & _
            "nRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""" & _
            "Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group""" & _
            " me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle " & _
            "parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4""" & _
            " /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Recor" & _
            "dSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style " & _
            "parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 454, 430</ClientRect><BorderSide" & _
            ">0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView>" & _
            "</Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""" & _
            "Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Cap" & _
            "tion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selec" & _
            "ted"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlight" & _
            "Row"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" " & _
            "/><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filte" & _
            "rBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSp" & _
            "lits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defa" & _
            "ultRecSelWidth><ClientArea>0, 0, 454, 430</ClientArea><PrintPageHeaderStyle pare" & _
            "nt="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnRefreshApproval
            '
            Me.btnRefreshApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshApproval.ForeColor = System.Drawing.Color.MidnightBlue
            Me.btnRefreshApproval.Location = New System.Drawing.Point(16, 8)
            Me.btnRefreshApproval.Name = "btnRefreshApproval"
            Me.btnRefreshApproval.Size = New System.Drawing.Size(56, 29)
            Me.btnRefreshApproval.TabIndex = 0
            Me.btnRefreshApproval.Text = "Refresh"
            '
            'lblDisplay
            '
            Me.lblDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDisplay.ForeColor = System.Drawing.SystemColors.Desktop
            Me.lblDisplay.Location = New System.Drawing.Point(496, 240)
            Me.lblDisplay.Name = "lblDisplay"
            Me.lblDisplay.Size = New System.Drawing.Size(336, 104)
            Me.lblDisplay.TabIndex = 60
            Me.lblDisplay.Text = "Label1"
            '
            'btnApproval
            '
            Me.btnApproval.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnApproval.ForeColor = System.Drawing.Color.Blue
            Me.btnApproval.Location = New System.Drawing.Point(496, 152)
            Me.btnApproval.Name = "btnApproval"
            Me.btnApproval.Size = New System.Drawing.Size(248, 56)
            Me.btnApproval.TabIndex = 4
            Me.btnApproval.Text = "Save"
            '
            'frmDataManagement
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1256, 742)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmDataManagement"
            Me.Text = "frmDataManagement"
            Me.TabControl1.ResumeLayout(False)
            Me.tpRMAData.ResumeLayout(False)
            Me.pnlDataUpdate.ResumeLayout(False)
            Me.pnlProduct.ResumeLayout(False)
            Me.pnlSelectModel.ResumeLayout(False)
            Me.pnlEnterModel.ResumeLayout(False)
            Me.pnlSelectCountryState.ResumeLayout(False)
            Me.pnlDataUpdate_Center.ResumeLayout(False)
            CType(Me.tdgData_Detail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpApproval.ResumeLayout(False)
            CType(Me.cboApprovedVal, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlApprovedBy.ResumeLayout(False)
            CType(Me.tdgDataApproval, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Form"

        '********************************************************************************
        Private Sub frmDataManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                _booLoadData = True

                'For Add/EditView RMA data------------------------------------------------------------------------------------------
                Me.tdgData.AllowDelete = False
                Me.tdgData.AllowAddNew = False
                Me.tdgData.AllowUpdate = False
                Me.tdgData.AllowColSelect = False
                Me.pnlSelectCountryState.Visible = False
                Me.cmbTypeSwitch.Items.Add("End User")
                Me.cmbTypeSwitch.Items.Add("Bulk")
                Me.cmbTypeSwitch.SelectedIndex = 0
                Me.rbtView.Checked = True
                ' MessageBox.Show("Cust_ID=" & Me._iMenuCustID & "     UserID=" & Me._iUserID)
                '------------------------------------------------------------------------------------------------------------------------

                'If Me._booSelectModel = True Then
                '    Me.pnlSelectModel.Visible = True
                '    Me.pnlEnterModel.Visible = False
                'Else
                '    Me.pnlSelectModel.Visible = False
                '    Me.pnlEnterModel.Visible = True
                'End If
                Me.pnlSelectModel.Visible = True
                Me.pnlEnterModel.Visible = True

                LoadApprovedValue()
                Me.cboApprovedBy.SelectedIndex = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                _booLoadData = False
            End Try
        End Sub


#End Region

#Region "Add/Edit/View RMA Data"

        '********************************************************************************
        Private Sub rbtView_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtView.CheckedChanged
            Try
                If Me.rbtView.Checked And Me._IsEndUserData Then goViewMode()
                If Me.rbtView.Checked And Me._IsBulkData Then goViewMode_Bulk()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtView_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub rbtEdit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtEdit.CheckedChanged
            Try
                If rbtEdit.Checked = True AndAlso Me.tdgData.RowCount > 0 Then
                    If Me.rbtEdit.Checked And Me._IsEndUserData Then goEditMode()
                    If Me.rbtEdit.Checked And Me._IsBulkData Then goEditMode_Bulk()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtEdit_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub rbtAddNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtAddNew.CheckedChanged
            Try
                If rbtAddNew.Checked And Me._IsEndUserData Then goAddNewMode()
                If rbtAddNew.Checked And Me._IsBulkData Then goAddNewMode_Bulk()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtAddNew_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub goViewMode()
            Dim f As New Font("Arial", 9, FontStyle.Bold)
            Dim f2 As New Font("Arial", 9, FontStyle.Regular)

            Me.rbtEdit.ForeColor = Color.Black
            Me.rbtView.ForeColor = Color.Blue
            Me.rbtAddNew.ForeColor = Color.Black
            Me.rbtView.Font = f
            Me.rbtEdit.Font = f2
            Me.rbtAddNew.Font = f2
            Dim cControl As Control

            Try
                Me.tdgData_Detail.Visible = False : Me.lblCurrentRecNum_Detail.Visible = False : Me.lblRecNum_Detail.Visible = False
                Me.lblWO_Quantity.Visible = False : Me.WO_Quantity.Visible = False
                Me.pnlProduct.Visible = False : Me.btnSelectProduct.Visible = False

                BindDataToUpdatePanel()

                For Each cControl In Me.pnlDataUpdate.Controls
                    If (TypeOf cControl Is TextBox) Then 'or (TypeOf cControl Is ComboBox)  Then
                        Select Case cControl.Name
                            Case "EW_ID", "RowID", "Status", "State_ID", "Cntry_ID", "RMA_No", "WO_ID", "S_ID", "Prod_Code"
                                'do nothing
                            Case Else
                                'cControl.Text = ""
                                'cControl.Enabled = False
                                CType(cControl, TextBox).ReadOnly = True
                                cControl.BackColor = Color.White
                                cControl.ForeColor = Color.Black
                        End Select

                    End If
                    If (TypeOf cControl Is ComboBox) Then
                        CType(cControl, ComboBox).DropDownStyle = ComboBoxStyle.Simple
                        cControl.Enabled = False
                        cControl.BackColor = Color.White
                        cControl.ForeColor = Color.Blue
                    End If
                Next cControl
                For Each cControl In Me.pnlSelectModel.Controls
                    If (TypeOf cControl Is TextBox) Then
                        CType(cControl, TextBox).ReadOnly = True
                        cControl.BackColor = Color.White
                        cControl.ForeColor = Color.Black
                    End If
                Next
                'Me.PurchaseDate.Text = "12/12/2012"
                Me.PurchaseDate.Enabled = False : Me.lblPanel.Text = "List of Selected Record"
                Me.btnUpdate.Text = "Update" : Me.btnUpdate.Visible = False : Me.btnSelectCountryState.Visible = False

                With Me

                    .txtMake.ReadOnly = True : .txtModel.ReadOnly = True
                    .lblProduct.Visible = True : .Product.Visible = True
                    .lblServiceLevel.Visible = True : .ServiceLevel.Visible = True
                    .lblRepairType.Visible = True : .RepairType.Visible = True
                    .lblWarranty.Visible = True : .Warranty.Visible = True
                    .lblLanguage.Visible = True : .Language.Visible = True
                    .lblSenderReference.Visible = True : .SenderReference.Visible = True
                    .lblDefectType1.Visible = True : .DefectType1.Visible = True
                    .lblDefectType2.Visible = True : .DefectType2.Visible = True
                    .lblErrorDescription.Visible = True : .ErrorDescription.Visible = True
                    .lblPurchaseDate.Visible = True : .PurchaseDate.Visible = True
                    .lblHardwareSerial.Visible = True : .HardwareSerial.Visible = True
                    .lblAccount.Visible = True : .Account.Visible = True

                    .lblPSSI2Cust_TrackNo.Visible = True : .PSSI2Cust_TrackNo.Visible = True
                    .lblCust2PSSI_TrackNo.Visible = True : .Cust2PSSI_TrackNo.Visible = True
                    .lblFinal_PSSI2Cust_TrackNo.Visible = True : .Final_PSSI2Cust_TrackNo.Visible = True
                    .TrackCreatedDateTime.Visible = True : .Device_DateShip.Visible = True

                    .lblStatus.Visible = True : .Status.Visible = True

                    .lblUpdateReason.Visible = False : .UpdateReason.Visible = False

                    '.lblPurchaseDate.Left = .Product.Left + .Product.Width
                    '.PurchaseDate.Left = .lblPurchaseDate.Left + .lblPurchaseDate.Width
                    '.lblPurchaseDate.Top = .Product.Top : .PurchaseDate.Top = .Product.Top

                    '.lblPSSI2Cust_TrackNo.Top = .lblPurchaseDate.Top + .lblPurchaseDate.Height
                    '.lblPSSI2Cust_TrackNo.Left = .Product.Left + .Product.Width + 10
                    '.PSSI2Cust_TrackNo.Left = .Product.Left + .Product.Width + 10
                    '.PSSI2Cust_TrackNo.Top = .lblPSSI2Cust_TrackNo.Top + .lblPSSI2Cust_TrackNo.Height

                    '.lblCust2PSSI_TrackNo.Left = .PSSI2Cust_TrackNo.Left
                    '.Cust2PSSI_TrackNo.Left = .PSSI2Cust_TrackNo.Left
                    '.lblCust2PSSI_TrackNo.Top = .PSSI2Cust_TrackNo.Top + .PSSI2Cust_TrackNo.Height - 10
                    '.Cust2PSSI_TrackNo.Top = .lblCust2PSSI_TrackNo.Top + .lblCust2PSSI_TrackNo.Height
                    '.TrackCreatedDateTime.Left = .Cust2PSSI_TrackNo.Left + .Cust2PSSI_TrackNo.Width
                    '.TrackCreatedDateTime.Top = .Cust2PSSI_TrackNo.Top

                    '.lblFinal_PSSI2Cust_TrackNo.Left = .PSSI2Cust_TrackNo.Left
                    '.Final_PSSI2Cust_TrackNo.Left = .PSSI2Cust_TrackNo.Left
                    '.lblFinal_PSSI2Cust_TrackNo.Top = .Cust2PSSI_TrackNo.Top + .Cust2PSSI_TrackNo.Height + 10
                    '.Final_PSSI2Cust_TrackNo.Top = .lblFinal_PSSI2Cust_TrackNo.Top + .lblFinal_PSSI2Cust_TrackNo.Height
                    '.Device_DateShip.Top = .Final_PSSI2Cust_TrackNo.Top
                    '.Device_DateShip.Left = .Final_PSSI2Cust_TrackNo.Left + .Final_PSSI2Cust_TrackNo.Width

                    '.lblErrorDescription.Left = .PSSI2Cust_TrackNo.Left
                    '.ErrorDescription.Left = .PSSI2Cust_TrackNo.Left
                    '.lblErrorDescription.Top = .SenderReference.Top + 10
                    '.ErrorDescription.Top = .lblErrorDescription.Top + .lblErrorDescription.Height
                    .ErrorDescription.Multiline = True
                    '.ErrorDescription.Height = 44

                End With

                Me.RMA_No.ReadOnly = True : Me.RMA_No.BorderStyle = BorderStyle.None
                Me.RMA_No.BackColor = Color.LightGray : Me.RMA_No.ForeColor = Color.Black

                Me.tdgData.Enabled = True
                Me.pnlDataUpdate.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "goViewMode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub goEditMode()
            Try
                Dim f As New Font("Arial", 9, FontStyle.Bold)
                Dim f2 As New Font("Arial", 9, FontStyle.Regular)
                Me.rbtEdit.ForeColor = Color.Blue
                Me.rbtView.ForeColor = Color.Black
                Me.rbtAddNew.ForeColor = Color.Black
                Me.rbtEdit.Font = f
                Me.rbtView.Font = f2
                Me.rbtAddNew.Font = f2

                Me.lblPanel.Text = "Edit and Update Record"
                Me.btnUpdate.Text = "Update" : Me.btnUpdate.Visible = True : Me.btnSelectCountryState.Visible = True

                Me.tdgData_Detail.Visible = False : Me.lblCurrentRecNum_Detail.Visible = False : Me.lblRecNum_Detail.Visible = False
                Me.lblWO_Quantity.Visible = False : Me.WO_Quantity.Visible = False
                Me.pnlProduct.Visible = False : Me.btnSelectProduct.Visible = True

                BindDataToUpdatePanel()


                With Me
                    .lblProduct.Visible = True : .Product.Visible = True
                    .lblServiceLevel.Visible = False : .ServiceLevel.Visible = False
                    .lblRepairType.Visible = False : .RepairType.Visible = False
                    .lblWarranty.Visible = False : .Warranty.Visible = False
                    .lblLanguage.Visible = False : .Language.Visible = False
                    .lblSenderReference.Visible = False : .SenderReference.Visible = False
                    .lblDefectType1.Visible = False : .DefectType1.Visible = False
                    .lblDefectType2.Visible = False : .DefectType2.Visible = False
                    .lblErrorDescription.Visible = False : .ErrorDescription.Visible = False
                    .lblPurchaseDate.Visible = False : .PurchaseDate.Visible = False
                    .lblHardwareSerial.Visible = False : .HardwareSerial.Visible = False
                    .lblAccount.Visible = False : .Account.Visible = False

                    'tracking numbers
                    .lblPSSI2Cust_TrackNo.Visible = False : .PSSI2Cust_TrackNo.Visible = False
                    .lblCust2PSSI_TrackNo.Visible = False : .Cust2PSSI_TrackNo.Visible = False
                    .lblFinal_PSSI2Cust_TrackNo.Visible = False : .Final_PSSI2Cust_TrackNo.Visible = False
                    .TrackCreatedDateTime.Visible = False : .Device_DateShip.Visible = False

                    .lblPhone.Visible = True : .Phone.Visible = True
                    .lblEmail.Visible = True : .Email.Visible = True

                    .lblUpdateReason.Visible = True : .UpdateReason.Visible = True

                    .txtName.ReadOnly = False : .Address1.ReadOnly = False
                    .City.ReadOnly = False : .Address2.ReadOnly = False
                    .ZipCode.ReadOnly = False : .Phone.ReadOnly = False
                    .Email.ReadOnly = False : .PSSI2Cust_TrackNo.ReadOnly = False
                    .Cust2PSSI_TrackNo.ReadOnly = False : .Final_PSSI2Cust_TrackNo.ReadOnly = False
                    .State.ReadOnly = True : .Country.ReadOnly = True
                    .State.BackColor = Color.OldLace : .Country.BackColor = Color.OldLace
                    .txtMake.ReadOnly = False : .txtModel.ReadOnly = False
                    .Product.Enabled = False
                   
                    '.lblPSSI2Cust_TrackNo.Left = .txtName.Left + .txtName.Width + 20
                    '.PSSI2Cust_TrackNo.Left = .lblPSSI2Cust_TrackNo.Left
                    '.lblCust2PSSI_TrackNo.Left = .txtName.Left + .txtName.Width + 20
                    '.Cust2PSSI_TrackNo.Left = .lblCust2PSSI_TrackNo.Left
                    '.lblFinal_PSSI2Cust_TrackNo.Left = .txtName.Left + .txtName.Width + 20
                    '.Final_PSSI2Cust_TrackNo.Left = .lblFinal_PSSI2Cust_TrackNo.Left
                    '.TrackCreatedDateTime.Left = .Cust2PSSI_TrackNo.Left + .Cust2PSSI_TrackNo.Width + 10
                    '.Device_DateShip.Left = Final_PSSI2Cust_TrackNo.Left + Final_PSSI2Cust_TrackNo.Width + 10

                    '.lblUpdateReason.Left = .txtName.Left + .txtName.Width + 20
                    '.lblUpdateReason.Top = .txtName.Top
                    '.UpdateReason.Left = .lblUpdateReason.Left
                    '.UpdateReason.Top = .lblUpdateReason.Top + .lblUpdateReason.Height
                    '.UpdateReason.Multiline = True : .UpdateReason.MaxLength = 100
                    '.UpdateReason.Height = 44 : .UpdateReason.Width = 200

                    .UpdateReason.ReadOnly = False
                    .lblUpdateReason.TextAlign = ContentAlignment.MiddleLeft


                    .lblStatus.Visible = True : .Status.Visible = True
                End With


                Me.RMA_No.ReadOnly = True : Me.RMA_No.BorderStyle = BorderStyle.None
                Me.RMA_No.BackColor = Color.LightGray : Me.RMA_No.ForeColor = Color.Black

                If Me.S_ID.Text < 2 Then
                    Me.PSSI2Cust_TrackNo.ReadOnly = True : Me.Cust2PSSI_TrackNo.ReadOnly = True
                End If
                If Me.S_ID.Text < 7 Then
                    Me.Final_PSSI2Cust_TrackNo.ReadOnly = True
                End If

                Me.tdgData.Enabled = True
                Me.pnlDataUpdate.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "goEditMode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub goAddNewMode()
            Try
                Dim f As New Font("Arial", 9, FontStyle.Bold)
                Dim f2 As New Font("Arial", 9, FontStyle.Regular)
                Dim dt As DataTable

                Me.rbtEdit.ForeColor = Color.Black
                Me.rbtView.ForeColor = Color.Black
                Me.rbtAddNew.ForeColor = Color.Blue
                Me.rbtView.Font = f2
                Me.rbtEdit.Font = f2
                Me.rbtAddNew.Font = f

                Me.tdgData_Detail.Visible = False : Me.lblCurrentRecNum_Detail.Visible = False : Me.lblRecNum_Detail.Visible = False
                Me.lblWO_Quantity.Visible = False : Me.WO_Quantity.Visible = False
                Me.pnlProduct.Visible = False : Me.btnSelectProduct.Visible = True

                BindDataToUpdatePanel()

                With Me
                    .lblProduct.Visible = True : .Product.Visible = True
                    .lblServiceLevel.Visible = True : .ServiceLevel.Visible = True
                    .lblRepairType.Visible = True : .RepairType.Visible = True
                    .lblWarranty.Visible = True : .Warranty.Visible = True
                    .lblLanguage.Visible = True : .Language.Visible = True
                    .lblSenderReference.Visible = True : .SenderReference.Visible = True
                    .lblDefectType1.Visible = True : .DefectType1.Visible = True
                    .lblDefectType2.Visible = True : .DefectType2.Visible = True
                    .lblErrorDescription.Visible = True : .ErrorDescription.Visible = True
                    .lblPurchaseDate.Visible = True : .PurchaseDate.Visible = True
                    .lblHardwareSerial.Visible = True : .HardwareSerial.Visible = True
                    .lblAccount.Visible = True : .Account.Visible = True
                    .lblPhone.Visible = True : .Phone.Visible = True
                    .lblEmail.Visible = True : .Email.Visible = True

                    .lblPSSI2Cust_TrackNo.Visible = False : .PSSI2Cust_TrackNo.Visible = False
                    .lblCust2PSSI_TrackNo.Visible = False : .Cust2PSSI_TrackNo.Visible = False
                    .lblFinal_PSSI2Cust_TrackNo.Visible = False : .Final_PSSI2Cust_TrackNo.Visible = False
                    .TrackCreatedDateTime.Visible = False : .Device_DateShip.Visible = False

                    .lblStatus.Visible = False : .Status.Visible = False

                    .lblUpdateReason.Visible = False : .UpdateReason.Visible = False

                    .btnSelectCountryState.Visible = False
                End With

                Dim cControl As Control
                For Each cControl In Me.pnlDataUpdate.Controls
                    If (TypeOf cControl Is TextBox) Then 'or (TypeOf cControl Is ComboBox)  Then
                        Select Case cControl.Name
                            Case "EW_ID", "RowID", "Status", "State_ID", "Cntry_ID", "RMA_No", "WO_ID", "S_ID"
                                cControl.Text = ""
                                Me.RMA_No.ReadOnly = False : Me.RMA_No.BorderStyle = BorderStyle.Fixed3D
                                Me.RMA_No.BackColor = Color.White : Me.RMA_No.ForeColor = Color.Black
                            Case Else
                                cControl.Text = ""
                                'cControl.Enabled = False
                                CType(cControl, TextBox).ReadOnly = False
                                cControl.BackColor = Color.White
                                cControl.ForeColor = Color.Black
                        End Select

                    End If
                    If (TypeOf cControl Is ComboBox) Then
                        CType(cControl, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
                        cControl.Enabled = True
                        cControl.Text = ""
                        cControl.BackColor = Color.White
                        cControl.ForeColor = Color.Black
                    End If
                Next cControl
                For Each cControl In Me.pnlEnterModel.Controls
                    If (TypeOf cControl Is TextBox) Then
                        cControl.Text = ""
                        CType(cControl, TextBox).ReadOnly = False
                        cControl.BackColor = Color.White
                        cControl.ForeColor = Color.Black
                    End If
                Next
                For Each cControl In Me.pnlSelectModel.Controls
                    If (TypeOf cControl Is TextBox) Then
                        cControl.Text = ""
                        CType(cControl, TextBox).ReadOnly = True
                        cControl.BackColor = Color.OldLace
                        cControl.ForeColor = Color.Black
                    End If
                Next
                Me.Prod_Code.BackColor = Color.LightGray : Me.Prod_Code.ForeColor = Color.Gray


                Me.State.ReadOnly = True : Me.Country.ReadOnly = True
                Me.State.BackColor = Color.OldLace : Me.Country.BackColor = Color.OldLace
                Me.PurchaseDate.Enabled = True : Me.lblPanel.Text = "New Record"
                Me.btnUpdate.Text = "Add" : Me.btnUpdate.Visible = True : Me.btnSelectCountryState.Visible = True

                'populate Dropdown items
                With Me
                    ._objNIDataM = New NIDataManagement()
                    dt = ._objNIDataM.GetNI_Products
                    '.Product.DataSource = dt
                    '.Product.ValueMember = dt.Columns("NI_Prod_ID").ToString
                    '.Product.DisplayMember = dt.Columns("NI_Prod_Desc").ToString

                    .ServiceLevel.Items.Clear()
                    .ServiceLevel.Items.Add("Customer Ships")
                    .ServiceLevel.Items.Add("Packaging Upfront")
                    '.ServiceLevel.Items.Add("On-Site Exchange")
                    '.ServiceLevel.Items.Add("Pickup Service")
                    .ServiceLevel.SelectedIndex = 0
                    .ServiceLevel.Enabled = False

                    .RepairType.Items.Clear()
                    .RepairType.Items.Add("SendRefurb")
                    .RepairType.Items.Add("SendNew")
                    .RepairType.Items.Add("RepairThisUnit")
                    .RepairType.Items.Add("SendNothing")
                    .RepairType.SelectedIndex = 2
                    .RepairType.Enabled = False

                    .Warranty.Items.Clear()
                    .Warranty.Items.Add("Yes")
                    .Warranty.Items.Add("No")
                    .Warranty.SelectedIndex = 0

                    .PurchaseDate.Format = DateTimePickerFormat.Short
                    .PurchaseDate.Text = Now.Date

                    .Language.Text = "EN" 'Set default for Languange
                End With

                Me.RMA_No.Focus()

                'Me.tdgData.SelectedRows.Add(0) 'Select row 1
                Me.tdgData.SelectedRows.Clear() 'clear selected row(s)
                Me.tdgData.Enabled = False
                Me.pnlDataUpdate.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "goAddNewMode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub goViewMode_Bulk()
            Dim f As New Font("Arial", 9, FontStyle.Bold)
            Dim f2 As New Font("Arial", 9, FontStyle.Regular)
            Try
                With Me
                    .rbtEdit.ForeColor = Color.Black
                    .rbtView.ForeColor = Color.Blue
                    .rbtAddNew.ForeColor = Color.Black
                    .rbtView.Font = f
                    .rbtEdit.Font = f2
                    .rbtAddNew.Font = f2

                    .pnlDataUpdate.Visible = False : .tdgData_Detail.Visible = True
                    '.tdgData_Detail.Top = .tdgData.Top + .tdgData.Height + .lblCurrentRecNum.Height + 10
                    '.tdgData_Detail.Width = .tdgData.Width : .tdgData_Detail.Height = .tdgData.Height
                    '.tdgData_Detail.Left = .tdgData.Left
                    '.lblCurrentRecNum_Detail.Top = .tdgData_Detail.Top + .tdgData_Detail.Height
                    '.lblRecNum_Detail.Top = .lblCurrentRecNum_Detail.Top
                    '.lblCurrentRecNum_Detail.Left = .tdgData_Detail.Left
                    '.lblRecNum_Detail.Left = .tdgData_Detail.Left + .tdgData_Detail.Width - .lblRecNum_Detail.Width

                    .lblCurrentRecNum_Detail.Visible = True : .lblRecNum_Detail.Visible = True

                    Me.tdgData.Enabled = True
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "goViewMode_Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub goEditMode_Bulk()
            Try
                Dim f As New Font("Arial", 9, FontStyle.Bold)
                Dim f2 As New Font("Arial", 9, FontStyle.Regular)
                Me.rbtEdit.ForeColor = Color.Blue
                Me.rbtView.ForeColor = Color.Black
                Me.rbtAddNew.ForeColor = Color.Black
                Me.rbtEdit.Font = f
                Me.rbtView.Font = f2
                Me.rbtAddNew.Font = f2

                Me.lblPanel.Text = "Edit and Update Record"
                Me.btnUpdate.Text = "Update" : Me.btnUpdate.Visible = True : Me.btnSelectCountryState.Visible = True

                Me.tdgData_Detail.Visible = False : Me.lblCurrentRecNum_Detail.Visible = False : Me.lblRecNum_Detail.Visible = False
                Me.RepairType.DropDownStyle = ComboBoxStyle.Simple : Me.Warranty.DropDownStyle = ComboBoxStyle.Simple
                Me.tdgData.Enabled = True

                BindDataToUpdatePanel_Bulk()

                With Me
                    .lblProduct.Visible = False : .Product.Visible = False
                    .lblServiceLevel.Visible = False : .ServiceLevel.Visible = False
                    .lblLanguage.Visible = False : .Language.Visible = False
                    .lblSenderReference.Visible = False : .SenderReference.Visible = False
                    .lblDefectType1.Visible = False : .DefectType1.Visible = False
                    .lblDefectType2.Visible = False : .DefectType2.Visible = False
                    .lblErrorDescription.Visible = False : .ErrorDescription.Visible = False
                    .lblPurchaseDate.Visible = False : .PurchaseDate.Visible = False
                    .lblHardwareSerial.Visible = False : .HardwareSerial.Visible = False
                    .lblAccount.Visible = False : .Account.Visible = False
                    .lblPSSI2Cust_TrackNo.Visible = False : .PSSI2Cust_TrackNo.Visible = False
                    .lblCust2PSSI_TrackNo.Visible = False : .Cust2PSSI_TrackNo.Visible = False
                    .lblFinal_PSSI2Cust_TrackNo.Visible = False : .Final_PSSI2Cust_TrackNo.Visible = False
                    .TrackCreatedDateTime.Visible = False : .Device_DateShip.Visible = False
                    .lblPhone.Visible = False : .Phone.Visible = False
                    .lblEmail.Visible = False : .Email.Visible = False

                    .lblUpdateReason.Visible = True : .UpdateReason.Visible = True

                    .lblWO_Quantity.Visible = True : .WO_Quantity.Visible = True
                    .lblRepairType.Visible = True : .RepairType.Visible = True
                    .lblWarranty.Visible = True : .Warranty.Visible = True
                    .RepairType.Enabled = False : .Warranty.Enabled = False

                    .WO_Quantity.Top = .Country.Top + .Country.Height : .WO_Quantity.Left = .Country.Left
                    .lblWO_Quantity.Top = .WO_Quantity.Top : .lblWO_Quantity.Left = .WO_Quantity.Left - .lblWO_Quantity.Width
                    '.RepairType.Top = .WO_Quantity.Top + .WO_Quantity.Height : .RepairType.Left = .WO_Quantity.Left
                    '.lblRepairType.Top = .RepairType.Top : .lblRepairType.Left = .RepairType.Left - .lblRepairType.Width

                    '.UpdateReason.Left = .Warranty.Left : .UpdateReason.Top = .Warranty.Top + .Warranty.Height + 20
                    '.lblUpdateReason.Top = .UpdateReason.Top
                    '.lblUpdateReason.Left = UpdateReason.Left - .lblUpdateReason.Width
                    '.UpdateReason.Multiline = True : .UpdateReason.MaxLength = 100
                    '.UpdateReason.Height = 44 : .UpdateReason.Width = 200
                    '.UpdateReason.ReadOnly = False : .lblUpdateReason.TextAlign = ContentAlignment.TopRight


                    .lblStatus.Visible = False : .Status.Visible = False

                    .txtName.ReadOnly = False : .Address1.ReadOnly = False
                    .City.ReadOnly = False : .Address2.ReadOnly = False
                    .ZipCode.ReadOnly = False : .WO_Quantity.ReadOnly = False

                    Me.RMA_No.ReadOnly = True : Me.RMA_No.BorderStyle = BorderStyle.None
                    Me.RMA_No.BackColor = Color.LightGray : Me.RMA_No.ForeColor = Color.Black
                End With

                Me.pnlDataUpdate.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "goEditMode_Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub goAddNewMode_Bulk()
            Try
                Dim f As New Font("Arial", 9, FontStyle.Bold)
                Dim f2 As New Font("Arial", 9, FontStyle.Regular)
                Dim dt As DataTable

                Me.rbtEdit.ForeColor = Color.Black
                Me.rbtView.ForeColor = Color.Black
                Me.rbtAddNew.ForeColor = Color.Blue
                Me.rbtView.Font = f2
                Me.rbtEdit.Font = f2
                Me.rbtAddNew.Font = f

                Me.tdgData_Detail.Visible = False : Me.lblCurrentRecNum_Detail.Visible = False : Me.lblRecNum_Detail.Visible = False

                BindDataToUpdatePanel_Bulk()

                With Me
                    .lblProduct.Visible = False : .Product.Visible = False
                    .lblServiceLevel.Visible = False : .ServiceLevel.Visible = False
                    .lblLanguage.Visible = False : .Language.Visible = False
                    .lblSenderReference.Visible = False : .SenderReference.Visible = False
                    .lblDefectType1.Visible = False : .DefectType1.Visible = False
                    .lblDefectType2.Visible = False : .DefectType2.Visible = False
                    .lblErrorDescription.Visible = False : .ErrorDescription.Visible = False
                    .lblPurchaseDate.Visible = False : .PurchaseDate.Visible = False
                    .lblHardwareSerial.Visible = False : .HardwareSerial.Visible = False
                    .lblAccount.Visible = False : .Account.Visible = False
                    .lblPSSI2Cust_TrackNo.Visible = False : .PSSI2Cust_TrackNo.Visible = False
                    .lblCust2PSSI_TrackNo.Visible = False : .Cust2PSSI_TrackNo.Visible = False
                    .lblFinal_PSSI2Cust_TrackNo.Visible = False : .Final_PSSI2Cust_TrackNo.Visible = False
                    .TrackCreatedDateTime.Visible = False : .Device_DateShip.Visible = False
                    .lblPhone.Visible = False : .Phone.Visible = False
                    .lblEmail.Visible = False : .Email.Visible = False
                    .lblStatus.Visible = False : .Status.Visible = False

                    .lblUpdateReason.Visible = False : .UpdateReason.Visible = False

                    .lblWO_Quantity.Visible = True : .WO_Quantity.Visible = True
                    .lblRepairType.Visible = True : .RepairType.Visible = True
                    .lblWarranty.Visible = True : .Warranty.Visible = True

                    '.WO_Quantity.Top = .Country.Top + .Country.Height : .WO_Quantity.Left = .Country.Left
                    '.lblWO_Quantity.Top = .WO_Quantity.Top : .lblWO_Quantity.Left = .WO_Quantity.Left - .lblWO_Quantity.Width

                    .txtName.ReadOnly = False : .Address1.ReadOnly = False
                    .City.ReadOnly = False : .Address2.ReadOnly = False
                    .ZipCode.ReadOnly = False : .WO_Quantity.ReadOnly = False

                    .txtName.Text = "" : .Address1.Text = ""
                    .City.Text = "" : .Address2.Text = ""
                    .ZipCode.Text = "" : .WO_Quantity.Text = ""
                    .State.Text = "" : .Country.Text = ""
                    .WO_Quantity.Text = "" : .RMA_No.Text = ""
                    .EW_ID.Text = "" : .RowID.Text = "" : .State_ID.Text = ""
                    .Cntry_ID.Text = "" : .S_ID.Text = "" : .WO_ID.Text = ""

                    .RMA_No.ReadOnly = False : .RMA_No.BorderStyle = BorderStyle.Fixed3D
                    .RMA_No.BackColor = Color.White : .RMA_No.ForeColor = Color.Black

                    .State.ReadOnly = True : .Country.ReadOnly = True
                    .State.BackColor = Color.OldLace : .Country.BackColor = Color.OldLace
                    .lblPanel.Text = "New Record"
                    .btnUpdate.Text = "Add" : .btnUpdate.Visible = True : .btnSelectCountryState.Visible = True

                    .RepairType.Items.Clear()
                    .RepairType.Items.Add("SendNothing")
                    .RepairType.SelectedIndex = 0
                    .RepairType.Enabled = False

                    .Warranty.DropDownStyle = ComboBoxStyle.DropDown
                    .Warranty.Items.Clear()
                    .Warranty.Items.Add("Yes")
                    .Warranty.Items.Add("No")
                    .Warranty.SelectedIndex = 0
                    .Warranty.Enabled = True
                    .Warranty.BackColor = Color.White : .Warranty.ForeColor = Color.Black

                    .tdgData.SelectedRows.Clear() 'clear selected row(s)
                    .tdgData.Enabled = False
                    .lblStatus.Visible = False : .Status.Visible = False
                End With

                'Me.RMA_No.Focus()
                'Me.RMA_No.Select()
                'Me.Show()
                'Application.DoEvents()
                Me.RMA_No.Focus()
                Me.pnlDataUpdate.Visible = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "goAddNewMode_Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub BindDataToUpdatePanel(Optional ByVal rowIdx As Integer = 0)
            Try
                Dim iRowID As Integer = Me.tdgData.Row
                Dim myD As Date

                If rowIdx > 0 Then
                    iRowID = rowIdx
                End If

                Me.tdgData.SelectedRows.Add(iRowID) 'select current row

                Dim j As Integer = 0
                Me.RowID.Text = iRowID + 1

                If Not IsDBNull(Me.tdgData.Columns("EW_ID").CellText(iRowID)) Then Me.EW_ID.Text = Me.tdgData.Columns("EW_ID").CellText(iRowID) Else Me.EW_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("WO_ID").CellText(iRowID)) Then Me.WO_ID.Text = Me.tdgData.Columns("WO_ID").CellText(iRowID) Else Me.WO_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("RMA_No").CellText(iRowID)) Then Me.RMA_No.Text = Me.tdgData.Columns("RMA_No").CellText(iRowID) Else Me.RMA_No.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Description").CellText(iRowID)) Then Me.Status.Text = Me.tdgData.Columns("Description").CellText(iRowID) Else Me.Status.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Name").CellText(iRowID)) Then Me.txtName.Text = Me.tdgData.Columns("Name").CellText(iRowID) Else Me.txtName.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Address1").CellText(iRowID)) Then Me.Address1.Text = Me.tdgData.Columns("Address1").CellText(iRowID) Else Me.Address1.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Address2").CellText(iRowID)) Then Me.Address2.Text = Me.tdgData.Columns("Address2").CellText(iRowID) Else Me.Address2.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("City").CellText(iRowID)) Then Me.City.Text = Me.tdgData.Columns("City").CellText(iRowID) Else Me.City.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("ZipCode").CellText(iRowID)) Then Me.ZipCode.Text = Me.tdgData.Columns("ZipCode").CellText(iRowID) Else Me.ZipCode.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("State").CellText(iRowID)) Then Me.State.Text = Me.tdgData.Columns("State").CellText(iRowID) Else Me.State.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Country").CellText(iRowID)) Then Me.Country.Text = Me.tdgData.Columns("Country").CellText(iRowID) Else Me.Country.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("State_ID").CellText(iRowID)) Then Me.State_ID.Text = Me.tdgData.Columns("State_ID").CellText(iRowID) Else Me.State_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Cntry_ID").CellText(iRowID)) Then Me.Cntry_ID.Text = Me.tdgData.Columns("Cntry_ID").CellText(iRowID) Else Me.Cntry_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Phone").CellText(iRowID)) Then Me.Phone.Text = Me.tdgData.Columns("Phone").CellText(iRowID) Else Me.Phone.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Email").CellText(iRowID)) Then Me.Email.Text = Me.tdgData.Columns("Email").CellText(iRowID) Else Me.Email.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("PSSI2Cust_TrackNo").CellText(iRowID)) Then Me.PSSI2Cust_TrackNo.Text = Me.tdgData.Columns("PSSI2Cust_TrackNo").CellText(iRowID) Else Me.PSSI2Cust_TrackNo.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Cust2PSSI_TrackNo").CellText(iRowID)) Then Me.Cust2PSSI_TrackNo.Text = Me.tdgData.Columns("Cust2PSSI_TrackNo").CellText(iRowID) Else Me.Cust2PSSI_TrackNo.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Final_PSSI2Cust_TrackNo").CellText(iRowID)) Then Me.Final_PSSI2Cust_TrackNo.Text = Me.tdgData.Columns("Final_PSSI2Cust_TrackNo").CellText(iRowID) Else Me.Final_PSSI2Cust_TrackNo.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("TrackCreatedDateTime").CellText(iRowID)) Then Me.TrackCreatedDateTime.Text = Me.tdgData.Columns("TrackCreatedDateTime").CellText(iRowID) Else Me.TrackCreatedDateTime.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Device_DateShip").CellText(iRowID)) Then Me.Device_DateShip.Text = Me.tdgData.Columns("Device_DateShip").CellText(iRowID) Else Me.Device_DateShip.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("S_ID").CellText(iRowID)) Then Me.S_ID.Text = Me.tdgData.Columns("S_ID").CellText(iRowID) Else Me.S_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Brand").CellText(iRowID)) Then Me.txtMake.Text = Me.tdgData.Columns("Brand").CellText(iRowID) Else Me.txtMake.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Model").CellText(iRowID)) Then Me.txtModel.Text = Me.tdgData.Columns("Model").CellText(iRowID) Else Me.txtModel.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Product").CellText(iRowID)) Then Me.Product.Text = Me.tdgData.Columns("Product").CellText(iRowID) Else Me.Product.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Prod_Code").CellText(iRowID)) Then Me.Prod_Code.Text = Me.tdgData.Columns("Prod_Code").CellText(iRowID) Else Me.Prod_Code.Text = ""

                If IsDate(Me.TrackCreatedDateTime.Text) Then
                    myD = Me.TrackCreatedDateTime.Text
                    Me.TrackCreatedDateTime.Text = Format(myD, "MM/dd/yyyy")
                End If
                If IsDate(Me.Device_DateShip.Text) Then
                    myD = Me.Device_DateShip.Text
                    Me.Device_DateShip.Text = Format(myD, "MM/dd/yyyy")
                End If

                'If Not IsDBNull(Me.tdgData.Columns("NI_Prod_Desc").CellText(iRowID)) Then Me.Product.Text = Me.tdgData.Columns("NI_Prod_Desc").CellText(iRowID) Else Me.Product.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("ServiceLevel").CellText(iRowID)) Then Me.ServiceLevel.Text = Me.tdgData.Columns("ServiceLevel").CellText(iRowID) Else Me.ServiceLevel.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("RepairType").CellText(iRowID)) Then Me.RepairType.Text = Me.tdgData.Columns("RepairType").CellText(iRowID) Else Me.RepairType.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Warranty").CellText(iRowID)) Then Me.Warranty.Text = Me.tdgData.Columns("Warranty").CellText(iRowID) Else Me.Warranty.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("HardwareSerial").CellText(iRowID)) Then Me.HardwareSerial.Text = Me.tdgData.Columns("HardwareSerial").CellText(iRowID) Else Me.HardwareSerial.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Language").CellText(iRowID)) Then Me.Language.Text = Me.tdgData.Columns("Language").CellText(iRowID) Else Me.Language.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("SenderReference").CellText(iRowID)) Then Me.SenderReference.Text = Me.tdgData.Columns("SenderReference").CellText(iRowID) Else Me.SenderReference.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Account").CellText(iRowID)) Then Me.Account.Text = Me.tdgData.Columns("Account").CellText(iRowID) Else Me.Account.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("DefectType1").CellText(iRowID)) Then Me.DefectType1.Text = Me.tdgData.Columns("DefectType1").CellText(iRowID) Else Me.DefectType1.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("DefectType2").CellText(iRowID)) Then Me.DefectType2.Text = Me.tdgData.Columns("DefectType2").CellText(iRowID) Else Me.DefectType2.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("ErrorDescription").CellText(iRowID)) Then Me.ErrorDescription.Text = Me.tdgData.Columns("ErrorDescription").CellText(iRowID) Else Me.ErrorDescription.Text = ""
                'If Not IsDBNull(Me.tdgData.Columns("PurchaseDate").CellText(iRowID)) Then Me.PurchaseDate.Text = Me.tdgData.Columns("PurchaseDate").CellText(iRowID) Else Me.PurchaseDate.Text = ""

                Me.Prod_Code.ReadOnly = True : Me.Prod_Code.BackColor = Color.LightGray : Me.Prod_Code.ForeColor = Color.Gray

                If IsDate(Me.tdgData.Columns("PurchaseDate").Value) Then
                    myD = Me.tdgData.Columns("PurchaseDate").Value
                    Me.PurchaseDate.Format = DateTimePickerFormat.Short
                    Me.PurchaseDate.Text = Format(myD, "MM/dd/yyyy")
                Else
                    Me.PurchaseDate.CustomFormat = " "
                    Me.PurchaseDate.Format = DateTimePickerFormat.Custom
                End If

                If Me._IsEndUserData AndAlso Me.rbtEdit.Checked Then
                    If Me.S_ID.Text < 2 Then
                        Me.PSSI2Cust_TrackNo.ReadOnly = True : Me.Cust2PSSI_TrackNo.ReadOnly = True
                    Else
                        Me.PSSI2Cust_TrackNo.ReadOnly = False : Me.Cust2PSSI_TrackNo.ReadOnly = False
                    End If
                    If Me.S_ID.Text < 7 Then
                        Me.Final_PSSI2Cust_TrackNo.ReadOnly = True
                    Else
                        Me.Final_PSSI2Cust_TrackNo.ReadOnly = False
                    End If
                End If

                Me.btnUpdate.ForeColor = Color.RoyalBlue

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDataToUpdatePanel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub BindDataToUpdatePanel_Bulk(Optional ByVal rowIdx As Integer = 0)
            Try
                Dim iRowID As Integer = Me.tdgData.Row
                Dim myD As Date

                If rowIdx > 0 Then
                    iRowID = rowIdx
                End If

                Me.tdgData.SelectedRows.Add(iRowID) 'select current row

                Dim j As Integer = 0
                Me.RowID.Text = iRowID + 1

                If Not IsDBNull(Me.tdgData.Columns("EW_ID").CellText(iRowID)) Then Me.EW_ID.Text = Me.tdgData.Columns("EW_ID").CellText(iRowID) Else Me.EW_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("WO_ID").CellText(iRowID)) Then Me.WO_ID.Text = Me.tdgData.Columns("WO_ID").CellText(iRowID) Else Me.WO_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("RMA_No").CellText(iRowID)) Then Me.RMA_No.Text = Me.tdgData.Columns("RMA_No").CellText(iRowID) Else Me.RMA_No.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Name").CellText(iRowID)) Then Me.txtName.Text = Me.tdgData.Columns("Name").CellText(iRowID) Else Me.txtName.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Address1").CellText(iRowID)) Then Me.Address1.Text = Me.tdgData.Columns("Address1").CellText(iRowID) Else Me.Address1.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Address2").CellText(iRowID)) Then Me.Address2.Text = Me.tdgData.Columns("Address2").CellText(iRowID) Else Me.Address2.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("City").CellText(iRowID)) Then Me.City.Text = Me.tdgData.Columns("City").CellText(iRowID) Else Me.City.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("ZipCode").CellText(iRowID)) Then Me.ZipCode.Text = Me.tdgData.Columns("ZipCode").CellText(iRowID) Else Me.ZipCode.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("State").CellText(iRowID)) Then Me.State.Text = Me.tdgData.Columns("State").CellText(iRowID) Else Me.State.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Country").CellText(iRowID)) Then Me.Country.Text = Me.tdgData.Columns("Country").CellText(iRowID) Else Me.Country.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("State_ID").CellText(iRowID)) Then Me.State_ID.Text = Me.tdgData.Columns("State_ID").CellText(iRowID) Else Me.State_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Cntry_ID").CellText(iRowID)) Then Me.Cntry_ID.Text = Me.tdgData.Columns("Cntry_ID").CellText(iRowID) Else Me.Cntry_ID.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("WO_Quantity").CellText(iRowID)) Then Me.WO_Quantity.Text = Me.tdgData.Columns("WO_Quantity").CellText(iRowID) Else Me.WO_Quantity.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("RepairType").CellText(iRowID)) Then Me.RepairType.Text = Me.tdgData.Columns("RepairType").CellText(iRowID) Else Me.RepairType.Text = ""
                If Not IsDBNull(Me.tdgData.Columns("Warranty").CellText(iRowID)) Then Me.Warranty.Text = Me.tdgData.Columns("Warranty").CellText(iRowID) Else Me.Warranty.Text = ""

                Me.btnUpdate.ForeColor = Color.RoyalBlue

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDataToUpdatePanel_Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub BindDetailDataToDetailGrid()
            Try
                Dim iRowID As Integer = Me.tdgData.Row
                'Dim myD As Date
                Dim dt As DataTable
                Dim iWO_ID As Integer

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Me.tdgData.SelectedRows.Add(iRowID) 'select current row

                If Not IsDBNull(Me.tdgData.Columns("WO_ID").Value) Then
                    iWO_ID = Me.tdgData.Columns("WO_ID").Value
                Else
                    MessageBox.Show("Work Order ID is nothing!")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
                Me._objNIDataM = New NIDataManagement()
                dt = Me._objNIDataM.GetNIBulkData_Detail(Me._iMenuCustID, iWO_ID)
                Me.tdgData_Detail.DataSource = dt

                If tdgData.RowCount > 0 Then
                    Me.lblRecNum_Detail.Text = "Total Row Count: " & tdgData_Detail.RowCount
                    Me.lblCurrentRecNum_Detail.Text = "Current Row Count: " & Me.tdgData_Detail.RowCount
                Else
                    Me.lblRecNum_Detail.Text = "Total Row Count: 0"
                    Me.lblCurrentRecNum_Detail.Text = "Current Row Count: 0"
                End If

                Me.Cursor = System.Windows.Forms.Cursors.Default

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindDetailDataToDetailGrid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub LoadEndUserData()
            Dim dt As DataTable

            Try
                Me._objNIDataM = New NIDataManagement()
                dt = Me._objNIDataM.GetNIRMAEndUserData(Me._iMenuCustID)
                Me.tdgData.DataSource = dt

                If tdgData.RowCount > 0 Then
                    Me.lblRecNum.Text = "Total Row Count: " & tdgData.RowCount
                    Me.lblCurrentRecNum.Text = "Current Row Count: " & Me.tdgData.RowCount
                Else
                    Me.lblRecNum.Text = "Total Row Count: 0"
                    Me.lblCurrentRecNum.Text = "Current Row Count: 0"
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadEndUserData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub LoadBulkMasterData()
            Dim dt As DataTable

            Try
                Me._objNIDataM = New NIDataManagement()
                dt = Me._objNIDataM.GetNIBulkData_Master(Me._iMenuCustID)
                Me.tdgData.DataSource = dt

                If tdgData.RowCount > 0 Then
                    Me.lblRecNum.Text = "Total Row Count: " & tdgData.RowCount
                    Me.lblCurrentRecNum.Text = "Current Row Count: " & Me.tdgData.RowCount
                Else
                    Me.lblRecNum.Text = "Total Row Count: 0"
                    Me.lblCurrentRecNum.Text = "Current Row Count: 0"
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadBulkMasterData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub cmbTypeSwitch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTypeSwitch.SelectedIndexChanged
            Try
                If Me.cmbTypeSwitch.SelectedItem = "End User" Then
                    Me._IsEndUserData = True : Me._IsBulkData = False
                    LoadEndUserData()
                    Me.rbtView.Checked = False : Me.rbtView.Checked = True
                ElseIf Me.cmbTypeSwitch.SelectedItem = "Bulk" Then
                    Me._IsEndUserData = False : Me._IsBulkData = True
                    LoadBulkMasterData()
                    Me.rbtView.Checked = False : Me.rbtView.Checked = True 'simulate a change
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "rbtView_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cmbCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCountry.SelectedIndexChanged
            Try
                RefreshStateNames(Me.cmbCountry.SelectedValue, False)
            Catch ex As Exception
                'Not need:  MessageBox.Show(ex.ToString, "cmbCountry_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub State_ID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles State_ID.TextChanged
            DataHaveChanged()
        End Sub

        '********************************************************************************
        Private Sub Cntry_ID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cntry_ID.TextChanged
            DataHaveChanged()
        End Sub

        '********************************************************************************
        Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Address1.Leave, Address2.Leave, City.Leave, ZipCode.Leave, Phone.Leave, Email.Leave, PSSI2Cust_TrackNo.Leave, Cust2PSSI_TrackNo.Leave, Final_PSSI2Cust_TrackNo.Leave, WO_Quantity.Leave
            Try
                'If DataHaveChanged() And Me.rbtEdit.Checked Then
                '    Dim reply As DialogResult = MessageBox.Show("Record not saved! Do you want to save?", "Your selection", _
                '          MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                '    If reply = DialogResult.Yes Then
                '        MessageBox.Show("yes")
                '    Else
                '        MessageBox.Show("no")
                '    End If
                'End If
                If DataHaveChanged() And Me.rbtEdit.Checked Then
                    Me.tdgData.Enabled = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtName_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub RMA_No_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RMA_No.Leave
            Try
                If Me._IsBulkData AndAlso Me.rbtAddNew.Checked Then
                    'Check for duplicated RMA (existing)
                    _objNIDataM = New NIDataManagement()
                    If _objNIDataM.RMANumberExist(Me._iMenuCustID, 2, Me.RMA_No.Text.Trim) Then
                        MessageBox.Show("RMA_No """ & Me.RMA_No.Text.Trim & """ exists!")
                        Me.RMA_No.Text = "" : Me.RMA_No.Focus() : Exit Sub
                    End If
                    _objNIDataM = Nothing
                ElseIf Me._IsEndUserData AndAlso Me.rbtAddNew.Checked Then
                    'Check for duplicated RMA (existing)
                    _objNIDataM = New NIDataManagement()
                    If _objNIDataM.RMANumberExist(Me._iMenuCustID, 1, Me.RMA_No.Text.Trim) Then
                        MessageBox.Show("RMA_No """ & Me.RMA_No.Text.Trim & """ exists!")
                        Me.RMA_No.Text = "" : Me.RMA_No.Focus() : Exit Sub
                    End If
                    _objNIDataM = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RMA_No_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgData.MouseUp
            Try
                If Me._IsEndUserData Then BindDataToUpdatePanel()
                If Me._IsBulkData AndAlso Me.rbtView.Checked Then BindDetailDataToDetailGrid()
                If Me._IsBulkData AndAlso Me.rbtEdit.Checked Then BindDataToUpdatePanel_Bulk()
                If Me._IsBulkData AndAlso Me.rbtAddNew.Checked Then BindDataToUpdatePanel_Bulk()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData.AfterSort
            Try
                If tdgData.RowCount > 0 Then
                    Me.lblCurrentRecNum.Text = "Current Row Count: " & Me.tdgData.RowCount
                Else
                    Me.lblCurrentRecNum.Text = "Current Row Count: 0"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData_AfterSort", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData.AfterFilter
            Try
                If tdgData.RowCount > 0 Then
                    Me.lblCurrentRecNum.Text = "Current Row Count: " & Me.tdgData.RowCount
                Else
                    Me.lblCurrentRecNum.Text = "Current Row Count: 0"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData_Detail_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData_Detail.AfterSort
            Try
                If tdgData_Detail.RowCount > 0 Then
                    Me.lblCurrentRecNum_Detail.Text = "Current Row Count: " & Me.tdgData_Detail.RowCount
                Else
                    Me.lblCurrentRecNum_Detail.Text = "Current Row Count: 0"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData_Detail_AfterSort", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgData_Detail_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgData_Detail.AfterFilter
            Try
                If tdgData_Detail.RowCount > 0 Then
                    Me.lblCurrentRecNum_Detail.Text = "Current Row Count: " & Me.tdgData_Detail.RowCount
                Else
                    Me.lblCurrentRecNum_Detail.Text = "Current Row Count: 0"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgData_Detail_AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strSQL As String = ""
            Try
                If Me._IsEndUserData AndAlso Me.rbtEdit.Checked AndAlso DataHaveChanged() Then
                    EditMode_getUpdateSQL4EndUser()
                ElseIf Me._IsEndUserData AndAlso Me.rbtAddNew.Checked Then
                    AddNewMode_getAddSQL4EndUser()
                ElseIf Me._IsBulkData AndAlso Me.rbtEdit.Checked AndAlso DataHaveChanged() Then
                    EditMode_getUpdateSQL4Bulk()
                ElseIf Me._IsBulkData AndAlso Me.rbtAddNew.Checked Then
                    AddNewMode_getAddSQL4Bulk()
                End If

                'MessageBox.Show(strSQL)

                If Me.rbtEdit.Checked Then
                    Me.tdgData.Enabled = True
                Else
                    Exit Sub
                End If
                Me.btnUpdate.ForeColor = Color.RoyalBlue

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Try
                If Me._IsEndUserData Then
                    LoadEndUserData()
                ElseIf Me._IsBulkData Then
                    LoadBulkMasterData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnSelectCountryState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectCountryState.Click
            Dim dt As DataTable, dt2 As DataTable
            Dim strSQL As String

            Try
                'Me.pnlSelectCountryState.Top = 0
                'Me.pnlSelectCountryState.Left = 0
                'Me.pnlSelectCountryState.Height = Me.pnlDataUpdate.Height
                'Me.pnlSelectCountryState.Width = Me.pnlDataUpdate.Width
                Me.pnlSelectCountryState.Visible = True
                'Me.pnlSelectCountryState.BringToFront()

                'Me.pnlDataUpdate_Center.Top = Me.pnlDataUpdate.Height / 2 - Me.pnlDataUpdate_Center.Height / 2
                'Me.pnlDataUpdate_Center.Left = Me.pnlDataUpdate.Width / 2 - Me.pnlDataUpdate_Center.Width / 2


                _objNIDataM = New NIDataManagement()

                dt = _objNIDataM.GetCountryNames()
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No country names found!")
                    Exit Sub
                End If
                Me.cmbCountry.DataSource = dt : Me.cmbCountry2.DataSource = dt
                Me.cmbCountry.ValueMember = dt.Columns("Cntry_ID").ToString : Me.cmbCountry2.ValueMember = dt.Columns("Cntry_ID").ToString
                Me.cmbCountry.DisplayMember = dt.Columns("Cntry_Name").ToString : Me.cmbCountry2.DisplayMember = dt.Columns("Cntry_ShortName").ToString

                If dt.Rows.Count > 0 Then
                    If Me.Cntry_ID.Text.Trim.Length > 0 AndAlso Convert.ToInt32(Me.Cntry_ID.Text) > 0 Then
                        Me.cmbCountry.SelectedValue = Convert.ToInt32(Me.Cntry_ID.Text)
                    Else
                        Me.cmbCountry.SelectedValue = 161
                    End If
                End If

                RefreshStateNames(Me.cmbCountry.SelectedValue, True)

                dt = Nothing : _objNIDataM = Nothing

            Catch ex As Exception
                ' MessageBox.Show(ex.ToString, "btnSelectCountryState_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Try

                Me.Cntry_ID.Text = Me.cmbCountry.SelectedValue
                Me.Country.Text = Me.cmbCountry2.Text
                Me.State_ID.Text = Me.cmbState.SelectedValue
                Me.State.Text = Me.cmbState2.Text
                Me.pnlSelectCountryState.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.pnlSelectCountryState.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        '********************************************************************************
        Private Sub btnProductSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductSelect.Click
            Try
                Me.Prod_Code.Text = Me.cmbProduct.SelectedValue
                Me.Product.Text = Me.cmbProduct.Text
                Me.pnlProduct.Visible = False : Me.btnSelectProduct.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnProductSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnProductClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductClose.Click
            Try
                Me.pnlProduct.Visible = False : Me.btnSelectProduct.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnProductClose_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub EditMode_getUpdateSQL4EndUser()
            Dim iRowIndex As Integer, iRowIndex_New As Integer
            Dim strSQL As String = "", strSQL_Second As String = ""
            Dim strOldValues As String = ""
            Dim strCol As String = "", strCol_Second As String = ""
            Dim S1 As String = "", S2 As String = ""
            Dim iN1 As Integer = 0, iN2 As Integer = 0
            Dim StrSQL_Ready1 As String = "", StrSQL_Ready2 As String = ""
            Dim sessionDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                'Table 1: production.extendedwarranty - ClaimNo, WO_ID, Shipto_Name, address1,address2,City,State_ShortName, ZipCode,Cntry_name,Tel,Email
                '                                       State_ID,Cntry_ID
                'Table 2: saleorders.SOheader - CustomerOrderNumber as ClaimNo,WorkOrderID as WO_ID,CustomerFirstName as Shipto_Name, 
                '                               CustomerAddress1 as address1, CustomerAddress2 as address2,CustomerCity as city,
                '                               CustomerState as State_ShortName,CustomerPostalCode ZipCode,CustomerCountry as cntry_Name,
                '                               CustomerPhone as tel, CustomerEmail as Email

                iRowIndex = Me.RowID.Text - 1

                'ShipTo_Name
                If Me.txtName.Text.Trim.Length > 0 Then
                    S2 = Me.txtName.Text.Trim : S1 = Me.tdgData.Columns("Name").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "ShipTo_Name=" : strCol_Second = "CustomerFirstName="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("Name field can't be nothing.") : Exit Sub
                End If

                'Address
                If Not Me.Address1.Text.Length + Me.Address2.Text.Length > 0 Then
                    MessageBox.Show("Address field(s) can't be nothing.") : Exit Sub
                End If
                If Me.Address1.Text.Trim.Length > 0 Then
                    S2 = Me.Address1.Text.Trim : S1 = Me.tdgData.Columns("Address1").CellText(iRowIndex).ToString.Trim
                    If Not S1.ToUpper = S2.ToUpper Then
                        strCol = "Address1=" : strCol_Second = "CustomerAddress1="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    S2 = Me.Address1.Text.Trim : S1 = Me.tdgData.Columns("Address1").CellText(iRowIndex).ToString.Trim
                    If S1.Length > 0 Then
                        strCol = "Address1=" : strCol_Second = "CustomerAddress1="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                End If
                If Me.Address2.Text.Trim.Length > 0 Then
                    S2 = Me.Address2.Text.Trim : S1 = Me.tdgData.Columns("Address2").CellText(iRowIndex).ToString.Trim
                    If Not S1.ToUpper = S2.ToUpper Then
                        strCol = "Address2=" : strCol_Second = "CustomerAddress2="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    If Not Me.tdgData.Columns("Address2").CellText(iRowIndex).ToString.Trim.Length = 0 Then
                        S2 = Me.Address1.Text.Trim : S1 = Me.tdgData.Columns("Address1").CellText(iRowIndex).ToString.Trim
                        If S1.Length > 0 Then
                            strCol = "Address2=" : strCol_Second = "CustomerAddress2="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                            If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                        End If
                    End If
                End If

                'City
                If Me.City.Text.Trim.Length > 0 Then
                    S2 = Me.City.Text.Trim : S1 = Me.tdgData.Columns("City").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "City=" : strCol_Second = "CustomerCity="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("City field can't be nothing.") : Exit Sub
                End If

                'ZipCode
                If Me.ZipCode.Text.Trim.Length > 0 Then
                    S2 = Me.ZipCode.Text.Trim : S1 = Me.tdgData.Columns("ZipCode").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "ZipCode=" : strCol_Second = "CustomerPostalCode="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("ZipCode field can't be nothing.") : Exit Sub
                End If

                'State:  State_ShortName, State_ID
                If Me.State.Text.Trim.Length > 0 Then
                    S2 = Me.State.Text.Trim : S1 = Me.tdgData.Columns("State").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "State_ShortName=" : strCol_Second = "CustomerState="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("State field can't be nothing.") : Exit Sub
                End If
                Try
                    iN2 = Me.State_ID.Text
                    If iN2 > 0 Then
                        iN1 = Me.tdgData.Columns("State_ID").CellText(iRowIndex)
                        If Not iN2 = iN1 Then
                            strCol = "State_ID="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & iN2 Else strSQL &= strCol & iN2
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & iN1 Else strOldValues &= strCol & iN1
                        End If
                    Else
                        MessageBox.Show("Invalid State ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid State ID. " & ex.Message) : Exit Sub
                End Try

                'Country:  Cntry_Name, Cntry_ID
                If Me.Country.Text.Trim.Length > 0 Then
                    S2 = Me.Country.Text.Trim : S1 = Me.tdgData.Columns("Country").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "Cntry_Name=" : strCol_Second = "CustomerCountry="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("Country field can't be nothing.") : Exit Sub
                End If
                Try
                    iN2 = Me.Cntry_ID.Text
                    If iN2 > 0 Then
                        iN1 = Me.tdgData.Columns("Cntry_ID").CellText(iRowIndex)
                        If Not iN2 = iN1 Then
                            strCol = "Cntry_ID="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & iN2 Else strSQL &= strCol & iN2
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & iN1 Else strOldValues &= strCol & iN1
                        End If
                    Else
                        MessageBox.Show("Invalid Country ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid Country ID. " & ex.Message) : Exit Sub
                End Try

                'Phone: Tel
                S2 = Me.Phone.Text.Trim : S1 = Me.tdgData.Columns("Phone").CellText(iRowIndex).ToString.Trim
                If Not S2.ToUpper = S1.ToUpper Then
                    strCol = "Tel=" : strCol_Second = "CustomerPhone="
                    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                    If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                End If

                'Email
                S2 = Me.Email.Text.Trim : S1 = Me.tdgData.Columns("Email").CellText(iRowIndex).ToString.Trim
                If Not S2.ToUpper = S1.ToUpper Then
                    strCol = "Email=" : strCol_Second = "CustomerEmail="
                    If EmailAddressCheck(S2) = False Then
                        MessageBox.Show("Invalid email address.") : Exit Sub
                    End If
                    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                    If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                End If

                'Make
                S2 = Me.txtMake.Text.Trim : S1 = Me.tdgData.Columns("Brand").CellText(iRowIndex).ToString.Trim
                If Not S2.ToUpper = S1.ToUpper Then
                    strCol = "Brand=" : strCol_Second = "Brand="
                    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                    If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                End If

                'Model
                S2 = Me.txtModel.Text.Trim : S1 = Me.tdgData.Columns("Model").CellText(iRowIndex).ToString.Trim
                If Not S2.ToUpper = S1.ToUpper Then
                    strCol = "Model=" : strCol_Second = "Model="
                    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                    If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                End If

                'Product (i.e., Type)
                S2 = Me.Product.Text.Trim : S1 = Me.tdgData.Columns("Product").CellText(iRowIndex).ToString.Trim
                If Not S2.ToUpper = S1.ToUpper Then
                    strCol = "Type=" : strCol_Second = "Type="
                    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                    If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(S2) Else strSQL_Second &= strCol_Second & CorrectString(S2)
                    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                End If

                'Prod_Code
                Try
                    iN2 = Me.Prod_Code.Text
                    If iN2 > 0 Then
                        iN1 = Me.tdgData.Columns("Prod_Code").CellText(iRowIndex)
                        If Not iN2 = iN1 Then
                            strCol = "Prod_Code="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & iN2 Else strSQL &= strCol & iN2
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & iN1 Else strOldValues &= strCol & iN1
                        End If
                    Else
                        MessageBox.Show("Invalid Prod_Code.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid Prod_Code. " & ex.Message) : Exit Sub
                End Try


                'Update Reason
                If Not Me.UpdateReason.Text.Trim.Length > 0 Then
                    MessageBox.Show("Update Reason field can't be nothing. Please enter a reason!") : Exit Sub
                End If

                'It is not easy to update tracking numbers, must manually change it by IT--------------------------------------
                ''PSSI2Cust_TrackNo
                'S2 = Me.PSSI2Cust_TrackNo.Text.Trim : S1 = Me.tdgData.Columns("PSSI2Cust_TrackNo").CellText(iRowIndex).ToString.Trim
                'If Not S2.ToUpper = S1.ToUpper Then
                '    strCol = "PSSI2Cust_TrackNo="
                '    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                '    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                'End If

                ''Cust2PSSI_TrackNo
                'S2 = Me.Cust2PSSI_TrackNo.Text.Trim : S1 = Me.tdgData.Columns("Cust2PSSI_TrackNo").CellText(iRowIndex).ToString.Trim
                'If Not S2.ToUpper = S1.ToUpper Then
                '     strCol = "Cust2PSSI_TrackNo="
                '    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                '    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                'End If

                ''Final_PSSI2Cust_TrackNo
                'S2 = Me.Final_PSSI2Cust_TrackNo.Text.Trim : S1 = Me.tdgData.Columns("Final_PSSI2Cust_TrackNo").CellText(iRowIndex).ToString.Trim
                'If Not S2.ToUpper = S1.ToUpper Then
                '    strCol = "Final_PSSI2Cust_TrackNo="
                '    If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                '    If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                'End If

                'MessageBox.Show("strSQL=" & strSQL & vbCrLf & "strSQL_Second=" & strSQL_Second & vbCrLf & "oldValues=" & strOldValues)
                'Exit Sub

                'Update -----------------------------------------------------------------------------------------------------------------------------
                If strSQL.Length > 0 AndAlso strSQL_Second.Length > 0 Then
                    If Me.WO_ID.Text.Trim.Length > 0 AndAlso IsNumeric(Me.WO_ID.Text) Then 'update production.extendedwarranty table or both of production.extendedwarranty and Salesorder.SOHeader tables
                        Dim IsFirstTable As Boolean, IsSecondTable As Boolean
                        Dim ErrMsg As String = ""
                        Me._objNIDataM = New NIDataManagement()
                        Me._objNIDataM.ValidateTableRecord(Me.EW_ID.Text, Me.WO_ID.Text, Me._iMenuCustID, Me.RMA_No.Text, IsFirstTable, IsSecondTable, ErrMsg)

                        If ErrMsg.Trim.Length > 0 Then  'failed
                            MessageBox.Show("Failed to update! " & ErrMsg)
                            Exit Sub
                        Else 'OK
                            If IsFirstTable = True AndAlso IsSecondTable = True Then 'Update 2 table
                                '----------------------------------------------------------------------------------------------------------------
                                If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
                                    StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
                                    'update first table
                                    If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
                                        'save log
                                        If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                                               Me._iMenuCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
                                                               StrSQL_Ready1.Replace("'", "''")) Then
                                        Else
                                            MessageBox.Show("Alert1: Failed to save the updated log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
                                        End If
                                    Else
                                        MessageBox.Show("Failed to update production.extendedwarranty.")
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Failed to update! No record to update in production.extendedwarranty.")
                                    Exit Sub
                                End If

                                '----------------------------------------------------------------------------------------------------------------
                                StrSQL_Ready2 = "Update saleorders.SOheader Set " & strSQL_Second & _
                                                " Where WorkOrderID =" & Me.WO_ID.Text & _
                                                " And Cust_ID=" & Me._iMenuCustID & _
                                                " And  CustomerOrderNumber='" & Me.RMA_No.Text & "'"
                                'update second table
                                If Me._objNIDataM.UpdateTable(StrSQL_Ready2) Then
                                    'save log
                                    If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                                           Me._iMenuCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
                                                           StrSQL_Ready2.Replace("'", "''")) Then
                                    Else
                                        MessageBox.Show("Alert2: Failed to save the updated log for saleorders.SOheader.  (Tracker.extendedwarranty_log)")
                                    End If
                                Else
                                    MessageBox.Show("Failed to update saleorders.SOheader.")
                                    Exit Sub
                                End If
                                '----------------------------------------------------------------------------------------------------------------

                            ElseIf IsFirstTable = True AndAlso IsSecondTable = False Then 'update the first table only
                                If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
                                    StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
                                    'update
                                    If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
                                        'save log
                                        If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                                               Me._iMenuCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
                                                               StrSQL_Ready1.Replace("'", "''")) Then
                                        Else
                                            MessageBox.Show("Alert3: Failed to save the updated log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
                                        End If
                                    Else
                                        MessageBox.Show("Failed to update production.extendedwarranty.")
                                        Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Failed to update! No record to update in production.extendedwarranty.")
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("Failed to update! No Table(s) to update. Exception of ValidateTableRecord")
                                Exit Sub
                            End If
                        End If

                    Else 'only update production.extendedwarranty table, WO_ID is nothing
                        Me._objNIDataM = New NIDataManagement()
                        If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
                            StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
                            'update
                            If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
                                'save log
                                If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                                       Me._iMenuCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
                                                       StrSQL_Ready1.Replace("'", "''")) Then
                                Else
                                    MessageBox.Show("Alert4: Failed to save the updated log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
                                End If
                            Else
                                MessageBox.Show("Failed to update production.extendedwarranty.")
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Failed to update! No record to update in production.extendedwarranty.")
                            Exit Sub
                        End If
                        Me._objNIDataM = Nothing
                    End If
                End If

                'Refresh after update
                LoadEndUserData()
                'After update and reload data, row index could be different, so search new rowindex based on EW_ID
                iRowIndex_New = findRowIdx(Me.EW_ID.Text)
                BindDataToUpdatePanel(iRowIndex_New)

                'MessageBox.Show(" StrSQL_Ready1=" & StrSQL_Ready1 & vbCrLf & " StrSQL_Ready2=" & StrSQL_Ready2)

                MessageBox.Show("successfully updated!")

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " EditMode_getUpdateSQL4EndUser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub EditMode_getUpdateSQL4Bulk()
            Dim iRowIndex As Integer, iRowIndex_New As Integer
            Dim strSQL As String = "", strOldValues As String = ""
            Dim strSQL_Ready As String = "", strSQL_Ready2 As String = ""
            Dim strCol As String = "", strErrMsg As String = ""
            Dim S1 As String = "", S2 As String = ""
            Dim iN1 As Integer = 0, iN2 As Integer = 0
            Dim newWOQuantity As Integer, oldWOQuantity As Integer
            Dim IsWOQuantityUpdate As Boolean = False
            Dim sessionDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                iRowIndex = Me.RowID.Text - 1

                'ShipTo_Name
                If Me.txtName.Text.Trim.Length > 0 Then
                    S2 = Me.txtName.Text.Trim : S1 = Me.tdgData.Columns("Name").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "ShipTo_Name="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("Name field can't be nothing.") : Exit Sub
                End If

                'Address
                If Not Me.Address1.Text.Length + Me.Address2.Text.Length > 0 Then
                    MessageBox.Show("Address field(s) can't be nothing.") : Exit Sub
                End If
                If Me.Address1.Text.Trim.Length > 0 Then
                    S2 = Me.Address1.Text.Trim : S1 = Me.tdgData.Columns("Address1").CellText(iRowIndex).ToString.Trim
                    If Not S1.ToUpper = S2.ToUpper Then
                        strCol = "Address1="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    S2 = Me.Address1.Text.Trim : S1 = Me.tdgData.Columns("Address1").CellText(iRowIndex).ToString.Trim
                    If S1.Length > 0 Then
                        strCol = "Address1="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                End If
                If Me.Address2.Text.Trim.Length > 0 Then
                    S2 = Me.Address2.Text.Trim : S1 = Me.tdgData.Columns("Address2").CellText(iRowIndex).ToString.Trim
                    If Not S1.ToUpper = S2.ToUpper Then
                        strCol = "Address2="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    If Not Me.tdgData.Columns("Address2").CellText(iRowIndex).ToString.Trim.Length = 0 Then
                        S2 = Me.Address1.Text.Trim : S1 = Me.tdgData.Columns("Address1").CellText(iRowIndex).ToString.Trim
                        If S1.Length > 0 Then
                            strCol = "Address2="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                        End If
                    End If
                End If

                'City
                If Me.City.Text.Trim.Length > 0 Then
                    S2 = Me.City.Text.Trim : S1 = Me.tdgData.Columns("City").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "City="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("City field can't be nothing.") : Exit Sub
                End If

                'ZipCode
                If Me.ZipCode.Text.Trim.Length > 0 Then
                    S2 = Me.ZipCode.Text.Trim : S1 = Me.tdgData.Columns("ZipCode").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "ZipCode="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("ZipCode field can't be nothing.") : Exit Sub
                End If

                'State:  State_ShortName, State_ID
                If Me.State.Text.Trim.Length > 0 Then
                    S2 = Me.State.Text.Trim : S1 = Me.tdgData.Columns("State").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "State_ShortName="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("State field can't be nothing.") : Exit Sub
                End If
                Try
                    iN2 = Me.State_ID.Text
                    If iN2 > 0 Then
                        iN1 = Me.tdgData.Columns("State_ID").CellText(iRowIndex)
                        If Not iN2 = iN1 Then
                            strCol = "State_ID="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & iN2 Else strSQL &= strCol & iN2
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & iN1 Else strOldValues &= strCol & iN1
                        End If
                    Else
                        MessageBox.Show("Invalid State ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid State ID. " & ex.Message) : Exit Sub
                End Try

                'Country:  Cntry_Name, Cntry_ID
                If Me.Country.Text.Trim.Length > 0 Then
                    S2 = Me.Country.Text.Trim : S1 = Me.tdgData.Columns("Country").CellText(iRowIndex).ToString.Trim
                    If Not S2.ToUpper = S1.ToUpper Then
                        strCol = "Cntry_Name="
                        If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
                        If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
                    End If
                Else
                    MessageBox.Show("Country field can't be nothing.") : Exit Sub
                End If
                Try
                    iN2 = Me.Cntry_ID.Text
                    If iN2 > 0 Then
                        iN1 = Me.tdgData.Columns("Cntry_ID").CellText(iRowIndex)
                        If Not iN2 = iN1 Then
                            strCol = "Cntry_ID="
                            If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & iN2 Else strSQL &= strCol & iN2
                            If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & iN1 Else strOldValues &= strCol & iN1
                        End If
                    Else
                        MessageBox.Show("Invalid Country ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid Country ID. " & ex.Message) : Exit Sub
                End Try


                'Wo_Quantity
                If Not IsNumeric(Me.WO_Quantity.Text) Then
                    MessageBox.Show("Invalid WO_Quantity (must be a numeric).") : Exit Sub
                End If
                iN1 = Me.WO_Quantity.Text
                If iN1 > 0 Then
                    iN2 = Me.tdgData.Columns("WO_Quantity").CellText(iRowIndex)
                    If Not iN1 = iN2 Then
                        newWOQuantity = iN1 : oldWOQuantity = iN2
                        IsWOQuantityUpdate = True
                    End If
                Else
                    MessageBox.Show("WO_Quantity must be greater than zero.") : Exit Sub
                End If

                'Update Reason
                If Not Me.UpdateReason.Text.Trim.Length > 0 Then
                    MessageBox.Show("Update Reason field can't be nothing. Please enter a reason!") : Exit Sub
                End If


                'Update now----------------------------------------------------------------------------------------------------------------------
                If strSQL.Trim.Length > 0 AndAlso IsWOQuantityUpdate = True Then 'Update ExtendedWarranty and tWorkOrder tables
                    Me._objNIDataM = New NIDataManagement()
                    Me._objNIDataM.ValidateTableRecord_Bulk(Me.EW_ID.Text, Me.WO_ID.Text, Me._iMenuCustID, Me.RMA_No.Text, strErrMsg)
                    If strErrMsg.Trim.Length > 0 Then 'failed
                        MessageBox.Show("Failed to update! " & strErrMsg)
                        Exit Sub
                    Else 'ok
                        strSQL_Ready = "Update production.ExtendedWarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
                        If Me._objNIDataM.UpdateTable(strSQL_Ready) Then
                            'save log1
                            If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                                   Me._iMenuCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
                                                   strSQL_Ready.Replace("'", "''")) Then
                            Else
                                MessageBox.Show("Alert1: Failed to save the updated log for  production.ExtendedWarranty.  (Tracker.extendedwarranty_log)")
                            End If

                            strSQL_Ready2 = "Update production.tWorkOrder Set WO_Quantity= " & newWOQuantity & " Where WO_ID=" & Me.WO_ID.Text
                            If Me._objNIDataM.UpdateTable(strSQL_Ready2) Then
                                'save log2
                                If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                                       Me._iMenuCustID, Me.RMA_No.Text, "Update", "WO_Quantity=" & newWOQuantity, _
                                                       strSQL_Ready2.Replace("'", "''")) Then
                                Else
                                    MessageBox.Show("Alert2: Failed to save the updated log for  production.tWorkOrder.  (Tracker.extendedwarranty_log)")
                                End If
                            Else
                                MessageBox.Show("Failed to update production.tWorkOrder")
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Failed to update production.ExtendedWarranty, and skipped to update production.tWorkOrder")
                            Exit Sub
                        End If
                    End If
                ElseIf strSQL.Trim.Length > 0 AndAlso IsWOQuantityUpdate = False Then 'Update ExtendedWarranty table
                    strSQL_Ready = "Update production.ExtendedWarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
                    If Me._objNIDataM.UpdateTable(strSQL_Ready) Then
                        'save log1
                        If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                               Me._iMenuCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
                                               strSQL_Ready.Replace("'", "''")) Then
                        Else
                            MessageBox.Show("Alert1: Failed to save the updated log for  production.ExtendedWarranty.  (Tracker.extendedwarranty_log)")
                        End If
                    Else
                        MessageBox.Show("Failed to update production.ExtendedWarranty.")
                        Exit Sub
                    End If
                ElseIf (Not strSQL.Trim.Length > 0) AndAlso IsWOQuantityUpdate = True Then 'Update tWorkOrder table
                    strSQL_Ready2 = "Update production.tWorkOrder Set WO_Quantity= " & newWOQuantity & " Where WO_ID=" & Me.WO_ID.Text
                    If Me._objNIDataM.UpdateTable(strSQL_Ready2) Then
                        'save log2
                        If Me._objNIDataM.SaveLog(Me.UpdateReason.Text, sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
                                               Me._iMenuCustID, Me.RMA_No.Text, "Update", "WO_Quantity=" & newWOQuantity, _
                                               strSQL_Ready2.Replace("'", "''")) Then
                        Else
                            MessageBox.Show("Alert2: Failed to save the updated log for  production.tWorkOrder.  (Tracker.extendedwarranty_log)")
                        End If
                    Else
                        MessageBox.Show("Failed to update production.tWorkOrder")
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Exception occurred!")
                    Exit Sub
                End If
                '----------------------------------------------------------------------------------------------------------------------------------
                ' MessageBox.Show(strSQL & "   oldValues=" & strOldValues)

                'Refresh after update
                LoadBulkMasterData()
                'After update and reload data, row index could be different, so search new rowindex based on EW_ID
                iRowIndex_New = findRowIdx(Me.EW_ID.Text)
                BindDataToUpdatePanel_Bulk(iRowIndex_New)

                'MessageBox.Show(" StrSQL_Ready1=" & StrSQL_Ready1 & vbCrLf & " StrSQL_Ready2=" & StrSQL_Ready2)

                MessageBox.Show("successfully updated!")

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "EditMode_getUpdateSQL4Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub AddNewMode_getAddSQL4EndUser()
            Dim iRowIndex As Integer
            Dim strSQL As String = "", strCols As String = "", strValues As String = ""
            Dim tmpS As String = "", strColName As String = "", errMsg As String = "", strPssiStatus As String = ""
            Dim iID As Integer = 0, newEW_ID As Integer

            Try
                Dim iSC_ID As Integer = 2 'FedEx Ground
                Dim dtLoadedDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
                Dim iNI_DataSwitch As Integer = 1 'AIG RMA 
                Dim iStatus_ID As Integer = 1 'RMA Received
                Dim iReturnBoxYesNo As Integer = 1 'AIG needs return box
                Dim sessionDateTime As String = dtLoadedDateTime
                strPssiStatus = Data.Buisness.TMIRecShip.GetTMIStatusDesc(iStatus_ID)

                ' iRowIndex = Me.RowID.Text - 1

                'ClaimNo: RMA_No
                tmpS = Me.RMA_No.Text.Trim : strColName = "ClaimNo"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("RMA_No field can't be nothing.") : Exit Sub
                End If

                'Check for duplicated RMA (existing)
                _objNIDataM = New NIDataManagement()
                If _objNIDataM.RMANumberExist(Me._iMenuCustID, 1, tmpS) Then
                    MessageBox.Show("RMA_No " & tmpS & " exists!") : Exit Sub
                End If
                _objNIDataM = Nothing

                'ShipTo_Name
                tmpS = Me.txtName.Text.Trim : strColName = "ShipTo_Name"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Name field can't be nothing.") : Exit Sub
                End If

                'Address
                If Not (Me.Address1.Text.Trim.Length + Me.Address2.Text.Trim.Length) > 0 Then
                    MessageBox.Show("Address can't be nothing.") : Exit Sub
                End If
                tmpS = Me.Address1.Text.Trim : strColName = "Address1"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If
                tmpS = Me.Address2.Text.Trim : strColName = "Address2"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If

                'City
                tmpS = Me.City.Text.Trim : strColName = "City"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("City field can't be nothing.") : Exit Sub
                End If

                'ZipCode
                tmpS = Me.ZipCode.Text.Trim : strColName = "ZipCode"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("ZipCode field can't be nothing.") : Exit Sub
                End If

                'State:  State_ShortName, State_ID
                tmpS = Me.State.Text.Trim : strColName = "State_ShortName"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("State field can't be nothing.") : Exit Sub
                End If
                Try
                    iID = Me.State_ID.Text
                    If iID > 0 Then
                        strColName = "State_ID"
                        If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                        If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                    Else
                        MessageBox.Show("Invalid State ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid State ID. " & ex.Message) : Exit Sub
                End Try


                'Country:  Cntry_Name, Cntry_ID
                tmpS = Me.Country.Text.Trim : strColName = "Cntry_Name"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Country field can't be nothing.") : Exit Sub
                End If
                Try
                    iID = Me.Cntry_ID.Text
                    If iID > 0 Then
                        strColName = "Cntry_ID"
                        If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                        If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                    Else
                        MessageBox.Show("Invalid Country ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid Country ID. " & ex.Message) : Exit Sub
                End Try

                'Phone: Tel
                tmpS = Me.Phone.Text.Trim : strColName = "Tel"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Phone field can't be nothing.") : Exit Sub
                End If

                'Email
                tmpS = Me.Email.Text.Trim : strColName = "Email"
                If tmpS.Length > 0 Then
                    If EmailAddressCheck(tmpS) = False Then
                        MessageBox.Show("Invalid email address.") : Exit Sub
                    End If
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Email field can't be nothing.") : Exit Sub
                End If

                'Make
                tmpS = Me.txtMake.Text.Trim : strColName = "Brand"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Invalid Make.") : Exit Sub
                End If

                'Model
                tmpS = Me.txtModel.Text.Trim : strColName = "Model"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Invalid Model.") : Exit Sub
                End If

                'Prod_Code
                tmpS = Me.Prod_Code.Text.Trim : strColName = "Prod_Code"
                If tmpS.Length > 0 Then
                    If IsNumeric(tmpS) Then
                        iID = tmpS
                    Else
                        MessageBox.Show("Invalid Prod_Code.") : Exit Sub
                    End If
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                Else
                    MessageBox.Show("Invalid Prod_Code.") : Exit Sub
                End If

                'Product (i.e., type in extendedwarranty table)
                tmpS = Me.Product.Text.Trim : strColName = "Type"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Invalid Product.") : Exit Sub
                End If

                'If Me.pnlSelectModel.Visible = True Then
                'Try
                '    'iID = Me.Product.SelectedValue
                '    If iID > 0 Then
                '        If strCols.Trim.Length > 0 Then strCols &= ", Prod_Code" Else strCols &= "Prod_Code"
                '        If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                '    Else
                '        MessageBox.Show("Invalid Product.") : Exit Sub
                '    End If
                'Catch ex As Exception
                '    MessageBox.Show("Invalid Product.") : Exit Sub
                'End Try
                'Else
                'If strColName.Trim.Length > 0 Then strCols &= ", " & "Brand, Model" Else strCols &= "Brand, Model"
                'If strValues.Trim.Length > 0 Then strValues &= "," & "'" & Me.txtMake.Text.Trim & "', '" & Me.txtModel.Text.Trim & "'" Else strValues &= "'" & Me.txtMake.Text.Trim & "', '" & Me.txtModel.Text.Trim & "'"
                'End If

                'ServiceLevel
                tmpS = Me.ServiceLevel.SelectedItem : strColName = "ServiceLevel"
                If Not (tmpS = "Customer Ships") AndAlso Not (tmpS = "Packaging Upfront") Then
                    MessageBox.Show("Invalid Service Level.") : Exit Sub
                End If
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Invalid Service Level.") : Exit Sub
                End If

                'RepairType
                tmpS = Me.RepairType.SelectedItem : strColName = "RepairType"
                If Not (tmpS = "SendRefurb") AndAlso Not (tmpS = "SendNew") AndAlso Not (tmpS = "RepairThisUnit") AndAlso Not (tmpS = "SendNothing") Then
                    MessageBox.Show("Invalid Repair Type.") : Exit Sub
                End If
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Invalid Repair Type.") : Exit Sub
                End If

                'Warranty
                tmpS = Me.Warranty.SelectedItem : strColName = "Warranty"
                If Not (tmpS = "Yes") AndAlso Not (tmpS = "No") Then
                    MessageBox.Show("Invalid Warranty.") : Exit Sub
                End If
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then
                        If tmpS = "No" Then strValues &= "," & 0
                        If tmpS = "Yes" Then strValues &= "," & 1
                    Else
                        If tmpS = "No" Then strValues &= 0
                        If tmpS = "Yes" Then strValues &= 1
                    End If
                Else
                    MessageBox.Show("Invalid Warranty.") : Exit Sub
                End If

                'HardwareSerial: SerialNo
                tmpS = Me.HardwareSerial.Text.Trim : strColName = "SerialNo"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("HardwareSerial field can't be nothing.") : Exit Sub
                End If

                'DefectType1: ErrDesc_ItemSKU
                tmpS = Me.DefectType1.Text.Trim : strColName = "DefectType1"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("DefectType1 field can't be nothing.") : Exit Sub
                End If

                'ErrorDescription: ErrDesc_ItemSKU
                tmpS = Me.ErrorDescription.Text.Trim : strColName = "ErrDesc_ItemSKU"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("ErrorDescription field can't be nothing.") : Exit Sub
                End If

                'PurchaseDate 
                tmpS = Me.PurchaseDate.Text : strColName = "PurchaseDate"
                If Not IsDate(tmpS) Then
                    MessageBox.Show("Invalid PurchaseDate.") : Exit Sub
                End If
                If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(Format(CDate(tmpS), "yyyy-MM-dd")) Else strValues &= CorrectString(Format(CDate(tmpS), "yyyy-MM-dd"))

                'Language
                tmpS = Me.Language.Text.Trim : strColName = "Language"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Enter a language, for example, ""EN"" ") : Exit Sub
                End If

                'Un-required fields------------------------------------------------------------------------------------------------------------
                'Account
                tmpS = Me.Account.Text.Trim : strColName = "Account"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If

                'SenderReference
                tmpS = Me.SenderReference.Text.Trim : strColName = "SenderReference"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If

                'DefectType2
                tmpS = Me.DefectType2.Text.Trim : strColName = "DefectType2"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If

                'Save data
                If strCols.Trim.Length > 0 AndAlso strValues.Trim.Length > 0 Then
                    strCols &= "," & " Cust_ID, Date, SC_ID,LoadedDateTime, NI_DataSwitch, S_ID, PSSI_CurrentStatus, ReturnBoxYesNo "
                    strValues &= "," & Me._iMenuCustID & ",'" & dtLoadedDateTime & "'," & iSC_ID & _
                                 ",'" & dtLoadedDateTime & "'," & iNI_DataSwitch & "," & iStatus_ID & ", '" & strPssiStatus & "', " & iReturnBoxYesNo
                    strSQL = "(" & strCols & ") Values (" & strValues & ")"
                    strSQL = "INSERT INTO Production.ExtendedWarranty (" & strCols & ") Values (" & strValues & ");"

                    Me._objNIDataM = New NIDataManagement()
                    Me._objNIDataM.InsertNewData2Table(strSQL, newEW_ID, errMsg) 'we may need to know newEW_ID

                    If errMsg.Trim.Length > 0 Then
                        MessageBox.Show(errMsg) : Exit Sub
                    Else
                        'Save log
                        If Me._objNIDataM.SaveLog("Add new", sessionDateTime, Me._iUserID, newEW_ID, Me._iMenuCustID, Me.RMA_No.Text, "Insert", "", _
                                               strSQL.Replace("'", "''")) Then
                        Else
                            MessageBox.Show("Alert1: Failed to save the inserted log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
                        End If

                        'Refresh data 
                        LoadEndUserData()
                        Me.rbtAddNew.Checked = False
                        Me.rbtAddNew.Checked = True
                        MessageBox.Show("Successfully added!")
                    End If
                Else
                    MessageBox.Show("Exception occurred!") : Exit Sub
                End If

                'MessageBox.Show(strSQL)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AddNewMode_getAddSQL4EndUser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSelectProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectProduct.Click
            Dim dt As DataTable

            Try
                _objNIDataM = New NIDataManagement()

                dt = _objNIDataM.GetProductData
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No products!")
                    Exit Sub
                End If
                Me.cmbProduct.DataSource = dt
                Me.cmbProduct.ValueMember = dt.Columns("Prod_ID").ToString
                Me.cmbProduct.DisplayMember = dt.Columns("Prod_Desc").ToString

                Me.pnlProduct.Visible = True : Me.pnlProduct.Left = Me.btnSelectProduct.Left
                Me.btnSelectProduct.Visible = False

                _objNIDataM = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectProduct", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub AddNewMode_getAddSQL4Bulk()
            'Dim iRowIndex As Integer
            Dim strSQL As String = "", strCols As String = "", strValues As String = ""
            Dim tmpS As String = "", strColName As String = "", strErrMsg As String = ""
            Dim iID As Integer = 0, iLocID As Integer = 0, iNI_DataSwitch As Integer = 2
            Dim iWO_Quantity As Integer, iWO_ID As Integer, newEW_ID As Integer
            Dim SessionDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim iStatus_ID As Integer = 1 'RMA Received
            Dim iReturnBoxYesNo As Integer = 0
            Dim strSQL_CreatWO, strPssiStatus As String

            Try
                strSQL_CreatWO = "" : strPssiStatus = ""
                strPssiStatus = Data.Buisness.TMIRecShip.GetTMIStatusDesc(iStatus_ID)

                'ClaimNo: RMA_No
                tmpS = Me.RMA_No.Text.Trim : strColName = "ClaimNo"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("RMA_No field can't be nothing.") : Exit Sub
                End If

                'Check for duplicated RMA (existing)
                _objNIDataM = New NIDataManagement()
                If _objNIDataM.RMANumberExist(Me._iMenuCustID, 2, tmpS) Then
                    MessageBox.Show("RMA_No " & tmpS & " exists!") : Exit Sub
                End If
                _objNIDataM = Nothing

                'ShipTo_Name
                tmpS = Me.txtName.Text.Trim : strColName = "ShipTo_Name"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Name field can't be nothing.") : Exit Sub
                End If

                'Address
                If Not (Me.Address1.Text.Trim.Length + Me.Address2.Text.Trim.Length) > 0 Then
                    MessageBox.Show("Address can't be nothing.") : Exit Sub
                End If
                tmpS = Me.Address1.Text.Trim : strColName = "Address1"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If
                tmpS = Me.Address2.Text.Trim : strColName = "Address2"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                End If

                'City
                tmpS = Me.City.Text.Trim : strColName = "City"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("City field can't be nothing.") : Exit Sub
                End If

                'ZipCode
                tmpS = Me.ZipCode.Text.Trim : strColName = "ZipCode"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("ZipCode field can't be nothing.") : Exit Sub
                End If

                'State:  State_ShortName, State_ID
                tmpS = Me.State.Text.Trim : strColName = "State_ShortName"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("State field can't be nothing.") : Exit Sub
                End If
                Try
                    iID = Me.State_ID.Text
                    If iID > 0 Then
                        strColName = "State_ID"
                        If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                        If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                    Else
                        MessageBox.Show("Invalid State ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid State ID. " & ex.Message) : Exit Sub
                End Try


                'Country:  Cntry_Name, Cntry_ID
                tmpS = Me.Country.Text.Trim : strColName = "Cntry_Name"
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
                Else
                    MessageBox.Show("Country field can't be nothing.") : Exit Sub
                End If
                Try
                    iID = Me.Cntry_ID.Text
                    If iID > 0 Then
                        strColName = "Cntry_ID"
                        If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                        If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                    Else
                        MessageBox.Show("Invalid Country ID.") : Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show("Invalid Country ID. " & ex.Message) : Exit Sub
                End Try

                'WO_Quantity
                If IsNumeric(Me.WO_Quantity.Text) Then
                    Try
                        iID = Me.WO_Quantity.Text
                        If iID > 0 Then
                            iWO_Quantity = iID
                        Else
                            MessageBox.Show("Invalid WO_Quantity (must be a numeric value.") : Exit Sub
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Exception error: WO_Quantity." & ex.Message) : Exit Sub
                    End Try
                Else
                    MessageBox.Show("Invalid WO_Quantity (must be a numeric value).") : Exit Sub
                End If

                'Warranty
                tmpS = Me.Warranty.SelectedItem : strColName = "Warranty"
                If Not (tmpS = "Yes") AndAlso Not (tmpS = "No") Then
                    MessageBox.Show("Invalid Warranty.") : Exit Sub
                End If
                If tmpS.Length > 0 Then
                    If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                    If strValues.Trim.Length > 0 Then
                        If tmpS = "No" Then strValues &= "," & 0
                        If tmpS = "Yes" Then strValues &= "," & 1
                    Else
                        If tmpS = "No" Then strValues &= 0
                        If tmpS = "Yes" Then strValues &= 1
                    End If
                Else
                    MessageBox.Show("Invalid Warranty.") : Exit Sub
                End If

                'default values---------------------------------------------------------------------------------------------
                strColName = "RepairType"
                If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
                If strValues.Trim.Length > 0 Then strValues &= ",'SendNothing'" Else strValues &= "'SendNothing'"

                If strCols.Trim.Length > 0 AndAlso strValues.Trim.Length > 0 Then
                    strSQL = "(" & strCols & ") Values (" & strValues & ")"
                Else
                    MessageBox.Show("Exception occurred!") : Exit Sub
                End If

                'Product
                If Me.pnlSelectModel.Visible = True Then
                    Try
                        ' iID = Me.Product.SelectedValue
                        If iID > 0 Then
                            If strCols.Trim.Length > 0 Then strCols &= ", Prod_Code" Else strCols &= "Prod_Code"
                            If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
                        Else
                            MessageBox.Show("Invalid Product.") : Exit Sub
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Invalid Product.") : Exit Sub
                    End Try
                Else
                    If strColName.Trim.Length > 0 Then strColName &= ", " & "Brand, Model" Else strColName &= "Brand, Model"
                    If strValues.Trim.Length > 0 Then strValues &= "," & "'" & Me.txtMake.Text.Trim & "', '" & Me.txtModel.Text.Trim & "'" Else strValues &= "'" & Me.txtMake.Text.Trim & "', '" & Me.txtModel.Text.Trim & "'"
                End If

                ' MessageBox.Show(strSQL)

                'Save data
                If strCols.Trim.Length > 0 AndAlso strValues.Trim.Length > 0 Then
                    Me._objNIDataM = New NIDataManagement()
                    iLocID = Me._objNIDataM.getLocationID(Me._iMenuCustID)
                    If Not iLocID > 0 Then
                        MessageBox.Show("Invalid location ID!") : Exit Sub
                    End If

                    'create workorder 
                    Me._objNIDataM.CreateWorkOrder_Bulk(SessionDateTime, Me.RMA_No.Text.Trim, iWO_Quantity, iLocID, Me._iGroupID, iWO_ID, strErrMsg)
                    strSQL_CreatWO = "INSERT INTO Production.tWorkOrder (Wo_Date,WO_CustWO,WO_Quantity,Loc_ID)" & _
                        " VALUES ('" & SessionDateTime & "','" & Me.RMA_No.Text.Trim & "'," & iWO_Quantity & "," & iLocID & ");"

                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show("Failed to create a work order! " & strErrMsg) : Exit Sub
                    Else
                        If iWO_ID > 0 Then
                            strCols &= "," & "WO_ID, Cust_ID, Date, LoadedDateTime, NI_DataSwitch, S_ID, PSSI_CurrentStatus, ReturnBoxYesNo "
                            strValues &= "," & iWO_ID & "," & Me._iMenuCustID & ",'" & SessionDateTime & "','" & _
                                         SessionDateTime & "'," & iNI_DataSwitch & "," & iStatus_ID & ", '" & strPssiStatus & "', " & iReturnBoxYesNo
                            strSQL = "INSERT INTO Production.ExtendedWarranty (" & strCols & ") VALUES (" & strValues & ");"
                            Me._objNIDataM.InsertNewData2Table(strSQL, newEW_ID, strErrMsg)
                            If strErrMsg.Trim.Length > 0 Then
                                MessageBox.Show("Failed to add bulk data to production.extendedwarranty! " & strErrMsg) : Exit Sub
                            Else
                                'Save log
                                If Me._objNIDataM.SaveLog("Add new master bulk data", SessionDateTime, Me._iUserID, newEW_ID, Me._iMenuCustID, Me.RMA_No.Text, "Insert", "", _
                                strSQL_CreatWO.Replace("'", "''")) Then
                                Else
                                    MessageBox.Show("Alert1: Failed to save the inserted log for production.tWorkorder. (Tracker.extendedwarranty_log)")
                                End If
                                If Me._objNIDataM.SaveLog("Add new master bulk data", SessionDateTime, Me._iUserID, newEW_ID, Me._iMenuCustID, Me.RMA_No.Text, "Insert", "", _
                                                       strSQL.Replace("'", "''")) Then
                                Else
                                    MessageBox.Show("Alert2: Failed to save the inserted log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
                                End If
                            End If

                            'Refresh data 
                            LoadBulkMasterData()
                            Me.rbtAddNew.Checked = False
                            Me.rbtAddNew.Checked = True
                            MessageBox.Show("Successfully added!")
                        Else
                            MessageBox.Show("Invalid WO_ID!") : Exit Sub
                        End If
                    End If
                Else
                    MessageBox.Show("Exception occurred!") : Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "AddNewMode_getAddSQL4Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Sub RefreshStateNames(ByVal iCntryID As Integer, ByVal IsTheFirstBound As Boolean)
            Dim dt As DataTable
            Dim strSQL As String

            Try
                _objNIDataM = New NIDataManagement()
                dt = _objNIDataM.GetStateNames(iCntryID)
                Me.cmbState.DataSource = dt : Me.cmbState2.DataSource = dt
                Me.cmbState.ValueMember = dt.Columns("State_ID").ToString : Me.cmbState2.ValueMember = dt.Columns("State_ID").ToString
                Me.cmbState.DisplayMember = dt.Columns("State_Long").ToString : Me.cmbState2.DisplayMember = dt.Columns("State_Short").ToString

                If Me.rbtEdit.Checked Then
                    If Me.State_ID.Text.Length = 0 Then
                        MessageBox.Show(Me.State.Text & " has invalid State_ID!")
                        Exit Sub
                    End If
                    If Not Me.State_ID.Text > 0 Then
                        MessageBox.Show(Me.State.Text & " has invalid State_ID!")
                        Exit Sub
                    End If
                    If IsTheFirstBound Then
                        Try
                            Me.cmbState.SelectedValue = Me.State_ID.Text
                        Catch ex As Exception
                            Try
                                Me.cmbState.SelectedIndex = 1 : Me.cmbState2.SelectedIndex = 1
                            Catch ex2 As Exception
                            End Try
                        End Try
                    End If
                End If

                If Me.rbtAddNew.Checked Then
                    Try
                        Me.cmbState.SelectedIndex = 1 : Me.cmbState2.SelectedIndex = 1
                    Catch ex2 As Exception
                    End Try
                End If

                dt = Nothing : _objNIDataM = Nothing

            Catch ex As Exception
                'Not need: MessageBox.Show(ex.ToString, "RefreshStateNames", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '********************************************************************************
        Private Function DataHaveChanged() As Boolean
            Dim tmpStr As String = ""

            Me.btnUpdate.ForeColor = Color.RoyalBlue

            Try
                If Not Me.rbtEdit.Checked Then
                    Return False : Exit Function
                End If


                If Not IsDBNull(Me.tdgData.Columns("Name").Value) Then tmpStr = Me.tdgData.Columns("Name").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.txtName.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Address1").Value) Then tmpStr = Me.tdgData.Columns("Address1").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.Address1.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Address2").Value) Then tmpStr = Me.tdgData.Columns("Address2").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.Address2.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("City").Value) Then tmpStr = Me.tdgData.Columns("City").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.City.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("ZipCode").Value) Then tmpStr = Me.tdgData.Columns("ZipCode").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.ZipCode.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("State_ID").Value) Then tmpStr = Me.tdgData.Columns("State_ID").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.State_ID.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Cntry_ID").Value) Then tmpStr = Me.tdgData.Columns("Cntry_ID").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.Cntry_ID.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Brand").Value) Then tmpStr = Me.tdgData.Columns("Brand").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.txtMake.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Model").Value) Then tmpStr = Me.tdgData.Columns("Model").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.txtModel.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Product").Value) Then tmpStr = Me.tdgData.Columns("Product").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.Product.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If
                If Not IsDBNull(Me.tdgData.Columns("Prod_Code").Value) Then tmpStr = Me.tdgData.Columns("Prod_Code").Value Else tmpStr = ""
                If Not tmpStr.Trim.ToUpper = Me.Prod_Code.Text.Trim.ToUpper Then
                    Me.btnUpdate.ForeColor = Color.Red
                    Return True : Exit Function
                End If


                If Me._IsEndUserData Then
                    If Not IsDBNull(Me.tdgData.Columns("Phone").Value) Then tmpStr = Me.tdgData.Columns("Phone").Value Else tmpStr = ""
                    If Not tmpStr.Trim.ToUpper = Me.Phone.Text.Trim.ToUpper Then
                        Me.btnUpdate.ForeColor = Color.Red
                        Return True : Exit Function
                    End If
                    If Not IsDBNull(Me.tdgData.Columns("Email").Value) Then tmpStr = Me.tdgData.Columns("Email").Value Else tmpStr = ""
                    If Not tmpStr.Trim.ToUpper = Me.Email.Text.Trim.ToUpper Then
                        Me.btnUpdate.ForeColor = Color.Red
                        Return True : Exit Function
                    End If
                    If Not IsDBNull(Me.tdgData.Columns("PSSI2Cust_TrackNo").Value) Then tmpStr = Me.tdgData.Columns("PSSI2Cust_TrackNo").Value Else tmpStr = ""
                    If Not tmpStr.Trim.ToUpper = Me.PSSI2Cust_TrackNo.Text.Trim.ToUpper Then
                        Me.btnUpdate.ForeColor = Color.Red
                        Return True : Exit Function
                    End If
                    If Not IsDBNull(Me.tdgData.Columns("Cust2PSSI_TrackNo").Value) Then tmpStr = Me.tdgData.Columns("Cust2PSSI_TrackNo").Value Else tmpStr = ""
                    If Not tmpStr.Trim.ToUpper = Me.Cust2PSSI_TrackNo.Text.Trim.ToUpper Then
                        Me.btnUpdate.ForeColor = Color.Red
                        Return True : Exit Function
                    End If
                    If Not IsDBNull(Me.tdgData.Columns("Final_PSSI2Cust_TrackNo").Value) Then tmpStr = Me.tdgData.Columns("Final_PSSI2Cust_TrackNo").Value Else tmpStr = ""
                    If Not tmpStr.Trim.ToUpper = Me.Final_PSSI2Cust_TrackNo.Text.Trim.ToUpper Then
                        Me.btnUpdate.ForeColor = Color.Red
                        Return True : Exit Function
                    End If
                ElseIf Me._IsBulkData Then
                    If Not IsDBNull(Me.tdgData.Columns("WO_Quantity").Value) Then tmpStr = Me.tdgData.Columns("WO_Quantity").Value Else tmpStr = ""
                    If Not tmpStr.Trim.ToUpper = Me.WO_Quantity.Text.Trim.ToUpper Then
                        Me.btnUpdate.ForeColor = Color.Red
                        Return True : Exit Function
                    End If
                End If

                Return False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DataHaveChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '********************************************************************************
        Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
            Try
                Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
                Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
                If emailAddressMatch.Success Then
                    EmailAddressCheck = True
                Else
                    EmailAddressCheck = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "EmailAddressCheck", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '********************************************************************************
        Private Sub numericTextboxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Phone.KeyPress, WO_Quantity.KeyPress
            Try
                Dim tb As TextBox = CType(sender, TextBox)
                Dim chr As Char = e.KeyChar

                If IsNumeric(e.KeyChar) And Not e.KeyChar = "-" Then
                    'If adding the character to the end of the current TextBox value results in
                    ' a numeric value, go on. Otherwise, set e.Handled to True, and don't let
                    ' the character to be added.
                    e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                    'ElseIf e.KeyChar = "." Then
                    '    'For the decimal character (.) we need a different rule:
                    '    'If adding a decimal to the end of the current value of the TextBox results
                    '    ' in a numeric value, it can be added. If not, this means we already have a
                    '    ' decimal in the TextBox value, so we only allow the new decimal to sit in
                    '    ' when it is overwriting the previous decimal.
                    '    If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                    '        e.Handled = True
                    '    End If
                    'ElseIf e.KeyChar = "-" Then
                    '    'A negative sign is prevented if the "-" key is pressed in any location
                    '    ' other than the begining of the number, or if the number already has a
                    '    ' negative sign
                    '    If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                    '        e.Handled = True
                    '    End If
                ElseIf Not Char.IsControl(e.KeyChar) Then
                    'IsControl is checked, because without that, keys like BackSpace couldn't
                    ' work correctly.
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "numericTextboxKeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub numericTextboxKeyPress2(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Phone.KeyDown, WO_Quantity.KeyDown

            Try
                If e.KeyValue > 47 And e.KeyValue < 60 Or e.KeyValue > 97 And e.KeyValue < 106 Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
                'Select Case e.KeyValue
                '    Case 46, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, vbBack
                '        e.Handled = False
                '    Case Else
                '        e.Handled = True
                'End Select

                'System.Windows.Forms.Keys.D0
                'Me.ListBox1.Items.Add(e.KeyCode)
                'Me.ListBox2.Items.Add(e.KeyValue)
                'Try
                '    Select Case e.KeyCode
                '        Case Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, vbBack

                '            e.Handled = False
                '        Case Else
                '            e.Handled = True
                '    End Select


                'Catch
                '    e.Handled = True
                'End Try

                'If Asc(e.KeyCode) <> 13 AndAlso Asc(e.KeyCode) <> 8 AndAlso Not IsNumeric(e.KeyCode) Then
                '    MessageBox.Show("Only Numbers")
                '    e.Handled = True
                'End If
                'If (Microsoft.VisualBasic.Asc(e.KeyCode) < 48) _
                '          Or (Microsoft.VisualBasic.Asc(e.KeyCode) > 57) Then
                '    e.Handled = True
                'End If
                'If (Microsoft.VisualBasic.Asc(e.KeyCode) = 8) Then
                '    e.Handled = False
                'End If
                'Select Case e.KeyCode
                '    Case Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, _
                '    Keys.D8, Keys.D9, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, _
                '    Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, _
                '    Keys.NumPad9
                '        e.Handled = True
                '    Case Else
                '        e.Handled = True
                'End Select

                'Dim tb As TextBox = sender
                'If Not (Char.IsDigit(e.KeyCode) Or Char.IsControl(Asc(e.KeyCode))) Then
                '    e.Handled = True
                'End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "numericTextboxKeyPress2", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Function CorrectString(ByVal s As String) As String
            Try
                Return "'" & s.Replace("'", "''") & "'"
            Catch ex As Exception
                Return s
            End Try
        End Function

        '********************************************************************************
        Private Function findRowIdx(ByVal EW_ID As Integer) As Integer
            Dim Idx As Integer = 0
            Dim i As Integer
            Try

                With Me.tdgData
                    For i = 0 To .RowCount - 1
                        If EW_ID = .Columns("EW_ID").CellText(i) Then 'found it
                            Idx = i
                            Exit For
                        End If
                    Next
                End With

                Return Idx
            Catch ex As Exception
                Return Idx
            End Try
        End Function

#End Region

#Region "Approval"

        '********************************************************************************
        Private Sub LoadApprovedValue()
            Dim dt As DataTable
            Try
                Me.cboApprovedVal.DataSource = Nothing

                dt = Me._objAIG.GetApprovedValue()
                Misc.PopulateC1DropDownList(Me.cboApprovedVal, dt, "AV_Desc", "AV_ID")
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnApproval_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproval.Click
            Dim i As Integer = 0, iDeviceID As Integer = 0, iModelID As Integer = 0
            Dim strApprovalDTime As String = Format(Now, "yyyy-MM-dd HHmm:ss")
            Dim strErrMsg As String = ""

            Try
                If Me._iCellOpt_ID > 0 AndAlso Me._iWO_ID > 0 Then
                    'Validate input data
                    If Me.pnlApprovedBy.Visible = True AndAlso Me.cboApprovedBy.SelectedIndex < 0 Then
                        MessageBox.Show("Please select approved by.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf IsNothing(Me.cboApprovedVal.SelectedValue) Then
                        MessageBox.Show("Please select approved type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    'Update table tCellOpt
                    If Me._iApprovalCondition = 1 Then 'Quote
                        i = Me._objAIG.UpdateQuoteApproval(Me._iMenuCustID, Me._iWO_ID, Me._dbTotalCharge, Me._EstimatedPartCost, strApprovalDTime, Me.cboApprovedVal.SelectedValue, Me.cboApprovedBy.Text, Me._iUserID, Me._iCellOpt_ID, strErrMsg)
                        If strErrMsg.Trim.Length > 0 Then
                            MessageBox.Show(strErrMsg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf i = 0 Then
                            MessageBox.Show("System has failed to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            LoadApprovalData()
                            Me.lblSN.Text = "" : Me.lblDisplay.Text = "" : Me.btnApproval.Text = "" : Me.btnApproval.Enabled = False
                            Me._iApprovalCondition = 0 : Me._EstimatedPartCost = 0 : Me._dbTotalCharge = 0 : Me._iCellOpt_ID = 0 : Me._iWO_ID = 0
                            MessageBox.Show("Succesfully Approved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    ElseIf Me._iApprovalCondition = 2 Then 'PSS Wrty
                        i = Me._objAIG.UpdatePSSWrtyApproval(Me._iCellOpt_ID, strApprovalDTime, Me._iUserID, Me.cboApprovedVal.SelectedValue)
                        If i > 0 Then
                            Me.lblSN.Text = "" : Me.lblDisplay.Text = "" : Me.btnApproval.Text = "" : Me.btnApproval.Enabled = False
                            Me._iApprovalCondition = 0 : Me._EstimatedPartCost = 0 : Me._dbTotalCharge = 0 : Me._iCellOpt_ID = 0 : Me._iWO_ID = 0
                            LoadApprovalData()
                            MessageBox.Show("Succesfully Approved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("System has failed to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    ElseIf Me._iApprovalCondition = 3 Then 'SN Discrepancy 
                        iDeviceID = Me.tdgDataApproval.Columns("Device_ID").CellText(Me.tdgDataApproval.Row)
                        iModelID = Me.tdgDataApproval.Columns("Model_ID").CellText(Me.tdgDataApproval.Row)

                        If iDeviceID = 0 Then
                            MessageBox.Show("Device ID is missing.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf iModelID = 0 Then
                            MessageBox.Show("Model ID is missing.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Generic.IsBillcodeMapped(iModelID, Data.Buisness.AIG.iCancelBillcode) = 0 Then
                            MessageBox.Show("Billcode mapping is missing for Cancel billcode.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            'Bill Cancel Billcode
                            If Me.cboApprovedVal.SelectedValue = 2 AndAlso Generic.IsBillcodeExisted(iDeviceID, Data.Buisness.AIG.iCancelBillcode) = False Then
                                Dim objDevice As New Rules.Device(iDeviceID)
                                objDevice.AddPart(Data.Buisness.AIG.iCancelBillcode)
                                objDevice.Update()
                                objDevice.Dispose() : objDevice = Nothing
                            End If

                            i = Me._objAIG.UpdateSNDiscrepancyApproval(Me._iCellOpt_ID, strApprovalDTime, Me._iUserID, Me.cboApprovedVal.SelectedValue)
                            If i > 0 Then
                                Me.lblSN.Text = "" : Me.lblDisplay.Text = "" : Me.btnApproval.Text = "" : Me.btnApproval.Enabled = False
                                Me._iApprovalCondition = 0 : Me._EstimatedPartCost = 0 : Me._dbTotalCharge = 0 : Me._iCellOpt_ID = 0 : Me._iWO_ID = 0
                                LoadApprovalData()
                                MessageBox.Show("Succesfully Approved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("System has failed to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        End If

                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnApproval_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub LoadApprovalData()
            Dim dt As DataTable
            Try
                Me.lblSN.Text = "" : Me.lblDisplay.Text = "" : Me.btnApproval.Enabled = False
                Me.tdgDataApproval.DataSource = Nothing : Me._iApprovalCondition = 0 : Me._EstimatedPartCost = 0 : Me._dbTotalCharge = 0

                dt = Me._objAIG.GetApprovalData(Me._objAIG.LOCID)

                If dt.Rows.Count > 0 Then
                    Me.tdgDataApproval.DataSource = dt
                    Me.tdgDataApproval.Splits(0).DisplayColumns("Device_SN").Width = 180
                    Me.tdgDataApproval.Splits(0).DisplayColumns("WorkStation").Width = 250
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadApprovalData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRefreshApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshApproval.Click
            Try
                LoadApprovedValue()
                LoadApprovalData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshApproval_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tpApproval_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpApproval.VisibleChanged
            Try
                If Me.tpApproval.Visible = True Then LoadApprovalData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpApproval_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub tdgDataApproval_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgDataApproval.MouseUp
            Dim iRowID As Integer
            Dim dt As DataTable, row As DataRow
            Dim LaborCharges As Double = 0

            Try
                Me.pnlApprovedBy.Visible = False
                Me.lblSN.Text = "" : Me.lblDisplay.Text = "" : Me.btnApproval.Text = "" : Me.btnApproval.Enabled = False
                Me._iApprovalCondition = 0 : Me._EstimatedPartCost = 0 : Me._dbTotalCharge = 0 : Me._iWO_ID = 0 : _iCellOpt_ID = 0

                If Me.tdgDataApproval.RowCount > 0 Then
                    iRowID = Me.tdgDataApproval.Row
                    If Not IsDBNull(Me.tdgDataApproval.Columns("WorkStation").CellText(iRowID)) Then
                        'get values and validate
                        Me._strWorkStation = Me.tdgDataApproval.Columns("WorkStation").CellText(iRowID)

                        If Not IsDBNull(Me.tdgDataApproval.Columns("Cellopt_ID").CellText(iRowID)) Then
                            Me._iCellOpt_ID = Me.tdgDataApproval.Columns("Cellopt_ID").CellText(iRowID)
                        Else
                            MessageBox.Show("No CellOpt_ID. See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        If Not IsDBNull(Me.tdgDataApproval.Columns("WO_ID").CellText(iRowID)) Then
                            Me._iWO_ID = Me.tdgDataApproval.Columns("WO_ID").CellText(iRowID)
                        Else
                            MessageBox.Show("No WO_ID. See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        'Ready
                        If Me._strWorkStation.Trim.ToUpper = Me._objAIG.strAwaitApproval_Quote.Trim.ToUpper Then 'Quote approval
                            dt = Me._objAIG.GetApprovalForQuoteCharges(Me.tdgDataApproval.Columns("Device_ID").CellText(iRowID))
                            If dt.Rows.Count > 0 Then 'device_id is primary key, >0 means 1 acutally
                                If Not IsDBNull(dt.Rows(0).Item("Device_LaborCharge")) Then
                                    LaborCharges = Convert.ToDouble(dt.Rows(0).Item("Device_LaborCharge"))
                                End If
                                If Not IsDBNull(dt.Rows(0).Item("Device_PartCharge")) Then
                                    _EstimatedPartCost = Convert.ToDouble(dt.Rows(0).Item("Device_PartCharge"))
                                End If
                                Me._dbTotalCharge = LaborCharges + _EstimatedPartCost

                                Me.lblDisplay.Text = "Labor Chages: " & LaborCharges.ToString & Environment.NewLine
                                Me.lblDisplay.Text &= "Part Charges: " & _EstimatedPartCost.ToString & Environment.NewLine
                                Me.lblDisplay.Text &= "Total Charges: " & _dbTotalCharge.ToString
                                Me.lblSN.Text = "Device SN: " & Me.tdgDataApproval.Columns("Device_SN").CellText(iRowID)
                                Me._iApprovalCondition = 1
                                Me.btnApproval.Text = "Approve Quote" : Me.btnApproval.Enabled = True
                                Me.pnlApprovedBy.Visible = True
                            Else
                                MessageBox.Show("Can't found data. See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        ElseIf Me.tdgDataApproval.Columns("Device_PSSWrty").CellText(iRowID).ToString = "1" _
                               AndAlso Me.tdgDataApproval.Columns("PSS_Wrty_AV_ID").CellText(iRowID).ToString = "0" Then  'PSS Wrty Approval
                            If IsDBNull(Me.tdgDataApproval.Columns("PSS_Wrty_Approval_DT").CellText(iRowID)) _
                               Or (Not IsDate(Me.tdgDataApproval.Columns("PSS_Wrty_Approval_DT").CellText(iRowID))) Then
                                Me._iApprovalCondition = 2
                                Me.lblSN.Text = "Device SN: " & Me.tdgDataApproval.Columns("Device_SN").CellText(iRowID)
                                Me.btnApproval.Text = "Approve PSSWarranty" : Me.btnApproval.Enabled = True
                            Else
                                MessageBox.Show("PSS_Wrty_Approval_DT has datetime in tCellOpt (seems Approved). See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        ElseIf Me.tdgDataApproval.Columns("SN_Discp_Flag").CellText(iRowID).ToString = "1" _
                               AndAlso Me.tdgDataApproval.Columns("SN_Discp_AV_ID").CellText(iRowID).ToString = "0" Then  'SN Discrepancy Approval
                            If IsDBNull(Me.tdgDataApproval.Columns("SN_Discp_Approved_DT").CellText(iRowID)) _
                               Or (Not IsDate(Me.tdgDataApproval.Columns("SN_Discp_Approved_DT").CellText(iRowID))) Then
                                If Me._strWorkStation.Trim.ToUpper = Me._objAIG.strAwaitApproval_SN_Discrepancy.Trim.ToUpper Then
                                    Me._iApprovalCondition = 3
                                    Me.lblSN.Text = "Device SN: " & Me.tdgDataApproval.Columns("Device_SN").CellText(iRowID) & _
                                                    "  (EDI SN: " & Me.tdgDataApproval.Columns("EDI S/N").CellText(iRowID) & ")"
                                    Me.btnApproval.Text = "Approve SN Discrepancy" : Me.btnApproval.Enabled = True
                                Else
                                    MessageBox.Show("Invalid workstation (It should be '" & Me._objAIG.strAwaitApproval_SN_Discrepancy & "') in tCellOpt. See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                End If
                            Else
                                MessageBox.Show("SN_Discp_Approved_DT has datetime in tCellOpt (seems Approved). See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        Else
                            Me.lblSN.Text = "" : Me.lblDisplay.Text = ""
                            Me.btnApproval.Text = "" : Me.btnApproval.Enabled = False
                            MessageBox.Show("Invalid Work Station. See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        MessageBox.Show("No Work Station. See IT", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgDataApproval_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************


        '********************************************************************************
#End Region




       


    End Class
End Namespace