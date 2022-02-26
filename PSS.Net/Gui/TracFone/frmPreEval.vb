Option Explicit On 

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules

Namespace Gui.TracFone
    Public Class frmPreEval
        Inherits System.Windows.Forms.Form
        Private Const btnWidth = 120
        Private Const btnHeight = 50

        Private _iMenuCustID As Integer
        Private _strScreenName As String = ""
        Private _objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
        Private _dtAWAP As DataTable
        Private _device As Device = Nothing
        Private _objNewTech As PSS.Data.Buisness.NewTech

        Private tmpDeviceID, tmpModelID, tmpManufID, tmpProdID, tmpLoc, tmpCustID, tmpWO, tmpDeviceType, tmpConsignedParts, tmpCustCRbill As Integer

        ' Private origFrmWidth As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _strScreenName = strScreenName

            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
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
        Friend WithEvents tabMain As System.Windows.Forms.TabControl
        Friend WithEvents tbNeedPart As System.Windows.Forms.TabPage
        Friend WithEvents pnlNeededParts As System.Windows.Forms.Panel
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents tpNeedRVParts As System.Windows.Forms.TabPage
        Friend WithEvents pnlNeededRVParts As System.Windows.Forms.Panel
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tbNeedPart = New System.Windows.Forms.TabPage()
            Me.pnlNeededParts = New System.Windows.Forms.Panel()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.tpNeedRVParts = New System.Windows.Forms.TabPage()
            Me.pnlNeededRVParts = New System.Windows.Forms.Panel()
            Me.tabMain.SuspendLayout()
            Me.tbNeedPart.SuspendLayout()
            Me.tpNeedRVParts.SuspendLayout()
            Me.SuspendLayout()
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbNeedPart, Me.tpNeedRVParts})
            Me.tabMain.Location = New System.Drawing.Point(8, 51)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(976, 488)
            Me.tabMain.TabIndex = 111
            '
            'tbNeedPart
            '
            Me.tbNeedPart.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNeededParts})
            Me.tbNeedPart.Location = New System.Drawing.Point(4, 22)
            Me.tbNeedPart.Name = "tbNeedPart"
            Me.tbNeedPart.Size = New System.Drawing.Size(968, 462)
            Me.tbNeedPart.TabIndex = 3
            Me.tbNeedPart.Text = "Need Part(s)"
            Me.tbNeedPart.Visible = False
            '
            'pnlNeededParts
            '
            Me.pnlNeededParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededParts.AutoScroll = True
            Me.pnlNeededParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededParts.Name = "pnlNeededParts"
            Me.pnlNeededParts.Size = New System.Drawing.Size(952, 440)
            Me.pnlNeededParts.TabIndex = 110
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(112, 8)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(176, 20)
            Me.txtSerial.TabIndex = 109
            Me.txtSerial.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.Black
            Me.lblDeviceSN.Location = New System.Drawing.Point(24, 12)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(80, 16)
            Me.lblDeviceSN.TabIndex = 110
            Me.lblDeviceSN.Text = "Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Location = New System.Drawing.Point(912, 8)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 22)
            Me.btnClear.TabIndex = 121
            Me.btnClear.Text = "&Clear"
            '
            'btnComplete
            '
            Me.btnComplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(784, 8)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(112, 22)
            Me.btnComplete.TabIndex = 124
            Me.btnComplete.Text = "Complete Device"
            '
            'tpNeedRVParts
            '
            Me.tpNeedRVParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNeededRVParts})
            Me.tpNeedRVParts.Location = New System.Drawing.Point(4, 22)
            Me.tpNeedRVParts.Name = "tpNeedRVParts"
            Me.tpNeedRVParts.Size = New System.Drawing.Size(968, 462)
            Me.tpNeedRVParts.TabIndex = 4
            Me.tpNeedRVParts.Text = "Need RV Part(s)"
            '
            'pnlNeededRVParts
            '
            Me.pnlNeededRVParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededRVParts.AutoScroll = True
            Me.pnlNeededRVParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededRVParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededRVParts.Name = "pnlNeededRVParts"
            Me.pnlNeededRVParts.Size = New System.Drawing.Size(952, 440)
            Me.pnlNeededRVParts.TabIndex = 111
            '
            'frmPreEval
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(992, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnComplete, Me.btnClear, Me.tabMain, Me.txtSerial, Me.lblDeviceSN})
            Me.Name = "frmPreEval"
            Me.Text = "frmPreEval"
            Me.tabMain.ResumeLayout(False)
            Me.tbNeedPart.ResumeLayout(False)
            Me.tpNeedRVParts.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**********************************************************************************************************************
        Private Sub frmPreEval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me._objNewTech = New PSS.Data.Buisness.NewTech()
                '     origFrmWidth = Me.Width
                txtSerial.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmNewTech_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '**********************************************************************************************************************
        Private Sub ProcessSN()
            Dim ProdGrpCheck As New PSS.Data.Buisness.ProdGrpCheck()
            Dim objPretest As PSS.Data.Buisness.PreTest
            Dim val As Long = 0
            Dim bIsGSdevice, booCorrectStation As Boolean
            Dim strGSLotNum As String
            Dim strOriginalDeviceSN As String
            Dim dtPretestData As DataTable
            Dim strDevCurrWrkStation As String = ""
            Dim iDeviceCCID, iMachineCCID As Integer

            Try
                If PSS.Data.Buisness.Generic.GetMachineCostCenterID() = 0 Then
                    MessageBox.Show("This computer does not map to any cost center. Please contact your supervisor for advises.", "Computer Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                booCorrectStation = False
                '******************************
                'Clear controls and variables
                '******************************
                strOriginalDeviceSN = Me.txtSerial.Text.Trim.ToUpper
                Me.btnClear_Click(Nothing, Nothing)
                Me.txtSerial.Text = strOriginalDeviceSN
                '******************************

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                txtSerial.Text = txtSerial.Text.Trim.ToUpper  '//Format serial as all uppercase
                val = Me.verifySerialNumber(txtSerial.Text)

                If val = 0 Then
                    MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    MessageBox.Show("SN/IMEI existed more than one in the system. Please contact your lead or supervisor.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                Else
                    Me.tmpDeviceID = val
                    If getData() = False Then Exit Sub
                    If Me.tmpDeviceID > 0 Then
                        Me.LoadDevice()
                        loadBillCodes()
                        Me.HighLightSelectedButtons()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN KeyDownEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.btnClear_Click(Nothing, Nothing)
            Finally
                Cursor.Current = Cursors.Default : Me.Enabled = True
                ProdGrpCheck = Nothing : objPretest = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dtPretestData)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long
            Dim dt As DataTable
            Try
                dt = Me._objNewTech.GetDeviceInWip(mDeviceSN, Me._iMenuCustID)
                If dt.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf dt.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    Return dt.Rows(0)("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Private Function getData() As Boolean
            Dim booResult As Boolean = True
            Dim xCount As Integer
            Dim r As DataRow
            Dim dt As DataTable

            Try
                tmpModelID = 0 : tmpManufID = 0 : tmpProdID = 0 : tmpWO = 0 : tmpCustID = 0

                tmpCustCRbill = 0 : tmpDeviceType = 0
                tmpConsignedParts = 0
                _dtAWAP = New DataTable()

                If Me.tmpDeviceID = 0 Then Throw New Exception("Device ID is missing.")

                dt = Me._objNewTech.GetDeviceInfo(Me.tmpDeviceID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't define device's model.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Device ID existed more than one in the system.")
                Else
                    tmpModelID = dt.Rows(0)("Model_ID")
                    tmpManufID = dt.Rows(0)("Manuf_ID")
                    tmpProdID = dt.Rows(0)("Prod_ID")
                    tmpWO = dt.Rows(0)("WO_ID")
                    tmpLoc = dt.Rows(0)("Loc_ID")
                    tmpCustID = dt.Rows(0)("Cust_ID")
                    tmpCustCRbill = dt.Rows(0)("Cust_CRBilling")
                    tmpConsignedParts = dt.Rows(0)("cust_consignedparts")

                    If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                        Throw New Exception("Can not define Device ID/ Model ID/ Manufacturer ID of this device.")
                    End If

                    _dtAWAP = Me._objNewTech.GetSelectedAWAP(tmpDeviceID)
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Private Sub LoadDevice()
            Try
                _device = Nothing
                _device = New Device(Me.tmpDeviceID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************************
        Private Sub loadBillCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable
            Dim objBD As Buisness.DeviceBilling

            Try
                objBD = New Buisness.DeviceBilling()

                If tmpConsignedParts = 1 Then
                    'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 ORDER BY BillCode_Desc")
                    mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc")
                Else
                    mthdGrp = objBD.GetPartBillcodes(tmpCustID, tmpModelID, 5, , 0)
                End If

                createBillingButtons(mthdGrp, Me.pnlNeededParts)
                System.Windows.Forms.Application.DoEvents()

                Buisness.Generic.DisposeDT(mthdGrp)
                mthdGrp = objBD.GetPartBillcodes(tmpCustID, tmpModelID, 5, , 1)
                createBillingButtons(mthdGrp, Me.pnlNeededRVParts)
                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                Buisness.Generic.DisposeDT(mthdGrp)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.txtSerial.Enabled = True
                Me.pnlNeededParts.Controls.Clear()
                Me.pnlNeededRVParts.Controls.Clear()

                txtSerial.Text = ""

                Me.tmpDeviceID = 0 : Me.tmpModelID = 0 : Me.tmpManufID = 0 : Me.tmpProdID = 0 : Me.tmpWO = 0

                '//reset the bill tray feature

                tabMain.Visible = True

                'Clear global variable
                If Not IsNothing(Me._device) Then
                    Me._device.Dispose() : Me._device = Nothing
                End If

                'data table
                PSS.Data.Buisness.Generic.DisposeDT(Me._dtAWAP)

                txtSerial.Focus()
                Me.txtSerial.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub createBillingButtons(ByVal dt As DataTable, ByRef pnlButtons As Windows.Forms.Panel)
            Const vBuffer As Integer = 5
            Const hBuffer As Integer = 5
            Dim btnLeft As Int32 = 5
            Dim btnTop As Int32 = 5

            Dim r As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0, pnlLeft As Integer, pnlWidth As Integer, colCount As Integer

            Try
                '*************************************
                'Create need buttons
                '*************************************
                colCount = 0
                pnlLeft = pnlButtons.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()
                    With cBill(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        '*********************************************
                        'High light Consigned parts
                        '*********************************************
                        If r("PSPrice_ConsignedPart").ToString() = "1" Then
                            .BackColor = Color.Orange
                        Else
                            .BackColor = Color.LightSteelBlue
                        End If
                        '*********************************************

                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick_AWAP
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next

                pnlButtons.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                r = Nothing
                cBill = Nothing
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub billingClick_AWAP(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drBOMPart As DataRow
            'Dim x As Integer
            Dim action As String
            Dim strAddPartNo, strBilledPartNo, strCorrectPart As String
            Dim booRVPart As Boolean = False
            Dim R1 As DataRow

            Try
                strAddPartNo = "" : strBilledPartNo = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0

                '//Determine action to be performed
                action = "add"
                If Me._dtAWAP.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    drBOMPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)
                    strAddPartNo = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.ToLower
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If

                If iRVPart > 0 Then
                    MessageBox.Show("RV part should not listed in this tab. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf iConsignedPart > 0 Then
                    MessageBox.Show("Consigned part should not listed in this tab. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '*********************************
                If action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    '***************************************************
                    'RV, EOM and Consigned Parts validation 05/05/2011
                    '***************************************************
                    Exit Sub
                End If

                '//March 24, 2006
                Me.Enabled = False

                If action = "remove" Then   '//turn off
                    Me._objNewTech.DeleteDeviceBillAWAP(Me.tmpDeviceID, Trim(sender.tag.ToString))
                Else    '//turn on
                    R1 = Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)
                    Me._objNewTech.InsertIntoDeviceBillAWAP(Me.tmpDeviceID, drBOMPart("PSPrice_StndCost"), drBOMPart("PSPrice_AvgCost"), _
                    drBOMPart("PSPrice_StndCost"), (drBOMPart("PSPrice_StndCost") * (1 + (_device.CustMarkUp))), R1("Billcode_ID"), drBOMPart("PSPrice_Number"), _
                    1, Core.ApplicationUser.IDuser, iFailID, iRepairID, 0)
                End If

                '*******************************
                Me._dtAWAP = Me._objNewTech.GetSelectedAWAP(tmpDeviceID)
                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "billingClick_AWAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : dr1 = Nothing
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub HighLightSelectedButtons()
            Dim i As Integer = 0

            Try
                'pnlNeededParts
                For i = 0 To Me.pnlNeededParts.Controls.Count - 1
                    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlNeededRvParts
                For i = 0 To Me.pnlNeededRVParts.Controls.Count - 1
                    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededRVParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededRVParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededRVParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Function ValidateRVOEMAndConsighnedPartSelection(ByVal strAddingPartNo As String, _
                                                                ByVal iBillcodeID As Integer, _
                                                                ByVal iRVPart As Integer, _
                                                                ByVal iConsignedPart As Integer) As Boolean
            Dim booReturnVal As Boolean = True
            Dim R1 As DataRow

            Try
                'No need to check if part list is empty or adding part is a services
                If Me._device.Parts.Rows.Count = 0 OrElse Me._device.GetPartTypeID(iBillcodeID) = 1 Then Return True

                ValidateRVOEMAndConsighnedPartSelection = True

                For Each R1 In Me._device.Parts.Rows
                    If iRVPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_RV").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf iConsignedPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_TT").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_RV").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("RV part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_TT").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("Consigned part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    End If
                Next R1
                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim i As Integer = 0

            Try
                If Me.tmpDeviceID > 0 Then
                    i = Me._objNewTech.SetAWAPCompletedDate(tmpDeviceID)
                    If i > 0 Then Me.btnClear_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**********************************************************************************************************************


    End Class
End Namespace
