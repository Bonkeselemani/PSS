

Public Class frmCollectMClaimData
    Inherits System.Windows.Forms.Form

    Private objMClaim As PSS.Data.Buisness.WarrantyClaim.MClaim
    Private iWrtyFlg As Integer = 0
    'Private iCust_id As Integer = 0
    'Private iModel_id As Integer = 0
    Private iGSMFlag As Integer = 1
    Private iDevice_id As Integer = 0
    Private iCellOpt_id As Integer = 0
    Private strCellOpt_MSN As String = ""
    Private strCellOpt_IMEI As String = ""
    Private strCellOpt_CSN As String = ""
    Private strCellOpt_SoftVerIN As String = ""
    Private strCellOpt_SJUG As String = ""
    'Private iDevGroup_id As Integer = 0
    'Private iParentGroupID As Integer = PSS.Core.Global.ApplicationUser.GroupID
    Private iDcode_id As Integer = 0
    Private iTransCodeIndex As Integer = 0
    Private booReturnFlag As Boolean = False
    Private strAPC_codeDesc As String = ""


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iDev_id As Integer, _
                    ByVal iBillCodeFlag As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMClaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()
        iDevice_id = iDev_id
        iTransCodeIndex = iBillCodeFlag
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMesg As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCustomer1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    Friend WithEvents txtMSN As System.Windows.Forms.TextBox
    Friend WithEvents txtSoftVer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cboSUG As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cboSUG = New PSS.Gui.Controls.ComboBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSoftVer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMSN = New System.Windows.Forms.TextBox()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCustomer1 = New System.Windows.Forms.Label()
        Me.lblMesg = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClose, Me.cboSUG, Me.cmdSave, Me.Label2, Me.txtSoftVer, Me.Label1, Me.txtMSN, Me.txtIMEI, Me.Label4, Me.lblCustomer1})
        Me.Panel1.Location = New System.Drawing.Point(2, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 198)
        Me.Panel1.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdClose.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdClose.ForeColor = System.Drawing.Color.White
        Me.cmdClose.Location = New System.Drawing.Point(149, 148)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(104, 28)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "CLOSE"
        Me.cmdClose.Visible = False
        '
        'cboSUG
        '
        Me.cboSUG.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboSUG.AutoComplete = True
        Me.cboSUG.Location = New System.Drawing.Point(150, 82)
        Me.cboSUG.Name = "cboSUG"
        Me.cboSUG.Size = New System.Drawing.Size(152, 21)
        Me.cboSUG.TabIndex = 3
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdSave.Enabled = False
        Me.cmdSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(149, 148)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(104, 28)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save Data"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(21, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "SJUG Number:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSoftVer
        '
        Me.txtSoftVer.Enabled = False
        Me.txtSoftVer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoftVer.Location = New System.Drawing.Point(150, 113)
        Me.txtSoftVer.Name = "txtSoftVer"
        Me.txtSoftVer.Size = New System.Drawing.Size(152, 23)
        Me.txtSoftVer.TabIndex = 4
        Me.txtSoftVer.Text = ""
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(11, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Software Ver:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMSN
        '
        Me.txtMSN.Enabled = False
        Me.txtMSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMSN.Location = New System.Drawing.Point(150, 49)
        Me.txtMSN.Name = "txtMSN"
        Me.txtMSN.Size = New System.Drawing.Size(152, 23)
        Me.txtMSN.TabIndex = 2
        Me.txtMSN.Text = ""
        '
        'txtIMEI
        '
        Me.txtIMEI.Enabled = False
        Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(150, 17)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(152, 23)
        Me.txtIMEI.TabIndex = 1
        Me.txtIMEI.Text = ""
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(18, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "MSN/CSN:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomer1
        '
        Me.lblCustomer1.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCustomer1.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer1.Location = New System.Drawing.Point(24, 21)
        Me.lblCustomer1.Name = "lblCustomer1"
        Me.lblCustomer1.Size = New System.Drawing.Size(128, 16)
        Me.lblCustomer1.TabIndex = 70
        Me.lblCustomer1.Text = "IMEI/Decimal SN:"
        Me.lblCustomer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMesg
        '
        Me.lblMesg.BackColor = System.Drawing.Color.SteelBlue
        Me.lblMesg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMesg.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesg.ForeColor = System.Drawing.Color.White
        Me.lblMesg.Location = New System.Drawing.Point(3, 260)
        Me.lblMesg.Name = "lblMesg"
        Me.lblMesg.Size = New System.Drawing.Size(341, 61)
        Me.lblMesg.TabIndex = 1
        Me.lblMesg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(3, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(341, 54)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Motorola MClaim Data"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCollectMClaimData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(347, 323)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblMesg, Me.Panel1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCollectMClaimData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motorola MClaim Data"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Property ReturnFlag() As Boolean
        Get
            Return booReturnFlag
        End Get
        Set(ByVal Value As Boolean)
            booReturnFlag = Value
        End Set
    End Property

    Private Sub frmCollectMClaimData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GetDeviceInfo()

        Catch ex As Exception
            MessageBox.Show("frmCollectMClaimData_Load(): " & Environment.NewLine & ex.Message, "Input IMEI Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    Private Sub LoadSugNumbers(ByVal iModel_ID As Integer)
        Dim dt1 As DataTable

        Try
            dt1 = Me.objMClaim.GetMotoSUGNumbers(iModel_ID)
            With cboSUG
                .DataSource = dt1.DefaultView
                .DisplayMember = dt1.Columns("LensSUG_text").ToString
                .ValueMember = dt1.Columns("LensSUG_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '''Private Sub ClearControl(Optional ByVal iClearMsgLabel As Integer = 1)
    '''    iWrtyFlg = 0
    '''    iCust_id = 0
    '''    iModel_id = 0
    '''    iGSMFlag = 1
    '''    'iDevice_id = 0
    '''    iCellOpt_id = 0
    '''    strCellOpt_MSN = ""
    '''    strCellOpt_CSN = ""
    '''    strCellOpt_SoftVerIN = ""
    '''    strCellOpt_SJUG = ""
    '''    iDevGroup_id = 0
    '''    iDcode_id = 0
    '''    iTransCodeIndex = 0

    '''    Me.txtMSN.Text = ""
    '''    Me.txtMSN.Enabled = False
    '''    Me.txtSJUG.Text = ""
    '''    Me.txtSJUG.Enabled = False
    '''    Me.txtSoftVer.Text = ""
    '''    Me.txtSoftVer.Enabled = False
    '''    Me.cmdSave.Enabled = False

    '''    If iClearMsgLabel = 1 Then
    '''        Me.lblMesg.Text = ""
    '''        Me.lblMesg.BackColor = System.Drawing.Color.SteelBlue
    '''    End If

    '''    Me.txtIMEI.Focus()
    '''End Sub

    '*************************************************************************
    '''Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
    '''    Dim iNewOwner As Integer = 0
    '''    Dim iManuf_id As Integer = 0
    '''    Dim strCarrier_MotoDesc As String
    '''    Dim dt As DataTable
    '''    Dim dtCarrier As DataTable


    '''    If e.KeyValue = 13 Then

    '''        Try
    '''            If Trim(Me.txtIMEI.Text) = "" Then
    '''                Exit Sub
    '''            End If

    '''            '*****************************
    '''            'Get device's cust_id,modelID
    '''            '*****************************
    '''            dt = Me.objMClaim.GetDeviceInfo(Trim(Me.txtIMEI.Text))
    '''            If dt.Rows.Count > 0 Then
    '''                iCust_id = dt.Rows(0)("cust_id")
    '''                iModel_id = dt.Rows(0)("model_id")
    '''                iManuf_id = dt.Rows(0)("manuf_id")
    '''                iDevice_id = dt.Rows(0)("device_id")
    '''                iCellOpt_id = dt.Rows(0)("cellopt_id")
    '''                iDevGroup_id = dt.Rows(0)("group_id")

    '''                If Not IsDBNull(dt.Rows(0)("CellOpt_MSN")) Then
    '''                    strCellOpt_MSN = UCase(Trim(dt.Rows(0)("CellOpt_MSN")))
    '''                    Me.txtMSN.Enabled = True
    '''                    Me.txtMSN.Text = strCellOpt_MSN
    '''                    Me.iGSMFlag = 1
    '''                End If

    '''                If Not IsDBNull(dt.Rows(0)("CellOpt_CSN")) Then
    '''                    strCellOpt_CSN = UCase(Trim(dt.Rows(0)("CellOpt_CSN")))
    '''                    Me.txtMSN.Enabled = True
    '''                    Me.txtMSN.Text = strCellOpt_CSN
    '''                    Me.iGSMFlag = 0
    '''                End If

    '''                If Not IsDBNull(dt.Rows(0)("CellOpt_Transceiver")) Then
    '''                    strCellOpt_SJUG = UCase(Trim(dt.Rows(0)("CellOpt_Transceiver")))
    '''                    Me.txtSJUG.Enabled = True
    '''                    Me.txtSJUG.Text = strCellOpt_SJUG
    '''                End If

    '''                If Not IsDBNull(dt.Rows(0)("CellOpt_SoftVerIN")) Then
    '''                    strCellOpt_SoftVerIN = UCase(Trim(dt.Rows(0)("CellOpt_SoftVerIN")))
    '''                    Me.txtSoftVer.Enabled = True
    '''                    Me.txtSoftVer.Text = strCellOpt_SoftVerIN
    '''                End If
    '''            Else
    '''                MessageBox.Show("The IMEI does not exist.", "Scan IMEI", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
    '''                Me.txtIMEI.SelectAll()
    '''                Me.txtIMEI.Focus()
    '''                Exit Sub
    '''            End If

    '''            '******************************************
    '''            'Check if device's manufacturer is Motorola
    '''            '******************************************
    '''            If Not IsMotorolaDevice(iManuf_id) Then
    '''                Throw New Exception("This is not a Motorola phone.")
    '''            End If

    '''            '*****************************
    '''            'Check device's carrier
    '''            '*****************************
    '''            Select Case iCust_id
    '''                Case 2019   'ATCLE
    '''                    'Get Carrier desc (motorola short desc). Assume Cingular is the carrier for ATCLE
    '''                    strCarrier_MotoDesc = "CIN"

    '''                Case 2113   'Brightpoint
    '''                    'Get Carrier
    '''                    dtCarrier = Me.objMClaim.GetCSCarrier_MotoDesc(iCust_id, Trim(Me.txtIMEI.Text))
    '''                    If dtCarrier.Rows.Count > 0 Then
    '''                        If Not IsDBNull(dtCarrier.Rows(0)("carrier_MotoDesc")) Then
    '''                            strCarrier_MotoDesc = dtCarrier.Rows(0)("carrier_MotoDesc")
    '''                        Else
    '''                            strCarrier_MotoDesc = ""
    '''                        End If
    '''                    Else
    '''                        strCarrier_MotoDesc = ""
    '''                    End If
    '''            End Select

    '''            If strCarrier_MotoDesc <> "" Then
    '''                iDcode_id = Me.objMClaim.GetDCodeID(strCarrier_MotoDesc)
    '''                If iDcode_id = 0 Then
    '''                    Throw New Exception("Carrier does not exist in Motorola's master code.")
    '''                End If
    '''            Else
    '''                Throw New Exception("Carrier does not exist in Motorola's master code.")
    '''            End If

    '''            '************************************************
    '''            'Check if the device billed with the parts that
    '''            '   allow to submit the MClaim
    '''            '************************************************

    '''            iTransCodeIndex = Me.objMClaim.CheckForWrtyBillcodes(iDevice_id, iCust_id, iModel_id)
    '''            If iTransCodeIndex = 0 Then
    '''                'Throw New Exception("No Motorola billcodes for this device.")
    '''                'Me.ClearControl()
    '''                Me.lblMesg.BackColor = System.Drawing.Color.ForestGreen
    '''                Me.lblMesg.Text = "Manual Flash"
    '''                Me.txtIMEI.SelectAll()
    '''                Me.txtIMEI.Focus()
    '''                Exit Sub
    '''            End If


    '''            '*****************************
    '''            'Check if device is GSM phone
    '''            If Trim(Me.txtIMEI.Text).Length = 15 Then
    '''                iGSMFlag = 1
    '''            Else
    '''                iGSMFlag = 0
    '''            End If

    '''            'enable and set focus to netxt control
    '''            Me.txtMSN.Enabled = True
    '''            Me.txtMSN.Focus()

    '''            If Trim(Me.txtMSN.Text).Length > 0 And Trim(Me.txtSJUG.Text).Length > 0 And Trim(Me.txtSoftVer.Text).Length > 0 Then
    '''                Me.ProcessMSN()
    '''            Else
    '''                Me.txtMSN.Text = ""
    '''                Me.txtSJUG.Text = ""
    '''                Me.txtSoftVer.Text = ""
    '''            End If
    '''        Catch ex As Exception
    '''            MessageBox.Show("txtIMEI_KeyUp: " & Environment.NewLine & ex.Message, "Input IMEI Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '''            'Me.ClearControl()
    '''            Me.lblMesg.BackColor = System.Drawing.Color.ForestGreen
    '''            Me.lblMesg.Text = "Manual Flash"
    '''            Me.txtIMEI.SelectAll()
    '''            Me.txtIMEI.Focus()
    '''        Finally
    '''            If Not IsNothing(dt) Then
    '''                dt.Dispose()
    '''                dt = Nothing
    '''            End If
    '''            If Not IsNothing(dtCarrier) Then
    '''                dtCarrier.Dispose()
    '''                dtCarrier = Nothing
    '''            End If
    '''        End Try
    '''    End If
    '''End Sub

    '*************************************************************************
    Private Sub GetDeviceInfo()
        Dim iNewOwner As Integer = 0
        'Dim iManuf_id As Integer = 0
        Dim strCarrier_MotoDesc As String
        Dim dt As DataTable
        Dim dtCarrier As DataTable
        Dim iLensSUG_ID As Integer = 0

        Try

            '*****************************
            'Get device's cust_id,modelID
            '*****************************
            dt = objMClaim.GetDeviceInfo(iDevice_id)
            If dt.Rows.Count > 0 Then
                'iCust_id = dt.Rows(0)("cust_id")
                'iModel_id = dt.Rows(0)("model_id")
                'iManuf_id = dt.Rows(0)("manuf_id")
                'iDevice_id = dt.Rows(0)("device_id")
                iCellOpt_id = dt.Rows(0)("cellopt_id")
                'iDevGroup_id = dt.Rows(0)("group_id")
                If Not IsDBNull(dt.Rows(0)(("LensSUG_ID"))) Then
                    iLensSUG_ID = dt.Rows(0)(("LensSUG_ID"))
                End If


                '****************************
                'Load SUG Numbers
                '****************************
                If Not IsNothing(dt.Rows(0)("model_id")) Then
                    Me.LoadSugNumbers(dt.Rows(0)("model_id"))
                End If
                '****************************

                If Not IsDBNull(dt.Rows(0)("CellOpt_IMEI")) Then
                    strCellOpt_IMEI = UCase(Trim(dt.Rows(0)("CellOpt_IMEI")))
                    'Me.txtIMEI.Enabled = True
                    Me.txtIMEI.Text = strCellOpt_IMEI
                    Me.iGSMFlag = 1
                End If

                If Not IsDBNull(dt.Rows(0)("CellOpt_MSN")) Then
                    strCellOpt_MSN = UCase(Trim(dt.Rows(0)("CellOpt_MSN")))
                    Me.txtMSN.Enabled = True
                    Me.txtMSN.Text = strCellOpt_MSN
                    Me.iGSMFlag = 1
                End If

                If Not IsDBNull(dt.Rows(0)("CellOpt_CSN")) Then
                    strCellOpt_CSN = UCase(Trim(dt.Rows(0)("CellOpt_CSN")))
                    Me.txtMSN.Enabled = True
                    Me.txtMSN.Text = strCellOpt_CSN
                    Me.iGSMFlag = 0
                End If

                If Not IsDBNull(dt.Rows(0)("CellOpt_Transceiver")) Then
                    strCellOpt_SJUG = UCase(Trim(dt.Rows(0)("CellOpt_Transceiver")))
                    Me.cboSUG.Enabled = True
                    Me.cboSUG.SelectedValue = iLensSUG_ID
                End If

                If Not IsDBNull(dt.Rows(0)("CellOpt_SoftVerIN")) Then
                    strCellOpt_SoftVerIN = UCase(Trim(dt.Rows(0)("CellOpt_SoftVerIN")))
                    Me.txtSoftVer.Enabled = True
                    Me.txtSoftVer.Text = strCellOpt_SoftVerIN
                End If

                'GSM Flag
                If Not IsDBNull(dt.Rows(0)("Model_GSM")) Then
                    If CInt(dt.Rows(0)("Model_GSM").ToString) = 1 Then
                        iGSMFlag = 1
                    ElseIf CInt(dt.Rows(0)("Model_GSM").ToString) = 0 Then
                        iGSMFlag = 0
                    End If
                Else
                    '*****************************
                    'Check if device is GSM phone
                    If Trim(Me.txtIMEI.Text).Length = 15 Then
                        iGSMFlag = 1
                    Else
                        iGSMFlag = 0
                    End If
                    '*****************************
                End If

                'APC code
                If Not IsDBNull(dt.Rows(0)("Dcode_ID")) Then
                    If dt.Rows(0)("Dcode_ID") > 0 Then
                        strAPC_codeDesc = objMClaim.GetMotorolaAPCCodeDesc(dt.Rows(0)("Dcode_ID"))
                    End If
                End If
            Else
                MessageBox.Show("The Device does not exist.", "Get Device Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmdSave.Visible = False
                Me.cmdClose.Visible = True
                Me.cmdClose.Focus()
                Exit Sub
            End If

            '******************************************
            'Check if device's manufacturer is Motorola
            '******************************************
            'If Not IsMotorolaDevice(iManuf_id) Then
            '    Throw New Exception("This is not a Motorola phone.")
            'End If

            '*****************************
            'Check device's carrier
            '*****************************
            'Select Case iCust_id
            '    Case 2019   'ATCLE
            '        'Get Carrier desc (motorola short desc). Assume Cingular is the carrier for ATCLE
            '        strCarrier_MotoDesc = "CIN"

            '    Case 2113   'Brightpoint
            '        'Get Carrier
            '        dtCarrier = Me.objMClaim.GetCSCarrier_MotoDesc(iCust_id, Trim(Me.txtIMEI.Text))
            '        If dtCarrier.Rows.Count > 0 Then
            '            If Not IsDBNull(dtCarrier.Rows(0)("carrier_MotoDesc")) Then
            '                strCarrier_MotoDesc = dtCarrier.Rows(0)("carrier_MotoDesc")
            '            Else
            '                strCarrier_MotoDesc = ""
            '            End If
            '        Else
            '            strCarrier_MotoDesc = ""
            '        End If
            'End Select

            'If strCarrier_MotoDesc <> "" Then
            '    iDcode_id = Me.objMClaim.GetDCodeID(strCarrier_MotoDesc)
            '    If iDcode_id = 0 Then
            '        Throw New Exception("Carrier does not exist in Motorola's master code.")
            '    End If
            'Else
            '    Throw New Exception("Carrier does not exist in Motorola's master code.")
            'End If

            '************************************************
            'Check if the device billed with the parts that
            '   allow to submit the MClaim
            '************************************************

            'iTransCodeIndex = Me.objMClaim.CheckForWrtyBillcodes(iDevice_id, iCust_id, iModel_id)
            'If iTransCodeIndex = 0 Then
            '    'Throw New Exception("No Motorola billcodes for this device.")
            '    'Me.ClearControl()
            '    Me.lblMesg.BackColor = System.Drawing.Color.ForestGreen
            '    Me.lblMesg.Text = "Manual Flash"
            '    Me.txtIMEI.SelectAll()
            '    Me.txtIMEI.Focus()
            '    Exit Sub
            'End If


            If Trim(Me.txtMSN.Text) <> "" And Trim(Me.cboSUG.SelectedItem("LensSUG_text")) <> "" And Trim(Me.txtSoftVer.Text) <> "" Then
                Me.ProcessMSN()
            Else
                Me.txtMSN.Text = ""
                Me.txtMSN.Enabled = True
                Me.cboSUG.SelectedValue = 0
                Me.txtSoftVer.Text = ""
                Me.txtMSN.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show("GetDeviceInfo(): " & Environment.NewLine & ex.Message, "Input IMEI Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
            If Not IsNothing(dtCarrier) Then
                dtCarrier.Dispose()
                dtCarrier = Nothing
            End If
        End Try

    End Sub

    '*************************************************************************
    Private Sub txtMSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMSN.KeyUp

        If e.KeyValue = 13 Then
            Try
                If Trim(Me.txtMSN.Text) = "" Then
                    Exit Sub
                Else
                    ProcessMSN()
                End If
            Catch ex As Exception
                MessageBox.Show("txtMSN_KeyUp: " & Environment.NewLine & ex.Message, "Input MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
            End Try
        End If
    End Sub

    '*************************************************************************
    Private Sub ProcessMSN()
        Dim strScanAPC_Code As String = ""
        Dim iAPC_Code_Existed As Integer = 0

        Try
            If Trim(strAPC_codeDesc) = "" Then
                MessageBox.Show("APC code for this model is not set up. Please contact Engineering Department immediately.", "Motorola APC Code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.booReturnFlag = False
                Me.Close()

                ''PSS.Gui.techscreen.frmNewTech.iMClaimDataResult = False

                ''Me.cmdClose.Visible = True
                ''Me.cmdClose.Focus()
                ''Exit Sub
            End If

            If Trim(Me.txtMSN.Text) = "" Then
                Exit Sub
            Else
                If Len(Trim(Me.txtMSN.Text)) < 3 Then
                    MessageBox.Show("Invalid MSN format.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMSN.SelectAll()
                    Me.txtMSN.Focus()
                    Exit Sub
                End If

                If IsNumeric(Trim(Me.txtMSN.Text)) Then
                    MessageBox.Show("Invalid MSN format.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMSN.SelectAll()
                    Me.txtMSN.Focus()
                    Exit Sub
                End If

                '****************************************
                'Check for existed of APC code
                ' if APC code does not exist then close MClaim screen 
                ' without completed device
                '****************************************
                strScanAPC_Code = Mid(Trim(Me.txtMSN.Text), 1, 3)
                iAPC_Code_Existed = objMClaim.IsAPC_CodeExisted(strScanAPC_Code)
                If iAPC_Code_Existed = 0 Then
                    MessageBox.Show("The APC Code determined based on the MSN you provided does not exist in PSS database. Please contact your supervisor.", "Validate APC Code", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.booReturnFlag = False
                    Me.Close()
                End If
                '****************************************



                'If Mid(Trim(Me.txtMSN.Text), 1, Trim(strAPC_codeDesc).Length) <> Trim(strAPC_codeDesc) Then
                '    MessageBox.Show("Invalid MSN number. MSN must start with '" & strAPC_codeDesc & "'.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Me.txtMSN.SelectAll()
                '    Me.txtMSN.Focus()
                '    Exit Sub
                'End If

                If Trim(Me.txtMSN.Text).Length < 10 Or Trim(Me.txtMSN.Text).Length > 12 Then
                    MessageBox.Show("Invalid MSN length.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMSN.SelectAll()
                    Me.txtMSN.Focus()
                    Exit Sub
                End If

                If iTransCodeIndex = 1 Then             'REP
                    'Check warranty
                    iWrtyFlg = Me.checkOEMwrty_Motorola(Trim(Me.txtMSN.Text), iGSMFlag)
                ElseIf iTransCodeIndex = 2 Then         'REW
                    iWrtyFlg = 1
                End If

                If Me.iWrtyFlg = 1 Then
                    Me.lblMesg.BackColor = System.Drawing.Color.Orange
                    Me.lblMesg.Text = "Flash with RSD NET"

                    'enable and set focus to netxt control
                    Me.cboSUG.Enabled = True
                    Me.txtSoftVer.Enabled = True
                    Me.cmdSave.Enabled = True
                    Me.cmdSave.Visible = True
                    Me.cmdClose.Visible = False
                    If Me.cboSUG.SelectedValue > 0 And Trim(Me.txtSoftVer.Text) <> "" Then
                        Me.txtSoftVer.Focus()
                    Else
                        Me.cboSUG.Focus()
                    End If

                Else
                    'Me.ClearControl()
                    Me.lblMesg.BackColor = System.Drawing.Color.SteelBlue
                    Me.lblMesg.Text = "Manual Flash"
                    Me.txtSoftVer.Enabled = False
                    Me.cboSUG.Enabled = False
                    Me.cmdSave.Visible = False
                    Me.cmdClose.Visible = True
                    Me.cmdClose.Focus()
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        Finally
        End Try
    End Sub

    '*************************************************************************
    Private Sub cboSUG_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSUG.SelectionChangeCommitted
        If Me.cboSUG.SelectedValue > 0 Then
            Me.txtSoftVer.Focus()
        End If
    End Sub

    '*************************************************************************
    Private Sub txtSoftVer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftVer.KeyUp
        If e.KeyValue = 13 Then
            SaveData()
        End If
    End Sub

    '*************************************************************************
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveData()
    End Sub

    '*************************************************************************
    Public Sub SaveData()
        Dim strSJUG As String = Trim(Me.cboSUG.SelectedItem("LensSUG_text"))  'UCase(Trim(Me.txtSJUG.Text))
        Dim i As Integer = 0
        Dim iNewOwner As Integer = 0
        Dim iLineID As Integer = PSS.Core.[Global].ApplicationUser.LineID

        Try
            If Trim(Me.txtIMEI.Text) = "" Then
                Throw New Exception("IMEI/Decimal SN is missing.")
            End If
            '*********************************
            'Validate MSN number
            If Trim(Me.txtMSN.Text) = "" Then
                'Throw New Exception("MSN number is missing.")
                MessageBox.Show("MSN number is missing.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtMSN.Focus()
                booReturnFlag = False
                Exit Sub
            Else
                If IsNumeric(Trim(Me.txtMSN.Text)) Then
                    'Throw New Exception("Invalid MSN number.")
                    MessageBox.Show("Invalid MSN number.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMSN.Focus()
                    booReturnFlag = False
                    Exit Sub
                End If
                If Trim(Me.txtMSN.Text).Length < 10 Or Trim(Me.txtMSN.Text).Length > 12 Then
                    'Throw New Exception("Invalid MSN length.")
                    MessageBox.Show("Invalid MSN length.", "Validate MSN Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMSN.Focus()
                    booReturnFlag = False
                    Exit Sub
                End If
            End If
            '*********************************
            'Validate SJUG number
            If cboSUG.SelectedValue = 0 Then

                'Throw New Exception("SJUG number is missing.")
                MessageBox.Show("SJUG number is missing.", "Validate SJUG Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboSUG.Focus()
                booReturnFlag = False
                Exit Sub
                'Else
                '    'If strSJUG.Length > 15 Then
                '    '    'Throw New Exception("Invalid SJUG length.")
                '    '    MessageBox.Show("SJUG number is missing.", "Validate SJUG Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    '    Me.cboSUG.Focus()
                '    '    booReturnFlag = False
                '    '    Exit Sub
                '    'End If
                '    If Mid(strSJUG, 1, 4) <> "SJUG" Then
                '        'Throw New Exception("Invalid SJUG format.")
                '        MessageBox.Show("Invalid format for SJUG Number.", "Validate SJUG Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Me.cboSUG.Focus()
                '        booReturnFlag = False
                '        Exit Sub
                '    End If
            End If

            '*********************************
            'Validate Software version
            If Trim(Me.txtSoftVer.Text) = "" Then
                'Throw New Exception("Software version is missing.")
                MessageBox.Show("Software version is missing.", "Validate S/W Version", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSoftVer.Focus()
                booReturnFlag = False
                Exit Sub
            End If
            If InStr(Trim(Me.txtSoftVer.Text), ".") = 0 Then
                MessageBox.Show("Invalid software version format.", "Validate S/W Version", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSoftVer.Focus()
                booReturnFlag = False
                Exit Sub
            End If
            '*********************************
            'check warranty flag
            If Me.iWrtyFlg = 0 Then
                'MessageBox.Show("Device is not under warranty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtMSN.SelectAll()
                Me.txtMSN.Focus()
                booReturnFlag = False
                Exit Sub
            End If

            ''*********************************
            ''pull device's Wipowner to cell 1 flashing or cell 2 flashing from cell 1 or 2
            'iNewOwner = Me.objMClaim.GetNewOwner(Me.iCust_id, Me.iModel_id, iLineID, Me.iParentGroupID)

            ''*********************************
            ''update data
            i = Me.objMClaim.UpdateMClaimData(Me.iCellOpt_id, _
                                              UCase(Trim(Me.txtIMEI.Text)), _
                                              UCase(Trim(Me.txtMSN.Text)), _
                                              strSJUG, _
                                              Trim(Me.txtSoftVer.Text), _
                                              Me.iGSMFlag, _
                                              Me.iDevice_id, _
                                              Me.iDcode_id)

            If i > 0 Then
                'MessageBox.Show("Data saved.", "Save MClaim Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                booReturnFlag = True
                Me.Close()
            End If

            'Me.ClearControl(0)
            'Me.txtIMEI.SelectAll()
            'Me.txtIMEI.Focus()
        Catch ex As Exception
            booReturnFlag = False
            Me.cmdSave.Visible = False
            Me.cmdClose.Visible = True
            Me.cmdClose.Focus()
            MessageBox.Show("SaveData(): " & Environment.NewLine & ex.Message, "Input Software Version", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    ''*************************************************************************
    'Private Function IsMotorolaDevice(ByVal iManufID As Integer) As Boolean
    '    Try
    '        If iManufID = 1 Then    '1:Mortorola
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    '*************************************************************************
    Private Function checkOEMwrty_Motorola(ByVal strCode As String, _
                                           ByVal iGSMFlag As Integer) As Integer

        '//Check Data
        Dim strYearDigit As String
        Dim strYear As String
        Dim strMonthDigit As String
        Dim strMonth As String
        Dim strWrtyPeriodDigit As String
        Dim strWrtyPeriod As String

        If iGSMFlag = 1 Then
            strYearDigit = UCase(Mid(strCode, 5, 1))
            strMonthDigit = UCase(Mid(strCode, 6, 1))
        Else
            strYearDigit = UCase(Mid(strCode, 9, 1))
            strMonthDigit = UCase(Mid(strCode, 10, 1))
        End If


        Select Case strYearDigit
            Case "A"
                strYear = "2000"
            Case "B"
                strYear = "2001"
            Case "C"
                strYear = "2002"
            Case "D"
                strYear = "2003"
            Case "E"
                strYear = "2004"
            Case "F"
                strYear = "2005"
            Case "G"
                strYear = "2006"
            Case "H"
                strYear = "2007"

                'Case "I"

            Case "J"
                strYear = "2008"
            Case "K"
                strYear = "2009"
            Case "L"
                strYear = "2010"
            Case "M"
                strYear = "2011"
            Case "N"
                strYear = "2012"
            Case Else
                strYear = "1999"
        End Select

        Select Case strMonthDigit
            Case "A"
                strMonth = "1"
            Case "B"
                strMonth = "1"
            Case "C"
                strMonth = "2"
            Case "D"
                strMonth = "2"
            Case "E"
                strMonth = "3"
            Case "F"
                strMonth = "3"
            Case "G"
                strMonth = "4"
            Case "H"
                strMonth = "4"
            Case "J"
                strMonth = "5"
            Case "K"
                strMonth = "5"
            Case "L"
                strMonth = "6"
            Case "M"
                strMonth = "6"
            Case "N"
                strMonth = "7"
            Case "P"
                strMonth = "7"
            Case "Q"
                strMonth = "8"
            Case "R"
                strMonth = "8"
            Case "S"
                strMonth = "9"
            Case "T"
                strMonth = "9"
            Case "U"
                strMonth = "10"
            Case "V"
                strMonth = "10"
            Case "W"
                strMonth = "11"
            Case "X"
                strMonth = "11"
            Case "Y"
                strMonth = "12"
            Case "Z"
                strMonth = "12"
            Case Else
                strMonth = "1"
        End Select

        If Len(Trim(strCode)) > 10 Then
            strWrtyPeriodDigit = UCase(Mid(strCode, 11, 1))
            Select Case strWrtyPeriodDigit
                Case "A"
                    strWrtyPeriod = "365"
                Case "B"
                    strWrtyPeriod = "1095"
                Case "C"
                    strWrtyPeriod = "1825"
                Case "D"
                    strWrtyPeriod = "1095"
                Case "E"
                    strWrtyPeriod = "0"
                Case "F"
                    strWrtyPeriod = "90"
                Case "H"                    '3 yrs, Cannada only
                    'strWrtyPeriod = "1095"
                    strWrtyPeriod = "0"
                Case "J"
                    strWrtyPeriod = "365"
                Case "L"
                    strWrtyPeriod = "365"
                Case "M"
                    strWrtyPeriod = "365"
                Case "N"
                    strWrtyPeriod = "1825"
                Case "P"
                    strWrtyPeriod = "1825"
                Case "Q"
                    strWrtyPeriod = "1095"
                Case "R"
                    strWrtyPeriod = "1095"
                Case "S"
                    strWrtyPeriod = "1095"
                Case "T"                    'OEM telephone(serviced by dealers only)
                    strWrtyPeriod = "0"
                Case "U"
                    strWrtyPeriod = "90"
                Case "W"
                    strWrtyPeriod = "1460"
                Case "X"
                    strWrtyPeriod = "1825"
                Case "Y"
                    strWrtyPeriod = "1095"
                Case "Z"
                    strWrtyPeriod = "1095"
                Case Else
                    strWrtyPeriod = "365"
            End Select
        Else
            strWrtyPeriod = "365"
        End If

        Dim mDate As Date = strMonth & "/1/" & strYear
        Dim mDateExp As String = DateAdd(DateInterval.Day, CInt(strWrtyPeriod), mDate)

        Dim mNow As Date = Gui.Receiving.FormatDateShort(Now)
        If mNow < mDateExp Then
            Return 1    'warranty
        Else
            Return 0    'no warranty
        End If
    End Function

    '*************************************************************************
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.booReturnFlag = True
        Me.Close()
    End Sub


End Class
