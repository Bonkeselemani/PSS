Option Explicit On

Imports System.IO
Imports System
Imports System.Windows.Forms


Namespace Gui
    Public Class frmCustmaintNew
        Inherits System.Windows.Forms.Form

        Public Enum TableName
            lparentco
            tcustomer
            tlocation
            tpurchaseorder
            tlabprcgrp
            lpricingtype
            tcmlabmap
            tmodel
            lbillcodes
            tcmpartmap
            lpsswrtyparts
            lpsswrtylabor
            lpaymethod
            lstate
            lcountry
            lcctype
            tslsp
            YesNo
        End Enum

        Private _objCustMaintNew As Data.Buisness.CustMaintNew
        Private _dtTablesArr(18) As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objCustMaintNew = New Data.Buisness.CustMaintNew()
           
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
        Friend WithEvents tpgCustomer As System.Windows.Forms.TabPage
        Friend WithEvents tpgPricing As System.Windows.Forms.TabPage
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label63 As System.Windows.Forms.Label
        Friend WithEvents Label34 As System.Windows.Forms.Label
        Friend WithEvents Label33 As System.Windows.Forms.Label
        Friend WithEvents Label32 As System.Windows.Forms.Label
        Friend WithEvents Label31 As System.Windows.Forms.Label
        Friend WithEvents Label30 As System.Windows.Forms.Label
        Friend WithEvents Label27 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents tpgLoc As System.Windows.Forms.TabPage
        Friend WithEvents tpgCustToPrice As System.Windows.Forms.TabPage
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
        Friend WithEvents Label62 As System.Windows.Forms.Label
        Friend WithEvents tpgPO As System.Windows.Forms.TabPage
        Friend WithEvents grdDevice As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnPricingAdd As System.Windows.Forms.Button
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents Label71 As System.Windows.Forms.Label
        Friend WithEvents Label67 As System.Windows.Forms.Label
        Friend WithEvents lblCMplusParts As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents tpgPCo As System.Windows.Forms.TabPage
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtCust_Memo As System.Windows.Forms.TextBox
        Friend WithEvents txtCust_MarkUpRUR As System.Windows.Forms.TextBox
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents cmbCust_Product As System.Windows.Forms.ComboBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents txtCust_MarkupNTF As System.Windows.Forms.TextBox
        Friend WithEvents chkCust_Inactive As System.Windows.Forms.CheckBox
        Friend WithEvents cmbCust_InvoiceDetail As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_CollSalesTax As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_CrAppShip As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_CrAppRec As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_RepLCD As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_RepNonWrty As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_PlusParts As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_SalePerson As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_Pco As System.Windows.Forms.ComboBox
        Friend WithEvents lblCust_LName_New As System.Windows.Forms.Label
        Friend WithEvents lblCust_FName_New As System.Windows.Forms.Label
        Friend WithEvents cmbCust_LName As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_FName As System.Windows.Forms.ComboBox
        Friend WithEvents btnCust_Cancel As System.Windows.Forms.Button
        Friend WithEvents btnCust_New As System.Windows.Forms.Button
        Friend WithEvents btnCust_AddUpdate As System.Windows.Forms.Button
        Friend WithEvents txtCust_MarkUpRTM As System.Windows.Forms.TextBox
        Friend WithEvents cmbCust_MarkUpPlusparts As System.Windows.Forms.ComboBox
        Friend WithEvents txtCust_MarkupInvt As System.Windows.Forms.TextBox
        Friend WithEvents cmbCust_MarkUpInvMthdID As System.Windows.Forms.ComboBox
        Friend WithEvents txtCust_MarkUpCust As System.Windows.Forms.TextBox
        Friend WithEvents txtCust_MarkUpNER As System.Windows.Forms.TextBox
        Friend WithEvents chkPco_Inactive As System.Windows.Forms.CheckBox
        Friend WithEvents btnPco_Cancel As System.Windows.Forms.Button
        Friend WithEvents btnPco_New As System.Windows.Forms.Button
        Friend WithEvents cmbPco_PSSWrtyLabor As System.Windows.Forms.ComboBox
        Friend WithEvents cmbPco_PSSWrtyPart As System.Windows.Forms.ComboBox
        Friend WithEvents txtPco_WrtyDay As System.Windows.Forms.TextBox
        Friend WithEvents chkPco_EndUser As System.Windows.Forms.CheckBox
        Friend WithEvents txtPco_MotoCode As System.Windows.Forms.TextBox
        Friend WithEvents btnPco_AddUpdate As System.Windows.Forms.Button
        Friend WithEvents lblPco_Name_New As System.Windows.Forms.Label
        Friend WithEvents cmbPco_Name As System.Windows.Forms.ComboBox
        Friend WithEvents txtCust_DaysInWrty As System.Windows.Forms.TextBox
        Friend WithEvents btnLoc_New As System.Windows.Forms.Button
        Friend WithEvents btnLoc_AddUpdate As System.Windows.Forms.Button
        Friend WithEvents lstLoc_Location As System.Windows.Forms.ListBox
        Friend WithEvents cmbLoc_Customer As System.Windows.Forms.ComboBox
        Friend WithEvents cmbLoc_ManifestDetail As System.Windows.Forms.ComboBox
        Friend WithEvents cmbLoc_Country As System.Windows.Forms.ComboBox
        Friend WithEvents cmbLoc_State As System.Windows.Forms.ComboBox
        Friend WithEvents txtLoc_Email As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Fax As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Phone As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Contact As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Zip As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_City As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Address2 As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Address1 As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Name As System.Windows.Forms.TextBox
        Friend WithEvents btnLoc_Cancel As System.Windows.Forms.Button
        Friend WithEvents txtLoc_ShippingMemo As System.Windows.Forms.TextBox
        Friend WithEvents txtLoc_Memo As System.Windows.Forms.TextBox
        Friend WithEvents cmbLoc_AfterMarket As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_PayID As System.Windows.Forms.ComboBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents cmbCust_WrtyLabor As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCust_WrtyParts As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustmaintNew))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgPCo = New System.Windows.Forms.TabPage()
            Me.cmbPco_PSSWrtyLabor = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cmbPco_PSSWrtyPart = New System.Windows.Forms.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtPco_WrtyDay = New System.Windows.Forms.TextBox()
            Me.chkPco_EndUser = New System.Windows.Forms.CheckBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtPco_MotoCode = New System.Windows.Forms.TextBox()
            Me.btnPco_AddUpdate = New System.Windows.Forms.Button()
            Me.chkPco_Inactive = New System.Windows.Forms.CheckBox()
            Me.lblPco_Name_New = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnPco_Cancel = New System.Windows.Forms.Button()
            Me.cmbPco_Name = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnPco_New = New System.Windows.Forms.Button()
            Me.tpgCustomer = New System.Windows.Forms.TabPage()
            Me.cmbCust_PayID = New System.Windows.Forms.ComboBox()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cmbCust_WrtyLabor = New System.Windows.Forms.ComboBox()
            Me.cmbCust_WrtyParts = New System.Windows.Forms.ComboBox()
            Me.txtCust_DaysInWrty = New System.Windows.Forms.TextBox()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.cmbCust_Product = New System.Windows.Forms.ComboBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.txtCust_Memo = New System.Windows.Forms.TextBox()
            Me.btnCust_New = New System.Windows.Forms.Button()
            Me.Label32 = New System.Windows.Forms.Label()
            Me.cmbCust_Pco = New System.Windows.Forms.ComboBox()
            Me.btnCust_AddUpdate = New System.Windows.Forms.Button()
            Me.Label34 = New System.Windows.Forms.Label()
            Me.btnCust_Cancel = New System.Windows.Forms.Button()
            Me.lblCust_LName_New = New System.Windows.Forms.Label()
            Me.cmbCust_CrAppShip = New System.Windows.Forms.ComboBox()
            Me.Label33 = New System.Windows.Forms.Label()
            Me.lblCust_FName_New = New System.Windows.Forms.Label()
            Me.chkCust_Inactive = New System.Windows.Forms.CheckBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cmbCust_CrAppRec = New System.Windows.Forms.ComboBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label31 = New System.Windows.Forms.Label()
            Me.Label30 = New System.Windows.Forms.Label()
            Me.cmbCust_LName = New System.Windows.Forms.ComboBox()
            Me.cmbCust_SalePerson = New System.Windows.Forms.ComboBox()
            Me.Label27 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.cmbCust_InvoiceDetail = New System.Windows.Forms.ComboBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.cmbCust_FName = New System.Windows.Forms.ComboBox()
            Me.cmbCust_RepLCD = New System.Windows.Forms.ComboBox()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.txtCust_MarkUpRTM = New System.Windows.Forms.TextBox()
            Me.Label71 = New System.Windows.Forms.Label()
            Me.txtCust_MarkupNTF = New System.Windows.Forms.TextBox()
            Me.Label67 = New System.Windows.Forms.Label()
            Me.cmbCust_MarkUpPlusparts = New System.Windows.Forms.ComboBox()
            Me.lblCMplusParts = New System.Windows.Forms.Label()
            Me.txtCust_MarkupInvt = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.cmbCust_MarkUpInvMthdID = New System.Windows.Forms.ComboBox()
            Me.txtCust_MarkUpCust = New System.Windows.Forms.TextBox()
            Me.txtCust_MarkUpNER = New System.Windows.Forms.TextBox()
            Me.txtCust_MarkUpRUR = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.cmbCust_RepNonWrty = New System.Windows.Forms.ComboBox()
            Me.cmbCust_CollSalesTax = New System.Windows.Forms.ComboBox()
            Me.Label63 = New System.Windows.Forms.Label()
            Me.cmbCust_PlusParts = New System.Windows.Forms.ComboBox()
            Me.tpgLoc = New System.Windows.Forms.TabPage()
            Me.btnLoc_Cancel = New System.Windows.Forms.Button()
            Me.btnLoc_New = New System.Windows.Forms.Button()
            Me.btnLoc_AddUpdate = New System.Windows.Forms.Button()
            Me.lstLoc_Location = New System.Windows.Forms.ListBox()
            Me.cmbLoc_Customer = New System.Windows.Forms.ComboBox()
            Me.txtLoc_ShippingMemo = New System.Windows.Forms.TextBox()
            Me.txtLoc_Memo = New System.Windows.Forms.TextBox()
            Me.cmbLoc_ManifestDetail = New System.Windows.Forms.ComboBox()
            Me.cmbLoc_AfterMarket = New System.Windows.Forms.ComboBox()
            Me.cmbLoc_Country = New System.Windows.Forms.ComboBox()
            Me.cmbLoc_State = New System.Windows.Forms.ComboBox()
            Me.txtLoc_Email = New System.Windows.Forms.TextBox()
            Me.txtLoc_Fax = New System.Windows.Forms.TextBox()
            Me.txtLoc_Phone = New System.Windows.Forms.TextBox()
            Me.txtLoc_Contact = New System.Windows.Forms.TextBox()
            Me.txtLoc_Zip = New System.Windows.Forms.TextBox()
            Me.txtLoc_City = New System.Windows.Forms.TextBox()
            Me.txtLoc_Address2 = New System.Windows.Forms.TextBox()
            Me.txtLoc_Address1 = New System.Windows.Forms.TextBox()
            Me.txtLoc_Name = New System.Windows.Forms.TextBox()
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
            Me.tpgPO = New System.Windows.Forms.TabPage()
            Me.tpgPricing = New System.Windows.Forms.TabPage()
            Me.btnPricingAdd = New System.Windows.Forms.Button()
            Me.grdDevice = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgCustToPrice = New System.Windows.Forms.TabPage()
            Me.TabControl1.SuspendLayout()
            Me.tpgPCo.SuspendLayout()
            Me.tpgCustomer.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.tpgLoc.SuspendLayout()
            Me.tpgPricing.SuspendLayout()
            CType(Me.grdDevice, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgPCo, Me.tpgCustomer, Me.tpgLoc, Me.tpgPO, Me.tpgPricing, Me.tpgCustToPrice})
            Me.TabControl1.Location = New System.Drawing.Point(5, 4)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(699, 508)
            Me.TabControl1.TabIndex = 0
            '
            'tpgPCo
            '
            Me.tpgPCo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgPCo.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbPco_PSSWrtyLabor, Me.Label5, Me.cmbPco_PSSWrtyPart, Me.Label3, Me.txtPco_WrtyDay, Me.chkPco_EndUser, Me.Label2, Me.txtPco_MotoCode, Me.btnPco_AddUpdate, Me.chkPco_Inactive, Me.lblPco_Name_New, Me.Label1, Me.btnPco_Cancel, Me.cmbPco_Name, Me.Label6, Me.Label4, Me.btnPco_New})
            Me.tpgPCo.Location = New System.Drawing.Point(4, 22)
            Me.tpgPCo.Name = "tpgPCo"
            Me.tpgPCo.Size = New System.Drawing.Size(691, 482)
            Me.tpgPCo.TabIndex = 5
            Me.tpgPCo.Text = "Parent Company"
            '
            'cmbPco_PSSWrtyLabor
            '
            Me.cmbPco_PSSWrtyLabor.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbPco_PSSWrtyLabor.Location = New System.Drawing.Point(120, 152)
            Me.cmbPco_PSSWrtyLabor.Name = "cmbPco_PSSWrtyLabor"
            Me.cmbPco_PSSWrtyLabor.Size = New System.Drawing.Size(208, 21)
            Me.cmbPco_PSSWrtyLabor.TabIndex = 28
            Me.cmbPco_PSSWrtyLabor.TabStop = False
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(24, 120)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 24)
            Me.Label5.TabIndex = 26
            Me.Label5.Text = "PSS Warranty Parts:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbPco_PSSWrtyPart
            '
            Me.cmbPco_PSSWrtyPart.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbPco_PSSWrtyPart.Location = New System.Drawing.Point(120, 120)
            Me.cmbPco_PSSWrtyPart.Name = "cmbPco_PSSWrtyPart"
            Me.cmbPco_PSSWrtyPart.Size = New System.Drawing.Size(208, 21)
            Me.cmbPco_PSSWrtyPart.TabIndex = 25
            Me.cmbPco_PSSWrtyPart.TabStop = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(24, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 24
            Me.Label3.Text = "Warranty Days:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPco_WrtyDay
            '
            Me.txtPco_WrtyDay.Location = New System.Drawing.Point(120, 96)
            Me.txtPco_WrtyDay.Name = "txtPco_WrtyDay"
            Me.txtPco_WrtyDay.Size = New System.Drawing.Size(120, 20)
            Me.txtPco_WrtyDay.TabIndex = 23
            Me.txtPco_WrtyDay.Text = ""
            '
            'chkPco_EndUser
            '
            Me.chkPco_EndUser.BackColor = System.Drawing.Color.Transparent
            Me.chkPco_EndUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPco_EndUser.ForeColor = System.Drawing.Color.Black
            Me.chkPco_EndUser.Location = New System.Drawing.Point(61, 184)
            Me.chkPco_EndUser.Name = "chkPco_EndUser"
            Me.chkPco_EndUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkPco_EndUser.Size = New System.Drawing.Size(72, 14)
            Me.chkPco_EndUser.TabIndex = 22
            Me.chkPco_EndUser.Text = "End User"
            Me.chkPco_EndUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(24, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 16)
            Me.Label2.TabIndex = 21
            Me.Label2.Text = "Moto Code:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPco_MotoCode
            '
            Me.txtPco_MotoCode.Location = New System.Drawing.Point(120, 72)
            Me.txtPco_MotoCode.Name = "txtPco_MotoCode"
            Me.txtPco_MotoCode.Size = New System.Drawing.Size(120, 20)
            Me.txtPco_MotoCode.TabIndex = 20
            Me.txtPco_MotoCode.Text = ""
            '
            'btnPco_AddUpdate
            '
            Me.btnPco_AddUpdate.BackColor = System.Drawing.Color.Green
            Me.btnPco_AddUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPco_AddUpdate.ForeColor = System.Drawing.Color.White
            Me.btnPco_AddUpdate.Location = New System.Drawing.Point(240, 8)
            Me.btnPco_AddUpdate.Name = "btnPco_AddUpdate"
            Me.btnPco_AddUpdate.Size = New System.Drawing.Size(88, 20)
            Me.btnPco_AddUpdate.TabIndex = 19
            Me.btnPco_AddUpdate.Text = "Add/Update"
            '
            'chkPco_Inactive
            '
            Me.chkPco_Inactive.BackColor = System.Drawing.Color.Transparent
            Me.chkPco_Inactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPco_Inactive.ForeColor = System.Drawing.Color.Black
            Me.chkPco_Inactive.Location = New System.Drawing.Point(61, 208)
            Me.chkPco_Inactive.Name = "chkPco_Inactive"
            Me.chkPco_Inactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkPco_Inactive.Size = New System.Drawing.Size(72, 14)
            Me.chkPco_Inactive.TabIndex = 34
            Me.chkPco_Inactive.Text = "Inactive"
            Me.chkPco_Inactive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPco_Name_New
            '
            Me.lblPco_Name_New.BackColor = System.Drawing.Color.Transparent
            Me.lblPco_Name_New.ForeColor = System.Drawing.Color.White
            Me.lblPco_Name_New.Location = New System.Drawing.Point(123, 50)
            Me.lblPco_Name_New.Name = "lblPco_Name_New"
            Me.lblPco_Name_New.Size = New System.Drawing.Size(200, 16)
            Me.lblPco_Name_New.TabIndex = 17
            Me.lblPco_Name_New.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPco_Name_New.Visible = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(24, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 16)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPco_Cancel
            '
            Me.btnPco_Cancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPco_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPco_Cancel.ForeColor = System.Drawing.Color.White
            Me.btnPco_Cancel.Location = New System.Drawing.Point(136, 8)
            Me.btnPco_Cancel.Name = "btnPco_Cancel"
            Me.btnPco_Cancel.Size = New System.Drawing.Size(72, 20)
            Me.btnPco_Cancel.TabIndex = 33
            Me.btnPco_Cancel.Text = "Cancel"
            '
            'cmbPco_Name
            '
            Me.cmbPco_Name.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbPco_Name.Location = New System.Drawing.Point(120, 48)
            Me.cmbPco_Name.Name = "cmbPco_Name"
            Me.cmbPco_Name.Size = New System.Drawing.Size(208, 21)
            Me.cmbPco_Name.TabIndex = 1
            Me.cmbPco_Name.TabStop = False
            '
            'Label6
            '
            Me.Label6.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label6.BackColor = System.Drawing.Color.Gold
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(1, 32)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(688, 4)
            Me.Label6.TabIndex = 32
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(24, 152)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 24)
            Me.Label4.TabIndex = 31
            Me.Label4.Text = "PSS Warranty Labor:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPco_New
            '
            Me.btnPco_New.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPco_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPco_New.ForeColor = System.Drawing.Color.White
            Me.btnPco_New.Location = New System.Drawing.Point(32, 8)
            Me.btnPco_New.Name = "btnPco_New"
            Me.btnPco_New.Size = New System.Drawing.Size(72, 20)
            Me.btnPco_New.TabIndex = 33
            Me.btnPco_New.Text = "New"
            '
            'tpgCustomer
            '
            Me.tpgCustomer.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCust_PayID, Me.Label23, Me.Label22, Me.GroupBox1, Me.cmbCust_Product, Me.Label18, Me.txtCust_Memo, Me.btnCust_New, Me.Label32, Me.cmbCust_Pco, Me.btnCust_AddUpdate, Me.Label34, Me.btnCust_Cancel, Me.lblCust_LName_New, Me.cmbCust_CrAppShip, Me.Label33, Me.lblCust_FName_New, Me.chkCust_Inactive, Me.Label10, Me.cmbCust_CrAppRec, Me.Label8, Me.Label31, Me.Label30, Me.cmbCust_LName, Me.cmbCust_SalePerson, Me.Label27, Me.Label7, Me.Label9, Me.cmbCust_InvoiceDetail, Me.Label12, Me.cmbCust_FName, Me.cmbCust_RepLCD, Me.GroupBox4, Me.Label11, Me.cmbCust_RepNonWrty, Me.cmbCust_CollSalesTax, Me.Label63, Me.cmbCust_PlusParts})
            Me.tpgCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tpgCustomer.ForeColor = System.Drawing.SystemColors.ControlText
            Me.tpgCustomer.Location = New System.Drawing.Point(4, 22)
            Me.tpgCustomer.Name = "tpgCustomer"
            Me.tpgCustomer.Size = New System.Drawing.Size(691, 482)
            Me.tpgCustomer.TabIndex = 0
            Me.tpgCustomer.Text = "Customer"
            '
            'cmbCust_PayID
            '
            Me.cmbCust_PayID.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbCust_PayID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_PayID.Location = New System.Drawing.Point(80, 96)
            Me.cmbCust_PayID.Name = "cmbCust_PayID"
            Me.cmbCust_PayID.Size = New System.Drawing.Size(224, 22)
            Me.cmbCust_PayID.TabIndex = 85
            Me.cmbCust_PayID.TabStop = False
            '
            'Label23
            '
            Me.Label23.BackColor = System.Drawing.Color.Transparent
            Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Black
            Me.Label23.Location = New System.Drawing.Point(8, 96)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(72, 16)
            Me.Label23.TabIndex = 86
            Me.Label23.Text = "Pay ID:"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label22
            '
            Me.Label22.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label22.BackColor = System.Drawing.Color.Salmon
            Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.White
            Me.Label22.Location = New System.Drawing.Point(3, 216)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(685, 2)
            Me.Label22.TabIndex = 84
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCust_WrtyLabor, Me.cmbCust_WrtyParts, Me.txtCust_DaysInWrty, Me.Label19, Me.Label20, Me.Label21})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
            Me.GroupBox1.Location = New System.Drawing.Point(368, 264)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(312, 144)
            Me.GroupBox1.TabIndex = 83
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Warranty"
            '
            'cmbCust_WrtyLabor
            '
            Me.cmbCust_WrtyLabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_WrtyLabor.Location = New System.Drawing.Point(112, 64)
            Me.cmbCust_WrtyLabor.Name = "cmbCust_WrtyLabor"
            Me.cmbCust_WrtyLabor.Size = New System.Drawing.Size(168, 21)
            Me.cmbCust_WrtyLabor.TabIndex = 61
            '
            'cmbCust_WrtyParts
            '
            Me.cmbCust_WrtyParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_WrtyParts.Location = New System.Drawing.Point(112, 40)
            Me.cmbCust_WrtyParts.Name = "cmbCust_WrtyParts"
            Me.cmbCust_WrtyParts.Size = New System.Drawing.Size(168, 21)
            Me.cmbCust_WrtyParts.TabIndex = 60
            '
            'txtCust_DaysInWrty
            '
            Me.txtCust_DaysInWrty.Location = New System.Drawing.Point(112, 16)
            Me.txtCust_DaysInWrty.Name = "txtCust_DaysInWrty"
            Me.txtCust_DaysInWrty.Size = New System.Drawing.Size(56, 20)
            Me.txtCust_DaysInWrty.TabIndex = 59
            Me.txtCust_DaysInWrty.Text = ""
            '
            'Label19
            '
            Me.Label19.ForeColor = System.Drawing.Color.Black
            Me.Label19.Location = New System.Drawing.Point(16, 64)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(96, 16)
            Me.Label19.TabIndex = 64
            Me.Label19.Text = "Warranty Labor:"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label20
            '
            Me.Label20.ForeColor = System.Drawing.Color.Black
            Me.Label20.Location = New System.Drawing.Point(16, 40)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(96, 16)
            Me.Label20.TabIndex = 63
            Me.Label20.Text = "Warranty Parts:"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label21
            '
            Me.Label21.ForeColor = System.Drawing.Color.Black
            Me.Label21.Location = New System.Drawing.Point(8, 16)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(104, 16)
            Me.Label21.TabIndex = 62
            Me.Label21.Text = "Days In Warranty:"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_Product
            '
            Me.cmbCust_Product.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbCust_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_Product.Location = New System.Drawing.Point(85, 232)
            Me.cmbCust_Product.Name = "cmbCust_Product"
            Me.cmbCust_Product.Size = New System.Drawing.Size(243, 22)
            Me.cmbCust_Product.TabIndex = 82
            Me.cmbCust_Product.TabStop = False
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.Black
            Me.Label18.Location = New System.Drawing.Point(13, 232)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(67, 16)
            Me.Label18.TabIndex = 81
            Me.Label18.Text = "Product:"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCust_Memo
            '
            Me.txtCust_Memo.Location = New System.Drawing.Point(80, 168)
            Me.txtCust_Memo.MaxLength = 90
            Me.txtCust_Memo.Name = "txtCust_Memo"
            Me.txtCust_Memo.Size = New System.Drawing.Size(568, 20)
            Me.txtCust_Memo.TabIndex = 80
            Me.txtCust_Memo.Text = ""
            '
            'btnCust_New
            '
            Me.btnCust_New.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCust_New.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCust_New.ForeColor = System.Drawing.Color.White
            Me.btnCust_New.Location = New System.Drawing.Point(32, 8)
            Me.btnCust_New.Name = "btnCust_New"
            Me.btnCust_New.Size = New System.Drawing.Size(72, 20)
            Me.btnCust_New.TabIndex = 35
            Me.btnCust_New.Text = "New"
            '
            'Label32
            '
            Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label32.ForeColor = System.Drawing.Color.Black
            Me.Label32.Location = New System.Drawing.Point(360, 112)
            Me.Label32.Name = "Label32"
            Me.Label32.Size = New System.Drawing.Size(88, 24)
            Me.Label32.TabIndex = 72
            Me.Label32.Text = "Credit Approve Receive:"
            Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_Pco
            '
            Me.cmbCust_Pco.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbCust_Pco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_Pco.Location = New System.Drawing.Point(80, 120)
            Me.cmbCust_Pco.Name = "cmbCust_Pco"
            Me.cmbCust_Pco.Size = New System.Drawing.Size(224, 22)
            Me.cmbCust_Pco.TabIndex = 44
            Me.cmbCust_Pco.TabStop = False
            '
            'btnCust_AddUpdate
            '
            Me.btnCust_AddUpdate.BackColor = System.Drawing.Color.Green
            Me.btnCust_AddUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCust_AddUpdate.ForeColor = System.Drawing.Color.White
            Me.btnCust_AddUpdate.Location = New System.Drawing.Point(240, 8)
            Me.btnCust_AddUpdate.Name = "btnCust_AddUpdate"
            Me.btnCust_AddUpdate.Size = New System.Drawing.Size(88, 20)
            Me.btnCust_AddUpdate.TabIndex = 34
            Me.btnCust_AddUpdate.Text = "Add/Update"
            '
            'Label34
            '
            Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label34.ForeColor = System.Drawing.Color.Black
            Me.Label34.Location = New System.Drawing.Point(512, 64)
            Me.Label34.Name = "Label34"
            Me.Label34.Size = New System.Drawing.Size(112, 19)
            Me.Label34.TabIndex = 74
            Me.Label34.Text = "Collect Sales Tax:"
            Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCust_Cancel
            '
            Me.btnCust_Cancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCust_Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCust_Cancel.ForeColor = System.Drawing.Color.White
            Me.btnCust_Cancel.Location = New System.Drawing.Point(136, 8)
            Me.btnCust_Cancel.Name = "btnCust_Cancel"
            Me.btnCust_Cancel.Size = New System.Drawing.Size(72, 20)
            Me.btnCust_Cancel.TabIndex = 37
            Me.btnCust_Cancel.Text = "Cancel"
            '
            'lblCust_LName_New
            '
            Me.lblCust_LName_New.BackColor = System.Drawing.Color.Transparent
            Me.lblCust_LName_New.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCust_LName_New.ForeColor = System.Drawing.Color.White
            Me.lblCust_LName_New.Location = New System.Drawing.Point(80, 70)
            Me.lblCust_LName_New.Name = "lblCust_LName_New"
            Me.lblCust_LName_New.Size = New System.Drawing.Size(222, 16)
            Me.lblCust_LName_New.TabIndex = 43
            Me.lblCust_LName_New.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCust_LName_New.Visible = False
            '
            'cmbCust_CrAppShip
            '
            Me.cmbCust_CrAppShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_CrAppShip.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_CrAppShip.Location = New System.Drawing.Point(624, 40)
            Me.cmbCust_CrAppShip.Name = "cmbCust_CrAppShip"
            Me.cmbCust_CrAppShip.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_CrAppShip.TabIndex = 66
            '
            'Label33
            '
            Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label33.ForeColor = System.Drawing.Color.Black
            Me.Label33.Location = New System.Drawing.Point(504, 48)
            Me.Label33.Name = "Label33"
            Me.Label33.Size = New System.Drawing.Size(120, 12)
            Me.Label33.TabIndex = 73
            Me.Label33.Text = "Credit Approve Ship:"
            Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCust_FName_New
            '
            Me.lblCust_FName_New.BackColor = System.Drawing.Color.Transparent
            Me.lblCust_FName_New.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCust_FName_New.ForeColor = System.Drawing.Color.White
            Me.lblCust_FName_New.Location = New System.Drawing.Point(80, 47)
            Me.lblCust_FName_New.Name = "lblCust_FName_New"
            Me.lblCust_FName_New.Size = New System.Drawing.Size(222, 16)
            Me.lblCust_FName_New.TabIndex = 42
            Me.lblCust_FName_New.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblCust_FName_New.Visible = False
            '
            'chkCust_Inactive
            '
            Me.chkCust_Inactive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCust_Inactive.ForeColor = System.Drawing.Color.Black
            Me.chkCust_Inactive.Location = New System.Drawing.Point(576, 120)
            Me.chkCust_Inactive.Name = "chkCust_Inactive"
            Me.chkCust_Inactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkCust_Inactive.Size = New System.Drawing.Size(96, 14)
            Me.chkCust_Inactive.TabIndex = 76
            Me.chkCust_Inactive.Text = "Inactive"
            Me.chkCust_Inactive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(8, 112)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(72, 32)
            Me.Label10.TabIndex = 45
            Me.Label10.Text = "Parent Company:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_CrAppRec
            '
            Me.cmbCust_CrAppRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_CrAppRec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_CrAppRec.Location = New System.Drawing.Point(448, 112)
            Me.cmbCust_CrAppRec.Name = "cmbCust_CrAppRec"
            Me.cmbCust_CrAppRec.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_CrAppRec.TabIndex = 65
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(8, 70)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(72, 16)
            Me.Label8.TabIndex = 41
            Me.Label8.Text = "Last Name:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label31
            '
            Me.Label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label31.ForeColor = System.Drawing.Color.Black
            Me.Label31.Location = New System.Drawing.Point(368, 96)
            Me.Label31.Name = "Label31"
            Me.Label31.Size = New System.Drawing.Size(80, 16)
            Me.Label31.TabIndex = 71
            Me.Label31.Text = "Replace LCD:"
            Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label30
            '
            Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label30.ForeColor = System.Drawing.Color.Black
            Me.Label30.Location = New System.Drawing.Point(368, 64)
            Me.Label30.Name = "Label30"
            Me.Label30.Size = New System.Drawing.Size(77, 24)
            Me.Label30.TabIndex = 70
            Me.Label30.Text = "Repair Non-Warranty:"
            Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_LName
            '
            Me.cmbCust_LName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbCust_LName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_LName.Location = New System.Drawing.Point(80, 67)
            Me.cmbCust_LName.Name = "cmbCust_LName"
            Me.cmbCust_LName.Size = New System.Drawing.Size(224, 22)
            Me.cmbCust_LName.TabIndex = 40
            Me.cmbCust_LName.TabStop = False
            '
            'cmbCust_SalePerson
            '
            Me.cmbCust_SalePerson.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbCust_SalePerson.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_SalePerson.Location = New System.Drawing.Point(80, 144)
            Me.cmbCust_SalePerson.Name = "cmbCust_SalePerson"
            Me.cmbCust_SalePerson.Size = New System.Drawing.Size(224, 22)
            Me.cmbCust_SalePerson.TabIndex = 46
            Me.cmbCust_SalePerson.TabStop = False
            '
            'Label27
            '
            Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label27.ForeColor = System.Drawing.Color.Black
            Me.Label27.Location = New System.Drawing.Point(384, 40)
            Me.Label27.Name = "Label27"
            Me.Label27.Size = New System.Drawing.Size(64, 16)
            Me.Label27.TabIndex = 69
            Me.Label27.Text = "Plus Parts:"
            Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label7.BackColor = System.Drawing.Color.Gold
            Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(2, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(686, 4)
            Me.Label7.TabIndex = 36
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(8, 47)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 16)
            Me.Label9.TabIndex = 39
            Me.Label9.Text = "First Name:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_InvoiceDetail
            '
            Me.cmbCust_InvoiceDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_InvoiceDetail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_InvoiceDetail.Location = New System.Drawing.Point(624, 88)
            Me.cmbCust_InvoiceDetail.Name = "cmbCust_InvoiceDetail"
            Me.cmbCust_InvoiceDetail.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_InvoiceDetail.TabIndex = 68
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(8, 168)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(64, 8)
            Me.Label12.TabIndex = 78
            Me.Label12.Text = "Memo:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_FName
            '
            Me.cmbCust_FName.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.cmbCust_FName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_FName.Location = New System.Drawing.Point(80, 43)
            Me.cmbCust_FName.Name = "cmbCust_FName"
            Me.cmbCust_FName.Size = New System.Drawing.Size(224, 22)
            Me.cmbCust_FName.TabIndex = 38
            Me.cmbCust_FName.TabStop = False
            '
            'cmbCust_RepLCD
            '
            Me.cmbCust_RepLCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_RepLCD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_RepLCD.Location = New System.Drawing.Point(448, 88)
            Me.cmbCust_RepLCD.Name = "cmbCust_RepLCD"
            Me.cmbCust_RepLCD.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_RepLCD.TabIndex = 64
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCust_MarkUpRTM, Me.Label71, Me.txtCust_MarkupNTF, Me.Label67, Me.cmbCust_MarkUpPlusparts, Me.lblCMplusParts, Me.txtCust_MarkupInvt, Me.Label13, Me.cmbCust_MarkUpInvMthdID, Me.txtCust_MarkUpCust, Me.txtCust_MarkUpNER, Me.txtCust_MarkUpRUR, Me.Label15, Me.Label14, Me.Label16, Me.Label17})
            Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
            Me.GroupBox4.Location = New System.Drawing.Point(16, 264)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(312, 144)
            Me.GroupBox4.TabIndex = 79
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Markups"
            '
            'txtCust_MarkUpRTM
            '
            Me.txtCust_MarkUpRTM.ForeColor = System.Drawing.Color.Black
            Me.txtCust_MarkUpRTM.Location = New System.Drawing.Point(72, 88)
            Me.txtCust_MarkUpRTM.Name = "txtCust_MarkUpRTM"
            Me.txtCust_MarkUpRTM.Size = New System.Drawing.Size(64, 20)
            Me.txtCust_MarkUpRTM.TabIndex = 6
            Me.txtCust_MarkUpRTM.Text = ""
            '
            'Label71
            '
            Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label71.ForeColor = System.Drawing.Color.Black
            Me.Label71.Location = New System.Drawing.Point(32, 88)
            Me.Label71.Name = "Label71"
            Me.Label71.Size = New System.Drawing.Size(40, 16)
            Me.Label71.TabIndex = 62
            Me.Label71.Text = "RTM:"
            Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtCust_MarkupNTF
            '
            Me.txtCust_MarkupNTF.ForeColor = System.Drawing.Color.Black
            Me.txtCust_MarkupNTF.Location = New System.Drawing.Point(72, 40)
            Me.txtCust_MarkupNTF.Name = "txtCust_MarkupNTF"
            Me.txtCust_MarkupNTF.Size = New System.Drawing.Size(64, 20)
            Me.txtCust_MarkupNTF.TabIndex = 4
            Me.txtCust_MarkupNTF.Text = ""
            '
            'Label67
            '
            Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label67.ForeColor = System.Drawing.Color.Black
            Me.Label67.Location = New System.Drawing.Point(32, 40)
            Me.Label67.Name = "Label67"
            Me.Label67.Size = New System.Drawing.Size(38, 16)
            Me.Label67.TabIndex = 61
            Me.Label67.Text = "NTF:"
            Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_MarkUpPlusparts
            '
            Me.cmbCust_MarkUpPlusparts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_MarkUpPlusparts.ForeColor = System.Drawing.Color.Black
            Me.cmbCust_MarkUpPlusparts.Location = New System.Drawing.Point(224, 88)
            Me.cmbCust_MarkUpPlusparts.Name = "cmbCust_MarkUpPlusparts"
            Me.cmbCust_MarkUpPlusparts.Size = New System.Drawing.Size(64, 21)
            Me.cmbCust_MarkUpPlusparts.TabIndex = 10
            '
            'lblCMplusParts
            '
            Me.lblCMplusParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCMplusParts.ForeColor = System.Drawing.Color.Black
            Me.lblCMplusParts.Location = New System.Drawing.Point(160, 88)
            Me.lblCMplusParts.Name = "lblCMplusParts"
            Me.lblCMplusParts.Size = New System.Drawing.Size(64, 16)
            Me.lblCMplusParts.TabIndex = 59
            Me.lblCMplusParts.Text = "Plus Parts:"
            Me.lblCMplusParts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCust_MarkupInvt
            '
            Me.txtCust_MarkupInvt.ForeColor = System.Drawing.Color.Black
            Me.txtCust_MarkupInvt.Location = New System.Drawing.Point(224, 64)
            Me.txtCust_MarkupInvt.Name = "txtCust_MarkupInvt"
            Me.txtCust_MarkupInvt.Size = New System.Drawing.Size(64, 20)
            Me.txtCust_MarkupInvt.TabIndex = 8
            Me.txtCust_MarkupInvt.Text = ""
            '
            'Label13
            '
            Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.Black
            Me.Label13.Location = New System.Drawing.Point(160, 64)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(56, 16)
            Me.Label13.TabIndex = 57
            Me.Label13.Text = "Inventory:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_MarkUpInvMthdID
            '
            Me.cmbCust_MarkUpInvMthdID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_MarkUpInvMthdID.ForeColor = System.Drawing.Color.Black
            Me.cmbCust_MarkUpInvMthdID.Location = New System.Drawing.Point(72, 112)
            Me.cmbCust_MarkUpInvMthdID.Name = "cmbCust_MarkUpInvMthdID"
            Me.cmbCust_MarkUpInvMthdID.Size = New System.Drawing.Size(216, 21)
            Me.cmbCust_MarkUpInvMthdID.TabIndex = 9
            '
            'txtCust_MarkUpCust
            '
            Me.txtCust_MarkUpCust.ForeColor = System.Drawing.Color.Black
            Me.txtCust_MarkUpCust.Location = New System.Drawing.Point(224, 40)
            Me.txtCust_MarkUpCust.Name = "txtCust_MarkUpCust"
            Me.txtCust_MarkUpCust.Size = New System.Drawing.Size(64, 20)
            Me.txtCust_MarkUpCust.TabIndex = 7
            Me.txtCust_MarkUpCust.Text = ""
            '
            'txtCust_MarkUpNER
            '
            Me.txtCust_MarkUpNER.ForeColor = System.Drawing.Color.Black
            Me.txtCust_MarkUpNER.Location = New System.Drawing.Point(72, 64)
            Me.txtCust_MarkUpNER.Name = "txtCust_MarkUpNER"
            Me.txtCust_MarkUpNER.Size = New System.Drawing.Size(64, 20)
            Me.txtCust_MarkUpNER.TabIndex = 5
            Me.txtCust_MarkUpNER.Text = ""
            '
            'txtCust_MarkUpRUR
            '
            Me.txtCust_MarkUpRUR.ForeColor = System.Drawing.Color.Black
            Me.txtCust_MarkUpRUR.Location = New System.Drawing.Point(72, 16)
            Me.txtCust_MarkUpRUR.Name = "txtCust_MarkUpRUR"
            Me.txtCust_MarkUpRUR.Size = New System.Drawing.Size(64, 20)
            Me.txtCust_MarkUpRUR.TabIndex = 3
            Me.txtCust_MarkUpRUR.Text = ""
            '
            'Label15
            '
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Black
            Me.Label15.Location = New System.Drawing.Point(16, 104)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(56, 32)
            Me.Label15.TabIndex = 12
            Me.Label15.Text = "Inventory Method:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Black
            Me.Label14.Location = New System.Drawing.Point(160, 40)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(58, 16)
            Me.Label14.TabIndex = 11
            Me.Label14.Text = "Customer:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Black
            Me.Label16.Location = New System.Drawing.Point(32, 64)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(40, 16)
            Me.Label16.TabIndex = 10
            Me.Label16.Text = "NER:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label17
            '
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.Black
            Me.Label17.Location = New System.Drawing.Point(32, 16)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(38, 16)
            Me.Label17.TabIndex = 9
            Me.Label17.Text = "RUR:"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(0, 144)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 16)
            Me.Label11.TabIndex = 47
            Me.Label11.Text = "Sale Person:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_RepNonWrty
            '
            Me.cmbCust_RepNonWrty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_RepNonWrty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_RepNonWrty.Location = New System.Drawing.Point(448, 64)
            Me.cmbCust_RepNonWrty.Name = "cmbCust_RepNonWrty"
            Me.cmbCust_RepNonWrty.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_RepNonWrty.TabIndex = 63
            '
            'cmbCust_CollSalesTax
            '
            Me.cmbCust_CollSalesTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_CollSalesTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_CollSalesTax.Location = New System.Drawing.Point(624, 64)
            Me.cmbCust_CollSalesTax.Name = "cmbCust_CollSalesTax"
            Me.cmbCust_CollSalesTax.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_CollSalesTax.TabIndex = 67
            '
            'Label63
            '
            Me.Label63.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label63.ForeColor = System.Drawing.Color.Black
            Me.Label63.Location = New System.Drawing.Point(536, 96)
            Me.Label63.Name = "Label63"
            Me.Label63.Size = New System.Drawing.Size(88, 16)
            Me.Label63.TabIndex = 75
            Me.Label63.Text = "Invoice Detail:"
            Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCust_PlusParts
            '
            Me.cmbCust_PlusParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCust_PlusParts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCust_PlusParts.Location = New System.Drawing.Point(448, 40)
            Me.cmbCust_PlusParts.Name = "cmbCust_PlusParts"
            Me.cmbCust_PlusParts.Size = New System.Drawing.Size(48, 22)
            Me.cmbCust_PlusParts.TabIndex = 62
            '
            'tpgLoc
            '
            Me.tpgLoc.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgLoc.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLoc_Cancel, Me.btnLoc_New, Me.btnLoc_AddUpdate, Me.lstLoc_Location, Me.cmbLoc_Customer, Me.txtLoc_ShippingMemo, Me.txtLoc_Memo, Me.cmbLoc_ManifestDetail, Me.cmbLoc_AfterMarket, Me.cmbLoc_Country, Me.cmbLoc_State, Me.txtLoc_Email, Me.txtLoc_Fax, Me.txtLoc_Phone, Me.txtLoc_Contact, Me.txtLoc_Zip, Me.txtLoc_City, Me.txtLoc_Address2, Me.txtLoc_Address1, Me.txtLoc_Name, Me.Label53, Me.Label52, Me.Label51, Me.Label50, Me.Label49, Me.Label48, Me.Label47, Me.Label46, Me.Label45, Me.Label44, Me.Label43, Me.Label42, Me.Label41, Me.Label40, Me.Label39, Me.Label38, Me.Label62})
            Me.tpgLoc.Location = New System.Drawing.Point(4, 22)
            Me.tpgLoc.Name = "tpgLoc"
            Me.tpgLoc.Size = New System.Drawing.Size(691, 482)
            Me.tpgLoc.TabIndex = 2
            Me.tpgLoc.Text = "Location"
            '
            'btnLoc_Cancel
            '
            Me.btnLoc_Cancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnLoc_Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoc_Cancel.ForeColor = System.Drawing.Color.White
            Me.btnLoc_Cancel.Location = New System.Drawing.Point(144, 8)
            Me.btnLoc_Cancel.Name = "btnLoc_Cancel"
            Me.btnLoc_Cancel.Size = New System.Drawing.Size(80, 20)
            Me.btnLoc_Cancel.TabIndex = 137
            Me.btnLoc_Cancel.Text = "Cancel"
            '
            'btnLoc_New
            '
            Me.btnLoc_New.BackColor = System.Drawing.Color.SteelBlue
            Me.btnLoc_New.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoc_New.ForeColor = System.Drawing.Color.White
            Me.btnLoc_New.Location = New System.Drawing.Point(32, 8)
            Me.btnLoc_New.Name = "btnLoc_New"
            Me.btnLoc_New.Size = New System.Drawing.Size(80, 20)
            Me.btnLoc_New.TabIndex = 136
            Me.btnLoc_New.Text = "New"
            '
            'btnLoc_AddUpdate
            '
            Me.btnLoc_AddUpdate.BackColor = System.Drawing.Color.Green
            Me.btnLoc_AddUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoc_AddUpdate.ForeColor = System.Drawing.Color.White
            Me.btnLoc_AddUpdate.Location = New System.Drawing.Point(256, 8)
            Me.btnLoc_AddUpdate.Name = "btnLoc_AddUpdate"
            Me.btnLoc_AddUpdate.Size = New System.Drawing.Size(80, 20)
            Me.btnLoc_AddUpdate.TabIndex = 135
            Me.btnLoc_AddUpdate.Text = "Add/Update"
            '
            'lstLoc_Location
            '
            Me.lstLoc_Location.Location = New System.Drawing.Point(16, 48)
            Me.lstLoc_Location.Name = "lstLoc_Location"
            Me.lstLoc_Location.Size = New System.Drawing.Size(88, 238)
            Me.lstLoc_Location.TabIndex = 17
            Me.lstLoc_Location.TabStop = False
            '
            'cmbLoc_Customer
            '
            Me.cmbLoc_Customer.Location = New System.Drawing.Point(208, 48)
            Me.cmbLoc_Customer.Name = "cmbLoc_Customer"
            Me.cmbLoc_Customer.Size = New System.Drawing.Size(272, 21)
            Me.cmbLoc_Customer.TabIndex = 1
            '
            'txtLoc_ShippingMemo
            '
            Me.txtLoc_ShippingMemo.Location = New System.Drawing.Point(496, 216)
            Me.txtLoc_ShippingMemo.Multiline = True
            Me.txtLoc_ShippingMemo.Name = "txtLoc_ShippingMemo"
            Me.txtLoc_ShippingMemo.Size = New System.Drawing.Size(160, 72)
            Me.txtLoc_ShippingMemo.TabIndex = 16
            Me.txtLoc_ShippingMemo.Text = ""
            '
            'txtLoc_Memo
            '
            Me.txtLoc_Memo.Location = New System.Drawing.Point(496, 96)
            Me.txtLoc_Memo.Multiline = True
            Me.txtLoc_Memo.Name = "txtLoc_Memo"
            Me.txtLoc_Memo.Size = New System.Drawing.Size(160, 72)
            Me.txtLoc_Memo.TabIndex = 15
            Me.txtLoc_Memo.Text = ""
            '
            'cmbLoc_ManifestDetail
            '
            Me.cmbLoc_ManifestDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbLoc_ManifestDetail.Location = New System.Drawing.Point(432, 248)
            Me.cmbLoc_ManifestDetail.Name = "cmbLoc_ManifestDetail"
            Me.cmbLoc_ManifestDetail.Size = New System.Drawing.Size(48, 21)
            Me.cmbLoc_ManifestDetail.TabIndex = 13
            '
            'cmbLoc_AfterMarket
            '
            Me.cmbLoc_AfterMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbLoc_AfterMarket.Location = New System.Drawing.Point(432, 224)
            Me.cmbLoc_AfterMarket.Name = "cmbLoc_AfterMarket"
            Me.cmbLoc_AfterMarket.Size = New System.Drawing.Size(48, 21)
            Me.cmbLoc_AfterMarket.TabIndex = 12
            '
            'cmbLoc_Country
            '
            Me.cmbLoc_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbLoc_Country.Location = New System.Drawing.Point(208, 176)
            Me.cmbLoc_Country.Name = "cmbLoc_Country"
            Me.cmbLoc_Country.Size = New System.Drawing.Size(272, 21)
            Me.cmbLoc_Country.TabIndex = 8
            '
            'cmbLoc_State
            '
            Me.cmbLoc_State.Location = New System.Drawing.Point(344, 152)
            Me.cmbLoc_State.Name = "cmbLoc_State"
            Me.cmbLoc_State.Size = New System.Drawing.Size(48, 21)
            Me.cmbLoc_State.TabIndex = 6
            '
            'txtLoc_Email
            '
            Me.txtLoc_Email.Location = New System.Drawing.Point(208, 272)
            Me.txtLoc_Email.Name = "txtLoc_Email"
            Me.txtLoc_Email.Size = New System.Drawing.Size(272, 20)
            Me.txtLoc_Email.TabIndex = 14
            Me.txtLoc_Email.Text = ""
            '
            'txtLoc_Fax
            '
            Me.txtLoc_Fax.Location = New System.Drawing.Point(208, 248)
            Me.txtLoc_Fax.Name = "txtLoc_Fax"
            Me.txtLoc_Fax.Size = New System.Drawing.Size(120, 20)
            Me.txtLoc_Fax.TabIndex = 11
            Me.txtLoc_Fax.Text = ""
            '
            'txtLoc_Phone
            '
            Me.txtLoc_Phone.Location = New System.Drawing.Point(208, 224)
            Me.txtLoc_Phone.Name = "txtLoc_Phone"
            Me.txtLoc_Phone.Size = New System.Drawing.Size(120, 20)
            Me.txtLoc_Phone.TabIndex = 10
            Me.txtLoc_Phone.Text = ""
            '
            'txtLoc_Contact
            '
            Me.txtLoc_Contact.Location = New System.Drawing.Point(208, 200)
            Me.txtLoc_Contact.Name = "txtLoc_Contact"
            Me.txtLoc_Contact.Size = New System.Drawing.Size(272, 20)
            Me.txtLoc_Contact.TabIndex = 9
            Me.txtLoc_Contact.Text = ""
            '
            'txtLoc_Zip
            '
            Me.txtLoc_Zip.Location = New System.Drawing.Point(416, 152)
            Me.txtLoc_Zip.Name = "txtLoc_Zip"
            Me.txtLoc_Zip.Size = New System.Drawing.Size(62, 20)
            Me.txtLoc_Zip.TabIndex = 7
            Me.txtLoc_Zip.Text = ""
            '
            'txtLoc_City
            '
            Me.txtLoc_City.Location = New System.Drawing.Point(208, 152)
            Me.txtLoc_City.Name = "txtLoc_City"
            Me.txtLoc_City.Size = New System.Drawing.Size(96, 20)
            Me.txtLoc_City.TabIndex = 5
            Me.txtLoc_City.Text = ""
            '
            'txtLoc_Address2
            '
            Me.txtLoc_Address2.Location = New System.Drawing.Point(208, 128)
            Me.txtLoc_Address2.Name = "txtLoc_Address2"
            Me.txtLoc_Address2.Size = New System.Drawing.Size(272, 20)
            Me.txtLoc_Address2.TabIndex = 4
            Me.txtLoc_Address2.Text = ""
            '
            'txtLoc_Address1
            '
            Me.txtLoc_Address1.Location = New System.Drawing.Point(208, 104)
            Me.txtLoc_Address1.Name = "txtLoc_Address1"
            Me.txtLoc_Address1.Size = New System.Drawing.Size(272, 20)
            Me.txtLoc_Address1.TabIndex = 3
            Me.txtLoc_Address1.Text = ""
            '
            'txtLoc_Name
            '
            Me.txtLoc_Name.Location = New System.Drawing.Point(208, 80)
            Me.txtLoc_Name.Name = "txtLoc_Name"
            Me.txtLoc_Name.Size = New System.Drawing.Size(272, 20)
            Me.txtLoc_Name.TabIndex = 2
            Me.txtLoc_Name.Text = ""
            '
            'Label53
            '
            Me.Label53.BackColor = System.Drawing.Color.Transparent
            Me.Label53.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label53.ForeColor = System.Drawing.Color.Black
            Me.Label53.Location = New System.Drawing.Point(120, 50)
            Me.Label53.Name = "Label53"
            Me.Label53.Size = New System.Drawing.Size(80, 16)
            Me.Label53.TabIndex = 132
            Me.Label53.Text = "Customer:"
            Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label52
            '
            Me.Label52.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label52.Location = New System.Drawing.Point(496, 200)
            Me.Label52.Name = "Label52"
            Me.Label52.Size = New System.Drawing.Size(112, 16)
            Me.Label52.TabIndex = 131
            Me.Label52.Text = "Shipping Memo:"
            Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label51
            '
            Me.Label51.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label51.Location = New System.Drawing.Point(496, 80)
            Me.Label51.Name = "Label51"
            Me.Label51.Size = New System.Drawing.Size(48, 16)
            Me.Label51.TabIndex = 130
            Me.Label51.Text = "Memo:"
            Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label50
            '
            Me.Label50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label50.Location = New System.Drawing.Point(344, 248)
            Me.Label50.Name = "Label50"
            Me.Label50.Size = New System.Drawing.Size(88, 16)
            Me.Label50.TabIndex = 129
            Me.Label50.Text = "Manifest Detail:"
            Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label49
            '
            Me.Label49.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label49.Location = New System.Drawing.Point(344, 224)
            Me.Label49.Name = "Label49"
            Me.Label49.Size = New System.Drawing.Size(80, 16)
            Me.Label49.TabIndex = 128
            Me.Label49.Text = "After Market:"
            Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label48
            '
            Me.Label48.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label48.Location = New System.Drawing.Point(120, 272)
            Me.Label48.Name = "Label48"
            Me.Label48.Size = New System.Drawing.Size(80, 16)
            Me.Label48.TabIndex = 127
            Me.Label48.Text = "E-Mail:"
            Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label47
            '
            Me.Label47.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label47.Location = New System.Drawing.Point(120, 248)
            Me.Label47.Name = "Label47"
            Me.Label47.Size = New System.Drawing.Size(80, 16)
            Me.Label47.TabIndex = 126
            Me.Label47.Text = "Fax:"
            Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label46
            '
            Me.Label46.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label46.Location = New System.Drawing.Point(120, 224)
            Me.Label46.Name = "Label46"
            Me.Label46.Size = New System.Drawing.Size(80, 16)
            Me.Label46.TabIndex = 125
            Me.Label46.Text = "Phone:"
            Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label45
            '
            Me.Label45.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label45.Location = New System.Drawing.Point(120, 200)
            Me.Label45.Name = "Label45"
            Me.Label45.Size = New System.Drawing.Size(80, 16)
            Me.Label45.TabIndex = 124
            Me.Label45.Text = "Contact:"
            Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label44
            '
            Me.Label44.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label44.Location = New System.Drawing.Point(120, 176)
            Me.Label44.Name = "Label44"
            Me.Label44.Size = New System.Drawing.Size(80, 16)
            Me.Label44.TabIndex = 123
            Me.Label44.Text = "Country:"
            Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label43
            '
            Me.Label43.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label43.Location = New System.Drawing.Point(384, 152)
            Me.Label43.Name = "Label43"
            Me.Label43.Size = New System.Drawing.Size(32, 16)
            Me.Label43.TabIndex = 122
            Me.Label43.Text = "Zip:"
            Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label42
            '
            Me.Label42.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label42.Location = New System.Drawing.Point(304, 152)
            Me.Label42.Name = "Label42"
            Me.Label42.Size = New System.Drawing.Size(40, 16)
            Me.Label42.TabIndex = 121
            Me.Label42.Text = "State:"
            Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label41
            '
            Me.Label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label41.Location = New System.Drawing.Point(120, 152)
            Me.Label41.Name = "Label41"
            Me.Label41.Size = New System.Drawing.Size(80, 16)
            Me.Label41.TabIndex = 120
            Me.Label41.Text = "City:"
            Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label40
            '
            Me.Label40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label40.Location = New System.Drawing.Point(120, 128)
            Me.Label40.Name = "Label40"
            Me.Label40.Size = New System.Drawing.Size(80, 16)
            Me.Label40.TabIndex = 119
            Me.Label40.Text = "Address(2):"
            Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label39
            '
            Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label39.Location = New System.Drawing.Point(120, 104)
            Me.Label39.Name = "Label39"
            Me.Label39.Size = New System.Drawing.Size(80, 16)
            Me.Label39.TabIndex = 118
            Me.Label39.Text = "Address(1):"
            Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label38
            '
            Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label38.Location = New System.Drawing.Point(120, 80)
            Me.Label38.Name = "Label38"
            Me.Label38.Size = New System.Drawing.Size(80, 16)
            Me.Label38.TabIndex = 117
            Me.Label38.Text = "Account #:"
            Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label62
            '
            Me.Label62.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label62.BackColor = System.Drawing.Color.SteelBlue
            Me.Label62.Location = New System.Drawing.Point(0, 32)
            Me.Label62.Name = "Label62"
            Me.Label62.Size = New System.Drawing.Size(688, 4)
            Me.Label62.TabIndex = 134
            '
            'tpgPO
            '
            Me.tpgPO.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgPO.Location = New System.Drawing.Point(4, 22)
            Me.tpgPO.Name = "tpgPO"
            Me.tpgPO.Size = New System.Drawing.Size(691, 482)
            Me.tpgPO.TabIndex = 4
            Me.tpgPO.Text = "PO"
            '
            'tpgPricing
            '
            Me.tpgPricing.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgPricing.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPricingAdd, Me.grdDevice})
            Me.tpgPricing.Location = New System.Drawing.Point(4, 22)
            Me.tpgPricing.Name = "tpgPricing"
            Me.tpgPricing.Size = New System.Drawing.Size(691, 482)
            Me.tpgPricing.TabIndex = 1
            Me.tpgPricing.Text = "Pricing"
            '
            'btnPricingAdd
            '
            Me.btnPricingAdd.Location = New System.Drawing.Point(392, 432)
            Me.btnPricingAdd.Name = "btnPricingAdd"
            Me.btnPricingAdd.Size = New System.Drawing.Size(120, 32)
            Me.btnPricingAdd.TabIndex = 133
            Me.btnPricingAdd.Text = "Add New Pricing Group"
            '
            'grdDevice
            '
            Me.grdDevice.AllowAddNew = True
            Me.grdDevice.AllowColMove = False
            Me.grdDevice.AllowColSelect = False
            Me.grdDevice.AllowDelete = True
            Me.grdDevice.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.grdDevice.AlternatingRows = True
            Me.grdDevice.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grdDevice.BackColor = System.Drawing.Color.SteelBlue
            Me.grdDevice.FilterBar = True
            Me.grdDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdDevice.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdDevice.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdDevice.Location = New System.Drawing.Point(4, 8)
            Me.grdDevice.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdDevice.Name = "grdDevice"
            Me.grdDevice.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdDevice.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdDevice.PreviewInfo.ZoomFactor = 75
            Me.grdDevice.RowHeight = 20
            Me.grdDevice.Size = New System.Drawing.Size(683, 396)
            Me.grdDevice.TabIndex = 132
            Me.grdDevice.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:I" & _
            "nactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:" & _
            "Transparent;}Footer{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Microsoft San" & _
            "s Serif, 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:Highl" & _
            "ightText;BackColor:Highlight;}Style14{}OddRow{BackColor:Transparent;}RecordSelec" & _
            "tor{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.2" & _
            "5pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;BackColor:Bisque;}Style8{}Style10{AlignHorz:Near;}Style11{}Sty" & _
            "le12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HB" & _
            "arHeight=""10"" AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing" & _
            "=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
            "olumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSe" & _
            "lectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
            "up=""1""><Height>392</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
            "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
            "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
            ">0, 0, 679, 392</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Borde" & _
            "rStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me" & _
            "=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Fo" & _
            "oter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inact" & _
            "ive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor""" & _
            " /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow" & _
            """ /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelec" & _
            "tor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group" & _
            """ /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>No" & _
            "ne</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 679, 392" & _
            "</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyl" & _
            "e parent="""" me=""Style15"" /></Blob>"
            '
            'tpgCustToPrice
            '
            Me.tpgCustToPrice.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgCustToPrice.Location = New System.Drawing.Point(4, 22)
            Me.tpgCustToPrice.Name = "tpgCustToPrice"
            Me.tpgCustToPrice.Size = New System.Drawing.Size(691, 482)
            Me.tpgCustToPrice.TabIndex = 3
            Me.tpgCustToPrice.Text = "Customer to Price"
            '
            'frmCustmaintNew
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(728, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmCustmaintNew"
            Me.Text = "Customer Information"
            Me.TabControl1.ResumeLayout(False)
            Me.tpgPCo.ResumeLayout(False)
            Me.tpgCustomer.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.tpgLoc.ResumeLayout(False)
            Me.tpgPricing.ResumeLayout(False)
            CType(Me.grdDevice, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************
        Private Sub frmCustmaintNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt1 As DataTable

            Try
                'lparentco
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lparentco.ToString)
                Me._dtTablesArr(Me.TableName.lparentco) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.lparentco), "PCo_Name", Me.cmbPco_Name)
                PopulateCombo(_dtTablesArr(Me.TableName.lparentco), "PCo_Name", Me.cmbCust_PlusParts)

                'tcustomer
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tcustomer.ToString)
                Me._dtTablesArr(Me.TableName.tcustomer) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.tcustomer), "Cust_Name1", Me.cmbCust_FName)
                PopulateCombo(_dtTablesArr(Me.TableName.tcustomer), "Cust_Name2", Me.cmbCust_LName)

                'tlocation
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tlocation.ToString)
                Me._dtTablesArr(Me.TableName.tlocation) = dt1

                'tpurchaseorder
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tpurchaseorder.ToString)
                Me._dtTablesArr(Me.TableName.tpurchaseorder) = dt1

                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tlabprcgrp.ToString)
                Me._dtTablesArr(Me.TableName.tlabprcgrp) = dt1

                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lpricingtype.ToString)
                Me._dtTablesArr(Me.TableName.lpricingtype) = dt1

                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tcmlabmap.ToString)
                Me._dtTablesArr(Me.TableName.tcmlabmap) = dt1

                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tmodel.ToString)
                Me._dtTablesArr(Me.TableName.tmodel) = dt1

                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lbillcodes.ToString)
                Me._dtTablesArr(Me.TableName.lbillcodes) = dt1

                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tcmpartmap.ToString)
                Me._dtTablesArr(Me.TableName.tcmpartmap) = dt1

                'lpsswrtyparts
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lpsswrtyparts.ToString)
                Me._dtTablesArr(Me.TableName.lpsswrtyparts) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.lpsswrtyparts), "PSSWrtyParts_Desc", Me.cmbPco_PSSWrtyPart)
                PopulateCombo(_dtTablesArr(Me.TableName.lpsswrtyparts), "PSSWrtyParts_Desc", Me.cmbCust_WrtyParts)

                'lpsswrtylabor
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lpsswrtylabor.ToString)
                Me._dtTablesArr(Me.TableName.lpsswrtylabor) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.lpsswrtylabor), "PSSWrtyLabor_Desc", Me.cmbPco_PSSWrtyLabor)
                PopulateCombo(_dtTablesArr(Me.TableName.lpsswrtylabor), "PSSWrtyLabor_Desc", Me.cmbCust_WrtyLabor)

                'lpaymethod
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lpaymethod.ToString)
                Me._dtTablesArr(Me.TableName.lpaymethod) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.lpaymethod), "Pay_Desc", Me.cmbCust_PayID)

                'lstate
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lstate.ToString)
                Me._dtTablesArr(Me.TableName.lstate) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.lstate), "State_Short", Me.cmbLoc_State)

                'lcountry
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.lcountry.ToString)
                Me._dtTablesArr(Me.TableName.lcountry) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.lcountry), "Cntry_Name", Me.cmbLoc_Country)

                'tslsp
                dt1 = _objCustMaintNew.LoadAllDatatable(Me.TableName.tslsp.ToString)
                Me._dtTablesArr(Me.TableName.tslsp) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.tslsp), "SlsP_FirstName", Me.cmbCust_SalePerson)

                'YesNo
                dt1 = _objCustMaintNew.CreateYesNoTable()
                Me._dtTablesArr(Me.TableName.YesNo) = dt1
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_PlusParts)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_RepNonWrty)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_RepLCD)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_CrAppRec)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_CrAppShip)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_CollSalesTax)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbCust_InvoiceDetail)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbLoc_ManifestDetail)
                PopulateCombo(_dtTablesArr(Me.TableName.YesNo), "Desc", Me.cmbLoc_AfterMarket)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '****************************************************************
        Private Sub PopulateCombo(ByVal dtTable As DataTable,
                                  ByVal strColName As String,
                                  ByRef cmbCtrl As ComboBox)
            Dim R1 As DataRow

            Try
                cmbCtrl.Items.Clear()

                For Each R1 In dtTable.Rows
                    cmbCtrl.Items.Add(R1(strColName))
                Next R1

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '****************************************************************
        Private Sub tpgCustomer_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgCustomer.VisibleChanged
           
        End Sub

        '****************************************************************

        Private Sub tpgCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpgCustomer.Click

        End Sub

        Private Sub cmbLocAfterMarket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoc_AfterMarket.SelectedIndexChanged

        End Sub
    End Class
End Namespace


