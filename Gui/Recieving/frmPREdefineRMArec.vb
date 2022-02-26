Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing
Imports System.Drawing.Printing
Imports PSS.Core


Namespace Gui.Receiving


    Public Class frmPREdefineRMArec
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
        Friend WithEvents txtPRL As System.Windows.Forms.TextBox
        Friend WithEvents txtIP As System.Windows.Forms.TextBox
        Friend WithEvents txtSKU As System.Windows.Forms.TextBox
        Friend WithEvents btnSET As System.Windows.Forms.Button
        Friend WithEvents btnRecover As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tbMain As System.Windows.Forms.TabPage
        Friend WithEvents tbRec As System.Windows.Forms.TabPage
        Friend WithEvents tbTech As System.Windows.Forms.TabPage
        Friend WithEvents tvList As System.Windows.Forms.TreeView
        Friend WithEvents btnSave As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.cboManufacturer = New System.Windows.Forms.ComboBox()
            Me.cboModel = New System.Windows.Forms.ComboBox()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            Me.txtQuantity = New System.Windows.Forms.TextBox()
            Me.txtPRL = New System.Windows.Forms.TextBox()
            Me.txtIP = New System.Windows.Forms.TextBox()
            Me.txtSKU = New System.Windows.Forms.TextBox()
            Me.btnSET = New System.Windows.Forms.Button()
            Me.btnRecover = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tbMain = New System.Windows.Forms.TabPage()
            Me.tbRec = New System.Windows.Forms.TabPage()
            Me.tbTech = New System.Windows.Forms.TabPage()
            Me.tvList = New System.Windows.Forms.TreeView()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.tbMain.SuspendLayout()
            Me.tbRec.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(32, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Customer Name :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(32, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 16)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Manufacturer :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(32, 56)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Model :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(32, 80)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 16)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "RMA :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(32, 104)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 16)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "Quantity :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(32, 128)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 16)
            Me.Label6.TabIndex = 5
            Me.Label6.Text = "PRL :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(32, 152)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(96, 16)
            Me.Label7.TabIndex = 6
            Me.Label7.Text = "IP :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(32, 176)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(96, 16)
            Me.Label8.TabIndex = 7
            Me.Label8.Text = "SKU :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCustomer.Location = New System.Drawing.Point(128, 32)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(160, 21)
            Me.cboCustomer.TabIndex = 8
            '
            'cboManufacturer
            '
            Me.cboManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboManufacturer.Location = New System.Drawing.Point(128, 32)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(160, 21)
            Me.cboManufacturer.TabIndex = 9
            '
            'cboModel
            '
            Me.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboModel.Location = New System.Drawing.Point(128, 56)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(160, 21)
            Me.cboModel.TabIndex = 10
            '
            'txtRMA
            '
            Me.txtRMA.Location = New System.Drawing.Point(128, 80)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(136, 20)
            Me.txtRMA.TabIndex = 11
            Me.txtRMA.Text = ""
            '
            'txtQuantity
            '
            Me.txtQuantity.Location = New System.Drawing.Point(128, 104)
            Me.txtQuantity.Name = "txtQuantity"
            Me.txtQuantity.Size = New System.Drawing.Size(136, 20)
            Me.txtQuantity.TabIndex = 12
            Me.txtQuantity.Text = ""
            '
            'txtPRL
            '
            Me.txtPRL.Location = New System.Drawing.Point(128, 128)
            Me.txtPRL.Name = "txtPRL"
            Me.txtPRL.Size = New System.Drawing.Size(136, 20)
            Me.txtPRL.TabIndex = 13
            Me.txtPRL.Text = ""
            '
            'txtIP
            '
            Me.txtIP.Location = New System.Drawing.Point(128, 152)
            Me.txtIP.Name = "txtIP"
            Me.txtIP.Size = New System.Drawing.Size(136, 20)
            Me.txtIP.TabIndex = 14
            Me.txtIP.Text = ""
            '
            'txtSKU
            '
            Me.txtSKU.Location = New System.Drawing.Point(128, 176)
            Me.txtSKU.Name = "txtSKU"
            Me.txtSKU.Size = New System.Drawing.Size(136, 20)
            Me.txtSKU.TabIndex = 15
            Me.txtSKU.Text = ""
            '
            'btnSET
            '
            Me.btnSET.Location = New System.Drawing.Point(416, 368)
            Me.btnSET.Name = "btnSET"
            Me.btnSET.TabIndex = 16
            Me.btnSET.Text = "SET"
            '
            'btnRecover
            '
            Me.btnRecover.Location = New System.Drawing.Point(576, 368)
            Me.btnRecover.Name = "btnRecover"
            Me.btnRecover.TabIndex = 17
            Me.btnRecover.Text = "Recover"
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(504, 368)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 23)
            Me.btnClear.TabIndex = 18
            Me.btnClear.Text = "Clear"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(464, 408)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(96, 23)
            Me.Button1.TabIndex = 19
            Me.Button1.Text = "Reprint Master"
            Me.Button1.Visible = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(464, 432)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(96, 23)
            Me.Button2.TabIndex = 20
            Me.Button2.Text = "Reprint OverPack Manifest"
            Me.Button2.Visible = False
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(560, 408)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(96, 23)
            Me.Button3.TabIndex = 21
            Me.Button3.Text = "Coffin Box"
            Me.Button3.Visible = False
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(560, 432)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(96, 23)
            Me.Button4.TabIndex = 22
            Me.Button4.Text = "Reprint OverPack"
            Me.Button4.Visible = False
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.Location = New System.Drawing.Point(8, 8)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(344, 32)
            Me.lblTitle.TabIndex = 23
            Me.lblTitle.Text = "Default Settings for RMA"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbMain, Me.tbRec, Me.tbTech})
            Me.TabControl1.Location = New System.Drawing.Point(32, 64)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(368, 328)
            Me.TabControl1.TabIndex = 24
            '
            'tbMain
            '
            Me.tbMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.cboCustomer})
            Me.tbMain.Location = New System.Drawing.Point(4, 22)
            Me.tbMain.Name = "tbMain"
            Me.tbMain.Size = New System.Drawing.Size(360, 302)
            Me.tbMain.TabIndex = 0
            Me.tbMain.Text = "Main Information"
            '
            'tbRec
            '
            Me.tbRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSKU, Me.Label8, Me.cboModel, Me.txtRMA, Me.cboManufacturer, Me.Label2, Me.Label3, Me.txtQuantity, Me.Label4, Me.Label5, Me.txtPRL, Me.Label6, Me.txtIP, Me.Label7})
            Me.tbRec.Location = New System.Drawing.Point(4, 22)
            Me.tbRec.Name = "tbRec"
            Me.tbRec.Size = New System.Drawing.Size(360, 302)
            Me.tbRec.TabIndex = 1
            Me.tbRec.Text = "Receiving"
            '
            'tbTech
            '
            Me.tbTech.Location = New System.Drawing.Point(4, 22)
            Me.tbTech.Name = "tbTech"
            Me.tbTech.Size = New System.Drawing.Size(360, 302)
            Me.tbTech.TabIndex = 2
            Me.tbTech.Text = "Tech"
            '
            'tvList
            '
            Me.tvList.ImageIndex = -1
            Me.tvList.Location = New System.Drawing.Point(416, 64)
            Me.tvList.Name = "tvList"
            Me.tvList.SelectedImageIndex = -1
            Me.tvList.Size = New System.Drawing.Size(232, 296)
            Me.tvList.TabIndex = 25
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(32, 400)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(368, 23)
            Me.btnSave.TabIndex = 26
            Me.btnSave.Text = "SAVE RECORD"
            '
            'frmPREdefineRMArec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(664, 461)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSave, Me.tvList, Me.TabControl1, Me.lblTitle, Me.Button4, Me.Button3, Me.Button2, Me.Button1, Me.btnClear, Me.btnRecover, Me.btnSET})
            Me.Name = "frmPREdefineRMArec"
            Me.Text = "frmPREdefineRMArec"
            Me.TabControl1.ResumeLayout(False)
            Me.tbMain.ResumeLayout(False)
            Me.tbRec.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private PreDefine As New PSS.Gui.Receiving.clsPREdefine()
        Private xCount As Integer
        Private initLoad As Boolean


        Private Sub frmPREdefineRMArec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            initLoad = False
            getCustomerList()
            getManufacturerList()
            getModelList()
            initLoad = True

        End Sub

        Private Sub getCustomerList()

            Dim dCust As DataTable = PreDefine.PopulateCustomers
            cboCustomer.DataSource = dCust.DefaultView
            cboCustomer.DisplayMember = dCust.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dCust.Columns("Cust_ID").ToString

        End Sub

        Private Sub getManufacturerList()

            Dim dManuf As DataTable = PreDefine.PopulateManufacturers
            cboManufacturer.DataSource = dManuf.DefaultView
            cboManufacturer.DisplayMember = dManuf.Columns("Manuf_Desc").ToString
            cboManufacturer.ValueMember = dManuf.Columns("Manuf_ID").ToString

        End Sub

        Private Sub getModelList()

            Try
                Dim dModel As DataTable = PreDefine.PopulateModels
                cboModel.DataSource = dModel.DefaultView
                cboModel.DisplayMember = dModel.Columns("Model_Desc").ToString
                cboModel.ValueMember = dModel.Columns("Model_ID").ToString
            Catch ex As Exception
            End Try

        End Sub

        Private Sub btnSET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSET.Click

            PreDefine.Customer = cboCustomer.SelectedValue
            MsgBox(cboManufacturer.SelectedValue)
            PreDefine.Manufacturer = cboManufacturer.SelectedValue
            PreDefine.Model = cboModel.SelectedValue
            PreDefine.RMA = txtRMA.Text
            PreDefine.Qty = txtQuantity.Text
            PreDefine.PRL = txtPRL.Text
            PreDefine.IP = txtIP.Text
            PreDefine.SKU = txtSKU.Text

        End Sub

        Private Sub btnRecover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecover.Click

            clearCustomer()
            clearManufacturer()
            clearModel()
            getCustomerList()
            getManufacturerList()
            cboCustomer.SelectedValue = PreDefine.Customer
            cboManufacturer.SelectedValue = PreDefine.Manufacturer
            getModelList()
            cboModel.SelectedValue = PreDefine.Model
            txtRMA.Text = PreDefine.RMA
            txtQuantity.Text = PreDefine.Qty
            txtPRL.Text = PreDefine.PRL
            txtIP.Text = PreDefine.IP
            txtSKU.Text = PreDefine.SKU

        End Sub

        Private Sub cboManufacturer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedIndexChanged

            'If Len(Trim(cboManufacturer.SelectedValue)) > 0 Then
            'PreDefine.Manufacturer = cboManufacturer.SelectedValue
            'End If

        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            clearCustomer()
            clearManufacturer()
            clearModel()
            txtRMA.Text = ""
            txtQuantity.Text = ""
            txtPRL.Text = ""
            txtIP.Text = ""
            txtSKU.Text = ""

        End Sub

        Private Sub clearCustomer()

            Try
                cboCustomer.Items.Clear()
            Catch ex As Exception
                cboCustomer.SelectedIndex = -1
            End Try

        End Sub

        Private Sub clearManufacturer()

            Try
                cboManufacturer.Items.Clear()
            Catch ex As Exception
                cboManufacturer.SelectedIndex = -1
            End Try

        End Sub

        Private Sub clearModel()

            Try
                cboModel.Items.Clear()
            Catch ex As Exception
                cboModel.SelectedIndex = -1
            End Try

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iPallett_ID As Integer
            Dim iOverPack_ID As Integer
            Dim iShip_ID As Integer
            Dim iProd_ID As Integer = 2 ' cellular Phone
            Dim iLOC_ID As Integer
            Dim strUser As String = PSS.Core.[Global].ApplicationUser.User
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim objRpt As ReportDocument
            Dim ps As New PrinterSettings()

            Try

                '*******************
                'Ship Master Label

                Dim strInput As String
                strInput = InputBox("Enter Shipping ID: ", "Master Pack")

                ps.PrinterName = "Zebra170Xi on CELLBILL"

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_Master_Label.rpt")
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & strInput
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_Master_Label.rpt")
                'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & strInput
                'ps.PrinterName = "Zebra170Xi on CELLBILL"
                'rpt.PrintOut(False, 1)
                'rpt = Nothing

                'change the printer here
                'rpt.SelectPrinter("Zebra 170xi", "Zebra170Xi on CELLBILL", "COM2")

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'If Not IsNothing(dt) Then
                '    dt = Nothing
                'End If
                'rpt = Nothing
                'rptApp = Nothing
                ps = Nothing
            End Try

        End Sub

        Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

            Dim i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iPallett_ID As Integer
            Dim iOverPack_ID As Integer
            Dim iShip_ID As Integer
            Dim iProd_ID As Integer = 2 ' cellular Phone
            Dim iLOC_ID As Integer
            Dim strUser As String = PSS.Core.[Global].ApplicationUser.User
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim objRpt As ReportDocument
            Dim ps As New PrinterSettings()

            Try

                '********************************************************
                'Print
                '********************************************************
                'Ship Over Pack Label
                Dim strInput As String
                strInput = InputBox("Enter overpack ID: ", "Master Pack")

                ps.PrinterName = "Zebra170Xi on CELLBILL"

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_OverPack_Label.rpt")
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & strInput
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_OverPack_Label.rpt")
                'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & strInput
                'ps.PrinterName = "Zebra170Xi on CELLBILL"
                'rpt.PrintOut(False, 1)
                'rpt = Nothing

                'change the printer here
                'rpt.SelectPrinter("Zebra 170xi", "Zebra170Xi on CELLBILL", "COM2")

                '*******************
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'If Not IsNothing(dt) Then
                '    dt = Nothing
                'End If
                'rpt = Nothing
                'rptApp = Nothing
                ps = Nothing
            End Try


        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

            Dim i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iPallett_ID As Integer
            Dim iOverPack_ID As Integer
            Dim iShip_ID As Integer
            Dim iProd_ID As Integer = 2 ' cellular Phone
            Dim iLOC_ID As Integer
            Dim strUser As String = PSS.Core.[Global].ApplicationUser.User
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim objRpt As ReportDocument
            Dim ps As New PrinterSettings()

            Try

                '*****************************************
                'Print Shipping Manifest and labels here
                '*****************************************
                'Ship Manifest Overpack

                Dim strInput As String
                strInput = InputBox("Enter OverPack ID: ", "Over Pack")

                ps.PrinterName = "Default on WCCELLULAR"

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_Manifest_OverPack.rpt")
                    .RecordSelectionFormula = "{toverpack.overpack_ID} = " & strInput
                    .PrintToPrinter(2, True, 0, 0)
                End With

                objRpt.Close()

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_Manifest_OverPack.rpt")
                'rpt.RecordSelectionFormula = "{toverpack.overpack_ID} = " & strInput
                'ps.PrinterName = "Default on WCCELLULAR"
                'rpt.PrintOut(False, 2)
                'rpt = Nothing

                'change the printer here
                'rpt.SelectPrinter("HP LaserJet 5Si", "HP LaserJet 5Si on WCCELLULAR", "LPT1")

                '*******************
                'Ship Over Pack Label
                ps.PrinterName = "Zebra170Xi on CELLBILL"

                objRpt = Nothing
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_OverPack_Label.rpt")
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & iShip_ID
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_OverPack_Label.rpt")
                'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & iShip_ID
                'ps.PrinterName = "Zebra170Xi on CELLBILL"
                'rpt.PrintOut(False, 1)
                'rpt = Nothing

                'change the printer here
                'rpt.SelectPrinter("Zebra 170xi", "Zebra170Xi on CELLBILL", "COM2")

                '*******************

            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'If Not IsNothing(dt) Then
                '    dt = Nothing
                'End If
                'rpt = Nothing
                'rptApp = Nothing
                ps = Nothing
            End Try


        End Sub

        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

            Dim i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iPallett_ID As Integer
            Dim iOverPack_ID As Integer
            Dim iShip_ID As Integer
            Dim iProd_ID As Integer = 2 ' cellular Phone
            Dim iLOC_ID As Integer
            Dim strUser As String = PSS.Core.[Global].ApplicationUser.User
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim objRpt As ReportDocument
            Dim ps As New PrinterSettings()

            Try

                '********************************************************
                'Print
                '********************************************************
                ''*******************
                'Print Ship_Coffinbox_Label

                Dim strInput As String
                strInput = InputBox("Enter Device ID: ", "Coffin Box")

                ps.PrinterName = "ZebraZ40 on CELLBILL"

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_CoffinBox_Label.rpt")
                    .RecordSelectionFormula = "{tdevice.Device_ID} = " & strInput
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_CoffinBox_Label.rpt")
                'rpt.RecordSelectionFormula = "{tdevice.Device_ID} = " & strInput
                'ps.PrinterName = "ZebraZ40 on CELLBILL"
                'rpt.PrintOut(False, 1)
                'rpt = Nothing

                'Select the printer here
                'rpt.SelectPrinter("HP LaserJet 5si", "192.168.1.240", "IP_192.168.1.240")
                'rpt.SelectPrinter("Zebra Z4000 300dpi", "ZebraZ4k_1 on CELLBILL", "LPT1")
                'rpt.SelectPrinter("Zebra Z4000 300dpi", "ZebraZ4k_1", "LPT1")



            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'If Not IsNothing(dt) Then
                '    dt = Nothing
                'End If
                'rpt = Nothing
                'rptApp = Nothing
                ps = Nothing
            End Try


        End Sub


        Private Sub populateTree()

            tvList.Nodes.Clear()
            tvList.Nodes.Add(cboCustomer.Text)
            tvList.Nodes.Add(New TreeNode("Receiving"))
            tvList.Nodes(1).Nodes.Add(New TreeNode("Manufacturer"))
            tvList.Nodes(1).Nodes(0).Nodes.Add(New TreeNode(Me.cboManufacturer.Text))
            tvList.Nodes(1).Nodes.Add(New TreeNode("Model"))
            tvList.Nodes(1).Nodes(1).Nodes.Add(New TreeNode(Me.cboModel.Text))
            tvList.Nodes(1).Nodes.Add(New TreeNode("RMA"))
            tvList.Nodes(1).Nodes(2).Nodes.Add(New TreeNode(Me.txtRMA.Text))
            tvList.Nodes(1).Nodes.Add(New TreeNode("Quantity"))
            tvList.Nodes(1).Nodes(3).Nodes.Add(New TreeNode(Me.txtQuantity.Text))
            tvList.Nodes(1).Nodes.Add(New TreeNode("PRL"))
            tvList.Nodes(1).Nodes(4).Nodes.Add(New TreeNode(Me.txtPRL.Text))
            tvList.Nodes(1).Nodes.Add(New TreeNode("IP"))
            tvList.Nodes(1).Nodes(5).Nodes.Add(New TreeNode(Me.txtIP.Text))
            tvList.Nodes(1).Nodes.Add(New TreeNode("SKU"))
            tvList.Nodes(1).Nodes(6).Nodes.Add(New TreeNode(Me.txtSKU.Text))
            tvList.Nodes.Add(New TreeNode("Tech"))

        End Sub


        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            '//Set all values to class
            PreDefine.Customer = cboCustomer.SelectedValue
            MsgBox(cboManufacturer.SelectedValue)
            PreDefine.Manufacturer = cboManufacturer.SelectedValue
            PreDefine.Model = cboModel.SelectedValue
            PreDefine.RMA = txtRMA.Text
            PreDefine.Qty = txtQuantity.Text
            PreDefine.PRL = txtPRL.Text
            PreDefine.IP = txtIP.Text
            PreDefine.SKU = txtSKU.Text

            PreDefine.SaveData()

            populateTree()

        End Sub

        Private Sub cboManufacturer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedValueChanged

            Try
                If initLoad = True Then
                    If Len(Trim(cboManufacturer.Text)) > 0 Then
                        PreDefine.Manufacturer = cboManufacturer.SelectedValue
                        getModelList()
                        cboModel.Text = ""
                    End If
                End If
            Catch ex As Exception
            End Try

        End Sub

    End Class

End Namespace
