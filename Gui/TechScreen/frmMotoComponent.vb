Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]

Namespace Gui.techscreen

    Public Class frmMotoComponent
        Inherits System.Windows.Forms.Form

        Private dtBillCode As DataTable
        Private dtRefDes As DataTable
        Private dtFailureCode As DataTable
        Private dtpartData As DataTable
        Private vTray As Int32
        Private vDevice As String
        Private vDeviceID As Int32
        Private vModel As Int32

        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal dtPD As DataTable, ByVal TrayID As Int32, ByVal ModelID As Int32, ByVal sDevice As String, ByVal DeviceID As Int32)
            MyBase.New()

            dtpartData = dtPD
            vTray = TrayID
            vDevice = sDevice
            vDeviceID = DeviceID
            vModel = ModelID

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
        Friend WithEvents lblQuantity As System.Windows.Forms.Label
        Friend WithEvents lblRefDes As System.Windows.Forms.Label
        Friend WithEvents lblRefDesNum As System.Windows.Forms.Label
        Friend WithEvents lblFailCode As System.Windows.Forms.Label
        Friend WithEvents txtQuantity As System.Windows.Forms.NumericUpDown
        Friend WithEvents cboRefDes As System.Windows.Forms.ComboBox
        Friend WithEvents txtRefDesNum As System.Windows.Forms.TextBox
        Friend WithEvents cboFailCode As System.Windows.Forms.ComboBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAddComponent As System.Windows.Forms.Button
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblBillCode As System.Windows.Forms.Label
        Friend WithEvents cboBillCode As System.Windows.Forms.ComboBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMotoComponent))
            Me.lblBillCode = New System.Windows.Forms.Label()
            Me.lblQuantity = New System.Windows.Forms.Label()
            Me.lblRefDes = New System.Windows.Forms.Label()
            Me.lblRefDesNum = New System.Windows.Forms.Label()
            Me.lblFailCode = New System.Windows.Forms.Label()
            Me.cboBillCode = New System.Windows.Forms.ComboBox()
            Me.txtQuantity = New System.Windows.Forms.NumericUpDown()
            Me.cboRefDes = New System.Windows.Forms.ComboBox()
            Me.txtRefDesNum = New System.Windows.Forms.TextBox()
            Me.cboFailCode = New System.Windows.Forms.ComboBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnAddComponent = New System.Windows.Forms.Button()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblBillCode
            '
            Me.lblBillCode.Location = New System.Drawing.Point(16, 48)
            Me.lblBillCode.Name = "lblBillCode"
            Me.lblBillCode.Size = New System.Drawing.Size(120, 16)
            Me.lblBillCode.TabIndex = 0
            Me.lblBillCode.Text = "Bill Code(Part#):"
            Me.lblBillCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblQuantity
            '
            Me.lblQuantity.Enabled = False
            Me.lblQuantity.Location = New System.Drawing.Point(16, 72)
            Me.lblQuantity.Name = "lblQuantity"
            Me.lblQuantity.Size = New System.Drawing.Size(120, 16)
            Me.lblQuantity.TabIndex = 0
            Me.lblQuantity.Text = "Quantity:"
            Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDes
            '
            Me.lblRefDes.Location = New System.Drawing.Point(16, 96)
            Me.lblRefDes.Name = "lblRefDes"
            Me.lblRefDes.Size = New System.Drawing.Size(120, 16)
            Me.lblRefDes.TabIndex = 0
            Me.lblRefDes.Text = "Reference Designator:"
            Me.lblRefDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRefDesNum
            '
            Me.lblRefDesNum.Location = New System.Drawing.Point(16, 120)
            Me.lblRefDesNum.Name = "lblRefDesNum"
            Me.lblRefDesNum.Size = New System.Drawing.Size(120, 16)
            Me.lblRefDesNum.TabIndex = 0
            Me.lblRefDesNum.Text = "Ref. Des. Number:"
            Me.lblRefDesNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFailCode
            '
            Me.lblFailCode.Location = New System.Drawing.Point(16, 144)
            Me.lblFailCode.Name = "lblFailCode"
            Me.lblFailCode.Size = New System.Drawing.Size(120, 16)
            Me.lblFailCode.TabIndex = 0
            Me.lblFailCode.Text = "Failure Code:"
            Me.lblFailCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboBillCode
            '
            Me.cboBillCode.Location = New System.Drawing.Point(136, 48)
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.Size = New System.Drawing.Size(160, 21)
            Me.cboBillCode.TabIndex = 0
            '
            'txtQuantity
            '
            Me.txtQuantity.Enabled = False
            Me.txtQuantity.Location = New System.Drawing.Point(136, 72)
            Me.txtQuantity.Name = "txtQuantity"
            Me.txtQuantity.Size = New System.Drawing.Size(40, 20)
            Me.txtQuantity.TabIndex = 1
            Me.txtQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'cboRefDes
            '
            Me.cboRefDes.Location = New System.Drawing.Point(136, 96)
            Me.cboRefDes.Name = "cboRefDes"
            Me.cboRefDes.Size = New System.Drawing.Size(160, 21)
            Me.cboRefDes.TabIndex = 2
            '
            'txtRefDesNum
            '
            Me.txtRefDesNum.Location = New System.Drawing.Point(136, 120)
            Me.txtRefDesNum.Name = "txtRefDesNum"
            Me.txtRefDesNum.Size = New System.Drawing.Size(40, 20)
            Me.txtRefDesNum.TabIndex = 3
            Me.txtRefDesNum.Text = ""
            '
            'cboFailCode
            '
            Me.cboFailCode.Location = New System.Drawing.Point(136, 144)
            Me.cboFailCode.Name = "cboFailCode"
            Me.cboFailCode.Size = New System.Drawing.Size(160, 21)
            Me.cboFailCode.TabIndex = 4
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(136, 208)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(48, 23)
            Me.btnCancel.TabIndex = 7
            Me.btnCancel.Text = "Cancel"
            '
            'btnAddComponent
            '
            Me.btnAddComponent.Location = New System.Drawing.Point(192, 208)
            Me.btnAddComponent.Name = "btnAddComponent"
            Me.btnAddComponent.Size = New System.Drawing.Size(96, 23)
            Me.btnAddComponent.TabIndex = 6
            Me.btnAddComponent.Text = "Add Component"
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
            Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(232, 24)
            Me.PictureBox1.TabIndex = 8
            Me.PictureBox1.TabStop = False
            '
            'Panel2
            '
            Me.Panel2.Location = New System.Drawing.Point(0, 192)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(128, 40)
            Me.Panel2.TabIndex = 10
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(192, 176)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(88, 23)
            Me.Button1.TabIndex = 11
            Me.Button1.Text = "Labor"
            '
            'frmMotoComponent
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(296, 237)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Panel2, Me.PictureBox1, Me.btnAddComponent, Me.btnCancel, Me.cboFailCode, Me.txtRefDesNum, Me.cboRefDes, Me.txtQuantity, Me.cboBillCode, Me.lblFailCode, Me.lblRefDesNum, Me.lblRefDes, Me.lblQuantity, Me.lblBillCode})
            Me.Name = "frmMotoComponent"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "Motorola Add Component"
            CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region



        Private Sub btnAddComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddComponent.Click

            Dim x As frmTechScreen

            '//Get intial values
            Dim valBillCode As Integer
            Dim valRefDes As Integer
            Dim valFailureCode As Integer

            valBillCode = 0
            valRefDes = 0
            valFailureCode = 0

            Dim xCount As Integer = 0
            Dim r As DataRow
            'BillCode
            For xCount = 0 To dtBillCode.Rows.Count - 1
                r = dtBillCode.Rows(xCount)
                If r("BillCode_Desc") = Me.cboBillCode.Text Then
                    valBillCode = r("BillCode_ID")
                    Exit For
                End If
            Next
            'RefDes
            For xCount = 0 To dtRefDes.Rows.Count - 1
                r = dtRefDes.Rows(xCount)
                If r("Dcode_LDesc") = Me.cboRefDes.Text Then
                    valRefDes = r("Dcode_ID")
                    Exit For
                End If
            Next
            'FailureCode
            For xCount = 0 To dtFailureCode.Rows.Count - 1
                r = dtFailureCode.Rows(xCount)
                If r("Dcode_LDesc") = Me.cboFailCode.Text Then
                    valFailureCode = r("Dcode_ID")
                    Exit For
                End If
            Next

            'Get Part Data Information
            _device.AddPart(valBillCode)


            'Try
            ''x.datagrid.Clear()
            'Catch ex As Exception
            'End Try
            'Dim dtP As New PSS.Data.Production.Joins()
            'Dim dtParts As DataTable = dtP.GenericSelect("select lbillcodes.billcode_desc, tdevicebill.* from (tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) WHERE tdevicebill.device_id=" & vDeviceID & " ORDER BY BillCode_Desc")

            'Dim xcount As Integer = 0
            'Dim r As DataRow
            'Dim dr1 As DataRow

            'For xcount = 0 To dtParts.Rows.Count - 1
            'r = dtParts.Rows(xCount)
            'dr1 = x.datagrid.NewRow()
            'dr1("PartNum") = r("billcode_desc")
            'x.datagrid.Rows.Add(dr1)
            'Next

            'Update tdevice date bill
            MsgBox("Entered")
            'Dim dtUpDev As New PSS.Data.Production.tdevice()
            'Dim blnUpd As Boolean = dtUpDev.UpdateBillDateByDevice(vDeviceID, PSS.Gui.Receiving.General.FormatDate(Now))




        End Sub

        Private Sub frmMotoComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            loadGroup("Reference Designator", "DCode_LDesc", cboRefDes)
            loadGroup("Failure", "DCode_LDesc", cboFailCode)
            loadBillCodes()
            Me.LoadTray()
            Me.LoadDevice()

        End Sub

        Private Sub loadGroup(ByVal valType As String, ByVal valField As String, ByVal valCtrl As Control)

            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT * FROM " & _
            "(lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) " & _
            "WHERE MCode_DESC = '" & valType & "' AND lcodesdetail.manuf_ID=1 ORDER BY " & valField)

            If valType = "Reference Designator" Then
                dtRefDes = mthdGrp
            ElseIf valType = "Failure" Then
                dtFailureCode = mthdGrp
            End If

            If valCtrl.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                Dim xCount As Integer = 0
                Dim r As DataRow
                For xCount = 0 To mthdGrp.Rows.Count - 1
                    r = mthdGrp.Rows(xCount)
                    CType(valCtrl, ComboBox).Items.Add(r(valField))
                Next
            End If

            mthdGrp.Dispose()
            mthdGrp = Nothing

        End Sub

        Private Sub loadBillCodes()

            Dim mthd As New PSS.Data.Production.Joins()

            Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.* FROM (lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id) WHERE tpsmap.model_id = " & vModel)
            dtBillCode = mthdGrp
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To mthdGrp.Rows.Count - 1
                r = mthdGrp.Rows(xCount)
                cboBillCode.Items.Add(r("BillCode_DESC"))
            Next

            mthdGrp.Dispose()
            mthdGrp = Nothing

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        End Sub

        Private Sub cboBillCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillCode.SelectedIndexChanged

        End Sub


        Private Sub LoadTray()

            If IsNumeric(vTray) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(vTray)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                    'DoDeviceFields()
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub

        Private Sub LoadDevice()
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(vDevice) & "'")
                _device = New Device(__device(0)("Device_ID"))
                'Me.dbgParts.DataSource = _device.DefaultView
                'DoPartsFields()
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(vDevice) Then
                        Exit For
                    End If
                Next
                'Me.dbgDevices.MoveRelative(0, i)
                'Me.dbgDevices.Row = i
                'Me.lblCust.Text = _device.Customer
                'If _device.EndUser = True Then LockPrint(True)

                'txtDevice.Text = UCase(txtDevice.Text)
                'txtPart.Focus()
            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
                ' Me.dbgParts.DataSource = Nothing
                'LockPrint(False)
                'Me.lblCust.Text = ""
                'txtDevice.Text = ""
            End Try
        End Sub

        Private Sub HotKeysF12()
            'If e.KeyCode = Keys.F12 Then
            If Len(Trim(vTray)) > 0 Then
                If Len(Trim(vDeviceID)) > 0 Then
                    'If Len(Trim(txtPart.Text)) > 0 Then
                    'txtPart.Text = ""
                    'End If
                    UpdateBilling()
                    'Me.dbgParts.DataSource = Nothing
                    '_device.Dispose()
                    '_device = Nothing
                    'Me.lblCust.Text = ""
                    'If Me._printOnF9 = True Then
                    '    Me.btnPrintDevice.Enabled = False
                    'End If
                    'txtDevice.Text = ""
                    'txtDevice.Focus()
                End If
            End If
            'End If
        End Sub

        Private Sub UpdateBilling()
            Try 'here in case there is not refrence to _device
                _device.Update()
                Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
                If _device.Parts.Rows.Count = 0 Then
                    d(0)("Device_DateBill") = DBNull.Value
                Else
                    d(0)("Device_DateBill") = Now
                End If
                d = Nothing
                _device.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
            End Try
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            HotKeysF12()
            MsgBox("Entered")

        End Sub
    End Class

End Namespace
