Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text.RegularExpressions

Namespace Gui.NativeInstruments
    Public Class frmDataManagement
        Inherits System.Windows.Forms.Form

#Region "DECLARATIONS"

		Private _booLoadData As Boolean = False

		'For Add/EditView RMA data-------------------------------
		Private _objNIDataM As NIDataManagement
		Private _objNI As NI
		Private _iCustID As Integer
		Private _iGroupID As Integer
		Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
		Private _bIsTheFirstTime As Boolean = True
		Private _tmpStrText As String = ""
		Private _IsEndUserData As Boolean = False
		Private _IsBulkData As Boolean = False
		Private Enum enumRepairType
			SendRefurb = 1
			SendNew = 2
			RepairThisUnit = 3
			SendNothing = 4
			SendSparePart = 5
		End Enum
		Private Enum enumFillOrderStatus
			FillOrderNotCreated = 1
			FillOrderCreatedButNotShipped_FoundDetailIDInWarehouseItems = 2
			FillOrderCreatedButNotShipped_NotFoundDetailIDInWarehouseItems = 3
			FillOrderCreatedAndShipped = 4
			FillOrdersCreatedMultiple = 5
		End Enum

#End Region
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
		Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
		Friend WithEvents tpAddFulOrder As System.Windows.Forms.TabPage
		Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents cboDevCondition As C1.Win.C1List.C1Combo
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents btnAddOrder As System.Windows.Forms.Button
		Friend WithEvents cboModels As C1.Win.C1List.C1Combo
		Friend WithEvents cboCosmGrades As C1.Win.C1List.C1Combo
		Friend WithEvents grbShipmentInfo As System.Windows.Forms.GroupBox
		Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
		Friend WithEvents txtState As System.Windows.Forms.TextBox
		Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
		Friend WithEvents txtShipPhone As System.Windows.Forms.TextBox
		Friend WithEvents txtCity As System.Windows.Forms.TextBox
		Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
		Friend WithEvents txtEmail As System.Windows.Forms.TextBox
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents lblOrderQty As System.Windows.Forms.Label
		Friend WithEvents btnClear As System.Windows.Forms.Button
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
		Friend WithEvents Product As System.Windows.Forms.ComboBox
		Friend WithEvents lblProduct As System.Windows.Forms.Label
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
		Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
		Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
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
		Friend WithEvents txtNameShip As System.Windows.Forms.TextBox
		Friend WithEvents txtName As System.Windows.Forms.TextBox
		Friend WithEvents lblSparePart As System.Windows.Forms.Label
		Friend WithEvents SparePart As System.Windows.Forms.TextBox
		Friend WithEvents pnlRepireType As System.Windows.Forms.Panel
		Friend WithEvents chkChange2 As System.Windows.Forms.CheckBox
		Friend WithEvents chkChange1 As System.Windows.Forms.CheckBox
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents BulkOrderType As System.Windows.Forms.ComboBox
		Friend WithEvents lblBulkOrderType As System.Windows.Forms.Label
		Friend WithEvents cboPkngUF As System.Windows.Forms.ComboBox
		Friend WithEvents lblPkngUF As System.Windows.Forms.Label
		Friend WithEvents lblReqstr As System.Windows.Forms.Label
		Friend WithEvents cboRequester As System.Windows.Forms.ComboBox
		Friend WithEvents btnRqstrAdd As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDataManagement))
			Me.TabControl1 = New System.Windows.Forms.TabControl()
			Me.tpAddFulOrder = New System.Windows.Forms.TabPage()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.lblOrderQty = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.grbShipmentInfo = New System.Windows.Forms.GroupBox()
			Me.txtEmail = New System.Windows.Forms.TextBox()
			Me.txtZipCode = New System.Windows.Forms.TextBox()
			Me.txtState = New System.Windows.Forms.TextBox()
			Me.txtAddress2 = New System.Windows.Forms.TextBox()
			Me.txtShipPhone = New System.Windows.Forms.TextBox()
			Me.txtCity = New System.Windows.Forms.TextBox()
			Me.txtAddress1 = New System.Windows.Forms.TextBox()
			Me.txtNameShip = New System.Windows.Forms.TextBox()
			Me.btnAddOrder = New System.Windows.Forms.Button()
			Me.cboCosmGrades = New C1.Win.C1List.C1Combo()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.cboDevCondition = New C1.Win.C1List.C1Combo()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.cboModels = New C1.Win.C1List.C1Combo()
			Me.Label6 = New System.Windows.Forms.Label()
			Me.txtOrderNo = New System.Windows.Forms.TextBox()
			Me.Label7 = New System.Windows.Forms.Label()
			Me.tpRMAData = New System.Windows.Forms.TabPage()
			Me.pnlDataUpdate = New System.Windows.Forms.Panel()
			Me.btnRqstrAdd = New System.Windows.Forms.Button()
			Me.cboRequester = New System.Windows.Forms.ComboBox()
			Me.lblReqstr = New System.Windows.Forms.Label()
			Me.cboPkngUF = New System.Windows.Forms.ComboBox()
			Me.lblPkngUF = New System.Windows.Forms.Label()
			Me.BulkOrderType = New System.Windows.Forms.ComboBox()
			Me.lblBulkOrderType = New System.Windows.Forms.Label()
			Me.pnlRepireType = New System.Windows.Forms.Panel()
			Me.chkChange2 = New System.Windows.Forms.CheckBox()
			Me.chkChange1 = New System.Windows.Forms.CheckBox()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.lblSparePart = New System.Windows.Forms.Label()
			Me.SparePart = New System.Windows.Forms.TextBox()
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
			Me.ServiceLevel = New System.Windows.Forms.ComboBox()
			Me.lblServiceLevel = New System.Windows.Forms.Label()
			Me.Product = New System.Windows.Forms.ComboBox()
			Me.lblProduct = New System.Windows.Forms.Label()
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
			Me.ListBox2 = New System.Windows.Forms.ListBox()
			Me.ListBox1 = New System.Windows.Forms.ListBox()
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
			Me.TabControl1.SuspendLayout()
			Me.tpAddFulOrder.SuspendLayout()
			Me.grbShipmentInfo.SuspendLayout()
			CType(Me.cboCosmGrades, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboDevCondition, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tpRMAData.SuspendLayout()
			Me.pnlDataUpdate.SuspendLayout()
			Me.pnlRepireType.SuspendLayout()
			Me.pnlSelectCountryState.SuspendLayout()
			Me.pnlDataUpdate_Center.SuspendLayout()
			CType(Me.tdgData_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.tdgData, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'TabControl1
			'
			Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpAddFulOrder, Me.tpRMAData})
			Me.TabControl1.Location = New System.Drawing.Point(16, 16)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New System.Drawing.Size(984, 616)
			Me.TabControl1.TabIndex = 0
			'
			'tpAddFulOrder
			'
			Me.tpAddFulOrder.BackColor = System.Drawing.Color.SteelBlue
			Me.tpAddFulOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.lblOrderQty, Me.Label3, Me.grbShipmentInfo, Me.btnAddOrder, Me.cboCosmGrades, Me.Label2, Me.cboDevCondition, Me.Label1, Me.cboModels, Me.Label6, Me.txtOrderNo, Me.Label7})
			Me.tpAddFulOrder.Location = New System.Drawing.Point(4, 22)
			Me.tpAddFulOrder.Name = "tpAddFulOrder"
			Me.tpAddFulOrder.Size = New System.Drawing.Size(976, 590)
			Me.tpAddFulOrder.TabIndex = 0
			Me.tpAddFulOrder.Text = "Add Fulfillment Order"
			'
			'btnClear
			'
			Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
			Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClear.ForeColor = System.Drawing.Color.White
			Me.btnClear.Location = New System.Drawing.Point(344, 424)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.btnClear.Size = New System.Drawing.Size(120, 21)
			Me.btnClear.TabIndex = 12
			Me.btnClear.Text = "Clear"
			'
			'lblOrderQty
			'
			Me.lblOrderQty.BackColor = System.Drawing.Color.Transparent
			Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblOrderQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblOrderQty.ForeColor = System.Drawing.Color.White
			Me.lblOrderQty.Location = New System.Drawing.Point(128, 264)
			Me.lblOrderQty.Name = "lblOrderQty"
			Me.lblOrderQty.Size = New System.Drawing.Size(56, 21)
			Me.lblOrderQty.TabIndex = 4
			Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label3
			'
			Me.Label3.BackColor = System.Drawing.Color.Transparent
			Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label3.ForeColor = System.Drawing.Color.White
			Me.Label3.Location = New System.Drawing.Point(40, 264)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(88, 21)
			Me.Label3.TabIndex = 3
			Me.Label3.Text = "Order Qty :"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'grbShipmentInfo
			'
			Me.grbShipmentInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEmail, Me.txtZipCode, Me.txtState, Me.txtAddress2, Me.txtShipPhone, Me.txtCity, Me.txtAddress1, Me.txtNameShip})
			Me.grbShipmentInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.grbShipmentInfo.ForeColor = System.Drawing.Color.White
			Me.grbShipmentInfo.Location = New System.Drawing.Point(128, 48)
			Me.grbShipmentInfo.Name = "grbShipmentInfo"
			Me.grbShipmentInfo.Size = New System.Drawing.Size(336, 200)
			Me.grbShipmentInfo.TabIndex = 2
			Me.grbShipmentInfo.TabStop = False
			Me.grbShipmentInfo.Text = "Ship To Information"
			'
			'txtEmail
			'
			Me.txtEmail.BackColor = System.Drawing.SystemColors.Info
			Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtEmail.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtEmail.Location = New System.Drawing.Point(8, 168)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.Size = New System.Drawing.Size(320, 23)
			Me.txtEmail.TabIndex = 7
			Me.txtEmail.Text = ""
			'
			'txtZipCode
			'
			Me.txtZipCode.BackColor = System.Drawing.SystemColors.Info
			Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtZipCode.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtZipCode.Location = New System.Drawing.Point(8, 144)
			Me.txtZipCode.Name = "txtZipCode"
			Me.txtZipCode.Size = New System.Drawing.Size(176, 23)
			Me.txtZipCode.TabIndex = 5
			Me.txtZipCode.Text = ""
			'
			'txtState
			'
			Me.txtState.BackColor = System.Drawing.SystemColors.Info
			Me.txtState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtState.Location = New System.Drawing.Point(184, 120)
			Me.txtState.Name = "txtState"
			Me.txtState.Size = New System.Drawing.Size(144, 23)
			Me.txtState.TabIndex = 4
			Me.txtState.Text = ""
			'
			'txtAddress2
			'
			Me.txtAddress2.BackColor = System.Drawing.SystemColors.Info
			Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtAddress2.Location = New System.Drawing.Point(8, 96)
			Me.txtAddress2.Name = "txtAddress2"
			Me.txtAddress2.Size = New System.Drawing.Size(320, 23)
			Me.txtAddress2.TabIndex = 2
			Me.txtAddress2.Text = ""
			'
			'txtShipPhone
			'
			Me.txtShipPhone.BackColor = System.Drawing.SystemColors.Info
			Me.txtShipPhone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtShipPhone.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtShipPhone.Location = New System.Drawing.Point(184, 144)
			Me.txtShipPhone.Name = "txtShipPhone"
			Me.txtShipPhone.Size = New System.Drawing.Size(144, 23)
			Me.txtShipPhone.TabIndex = 6
			Me.txtShipPhone.Text = ""
			Me.txtShipPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			'
			'txtCity
			'
			Me.txtCity.BackColor = System.Drawing.SystemColors.Info
			Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtCity.Location = New System.Drawing.Point(8, 120)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New System.Drawing.Size(176, 23)
			Me.txtCity.TabIndex = 3
			Me.txtCity.Text = ""
			'
			'txtAddress1
			'
			Me.txtAddress1.BackColor = System.Drawing.SystemColors.Info
			Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtAddress1.Location = New System.Drawing.Point(8, 72)
			Me.txtAddress1.Name = "txtAddress1"
			Me.txtAddress1.Size = New System.Drawing.Size(320, 23)
			Me.txtAddress1.TabIndex = 1
			Me.txtAddress1.Text = ""
			'
			'txtNameShip
			'
			Me.txtNameShip.BackColor = System.Drawing.SystemColors.Info
			Me.txtNameShip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtNameShip.ForeColor = System.Drawing.SystemColors.Desktop
			Me.txtNameShip.Location = New System.Drawing.Point(8, 24)
			Me.txtNameShip.Multiline = True
			Me.txtNameShip.Name = "txtNameShip"
			Me.txtNameShip.Size = New System.Drawing.Size(320, 42)
			Me.txtNameShip.TabIndex = 0
			Me.txtNameShip.Text = ""
			'
			'btnAddOrder
			'
			Me.btnAddOrder.BackColor = System.Drawing.Color.Green
			Me.btnAddOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnAddOrder.ForeColor = System.Drawing.Color.White
			Me.btnAddOrder.Location = New System.Drawing.Point(128, 424)
			Me.btnAddOrder.Name = "btnAddOrder"
			Me.btnAddOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.btnAddOrder.Size = New System.Drawing.Size(168, 21)
			Me.btnAddOrder.TabIndex = 11
			Me.btnAddOrder.Text = "Add"
			'
			'cboCosmGrades
			'
			Me.cboCosmGrades.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboCosmGrades.AutoCompletion = True
			Me.cboCosmGrades.AutoDropDown = True
			Me.cboCosmGrades.AutoSelect = True
			Me.cboCosmGrades.Caption = ""
			Me.cboCosmGrades.CaptionHeight = 17
			Me.cboCosmGrades.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboCosmGrades.ColumnCaptionHeight = 17
			Me.cboCosmGrades.ColumnFooterHeight = 17
			Me.cboCosmGrades.ColumnHeaders = False
			Me.cboCosmGrades.ContentHeight = 15
			Me.cboCosmGrades.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboCosmGrades.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboCosmGrades.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboCosmGrades.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboCosmGrades.EditorHeight = 15
			Me.cboCosmGrades.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboCosmGrades.ItemHeight = 15
			Me.cboCosmGrades.Location = New System.Drawing.Point(128, 384)
			Me.cboCosmGrades.MatchEntryTimeout = CType(2000, Long)
			Me.cboCosmGrades.MaxDropDownItems = CType(10, Short)
			Me.cboCosmGrades.MaxLength = 32767
			Me.cboCosmGrades.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboCosmGrades.Name = "cboCosmGrades"
			Me.cboCosmGrades.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboCosmGrades.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboCosmGrades.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboCosmGrades.Size = New System.Drawing.Size(168, 21)
			Me.cboCosmGrades.TabIndex = 10
			Me.cboCosmGrades.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label2
			'
			Me.Label2.BackColor = System.Drawing.Color.Transparent
			Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.ForeColor = System.Drawing.Color.White
			Me.Label2.Location = New System.Drawing.Point(0, 384)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(128, 21)
			Me.Label2.TabIndex = 9
			Me.Label2.Text = "Cosmetic Grade :"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboDevCondition
			'
			Me.cboDevCondition.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboDevCondition.AutoCompletion = True
			Me.cboDevCondition.AutoDropDown = True
			Me.cboDevCondition.AutoSelect = True
			Me.cboDevCondition.Caption = ""
			Me.cboDevCondition.CaptionHeight = 17
			Me.cboDevCondition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboDevCondition.ColumnCaptionHeight = 17
			Me.cboDevCondition.ColumnFooterHeight = 17
			Me.cboDevCondition.ColumnHeaders = False
			Me.cboDevCondition.ContentHeight = 15
			Me.cboDevCondition.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboDevCondition.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboDevCondition.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboDevCondition.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboDevCondition.EditorHeight = 15
			Me.cboDevCondition.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboDevCondition.ItemHeight = 15
			Me.cboDevCondition.Location = New System.Drawing.Point(128, 344)
			Me.cboDevCondition.MatchEntryTimeout = CType(2000, Long)
			Me.cboDevCondition.MaxDropDownItems = CType(10, Short)
			Me.cboDevCondition.MaxLength = 32767
			Me.cboDevCondition.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboDevCondition.Name = "cboDevCondition"
			Me.cboDevCondition.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboDevCondition.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboDevCondition.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboDevCondition.Size = New System.Drawing.Size(168, 21)
			Me.cboDevCondition.TabIndex = 8
			Me.cboDevCondition.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label1
			'
			Me.Label1.BackColor = System.Drawing.Color.Transparent
			Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.White
			Me.Label1.Location = New System.Drawing.Point(-8, 344)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(136, 21)
			Me.Label1.TabIndex = 7
			Me.Label1.Text = "Device Condition :"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'cboModels
			'
			Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboModels.AutoCompletion = True
			Me.cboModels.AutoDropDown = True
			Me.cboModels.AutoSelect = True
			Me.cboModels.Caption = ""
			Me.cboModels.CaptionHeight = 17
			Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboModels.ColumnCaptionHeight = 17
			Me.cboModels.ColumnFooterHeight = 17
			Me.cboModels.ColumnHeaders = False
			Me.cboModels.ContentHeight = 15
			Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboModels.EditorHeight = 15
			Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.cboModels.ItemHeight = 15
			Me.cboModels.Location = New System.Drawing.Point(128, 304)
			Me.cboModels.MatchEntryTimeout = CType(2000, Long)
			Me.cboModels.MaxDropDownItems = CType(10, Short)
			Me.cboModels.MaxLength = 32767
			Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboModels.Name = "cboModels"
			Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboModels.Size = New System.Drawing.Size(168, 21)
			Me.cboModels.TabIndex = 6
			Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'Label6
			'
			Me.Label6.BackColor = System.Drawing.Color.Transparent
			Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label6.ForeColor = System.Drawing.Color.White
			Me.Label6.Location = New System.Drawing.Point(72, 304)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New System.Drawing.Size(56, 21)
			Me.Label6.TabIndex = 5
			Me.Label6.Text = "Model :"
			Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtOrderNo
			'
			Me.txtOrderNo.Location = New System.Drawing.Point(128, 16)
			Me.txtOrderNo.Name = "txtOrderNo"
			Me.txtOrderNo.Size = New System.Drawing.Size(168, 20)
			Me.txtOrderNo.TabIndex = 1
			Me.txtOrderNo.Text = ""
			'
			'Label7
			'
			Me.Label7.BackColor = System.Drawing.Color.Transparent
			Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label7.ForeColor = System.Drawing.Color.White
			Me.Label7.Location = New System.Drawing.Point(40, 16)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New System.Drawing.Size(88, 16)
			Me.Label7.TabIndex = 0
			Me.Label7.Text = "Order # :"
			Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'tpRMAData
			'
			Me.tpRMAData.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDataUpdate, Me.tdgData_Detail, Me.tdgData, Me.btnRefresh, Me.rbtAddNew, Me.rbtView, Me.rbtEdit, Me.cmbTypeSwitch, Me.lblCurrentRecNum_Detail, Me.lblCurrentRecNum, Me.lblRecNum, Me.lblRecNum_Detail})
			Me.tpRMAData.Location = New System.Drawing.Point(4, 22)
			Me.tpRMAData.Name = "tpRMAData"
			Me.tpRMAData.Size = New System.Drawing.Size(976, 590)
			Me.tpRMAData.TabIndex = 1
			Me.tpRMAData.Text = "Add/Edit/View RMA Data"
			'
			'pnlDataUpdate
			'
			Me.pnlDataUpdate.BackColor = System.Drawing.Color.LightGray
			Me.pnlDataUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlDataUpdate.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRqstrAdd, Me.cboRequester, Me.lblReqstr, Me.cboPkngUF, Me.lblPkngUF, Me.BulkOrderType, Me.lblBulkOrderType, Me.pnlRepireType, Me.lblSparePart, Me.SparePart, Me.lblUpdateReason, Me.UpdateReason, Me.S_ID, Me.lblWO_Quantity, Me.WO_Quantity, Me.lblPurchaseDate, Me.lblSenderReference, Me.SenderReference, Me.lblAccount, Me.Account, Me.lblLanguage, Me.Language, Me.lblErrorDescription, Me.ErrorDescription, Me.lblDefectType2, Me.DefectType2, Me.lblDefectType1, Me.PurchaseDate, Me.Warranty, Me.lblWarranty, Me.RepairType, Me.lblRepairType, Me.ServiceLevel, Me.lblServiceLevel, Me.Product, Me.lblProduct, Me.DefectType1, Me.lblHardwareSerial, Me.HardwareSerial, Me.Device_DateShip, Me.TrackCreatedDateTime, Me.lblFinal_PSSI2Cust_TrackNo, Me.RowID, Me.pnlSelectCountryState, Me.Cntry_ID, Me.State_ID, Me.btnSelectCountryState, Me.lblZipCode, Me.ZipCode, Me.WO_ID, Me.lblPanel, Me.lblStatus, Me.Status, Me.Cust2PSSI_TrackNo, Me.lblPSSI2Cust_TrackNo, Me.PSSI2Cust_TrackNo, Me.lblEmail, Me.Email, Me.lblCountry, Me.Country, Me.lblState, Me.State, Me.lblCity, Me.City, Me.lblAddress2, Me.Address2, Me.lblAddress1, Me.Address1, Me.ListBox2, Me.ListBox1, Me.lblPhone, Me.Phone, Me.lblName, Me.txtName, Me.EW_ID, Me.btnUpdate, Me.lblRMANo, Me.RMA_No, Me.Final_PSSI2Cust_TrackNo, Me.lblCust2PSSI_TrackNo})
			Me.pnlDataUpdate.Location = New System.Drawing.Point(8, 232)
			Me.pnlDataUpdate.Name = "pnlDataUpdate"
			Me.pnlDataUpdate.Size = New System.Drawing.Size(960, 352)
			Me.pnlDataUpdate.TabIndex = 69
			'
			'btnRqstrAdd
			'
			Me.btnRqstrAdd.Location = New System.Drawing.Point(272, 288)
			Me.btnRqstrAdd.Name = "btnRqstrAdd"
			Me.btnRqstrAdd.Size = New System.Drawing.Size(40, 24)
			Me.btnRqstrAdd.TabIndex = 12
			Me.btnRqstrAdd.TabStop = False
			Me.btnRqstrAdd.Text = "Add"
			'
			'cboRequester
			'
			Me.cboRequester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboRequester.DropDownWidth = 300
			Me.cboRequester.Location = New System.Drawing.Point(88, 288)
			Me.cboRequester.MaxDropDownItems = 15
			Me.cboRequester.Name = "cboRequester"
			Me.cboRequester.Size = New System.Drawing.Size(184, 21)
			Me.cboRequester.TabIndex = 11
			'
			'lblReqstr
			'
			Me.lblReqstr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblReqstr.ImageAlign = System.Drawing.ContentAlignment.BottomRight
			Me.lblReqstr.Location = New System.Drawing.Point(16, 288)
			Me.lblReqstr.Name = "lblReqstr"
			Me.lblReqstr.Size = New System.Drawing.Size(72, 24)
			Me.lblReqstr.TabIndex = 107
			Me.lblReqstr.Text = "Requester:"
			Me.lblReqstr.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'cboPkngUF
			'
			Me.cboPkngUF.Items.AddRange(New Object() {"<Select>", "Yes", "No"})
			Me.cboPkngUF.Location = New System.Drawing.Point(440, 288)
			Me.cboPkngUF.Name = "cboPkngUF"
			Me.cboPkngUF.Size = New System.Drawing.Size(176, 21)
			Me.cboPkngUF.TabIndex = 23
			Me.cboPkngUF.Visible = False
			'
			'lblPkngUF
			'
			Me.lblPkngUF.BackColor = System.Drawing.Color.LightGray
			Me.lblPkngUF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblPkngUF.Location = New System.Drawing.Point(312, 288)
			Me.lblPkngUF.Name = "lblPkngUF"
			Me.lblPkngUF.Size = New System.Drawing.Size(120, 24)
			Me.lblPkngUF.TabIndex = 105
			Me.lblPkngUF.Text = "Packaging Upfront:"
			Me.lblPkngUF.TextAlign = System.Drawing.ContentAlignment.TopRight
			Me.lblPkngUF.Visible = False
			'
			'BulkOrderType
			'
			Me.BulkOrderType.Enabled = False
			Me.BulkOrderType.Location = New System.Drawing.Point(440, 312)
			Me.BulkOrderType.Name = "BulkOrderType"
			Me.BulkOrderType.Size = New System.Drawing.Size(176, 21)
			Me.BulkOrderType.TabIndex = 16
			'
			'lblBulkOrderType
			'
			Me.lblBulkOrderType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBulkOrderType.ImageAlign = System.Drawing.ContentAlignment.BottomRight
			Me.lblBulkOrderType.Location = New System.Drawing.Point(328, 312)
			Me.lblBulkOrderType.Name = "lblBulkOrderType"
			Me.lblBulkOrderType.Size = New System.Drawing.Size(104, 24)
			Me.lblBulkOrderType.TabIndex = 103
			Me.lblBulkOrderType.Text = "BulkOrderType:"
			Me.lblBulkOrderType.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'pnlRepireType
			'
			Me.pnlRepireType.BackColor = System.Drawing.SystemColors.Control
			Me.pnlRepireType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.pnlRepireType.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkChange2, Me.chkChange1, Me.Label4})
			Me.pnlRepireType.Location = New System.Drawing.Point(464, 200)
			Me.pnlRepireType.Name = "pnlRepireType"
			Me.pnlRepireType.Size = New System.Drawing.Size(224, 64)
			Me.pnlRepireType.TabIndex = 17
			'
			'chkChange2
			'
			Me.chkChange2.Location = New System.Drawing.Point(16, 36)
			Me.chkChange2.Name = "chkChange2"
			Me.chkChange2.Size = New System.Drawing.Size(192, 16)
			Me.chkChange2.TabIndex = 2
			Me.chkChange2.Text = "SendNew --> SendNothing"
			'
			'chkChange1
			'
			Me.chkChange1.Location = New System.Drawing.Point(16, 18)
			Me.chkChange1.Name = "chkChange1"
			Me.chkChange1.Size = New System.Drawing.Size(192, 16)
			Me.chkChange1.TabIndex = 1
			Me.chkChange1.Text = "Send New --> SendRefurb"
			'
			'Label4
			'
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.ForeColor = System.Drawing.Color.Indigo
			Me.Label4.Location = New System.Drawing.Point(2, 4)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(64, 16)
			Me.Label4.TabIndex = 0
			Me.Label4.Text = "Change:"
			'
			'lblSparePart
			'
			Me.lblSparePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblSparePart.Location = New System.Drawing.Point(760, 24)
			Me.lblSparePart.Name = "lblSparePart"
			Me.lblSparePart.Size = New System.Drawing.Size(96, 24)
			Me.lblSparePart.TabIndex = 101
			Me.lblSparePart.Text = "SparePart Qty:"
			Me.lblSparePart.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'SparePart
			'
			Me.SparePart.BackColor = System.Drawing.SystemColors.Window
			Me.SparePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.SparePart.Location = New System.Drawing.Point(864, 24)
			Me.SparePart.Name = "SparePart"
			Me.SparePart.Size = New System.Drawing.Size(24, 22)
			Me.SparePart.TabIndex = 3
			Me.SparePart.Text = ""
			'
			'lblUpdateReason
			'
			Me.lblUpdateReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblUpdateReason.Location = New System.Drawing.Point(768, 0)
			Me.lblUpdateReason.Name = "lblUpdateReason"
			Me.lblUpdateReason.Size = New System.Drawing.Size(104, 24)
			Me.lblUpdateReason.TabIndex = 99
			Me.lblUpdateReason.Text = "Update Reason:"
			Me.lblUpdateReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'UpdateReason
			'
			Me.UpdateReason.BackColor = System.Drawing.SystemColors.Window
			Me.UpdateReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.UpdateReason.Location = New System.Drawing.Point(872, 0)
			Me.UpdateReason.Name = "UpdateReason"
			Me.UpdateReason.Size = New System.Drawing.Size(80, 22)
			Me.UpdateReason.TabIndex = 11
			Me.UpdateReason.Text = ""
			'
			'S_ID
			'
			Me.S_ID.BackColor = System.Drawing.Color.LightGray
			Me.S_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.S_ID.Enabled = False
			Me.S_ID.Font = New System.Drawing.Font("Calibri", 8.25!)
			Me.S_ID.ForeColor = System.Drawing.Color.Gray
			Me.S_ID.Location = New System.Drawing.Point(968, 48)
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
			Me.lblWO_Quantity.Location = New System.Drawing.Point(568, 16)
			Me.lblWO_Quantity.Name = "lblWO_Quantity"
			Me.lblWO_Quantity.Size = New System.Drawing.Size(88, 24)
			Me.lblWO_Quantity.TabIndex = 96
			Me.lblWO_Quantity.Text = "W.O. Qty.:"
			Me.lblWO_Quantity.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'WO_Quantity
			'
			Me.WO_Quantity.BackColor = System.Drawing.SystemColors.Window
			Me.WO_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.WO_Quantity.Location = New System.Drawing.Point(664, 16)
			Me.WO_Quantity.Name = "WO_Quantity"
			Me.WO_Quantity.Size = New System.Drawing.Size(56, 22)
			Me.WO_Quantity.TabIndex = 10
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
			Me.lblSenderReference.Location = New System.Drawing.Point(312, 216)
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
			Me.SenderReference.Location = New System.Drawing.Point(440, 216)
			Me.SenderReference.Name = "SenderReference"
			Me.SenderReference.Size = New System.Drawing.Size(176, 22)
			Me.SenderReference.TabIndex = 20
			Me.SenderReference.Text = ""
			'
			'lblAccount
			'
			Me.lblAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblAccount.Location = New System.Drawing.Point(320, 192)
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
			Me.Account.Location = New System.Drawing.Point(440, 192)
			Me.Account.Name = "Account"
			Me.Account.Size = New System.Drawing.Size(176, 22)
			Me.Account.TabIndex = 19
			Me.Account.Text = ""
			'
			'lblLanguage
			'
			Me.lblLanguage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblLanguage.Location = New System.Drawing.Point(320, 168)
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
			Me.Language.Location = New System.Drawing.Point(440, 168)
			Me.Language.Name = "Language"
			Me.Language.Size = New System.Drawing.Size(176, 22)
			Me.Language.TabIndex = 18
			Me.Language.Text = ""
			'
			'lblErrorDescription
			'
			Me.lblErrorDescription.BackColor = System.Drawing.Color.LightGray
			Me.lblErrorDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblErrorDescription.Location = New System.Drawing.Point(656, 272)
			Me.lblErrorDescription.Name = "lblErrorDescription"
			Me.lblErrorDescription.Size = New System.Drawing.Size(80, 32)
			Me.lblErrorDescription.TabIndex = 32
			Me.lblErrorDescription.Text = "Error Description:"
			'
			'ErrorDescription
			'
			Me.ErrorDescription.BackColor = System.Drawing.SystemColors.Window
			Me.ErrorDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.ErrorDescription.Location = New System.Drawing.Point(744, 272)
			Me.ErrorDescription.Multiline = True
			Me.ErrorDescription.Name = "ErrorDescription"
			Me.ErrorDescription.Size = New System.Drawing.Size(280, 50)
			Me.ErrorDescription.TabIndex = 31
			Me.ErrorDescription.Text = ""
			'
			'lblDefectType2
			'
			Me.lblDefectType2.BackColor = System.Drawing.Color.LightGray
			Me.lblDefectType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDefectType2.Location = New System.Drawing.Point(336, 264)
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
			Me.DefectType2.Location = New System.Drawing.Point(440, 264)
			Me.DefectType2.Name = "DefectType2"
			Me.DefectType2.Size = New System.Drawing.Size(176, 22)
			Me.DefectType2.TabIndex = 22
			Me.DefectType2.Text = ""
			'
			'lblDefectType1
			'
			Me.lblDefectType1.BackColor = System.Drawing.Color.LightGray
			Me.lblDefectType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDefectType1.Location = New System.Drawing.Point(336, 240)
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
			Me.PurchaseDate.TabIndex = 29
			'
			'Warranty
			'
			Me.Warranty.Location = New System.Drawing.Point(440, 120)
			Me.Warranty.Name = "Warranty"
			Me.Warranty.Size = New System.Drawing.Size(176, 21)
			Me.Warranty.TabIndex = 16
			'
			'lblWarranty
			'
			Me.lblWarranty.BackColor = System.Drawing.Color.LightGray
			Me.lblWarranty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblWarranty.Location = New System.Drawing.Point(336, 120)
			Me.lblWarranty.Name = "lblWarranty"
			Me.lblWarranty.Size = New System.Drawing.Size(96, 24)
			Me.lblWarranty.TabIndex = 80
			Me.lblWarranty.Text = "Warranty:"
			Me.lblWarranty.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'RepairType
			'
			Me.RepairType.Location = New System.Drawing.Point(440, 96)
			Me.RepairType.Name = "RepairType"
			Me.RepairType.Size = New System.Drawing.Size(176, 21)
			Me.RepairType.TabIndex = 15
			'
			'lblRepairType
			'
			Me.lblRepairType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblRepairType.Location = New System.Drawing.Point(336, 96)
			Me.lblRepairType.Name = "lblRepairType"
			Me.lblRepairType.Size = New System.Drawing.Size(96, 24)
			Me.lblRepairType.TabIndex = 78
			Me.lblRepairType.Text = "Repair Type:"
			Me.lblRepairType.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'ServiceLevel
			'
			Me.ServiceLevel.Location = New System.Drawing.Point(440, 72)
			Me.ServiceLevel.Name = "ServiceLevel"
			Me.ServiceLevel.Size = New System.Drawing.Size(176, 21)
			Me.ServiceLevel.TabIndex = 14
			'
			'lblServiceLevel
			'
			Me.lblServiceLevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblServiceLevel.Location = New System.Drawing.Point(336, 72)
			Me.lblServiceLevel.Name = "lblServiceLevel"
			Me.lblServiceLevel.Size = New System.Drawing.Size(96, 24)
			Me.lblServiceLevel.TabIndex = 76
			Me.lblServiceLevel.Text = "Service Level:"
			Me.lblServiceLevel.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'Product
			'
			Me.Product.Enabled = False
			Me.Product.Location = New System.Drawing.Point(440, 48)
			Me.Product.Name = "Product"
			Me.Product.Size = New System.Drawing.Size(176, 21)
			Me.Product.TabIndex = 13
			'
			'lblProduct
			'
			Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblProduct.ImageAlign = System.Drawing.ContentAlignment.BottomRight
			Me.lblProduct.Location = New System.Drawing.Point(376, 48)
			Me.lblProduct.Name = "lblProduct"
			Me.lblProduct.Size = New System.Drawing.Size(56, 24)
			Me.lblProduct.TabIndex = 74
			Me.lblProduct.Text = "Product:"
			Me.lblProduct.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'DefectType1
			'
			Me.DefectType1.BackColor = System.Drawing.SystemColors.Window
			Me.DefectType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.DefectType1.Location = New System.Drawing.Point(440, 240)
			Me.DefectType1.Name = "DefectType1"
			Me.DefectType1.Size = New System.Drawing.Size(176, 22)
			Me.DefectType1.TabIndex = 21
			Me.DefectType1.Text = ""
			'
			'lblHardwareSerial
			'
			Me.lblHardwareSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblHardwareSerial.Location = New System.Drawing.Point(320, 144)
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
			Me.HardwareSerial.Location = New System.Drawing.Point(440, 144)
			Me.HardwareSerial.Name = "HardwareSerial"
			Me.HardwareSerial.Size = New System.Drawing.Size(176, 22)
			Me.HardwareSerial.TabIndex = 17
			Me.HardwareSerial.Text = ""
			'
			'Device_DateShip
			'
			Me.Device_DateShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Device_DateShip.ForeColor = System.Drawing.SystemColors.ControlDarkDark
			Me.Device_DateShip.Location = New System.Drawing.Point(920, 168)
			Me.Device_DateShip.Name = "Device_DateShip"
			Me.Device_DateShip.Size = New System.Drawing.Size(104, 24)
			Me.Device_DateShip.TabIndex = 70
			Me.Device_DateShip.Text = "Tricking Date"
			Me.Device_DateShip.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			Me.Device_DateShip.Visible = False
			'
			'TrackCreatedDateTime
			'
			Me.TrackCreatedDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.TrackCreatedDateTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
			Me.TrackCreatedDateTime.Location = New System.Drawing.Point(920, 112)
			Me.TrackCreatedDateTime.Name = "TrackCreatedDateTime"
			Me.TrackCreatedDateTime.Size = New System.Drawing.Size(112, 24)
			Me.TrackCreatedDateTime.TabIndex = 69
			Me.TrackCreatedDateTime.Text = "Tricking Date"
			Me.TrackCreatedDateTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft
			Me.TrackCreatedDateTime.Visible = False
			'
			'lblFinal_PSSI2Cust_TrackNo
			'
			Me.lblFinal_PSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblFinal_PSSI2Cust_TrackNo.Location = New System.Drawing.Point(632, 144)
			Me.lblFinal_PSSI2Cust_TrackNo.Name = "lblFinal_PSSI2Cust_TrackNo"
			Me.lblFinal_PSSI2Cust_TrackNo.Size = New System.Drawing.Size(280, 24)
			Me.lblFinal_PSSI2Cust_TrackNo.TabIndex = 29
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
			Me.RowID.Location = New System.Drawing.Point(968, 32)
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
			Me.pnlSelectCountryState.Location = New System.Drawing.Point(720, 192)
			Me.pnlSelectCountryState.Name = "pnlSelectCountryState"
			Me.pnlSelectCountryState.Size = New System.Drawing.Size(312, 80)
			Me.pnlSelectCountryState.TabIndex = 33
			'
			'pnlDataUpdate_Center
			'
			Me.pnlDataUpdate_Center.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCountry2, Me.cmbState2, Me.cmbCountry, Me.cmbState, Me.btnOK, Me.btnCancel})
			Me.pnlDataUpdate_Center.Location = New System.Drawing.Point(16, 8)
			Me.pnlDataUpdate_Center.Name = "pnlDataUpdate_Center"
			Me.pnlDataUpdate_Center.Size = New System.Drawing.Size(288, 64)
			Me.pnlDataUpdate_Center.TabIndex = 0
			'
			'cmbCountry2
			'
			Me.cmbCountry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
			Me.cmbCountry2.Enabled = False
			Me.cmbCountry2.Location = New System.Drawing.Point(8, 8)
			Me.cmbCountry2.Name = "cmbCountry2"
			Me.cmbCountry2.Size = New System.Drawing.Size(48, 21)
			Me.cmbCountry2.TabIndex = 0
			'
			'cmbState2
			'
			Me.cmbState2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
			Me.cmbState2.Enabled = False
			Me.cmbState2.Location = New System.Drawing.Point(8, 32)
			Me.cmbState2.Name = "cmbState2"
			Me.cmbState2.Size = New System.Drawing.Size(48, 21)
			Me.cmbState2.TabIndex = 1
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
			Me.btnOK.TabIndex = 2
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
			Me.Cntry_ID.Visible = False
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
			Me.State_ID.Visible = False
			'
			'btnSelectCountryState
			'
			Me.btnSelectCountryState.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnSelectCountryState.Location = New System.Drawing.Point(224, 195)
			Me.btnSelectCountryState.Name = "btnSelectCountryState"
			Me.btnSelectCountryState.Size = New System.Drawing.Size(88, 40)
			Me.btnSelectCountryState.TabIndex = 8
			Me.btnSelectCountryState.Text = "Change Country/State"
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
			Me.ZipCode.TabIndex = 5
			Me.ZipCode.Text = ""
			'
			'WO_ID
			'
			Me.WO_ID.BackColor = System.Drawing.Color.LightGray
			Me.WO_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.WO_ID.Enabled = False
			Me.WO_ID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.WO_ID.ForeColor = System.Drawing.Color.Gray
			Me.WO_ID.Location = New System.Drawing.Point(965, 16)
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
			Me.Status.TabStop = False
			Me.Status.Text = ""
			'
			'Cust2PSSI_TrackNo
			'
			Me.Cust2PSSI_TrackNo.BackColor = System.Drawing.SystemColors.Window
			Me.Cust2PSSI_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Cust2PSSI_TrackNo.Location = New System.Drawing.Point(632, 112)
			Me.Cust2PSSI_TrackNo.Name = "Cust2PSSI_TrackNo"
			Me.Cust2PSSI_TrackNo.Size = New System.Drawing.Size(280, 22)
			Me.Cust2PSSI_TrackNo.TabIndex = 26
			Me.Cust2PSSI_TrackNo.Text = ""
			'
			'lblPSSI2Cust_TrackNo
			'
			Me.lblPSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblPSSI2Cust_TrackNo.Location = New System.Drawing.Point(632, 48)
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
			Me.PSSI2Cust_TrackNo.Location = New System.Drawing.Point(632, 72)
			Me.PSSI2Cust_TrackNo.Name = "PSSI2Cust_TrackNo"
			Me.PSSI2Cust_TrackNo.Size = New System.Drawing.Size(280, 22)
			Me.PSSI2Cust_TrackNo.TabIndex = 25
			Me.PSSI2Cust_TrackNo.Text = ""
			'
			'lblEmail
			'
			Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblEmail.Location = New System.Drawing.Point(32, 264)
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
			Me.Email.Location = New System.Drawing.Point(88, 264)
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
			Me.Country.TabIndex = 7
			Me.Country.TabStop = False
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
			Me.State.TabIndex = 6
			Me.State.TabStop = False
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
			Me.City.TabIndex = 4
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
			Me.Address2.TabIndex = 3
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
			Me.Address1.TabIndex = 2
			Me.Address1.Text = ""
			'
			'ListBox2
			'
			Me.ListBox2.Location = New System.Drawing.Point(936, 72)
			Me.ListBox2.Name = "ListBox2"
			Me.ListBox2.Size = New System.Drawing.Size(32, 30)
			Me.ListBox2.TabIndex = 32
			'
			'ListBox1
			'
			Me.ListBox1.Location = New System.Drawing.Point(976, 72)
			Me.ListBox1.Name = "ListBox1"
			Me.ListBox1.Size = New System.Drawing.Size(32, 30)
			Me.ListBox1.TabIndex = 24
			'
			'lblPhone
			'
			Me.lblPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblPhone.Location = New System.Drawing.Point(32, 240)
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
			Me.Phone.Location = New System.Drawing.Point(88, 240)
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
			Me.txtName.TabIndex = 1
			Me.txtName.Text = ""
			'
			'EW_ID
			'
			Me.EW_ID.BackColor = System.Drawing.Color.LightGray
			Me.EW_ID.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.EW_ID.Enabled = False
			Me.EW_ID.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.EW_ID.ForeColor = System.Drawing.Color.Gray
			Me.EW_ID.Location = New System.Drawing.Point(968, 0)
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
			Me.btnUpdate.Location = New System.Drawing.Point(16, 8)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New System.Drawing.Size(112, 32)
			Me.btnUpdate.TabIndex = 34
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
			Me.RMA_No.TabIndex = 0
			Me.RMA_No.Text = ""
			'
			'Final_PSSI2Cust_TrackNo
			'
			Me.Final_PSSI2Cust_TrackNo.BackColor = System.Drawing.SystemColors.Window
			Me.Final_PSSI2Cust_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Final_PSSI2Cust_TrackNo.Location = New System.Drawing.Point(632, 168)
			Me.Final_PSSI2Cust_TrackNo.Name = "Final_PSSI2Cust_TrackNo"
			Me.Final_PSSI2Cust_TrackNo.Size = New System.Drawing.Size(280, 22)
			Me.Final_PSSI2Cust_TrackNo.TabIndex = 27
			Me.Final_PSSI2Cust_TrackNo.Text = ""
			'
			'lblCust2PSSI_TrackNo
			'
			Me.lblCust2PSSI_TrackNo.BackColor = System.Drawing.Color.LightGray
			Me.lblCust2PSSI_TrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblCust2PSSI_TrackNo.Location = New System.Drawing.Point(632, 88)
			Me.lblCust2PSSI_TrackNo.Name = "lblCust2PSSI_TrackNo"
			Me.lblCust2PSSI_TrackNo.Size = New System.Drawing.Size(280, 24)
			Me.lblCust2PSSI_TrackNo.TabIndex = 26
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
			Me.tdgData_Detail.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
			Me.tdgData_Detail.Location = New System.Drawing.Point(672, 8)
			Me.tdgData_Detail.Name = "tdgData_Detail"
			Me.tdgData_Detail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tdgData_Detail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tdgData_Detail.PreviewInfo.ZoomFactor = 75
			Me.tdgData_Detail.Size = New System.Drawing.Size(64, 32)
			Me.tdgData_Detail.TabIndex = 68
			Me.tdgData_Detail.Text = "C1TrueDBGrid1"
			Me.tdgData_Detail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Le" & _
			"monChiffon;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inacti" & _
			"ve{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}C" & _
			"aption{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highl" & _
			"ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSele" & _
			"ctor{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raise" & _
			"d,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz" & _
			":Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1True" & _
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
			Me.tdgData.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
			Me.tdgData.Location = New System.Drawing.Point(8, 40)
			Me.tdgData.Name = "tdgData"
			Me.tdgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tdgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tdgData.PreviewInfo.ZoomFactor = 75
			Me.tdgData.Size = New System.Drawing.Size(960, 168)
			Me.tdgData.TabIndex = 5
			Me.tdgData.Text = "C1TrueDBGrid1"
			Me.tdgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
			"wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
			"{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
			"tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
			"htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
			"or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
			",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
			"ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
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
			"nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 958, 166</ClientRect><BorderSide>0</" & _
			"BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
			"lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
			"ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
			""" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
			" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
			" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
			"tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
			""" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
			"><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
			"ecSelWidth><ClientArea>0, 0, 958, 166</ClientArea><PrintPageHeaderStyle parent=""" & _
			""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
			'
			'btnRefresh
			'
			Me.btnRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnRefresh.Location = New System.Drawing.Point(520, 3)
			Me.btnRefresh.Name = "btnRefresh"
			Me.btnRefresh.Size = New System.Drawing.Size(144, 32)
			Me.btnRefresh.TabIndex = 4
			Me.btnRefresh.Text = "Refresh Grid Data"
			'
			'rbtAddNew
			'
			Me.rbtAddNew.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtAddNew.Location = New System.Drawing.Point(184, 8)
			Me.rbtAddNew.Name = "rbtAddNew"
			Me.rbtAddNew.Size = New System.Drawing.Size(80, 24)
			Me.rbtAddNew.TabIndex = 1
			Me.rbtAddNew.Text = "Add New"
			'
			'rbtView
			'
			Me.rbtView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtView.Location = New System.Drawing.Point(400, 8)
			Me.rbtView.Name = "rbtView"
			Me.rbtView.Size = New System.Drawing.Size(88, 24)
			Me.rbtView.TabIndex = 3
			Me.rbtView.Text = "View Data"
			'
			'rbtEdit
			'
			Me.rbtEdit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtEdit.Location = New System.Drawing.Point(288, 8)
			Me.rbtEdit.Name = "rbtEdit"
			Me.rbtEdit.Size = New System.Drawing.Size(96, 24)
			Me.rbtEdit.TabIndex = 2
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
			'frmDataManagement
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(1016, 654)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
			Me.Name = "frmDataManagement"
			Me.Text = "frmDataManagement"
			Me.TabControl1.ResumeLayout(False)
			Me.tpAddFulOrder.ResumeLayout(False)
			Me.grbShipmentInfo.ResumeLayout(False)
			CType(Me.cboCosmGrades, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboDevCondition, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
			Me.tpRMAData.ResumeLayout(False)
			Me.pnlDataUpdate.ResumeLayout(False)
			Me.pnlRepireType.ResumeLayout(False)
			Me.pnlSelectCountryState.ResumeLayout(False)
			Me.pnlDataUpdate_Center.ResumeLayout(False)
			CType(Me.tdgData_Detail, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.tdgData, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "Form"

		Private Sub frmDataManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim dt As DataTable
			Try
				PSS.Core.Highlight.SetHighLight(Me)
				_booLoadData = True

				PopulateRequesterCombo()

				'Load customers
				dt = Generic.GetModelsWithCustCriteria(NI.CUSTOMERID, True, NI.PRODID, NI.MANUFID)
				Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
				Me.cboModels.SelectedValue = 0

				'Load device condition
				dt = Generic.GetDeviceConditionDefinition(True)
				'Remove Untest
				If dt.Select("DCode_ID = 3855").Length > 0 Then
					Dim R1 As DataRow
					R1 = dt.Select("DCode_ID = 3855")(0)
					dt.Rows.Remove(R1) : dt.AcceptChanges()
				End If
				Misc.PopulateC1DropDownList(Me.cboDevCondition, dt, "DCode_LDesc", "DCode_ID")
				Me.cboDevCondition.SelectedValue = 0

				'Load Cosmetic grade
				dt = Generic.GetCosmeticGrades(True)
				Misc.PopulateC1DropDownList(Me.cboCosmGrades, dt, "DCode_LDesc", "DCode_ID")
				Me.cboCosmGrades.SelectedValue = 0

				'For Add/EditView RMA data------------------------------------------------------------------------------------------
				Me.tdgData.AllowDelete = False
				Me.tdgData.AllowAddNew = False
				Me.tdgData.AllowUpdate = False
				Me.tdgData.AllowColSelect = False
				Me.ListBox1.Visible = False
				Me.ListBox2.Visible = False
				Me.pnlSelectCountryState.Visible = False
				Me._iCustID = NI.CUSTOMERID
				Me._iGroupID = NI.GROUPID
				Me.cmbTypeSwitch.Items.Add("End User")
				Me.cmbTypeSwitch.Items.Add("Bulk")
				Me.cmbTypeSwitch.SelectedIndex = 0
				Me.rbtView.Checked = True
				' MessageBox.Show("Cust_ID=" & Me._iCustID & "     UserID=" & Me._iUserID)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Generic.DisposeDT(dt)
				_booLoadData = False
			End Try
		End Sub

#End Region
#Region "Add Fulfillment Order"
		'********************************************************************************
		Private Sub cboModels_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModels.SelectedValueChanged
			Try
				If _booLoadData = True Then Exit Sub

				Me.cboDevCondition.SelectedValue = 0

				If Me.cboModels.SelectedValue > 0 Then
					Me.cboDevCondition.SelectAll() : Me.cboDevCondition.Focus()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "cboModels_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		'********************************************************************************
		Private Sub cboDevCondition_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDevCondition.SelectedValueChanged
			Try
				If _booLoadData = True Then Exit Sub

				Me.cboCosmGrades.SelectedValue = 0

				If Me.cboDevCondition.SelectedValue > 0 Then
					If Me.cboDevCondition.SelectedValue = 3856 Then
						Me.cboCosmGrades.Enabled = False
					Else
						Me.cboCosmGrades.Enabled = True
						Me.cboCosmGrades.SelectAll() : Me.cboCosmGrades.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "cboDevCondition_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		'********************************************************************************
		Private Sub txtOrderNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderNo.KeyUp
			Dim iWOID As Integer = 0

			Try
				If e.KeyCode = Keys.Enter AndAlso Me.txtOrderNo.Text.Trim.Length > 0 Then
					Me.ClearAll()
					Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
					If Me.ProcessOrder(True, iWOID) = False Then
						Me.Enabled = True : Me.txtOrderNo.SelectAll() : Me.txtOrderNo.Focus()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "txtOrderNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub

		'********************************************************************************
		Private Function ProcessOrder(ByVal booPopulateShipToInfo As Boolean, ByRef iWOID As Integer) As Boolean
			Dim booReturnVal As Boolean = False
			Dim dt, dtSOHeader As DataTable
			Dim objNIRec As NIRec
			Dim objWriteFulOrder As Data.Buisness.Fullfillment.WriteOrders

			Try
				objNIRec = New NIRec()
				objWriteFulOrder = New Data.Buisness.Fullfillment.WriteOrders()

				dt = objNIRec.GetNIInboundOrder(Me.txtOrderNo.Text.Trim.ToUpper)
				If dt.Rows.Count > 1 Then
					MessageBox.Show("Duplicate order #. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf dt.Rows.Count = 0 Then
					MessageBox.Show("Order does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf dt.Rows(0)("WO Type").ToString <> "End User" Then
					MessageBox.Show("WO Type is " & dt.Rows(0)("WO Type").ToString & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf Convert.ToInt32(dt.Rows(0)("WO_Quantity")) = 0 Then
					MessageBox.Show("Order is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf Not (dt.Rows(0)("RepairType").ToString.Trim.ToLower = "SendRefurb".ToString.ToLower OrElse dt.Rows(0)("RepairType").ToString.Trim.ToLower = "SendNew".ToString.ToLower) Then
					MessageBox.Show("Repair Type of this order is '" & dt.Rows(0)("RepairType").ToString & "' therefore can't send the replacement unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Else
					dtSOHeader = objWriteFulOrder.GetSOHeader(NI.CUSTOMERID, Me.txtOrderNo.Text.Trim.ToUpper)
					If dtSOHeader.Rows.Count > 1 Then
						MessageBox.Show("Duplicate fulfillment order exists. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf dtSOHeader.Rows.Count = 1 Then
						Dim strMsg As String = "Order has already created"
						If Not IsDBNull(dtSOHeader.Rows(0)("User_FullName")) Then strMsg &= " by " & dtSOHeader.Rows(0)("User_FullName").ToString
						If Not IsDBNull(dtSOHeader.Rows(0)("OrderCreatedDate")) Then strMsg &= " on " & Convert.ToDateTime(dtSOHeader.Rows(0)("OrderCreatedDate").ToString).ToString("MM/dd/yyyy")

						MessageBox.Show(strMsg & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						If booPopulateShipToInfo Then
							Me.PopulateShipToInfo(dt.Rows(0))
							Me.lblOrderQty.Text = dt.Rows(0)("WO_Quantity").ToString
						End If

						iWOID = Convert.ToInt32(dt.Rows(0)("WO_ID"))
						booReturnVal = True
					End If					  'Validate SO 
				End If				'Validate EDI order

				Return booReturnVal
			Catch ex As Exception
				Throw ex
			Finally
				Generic.DisposeDT(dt) : Generic.DisposeDT(dtSOHeader)
				objNIRec = Nothing : objWriteFulOrder = Nothing
			End Try
		End Function

		'********************************************************************************
		Private Sub ClearShipToCtrls()
			Try
				Me.txtNameShip.Text = ""
				Me.txtAddress1.Text = ""
				Me.txtAddress2.Text = ""
				Me.txtCity.Text = ""
				Me.txtState.Text = ""
				Me.txtZipCode.Text = ""
				Me.txtShipPhone.Text = ""
				Me.txtEmail.Text = ""
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'********************************************************************************
		Private Sub PopulateShipToInfo(ByVal drShipTo As DataRow)
			Try
				Me.txtNameShip.Text = drShipTo("ShipTo_name").ToString
				Me.txtAddress1.Text = drShipTo("Address1").ToString
				Me.txtAddress2.Text = ""
				Me.txtCity.Text = drShipTo("City").ToString
				Me.txtState.Text = drShipTo("State_ShortName").ToString
				Me.txtZipCode.Text = drShipTo("ZipCode").ToString
				Me.txtShipPhone.Text = drShipTo("Tel").ToString
				Me.txtEmail.Text = drShipTo("Email").ToString

			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'********************************************************************************
		Private Sub ClearAll()
			Try
				ClearShipToCtrls()
				Me.lblOrderQty.Text = "0"
				Me.cboModels.SelectedValue = 0
				Me.cboDevCondition.SelectedValue = 0
				Me.cboCosmGrades.SelectedValue = 0
			Catch ex As Exception
				Throw ex
			End Try
		End Sub

		'********************************************************************************
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			Try
				Me.txtOrderNo.Text = ""
				ClearAll()
				Me.txtOrderNo.Focus()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		'********************************************************************************
		Private Sub btnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOrder.Click
			Dim iWOID, iCosmGradeID, iDevConditionID, iRetVal As Integer
			Dim objNIRec As NIRec
			Dim strMsg As String = ""
			Try
				If Me.txtOrderNo.Text.Trim.Length > 0 Then
					Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

					If Me.ProcessOrder(False, iWOID) = True Then
						If iWOID = 0 Then
							MessageBox.Show("Work Order ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						ElseIf Me.cboModels.SelectedValue = 0 Then
							MessageBox.Show("Please select a model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						ElseIf Me.cboDevCondition.SelectedValue = 0 Then
							MessageBox.Show("Please select the device's condition.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						ElseIf Me.cboDevCondition.SelectedValue = 3857 AndAlso Me.cboCosmGrades.SelectedValue = 0 Then
							MessageBox.Show("Please select the cosmetic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Else
							If Me.cboDevCondition.SelectedValue = 3857 Then iCosmGradeID = Me.cboCosmGrades.SelectedValue Else iCosmGradeID = 0
							iDevConditionID = Me.cboDevCondition.SelectedValue
							objNIRec = New NIRec()
							iRetVal = objNIRec.WriteOutBoundOrder(iWOID, iCosmGradeID, iDevConditionID, Me.cboModels.SelectedValue, PSS.Core.ApplicationUser.IDuser, strMsg)
							If strMsg.Trim.Length > 0 Then
								MessageBox.Show("Please select the cosmetic grade.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							ElseIf iRetVal = 0 Then
								MessageBox.Show("System failed to write the order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							Else
								MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
								Me.Enabled = True : Me.ClearAll() : Me.txtOrderNo.Text = "" : Me.txtOrderNo.Focus()
							End If
						End If						 'User input
					End If					  'ProcessOrder
				End If				'User input
			Catch ex As Exception
				MessageBox.Show(ex.Message, "btnAddOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				objNIRec = Nothing
				Me.Enabled = True : Cursor.Current = Cursors.Default
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
				If Me.rbtEdit.Checked And Me._IsEndUserData Then goEditMode()
				If Me.rbtEdit.Checked And Me._IsBulkData Then goEditMode_Bulk()
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
				Me.BulkOrderType.Visible = False : Me.lblBulkOrderType.Visible = False

				BindDataToUpdatePanel()

				For Each cControl In Me.pnlDataUpdate.Controls
					If (TypeOf cControl Is TextBox) Then					  'or (TypeOf cControl Is ComboBox)  Then
						Select Case cControl.Name
							Case "EW_ID", "RowID", "Status", "State_ID", "Cntry_ID", "RMA_No", "WO_ID", "S_ID"
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
				'Me.PurchaseDate.Text = "12/12/2012"
				Me.PurchaseDate.Enabled = False : Me.lblPanel.Text = "List of Selected Record"
				Me.btnUpdate.Text = "Update" : Me.btnUpdate.Visible = False : Me.btnSelectCountryState.Visible = False

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

					.lblPSSI2Cust_TrackNo.Visible = True : .PSSI2Cust_TrackNo.Visible = True
					.lblCust2PSSI_TrackNo.Visible = True : .Cust2PSSI_TrackNo.Visible = True
					.lblFinal_PSSI2Cust_TrackNo.Visible = True : .Final_PSSI2Cust_TrackNo.Visible = True
					.TrackCreatedDateTime.Visible = True : .Device_DateShip.Visible = True

					.lblStatus.Visible = True : .Status.Visible = True

					.lblUpdateReason.Visible = False : .UpdateReason.Visible = False

					.lblPurchaseDate.Left = .Product.Left + .Product.Width
					.PurchaseDate.Left = .lblPurchaseDate.Left + .lblPurchaseDate.Width
					.lblPurchaseDate.Top = .Product.Top : .PurchaseDate.Top = .Product.Top

					.lblPSSI2Cust_TrackNo.Top = .lblPurchaseDate.Top + .lblPurchaseDate.Height
					.lblPSSI2Cust_TrackNo.Left = .Product.Left + .Product.Width + 10
					.PSSI2Cust_TrackNo.Left = .Product.Left + .Product.Width + 10
					.PSSI2Cust_TrackNo.Top = .lblPSSI2Cust_TrackNo.Top + .lblPSSI2Cust_TrackNo.Height

					.lblCust2PSSI_TrackNo.Left = .PSSI2Cust_TrackNo.Left
					.Cust2PSSI_TrackNo.Left = .PSSI2Cust_TrackNo.Left
					.lblCust2PSSI_TrackNo.Top = .PSSI2Cust_TrackNo.Top + .PSSI2Cust_TrackNo.Height - 10
					.Cust2PSSI_TrackNo.Top = .lblCust2PSSI_TrackNo.Top + .lblCust2PSSI_TrackNo.Height
					.TrackCreatedDateTime.Left = .Cust2PSSI_TrackNo.Left + .Cust2PSSI_TrackNo.Width
					.TrackCreatedDateTime.Top = .Cust2PSSI_TrackNo.Top

					.lblFinal_PSSI2Cust_TrackNo.Left = .PSSI2Cust_TrackNo.Left
					.Final_PSSI2Cust_TrackNo.Left = .PSSI2Cust_TrackNo.Left
					.lblFinal_PSSI2Cust_TrackNo.Top = .Cust2PSSI_TrackNo.Top + .Cust2PSSI_TrackNo.Height + 10
					.Final_PSSI2Cust_TrackNo.Top = .lblFinal_PSSI2Cust_TrackNo.Top + .lblFinal_PSSI2Cust_TrackNo.Height
					.Device_DateShip.Top = .Final_PSSI2Cust_TrackNo.Top
					.Device_DateShip.Left = .Final_PSSI2Cust_TrackNo.Left + .Final_PSSI2Cust_TrackNo.Width

					.lblErrorDescription.Left = .PSSI2Cust_TrackNo.Left
					.ErrorDescription.Left = .PSSI2Cust_TrackNo.Left
					.lblErrorDescription.Top = .SenderReference.Top + 10
					.ErrorDescription.Top = .lblErrorDescription.Top + .lblErrorDescription.Height
					.ErrorDescription.Multiline = True : .ErrorDescription.Height = 50
					.SparePart.Left = .DefectType2.Left : .SparePart.Top = .DefectType2.Top + .DefectType2.Height + 4
					.lblSparePart.Left = .SparePart.Left - .lblSparePart.Width : .lblSparePart.Top = .SparePart.Top
					.btnRqstrAdd.Visible = False
					.pnlRepireType.Visible = False
				End With

				' REQUESTER
				lblReqstr.Visible = True
				cboRequester.Visible = True
				cboRequester.DropDownStyle = ComboBoxStyle.DropDownList
				btnRqstrAdd.Visible = False
				btnRqstrAdd.Enabled = False

				' PACKAGING UPFRONT.
				cboPkngUF.DropDownStyle = ComboBoxStyle.DropDownList
				lblPkngUF.Visible = True
				cboPkngUF.Visible = True
				cboPkngUF.Enabled = False

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
				Me.BulkOrderType.Visible = False : Me.lblBulkOrderType.Visible = False

				BindDataToUpdatePanel()

				With Me
					.lblProduct.Visible = False : .Product.Visible = False
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
					.lblRepairType.Visible = True : .RepairType.Visible = True
					.RepairType.DropDownStyle = ComboBoxStyle.DropDown
					.SparePart.ReadOnly = True

					.lblReqstr.Visible = True
					.cboRequester.Visible = True
					.cboRequester.Enabled = True

					.lblUpdateReason.Visible = True : .UpdateReason.Visible = True

					.txtName.ReadOnly = False : .Address1.ReadOnly = False
					.City.ReadOnly = False : .Address2.ReadOnly = False
					.ZipCode.ReadOnly = False : .Phone.ReadOnly = False
					.Email.ReadOnly = False : .PSSI2Cust_TrackNo.ReadOnly = False
					.RepairType.Enabled = False : .RepairType.DropDownStyle = ComboBoxStyle.Simple

					.Cust2PSSI_TrackNo.ReadOnly = False : .Final_PSSI2Cust_TrackNo.ReadOnly = False
					.State.ReadOnly = True : .Country.ReadOnly = True
					.State.BackColor = Color.OldLace : .Country.BackColor = Color.OldLace

					.lblPSSI2Cust_TrackNo.Left = .txtName.Left + .txtName.Width + 20
					.PSSI2Cust_TrackNo.Left = .lblPSSI2Cust_TrackNo.Left
					.lblCust2PSSI_TrackNo.Left = .txtName.Left + .txtName.Width + 20
					.Cust2PSSI_TrackNo.Left = .lblCust2PSSI_TrackNo.Left
					.lblFinal_PSSI2Cust_TrackNo.Left = .txtName.Left + .txtName.Width + 20
					.Final_PSSI2Cust_TrackNo.Left = .lblFinal_PSSI2Cust_TrackNo.Left
					.TrackCreatedDateTime.Left = .Cust2PSSI_TrackNo.Left + .Cust2PSSI_TrackNo.Width + 10
					.Device_DateShip.Left = Final_PSSI2Cust_TrackNo.Left + Final_PSSI2Cust_TrackNo.Width + 10
					.pnlRepireType.Top = .RepairType.Top + .RepairType.Height
					.pnlRepireType.Left = .RepairType.Left
					.lblSparePart.Left = .RepairType.Left + .RepairType.Width + 5
					.lblSparePart.Top = .RepairType.Top : .SparePart.Top = .lblSparePart.Top
					.SparePart.Left = .lblSparePart.Left + .lblSparePart.Width

					.lblUpdateReason.Left = .txtName.Left + .txtName.Width + 20
					.lblUpdateReason.Top = .RMA_No.Top
					.UpdateReason.Left = .lblUpdateReason.Left + .lblUpdateReason.Width
					.UpdateReason.Top = .lblUpdateReason.Top
					.UpdateReason.Multiline = True : .UpdateReason.MaxLength = 100
					.UpdateReason.Height = 50 : .UpdateReason.Width = 400
					.UpdateReason.ReadOnly = False : .lblUpdateReason.TextAlign = ContentAlignment.TopLeft
					.lblStatus.Visible = True : .Status.Visible = True
					.pnlRepireType.Visible = True
				End With


				' REQUESTER
				lblReqstr.Visible = True
				cboRequester.Visible = True
				cboRequester.DropDownStyle = ComboBoxStyle.DropDownList
				cboRequester.Enabled = True
				btnRqstrAdd.Visible = True
				btnRqstrAdd.Enabled = cboRequester.Enabled

				' PACKAGING UPFRONT.
				cboPkngUF.DropDownStyle = ComboBoxStyle.DropDownList
				lblPkngUF.Visible = True
				cboPkngUF.Visible = True
				cboPkngUF.Enabled = True

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
				Me.BulkOrderType.Visible = False : Me.lblBulkOrderType.Visible = False

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
					.lblSparePart.Visible = False : .SparePart.Visible = False
					.lblStatus.Visible = False : .Status.Visible = False
					.lblUpdateReason.Visible = False : .UpdateReason.Visible = False
					.pnlRepireType.Visible = False
				End With

				Dim cControl As Control
				For Each cControl In Me.pnlDataUpdate.Controls
					If (TypeOf cControl Is TextBox) Then					  'or (TypeOf cControl Is ComboBox)  Then
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

				' PACKAGING UPFRONT.
				cboPkngUF.DropDownStyle = ComboBoxStyle.DropDownList
				lblPkngUF.Visible = True
				cboPkngUF.Text = "<Select>"
				cboPkngUF.Visible = True
				cboPkngUF.Enabled = True

				' REQUESTER.
				lblReqstr.Visible = True
				cboRequester.Visible = True
				cboRequester.DropDownStyle = ComboBoxStyle.DropDownList
				cboRequester.SelectedIndex = 0
				cboRequester.Enabled = True
				btnRqstrAdd.Visible = True
				btnRqstrAdd.Enabled = cboRequester.Enabled

				Me.State.ReadOnly = True : Me.Country.ReadOnly = True
				Me.State.BackColor = Color.OldLace : Me.Country.BackColor = Color.OldLace
				Me.PurchaseDate.Enabled = True : Me.lblPanel.Text = "New Record"
				Me.btnUpdate.Text = "Add" : Me.btnUpdate.Visible = True : Me.btnSelectCountryState.Visible = True

				'populate Dropdown items
				With Me
					._objNIDataM = New NIDataManagement()
					dt = ._objNIDataM.GetNI_Products
					.Product.DataSource = dt
					.Product.ValueMember = dt.Columns("NI_Prod_ID").ToString
					.Product.DisplayMember = dt.Columns("NI_Prod_Desc").ToString

					.ServiceLevel.Items.Clear()
					.ServiceLevel.Items.Add("Customer Ships")
					'.ServiceLevel.Items.Add("Packaging Upfront")
					'.ServiceLevel.Items.Add("On-Site Exchange")
					'.ServiceLevel.Items.Add("Pickup Service")
					.ServiceLevel.SelectedIndex = 0

					.RepairType.Items.Clear()
					.RepairType.Items.Add(enumRepairType.SendRefurb.ToString)					  '("SendRefurb")
					.RepairType.Items.Add(enumRepairType.SendNew.ToString)					  '("SendNew")
					.RepairType.Items.Add(enumRepairType.RepairThisUnit.ToString)					  '("RepairThisUnit")
					.RepairType.Items.Add(enumRepairType.SendNothing.ToString)					  '("SendNothing")
					' .RepairType.Items.Add(enumRepairType.SendSparePart.ToString) '("SendSparePart") 'Can't add claim for sending a spare part right now
					.RepairType.SelectedIndex = 0

					.Warranty.Items.Clear()
					.Warranty.Items.Add("Yes")
					.Warranty.Items.Add("No")
					.Warranty.SelectedIndex = 0

					.PurchaseDate.Format = DateTimePickerFormat.Short
					.PurchaseDate.Text = Now.Date

					.Language.Text = "EN"					  'Set default for Languange
				End With

				Me.RMA_No.SelectAll() : Me.RMA_No.Focus()

				'Me.tdgData.SelectedRows.Add(0) 'Select row 1
				Me.tdgData.SelectedRows.Clear()				'clear selected row(s)
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
					.tdgData_Detail.Top = .tdgData.Top + .tdgData.Height + .lblCurrentRecNum.Height + 10
					.tdgData_Detail.Width = .tdgData.Width : .tdgData_Detail.Height = .tdgData.Height
					.tdgData_Detail.Left = .tdgData.Left
					.lblCurrentRecNum_Detail.Top = .tdgData_Detail.Top + .tdgData_Detail.Height
					.lblRecNum_Detail.Top = .lblCurrentRecNum_Detail.Top
					.lblCurrentRecNum_Detail.Left = .tdgData_Detail.Left
					.lblRecNum_Detail.Left = .tdgData_Detail.Left + .tdgData_Detail.Width - .lblRecNum_Detail.Width

					.lblCurrentRecNum_Detail.Visible = True : .lblRecNum_Detail.Visible = True
					.BulkOrderType.Visible = True : .lblBulkOrderType.Visible = True

					Me.tdgData.Enabled = True
				End With

				' REQUESTER
				lblReqstr.Visible = True
				cboRequester.Visible = True
				cboRequester.DropDownStyle = ComboBoxStyle.DropDownList
				btnRqstrAdd.Visible = False
				btnRqstrAdd.Enabled = False

				' PACKAGING UPFRONT.
				cboPkngUF.DropDownStyle = ComboBoxStyle.DropDownList
				lblPkngUF.Visible = False
				cboPkngUF.Visible = False
				cboPkngUF.Enabled = False

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
				Me.BulkOrderType.DropDownStyle = ComboBoxStyle.Simple
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
					.BulkOrderType.Visible = True : .lblBulkOrderType.Visible = True
					.BulkOrderType.Enabled = False
					.WO_Quantity.Top = .Country.Top + .Country.Height + 5 : .WO_Quantity.Left = .Country.Left
					.lblWO_Quantity.Top = .WO_Quantity.Top : .lblWO_Quantity.Left = .WO_Quantity.Left - .lblWO_Quantity.Width
					.BulkOrderType.Top = .RepairType.Top - .BulkOrderType.Height - 10
					.lblBulkOrderType.Top = .BulkOrderType.Top
					.BulkOrderType.Left = .RepairType.Left
					.lblBulkOrderType.Left = .BulkOrderType.Left - .lblBulkOrderType.Width - 1
					.UpdateReason.Left = .Warranty.Left : .UpdateReason.Top = .Warranty.Top + .Warranty.Height + 20
					.lblUpdateReason.Top = .UpdateReason.Top
					.lblUpdateReason.Left = UpdateReason.Left - .lblUpdateReason.Width
					.UpdateReason.Multiline = True : .UpdateReason.MaxLength = 100
					.UpdateReason.Height = 50 : .UpdateReason.Width = 200
					.UpdateReason.ReadOnly = False : .lblUpdateReason.TextAlign = ContentAlignment.TopLeft
					.lblStatus.Visible = False : .Status.Visible = False
					.txtName.ReadOnly = False : .Address1.ReadOnly = False
					.City.ReadOnly = False : .Address2.ReadOnly = False
					.ZipCode.ReadOnly = False : .WO_Quantity.ReadOnly = False
					.RMA_No.ReadOnly = True : Me.RMA_No.BorderStyle = BorderStyle.None
					.RMA_No.BackColor = Color.LightGray : Me.RMA_No.ForeColor = Color.Black
					.pnlRepireType.Visible = False
				End With

				' REQUESTER
				lblReqstr.Visible = True
				cboRequester.Visible = True
				cboRequester.DropDownStyle = ComboBoxStyle.DropDownList
				cboRequester.Enabled = True
				btnRqstrAdd.Visible = True
				btnRqstrAdd.Enabled = cboRequester.Enabled

				' PACKAGING UPFRONT.
				cboPkngUF.DropDownStyle = ComboBoxStyle.DropDownList
				lblPkngUF.Visible = False
				cboPkngUF.Visible = False
				cboPkngUF.Enabled = False

				Me.pnlDataUpdate.Visible = True

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "goEditMode_Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		'********************************************************************************
		Private Sub goAddNewMode_Bulk()
			Try
				_objNIDataM = New NIDataManagement()
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
					.BulkOrderType.Visible = True : .lblBulkOrderType.Visible = True

					.WO_Quantity.Top = .Country.Top + .Country.Height + 5 : .WO_Quantity.Left = .Country.Left
					.lblWO_Quantity.Top = .WO_Quantity.Top : .lblWO_Quantity.Left = .WO_Quantity.Left - .lblWO_Quantity.Width
					.BulkOrderType.Top = .RepairType.Top - .BulkOrderType.Height - 10
					.lblBulkOrderType.Top = .BulkOrderType.Top
					.BulkOrderType.Left = .RepairType.Left
					.lblBulkOrderType.Left = .BulkOrderType.Left - .lblBulkOrderType.Width - 1

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

					'Try
					.BulkOrderType.Enabled = True
					.BulkOrderType.BackColor = Color.White : .BulkOrderType.ForeColor = Color.Black
					.BulkOrderType.DropDownStyle = ComboBoxStyle.DropDown
					.BulkOrderType.DataSource = Nothing : .BulkOrderType.Items.Clear()
					dt = ._objNIDataM.GetNI_BulkOrderType
					.BulkOrderType.DataSource = dt
					.BulkOrderType.ValueMember = dt.Columns("BulkORderType_ID").ToString
					.BulkOrderType.DisplayMember = dt.Columns("BulkORderType_Desc").ToString
					.BulkOrderType.SelectedIndex = 0
					'Catch ex As Exception
					'End Try

					.tdgData.SelectedRows.Clear()					  'clear selected row(s)
					.tdgData.Enabled = False
					.lblStatus.Visible = False : .Status.Visible = False
					.pnlRepireType.Visible = False
				End With

				' PACKAGING UPFRONT.
				cboPkngUF.DropDownStyle = ComboBoxStyle.DropDownList
				lblPkngUF.Visible = False
				cboPkngUF.Text = "<Select>"
				cboPkngUF.Visible = False
				cboPkngUF.Enabled = False

				' REQUESTER.
				lblReqstr.Visible = True
				cboRequester.Visible = True
				cboRequester.DropDownStyle = ComboBoxStyle.DropDownList
				cboRequester.SelectedIndex = 0
				cboRequester.Enabled = True
				btnRqstrAdd.Visible = True
				btnRqstrAdd.Enabled = cboRequester.Enabled

				'Me.RMA_No.Focus()
				'Me.RMA_No.Select()
				'Me.Show()
				'Application.DoEvents()
				'Me.RMA_No.SelectAll() : Me.RMA_No.Focus()
				Me.pnlDataUpdate.Visible = True

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "goAddNewMode_Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				If Me.pnlDataUpdate.Visible = True Then Me.RMA_No.SelectAll() : Me.RMA_No.Focus()
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

				Me.tdgData.SelectedRows.Add(iRowID)				'select current row

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
				If Not IsDBNull(Me.tdgData.Columns("SparePartQty").CellText(iRowID)) Then Me.SparePart.Text = Me.tdgData.Columns("SparePartQty").CellText(iRowID) Else Me.SparePart.Text = ""

				If IsDate(Me.TrackCreatedDateTime.Text) Then
					myD = Me.TrackCreatedDateTime.Text
					Me.TrackCreatedDateTime.Text = Format(myD, "MM/dd/yyyy")
				End If
				If IsDate(Me.Device_DateShip.Text) Then
					myD = Me.Device_DateShip.Text
					Me.Device_DateShip.Text = Format(myD, "MM/dd/yyyy")
				End If

				If Not IsDBNull(Me.tdgData.Columns("NI_Prod_Desc").CellText(iRowID)) Then Me.Product.Text = Me.tdgData.Columns("NI_Prod_Desc").CellText(iRowID) Else Me.Product.Text = ""
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

				' REQUESTER.
				If ConvertNullsAndEmptyString(Me.tdgData.Columns("requester").CellText(iRowID), "<Select>") = "<Select>" Then
					Me.cboRequester.SelectedIndex = 0
				Else
					Me.cboRequester.SelectedValue = Me.tdgData.Columns("requester").CellText(iRowID).ToString()
				End If

				UpdateReason.Text = ""

				' PACKAGING UPFRONT.
				If ConvertNullsAndEmptyString(Me.tdgData.Columns("PackagingUpfront").CellText(iRowID), "<Select>") = "<Select>" Then
					Me.cboPkngUF.Text = "<Select>"
				Else
					Me.cboPkngUF.Text = Me.tdgData.Columns("PackagingUpfront").CellText(iRowID).ToString()
				End If

				Try
					If IsDate(Me.tdgData.Columns("PurchaseDate").Value) Then
						myD = Me.tdgData.Columns("PurchaseDate").Value
						Me.PurchaseDate.Format = DateTimePickerFormat.Short
						Me.PurchaseDate.Text = Format(myD, "MM/dd/yyyy")
					Else
						Me.PurchaseDate.CustomFormat = " "
						Me.PurchaseDate.Format = DateTimePickerFormat.Custom
					End If
				Catch ex As Exception
				End Try

				If Me.RepairType.Text.Trim.ToUpper = Me.enumRepairType.SendSparePart.ToString.Trim.ToUpper Then
					Me.SparePart.Visible = True : Me.lblSparePart.Visible = True
				Else
					Me.SparePart.Visible = False : Me.lblSparePart.Visible = False
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

					With Me
						.chkChange1.Checked = False
						.chkChange2.Checked = False
						Select Case .RepairType.Text.Trim.ToUpper
							Case .enumRepairType.SendNew.ToString.Trim.ToUpper
								.chkChange1.Text = .enumRepairType.SendNew.ToString & " --> " & .enumRepairType.SendNothing.ToString
								.chkChange2.Text = .enumRepairType.SendNew.ToString & " --> " & .enumRepairType.SendRefurb.ToString
							Case .enumRepairType.SendRefurb.ToString.Trim.ToUpper
								.chkChange1.Text = .enumRepairType.SendRefurb.ToString & " --> " & .enumRepairType.SendNothing.ToString
								.chkChange2.Text = .enumRepairType.SendRefurb.ToString & " --> " & .enumRepairType.SendNew.ToString
							Case .enumRepairType.SendNothing.ToString.Trim.ToUpper
								.chkChange1.Text = .enumRepairType.SendNothing.ToString & " --> " & .enumRepairType.SendRefurb.ToString
								.chkChange2.Text = .enumRepairType.SendNothing.ToString & " --> " & .enumRepairType.SendNew.ToString
							Case Else
								.pnlRepireType.Visible = False
						End Select
					End With
				End If
				Me.chkChange1.ForeColor = Color.Black : Me.chkChange2.ForeColor = Color.Black
				Me.btnUpdate.ForeColor = Color.RoyalBlue
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "goViewMode", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

				Me.tdgData.SelectedRows.Add(iRowID)				'select current row

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
				If Not IsDBNull(Me.tdgData.Columns("BulkOrderType_Desc").CellText(iRowID)) Then Me.BulkOrderType.Text = Me.tdgData.Columns("BulkOrderType_Desc").CellText(iRowID) Else Me.BulkOrderType.Text = ""

				' REQUESTER.
				If ConvertNullsAndEmptyString(Me.tdgData.Columns("requester").CellText(iRowID), "<Select>") = "<Select>" Then
					Me.cboRequester.SelectedIndex = 0
				Else
					Me.cboRequester.SelectedValue = Me.tdgData.Columns("requester").CellText(iRowID).ToString()
				End If

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

				Me.tdgData.SelectedRows.Add(iRowID)				'select current row

				If Not IsDBNull(Me.tdgData.Columns("WO_ID").Value) Then
					iWO_ID = Me.tdgData.Columns("WO_ID").Value
				Else
					MessageBox.Show("Work Order ID is missing!")
					Me.Cursor = System.Windows.Forms.Cursors.Default
					Exit Sub
				End If
				Me._objNIDataM = New NIDataManagement()
				dt = Me._objNIDataM.GetNIBulkData_Detail(Me._iCustID, iWO_ID)
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
				dt = Me._objNIDataM.GetNIRMAEndUserData(Me._iCustID)
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
				dt = Me._objNIDataM.GetNIBulkData_Master(Me._iCustID)
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
				Me.Cursor = Cursors.WaitCursor
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
			Finally
				Me.Cursor = cursors.Default
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
		Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Address1.Leave, Address2.Leave, City.Leave, ZipCode.Leave, Phone.Leave, Email.Leave, PSSI2Cust_TrackNo.Leave, Cust2PSSI_TrackNo.Leave, Final_PSSI2Cust_TrackNo.Leave, WO_Quantity.Leave, txtNameShip.Leave
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
					If _objNIDataM.RMANumberExist(Me._iCustID, 2, Me.RMA_No.Text.Trim) Then
						MessageBox.Show("RMA_No """ & Me.RMA_No.Text.Trim & """ exists!")
						Me.RMA_No.Text = "" : Me.RMA_No.Focus() : Exit Sub
					End If
					_objNIDataM = Nothing
				ElseIf Me._IsEndUserData AndAlso Me.rbtAddNew.Checked Then
					'Check for duplicated RMA (existing)
					_objNIDataM = New NIDataManagement()
					If _objNIDataM.RMANumberExist(Me._iCustID, 1, Me.RMA_No.Text.Trim) Then
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
				Me.Cursor = Cursors.WaitCursor
				If Me._IsEndUserData AndAlso Me.rbtEdit.Checked AndAlso DataHaveChanged() Then
					EditMode_getUpdateSQL4EndUser()
				ElseIf Me._IsEndUserData AndAlso Me.rbtAddNew.Checked Then
					AddNewMode_getAddSQL4EndUser()
				ElseIf Me._IsBulkData AndAlso Me.rbtEdit.Checked AndAlso DataHaveChanged() Then
					EditMode_getUpdateSQL4Bulk()
				ElseIf Me._IsBulkData AndAlso Me.rbtAddNew.Checked Then
					AddNewMode_getAddSQL4Bulk()
				End If
				If Me.rbtEdit.Checked Then
					Me.tdgData.Enabled = True
				Else
					Exit Sub
				End If
				Me.btnUpdate.ForeColor = Color.RoyalBlue
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Cursor = Cursors.Default
			End Try
		End Sub

		'********************************************************************************
		Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
			Try
				Me.Cursor = Cursors.WaitCursor
				If Me._IsEndUserData Then
					LoadEndUserData()
				ElseIf Me._IsBulkData Then
					LoadBulkMasterData()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Cursor = Cursors.Default
			End Try
		End Sub

		'********************************************************************************
		Private Sub btnSelectCountryState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectCountryState.Click
			Dim dt As DataTable, dt2 As DataTable
			Dim strSQL As String
			Try
				Me.pnlSelectCountryState.Top = 0
				Me.pnlSelectCountryState.Left = 0
				Me.pnlSelectCountryState.Height = Me.pnlDataUpdate.Height
				Me.pnlSelectCountryState.Width = Me.pnlDataUpdate.Width
				Me.pnlSelectCountryState.Visible = True
				Me.pnlSelectCountryState.BringToFront()
				Me.pnlDataUpdate_Center.Top = Me.pnlDataUpdate.Height / 2 - Me.pnlDataUpdate_Center.Height / 2
				Me.pnlDataUpdate_Center.Left = Me.pnlDataUpdate.Width / 2 - Me.pnlDataUpdate_Center.Width / 2
				_objNIDataM = New NIDataManagement()
				dt = _objNIDataM.GetCountryNames()
				If Not dt.Rows.Count > 0 Then
					MessageBox.Show("No countries found in the table.")
					Exit Sub
				End If
				Me.cmbCountry.DataSource = dt : Me.cmbCountry2.DataSource = dt
				Me.cmbCountry.ValueMember = dt.Columns("Cntry_ID").ToString : Me.cmbCountry2.ValueMember = dt.Columns("Cntry_ID").ToString
				Me.cmbCountry.DisplayMember = dt.Columns("Cntry_Name").ToString : Me.cmbCountry2.DisplayMember = dt.Columns("Cntry_ShortName").ToString
				Try
					Me.cmbCountry.SelectedValue = Me.Cntry_ID.Text
				Catch ex As Exception
					Try
						Me.cmbCountry.SelectedIndex = 1 : Me.cmbCountry2.SelectedIndex = 1 'second one "US"
					Catch ex2 As Exception
					End Try
				End Try

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
		Private Sub EditMode_getUpdateSQL4EndUser()
			Dim iRowIndex As Integer, iRowIndex_New As Integer
			Dim strSQL As String = "", strSQL_Second As String = ""
			Dim strOldValues As String = "", strRMA_No As String
			Dim strCol As String = "", strCol_Second As String = ""
			Dim S1 As String = "", S2 As String = ""
			Dim iN1 As Integer = 0, iN2 As Integer = 0
			Dim StrSQL_Ready1 As String = "", StrSQL_Ready2 As String = ""
			Dim strSQL_InvalidOrder As String = ""
			Dim sessionDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
			Dim iSOHeaderID As Integer = 0

			Try
				'Table 1: production.extendedwarranty - ClaimNo, WO_ID, Shipto_Name, address1,address2,City,State_ShortName, ZipCode,Cntry_name,Tel,Email
				'                                       State_ID,Cntry_ID,RepairType
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
					MessageBox.Show("Name field cannot be empty.") : Exit Sub
				End If

				'Address
				If Not Me.Address1.Text.Length + Me.Address2.Text.Length > 0 Then
					MessageBox.Show("Address field(s) cannot be empty.") : Exit Sub
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
					MessageBox.Show("City field cannot be empty.") : Exit Sub
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
					MessageBox.Show("ZipCode field cannot be empty.") : Exit Sub
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
					MessageBox.Show("State field cannot be empty.") : Exit Sub
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
					MessageBox.Show("Country field cannot be empty.") : Exit Sub
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

				'Requester 
				If cboRequester.SelectedIndex < 1 Then
					MessageBox.Show("You must select a Requester.", "Requester required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Dim _org_rqstr As String = Me.tdgData.Columns("Requester").CellText(iRowIndex).ToString.Trim()
				Dim _rqstr As String
				_rqstr = cboRequester.Text
				If Not _rqstr.ToUpper = _org_rqstr.ToUpper Then
					strCol = "Requester="
					strCol_Second = "cboRequester="
					If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(_org_rqstr) Else strSQL &= strCol & CorrectString(_rqstr)
					If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(_org_rqstr) Else strSQL_Second &= strCol_Second & CorrectString(_rqstr)
					If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & _org_rqstr Else strOldValues &= strCol & _org_rqstr
				End If

				' PACKAGING UPFRONT.
				If cboPkngUF.Text = "<Select>" Then
					MessageBox.Show("You must select a value for Packaging Upfront.", "Packaging Upfront required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Dim _org_pkgnuf As String = Me.tdgData.Columns("PackagingUpfront").CellText(iRowIndex).ToString.Trim()
				Dim _pkgnuf As String
				_pkgnuf = cboPkngUF.Text
				If Not _pkgnuf.ToUpper = _org_pkgnuf.ToUpper Then
					strCol = "PackagingUpfront="
					strCol_Second = "cboPkngUF="
					If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(_org_pkgnuf) Else strSQL &= strCol & CorrectString(_pkgnuf)
					If strSQL_Second.Trim.Length > 0 Then strSQL_Second &= "," & strCol_Second & CorrectString(_org_pkgnuf) Else strSQL_Second &= strCol_Second & CorrectString(_pkgnuf)
					If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & _org_pkgnuf Else strOldValues &= strCol & _org_pkgnuf
				End If

				'RepairType
				With Me
					strCol = "RepairType="
					Select Case .RepairType.Text.Trim.ToUpper
						Case .enumRepairType.SendNew.ToString.Trim.ToUpper						 '1. SendNew to SendNothing or SendRefurb ------------------------------
							strRMA_No = Me.RMA_No.Text.Trim
							If ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrderNotCreated.ToString _
							   Or ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_NotFoundDetailIDInWarehouseItems.ToString Then
								If .chkChange1.Checked Then
									S1 = .RepairType.Text : S2 = .enumRepairType.SendNothing.ToString
									If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
									If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
								ElseIf .chkChange2.Checked Then
									S1 = .RepairType.Text : S2 = .enumRepairType.SendRefurb.ToString
									If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
									If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
								End If
								If iSOHeaderID > 0 Then								  'for reset InvalidOrder=1 in SOHeader table
									strSQL_InvalidOrder = "UPDATE saleorders.soheader SET InvalidOrder=1 WHERE SOHeaderID =" & iSOHeaderID
								End If
							ElseIf ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrderCreatedAndShipped.ToString Then
								MessageBox.Show("FillOrder has already created and shipped. Can't change!") : Exit Sub
							ElseIf ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrdersCreatedMultiple.ToString Then
								MessageBox.Show("FillOrder has multiple orders created. Can't change!") : Exit Sub
							Else							'i.e., Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_FoundDetailIDInWarehouseItems
								MessageBox.Show("FillOrder has already created and Warehouse item selected. Can't change!") : Exit Sub
							End If
						Case .enumRepairType.SendRefurb.ToString.Trim.ToUpper						 '2. SendRefurb to SendNothing or SendNew ---------------------------
							strRMA_No = Me.RMA_No.Text.Trim
							If ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrderNotCreated.ToString _
							   Or ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_NotFoundDetailIDInWarehouseItems.ToString Then
								If .chkChange1.Checked Then
									S1 = .RepairType.Text : S2 = .enumRepairType.SendNothing.ToString
									If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
									If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
								ElseIf .chkChange2.Checked Then
									S1 = .RepairType.Text : S2 = .enumRepairType.SendNew.ToString
									If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
									If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
								End If
								If iSOHeaderID > 0 Then								  'for reset InvalidOrder=1 in SOHeader table
									strSQL_InvalidOrder = "UPDATE saleorders.soheader SET InvalidOrder=1 WHERE SOHeaderID =" & iSOHeaderID
								End If
							ElseIf ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrderCreatedAndShipped.ToString Then
								MessageBox.Show("FillOrder has already created and shipped. Can't change!") : Exit Sub
							ElseIf ProcessRMAWhenChangingRepairType(strRMA_No, iSOHeaderID) = Me.enumFillOrderStatus.FillOrdersCreatedMultiple.ToString Then
								MessageBox.Show("FillOrder has multiple orders created. Can't change!") : Exit Sub
							Else							'i.e., Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_FoundDetailIDInWarehouseItems
								MessageBox.Show("FillOrder has already created and Warehouse item selected. Can't change!") : Exit Sub
							End If
						Case .enumRepairType.SendNothing.ToString.Trim.ToUpper						 '3. SendNothing to SendRefurb or SendNew ------------------------
							If .chkChange1.Checked Then
								S1 = .RepairType.Text : S2 = .enumRepairType.SendRefurb.ToString
								If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
								If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
							ElseIf .chkChange2.Checked Then
								S1 = .RepairType.Text : S2 = .enumRepairType.SendNew.ToString
								If strSQL.Trim.Length > 0 Then strSQL &= "," & strCol & CorrectString(S2) Else strSQL &= strCol & CorrectString(S2)
								If strOldValues.Trim.Length > 0 Then strOldValues &= ";" & strCol & S1 Else strOldValues &= strCol & S1
							End If
						Case Else
							MessageBox.Show("Not a valid RepairType. Can't change!") : Exit Sub
					End Select
				End With


				'Update Reason
				If Not Me.UpdateReason.Text.Trim.Length > 0 Then
					MessageBox.Show("Update Reason field cannot be empty. Please enter a reason!") : Exit Sub
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
					If Me.WO_ID.Text.Trim.Length > 0 AndAlso IsNumeric(Me.WO_ID.Text) Then					  'update production.extendedwarranty table or both of production.extendedwarranty and Salesorder.SOHeader tables
						Dim IsFirstTable As Boolean, IsSecondTable As Boolean
						Dim ErrMsg As String = ""
						Me._objNIDataM = New NIDataManagement()
						Me._objNIDataM.ValidateTableRecord(Me.EW_ID.Text, Me.WO_ID.Text, Me._iCustID, Me.RMA_No.Text, IsFirstTable, IsSecondTable, ErrMsg)

						If ErrMsg.Trim.Length > 0 Then						  'failed
							MessageBox.Show("Failed to update! " & ErrMsg)
							Exit Sub
						Else						 'OK
							If IsFirstTable = True AndAlso IsSecondTable = True Then							'Update 2 table
								'----------------------------------------------------------------------------------------------------------------
								If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
									StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
									'update first table
									If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
										'save log
										If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
										  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
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
								 " And Cust_ID=" & Me._iCustID & _
								 " And  CustomerOrderNumber='" & Me.RMA_No.Text & "'"
								'update second table
								If Me._objNIDataM.UpdateTable(StrSQL_Ready2) Then
									'save log
									If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
									  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
									  StrSQL_Ready2.Replace("'", "''")) Then
									Else
										MessageBox.Show("Alert2: Failed to save the updated log for saleorders.SOheader.  (Tracker.extendedwarranty_log)")
									End If
								Else
									MessageBox.Show("Failed to update saleorders.SOheader.")
									Exit Sub
								End If
								'----------------------------------------------------------------------------------------------------------------

							ElseIf IsFirstTable = True AndAlso IsSecondTable = False Then							'update the first table only
								If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
									StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
									'update
									If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
										'save log
										If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
										  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
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

					Else					  'only update production.extendedwarranty table, WO_ID is nothing
						Me._objNIDataM = New NIDataManagement()
						If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
							StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
							'update
							If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
								'save log
								If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
								  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
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
				ElseIf strSQL.Length > 0 Then				 'only update production.extendedwarranty table
					Me._objNIDataM = New NIDataManagement()
					If Me._objNIDataM.IsCorectRecordToUpdate(Me.EW_ID.Text, Me.RMA_No.Text) Then
						StrSQL_Ready1 = "Update production.extendedwarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
						'update
						If Me._objNIDataM.UpdateTable(StrSQL_Ready1) Then
							If strSQL_InvalidOrder.Trim.Length > 0 Then
								Me._objNIDataM.UpdateTable(strSQL_InvalidOrder)								  'set InvalidOrder=1
								StrSQL_Ready1 &= strSQL_InvalidOrder								  'For log
							End If
							'save log
							If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
							  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
							  StrSQL_Ready1.Replace("'", "''")) Then
							Else
								MessageBox.Show("Alert5: Failed to save the updated log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
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

				'Refresh after update
				LoadEndUserData()
				'After update and reload data, row index could be different, so search new rowindex based on EW_ID
				iRowIndex_New = findRowIdx(Me.EW_ID.Text)
				BindDataToUpdatePanel(iRowIndex_New)

				'MessageBox.Show(" StrSQL_Ready1=" & StrSQL_Ready1 & vbCrLf & " StrSQL_Ready2=" & StrSQL_Ready2)

				MessageBox.Show("Successfully Updated")

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
					MessageBox.Show("Name field cannot be empty.") : Exit Sub
				End If

				'Address
				If Not Me.Address1.Text.Length + Me.Address2.Text.Length > 0 Then
					MessageBox.Show("Address field(s) cannot be empty.") : Exit Sub
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
					MessageBox.Show("City field cannot be empty.") : Exit Sub
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
					MessageBox.Show("ZipCode field cannot be empty.") : Exit Sub
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
					MessageBox.Show("State field cannot be empty.") : Exit Sub
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
					MessageBox.Show("Country field cannot be empty.") : Exit Sub
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

				'REQUESTER 
				If cboRequester.SelectedIndex < 1 Then
					MessageBox.Show("You must select a Requester.", "Requester required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Dim _org_rqstr As String = Me.tdgData.Columns("Requester").CellText(iRowIndex).ToString.Trim()
				Dim _rqstr As String
				_rqstr = cboRequester.Text
				If _rqstr.ToUpper <> _org_rqstr.ToUpper Then
					strCol = "Requester="
					If strSQL.Trim.Length > 0 Then
						strSQL &= "," & strCol & CorrectString(_rqstr)
					Else
						strSQL &= strCol & CorrectString(_rqstr)
					End If
					If strOldValues.Trim.Length > 0 Then
						strOldValues &= ";" & strCol & _org_rqstr
					Else
						strOldValues &= strCol & _org_rqstr
					End If
				End If

				'Update Reason
				If Not Me.UpdateReason.Text.Trim.Length > 0 Then
					MessageBox.Show("Update Reason field cannot be empty. Please enter a reason!") : Exit Sub
				End If


				'Update now----------------------------------------------------------------------------------------------------------------------

				Me._objNIDataM = New NIDataManagement()
				If strSQL.Trim.Length > 0 AndAlso IsWOQuantityUpdate = True Then				   'Update ExtendedWarranty and tWorkOrder tables
					Me._objNIDataM.ValidateTableRecord_Bulk(Me.EW_ID.Text, Me.WO_ID.Text, Me._iCustID, Me.RMA_No.Text, strErrMsg)
					If strErrMsg.Trim.Length > 0 Then					  'failed
						MessageBox.Show("Failed to update! " & strErrMsg)
						Exit Sub
					Else					  'ok
						strSQL_Ready = "Update production.ExtendedWarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
						If Me._objNIDataM.UpdateTable(strSQL_Ready) Then
							'save log1
							If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
							  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
							  strSQL_Ready.Replace("'", "''")) Then
							Else
								MessageBox.Show("Alert1: Failed to save the updated log for  production.ExtendedWarranty.  (Tracker.extendedwarranty_log)")
							End If

							strSQL_Ready2 = "Update production.tWorkOrder Set WO_Quantity= " & newWOQuantity & " Where WO_ID=" & Me.WO_ID.Text
							If Me._objNIDataM.UpdateTable(strSQL_Ready2) Then
								'save log2
								If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
								  Me._iCustID, Me.RMA_No.Text, "Update", "WO_Quantity=" & newWOQuantity, _
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
				ElseIf strSQL.Trim.Length > 0 AndAlso IsWOQuantityUpdate = False Then				   'Update ExtendedWarranty table
					strSQL_Ready = "Update production.ExtendedWarranty Set " & strSQL & " Where EW_ID =" & Me.EW_ID.Text
					If Me._objNIDataM.UpdateTable(strSQL_Ready) Then
						'save log1
						If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
						  Me._iCustID, Me.RMA_No.Text, "Update", strOldValues.Replace("'", "''"), _
						  strSQL_Ready.Replace("'", "''")) Then
						Else
							MessageBox.Show("Alert1: Failed to save the updated log for  production.ExtendedWarranty.  (Tracker.extendedwarranty_log)")
						End If
					Else
						MessageBox.Show("Failed to update production.ExtendedWarranty.")
						Exit Sub
					End If
				ElseIf (Not strSQL.Trim.Length > 0) AndAlso IsWOQuantityUpdate = True Then				   'Update tWorkOrder table
					strSQL_Ready2 = "Update production.tWorkOrder Set WO_Quantity= " & newWOQuantity & " Where WO_ID=" & Me.WO_ID.Text
					If Me._objNIDataM.UpdateTable(strSQL_Ready2) Then
						'save log2
						If Me._objNIDataM.SaveLog(Me.UpdateReason.Text.Trim(), sessionDateTime, Me._iUserID, Me.EW_ID.Text, _
						  Me._iCustID, Me.RMA_No.Text, "Update", "WO_Quantity=" & newWOQuantity, _
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

				MessageBox.Show("Successfully Updated")

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "EditMode_getUpdateSQL4Bulk", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try

		End Sub

		'********************************************************************************
		Private Sub AddNewMode_getAddSQL4EndUser()
			Dim iRowIndex As Integer
			Dim strSQL As String = "", strCols As String = "", strValues As String = ""
			Dim tmpS As String = "", strColName As String = "", errMsg As String = ""
			Dim iID As Integer = 0, newEW_ID As Integer

			Try
				Dim iSC_ID As Integer = 2				'FedEx Ground
				Dim dtLoadedDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
				Dim iNI_DataSwitch As Integer = 1				'NI RMA 
				Dim iStatus_ID As Integer = 1				'RMA Received
				Dim iReturnBoxYesNo As Integer = 0
				Dim sessionDateTime As String = dtLoadedDateTime

				' iRowIndex = Me.RowID.Text - 1

				'ClaimNo: RMA_No
				tmpS = Me.RMA_No.Text.Trim : strColName = "ClaimNo"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("RMA_No field cannot be empty.") : Exit Sub
				End If

				'Check for duplicated RMA (existing)
				_objNIDataM = New NIDataManagement()
				If _objNIDataM.RMANumberExist(Me._iCustID, 1, tmpS) Then
					MessageBox.Show("RMA_No " & tmpS & " exists!") : Exit Sub
				End If
				_objNIDataM = Nothing

				'ShipTo_Name
				tmpS = Me.txtName.Text.Trim : strColName = "ShipTo_Name"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("Name field cannot be empty.") : Exit Sub
				End If

				'Address
				If Not (Me.Address1.Text.Trim.Length + Me.Address2.Text.Trim.Length) > 0 Then
					MessageBox.Show("Address cannot be empty.") : Exit Sub
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
					MessageBox.Show("City field cannot be empty.") : Exit Sub
				End If

				'ZipCode
				tmpS = Me.ZipCode.Text.Trim : strColName = "ZipCode"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("ZipCode field cannot be empty.") : Exit Sub
				End If

				'State:  State_ShortName, State_ID
				tmpS = Me.State.Text.Trim : strColName = "State_ShortName"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("State field cannot be empty.") : Exit Sub
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
					MessageBox.Show("Country field cannot be empty.") : Exit Sub
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
					MessageBox.Show("Phone field cannot be empty.") : Exit Sub
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
					MessageBox.Show("Email field cannot be empty.") : Exit Sub
				End If

				'Product
				Try
					iID = Me.Product.SelectedValue
					If iID > 0 Then
						strColName = "Prod_Code"
						If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
						If strValues.Trim.Length > 0 Then strValues &= "," & iID Else strValues &= iID
					Else
						MessageBox.Show("Invalid Product.") : Exit Sub
					End If
				Catch ex As Exception
					MessageBox.Show("Invalid Product.") : Exit Sub
				End Try

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

				'REQUESTER
				If cboRequester.SelectedIndex < 1 Then
					MessageBox.Show("You must select a Requester.", "Requester required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Dim _rqstr As String
				_rqstr = cboRequester.Text.Trim
				strColName = "Requester"
				If _rqstr.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(_rqstr) Else strValues &= CorrectString(_rqstr)
				Else
					MessageBox.Show("Requester field cannot be empty.") : Exit Sub
				End If

				' PACKAGING UPFRONT.
				If cboPkngUF.Text <> "Yes" AndAlso cboPkngUF.Text <> "No" Then
					MessageBox.Show("You must select a value for Packaging Upfront.", "Packaging Upfront required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				Else
					strCols &= ", " & "PackagingUpfront"
					strValues &= ", '" & cboPkngUF.Text & "'"
				End If

				' RETURNBOXYESNO.
				If cboPkngUF.Text = "Yes" Then
					iReturnBoxYesNo = 1
				Else
					iReturnBoxYesNo = 0
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
					MessageBox.Show("HardwareSerial field cannot be empty.") : Exit Sub
				End If

				'DefectType1: ErrDesc_ItemSKU
				tmpS = Me.DefectType1.Text.Trim : strColName = "DefectType1"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("DefectType1 field cannot be empty.") : Exit Sub
				End If

				'ErrorDescription: ErrDesc_ItemSKU
				tmpS = Me.ErrorDescription.Text.Trim : strColName = "ErrDesc_ItemSKU"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("ErrorDescription field cannot be empty.") : Exit Sub
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
					strCols &= "," & "Cust_ID,Date,SC_ID,LoadedDateTime,NI_DataSwitch,S_ID,ReturnBoxYesNo"
					strValues &= "," & Me._iCustID & ",'" & dtLoadedDateTime & "'," & iSC_ID & _
					 ",'" & dtLoadedDateTime & "'," & iNI_DataSwitch & "," & iStatus_ID & "," & iReturnBoxYesNo
					strSQL = "(" & strCols & ") Values (" & strValues & ")"
					strSQL = "INSERT INTO Production.ExtendedWarranty (" & strCols & ") Values (" & strValues & ");"

					Me._objNIDataM = New NIDataManagement()
					Me._objNIDataM.InsertNewData2Table(strSQL, newEW_ID, errMsg)					  'we may need to know newEW_ID

					If errMsg.Trim.Length > 0 Then
						MessageBox.Show(errMsg) : Exit Sub
					Else
						'Save log
						If Me._objNIDataM.SaveLog("Add new", sessionDateTime, Me._iUserID, newEW_ID, Me._iCustID, Me.RMA_No.Text, "Insert", "", _
						  strSQL.Replace("'", "''")) Then
						Else
							MessageBox.Show("Alert1: Failed to save the inserted log for production.extendedwarranty. (Tracker.extendedwarranty_log)")
						End If

						'Refresh data 
						LoadEndUserData()
						Me.rbtAddNew.Checked = False
						Me.rbtAddNew.Checked = True
						MessageBox.Show("The new record was successfully added.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
				Else
					MessageBox.Show("Exception occurred!") : Exit Sub
				End If


				'MessageBox.Show(strSQL)

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "AddNewMode_getAddSQL4EndUser", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
			Dim iStatus_ID As Integer = 1			 'RMA Received
			Dim iReturnBoxYesNo As Integer = 0
			Dim strSQL_CreatWO As String = ""

			Try
				'ClaimNo: RMA_No
				tmpS = Me.RMA_No.Text.Trim : strColName = "ClaimNo"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("RMA_No field cannot be empty.") : Exit Sub
				End If

				'Check for duplicated RMA (existing)
				_objNIDataM = New NIDataManagement()
				If _objNIDataM.RMANumberExist(Me._iCustID, 2, tmpS) Then
					MessageBox.Show("RMA_No " & tmpS & " exists!") : Exit Sub
				End If
				_objNIDataM = Nothing

				'ShipTo_Name
				tmpS = Me.txtName.Text.Trim : strColName = "ShipTo_Name"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("Name field cannot be empty.") : Exit Sub
				End If

				'Address
				If Not (Me.Address1.Text.Trim.Length + Me.Address2.Text.Trim.Length) > 0 Then
					MessageBox.Show("Address cannot be empty.") : Exit Sub
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
					MessageBox.Show("City field cannot be empty.") : Exit Sub
				End If

				'ZipCode
				tmpS = Me.ZipCode.Text.Trim : strColName = "ZipCode"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("ZipCode field cannot be empty.") : Exit Sub
				End If

				'State:  State_ShortName, State_ID
				tmpS = Me.State.Text.Trim : strColName = "State_ShortName"
				If tmpS.Length > 0 Then
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then strValues &= "," & CorrectString(tmpS) Else strValues &= CorrectString(tmpS)
				Else
					MessageBox.Show("State field cannot be empty.") : Exit Sub
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
					MessageBox.Show("Country field cannot be empty.") : Exit Sub
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
							MessageBox.Show("Invalid Work Order Quantity (must be a numeric value.") : Exit Sub
						End If
					Catch ex As Exception
						MessageBox.Show("Exception error: WO_Quantity." & ex.Message) : Exit Sub
					End Try
				Else
					MessageBox.Show("Invalid Work Order Quantity (must be a numeric value).") : Exit Sub
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

				'REQUESTER
				If cboRequester.SelectedIndex < 1 Then
					MessageBox.Show("You must select a Requester.", "Requester required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Dim _rqstr As String
				_rqstr = cboRequester.Text.Trim
				strColName = "Requester"
				If _rqstr.Length > 0 Then
					If strCols.Trim.Length > 0 Then
						strCols &= "," & strColName
					Else
						strCols &= strColName
					End If
					If strValues.Trim.Length > 0 Then
						strValues &= "," & CorrectString(_rqstr)
					Else
						strValues &= CorrectString(_rqstr)
					End If
				Else
					MessageBox.Show("Requester field cannot be empty.")
					Exit Sub
				End If

				'BulkORderType
				iID = Me.BulkOrderType.SelectedValue : strColName = "BulkORderType_ID"
				If Not iID > 0 Then
					MessageBox.Show("Invalid BulkORderType.") : Exit Sub
				Else
					If strCols.Trim.Length > 0 Then strCols &= "," & strColName Else strCols &= strColName
					If strValues.Trim.Length > 0 Then
						strValues &= "," & iID
					Else
						strValues &= iID
					End If
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

				' MessageBox.Show(strSQL)

				'Save data
				If strCols.Trim.Length > 0 AndAlso strValues.Trim.Length > 0 Then
					Me._objNIDataM = New NIDataManagement()
					iLocID = Me._objNIDataM.getLocationID(Me._iCustID)
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
							strCols &= "," & "WO_ID,Cust_ID,Date,LoadedDateTime,NI_DataSwitch,S_ID,ReturnBoxYesNo "
							strValues &= "," & iWO_ID & "," & Me._iCustID & ",'" & SessionDateTime & "','" & _
							SessionDateTime & "'," & iNI_DataSwitch & "," & iStatus_ID & "," & iReturnBoxYesNo

							strSQL = "INSERT INTO Production.ExtendedWarranty (" & strCols & ") VALUES (" & strValues & ");"

							Me._objNIDataM.InsertNewData2Table(strSQL, newEW_ID, strErrMsg)
							If strErrMsg.Trim.Length > 0 Then
								MessageBox.Show("Failed to add bulk data to production.extendedwarranty! " & strErrMsg) : Exit Sub
							Else
								'Save log
								If Me._objNIDataM.SaveLog("Add new master bulk data", SessionDateTime, Me._iUserID, newEW_ID, Me._iCustID, Me.RMA_No.Text, "Insert", "", _
								strSQL_CreatWO.Replace("'", "''")) Then
								Else
									MessageBox.Show("Alert1: Failed to save the inserted log to production.tWorkorder table. (Tracker.extendedwarranty_log)")
								End If
								If Me._objNIDataM.SaveLog("Add new master bulk data", SessionDateTime, Me._iUserID, newEW_ID, Me._iCustID, Me.RMA_No.Text, "Insert", "", _
								  strSQL.Replace("'", "''")) Then
								Else
									MessageBox.Show("Alert2: Failed to save the inserted log to production.extendedwarranty table. (Tracker.extendedwarranty_log)")
								End If
							End If

							'Refresh data 
							LoadBulkMasterData()
							Me.rbtAddNew.Checked = False
							Me.rbtAddNew.Checked = True
							MessageBox.Show("Successfully Added")
						Else
							MessageBox.Show("Invalid Work Order ID.") : Exit Sub
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

					' REQUESTER.
					If Not IsDBNull(Me.tdgData.Columns("Requester").Value) Then tmpStr = Me.tdgData.Columns("Requester").Value Else tmpStr = ""
					If Not tmpStr.Trim.ToUpper = Me.cboRequester.Text.Trim.ToUpper Then
						Me.btnUpdate.ForeColor = Color.Red
						Return True
						Exit Function
					End If

					' PACKAGING UPFRONT.
					If _IsEndUserData Then
						If Not IsDBNull(Me.tdgData.Columns("PackagingUpfront").Value) Then
							tmpStr = Me.tdgData.Columns("PackagingUpfront").Value
						Else
							tmpStr = ""
						End If
						If Not tmpStr.Trim.ToUpper = Me.cboPkngUF.Text.Trim.ToUpper Then
							Me.btnUpdate.ForeColor = Color.Red
							Return True
							Exit Function
						End If
					End If

					'RepairType
					With Me
						Select Case .RepairType.Text.Trim.ToUpper
							Case .enumRepairType.SendNew.ToString.Trim.ToUpper, .enumRepairType.SendRefurb.ToString.Trim.ToUpper, .enumRepairType.SendNothing.ToString.Trim.ToUpper
								If .chkChange1.Checked Then
									Me.btnUpdate.ForeColor = Color.Red
									Return True : Exit Function
								ElseIf .chkChange2.Checked Then
									Me.btnUpdate.ForeColor = Color.Red
									Return True : Exit Function
								End If
						End Select
					End With

				ElseIf Me._IsBulkData Then
					If Not IsDBNull(Me.tdgData.Columns("WO_Quantity").Value) Then tmpStr = Me.tdgData.Columns("WO_Quantity").Value Else tmpStr = ""

					' REQUESTER.
					If Not IsDBNull(Me.tdgData.Columns("Requester").Value) Then tmpStr = Me.tdgData.Columns("Requester").Value Else tmpStr = ""
					If Not tmpStr.Trim.ToUpper = Me.cboRequester.Text.Trim.ToUpper Then
						Me.btnUpdate.ForeColor = Color.Red
						Return True
						Exit Function
					End If

					' PACKAGING UPFRONT.
					If Not IsDBNull(Me.tdgData.Columns("PackagingUpfront").Value) Then
						tmpStr = Me.tdgData.Columns("PackagingUpfront").Value
					Else
						tmpStr = ""
					End If
					If Not tmpStr.Trim.ToUpper = Me.cboPkngUF.Text.Trim.ToUpper Then
						Me.btnUpdate.ForeColor = Color.Red
						Return True
						Exit Function
					End If

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
						If EW_ID = .Columns("EW_ID").CellText(i) Then						 'found it
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

		'********************************************************************************
		'Private Sub RepairType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepairType.SelectedIndexChanged
		'    MessageBox.Show("Index=" & RepairType.SelectedIndex & "  Item=" & RepairType.SelectedItem & "  Text=" & RepairType.SelectedText & "  Value=" & RepairType.SelectedValue)
		'End Sub

		'********************************************************************************
		Private Sub chkChange1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkChange1.Click
			chkChange1.ForeColor = Color.Black
			If chkChange1.Checked Then
				chkChange2.Checked = False
				chkChange1.ForeColor = Color.Indigo : chkChange2.ForeColor = Color.Black
			End If
		End Sub

		'********************************************************************************
		Private Sub chkChange2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkChange2.Click
			chkChange2.ForeColor = Color.Black
			If chkChange2.Checked Then
				chkChange1.Checked = False
				chkChange2.ForeColor = Color.Indigo : chkChange1.ForeColor = Color.Black
			End If
		End Sub

		'********************************************************************************
		Private Function ProcessRMAWhenChangingRepairType(ByVal strRMA_No As String, ByRef iSOHeaderID As Integer) As String
			Dim dtHeader, dtDetails, dtWareHouseItems As DataTable
			Dim row As DataRow
			Dim iSODetailsID As Integer = 0
			Dim strS As String = ""
			Dim bFoundDetailID_InWarehouseItem As Boolean = False
			Try
				iSOHeaderID = 0
				Me._objNIDataM = New NIDataManagement()

				dtHeader = Me._objNIDataM.getFillOrderHeaderData(strRMA_No)
				'MessageBox.Show("dtHeader.Rows.Count=" & dtHeader.Rows.Count)

				If Not dtHeader.Rows.Count > 0 Then				'No record
					Return Me.enumFillOrderStatus.FillOrderNotCreated.ToString
				ElseIf dtHeader.Rows.Count = 1 Then				'1 record
					iSOHeaderID = dtHeader.Rows(0).Item("SOHeaderID")
					'MessageBox.Show(" iSOHeaderID =" & iSOHeaderID)
					dtDetails = Me._objNIDataM.getFillOrderDetailsData(iSOHeaderID)
					For Each row In dtDetails.Rows					  'should be 1 record
						iSODetailsID = row("SODetailsID")
						dtWareHouseItems = Me._objNIDataM.getFillOrderWarehouseItemData(iSODetailsID)
						If dtWareHouseItems.Rows.Count > 0 Then
							bFoundDetailID_InWarehouseItem = True
						Else
							bFoundDetailID_InWarehouseItem = False
						End If
						Exit For
					Next
					dtDetails = Nothing : dtWareHouseItems = Nothing

					If dtHeader.Rows(0).IsNull("ShipDate") Then					  'Null
						If bFoundDetailID_InWarehouseItem Then
							Return Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_FoundDetailIDInWarehouseItems.ToString
						Else
							Return Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_NotFoundDetailIDInWarehouseItems.ToString
						End If
					Else					  'Not Null
						strS = dtHeader.Rows(0).Item("ShipDate")
						If strS.Trim.Length = 0 Then						 'nothing
							If bFoundDetailID_InWarehouseItem Then
								Return Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_FoundDetailIDInWarehouseItems.ToString
							Else
								Return Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_NotFoundDetailIDInWarehouseItems.ToString
							End If
						Else						 'Have something
							If IsDate(strS) Then							'Is date
								Return Me.enumFillOrderStatus.FillOrderCreatedAndShipped.ToString
							Else							'Not date
								If bFoundDetailID_InWarehouseItem Then
									Return Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_FoundDetailIDInWarehouseItems.ToString
								Else
									Return Me.enumFillOrderStatus.FillOrderCreatedButNotShipped_NotFoundDetailIDInWarehouseItems.ToString
								End If
							End If
						End If
					End If
				Else				'>1 more than 1 records
					Return Me.enumFillOrderStatus.FillOrdersCreatedMultiple.ToString
				End If

			Catch ex As Exception
				Return ""
				MessageBox.Show(ex.ToString, "ProcessRMAWhenChangingRepairType", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Function

#End Region
#Region "COMMON CONTROL EVENTS"

		Private Sub btnRqstrAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRqstrAdd.Click
			' Add new Requester to the PRODUCTION.NI_REQUESTERS table.
			Dim _obj As New Data.Buisness.NIDataManagement()
			Dim _newRqstr As String
			Try
				_newRqstr = InputBox("Enter the name of the new Requester.", "New Requester")
				If _newRqstr = "" Then
					Exit Sub
				End If
				If IsNumeric(_newRqstr.Substring(1, 1)) Then
					MessageBox.Show("", "Invalid Requester Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Me.Cursor = Cursors.WaitCursor
				If _newRqstr <> "" Then
					_obj.InsertNIRequester(_newRqstr)
					PopulateRequesterCombo()
					cboRequester.Text = _newRqstr
					Me.Cursor = Cursors.Default
					MessageBox.Show("The new requester " & _newRqstr & " has been added.", "New Requester Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
			Catch ex As Exception
				Me.Cursor = Cursors.Default
				If InStr(ex.Message, "duplicate") > 0 Then
					MessageBox.Show("The entered value already exists in the list.", "Duplicate Requester", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Else
					MessageBox.Show("An error occurred while inserting a new requester" & vbCrLf & vbCrLf & ex.Message, "Add Requester failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Finally
				_obj = Nothing
			End Try
		End Sub

#End Region
#Region "COMMON METHODS"

		Private Sub PopulateRequesterCombo()
			' Populate the Requester Combobox.
			Dim _dt As New DataTable()
			_objNIDataM = New NIDataManagement()
			_dt = _objNIDataM.GetNIRequesters()
			Dim _dr As DataRow
			_dr = _dt.NewRow()
			_dr(0) = 0
			_dr(1) = "<Select>"
			_dt.Rows.InsertAt(_dr, 0)
			_dt.AcceptChanges()
			cboRequester.DataSource = _dt
			cboRequester.ValueMember = _dt.Columns("rqstr_na").ToString
			cboRequester.DisplayMember = _dt.Columns("rqstr_na").ToString
		End Sub
		Private Function ConvertNulls(ByVal value As Object, ByVal newValue As Object)
			' Convert null values to a different value.
			If IsDBNull(value) Then
				Return newValue
			Else
				Return value
			End If
		End Function
		Private Function ConvertNullsAndEmptyString(ByVal value As Object, ByVal newValue As Object)
			' Convert null or empty string values to a different value.
			If IsDBNull(value) OrElse value = "" Then
				Return newValue
			Else
				Return value
			End If
		End Function

#End Region

	End Class
End Namespace