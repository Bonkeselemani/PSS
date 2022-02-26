'Imports PSS.Data
'Imports PSS.Core
'Imports PSS.Rules
'Imports PSS.Core.Global
'Imports System.IO

'Namespace Gui.CustomerMaint

'    Public Class frmPreload_USAMobility
'        Inherits System.Windows.Forms.Form

'#Region " Windows Form Designer generated code "

'        Public Sub New()
'            MyBase.New()

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call




'        End Sub

'        'Form overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents lblWO As System.Windows.Forms.Label
'        Friend WithEvents cboWO As PSS.Gui.Controls.ComboBox
'        Friend WithEvents grpDDC As System.Windows.Forms.GroupBox
'        Friend WithEvents txtWOnumber As System.Windows.Forms.TextBox
'        Friend WithEvents lblWOnumber As System.Windows.Forms.Label
'        Friend WithEvents txtProcessedBy As System.Windows.Forms.TextBox
'        Friend WithEvents txtFromLocation As System.Windows.Forms.TextBox
'        Friend WithEvents txtSKU As System.Windows.Forms.TextBox
'        Friend WithEvents txtChannel As System.Windows.Forms.TextBox
'        Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtCreationDate As System.Windows.Forms.TextBox
'        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
'        Friend WithEvents txtReturnOfficeCode As System.Windows.Forms.TextBox
'        Friend WithEvents txtVendor As System.Windows.Forms.TextBox
'        Friend WithEvents lblProcessedBy As System.Windows.Forms.Label
'        Friend WithEvents lblFromLocation As System.Windows.Forms.Label
'        Friend WithEvents lblSKU As System.Windows.Forms.Label
'        Friend WithEvents lblChannel As System.Windows.Forms.Label
'        Friend WithEvents lblDueDate As System.Windows.Forms.Label
'        Friend WithEvents lblStartDate As System.Windows.Forms.Label
'        Friend WithEvents lblCreationDate As System.Windows.Forms.Label
'        Friend WithEvents lblQuantity As System.Windows.Forms.Label
'        Friend WithEvents lblReturnOfficeCode As System.Windows.Forms.Label
'        Friend WithEvents lblVendor As System.Windows.Forms.Label
'        Friend WithEvents grpRepairVendor As System.Windows.Forms.GroupBox
'        Friend WithEvents txtFinishedGoodsSku As System.Windows.Forms.TextBox
'        Friend WithEvents txtShipTo As System.Windows.Forms.TextBox
'        Friend WithEvents lblFinishedGoodsSku As System.Windows.Forms.Label
'        Friend WithEvents lblShipTo As System.Windows.Forms.Label
'        Friend WithEvents lblInstructions As System.Windows.Forms.Label
'        Friend WithEvents txtInstructions As System.Windows.Forms.TextBox
'        Friend WithEvents lblCapHigh As System.Windows.Forms.Label
'        Friend WithEvents lblCapLow As System.Windows.Forms.Label
'        Friend WithEvents lblPad As System.Windows.Forms.Label
'        Friend WithEvents lblFrequency As System.Windows.Forms.Label
'        Friend WithEvents txtCapHigh As System.Windows.Forms.TextBox
'        Friend WithEvents txtCapLow As System.Windows.Forms.TextBox
'        Friend WithEvents txtPad As System.Windows.Forms.TextBox
'        Friend WithEvents txtFrequency As System.Windows.Forms.TextBox
'        Friend WithEvents btnUpdate As System.Windows.Forms.Button
'        Friend WithEvents btnSave As System.Windows.Forms.Button
'        Friend WithEvents btnNew As System.Windows.Forms.Button
'        Friend WithEvents btnClear As System.Windows.Forms.Button
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.lblWO = New System.Windows.Forms.Label()
'            Me.cboWO = New PSS.Gui.Controls.ComboBox()
'            Me.grpDDC = New System.Windows.Forms.GroupBox()
'            Me.txtWOnumber = New System.Windows.Forms.TextBox()
'            Me.lblWOnumber = New System.Windows.Forms.Label()
'            Me.txtProcessedBy = New System.Windows.Forms.TextBox()
'            Me.txtFromLocation = New System.Windows.Forms.TextBox()
'            Me.txtSKU = New System.Windows.Forms.TextBox()
'            Me.txtChannel = New System.Windows.Forms.TextBox()
'            Me.txtDueDate = New System.Windows.Forms.TextBox()
'            Me.txtStartDate = New System.Windows.Forms.TextBox()
'            Me.txtCreationDate = New System.Windows.Forms.TextBox()
'            Me.txtQuantity = New System.Windows.Forms.TextBox()
'            Me.txtReturnOfficeCode = New System.Windows.Forms.TextBox()
'            Me.txtVendor = New System.Windows.Forms.TextBox()
'            Me.lblProcessedBy = New System.Windows.Forms.Label()
'            Me.lblFromLocation = New System.Windows.Forms.Label()
'            Me.lblSKU = New System.Windows.Forms.Label()
'            Me.lblChannel = New System.Windows.Forms.Label()
'            Me.lblDueDate = New System.Windows.Forms.Label()
'            Me.lblStartDate = New System.Windows.Forms.Label()
'            Me.lblCreationDate = New System.Windows.Forms.Label()
'            Me.lblQuantity = New System.Windows.Forms.Label()
'            Me.lblReturnOfficeCode = New System.Windows.Forms.Label()
'            Me.lblVendor = New System.Windows.Forms.Label()
'            Me.grpRepairVendor = New System.Windows.Forms.GroupBox()
'            Me.txtFrequency = New System.Windows.Forms.TextBox()
'            Me.txtPad = New System.Windows.Forms.TextBox()
'            Me.txtCapLow = New System.Windows.Forms.TextBox()
'            Me.txtCapHigh = New System.Windows.Forms.TextBox()
'            Me.lblFrequency = New System.Windows.Forms.Label()
'            Me.lblPad = New System.Windows.Forms.Label()
'            Me.lblCapLow = New System.Windows.Forms.Label()
'            Me.lblCapHigh = New System.Windows.Forms.Label()
'            Me.txtInstructions = New System.Windows.Forms.TextBox()
'            Me.lblInstructions = New System.Windows.Forms.Label()
'            Me.txtFinishedGoodsSku = New System.Windows.Forms.TextBox()
'            Me.txtShipTo = New System.Windows.Forms.TextBox()
'            Me.lblFinishedGoodsSku = New System.Windows.Forms.Label()
'            Me.lblShipTo = New System.Windows.Forms.Label()
'            Me.btnUpdate = New System.Windows.Forms.Button()
'            Me.btnSave = New System.Windows.Forms.Button()
'            Me.btnNew = New System.Windows.Forms.Button()
'            Me.btnClear = New System.Windows.Forms.Button()
'            Me.grpDDC.SuspendLayout()
'            Me.grpRepairVendor.SuspendLayout()
'            Me.SuspendLayout()
'            '
'            'lblWO
'            '
'            Me.lblWO.Location = New System.Drawing.Point(8, 8)
'            Me.lblWO.Name = "lblWO"
'            Me.lblWO.Size = New System.Drawing.Size(96, 16)
'            Me.lblWO.TabIndex = 0
'            Me.lblWO.Text = "Workorder Name:"
'            '
'            'cboWO
'            '
'            Me.cboWO.AutoComplete = True
'            Me.cboWO.Location = New System.Drawing.Point(104, 8)
'            Me.cboWO.Name = "cboWO"
'            Me.cboWO.Size = New System.Drawing.Size(232, 21)
'            Me.cboWO.TabIndex = 0
'            '
'            'grpDDC
'            '
'            Me.grpDDC.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWOnumber, Me.lblWOnumber, Me.txtProcessedBy, Me.txtFromLocation, Me.txtSKU, Me.txtChannel, Me.txtDueDate, Me.txtStartDate, Me.txtCreationDate, Me.txtQuantity, Me.txtReturnOfficeCode, Me.txtVendor, Me.lblProcessedBy, Me.lblFromLocation, Me.lblSKU, Me.lblChannel, Me.lblDueDate, Me.lblStartDate, Me.lblCreationDate, Me.lblQuantity, Me.lblReturnOfficeCode, Me.lblVendor})
'            Me.grpDDC.Location = New System.Drawing.Point(16, 40)
'            Me.grpDDC.Name = "grpDDC"
'            Me.grpDDC.Size = New System.Drawing.Size(248, 288)
'            Me.grpDDC.TabIndex = 1
'            Me.grpDDC.TabStop = False
'            Me.grpDDC.Text = "DDC"
'            '
'            'txtWOnumber
'            '
'            Me.txtWOnumber.Location = New System.Drawing.Point(120, 64)
'            Me.txtWOnumber.Name = "txtWOnumber"
'            Me.txtWOnumber.Size = New System.Drawing.Size(112, 20)
'            Me.txtWOnumber.TabIndex = 4
'            Me.txtWOnumber.Text = ""
'            '
'            'lblWOnumber
'            '
'            Me.lblWOnumber.Location = New System.Drawing.Point(8, 64)
'            Me.lblWOnumber.Name = "lblWOnumber"
'            Me.lblWOnumber.Size = New System.Drawing.Size(104, 16)
'            Me.lblWOnumber.TabIndex = 0
'            Me.lblWOnumber.Text = "Workorder Number:"
'            Me.lblWOnumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtProcessedBy
'            '
'            Me.txtProcessedBy.Location = New System.Drawing.Point(120, 256)
'            Me.txtProcessedBy.Name = "txtProcessedBy"
'            Me.txtProcessedBy.Size = New System.Drawing.Size(112, 20)
'            Me.txtProcessedBy.TabIndex = 12
'            Me.txtProcessedBy.Text = ""
'            '
'            'txtFromLocation
'            '
'            Me.txtFromLocation.Location = New System.Drawing.Point(120, 232)
'            Me.txtFromLocation.Name = "txtFromLocation"
'            Me.txtFromLocation.Size = New System.Drawing.Size(112, 20)
'            Me.txtFromLocation.TabIndex = 11
'            Me.txtFromLocation.Text = ""
'            '
'            'txtSKU
'            '
'            Me.txtSKU.Location = New System.Drawing.Point(120, 208)
'            Me.txtSKU.Name = "txtSKU"
'            Me.txtSKU.Size = New System.Drawing.Size(112, 20)
'            Me.txtSKU.TabIndex = 10
'            Me.txtSKU.Text = ""
'            '
'            'txtChannel
'            '
'            Me.txtChannel.Location = New System.Drawing.Point(120, 184)
'            Me.txtChannel.Name = "txtChannel"
'            Me.txtChannel.Size = New System.Drawing.Size(112, 20)
'            Me.txtChannel.TabIndex = 9
'            Me.txtChannel.Text = ""
'            '
'            'txtDueDate
'            '
'            Me.txtDueDate.Location = New System.Drawing.Point(120, 160)
'            Me.txtDueDate.Name = "txtDueDate"
'            Me.txtDueDate.Size = New System.Drawing.Size(112, 20)
'            Me.txtDueDate.TabIndex = 8
'            Me.txtDueDate.Text = ""
'            '
'            'txtStartDate
'            '
'            Me.txtStartDate.Location = New System.Drawing.Point(120, 136)
'            Me.txtStartDate.Name = "txtStartDate"
'            Me.txtStartDate.Size = New System.Drawing.Size(112, 20)
'            Me.txtStartDate.TabIndex = 7
'            Me.txtStartDate.Text = ""
'            '
'            'txtCreationDate
'            '
'            Me.txtCreationDate.Location = New System.Drawing.Point(120, 112)
'            Me.txtCreationDate.Name = "txtCreationDate"
'            Me.txtCreationDate.Size = New System.Drawing.Size(112, 20)
'            Me.txtCreationDate.TabIndex = 6
'            Me.txtCreationDate.Text = ""
'            '
'            'txtQuantity
'            '
'            Me.txtQuantity.Location = New System.Drawing.Point(120, 88)
'            Me.txtQuantity.Name = "txtQuantity"
'            Me.txtQuantity.Size = New System.Drawing.Size(112, 20)
'            Me.txtQuantity.TabIndex = 5
'            Me.txtQuantity.Text = ""
'            '
'            'txtReturnOfficeCode
'            '
'            Me.txtReturnOfficeCode.Location = New System.Drawing.Point(120, 40)
'            Me.txtReturnOfficeCode.Name = "txtReturnOfficeCode"
'            Me.txtReturnOfficeCode.Size = New System.Drawing.Size(112, 20)
'            Me.txtReturnOfficeCode.TabIndex = 3
'            Me.txtReturnOfficeCode.Text = ""
'            '
'            'txtVendor
'            '
'            Me.txtVendor.Location = New System.Drawing.Point(120, 16)
'            Me.txtVendor.Name = "txtVendor"
'            Me.txtVendor.Size = New System.Drawing.Size(112, 20)
'            Me.txtVendor.TabIndex = 2
'            Me.txtVendor.Text = ""
'            '
'            'lblProcessedBy
'            '
'            Me.lblProcessedBy.Location = New System.Drawing.Point(8, 256)
'            Me.lblProcessedBy.Name = "lblProcessedBy"
'            Me.lblProcessedBy.Size = New System.Drawing.Size(104, 16)
'            Me.lblProcessedBy.TabIndex = 0
'            Me.lblProcessedBy.Text = "Processed By:"
'            Me.lblProcessedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblFromLocation
'            '
'            Me.lblFromLocation.Location = New System.Drawing.Point(8, 232)
'            Me.lblFromLocation.Name = "lblFromLocation"
'            Me.lblFromLocation.Size = New System.Drawing.Size(104, 16)
'            Me.lblFromLocation.TabIndex = 0
'            Me.lblFromLocation.Text = "From Location:"
'            Me.lblFromLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblSKU
'            '
'            Me.lblSKU.Location = New System.Drawing.Point(8, 208)
'            Me.lblSKU.Name = "lblSKU"
'            Me.lblSKU.Size = New System.Drawing.Size(104, 16)
'            Me.lblSKU.TabIndex = 0
'            Me.lblSKU.Text = "SKU:"
'            Me.lblSKU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblChannel
'            '
'            Me.lblChannel.Location = New System.Drawing.Point(8, 184)
'            Me.lblChannel.Name = "lblChannel"
'            Me.lblChannel.Size = New System.Drawing.Size(104, 16)
'            Me.lblChannel.TabIndex = 0
'            Me.lblChannel.Text = "Channel:"
'            Me.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblDueDate
'            '
'            Me.lblDueDate.Location = New System.Drawing.Point(8, 160)
'            Me.lblDueDate.Name = "lblDueDate"
'            Me.lblDueDate.Size = New System.Drawing.Size(104, 16)
'            Me.lblDueDate.TabIndex = 0
'            Me.lblDueDate.Text = "Due Date:"
'            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblStartDate
'            '
'            Me.lblStartDate.Location = New System.Drawing.Point(8, 136)
'            Me.lblStartDate.Name = "lblStartDate"
'            Me.lblStartDate.Size = New System.Drawing.Size(104, 16)
'            Me.lblStartDate.TabIndex = 0
'            Me.lblStartDate.Text = "Start Date:"
'            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblCreationDate
'            '
'            Me.lblCreationDate.Location = New System.Drawing.Point(8, 112)
'            Me.lblCreationDate.Name = "lblCreationDate"
'            Me.lblCreationDate.Size = New System.Drawing.Size(104, 16)
'            Me.lblCreationDate.TabIndex = 0
'            Me.lblCreationDate.Text = "Creation Date:"
'            Me.lblCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblQuantity
'            '
'            Me.lblQuantity.Location = New System.Drawing.Point(8, 88)
'            Me.lblQuantity.Name = "lblQuantity"
'            Me.lblQuantity.Size = New System.Drawing.Size(104, 16)
'            Me.lblQuantity.TabIndex = 0
'            Me.lblQuantity.Text = "Quantity:"
'            Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblReturnOfficeCode
'            '
'            Me.lblReturnOfficeCode.Location = New System.Drawing.Point(8, 40)
'            Me.lblReturnOfficeCode.Name = "lblReturnOfficeCode"
'            Me.lblReturnOfficeCode.Size = New System.Drawing.Size(104, 16)
'            Me.lblReturnOfficeCode.TabIndex = 0
'            Me.lblReturnOfficeCode.Text = "Return Office Code:"
'            Me.lblReturnOfficeCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblVendor
'            '
'            Me.lblVendor.Location = New System.Drawing.Point(8, 16)
'            Me.lblVendor.Name = "lblVendor"
'            Me.lblVendor.Size = New System.Drawing.Size(104, 16)
'            Me.lblVendor.TabIndex = 0
'            Me.lblVendor.Text = "Vendor:"
'            Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'grpRepairVendor
'            '
'            Me.grpRepairVendor.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFrequency, Me.txtPad, Me.txtCapLow, Me.txtCapHigh, Me.lblFrequency, Me.lblPad, Me.lblCapLow, Me.lblCapHigh, Me.txtInstructions, Me.lblInstructions, Me.txtFinishedGoodsSku, Me.txtShipTo, Me.lblFinishedGoodsSku, Me.lblShipTo})
'            Me.grpRepairVendor.Location = New System.Drawing.Point(272, 40)
'            Me.grpRepairVendor.Name = "grpRepairVendor"
'            Me.grpRepairVendor.Size = New System.Drawing.Size(256, 288)
'            Me.grpRepairVendor.TabIndex = 2
'            Me.grpRepairVendor.TabStop = False
'            Me.grpRepairVendor.Text = "Repair Vendor"
'            '
'            'txtFrequency
'            '
'            Me.txtFrequency.Location = New System.Drawing.Point(144, 256)
'            Me.txtFrequency.Name = "txtFrequency"
'            Me.txtFrequency.TabIndex = 19
'            Me.txtFrequency.Text = ""
'            '
'            'txtPad
'            '
'            Me.txtPad.Location = New System.Drawing.Point(144, 232)
'            Me.txtPad.Name = "txtPad"
'            Me.txtPad.TabIndex = 18
'            Me.txtPad.Text = ""
'            '
'            'txtCapLow
'            '
'            Me.txtCapLow.Location = New System.Drawing.Point(144, 184)
'            Me.txtCapLow.Name = "txtCapLow"
'            Me.txtCapLow.TabIndex = 16
'            Me.txtCapLow.Text = ""
'            '
'            'txtCapHigh
'            '
'            Me.txtCapHigh.Location = New System.Drawing.Point(144, 208)
'            Me.txtCapHigh.Name = "txtCapHigh"
'            Me.txtCapHigh.TabIndex = 17
'            Me.txtCapHigh.Text = ""
'            '
'            'lblFrequency
'            '
'            Me.lblFrequency.Location = New System.Drawing.Point(16, 256)
'            Me.lblFrequency.Name = "lblFrequency"
'            Me.lblFrequency.Size = New System.Drawing.Size(120, 16)
'            Me.lblFrequency.TabIndex = 0
'            Me.lblFrequency.Text = "Frequency:"
'            Me.lblFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblPad
'            '
'            Me.lblPad.Location = New System.Drawing.Point(16, 232)
'            Me.lblPad.Name = "lblPad"
'            Me.lblPad.Size = New System.Drawing.Size(120, 16)
'            Me.lblPad.TabIndex = 0
'            Me.lblPad.Text = "PAD:"
'            Me.lblPad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblCapLow
'            '
'            Me.lblCapLow.Location = New System.Drawing.Point(16, 184)
'            Me.lblCapLow.Name = "lblCapLow"
'            Me.lblCapLow.Size = New System.Drawing.Size(120, 16)
'            Me.lblCapLow.TabIndex = 0
'            Me.lblCapLow.Text = "CAP (Low):"
'            Me.lblCapLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblCapHigh
'            '
'            Me.lblCapHigh.Location = New System.Drawing.Point(16, 208)
'            Me.lblCapHigh.Name = "lblCapHigh"
'            Me.lblCapHigh.Size = New System.Drawing.Size(120, 16)
'            Me.lblCapHigh.TabIndex = 0
'            Me.lblCapHigh.Text = "CAP (High):"
'            Me.lblCapHigh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtInstructions
'            '
'            Me.txtInstructions.Location = New System.Drawing.Point(16, 88)
'            Me.txtInstructions.Multiline = True
'            Me.txtInstructions.Name = "txtInstructions"
'            Me.txtInstructions.Size = New System.Drawing.Size(224, 72)
'            Me.txtInstructions.TabIndex = 15
'            Me.txtInstructions.Text = ""
'            '
'            'lblInstructions
'            '
'            Me.lblInstructions.Location = New System.Drawing.Point(16, 72)
'            Me.lblInstructions.Name = "lblInstructions"
'            Me.lblInstructions.Size = New System.Drawing.Size(72, 16)
'            Me.lblInstructions.TabIndex = 0
'            Me.lblInstructions.Text = "Instructions:"
'            Me.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'            '
'            'txtFinishedGoodsSku
'            '
'            Me.txtFinishedGoodsSku.Location = New System.Drawing.Point(144, 40)
'            Me.txtFinishedGoodsSku.Name = "txtFinishedGoodsSku"
'            Me.txtFinishedGoodsSku.TabIndex = 14
'            Me.txtFinishedGoodsSku.Text = ""
'            '
'            'txtShipTo
'            '
'            Me.txtShipTo.Location = New System.Drawing.Point(144, 16)
'            Me.txtShipTo.Name = "txtShipTo"
'            Me.txtShipTo.TabIndex = 13
'            Me.txtShipTo.Text = ""
'            '
'            'lblFinishedGoodsSku
'            '
'            Me.lblFinishedGoodsSku.Location = New System.Drawing.Point(16, 40)
'            Me.lblFinishedGoodsSku.Name = "lblFinishedGoodsSku"
'            Me.lblFinishedGoodsSku.Size = New System.Drawing.Size(120, 16)
'            Me.lblFinishedGoodsSku.TabIndex = 0
'            Me.lblFinishedGoodsSku.Text = "Finished Goods SKU:"
'            Me.lblFinishedGoodsSku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'lblShipTo
'            '
'            Me.lblShipTo.Location = New System.Drawing.Point(16, 16)
'            Me.lblShipTo.Name = "lblShipTo"
'            Me.lblShipTo.Size = New System.Drawing.Size(120, 16)
'            Me.lblShipTo.TabIndex = 0
'            Me.lblShipTo.Text = "Ship To:"
'            Me.lblShipTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'btnUpdate
'            '
'            Me.btnUpdate.Location = New System.Drawing.Point(272, 368)
'            Me.btnUpdate.Name = "btnUpdate"
'            Me.btnUpdate.Size = New System.Drawing.Size(256, 23)
'            Me.btnUpdate.TabIndex = 21
'            Me.btnUpdate.Text = "Update Data"
'            '
'            'btnSave
'            '
'            Me.btnSave.Location = New System.Drawing.Point(272, 336)
'            Me.btnSave.Name = "btnSave"
'            Me.btnSave.Size = New System.Drawing.Size(256, 23)
'            Me.btnSave.TabIndex = 20
'            Me.btnSave.Text = "Save Data"
'            '
'            'btnNew
'            '
'            Me.btnNew.Location = New System.Drawing.Point(344, 8)
'            Me.btnNew.Name = "btnNew"
'            Me.btnNew.Size = New System.Drawing.Size(184, 23)
'            Me.btnNew.TabIndex = 0
'            Me.btnNew.TabStop = False
'            Me.btnNew.Text = "New Entry"
'            '
'            'btnClear
'            '
'            Me.btnClear.Location = New System.Drawing.Point(16, 368)
'            Me.btnClear.Name = "btnClear"
'            Me.btnClear.Size = New System.Drawing.Size(64, 23)
'            Me.btnClear.TabIndex = 0
'            Me.btnClear.TabStop = False
'            Me.btnClear.Text = "Clear"
'            '
'            'frmPreload_USAMobility
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.ClientSize = New System.Drawing.Size(648, 397)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnNew, Me.btnSave, Me.btnUpdate, Me.grpRepairVendor, Me.grpDDC, Me.cboWO, Me.lblWO})
'            Me.Name = "frmPreload_USAMobility"
'            Me.Text = "frmPreload_USAMobility"
'            Me.grpDDC.ResumeLayout(False)
'            Me.grpRepairVendor.ResumeLayout(False)
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Private dsPSS As PSS.Data.Production.Joins
'        Private dtWorkorder As DataTable

'        Private Sub frmPreload_USAMobility_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            hideControls()          '//Hides all form objects
'            loadCombo_Workorder()   '//Loads all USA WO currently defined
'            showControls()          '//Shows all form objects
'        End Sub

'        Private Sub cboWO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboWO.SelectionChangeCommitted
'            Me.getDetailData(cboWO.Text)
'        End Sub

'        Private Sub displayWorkorderValues(ByVal dr As DataRow)
'            clearFields()
'            System.Windows.Forms.Application.DoEvents()
'            If IsDBNull(dr("USA_Vendor")) = False Then txtVendor.Text = dr("USA_Vendor")
'            If IsDBNull(dr("USA_ReturnOfficeCode")) = False Then txtReturnOfficeCode.Text = dr("USA_ReturnOfficeCode")
'            If IsDBNull(dr("USA_WO")) = False Then txtWOnumber.Text = dr("USA_WO")
'            If IsDBNull(dr("USA_Qty")) = False Then txtQuantity.Text = dr("USA_Qty")
'            If IsDBNull(dr("USA_CreationDate")) = False Then txtCreationDate.Text = dr("USA_CreationDate")
'            If IsDBNull(dr("USA_StartDate")) = False Then txtStartDate.Text = dr("USA_StartDate")
'            If IsDBNull(dr("USA_DueDate")) = False Then txtDueDate.Text = dr("USA_DueDate")
'            If IsDBNull(dr("USA_Channel")) = False Then txtChannel.Text = dr("USA_Channel")
'            If IsDBNull(dr("USA_Sku")) = False Then txtSKU.Text = dr("USA_Sku")
'            If IsDBNull(dr("USA_FromLocation")) = False Then txtFromLocation.Text = dr("USA_FromLocation")
'            If IsDBNull(dr("USA_ProcessedBy")) = False Then txtProcessedBy.Text = dr("USA_ProcessedBy")
'            If IsDBNull(dr("USA_ShipTo")) = False Then txtShipTo.Text = dr("USA_ShipTo")
'            If IsDBNull(dr("USA_FinishedGoodsSKU")) = False Then txtFinishedGoodsSku.Text = dr("USA_FinishedGoodsSKU")
'            If IsDBNull(dr("USA_Instructions")) = False Then txtInstructions.Text = dr("USA_Instructions")
'            If IsDBNull(dr("USA_CapLow")) = False Then txtCapLow.Text = dr("USA_CapLow")
'            If IsDBNull(dr("USA_CapHigh")) = False Then txtCapHigh.Text = dr("USA_CapHigh")
'            If IsDBNull(dr("USA_Pad")) = False Then txtPad.Text = dr("USA_Pad")
'            If IsDBNull(dr("USA_Freq")) = False Then txtFrequency.Text = dr("USA_Freq")
'        End Sub

'#Region "Verify Data Functions"

'        Private Function verifyCapCodes(ByVal vLow As String, ByVal vHigh As String, ByVal vPad As Integer) As String

'            Dim intLow, intHigh, intDifference As Long
'            Dim errMsg As String = ""
'            '//Verify  - integers
'            Try
'                intLow = CInt(vLow)
'                intHigh = CInt(vHigh)
'            Catch ex As Exception
'                errMsg = vbCrLf & "Either the low or high cap code value can not be converted to an integer value. "
'                Return errMsg
'            End Try
'            '//Verify - high greater than low
'            Try
'                intDifference = intHigh - intLow
'                If intDifference < 0 Then
'                    errMsg = vbCrLf & "The high cap code values must be greater than the low cap code value. "
'                    Return errMsg
'                End If
'            Catch ex As Exception
'            End Try

'            Return errMsg

'        End Function
'        Private Function verifyPAD(ByVal vPad As String) As String
'            Dim vInt As Integer
'            Dim errMsg As String = ""
'            Try
'                vInt = CInt(vPad)
'            Catch ex As Exception
'                errMsg = vbCrLf & "The value for pad can not be converted to an integer. "
'                Return errMsg
'            End Try

'            Try
'                If vInt > 10 Then
'                    errMsg = vbCrLf & "The value for the pad can not be greater than 10. "
'                    Return errMsg
'                End If
'            Catch ex As Exception
'            End Try

'            Return errMsg

'        End Function
'        Private Function verifyFrequency(ByVal vFreq As String) As String
'            Dim errMsg As String = ""
'            Dim dtFreq As DataTable
'            If Len(Trim(vFreq)) > 0 Then
'                dtFreq = dsPSS.OrderEntrySelect("SELECT * FROM lfrequency WHERE freq_number = '" & vFreq & "'")
'                If dtFreq.Rows.Count < 1 Then
'                    errMsg = vbCrLf & "The frequency is not valid. "
'                    Return errMsg
'                End If
'            Else
'                errMsg += vbCrLf & "The frequency could not be determined. "
'                Return errMsg
'            End If

'            dtFreq = Nothing

'            Return errMsg

'        End Function
'        Private Function verifySKU(ByVal vSKU As String) As String
'            vSKU = Trim(vSKU)
'            Dim errMsg As String = ""
'            If Len(Trim(vSKU)) <> 14 Then
'                errMsg = "The SKU must be 14 characters long. "
'                Return errMsg
'            End If
'            If UCase(Mid$(vSKU, 12, 3)) <> "DIR" Then
'                errMsg = vbCrLf & "The SKU must end with DIR. "
'                Return errMsg
'            End If
'            Dim dtModel As DataTable = dsPSS.OrderEntrySelect("SELECT * FROM lmodelcodes4skus WHERE ModelCode = '" & Mid$(vSKU, 1, 3) & "'")
'            Try
'                If dtModel.Rows.Count < 1 Then
'                    errMsg = vbCrLf & "Can not determine the model value (characters 1 to 3). "
'                    Return errMsg
'                End If
'            Catch ex As Exception
'                errMsg = "Can not determine the model value (characters 1 to 3). "
'                Return errMsg
'            End Try
'            Dim dtChannel As DataTable = dsPSS.OrderEntrySelect("SELECT * FROM lchannel2frequency WHERE C2F_Channel = '" & Trim(Mid$(vSKU, 9, 3)) & "'")
'            Try
'                If dtChannel.Rows.Count < 1 Then
'                    errMsg = vbCrLf & "Can not determine the channel value (characters 9 to 11). "
'                    Return errMsg
'                End If
'            Catch ex As Exception
'                errMsg = vbCrLf & "Can not determine the channel value (characters 9 to 11). "
'                Return errMsg
'            End Try

'            Return errMsg

'        End Function

'        Private Function verifyData(ByVal mLow As String, ByVal mHigh As String, ByVal mPad As String, ByVal mFreq As String, ByVal mSku As String) As Boolean

'            Dim errorMessage As String = ""

'            errorMessage += verifyCapCodes(mLow, mHigh, mPad)
'            errorMessage += verifyPAD(mPad)
'            errorMessage += verifyFrequency(mFreq)
'            errorMessage += verifySKU(mSku)

'            If Len(Trim(errorMessage)) > 0 Then
'                MsgBox(errorMessage, MsgBoxStyle.Critical, "RECORD INVALID")
'                Return False
'            Else
'                Return True
'            End If

'        End Function

'#End Region

'#Region "Data Acquisition"

'        Private Sub getDetailData(ByVal strWO As String)
'            Dim drDetail As DataRow
'            If Len(Trim(cboWO.Text)) > 0 Then '//a record is available - SUBMIT
'                drDetail = getRecord(strWO)
'                displayWorkorderValues(drDetail)
'            End If
'        End Sub
'        Private Function getRecord(ByVal vWO) As DataRow
'            Return dsPSS.OrderEntrySelect("SELECT * FROM tusatest WHERE USA_WO = '" & vWO & "'").Rows(0)
'        End Function

'        Private Sub loadCombo_Workorder()
'            dtWorkorder = getWorkorder()
'            cboWO.DataSource = dtWorkorder
'            cboWO.DisplayMember = dtWorkorder.Columns("USA_WO").ToString
'            cboWO.ValueMember = dtWorkorder.Columns("USA_WO").ToString
'        End Sub
'        Private Function getWorkorder() As DataTable
'            Return dsPSS.OrderEntrySelect("SELECT USA_WO FROM tusatest")
'        End Function

'#End Region

'#Region "Control Functions"

'        Private Sub hideControls()
'            Dim xCount As Integer = 0
'            For xCount = 0 To Me.Controls.Count - 1
'                hideControlsExecute(Controls(xCount))
'            Next
'        End Sub
'        Private Sub hideControlsExecute(ByVal xctl As Control)
'            Dim x As Integer
'            If xctl.Controls.Count > 1 Then
'                xctl.Visible = False
'                For x = 0 To xctl.Controls.Count - 1
'                    hideControlsExecute(xctl.Controls(x))
'                Next
'            Else
'                xctl.Visible = False
'            End If
'        End Sub

'        Private Sub showControls()
'            Dim xCount As Integer = 0
'            For xCount = 0 To Me.Controls.Count - 1
'                showControlsExecute(Controls(xCount))
'            Next
'        End Sub
'        Private Sub showControlsExecute(ByVal xctl As Control)
'            Dim x As Integer
'            If xctl.Controls.Count > 1 Then
'                xctl.Visible = True
'                For x = 0 To xctl.Controls.Count - 1
'                    showControlsExecute(xctl.Controls(x))
'                Next
'            Else
'                xctl.Visible = True
'            End If
'        End Sub

'        Private Sub clearFields()
'            Dim xCount As Integer = 0
'            For xCount = 0 To Me.Controls.Count - 1
'                clearFieldsExecute(Controls(xCount))
'            Next
'        End Sub
'        Private Sub clearFieldsExecute(ByVal xctl As Control)
'            Dim x As Integer
'            If xctl.Controls.Count > 1 Then
'                xctl.Visible = True
'                For x = 0 To xctl.Controls.Count - 1
'                    clearFieldsExecute(xctl.Controls(x))
'                Next
'            Else
'                If xctl.GetType.Name = "TextBox" Then
'                    xctl.Text = ""
'                End If
'            End If

'        End Sub

'#End Region

'#Region "Button Functions"

'        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
'            clearFields()
'            cboWO.Text = ""
'            cboWO.Focus()
'        End Sub

'        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
'            Dim blnVerify As Boolean = Me.verifyData(txtCapLow.Text, txtCapHigh.Text, txtPad.Text, txtFrequency.Text, txtFinishedGoodsSku.Text)
'        End Sub

'#End Region


'    End Class

'End Namespace
