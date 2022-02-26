'Imports PSS.Gui.MotorolaSubcontract.frmMotoSubContShipping
Namespace Gui.MotorolaSubcontract
    Public Class frmReprint
        Inherits System.Windows.Forms.Form
        Private objMotoSubContShipping As frmMotoSubContShipping
        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
        'Private iWO_ID As Integer
        Private iCust_ID As Integer = 0
        Private iLoc_ID As Integer = 0
        Private iProcessType As Integer = 0
        Private iPrintPallettManifest As Integer = 0
        Private iPallettQty As Integer = 0
        Private iMasterPackQty As Integer = 0
        Private iOverPackQty As Integer = 0
        Private iPrintMasterManifest As Integer = 0
        Private iPrintCoffinLabel As Integer = 0
        Private iPrintMasterLabel As Integer = 0
        Private iPrintOverPackManifest As Integer = 0
        Private iPrintOverPackLbl As Integer = 0
        Private iPrintPallettLbl As Integer = 0
        Private strPallettManifestName As String = ""
        Private strCoffinLabelPrinter As String = ""
        Private strCoffinLabelName As String = ""
        Private strMasterLblPrinter As String = ""
        Private strMasterManifestName As String = ""
        Private strMasterLblName As String = ""
        Private strOverPackManifestName As String = ""
        Private strOverPackLblPrinter As String = ""
        Private strPallettLabelName As String = ""
        Private strOverPackLblName As String = ""
        Private strPallettLblPrinter As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            'Me.WO_ID = WO_ID

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
        Friend WithEvents cboPrintJobs As System.Windows.Forms.ComboBox
        Friend WithEvents txtInput As System.Windows.Forms.TextBox
        Friend WithEvents lblInput As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents cboProcess As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboPrintJobs = New System.Windows.Forms.ComboBox()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.lblInput = New System.Windows.Forms.Label()
            Me.txtInput = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboProcess = New System.Windows.Forms.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(16, 128)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(144, 24)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "What to Print:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPrintJobs
            '
            Me.cboPrintJobs.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.cboPrintJobs.ForeColor = System.Drawing.SystemColors.ControlText
            Me.cboPrintJobs.Location = New System.Drawing.Point(168, 128)
            Me.cboPrintJobs.Name = "cboPrintJobs"
            Me.cboPrintJobs.Size = New System.Drawing.Size(225, 21)
            Me.cboPrintJobs.TabIndex = 1
            '
            'btnReprint
            '
            Me.btnReprint.BackColor = System.Drawing.Color.Transparent
            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.Black
            Me.btnReprint.Location = New System.Drawing.Point(200, 216)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(75, 32)
            Me.btnReprint.TabIndex = 2
            Me.btnReprint.Text = "Reprint"
            '
            'lblInput
            '
            Me.lblInput.BackColor = System.Drawing.Color.Transparent
            Me.lblInput.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInput.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblInput.Location = New System.Drawing.Point(16, 160)
            Me.lblInput.Name = "lblInput"
            Me.lblInput.Size = New System.Drawing.Size(144, 24)
            Me.lblInput.TabIndex = 3
            Me.lblInput.Text = "Ship ID:"
            Me.lblInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInput
            '
            Me.txtInput.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.txtInput.ForeColor = System.Drawing.SystemColors.ControlText
            Me.txtInput.Location = New System.Drawing.Point(168, 160)
            Me.txtInput.Name = "txtInput"
            Me.txtInput.Size = New System.Drawing.Size(223, 20)
            Me.txtInput.TabIndex = 4
            Me.txtInput.Text = ""
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Transparent
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(280, 216)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 32)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "Cancel"
            '
            'cboCustomer
            '
            Me.cboCustomer.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.cboCustomer.ForeColor = System.Drawing.SystemColors.ControlText
            Me.cboCustomer.Location = New System.Drawing.Point(168, 16)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(225, 21)
            Me.cboCustomer.TabIndex = 6
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(16, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(144, 24)
            Me.Label2.TabIndex = 7
            Me.Label2.Text = "Customer:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProcess
            '
            Me.cboProcess.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.cboProcess.ForeColor = System.Drawing.SystemColors.ControlText
            Me.cboProcess.Location = New System.Drawing.Point(168, 48)
            Me.cboProcess.Name = "cboProcess"
            Me.cboProcess.Size = New System.Drawing.Size(128, 21)
            Me.cboProcess.TabIndex = 8
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(16, 48)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(144, 24)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "Process Type:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.cboLocation.ForeColor = System.Drawing.SystemColors.ControlText
            Me.cboLocation.Location = New System.Drawing.Point(168, 79)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(225, 21)
            Me.cboLocation.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(16, 79)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(144, 24)
            Me.Label4.TabIndex = 11
            Me.Label4.Text = "Location:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmReprint
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSkyBlue
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(546, 271)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cboLocation, Me.Label3, Me.cboProcess, Me.Label2, Me.cboCustomer, Me.btnCancel, Me.txtInput, Me.lblInput, Me.btnReprint, Me.cboPrintJobs, Me.Label1})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmReprint"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Reprint Manifests/Labels"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private iIndex As Integer

        'Public Property WO_ID()
        '    Get
        '        Return Me.iWO_ID
        '    End Get
        '    Set(ByVal Value)
        '        Me.iWO_ID = Value
        '    End Set
        'End Property

        Private Sub cboPrintJobs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrintJobs.SelectedIndexChanged
            Dim response As MsgBoxResult

            Me.txtInput.Text = ""

            Select Case Me.cboPrintJobs.Text
                Case "MasterPack Shipping Manifest"
                    Me.lblInput.Text = "Input Ship Id:"
                    Me.txtInput.Text = ""
                    iIndex = 0

                Case "Coffin Box Labels"

                    response = MsgBox("Would you like to print all 10 Coffin Box Labels instead of 1?", MsgBoxStyle.YesNoCancel, "Coffin Box Labels (10 or 1)")
                    Me.txtInput.Text = ""
                    If response = MsgBoxResult.Yes Then
                        Me.lblInput.Text = "Input Ship Id:"
                        iIndex = 1
                    ElseIf response = MsgBoxResult.No Then
                        Me.lblInput.Text = "Input Device SN:"
                        iIndex = 2
                    Else
                        'Cancel
                        Me.cboPrintJobs.Text = ""
                    End If

                Case "MasterPack Label"
                    Me.lblInput.Text = "Input Ship Id:"
                    Me.txtInput.Text = ""
                    iIndex = 3

                Case "OverPack Shipping Manifest"
                    Me.lblInput.Text = "Input OverPack Id:"
                    Me.txtInput.Text = ""
                    iIndex = 4

                Case "Overpack Label"
                    Me.lblInput.Text = "Input OverPack Id:"
                    Me.txtInput.Text = ""
                    iIndex = 5

                Case "Pallett Manifest"
                    Me.lblInput.Text = "Input Pallett Id:"
                    Me.txtInput.Text = ""
                    iIndex = 6

                Case "RUR/BER/RNR Label"
                    Me.lblInput.Text = "Input Ship Id:"
                    Me.txtInput.Text = ""
                    'iIndex = 7
                    iIndex = 3          'tlocamap has RUR label setup as master label under Process Type = 1 or 2. So iIndex is set to 3 which prints master label

            End Select
        End Sub

        Private Sub frmReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '*******************************************
            Me.cboProcess.Items.Add("")
            Me.cboProcess.Items.Add("Regular")
            Me.cboProcess.Items.Add("RUR")
            Me.cboProcess.Items.Add("BER")
            Me.cboProcess.Items.Add("RTM")

            '*******************************************
            Me.cboPrintJobs.Items.Add("")
            Me.cboPrintJobs.Items.Add("MasterPack Shipping Manifest")
            Me.cboPrintJobs.Items.Add("OverPack Shipping Manifest")
            Me.cboPrintJobs.Items.Add("Pallett Manifest")
            Me.cboPrintJobs.Items.Add("Coffin Box Labels")
            Me.cboPrintJobs.Items.Add("MasterPack Label")
            Me.cboPrintJobs.Items.Add("Overpack Label")
            Me.cboPrintJobs.Items.Add("RUR/BER/RNR Label")
            '*******************************************
            FillCustomerComboBox()
            '*******************************************
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
            Me.Dispose()
        End Sub

        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            Dim strFormula As String
            Dim iRet As Integer
            Dim dtDeviceIDs As DataTable
            Dim R1 As DataRow
            Dim strHex As String = ""
            'Dim iOP As Integer = 0

            Cursor.Current = Cursors.WaitCursor
            Me.btnReprint.Enabled = False

            'Null Value Validation
            If Me.cboProcess.Text = "" Then
                MsgBox("Please select a process type.", MsgBoxStyle.Information, "Reprint")
                Cursor.Current = Cursors.Default
                Me.btnReprint.Enabled = True
                Exit Sub
            End If
            If Me.cboCustomer.Text = "" Then
                MsgBox("Please select a Customer.", MsgBoxStyle.Information, "Reprint")
                Cursor.Current = Cursors.Default
                Me.btnReprint.Enabled = True
                Exit Sub
            End If
            If Me.cboLocation.Text = "" Then
                MsgBox("Please select a Location.", MsgBoxStyle.Information, "Reprint")
                Cursor.Current = Cursors.Default
                Me.btnReprint.Enabled = True
                Exit Sub
            End If
            If Me.cboPrintJobs.Text = "" Then
                MsgBox("Please select what to print.", MsgBoxStyle.Information, "Reprint")
                Cursor.Current = Cursors.Default
                Me.btnReprint.Enabled = True
                Exit Sub
            End If
            If Me.txtInput.Text = "" Then
                MsgBox("Enter a value to print the selected Manifest or Label.", MsgBoxStyle.Information, "Reprint")
                Cursor.Current = Cursors.Default
                Me.btnReprint.Enabled = True
                Exit Sub
            End If

            Try
                '******************************************************************************
                objMotoSubContShipping = New frmMotoSubContShipping(0)   'Sending 0 for nothing. No reason.
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()

                Select Case iIndex
                    Case 0      '"MasterPack Shipping Manifest"
                        'Numeric Validation
                        If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                            MsgBox("Enter a numeric value for Ship ID.", MsgBoxStyle.Information, "Reprint")
                            Exit Sub
                        End If
                        If iPrintMasterManifest = 1 Then
                            'Print
                            strFormula = "{tdevice.Ship_ID} = " & CInt(Trim(Me.txtInput.Text))
                            'iRet = objMotoSubContShipping.Print("Default on WCCELLULAR", True, "Ship_Manifest.rpt", strFormula, 2)
                            iRet = objMotoSubContShipping.Print("", True, strMasterManifestName, strFormula, 2, , , 4)
                            strFormula = ""
                        End If
                    Case 1      'All 10 Coffin Box labels
                        'Numeric Validation
                        If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                            MsgBox("Enter a numeric value for Ship ID.", MsgBoxStyle.Information, "Reprint")
                            Exit Sub
                        End If
                        If iPrintCoffinLabel = 1 Then
                            'Get All Device IDs for a given Ship_ID
                            dtDeviceIDs = objMotoSubcontract_Biz.GetAllDeviceIDsForShipID(CInt(Trim(Me.txtInput.Text)))

                            Dim i
                            i = dtDeviceIDs.Rows.Count()

                            'Print
                            For Each R1 In dtDeviceIDs.Rows
                                strHex = ""
                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                'Get HEX Number
                                If GetModel(R1("Device_ID")) = 743 Then
                                    strHex = InputBox("Scan ESN HEX number.", "Reprint")
                                End If
                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                strFormula = "{tdevice.Device_ID} = " & R1("Device_ID")
                                'Asif
                                'iRet = objMotoSubContShipping.Print("PARALLEL1 on FP10196F", False, "Ship_CoffinBox_Label.rpt", strFormula, 1)
                                iRet = objMotoSubContShipping.Print(strCoffinLabelPrinter, False, strCoffinLabelName, strFormula, 1, iLoc_ID, iProcessType, 1, strHex)
                                strFormula = ""
                            Next
                        End If

                    Case 2      'Just 1 Coffin Box Label

                        Dim message, title, defaultValue As String
                        Dim strMasterPackNo As String = ""

                        If iPrintCoffinLabel = 1 Then
                            message = "Enter Masterpack No."                ' Set prompt.
                            title = "Reprint"                     ' Set title.
                            defaultValue = ""                               ' Set default value.

                            strMasterPackNo = InputBox(message, title, defaultValue)      'INput Masterpack No which is also Ship_id

                            If Not IsNumeric(strMasterPackNo) Then
                                MsgBox("Please enter a numeric value for Masterpack No.", MsgBoxStyle.Information, "Reprint")
                                Exit Sub
                            End If

                            'Get Device ID for a given device serial number in wo
                            dtDeviceIDs = objMotoSubcontract_Biz.Get_DeviceID_For_Device_SN_and_Ship_ID(CInt(strMasterPackNo), Trim(Me.txtInput.Text))

                            If dtDeviceIDs.Rows.Count = 0 Then
                                MsgBox("No valid data found for the information entered.", MsgBoxStyle.Information, "Reprint")
                                Exit Sub
                            End If

                            'Print
                            For Each R1 In dtDeviceIDs.Rows     'There will only be one row
                                strHex = ""
                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                'Get HEX Number
                                If GetModel(R1("Device_ID")) = 743 Then
                                    strHex = InputBox("Scan ESN HEX number.", "Reprint")
                                End If
                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                strFormula = "{tdevice.Device_ID} = " & R1("Device_ID")
                                'Asif
                                'iRet = objMotoSubContShipping.Print("PARALLEL1 on FP10196F", False, "Ship_CoffinBox_Label.rpt", strFormula, 1)
                                iRet = objMotoSubContShipping.Print(strCoffinLabelPrinter, False, strCoffinLabelName, strFormula, 1, iLoc_ID, iProcessType, 1, strHex)
                                strFormula = ""
                                Exit For
                            Next
                        End If

                    Case 3      '"MasterPack Label"
                            'Numeric Validation
                            If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                                MsgBox("Enter a numeric value for Ship ID.", MsgBoxStyle.Information, "Reprint")
                                Exit Sub
                            End If
                            If iPrintMasterLabel = 1 Then
                                'Print
                                strFormula = "{tdevice.Ship_ID} = " & CInt(Trim(Me.txtInput.Text))
                                'Asif
                            iRet = objMotoSubContShipping.Print(strMasterLblPrinter, False, strMasterLblName, strFormula, 1, , , 2)
                                'iRet = objMotoSubContShipping.Print("PARALLEL4 on FP10196F", False, "Ship_Master_Label.rpt", strFormula, 1)
                                strFormula = ""
                            End If

                    Case 4      '"OverPack Shipping Manifest"
                            'Numeric Validation
                            If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                                MsgBox("Enter a numeric value for OverPack ID.", MsgBoxStyle.Information, "Reprint")
                                Exit Sub
                            End If
                            If iPrintOverPackManifest = 1 Then
                                'Print
                                strFormula = "{toverpack.overpack_ID} = " & CInt(Trim(Me.txtInput.Text))
                                'iRet = objMotoSubContShipping.Print("Default on WCCELLULAR", True, "Ship_Manifest_OverPack.rpt", strFormula, 2)
                            iRet = objMotoSubContShipping.Print("", True, strOverPackManifestName, strFormula, 2, , , 5)
                                strFormula = ""
                            End If

                    Case 5      '"Overpack Label"
                            'Numeric Validation
                            If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                                MsgBox("Enter a numeric value for OverPack ID.", MsgBoxStyle.Information, "Reprint")
                                Exit Sub
                            End If
                            If iPrintOverPackLbl = 1 Then
                                'Print
                                strFormula = "{tship.OverPack_ID} = " & CInt(Trim(Me.txtInput.Text))
                                'Asif
                            iRet = objMotoSubContShipping.Print(strOverPackLblPrinter, False, strOverPackLblName, strFormula, 1, , , 3)
                                'iRet = objMotoSubContShipping.Print("PARALLEL4 on FP10196F", False, "Ship_OverPack_Label.rpt", strFormula, 1)
                                'iRet = objMotoSubContShipping.Print("PARALLEL4 on FP10196F", False, "Ship_OverPack_Label_New.rpt", strFormula, 1)
                                'iRet = objMotoSubContShipping.Print("Zebra170Xi on CELLBILL", False, "Ship_OverPack_Label.rpt", strFormula, 1)
                                strFormula = ""
                            End If

                    Case 6      '"Pallett Manifest"
                            'Numeric Validation
                            If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                                MsgBox("Enter a numeric value for Pallett ID.", MsgBoxStyle.Information, "Reprint")
                                Me.txtInput.Text = ""
                                Exit Sub
                            End If
                            If iPrintPallettManifest = 1 Then
                                'Print
                                strFormula = "{tpallett.Pallett_ID} = " & CInt(Trim(Me.txtInput.Text))
                                'iRet = objMotoSubContShipping.Print("Default on WCCELLULAR", True, "Ship_Manifest_Pallett.rpt", strFormula, 2)
                            iRet = objMotoSubContShipping.Print("", True, strPallettManifestName, strFormula, 3, , , 6)
                                strFormula = ""
                            End If

                            '''Case 7      'RUR/BER/RNR Label
                            '''    'Numeric Validation
                            '''    If Not IsNumeric(Trim(Me.txtInput.Text)) Then
                            '''        MsgBox("Enter a numeric value for Ship ID.", MsgBoxStyle.Information, "Reprint")
                            '''        Me.txtInput.Text = ""
                            '''        Exit Sub
                            '''    End If

                            '''    strFormula = "{tdevice.Ship_ID} = " & CInt(Trim(Me.txtInput.Text))
                            '''    'Asif
                            '''    'iRet = objMotoSubContShipping.Print("PARALLEL2 on FP10196F", False, "Ship_RUR_BER_RNR_Label.rpt", strFormula, 1)
                            '''    iRet = objMotoSubContShipping.Print("PARALLEL2 on FP10196F", False, strMasterLblName, strFormula, 1)
                            '''    strFormula = ""
                End Select

            Catch ex As Exception
                MsgBox("frmReprint.btnReprint_Click: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally

                If Not IsNothing(objMotoSubcontract_Biz) Then
                    objMotoSubcontract_Biz = Nothing
                End If
                If Not IsNothing(objMotoSubContShipping) Then
                    objMotoSubContShipping = Nothing
                End If
                If Not IsNothing(dtDeviceIDs) Then
                    If Not IsDBNull(dtDeviceIDs) Then
                        dtDeviceIDs.Dispose()
                    End If
                    dtDeviceIDs = Nothing
                End If

                Me.btnReprint.Enabled = True
                Cursor.Current = Cursors.Default

                'Set the Globals to empty and Empty the controls here
                iCust_ID = 0
                iLoc_ID = 0
                iProcessType = 0
                iPrintPallettManifest = 0
                iPallettQty = 0
                iMasterPackQty = 0
                iOverPackQty = 0
                iPrintMasterManifest = 0
                iPrintCoffinLabel = 0
                iPrintMasterLabel = 0
                iPrintOverPackManifest = 0
                iPrintOverPackLbl = 0
                iPrintPallettLbl = 0
                strPallettManifestName = ""
                strCoffinLabelPrinter = ""
                strCoffinLabelName = ""
                strMasterLblPrinter = ""
                strMasterManifestName = ""
                strMasterLblName = ""
                strOverPackManifestName = ""
                strOverPackLblPrinter = ""
                strPallettLabelName = ""
                strOverPackLblName = ""
                strPallettLblPrinter = ""

                Me.cboCustomer.Text = ""
                Me.cboProcess.Text = ""
                Me.cboLocation.Text = ""
                Me.cboPrintJobs.Text = ""
                Me.txtInput.Text = ""

            End Try

        End Sub

        '****************************************************************
        'Gets the process type for ATCLE label printing
        '****************************************************************
        'Private Function GetProcessType(ByVal iDevID As Integer) As Integer

        '    Dim dt As DataTable
        '    Dim R1 As DataRow
        '    Dim i As Integer

        '    Try
        '        objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
        '        dt = objMotoSubcontract_Biz.IsDeviceRTM(iDevID)

        '        For Each R1 In dt.Rows
        '            i = R1("iCount")
        '            Exit For
        '        Next R1

        '        Select Case iLoc_ID
        '            Case 2540   ''ATCLE-AWS customer, location id is 2540
        '                If i > 0 Then
        '                    i = 5   'Magic number  ;)   '5 - RTM
        '                Else
        '                    i = iProcessType      '0 - Good, 1 - RUR
        '                End If
        '            Case Else   'For Motorola-NSC which is the only other customer this screen was designed for
        '                i = iProcessType          '0 - Good, 1 - RUR
        '        End Select

        '        Return i
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        R1 = Nothing
        '        '******************************
        '        'Destroy the datatable
        '        '******************************
        '        If Not IsNothing(dt) Then
        '            If Not IsDBNull(dt) Then
        '                dt.Dispose()
        '            End If
        '            dt = Nothing
        '        End If
        '        '******************************
        '        objMotoSubcontract_Biz = Nothing
        '    End Try

        'End Function


        '***************************************************************************
        'Fill Customer Combo Box
        '***************************************************************************
        Private Sub FillCustomerComboBox()
            Dim dt As DataTable
            Dim R1 As DataRow

            Try

                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCustomers

                Me.cboCustomer.DataSource = dt.DefaultView
                Me.cboCustomer.DisplayMember = dt.Columns("cust_name1").ToString
                Me.cboCustomer.ValueMember = dt.Columns("cust_id").ToString
                Me.cboCustomer.SelectedValue = 0         'Hardcoded for the NSC customer
                '**************************************************
            Catch ex As Exception
                MsgBox("frmReprint.FillCustomerComboBox: " & ex.Message.ToString, MsgBoxStyle.Critical, "Motorola NSC Shipping")
            Finally
                R1 = Nothing
                '*****************************
                'Destroy the datatable
                '*****************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                objMotoSubcontract_Biz = Nothing
            End Try
        End Sub
        '***********************************************************************************************
        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted

            Try
                'Clear the controls


                iCust_ID = Me.cboCustomer.SelectedValue     'Set the customer
                FillLocationComboBox()          'Fill the location combo box

            Catch ex As Exception
                MsgBox("frmReprint.cboCustomer_SelectionChangeCommitted: " & ex.Message.ToString)
            End Try

        End Sub

        '***********************************************************************************************
        Private Sub cboProcess_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProcess.SelectionChangeCommitted
            Select Case Trim(Me.cboProcess.SelectedItem)
                Case ""
                    iProcessType = -1
                Case "Regular"
                    iProcessType = 0
                Case "RUR"
                    iProcessType = 1
                Case "BER"
                    iProcessType = 2
                Case "RTM"
                    iProcessType = 4
            End Select

            Me.cboLocation.Text = ""
            Me.cboPrintJobs.Text = ""
            Me.txtInput.Text = ""
        End Sub

        '****************************************************************
        'This fills the Location combo box
        '***************************************************************************
        Private Sub FillLocationComboBox()

            Dim R1 As DataRow
            Dim dtLoc As DataTable

            Try

                If Not IsNothing(dtLoc) Then
                    dtLoc.Dispose()
                    dtLoc = Nothing
                End If

                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dtLoc = objMotoSubcontract_Biz.GetLocationsForCustomer(iCust_ID)

                '**************************************************
                'Fill the Customer combo box
                '**************************************************
                Me.cboLocation.DataSource = dtLoc.DefaultView
                Me.cboLocation.ValueMember = dtLoc.Columns("Loc_id").ToString
                Me.cboLocation.DisplayMember = dtLoc.Columns("Loc_Name").ToString
                Me.cboLocation.SelectedValue = 0

                '**************************************************
            Catch ex As Exception
                MsgBox("frmReprint.FillLocationComboBox: " & ex.Message.ToString, MsgBoxStyle.Critical, "Motorola NSC Shipping")
            Finally
                If Not IsNothing(dtLoc) Then
                    dtLoc.Dispose()
                    dtLoc = Nothing
                End If
                objMotoSubcontract_Biz = Nothing

            End Try
        End Sub

        Private Sub cboLocation_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectionChangeCommitted

            Dim R1 As DataRow
            Dim dt As DataTable

            Try

                If Me.cboProcess.Text = "" Then
                    MsgBox("Please select a process type.", MsgBoxStyle.Information, "Reprint")
                    Exit Sub
                End If

                iLoc_ID = Me.cboLocation.SelectedValue

                '********************************************
                'This gets the labels, reports and other 
                'Location specific information
                '********************************************

                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetLabelInfo(iLoc_ID, iProcessType)

                For Each R1 In dt.Rows

                    'Coffinbox related info
                    If Not IsDBNull(R1("LocMap_CoffinLabel")) Then
                        strCoffinLabelName = R1("LocMap_CoffinLabel")
                    End If
                    If Not IsDBNull(R1("CoffinLabelPrinter")) Then
                        strCoffinLabelPrinter = R1("CoffinLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_CoffinPrt")) Then
                        iPrintCoffinLabel = R1("LocMap_CoffinPrt")
                    End If

                    'Master Manifest related Info
                    If Not IsDBNull(R1("LocMap_MasterManifest")) Then
                        strMasterManifestName = R1("LocMap_MasterManifest")
                    End If
                    If Not IsDBNull(R1("LocMap_MasterManPrt")) Then
                        iPrintMasterManifest = R1("LocMap_MasterManPrt")
                    End If

                    'Master Label related info
                    If Not IsDBNull(R1("LocMap_MasterLabel")) Then
                        strMasterLblName = R1("LocMap_MasterLabel")
                    End If
                    If Not IsDBNull(R1("MasterLabelPrinter")) Then
                        strMasterLblPrinter = R1("MasterLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_MasterLblPrt")) Then
                        iPrintMasterLabel = R1("LocMap_MasterLblPrt")
                    End If
                    If Not IsDBNull(R1("LocMap_MasterQnt")) Then
                        iMasterPackQty = R1("LocMap_MasterQnt")
                    End If

                    'Overpack Manifest related info
                    If Not IsDBNull(R1("LocMap_OverManifest")) Then
                        strOverPackManifestName = R1("LocMap_OverManifest")
                    End If
                    If Not IsDBNull(R1("LocMap_OverManPrt")) Then
                        iPrintOverPackManifest = R1("LocMap_OverManPrt")
                    End If

                    'Overpack Label related info
                    If Not IsDBNull(R1("LocMap_OverLabel")) Then
                        strOverPackLblName = R1("LocMap_OverLabel")
                    End If
                    If Not IsDBNull(R1("OverpackLabelPrinter")) Then
                        strOverPackLblPrinter = R1("OverpackLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_OverLblPrt")) Then
                        iPrintOverPackLbl = R1("LocMap_OverLblPrt")
                    End If
                    If Not IsDBNull(R1("LocMap_OverQnt")) Then
                        iOverPackQty = R1("LocMap_OverQnt")
                    End If

                    'Pallett Manifest related info
                    If Not IsDBNull(R1("LocMap_PallettManifest")) Then
                        strPallettManifestName = R1("LocMap_PallettManifest")
                    End If
                    If Not IsDBNull(R1("LocMap_PallettManPrt")) Then
                        iPrintPallettManifest = R1("LocMap_PallettManPrt")
                    End If

                    'Pallett Label related info
                    If Not IsDBNull(R1("LocMap_PallettLabel")) Then
                        strPallettLabelName = R1("LocMap_PallettLabel")
                    End If
                    If Not IsDBNull(R1("PallettLabelPrinter")) Then
                        strPallettLblPrinter = R1("PallettLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_PallettLblPrt")) Then
                        iPrintPallettLbl = R1("LocMap_PallettLblPrt")
                    End If
                    If Not IsDBNull(R1("LocMap_PallettQnt")) Then
                        iPallettQty = R1("LocMap_PallettQnt")
                    End If

                Next R1
                '********************************************
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.BtnPrint_Click.ObjFrm.ShowDialog(): " & ex.Message.ToString)
            Finally

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                objMotoSubcontract_Biz = Nothing
            End Try


            '********************************************


        End Sub

        Private Function GetModel(ByVal idev_id As Integer) As Integer
            objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
            Dim dt As New DataTable()
            Dim R1 As DataRow
            Dim iModId As Integer = 0

            Try
                dt = objMotoSubcontract_Biz.GetDeviceInfo(idev_id)

                For Each R1 In dt.Rows
                    iModId = R1("Model_ID")
                    Exit For
                Next R1

                Return iModId

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                objMotoSubcontract_Biz = Nothing
            End Try

        End Function

    End Class
End Namespace
