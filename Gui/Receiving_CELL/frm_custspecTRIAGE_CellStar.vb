Namespace Gui.pretest

    Public Class frm_custspecTRIAGE_CellStar
        Inherits System.Windows.Forms.Form


        Private ds As PSS.Data.Production.Joins
        Private r As DataRow
        Private strSQL As String
        Private strDevice As String


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
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblPSSI_Status As System.Windows.Forms.Label
        Friend WithEvents lblCellStar_Status As System.Windows.Forms.Label
        Friend WithEvents chkRepair As System.Windows.Forms.CheckBox
        Friend WithEvents chkNTF As System.Windows.Forms.CheckBox
        Friend WithEvents chkFlash As System.Windows.Forms.CheckBox
        Friend WithEvents chkCancelled As System.Windows.Forms.CheckBox
        Friend WithEvents chkVendor As System.Windows.Forms.CheckBox
        Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
        Friend WithEvents chkPhysicalDamage As System.Windows.Forms.CheckBox
        Friend WithEvents chkLiquidDamage As System.Windows.Forms.CheckBox
        Friend WithEvents lblIssues As System.Windows.Forms.Label
        Friend WithEvents lbox_issues As System.Windows.Forms.CheckedListBox
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblVendor As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblCellStar_Status = New System.Windows.Forms.Label()
            Me.lblPSSI_Status = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.chkRepair = New System.Windows.Forms.CheckBox()
            Me.chkNTF = New System.Windows.Forms.CheckBox()
            Me.chkFlash = New System.Windows.Forms.CheckBox()
            Me.chkCancelled = New System.Windows.Forms.CheckBox()
            Me.chkVendor = New System.Windows.Forms.CheckBox()
            Me.lblVendor = New System.Windows.Forms.Label()
            Me.cboVendor = New System.Windows.Forms.ComboBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lblIssues = New System.Windows.Forms.Label()
            Me.lbox_issues = New System.Windows.Forms.CheckedListBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.chkPhysicalDamage = New System.Windows.Forms.CheckBox()
            Me.chkLiquidDamage = New System.Windows.Forms.CheckBox()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Location = New System.Drawing.Point(168, 64)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(128, 20)
            Me.txtDeviceSN.TabIndex = 1
            Me.txtDeviceSN.Text = ""
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(72, 32)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomer.TabIndex = 0
            Me.cboCustomer.TabStop = False
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(16, 68)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(152, 16)
            Me.Label9.TabIndex = 44
            Me.Label9.Text = "Device: Serial/IMEI Number:"
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(16, 37)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
            Me.lblCustomer.TabIndex = 43
            Me.lblCustomer.Text = "Customer:"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCellStar_Status, Me.lblPSSI_Status, Me.Label2, Me.Label3})
            Me.Panel1.Location = New System.Drawing.Point(320, 16)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(280, 72)
            Me.Panel1.TabIndex = 47
            '
            'lblCellStar_Status
            '
            Me.lblCellStar_Status.Location = New System.Drawing.Point(112, 40)
            Me.lblCellStar_Status.Name = "lblCellStar_Status"
            Me.lblCellStar_Status.Size = New System.Drawing.Size(152, 16)
            Me.lblCellStar_Status.TabIndex = 52
            Me.lblCellStar_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPSSI_Status
            '
            Me.lblPSSI_Status.Location = New System.Drawing.Point(112, 16)
            Me.lblPSSI_Status.Name = "lblPSSI_Status"
            Me.lblPSSI_Status.Size = New System.Drawing.Size(152, 16)
            Me.lblPSSI_Status.TabIndex = 51
            Me.lblPSSI_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(16, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 16)
            Me.Label2.TabIndex = 49
            Me.Label2.Text = "PSSI Status:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 40)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 50
            Me.Label3.Text = "Brightpoint Status:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(328, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 48
            Me.Label1.Text = "Current Status"
            '
            'chkRepair
            '
            Me.chkRepair.Location = New System.Drawing.Point(56, 120)
            Me.chkRepair.Name = "chkRepair"
            Me.chkRepair.Size = New System.Drawing.Size(208, 16)
            Me.chkRepair.TabIndex = 2
            Me.chkRepair.Text = "FUNCTIONAL FAILURE (REPAIR)"
            '
            'chkNTF
            '
            Me.chkNTF.Location = New System.Drawing.Point(56, 144)
            Me.chkNTF.Name = "chkNTF"
            Me.chkNTF.Size = New System.Drawing.Size(208, 16)
            Me.chkNTF.TabIndex = 3
            Me.chkNTF.Text = "NO TROUBLE FOUND"
            '
            'chkFlash
            '
            Me.chkFlash.Location = New System.Drawing.Point(56, 168)
            Me.chkFlash.Name = "chkFlash"
            Me.chkFlash.Size = New System.Drawing.Size(208, 16)
            Me.chkFlash.TabIndex = 4
            Me.chkFlash.Text = "FLASHING ONLY"
            Me.chkFlash.Visible = False
            '
            'chkCancelled
            '
            Me.chkCancelled.Location = New System.Drawing.Point(16, 184)
            Me.chkCancelled.Name = "chkCancelled"
            Me.chkCancelled.Size = New System.Drawing.Size(208, 16)
            Me.chkCancelled.TabIndex = 7
            Me.chkCancelled.Text = "CANCELLED"
            '
            'chkVendor
            '
            Me.chkVendor.Location = New System.Drawing.Point(16, 208)
            Me.chkVendor.Name = "chkVendor"
            Me.chkVendor.Size = New System.Drawing.Size(208, 16)
            Me.chkVendor.TabIndex = 0
            Me.chkVendor.TabStop = False
            Me.chkVendor.Text = "SEND TO VENDOR FOR REPAIR"
            Me.chkVendor.Visible = False
            '
            'lblVendor
            '
            Me.lblVendor.Location = New System.Drawing.Point(40, 224)
            Me.lblVendor.Name = "lblVendor"
            Me.lblVendor.Size = New System.Drawing.Size(104, 16)
            Me.lblVendor.TabIndex = 0
            Me.lblVendor.Text = "SELECT VENDOR:"
            Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblVendor.Visible = False
            '
            'cboVendor
            '
            Me.cboVendor.Location = New System.Drawing.Point(40, 240)
            Me.cboVendor.Name = "cboVendor"
            Me.cboVendor.Size = New System.Drawing.Size(176, 21)
            Me.cboVendor.TabIndex = 0
            Me.cboVendor.TabStop = False
            Me.cboVendor.Visible = False
            '
            'Panel2
            '
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.lblIssues, Me.lbox_issues, Me.Label5, Me.chkPhysicalDamage, Me.chkLiquidDamage, Me.btnUpdate, Me.cboVendor, Me.lblVendor, Me.chkVendor, Me.chkCancelled})
            Me.Panel2.Location = New System.Drawing.Point(40, 96)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(560, 320)
            Me.Panel2.TabIndex = 57
            '
            'btnClear
            '
            Me.btnClear.Location = New System.Drawing.Point(152, 280)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(88, 24)
            Me.btnClear.TabIndex = 0
            Me.btnClear.TabStop = False
            Me.btnClear.Text = "CLEAR"
            '
            'lblIssues
            '
            Me.lblIssues.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblIssues.Location = New System.Drawing.Point(280, 8)
            Me.lblIssues.Name = "lblIssues"
            Me.lblIssues.Size = New System.Drawing.Size(264, 16)
            Me.lblIssues.TabIndex = 0
            Me.lblIssues.Text = "SELECT DEVICE ISSUES:"
            Me.lblIssues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lbox_issues
            '
            Me.lbox_issues.Location = New System.Drawing.Point(280, 32)
            Me.lbox_issues.Name = "lbox_issues"
            Me.lbox_issues.Size = New System.Drawing.Size(264, 274)
            Me.lbox_issues.TabIndex = 0
            Me.lbox_issues.TabStop = False
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(16, 104)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(168, 16)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "RETURN UN-REPAIRED (RUR)"
            '
            'chkPhysicalDamage
            '
            Me.chkPhysicalDamage.Location = New System.Drawing.Point(32, 144)
            Me.chkPhysicalDamage.Name = "chkPhysicalDamage"
            Me.chkPhysicalDamage.Size = New System.Drawing.Size(160, 16)
            Me.chkPhysicalDamage.TabIndex = 6
            Me.chkPhysicalDamage.Text = "PHYSICAL DAMAGE"
            '
            'chkLiquidDamage
            '
            Me.chkLiquidDamage.Location = New System.Drawing.Point(32, 128)
            Me.chkLiquidDamage.Name = "chkLiquidDamage"
            Me.chkLiquidDamage.Size = New System.Drawing.Size(160, 16)
            Me.chkLiquidDamage.TabIndex = 5
            Me.chkLiquidDamage.Text = "LIQUID DAMAGE"
            '
            'btnUpdate
            '
            Me.btnUpdate.Location = New System.Drawing.Point(16, 280)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(128, 24)
            Me.btnUpdate.TabIndex = 0
            Me.btnUpdate.TabStop = False
            Me.btnUpdate.Text = "UPDATE STATUS"
            '
            'frm_custspecTRIAGE_CellStar
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(664, 429)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkFlash, Me.chkNTF, Me.chkRepair, Me.Label1, Me.txtDeviceSN, Me.cboCustomer, Me.Label9, Me.lblCustomer, Me.Panel1, Me.Panel2})
            Me.Name = "frm_custspecTRIAGE_CellStar"
            Me.Text = "frm_custspecTRIAGE_CellStar"
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frm_custspecTRIAGE_CellStar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Hide_Elements()
            PopulateCustomer()

            txtDeviceSN.Focus()

        End Sub

        Private Sub PopulateCustomer()
            Try
                strSQL = "SELECT cust_id, cust_name1 from tcustomer where cust_id in (2113) ORDER BY Cust_Name1"
                Dim dtCust As DataTable = ds.OrderEntrySelect(strSQL)

                cboCustomer.DataSource = dtCust
                cboCustomer.DisplayMember = dtCust.Columns("Cust_Name1").ToString
                cboCustomer.ValueMember = dtCust.Columns("Cust_ID").ToString
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown
            If e.KeyCode = 13 Then

                Clear_CheckBoxes()
                Hide_Elements()
                lblPSSI_Status.Text = ""
                lblCellStar_Status.Text = ""
                System.Windows.Forms.Application.DoEvents()
                strDevice = ""

                Hide_Elements()
                System.Windows.Forms.Application.DoEvents()

                '//Get data
                strSQL = "SELECT * FROM cstincomingdata WHERE csin_ESN = '" & Trim(txtDeviceSN.Text) & "' AND ClosedStatusSent = 0"
                Dim dt As DataTable = ds.OrderEntrySelect(strSQL)

                If dt.Rows.Count > 0 Then
                    '//Get data elements
                    r = dt.Rows(0)

                    strDevice = r("csin_ESN")

                    If IsDBNull(r("pss_status")) = False Then
                        Me.lblPSSI_Status.Text = getStatusText(r("pss_status"))
                    Else
                        Me.lblPSSI_Status.Text = "NOT DEFINED"
                    End If

                    If IsDBNull(r("cs_status")) = False Then
                        Me.lblCellStar_Status.Text = getStatusText(r("cs_status"))
                    Else
                        Me.lblCellStar_Status.Text = "NOT DEFINED"
                    End If

                    '//Work with pss_status only for remainder of data
                    Clear_CheckBoxes()
                    System.Windows.Forms.Application.DoEvents()
                    Try
                        AssignCheckValues(r("pss_status"))
                    Catch ex As Exception
                    End Try
                Else
                    MsgBox("The device data has either not been received or the device has shipped. You can not perform triage on this device.", MsgBoxStyle.Critical, "ERROR")
                    txtDeviceSN.Text = ""
                    txtDeviceSN.Focus()
                    Exit Sub
                End If
            End If
        End Sub





        Private Sub Clear_CheckBoxes()
            chkPhysicalDamage.Checked = False
            chkLiquidDamage.Checked = False
            chkRepair.Checked = False
            chkNTF.Checked = False
            chkFlash.Checked = False
            chkCancelled.Checked = False
            chkVendor.Checked = False
            lblVendor.Visible = False
            cboVendor.Visible = False
        End Sub

        Private Sub Hide_Elements()
            lblVendor.Visible = False
            cboVendor.Visible = False
            lblIssues.Visible = False
            lbox_issues.Visible = False
        End Sub


        Private Function getStatusText(ByVal intStatus As Integer) As String

            Select Case intStatus
                Case -2
                    Return "Physical Damage"
                Case -1
                    Return "Liquid Damage"
                Case 0
                    Return "RUR"
                Case 1
                    Return "In Repair PSSI"
                Case 5
                    Return "No Trouble Found"
                Case 6
                    Return "Programming ONLY"
                Case 7
                    Return "Cancelled (RTM)"
                Case 8
                    Return "Sent to Vendor"
                Case 9
                    Return "In Repair PSSI"
            End Select
            Return "NOT DEFINED"

        End Function


        Private Function AssignCheckValues(ByVal intStatus As Integer) As Boolean

            Select Case intStatus
                Case -2
                    chkPhysicalDamage.Checked = True
                    Return True
                Case -1
                    chkLiquidDamage.Checked = True
                    Return True
                Case 0
                    '//No check for RUR General
                Case 1
                    chkRepair.Checked = True
                    Return True
                Case 5
                    chkNTF.Checked = True
                    Return True
                Case 6
                    chkFlash.Checked = True
                    Return True
                Case 7
                    chkCancelled.Checked = True
                    Return True
                Case 8
                    chkVendor.Checked = True
                    lblVendor.Visible = True
                    cboVendor.Visible = True
                    cboVendor.Focus()
                    Return True
                Case 9
                    chkRepair.Checked = True
                    Return True
            End Select

        End Function

        Private Function determinePSS_Status() As Integer
            If chkPhysicalDamage.Checked = True Then Return -2
            If chkLiquidDamage.Checked = True Then Return -1
            If chkRepair.Checked = True Then Return 9
            If chkNTF.Checked = True Then Return 5
            If chkFlash.Checked = True Then Return 6
            If chkCancelled.Checked = True Then Return 7
            If chkVendor.Checked = True Then Return 8
            Return 0
        End Function

        Private Function determineCS_Status() As Integer
            If chkPhysicalDamage.Checked = True Then Return 1
            If chkLiquidDamage.Checked = True Then Return 1
            If chkRepair.Checked = True Then Return 9
            If chkNTF.Checked = True Then Return 5
            If chkFlash.Checked = True Then Return 6
            If chkCancelled.Checked = True Then Return 7
            Return 0
        End Function

        Private Sub chkRepair_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRepair.CheckedChanged
            If chkRepair.Checked = True Then
                chkPhysicalDamage.Checked = False
                chkLiquidDamage.Checked = False
                chkNTF.Checked = False
                chkFlash.Checked = False
                chkCancelled.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub

        Private Sub chkNTF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNTF.CheckedChanged
            If chkNTF.Checked = True Then
                chkPhysicalDamage.Checked = False
                chkLiquidDamage.Checked = False
                chkRepair.Checked = False
                chkFlash.Checked = False
                chkCancelled.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub


        Private Sub chkFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFlash.CheckedChanged
            If chkFlash.Checked = True Then
                chkPhysicalDamage.Checked = False
                chkLiquidDamage.Checked = False
                chkRepair.Checked = False
                chkNTF.Checked = False
                chkCancelled.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub

        Private Sub chkLiquidDamage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLiquidDamage.CheckedChanged
            If chkLiquidDamage.Checked = True Then
                chkPhysicalDamage.Checked = False
                chkRepair.Checked = False
                chkNTF.Checked = False
                chkFlash.Checked = False
                chkCancelled.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub

        Private Sub chkPhysicalDamage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhysicalDamage.CheckedChanged
            If chkPhysicalDamage.Checked = True Then
                chkLiquidDamage.Checked = False
                chkRepair.Checked = False
                chkNTF.Checked = False
                chkFlash.Checked = False
                chkCancelled.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub

        Private Sub chkCancelled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCancelled.CheckedChanged
            If chkCancelled.Checked = True Then
                chkPhysicalDamage.Checked = False
                chkLiquidDamage.Checked = False
                chkRepair.Checked = False
                chkNTF.Checked = False
                chkFlash.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub

        Private Sub chkVendor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVendor.CheckedChanged
            If chkVendor.Checked = True Then
                chkPhysicalDamage.Checked = False
                chkLiquidDamage.Checked = False
                chkRepair.Checked = False
                chkNTF.Checked = False
                chkFlash.Checked = False
                chkCancelled.Checked = False
                cboVendor.Visible = False
                lblVendor.Visible = True
                cboVendor.Visible = True
            Else
                chkPhysicalDamage.Checked = False
                chkLiquidDamage.Checked = False
                chkRepair.Checked = False
                chkNTF.Checked = False
                chkFlash.Checked = False
                chkCancelled.Checked = False
                chkVendor.Checked = False
                lblVendor.Visible = False
                cboVendor.Visible = False
            End If
        End Sub


        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            If Len(Trim(strDevice)) > 0 Then

                '//Get status values

                Dim mPSS_Status As Integer
                Dim mCS_Status As Integer
                Dim mVendor As Integer = 0

                Dim strPSS As String
                Dim strCS As String
                Dim strVendor As String
                Dim mBillCode As String

                mPSS_Status = determinePSS_Status()
                System.Windows.Forms.Application.DoEvents()
                If mPSS_Status = 0 Then
                    '//Substitute NULL
                    strPSS = ", pss_Status = NULL"
                Else
                    strPSS = ", pss_Status = " & mPSS_Status
                End If

                mCS_Status = determineCS_Status()
                System.Windows.Forms.Application.DoEvents()
                If mCS_Status = 0 Then
                    '//Substitute NULL
                    strCS = ", cs_Status = NULL"
                Else
                    strCS = ", cs_Status = " & mCS_Status
                End If

                If chkVendor.Checked = True Then
                    '//Get vendor name
                    strVendor = ", vendor_item = '0'"
                Else
                    strVendor = ", vendor_item = '0'"
                End If


                '//get billcode if needed
                If chkNTF.Checked = True Then
                    mBillCode = ", Billcode_ID = 541"
                ElseIf chkFlash.Checked = True Then
                    mBillCode = ", Billcode_ID = 442"
                ElseIf chkLiquidDamage.Checked = True Then
                    mBillCode = ", Billcode_ID = 267"
                ElseIf chkPhysicalDamage.Checked = True Then
                    mBillCode = ", Billcode_ID = 276"
                ElseIf chkCancelled.Checked = True Then
                    mBillCode = ", Billcode_ID = 466"
                Else
                    mBillCode = ", Billcode_ID = 0"
                End If
                '//get billcode if needed


                strSQL = "UPDATE cstincomingdata SET InStatusSent = 1 " & strPSS & strCS & strVendor & mBillCode & " WHERE csin_ESN = '" & Trim(strDevice) & "' AND ClosedStatusSent = 0"
                Dim blnUpdate As Boolean = False
                Try
                    blnUpdate = ds.OrderEntryUpdateDelete(strSQL)
                Catch ex As Exception
                    MsgBox("Record could not be updated. Please iform your manager immediately.", MsgBoxStyle.Critical, "ERROR")
                End Try

                clearpage()

            End If

        End Sub

        Private Sub clearpage()
            Clear_CheckBoxes()
            Hide_Elements()
            lblPSSI_Status.Text = ""
            lblCellStar_Status.Text = ""
            strDevice = ""
            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            clearpage()
        End Sub

        Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

        End Sub
    End Class

End Namespace
