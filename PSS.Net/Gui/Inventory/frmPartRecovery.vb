Option Explicit On 
Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO

Namespace Inventory
    Public Class frmPartRecovery
        Inherits System.Windows.Forms.Form

        Private _objPartRelated As New PSS.Data.Buisness.PartRelated()
        Private _objNewTech As New PSS.Data.Buisness.NewTech()
        Private _LocID As Integer = 0
        Private _MfgID As Integer = 0
        Private _ProdID As Integer = 0
        Private _CusID As Integer = 0
        Private _ModelID As Integer = 0
        Private _WOID As Integer = 0
        Private _DeviceID As Integer = 0
        Private _TrayID As Integer = 0
        Private _strScreenName As String = ""

        Private Const vBuffer As Integer = 5
        Private Const hBuffer As Integer = 5
        Private Const btnWidth = 120
        Private Const btnHeight = 50
        Private btnLeft As Int32 = 5
        Private btnTop As Int32 = 5
        Private pnlLeft As Integer
        Private pnlWidth As Integer
        Private colCount As Integer
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPartRelated = New PSS.Data.Buisness.PartRelated()
            Me._strScreenName = strScreenName

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
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents tabMain As System.Windows.Forms.TabControl
        Friend WithEvents tbParts As System.Windows.Forms.TabPage
        Friend WithEvents pnlPart As System.Windows.Forms.Panel
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents Status As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tbParts = New System.Windows.Forms.TabPage()
            Me.pnlPart = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Status = New System.Windows.Forms.Label()
            Me.tabMain.SuspendLayout()
            Me.tbParts.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(144, 64)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(184, 20)
            Me.txtSerial.TabIndex = 105
            Me.txtSerial.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.White
            Me.lblDeviceSN.Location = New System.Drawing.Point(8, 64)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(128, 16)
            Me.lblDeviceSN.TabIndex = 106
            Me.lblDeviceSN.Text = "Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnComplete.Location = New System.Drawing.Point(368, 56)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(128, 32)
            Me.btnComplete.TabIndex = 138
            Me.btnComplete.Text = "Complete"
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblTitle.BackColor = System.Drawing.Color.Black
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(896, 48)
            Me.lblTitle.TabIndex = 137
            Me.lblTitle.Text = "PARTS RECOVERY"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParts})
            Me.tabMain.Location = New System.Drawing.Point(8, 184)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(860, 496)
            Me.tabMain.TabIndex = 139
            '
            'tbParts
            '
            Me.tbParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlPart})
            Me.tbParts.Location = New System.Drawing.Point(4, 22)
            Me.tbParts.Name = "tbParts"
            Me.tbParts.Size = New System.Drawing.Size(852, 470)
            Me.tbParts.TabIndex = 0
            Me.tbParts.Text = "PARTS"
            '
            'pnlPart
            '
            Me.pnlPart.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlPart.AutoScroll = True
            Me.pnlPart.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlPart.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlPart.Location = New System.Drawing.Point(8, 16)
            Me.pnlPart.Name = "pnlPart"
            Me.pnlPart.Size = New System.Drawing.Size(840, 432)
            Me.pnlPart.TabIndex = 108
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnClear.Location = New System.Drawing.Point(512, 56)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(88, 32)
            Me.btnClear.TabIndex = 140
            Me.btnClear.Text = "&Clear"
            '
            'Status
            '
            Me.Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Status.Location = New System.Drawing.Point(16, 104)
            Me.Status.Name = "Status"
            Me.Status.Size = New System.Drawing.Size(848, 72)
            Me.Status.TabIndex = 149
            Me.Status.Text = "Status"
            '
            'frmPartRecovery
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(896, 694)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Status, Me.btnClear, Me.tabMain, Me.btnComplete, Me.txtSerial, Me.lblDeviceSN, Me.lblTitle})
            Me.Name = "frmPartRecovery"
            Me.Text = "frmPartRecovery"
            Me.tabMain.ResumeLayout(False)
            Me.tbParts.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading"

        '*******************************************************************
        Private Sub frmPartRecovery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            lblTitle.Text = Me._strScreenName
            ResetVariables()
            Status.ForeColor = Color.Lime
            Status.Text = "Please scan a valid serial number..."
        End Sub

        '*******************************************************************
        Private Function LoadData() As Boolean
            Dim booResult As Boolean = True
            Dim xCount As Integer
            Dim r As DataRow
            Dim dt As DataTable

            Try
                Me._LocID = 0
                Me._MfgID = 0
                Me._ProdID = 0
                Me._CusID = 0
                Me._ModelID = 0
                Me._TrayID = 0
                Me._WOID = 0


                dt = Me._objNewTech.GetDeviceInfo(Me._DeviceID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't define device's model.")
                    booResult = False
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Device ID existed more than one in the system.")
                    booResult = False
                Else

                    Me._LocID = dt.Rows(0)("Loc_ID")
                    Me._MfgID = dt.Rows(0)("Manuf_ID")
                    Me._ProdID = dt.Rows(0)("Prod_ID")
                    Me._CusID = dt.Rows(0)("cust_id")
                    Me._ModelID = dt.Rows(0)("Model_ID")
                    Me._TrayID = dt.Rows(0)("Tray_ID")
                    Me._WOID = dt.Rows(0)("WO_ID")

                    If Me._DeviceID = 0 Or Me._ModelID = 0 Or Me._WOID = 0 Or Me._CusID = 0 Or Me._MfgID = 0 Or Me._TrayID = 0 Then
                        Throw New Exception("Can not define Device ID/Model ID/WorkOrder ID /Customer ID /Mfg ID/Tray ID of this device.")
                        booResult = False
                    End If

                End If

                Return booResult

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************

        Private Sub LoadPartsList()
            Dim objPJoins As New PSS.Data.Production.Joins()
            Dim dtPartsList As DataTable

            Try

                dtPartsList = objPJoins.GenericSelect("SELECT lbillcodes.*,lpsprice.psprice_id , lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM " & _
                "lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                "AND tbilldisplayexceptions.cust_id = " & Me._CusID & " " & _
                "WHERE tpsmap.model_id = " & Me._ModelID & " " & _
                " AND billtype_id = 2 AND tpsmap.ReflowTypeID <> 4 " & _
                "AND lpsprice.psprice_consignedpart = 0 " & _
                "AND tpsmap.Inactive = 0 " & _
                "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & Me._CusID & ") " & _
                "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                "ORDER BY BillCode_Desc")

                Me.CreatePartButtons(dtPartsList)
                Me.HighlightSelectedParts()

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objPJoins) Then objPJoins = Nothing
                If Not IsNothing(dtPartsList) Then dtPartsList = Nothing
            End Try
        End Sub


#End Region

#Region "Button & Text"

        '*******************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '*******************************************************************

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            Me.ResetVariables()

        End Sub

        '*****************************************************************

        Private Sub btnParts_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim btName, PSPrice_ID As String
            Dim userID As Integer = PSS.Core.ApplicationUser.IDuser


            Try

                Me.Enabled = False
                btName = Trim(sender.text.ToString)
                PSPrice_ID = Trim(sender.tag.ToString)

                _objPartRelated.InsertRemovePartRecovery(Me._DeviceID, PSPrice_ID, userID)

                If CType(sender, Button).BackColor.ToString() = "Color [Orange]" Then
                    CType(sender, Button).BackColor = Color.LightGray
                    Status.Text = btName & " has been removed from part recovery list..."
                Else
                    CType(sender, Button).BackColor = Color.Orange
                    Status.Text = btName & " has been added to part recovery list..."
                End If
                'HighlightSelectedParts()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnParts_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally
                Me.Enabled = True
            End Try

        

        End Sub

        '*******************************************************************

        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            'Parts Recovery, Scrap: The operator selects parts from recycle unit,
            'in which he think they are good and can be reuse later.
            'The part labels will be print, billing for Part Recovery will be generate and
            'the rest of unrecoverable parts will move to recycle pallet.

            'Triage ,Scrap: No recovery parts is select, the whole device will be scrap,
            'billing for Triage/Scrap will be generate and
            'whole device will move to recycle pallet.


            Dim objPJoins As New PSS.Data.Production.Joins()
            Dim objDevice As Rules.Device
            Dim dtRecoveryParts As DataTable = objPJoins.GenericSelect("Select * From partrecovery WHERE Device_ID=" & Me._DeviceID & " ORDER BY PartRecovery_ID")
            Dim iRecoveryCount As Integer = 0
            Dim drRecoveryPart As DataRow
            Dim PartRecovery_ID As Integer
            Dim StrPalletName As String

            Try

                If dtRecoveryParts.Rows.Count > 0 Then
                    '*******************************
                    ' *** Parts Recovery, Scrap ****
                    '*******************************

                    'Print Part Recovery label
                    Status.Text = dtRecoveryParts.Rows.Count & " Recovery Part's label is being generated and print. Please wait..."
                    Application.DoEvents()
                    For iRecoveryCount = 0 To dtRecoveryParts.Rows.Count - 1
                        drRecoveryPart = dtRecoveryParts.Rows(iRecoveryCount)
                        PartRecovery_ID = drRecoveryPart("PartRecovery_ID")
                        _objPartRelated.Label_PrintPartsRecoveryLabel(PartRecovery_ID)
                    Next iRecoveryCount

                    'Create billing for Part Recovery ; BillCode_ID = 2135
                    Status.Text = "Billing Part Recovery for device serial#" & txtSerial.Text & " is being generated. Please wait..."
                    Application.DoEvents()
                    If Generic.IsBillcodeMapped(Me._ModelID, 2135) = 0 Then
                        Status.Text = "Device  serial#" & txtSerial.Text & " has not mapped to Part Recover. Please contact Material department"
                        Exit Sub
                    ElseIf Generic.IsBillcodeExisted(Me._DeviceID, 2135) = False Then
                        objDevice = New Rules.Device(Me._DeviceID)
                        objDevice.AddPart(2135)
                        objDevice.Update()
                    End If

                    'Move device to Recycle Pallet 
                    StrPalletName = Me.RecycleDevice()
                    Status.Text = "Device Serial#" & txtSerial.Text & " has been assigned to Recycle Pallet#" & StrPalletName _
                    & ". Please move all unrecoverable parts and device to Recycle Pallet#" & StrPalletName _
                    & ". Also, please apply labels onto appropriate recovery parts, then move them to QC Inspection Station."

                Else
                    '*******************************
                    ' ******* Triage, Scrap *********
                    '*******************************

                    'Create billing for Triage/Scrap device; BillCode_ID = 2134
                    Status.Text = "Billing Triage/Scrap for device serial#" & txtSerial.Text & " is being generated. Please wait..."
                    Application.DoEvents()
                    If Generic.IsBillcodeMapped(Me._ModelID, 2134) = 0 Then
                        Status.Text = "Device  serial#" & txtSerial.Text & " has not mapped to Triage, Scrap. Please contact Material department"
                        Exit Sub
                    ElseIf Generic.IsBillcodeExisted(Me._DeviceID, 2134) = False Then
                        objDevice = New Rules.Device(Me._DeviceID)
                        objDevice.AddPart(2134)
                        objDevice.Update()
                    End If
                    'Move device to Recycle Pallet 
                    StrPalletName = Me.RecycleDevice()
                    Status.Text = "Billing for Triage/Scrap device serial#" & txtSerial.Text & " has been generated." _
                    & " This device also assigned to Recycle Pallet#" & StrPalletName _
                    & ". Please move this device to recycle pallet."

                End If

                Me.ResetVariables()

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dtRecoveryParts)
                objPJoins = Nothing
                drRecoveryPart = Nothing

            End Try

        End Sub
#End Region

#Region "Functions & Subs"

        '*******************************************************************
        Private Sub ProcessSN()

            Try

                Me.txtSerial.Text = Me.txtSerial.Text.Trim.ToUpper
                '******************************

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                If DoValidation(txtSerial.Text) = False Then
                    Me.Enabled = True
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                Else
                    If LoadData() = False Then Exit Sub
                    Me.LoadPartsList()
                    Me.txtSerial.Enabled = False
                    Me.btnComplete.Visible = True
                    Status.Text = "PART RECOVERY/SCRAP: Toggle the 'Part' button to add/remove part recovery, then click on the 'Complete' button. Billing and label will be generated..." & vbCrLf & "TRIAGE/SCRAP: Click on 'Complete' button to generate billing... "
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = Cursors.Default
                Me.Enabled = True

            End Try
        End Sub

        '******************************************************************
        Private Sub HighlightSelectedParts()
            'Highlight part button that are selected

            Dim objPJoins As New PSS.Data.Production.Joins()
            Dim dtPartRecovery As DataTable = objPJoins.GenericSelect("Select * From partrecovery WHERE Device_ID=" & Me._DeviceID & " ORDER BY PartRecovery_ID")
            Dim iRecoveryCount, iPartCount As Integer
            Dim drPartRecovery As DataRow
            Dim btnPart As Button

            Try
                iRecoveryCount = 0 : iPartCount = 0

                'Reset Backcolor
                For iPartCount = 0 To Me.pnlPart.Controls.Count - 1
                    Me.pnlPart.Controls(iPartCount).BackColor = Color.LightGray
                Next iPartCount

                'Highlight the Recovery Parts
                For iRecoveryCount = 0 To dtPartRecovery.Rows.Count - 1
                    drPartRecovery = dtPartRecovery.Rows(iRecoveryCount)

                    'Part button panel
                    For iPartCount = 0 To pnlPart.Controls.Count - 1
                        btnPart = CType(pnlPart.Controls(iPartCount), System.Windows.Forms.Button)
                        With btnPart
                            If drPartRecovery("PSPrice_ID") = .Tag Then
                                btnPart.BackColor = Color.Orange
                                Exit For
                            End If

                        End With
                    Next iPartCount

                Next iRecoveryCount


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "HighlightSelectedParts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Buisness.Generic.DisposeDT(dtPartRecovery)
                objPJoins = Nothing
                drPartRecovery = Nothing

            End Try
        End Sub
      

        '*******************************************************************
        Private Function DoValidation(ByVal Serial As String) As Boolean

            Dim dtDevice As DataTable
            Dim objNewTech As New PSS.Data.Buisness.NewTech()
            Me._DeviceID = 0

            Try
                Status.ForeColor = Color.Red
                dtDevice = objNewTech.GetDeviceInWip(Serial, Me._CusID)
                If dtDevice.Rows.Count < 1 Then
                    Status.Text = "This device serial# " & Serial & " does not exist in the system or has been assigned to pallet or shipped."
                    Return False
                ElseIf dtDevice.Rows.Count > 1 Then
                    Status.Text = "This device serial# " & Serial & " existed more than one in the system. Please contact your lead or supervisor."
                    Return False
                    'ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    '    Status.Text = "This device serial#" & Serial & " has not been billed."
                    '    Return False
                Else
                    Me._DeviceID = (dtDevice.Rows(0)("Device_ID"))
                    Status.ForeColor = Color.Lime
                    Return True

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return False
            Finally
                Buisness.Generic.DisposeDT(dtDevice)
                objNewTech = Nothing

            End Try

        End Function

        '*******************************************************************
        Private Function DoValidationRefubished(ByVal Serial As String) As Boolean

            Dim iMaxBillRule As Integer = 0
            Dim dtPressure, dtHipot As DataTable
            Dim ojbMisc As New PSS.Data.Production.Misc()
            Dim ojbBill As New PSS.Data.Buisness.Generic()

            Try
                Status.ForeColor = Color.Red

                dtPressure = ojbMisc.GetDataTable("select * from lbillcodes where BillCode_ID=2131 and billtype_id=1 And device_id=" & Me._ProdID)
                dtHipot = ojbMisc.GetDataTable("select * from lbillcodes where BillCode_ID=2132 and billtype_id=1 And device_id=" & Me._ProdID)
                iMaxBillRule = ojbBill.GetMaxBillRule(Me._DeviceID)

                If dtPressure.Rows.Count < 1 Then
                    Status.Text = "This device serial# " & Serial & " hasn't pass Pressure test. Please move this device to Pressure Test Station or contact supervisor."
                    Return False
                ElseIf dtHipot.Rows.Count < 1 Then
                    Status.Text = "This device serial# " & Serial & " hasn't pass Hipot test. Please move this device to Hipot Test station or contact supervisor."
                    Return False
                ElseIf iMaxBillRule <> 0 Then
                    Status.Text = "This device serial# " & Serial & " is not belongs to refurbish. Please contact supervisor or IT department."
                    Return False
                ElseIf Generic.IsValidQCResults(Me._DeviceID, 1, "Functional", True, True) = False Then
                    Status.Text = "This device serial#" & Serial & " has not passed QC."
                    Return False
                Else
                    Status.ForeColor = Color.Lime
                    Return True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Return False
            Finally
                Buisness.Generic.DisposeDT(dtPressure)
                Buisness.Generic.DisposeDT(dtHipot)
                ojbMisc = Nothing
                ojbBill = Nothing


            End Try

        End Function

        '*****************************************************************
        Private Sub CreatePartButtons(ByVal dtPartsList As DataTable)

            Dim drPart As DataRow
            Dim colLength As Integer = 4
            Dim btnPart() As Button
            Dim x As Integer = 0
            Me.pnlPart.Controls.Clear()

            Try
                colCount = 0
                pnlLeft = pnlPart.Left
                pnlWidth = tabMain.Width - 48
                ReDim btnPart(dtPartsList.Rows.Count)
                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dtPartsList.Rows.Count - 1
                    drPart = dtPartsList.Rows(x)
                    btnPart(x) = New System.Windows.Forms.Button()
                    With btnPart(x)
                        .Text = drPart("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        .BackColor = Color.LightGray
                        .Tag = drPart("psprice_id") '
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.btnParts_Click
                    End With


                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If

                Next

                Me.pnlPart.Controls.AddRange(btnPart)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreatePartButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                drPart = Nothing
                btnPart = Nothing

            End Try
        End Sub

        '*****************************************************************

        Private Sub ResetVariables()

            'Clear global variable
            Me._DeviceID = 0
            Me._LocID = 0
            Me._MfgID = 0
            Me._ProdID = 0
            Me._CusID = 0
            Me._ModelID = 0
            Me._TrayID = 0
            Me._WOID = 0
            Me.pnlPart.Controls.Clear()
            Me.btnComplete.Visible = False
            Me.tabMain.Visible = True

            Me.txtSerial.Enabled = True
            Me.txtSerial.Text = ""
            Me.txtSerial.Focus()

        End Sub

        '********************************************************************************************************
        Private Function CreateRecyclePallet() As Integer

            Dim objShip As New PSS.Data.Production.Shipping()
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Dim iPalletID As Integer
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            Dim strdate As String = Format(CDate(strWorkDate), "MMddyy")
            Dim strPalletName, strLastAlphaInPallet As String
            Dim strShortCustDesc As String = PSS.Data.Buisness.Nespresso.Nespresso.ShortCustDesc
            Dim strShortModelName As String = Trim(objMisc.GetShortModelName(Me._ModelID))
            Const iPalletTypeID As Integer = 7      '7=Recycle
            Const iPalletBillRuleID As Integer = 1  '1=Recycle
            Const SkuLen As String = ""             'SKU is not use for Recycle device

            Try

                strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strShortCustDesc & strShortModelName, strdate)
                strPalletName = "NESCYL" & strdate & strLastAlphaInPallet
                iPalletID = objShip.CreatePallet(Me._CusID, Me._LocID, Me._ModelID, 0, strPalletName, iPalletBillRuleID, SkuLen, 0, 0, iPalletTypeID)
                If iPalletID = 0 Then
                    MessageBox.Show("System has failed to create Recycle Pallet. Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    'Close Recyle Pallet to prevent operator scan other serials into this box in frmBuildShipBox screen
                    objMisc.ClosePallet(Me._CusID, iPalletID, strPalletName, 0, )
                End If

                Return iPalletID

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmPartRecovery_CreateRecyclePallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                CreateRecyclePallet = 0

            Finally
                objMisc = Nothing
                objShip = Nothing
            End Try

        End Function

        '********************************************************************
        Private Function RecycleDevice() As String
            'Create Recycle Pallet if not existed then move device to Recycle Pallet. 

            Dim dtRecycle As DataTable
            Dim objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()
            Dim StrPalletName As String = ""
            Dim iPalletID As Integer

            Try

                dtRecycle = objNespresso.GetOpenRecyclePallet(Me._LocID, Me._CusID)
                If dtRecycle.Rows.Count = 0 Then
                    iPalletID = Me.CreateRecyclePallet()
                    dtRecycle = objNespresso.GetOpenRecyclePallet(Me._LocID, Me._CusID)
                Else
                    iPalletID = dtRecycle.Rows(0)("Pallett_ID")
                End If
                StrPalletName = dtRecycle.Rows(0)("Pallett_Name")
                PSS.Data.Production.Shipping.AssignDeviceToPallet(Me._DeviceID, iPalletID)
                RecycleDevice = StrPalletName

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmPartRecovery_RecycleDevice", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                RecycleDevice = ""

            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtRecycle)
                objNespresso = Nothing

            End Try

        End Function

        '********************************************************************

#End Region


     
    End Class



End Namespace