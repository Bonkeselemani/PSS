Imports PSS.Core
Imports PSS.Data

Namespace Gui.Receiving

    Public Class frmTechScreen
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
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents grpPartDetail As System.Windows.Forms.GroupBox
        Friend WithEvents cboRepairCode As System.Windows.Forms.ComboBox
        Friend WithEvents cboDefectCode As System.Windows.Forms.ComboBox
        Friend WithEvents cboCustomerComplaint As System.Windows.Forms.ComboBox
        Friend WithEvents txtPartCode As System.Windows.Forms.TextBox
        Friend WithEvents lblRepairCode As System.Windows.Forms.Label
        Friend WithEvents lblDefectCode As System.Windows.Forms.Label
        Friend WithEvents lblCustomerComplaint As System.Windows.Forms.Label
        Friend WithEvents lblPartCode As System.Windows.Forms.Label
        Friend WithEvents lblPartCodeError As System.Windows.Forms.Label
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents chkKeyRepair As System.Windows.Forms.CheckBox
        Friend WithEvents grpWrty As System.Windows.Forms.GroupBox
        Friend WithEvents txtHardwareVersion As System.Windows.Forms.TextBox
        Friend WithEvents txtSoftwareVersion As System.Windows.Forms.TextBox
        Friend WithEvents lblHardwareVersion As System.Windows.Forms.Label
        Friend WithEvents lblSoftwareVersion As System.Windows.Forms.Label
        Friend WithEvents dtGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents btnNewDevice As System.Windows.Forms.Button
        Friend WithEvents btnNewTray As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnExit As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTechScreen))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.dtGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.grpPartDetail = New System.Windows.Forms.GroupBox()
            Me.btnExit = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnNewTray = New System.Windows.Forms.Button()
            Me.chkKeyRepair = New System.Windows.Forms.CheckBox()
            Me.btnNewDevice = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.lblPartCodeError = New System.Windows.Forms.Label()
            Me.cboRepairCode = New System.Windows.Forms.ComboBox()
            Me.cboDefectCode = New System.Windows.Forms.ComboBox()
            Me.cboCustomerComplaint = New System.Windows.Forms.ComboBox()
            Me.txtPartCode = New System.Windows.Forms.TextBox()
            Me.lblRepairCode = New System.Windows.Forms.Label()
            Me.lblDefectCode = New System.Windows.Forms.Label()
            Me.lblCustomerComplaint = New System.Windows.Forms.Label()
            Me.lblPartCode = New System.Windows.Forms.Label()
            Me.grpWrty = New System.Windows.Forms.GroupBox()
            Me.txtHardwareVersion = New System.Windows.Forms.TextBox()
            Me.txtSoftwareVersion = New System.Windows.Forms.TextBox()
            Me.lblHardwareVersion = New System.Windows.Forms.Label()
            Me.lblSoftwareVersion = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            CType(Me.dtGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpPartDetail.SuspendLayout()
            Me.grpWrty.SuspendLayout()
            Me.SuspendLayout()
            '
            'dtGrid
            '
            Me.dtGrid.AllowDelete = True
            Me.dtGrid.AllowFilter = True
            Me.dtGrid.AllowRowSelect = False
            Me.dtGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.dtGrid.AllowSort = True
            Me.dtGrid.CaptionHeight = 17
            Me.dtGrid.CollapseColor = System.Drawing.Color.Black
            Me.dtGrid.DataChanged = False
            Me.dtGrid.BackColor = System.Drawing.Color.Empty
            Me.dtGrid.ExpandColor = System.Drawing.Color.Black
            Me.dtGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.dtGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dtGrid.Location = New System.Drawing.Point(48, 40)
            Me.dtGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.dtGrid.Name = "dtGrid"
            Me.dtGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dtGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dtGrid.PreviewInfo.ZoomFactor = 75
            Me.dtGrid.PrintInfo.ShowOptionsDialog = False
            Me.dtGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.dtGrid.RowDivider = GridLines1
            Me.dtGrid.RowHeight = 15
            Me.dtGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.dtGrid.ScrollTips = False
            Me.dtGrid.Size = New System.Drawing.Size(680, 200)
            Me.dtGrid.TabIndex = 0
            Me.dtGrid.Text = "C1TrueDBGrid1"
            Me.dtGrid.PropBag = CType(resources.GetObject("dtGrid.PropBag"), String)
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(120, 264)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(40, 16)
            Me.lblTray.TabIndex = 1
            Me.lblTray.Text = "Tray"
            Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSN
            '
            Me.lblSN.Location = New System.Drawing.Point(40, 288)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(120, 16)
            Me.lblSN.TabIndex = 2
            Me.lblSN.Text = "Device Serial Number"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTray
            '
            Me.txtTray.Location = New System.Drawing.Point(160, 264)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.TabIndex = 1
            Me.txtTray.Text = ""
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Location = New System.Drawing.Point(160, 288)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.TabIndex = 2
            Me.txtDeviceSN.Text = ""
            '
            'grpPartDetail
            '
            Me.grpPartDetail.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.btnClear, Me.btnNewTray, Me.chkKeyRepair, Me.btnNewDevice, Me.btnAdd, Me.lblPartCodeError, Me.cboRepairCode, Me.cboDefectCode, Me.cboCustomerComplaint, Me.txtPartCode, Me.lblRepairCode, Me.lblDefectCode, Me.lblCustomerComplaint, Me.lblPartCode})
            Me.grpPartDetail.Location = New System.Drawing.Point(288, 256)
            Me.grpPartDetail.Name = "grpPartDetail"
            Me.grpPartDetail.Size = New System.Drawing.Size(440, 184)
            Me.grpPartDetail.TabIndex = 13
            Me.grpPartDetail.TabStop = False
            Me.grpPartDetail.Text = "Part Detail"
            '
            'btnExit
            '
            Me.btnExit.Location = New System.Drawing.Point(368, 152)
            Me.btnExit.Name = "btnExit"
            Me.btnExit.Size = New System.Drawing.Size(64, 23)
            Me.btnExit.TabIndex = 14
            Me.btnExit.Text = "E&xit"
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(272, 152)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(80, 23)
            Me.btnClear.TabIndex = 13
            Me.btnClear.Text = "&Clear Form"
            '
            'btnNewTray
            '
            Me.btnNewTray.Location = New System.Drawing.Point(184, 152)
            Me.btnNewTray.Name = "btnNewTray"
            Me.btnNewTray.Size = New System.Drawing.Size(80, 23)
            Me.btnNewTray.TabIndex = 12
            Me.btnNewTray.Text = "New &Tray"
            '
            'chkKeyRepair
            '
            Me.chkKeyRepair.Location = New System.Drawing.Point(128, 120)
            Me.chkKeyRepair.Name = "chkKeyRepair"
            Me.chkKeyRepair.Size = New System.Drawing.Size(80, 24)
            Me.chkKeyRepair.TabIndex = 9
            Me.chkKeyRepair.Text = "Key Repair"
            '
            'btnNewDevice
            '
            Me.btnNewDevice.Location = New System.Drawing.Point(96, 152)
            Me.btnNewDevice.Name = "btnNewDevice"
            Me.btnNewDevice.Size = New System.Drawing.Size(80, 23)
            Me.btnNewDevice.TabIndex = 11
            Me.btnNewDevice.Text = "New &Device"
            '
            'btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(8, 152)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(80, 23)
            Me.btnAdd.TabIndex = 10
            Me.btnAdd.Text = "&Add Record"
            '
            'lblPartCodeError
            '
            Me.lblPartCodeError.Location = New System.Drawing.Point(232, 24)
            Me.lblPartCodeError.Name = "lblPartCodeError"
            Me.lblPartCodeError.Size = New System.Drawing.Size(200, 16)
            Me.lblPartCodeError.TabIndex = 21
            '
            'cboRepairCode
            '
            Me.cboRepairCode.Location = New System.Drawing.Point(128, 96)
            Me.cboRepairCode.Name = "cboRepairCode"
            Me.cboRepairCode.Size = New System.Drawing.Size(256, 21)
            Me.cboRepairCode.TabIndex = 8
            '
            'cboDefectCode
            '
            Me.cboDefectCode.Location = New System.Drawing.Point(128, 72)
            Me.cboDefectCode.Name = "cboDefectCode"
            Me.cboDefectCode.Size = New System.Drawing.Size(256, 21)
            Me.cboDefectCode.TabIndex = 7
            '
            'cboCustomerComplaint
            '
            Me.cboCustomerComplaint.Location = New System.Drawing.Point(128, 48)
            Me.cboCustomerComplaint.Name = "cboCustomerComplaint"
            Me.cboCustomerComplaint.Size = New System.Drawing.Size(256, 21)
            Me.cboCustomerComplaint.TabIndex = 6
            '
            'txtPartCode
            '
            Me.txtPartCode.Location = New System.Drawing.Point(128, 24)
            Me.txtPartCode.Name = "txtPartCode"
            Me.txtPartCode.TabIndex = 5
            Me.txtPartCode.Text = ""
            '
            'lblRepairCode
            '
            Me.lblRepairCode.Location = New System.Drawing.Point(16, 96)
            Me.lblRepairCode.Name = "lblRepairCode"
            Me.lblRepairCode.Size = New System.Drawing.Size(112, 16)
            Me.lblRepairCode.TabIndex = 16
            Me.lblRepairCode.Text = "Repair Code"
            '
            'lblDefectCode
            '
            Me.lblDefectCode.Location = New System.Drawing.Point(16, 72)
            Me.lblDefectCode.Name = "lblDefectCode"
            Me.lblDefectCode.Size = New System.Drawing.Size(112, 16)
            Me.lblDefectCode.TabIndex = 15
            Me.lblDefectCode.Text = "Defect Code"
            '
            'lblCustomerComplaint
            '
            Me.lblCustomerComplaint.Location = New System.Drawing.Point(16, 48)
            Me.lblCustomerComplaint.Name = "lblCustomerComplaint"
            Me.lblCustomerComplaint.Size = New System.Drawing.Size(112, 16)
            Me.lblCustomerComplaint.TabIndex = 14
            Me.lblCustomerComplaint.Text = "Customer Complaint"
            '
            'lblPartCode
            '
            Me.lblPartCode.Location = New System.Drawing.Point(16, 24)
            Me.lblPartCode.Name = "lblPartCode"
            Me.lblPartCode.Size = New System.Drawing.Size(112, 16)
            Me.lblPartCode.TabIndex = 13
            Me.lblPartCode.Text = "Part Code"
            '
            'grpWrty
            '
            Me.grpWrty.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtHardwareVersion, Me.txtSoftwareVersion, Me.lblHardwareVersion, Me.lblSoftwareVersion})
            Me.grpWrty.Location = New System.Drawing.Point(40, 360)
            Me.grpWrty.Name = "grpWrty"
            Me.grpWrty.Size = New System.Drawing.Size(224, 80)
            Me.grpWrty.TabIndex = 18
            Me.grpWrty.TabStop = False
            Me.grpWrty.Text = "Warranty"
            Me.grpWrty.Visible = False
            '
            'txtHardwareVersion
            '
            Me.txtHardwareVersion.Location = New System.Drawing.Point(112, 48)
            Me.txtHardwareVersion.Name = "txtHardwareVersion"
            Me.txtHardwareVersion.TabIndex = 4
            Me.txtHardwareVersion.Text = ""
            '
            'txtSoftwareVersion
            '
            Me.txtSoftwareVersion.Location = New System.Drawing.Point(112, 24)
            Me.txtSoftwareVersion.Name = "txtSoftwareVersion"
            Me.txtSoftwareVersion.TabIndex = 3
            Me.txtSoftwareVersion.Text = ""
            '
            'lblHardwareVersion
            '
            Me.lblHardwareVersion.Location = New System.Drawing.Point(8, 48)
            Me.lblHardwareVersion.Name = "lblHardwareVersion"
            Me.lblHardwareVersion.Size = New System.Drawing.Size(100, 16)
            Me.lblHardwareVersion.TabIndex = 19
            Me.lblHardwareVersion.Text = "Hardware Version"
            Me.lblHardwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSoftwareVersion
            '
            Me.lblSoftwareVersion.Location = New System.Drawing.Point(8, 24)
            Me.lblSoftwareVersion.Name = "lblSoftwareVersion"
            Me.lblSoftwareVersion.Size = New System.Drawing.Size(100, 16)
            Me.lblSoftwareVersion.TabIndex = 18
            Me.lblSoftwareVersion.Text = "Software Version"
            Me.lblSoftwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblManufacturer
            '
            Me.lblManufacturer.Location = New System.Drawing.Point(552, 8)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(168, 23)
            Me.lblManufacturer.TabIndex = 19
            '
            'frmTechScreen
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(790, 491)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblManufacturer, Me.grpWrty, Me.grpPartDetail, Me.txtDeviceSN, Me.txtTray, Me.lblSN, Me.lblTray, Me.dtGrid})
            Me.Name = "frmTechScreen"
            Me.Text = "Technician Screen"
            CType(Me.dtGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpPartDetail.ResumeLayout(False)
            Me.grpWrty.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private arrDevicesByTray(100, 3) As String
        Private arrDeviceCount As Integer
        Private DeviceType As Integer
        Private arrCustomerComplaint(1000, 2) As String
        Private arrFailCodes(1000, 2) As String
        Private arrRepairCodes(1000, 2) As String
        Private tmpDevice As DataTable
        Private partID As Integer

        Private Sub txtTray_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTray.Leave

            Dim tblTray As New PSS.Data.Production.ttray()
            Dim drTray As DataRow
            Dim valWOID As Integer

            drTray = tblTray.GetDataRow(CInt(txtTray.Text))
            valWOID = drTray("WO_ID")
            If Len(valWOID) < 1 Then 'throw error
                txtTray.Focus()
                'PLACE ERROR HERE
                Exit Sub
            End If

            '//Make an array of devices for the tray
            Dim xCount As Integer = 0
            Dim tblDevices As New PSS.Data.Production.tdevice()
            Dim dtDevices As DataTable = tblDevices.GetDataTableByTrayOrdered(CInt(txtTray.Text))
            Dim drDevices As DataRow

            For xCount = 0 To dtDevices.Rows.Count - 1
                drDevices = dtDevices.Rows(xCount)
                arrDevicesByTray(xCount, 0) = drDevices("Device_SN")
                arrDevicesByTray(xCount, 1) = drDevices("Model_ID")
                If IsDBNull(drDevices("Device_ManufWrty")) = False Then
                    arrDevicesByTray(xCount, 2) = drDevices("Device_ManufWrty")
                Else
                    arrDevicesByTray(xCount, 2) = 0
                End If
                If IsDBNull(drDevices("Device_PSSWrty")) = False Then
                    arrDevicesByTray(xCount, 3) = drDevices("Device_PSSWrty")
                Else
                    arrDevicesByTray(xCount, 3) = 0
                End If
                arrDeviceCount = xCount
            Next

        End Sub

        Private Sub txtDeviceSN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeviceSN.Leave

            Dim xCount As Integer = 0
            Dim verDevice As Boolean
            Dim valManufacturer, valModel As Integer
            Dim valManufWrty, valPSSWrty As Integer

            '//Verify Device is part of tray
            verDevice = False
            For xCount = 0 To arrDeviceCount
                If arrDevicesByTray(xCount, 0) = Trim(txtDeviceSN.Text) Then
                    valModel = arrDevicesByTray(xCount, 1)
                    valManufWrty = arrDevicesByTray(xCount, 2)
                    valPSSWrty = arrDevicesByTray(xCount, 3)
                    verDevice = True
                    Exit For
                End If
            Next

            '//Get Manufacturer and Model values
            valManufacturer = 0
            '        Dim tblModel As New PSS.Data.Production.tmodel()
            '        Dim drModel As DataRow = tblModel.GetRowByModel(valModel)
            Dim tblModelJoin As New PSS.Data.Production.Joins()

            Dim dtModel As DataTable = tblModelJoin.TechScreenManufModelInfoByModel(valModel, 1)
            Dim drModel As DataRow
            For xCount = 0 To dtModel.Rows.Count - 1
                drModel = dtModel.Rows(xCount)
                valManufacturer = drModel("Manuf_ID")
            Next


            If Len(lblManufacturer.Text) < 1 Then
                lblManufacturer.Text = valManufacturer
                populateArrays(valManufacturer)
            ElseIf CInt(lblManufacturer.Text) = valManufacturer Then
                'DO NOT repopulate combo boxes the data is correct
                'It is a waste of resources
                'The business logic should not allow multiple manufacturers by tray
            Else
                lblManufacturer.Text = valManufacturer
                populateArrays(valManufacturer)
            End If


            '//Verify value for Device Serial Number
            Dim valVerify As Boolean
            Dim arrDeviceUBOUND As Integer = UBound(arrDevicesByTray)

            valVerify = False
            For xCount = 0 To arrDeviceUBOUND
                If arrDevicesByTray(xCount, 0) = txtDeviceSN.Text Then
                    valVerify = True
                    Exit For
                End If
            Next

            '//If serial number does not exists for tray then ERROR
            If valVerify = False Then
                MsgBox("The serial number entered does not exists for the tray selected. Please re-enter the serial number.", MsgBoxStyle.OKOnly, "No Serial Number for Tray")
                txtDeviceSN.Text = ""
                txtDeviceSN.Focus()
                Exit Sub
            End If

            '//If serial number is true for tray then verify not duplicate

            '//See if Wrty exists
            If valManufWrty = 1 Or valPSSWrty = 1 Then
                grpWrty.Visible = True
                txtSoftwareVersion.Focus()
                Exit Sub
            End If

            '//Set focus to part detail
            txtPartCode.Focus()

        End Sub

        Private Sub txtPartCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartCode.Leave

        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

            '//Verify data to be put into grid
            Dim msg As String = ""
            If Len(txtDeviceSN.Text) < 1 Then msg += "Device Serial Number missing." & vbCrLf
            If Len(txtPartCode.Text) < 1 Then msg += "Part Code not defined." & vbCrLf
            If Len(cboCustomerComplaint.Text) < 1 Then msg += "No Customer Complaint defined." & vbCrLf
            If Len(cboDefectCode.Text) < 1 Then msg += "No Defect Code defined." & vbCrLf
            If Len(cboRepairCode.Text) < 1 Then msg += "No Repair Code defined."
            If Len(Trim(msg)) > 0 Then
                MsgBox("The following errors have occurred: " & vbCrLf & msg & vbCrLf & "The add con not continue...Exiting", MsgBoxStyle.OKOnly, "Error WithData")
                Exit Sub
            End If

            '//Validate parts are not duplicated in grid
            Dim xCount As Integer = 0
            Dim drDup As DataRow

            For xCount = 0 To tmpDevice.Rows.Count - 1
                drDup = tmpDevice.Rows(xCount)
                If drDup("PartCode") = txtPartCode.Text Then
                    MsgBox("This part is already entered for this device. Please select a new part code.", MsgBoxStyle.OKOnly, "Duplicate Part")
                    txtPartCode.Focus()
                    Exit Sub
                End If
            Next

            '//Write data to grid

            Dim dr As DataRow = tmpDevice.NewRow
            dr("DeviceSN") = txtDeviceSN.Text
            dr("PartCode") = txtPartCode.Text
            dr("PartCodeID") = partID
            dr("CustomerComplaint") = arrCustomerComplaint(cboCustomerComplaint.SelectedIndex, 1)
            dr("CustomerComplaintID") = arrCustomerComplaint(cboCustomerComplaint.SelectedIndex, 2)
            dr("DefectCode") = arrFailCodes(cboDefectCode.SelectedIndex, 1)
            dr("DefectCodeID") = arrFailCodes(cboDefectCode.SelectedIndex, 2)
            dr("RepairCode") = arrRepairCodes(cboRepairCode.SelectedIndex, 1)
            dr("RepairCodeID") = arrRepairCodes(cboRepairCode.SelectedIndex, 2)
            If chkKeyRepair.Checked = True Then
                dr("KeyRepair") = "YES"
            Else
                dr("KeyRepair") = "NO"
            End If
            tmpDevice.Rows.Add(dr)
            dtGrid.MoveLast()


            '//Clear device data on form
            txtTray.ReadOnly = True
            txtDeviceSN.ReadOnly = True

            txtPartCode.Text = ""
            cboCustomerComplaint.Text = ""
            cboDefectCode.Text = ""
            cboRepairCode.Text = ""
            chkKeyRepair.Checked = False
            txtPartCode.Focus()


            '//Repopulate grid for tray
            dtGrid.DataSource = tmpDevice

        End Sub


        Private Sub txtTray_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTray.TextChanged

        End Sub

        Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged



        End Sub

        Private Sub populateArrays(ByVal valManufacturer As Integer)

            '//Populate arrays that hold information for
            'Device Serial Numbers for Tray
            'Customer Complaint Codes for Manufacturer
            Dim tblComplaint As New PSS.Data.Production.tcomplaint()
            Dim dtComplaint As DataTable = tblComplaint.TechScreenComplaintList(valManufacturer, 1)
            Dim drComplaint As DataRow
            Dim xCount As Integer = 0

            For xCount = 0 To dtComplaint.Rows.Count - 1
                drComplaint = dtComplaint.Rows(xCount)
                cboCustomerComplaint.Items.Insert(xCount, drComplaint("Comp_Desc"))
                arrCustomerComplaint(xCount, 0) = drComplaint("Comp_Desc")
                arrCustomerComplaint(xCount, 1) = drComplaint("Comp_Code")
                arrCustomerComplaint(xCount, 2) = drComplaint("Comp_ID")
            Next

            'Defect Codes for Manufacturer
            Dim tblFailCodes As New PSS.Data.Production.tfailcodes()
            Dim dtFailCodes As DataTable = Buisness.WarrantyClaim.FailCodesRepairCodes.GetFailCodesListAllCols(valManufacturer, 1)
            Dim drFailCodes As DataRow
            For xCount = 0 To dtFailCodes.Rows.Count - 1
                drFailCodes = dtFailCodes.Rows(xCount)
                Me.cboDefectCode.Items.Insert(xCount, drFailCodes("Fail_SDesc"))
                arrFailCodes(xCount, 0) = drFailCodes("Fail_SDesc")
                arrFailCodes(xCount, 1) = drFailCodes("Fail_LDesc")
                arrFailCodes(xCount, 2) = drFailCodes("Fail_ID")
            Next

            'Repair Codes for Manufacturer
            Dim tblRepairCodes As New PSS.Data.Production.lrepaircodes()
            Dim dtRepairCodes As DataTable = tblRepairCodes.TechScreenRepairList(valManufacturer, 1)
            Dim drRepairCodes As DataRow
            For xCount = 0 To dtRepairCodes.Rows.Count - 1
                drRepairCodes = dtRepairCodes.Rows(xCount)
                cboRepairCode.Items.Insert(xCount, drRepairCodes("Repair_SDesc"))
                arrRepairCodes(xCount, 0) = drRepairCodes("Repair_SDesc")
                arrRepairCodes(xCount, 1) = drRepairCodes("Repair_LDesc")
                arrRepairCodes(xCount, 2) = drRepairCodes("Repair_ID")
            Next

        End Sub


        Private Sub frmTechScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            tmpDevice = CreateTmpDevice()
            grpWrty.Visible = False
            txtTray.Focus()
            Highlight.SetHighLight(Me)      '//Highlights currently selected control

        End Sub

        Private Sub txtPartCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartCode.TextChanged

        End Sub

        Private Function CreateTmpDevice() As DataTable

            Dim dtDeviceTmp As New DataTable("tmpDevice")
            dtDeviceTmp.MinimumCapacity = 500
            dtDeviceTmp.CaseSensitive = False
            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtDeviceTmp.Columns.Add(dcDeviceSN)
            Dim dcPartCode As New DataColumn("PartCode")
            dtDeviceTmp.Columns.Add(dcPartCode)
            Dim dcCustomerComplaint As New DataColumn("CustomerComplaint")
            dtDeviceTmp.Columns.Add(dcCustomerComplaint)
            Dim dcDefectCode As New DataColumn("DefectCode")
            dtDeviceTmp.Columns.Add(dcDefectCode)
            Dim dcRepairCode As New DataColumn("RepairCode")
            dtDeviceTmp.Columns.Add(dcRepairCode)
            Dim dcKeyRepair As New DataColumn("KeyRepair")
            dtDeviceTmp.Columns.Add(dcKeyRepair)

            Dim dcPartCodeID As New DataColumn("PartCodeID")
            dtDeviceTmp.Columns.Add(dcPartCodeID)
            Dim dcCustomerComplaintID As New DataColumn("CustomerComplaintID")
            dtDeviceTmp.Columns.Add(dcCustomerComplaintID)
            Dim dcDefectCodeID As New DataColumn("DefectCodeID")
            dtDeviceTmp.Columns.Add(dcDefectCodeID)
            Dim dcRepairCodeID As New DataColumn("RepairCodeID")
            dtDeviceTmp.Columns.Add(dcRepairCodeID)

            dtGrid.DataSource = dtDeviceTmp
            CreateTmpDevice = dtDeviceTmp

        End Function

        Private Sub txtPartCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartCode.Enter

            If grpWrty.Visible = True Then
                If Len(Trim(txtHardwareVersion.Text)) < 1 Then
                    txtHardwareVersion.Focus()
                    Exit Sub
                End If
                If Len(Trim(txtSoftwareVersion.Text)) < 1 Then
                    txtSoftwareVersion.Focus()
                    Exit Sub
                End If
            End If

        End Sub

        Private Sub btnNewDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDevice.Click

            '//Verify warranty type
            'If warranty type is Manufacture Warranty then
            '//Verify that at least one record has all fields entered
            'If warranty type is PSS Warranty then
            '//Verify all lines have part numbers - not duplicated
            'If warranty type is No Warranty then
            '//Verify all lines have part numbers - not duplicated

            '//Write data to database tables

            '//Clear data on form
            tmpDevice.Clear()
            txtSoftwareVersion.Text = ""
            txtHardwareVersion.Text = ""
            grpWrty.Visible = False
            txtPartCode.Text = ""
            cboCustomerComplaint.Text = ""
            cboDefectCode.Text = ""
            cboRepairCode.Text = ""
            chkKeyRepair.Checked = False

            txtDeviceSN.ReadOnly = False
            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

            '//Unload form

        End Sub

        Private Sub btnNewTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTray.Click

            '//Clear data on form
            dtGrid.ClearFields()
            txtSoftwareVersion.Text = ""
            txtHardwareVersion.Text = ""
            grpWrty.Visible = False
            txtPartCode.Text = ""
            cboCustomerComplaint.Text = ""
            cboCustomerComplaint.Items.Clear()
            cboDefectCode.Text = ""
            cboDefectCode.Items.Clear()
            cboRepairCode.Text = ""
            cboRepairCode.Items.Clear()
            chkKeyRepair.Checked = False
            txtDeviceSN.Text = ""
            txtTray.Text = ""


            txtDeviceSN.ReadOnly = False
            txtTray.ReadOnly = False
            txtTray.Focus()

        End Sub




        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            '//Clear data on form
            Try
                dtGrid.ClearFields()
                txtSoftwareVersion.Text = ""
                txtHardwareVersion.Text = ""
                grpWrty.Visible = False
                txtPartCode.Text = ""
                cboCustomerComplaint.Text = ""
                cboCustomerComplaint.Items.Clear()
                cboDefectCode.Text = ""
                cboDefectCode.Items.Clear()
                cboRepairCode.Text = ""
                cboRepairCode.Items.Clear()
                chkKeyRepair.Checked = False
            Catch

            End Try


        End Sub


        Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

            Me.Close()

        End Sub

        Private Sub cboCustomerComplaint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerComplaint.SelectedIndexChanged

        End Sub

        Private Sub cboCustomerComplaint_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomerComplaint.Enter

            Dim xCount As Integer = 0
            partID = 0
            Dim verParts As Boolean

            '//Verify value for Part Number
            'If Len(Trim(txtPartCode.Text)) < 1 Then
            'txtPartCode.Focus()
            'Exit Sub
            'End If
            '//Verify valid Part Number
            Dim tblParts As New PSS.Data.Production.lparts()
            Dim dtParts As DataTable = tblParts.TechScreenGetPartData(Trim(txtPartCode.Text))
            Dim drParts As DataRow
            For xCount = 0 To dtParts.Rows.Count - 1
                drParts = dtParts.Rows(xCount)
                partID = drParts("Parts_ID")
            Next

            If partID > 0 Then
                verParts = True
            Else
                verParts = False
                MsgBox("This part code does not exists. Please try again.", MsgBoxStyle.OKOnly, "No Part Defined")
                txtPartCode.Text = ""
                txtPartCode.Focus()
            End If

        End Sub

        Private Sub txtSoftwareVersion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoftwareVersion.TextChanged

        End Sub

        Private Sub txtHardwareVersion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHardwareVersion.TextChanged

        End Sub

        Private Sub txtHardwareVersion_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHardwareVersion.Leave

            txtPartCode.Focus()

        End Sub
    End Class
End Namespace
