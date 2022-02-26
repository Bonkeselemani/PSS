Option Explicit On 

Public Class frmBillGroupsAdmin
    Inherits System.Windows.Forms.Form

    Private _objBillGrpAdmin As PSS.Data.Buisness.BillGroupsAdmin
    Private _Active As Boolean

    Private dtCustomer As DataTable
    Private dtManufacturer As DataTable
    Private dtEnterprise As DataTable
    Private dtModel As DataTable
    Private dtBillCodes As DataTable

    Private dbCustMarkup As Double = 0.0
    Private _booNewBillGrp As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objBillGrpAdmin = New PSS.Data.Buisness.BillGroupsAdmin()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            _objBillGrpAdmin = Nothing

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
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents lblManufacturer As System.Windows.Forms.Label
    Friend WithEvents lblEnterprise As System.Windows.Forms.Label
    Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents cboModel As System.Windows.Forms.ComboBox
    Friend WithEvents cboEnterprise As System.Windows.Forms.ComboBox
    Friend WithEvents lblDefinedBillGroups As System.Windows.Forms.Label
    Friend WithEvents btnNewBillGroup As System.Windows.Forms.Button
    Friend WithEvents tvMAIN As System.Windows.Forms.TreeView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCreateModelEnt As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblTargetName As System.Windows.Forms.Label
    Friend WithEvents lblBERN As System.Windows.Forms.Label
    Friend WithEvents lblTarget As System.Windows.Forms.Label
    Friend WithEvents lblBER As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents L8 As System.Windows.Forms.Label
    Friend WithEvents L6 As System.Windows.Forms.Label
    Friend WithEvents L4 As System.Windows.Forms.Label
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents L9 As System.Windows.Forms.Label
    Friend WithEvents L7 As System.Windows.Forms.Label
    Friend WithEvents L5 As System.Windows.Forms.Label
    Friend WithEvents L3 As System.Windows.Forms.Label
    Public WithEvents L1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents chkInactive1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive7 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive8 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive9 As System.Windows.Forms.CheckBox
    Friend WithEvents idx_txtBG As System.Windows.Forms.TextBox
    Friend WithEvents lblLabor As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.lblEnterprise = New System.Windows.Forms.Label()
        Me.cboManufacturer = New System.Windows.Forms.ComboBox()
        Me.cboModel = New System.Windows.Forms.ComboBox()
        Me.cboEnterprise = New System.Windows.Forms.ComboBox()
        Me.tvMAIN = New System.Windows.Forms.TreeView()
        Me.lblDefinedBillGroups = New System.Windows.Forms.Label()
        Me.btnNewBillGroup = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCreateModelEnt = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTargetName = New System.Windows.Forms.Label()
        Me.lblBERN = New System.Windows.Forms.Label()
        Me.lblTarget = New System.Windows.Forms.Label()
        Me.lblBER = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.L8 = New System.Windows.Forms.Label()
        Me.L6 = New System.Windows.Forms.Label()
        Me.L4 = New System.Windows.Forms.Label()
        Me.L2 = New System.Windows.Forms.Label()
        Me.L9 = New System.Windows.Forms.Label()
        Me.L7 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.L1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.idx_txtBG = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chkInactive1 = New System.Windows.Forms.CheckBox()
        Me.chkInactive2 = New System.Windows.Forms.CheckBox()
        Me.chkInactive3 = New System.Windows.Forms.CheckBox()
        Me.chkInactive4 = New System.Windows.Forms.CheckBox()
        Me.chkInactive5 = New System.Windows.Forms.CheckBox()
        Me.chkInactive6 = New System.Windows.Forms.CheckBox()
        Me.chkInactive7 = New System.Windows.Forms.CheckBox()
        Me.chkInactive8 = New System.Windows.Forms.CheckBox()
        Me.chkInactive9 = New System.Windows.Forms.CheckBox()
        Me.lblLabor = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(208, 8)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(72, 21)
        Me.lblCustomer.TabIndex = 0
        Me.lblCustomer.Text = "CUSTOMER:"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(472, 32)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(48, 21)
        Me.lblModel.TabIndex = 1
        Me.lblModel.Text = "MODEL:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustomer
        '
        Me.cboCustomer.Location = New System.Drawing.Point(288, 8)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(176, 21)
        Me.cboCustomer.TabIndex = 7
        '
        'lblManufacturer
        '
        Me.lblManufacturer.Location = New System.Drawing.Point(232, 32)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(48, 21)
        Me.lblManufacturer.TabIndex = 8
        Me.lblManufacturer.Text = "MANUF:"
        Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEnterprise
        '
        Me.lblEnterprise.Location = New System.Drawing.Point(472, 8)
        Me.lblEnterprise.Name = "lblEnterprise"
        Me.lblEnterprise.Size = New System.Drawing.Size(48, 21)
        Me.lblEnterprise.TabIndex = 9
        Me.lblEnterprise.Text = "ENT:"
        Me.lblEnterprise.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboManufacturer
        '
        Me.cboManufacturer.Location = New System.Drawing.Point(288, 32)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(176, 21)
        Me.cboManufacturer.TabIndex = 11
        '
        'cboModel
        '
        Me.cboModel.Location = New System.Drawing.Point(528, 32)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(176, 21)
        Me.cboModel.TabIndex = 12
        '
        'cboEnterprise
        '
        Me.cboEnterprise.Location = New System.Drawing.Point(528, 8)
        Me.cboEnterprise.Name = "cboEnterprise"
        Me.cboEnterprise.Size = New System.Drawing.Size(176, 21)
        Me.cboEnterprise.TabIndex = 13
        '
        'tvMAIN
        '
        Me.tvMAIN.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.tvMAIN.ImageIndex = -1
        Me.tvMAIN.Location = New System.Drawing.Point(1, 32)
        Me.tvMAIN.Name = "tvMAIN"
        Me.tvMAIN.SelectedImageIndex = -1
        Me.tvMAIN.Size = New System.Drawing.Size(199, 520)
        Me.tvMAIN.TabIndex = 18
        '
        'lblDefinedBillGroups
        '
        Me.lblDefinedBillGroups.BackColor = System.Drawing.Color.LightYellow
        Me.lblDefinedBillGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDefinedBillGroups.Location = New System.Drawing.Point(1, 0)
        Me.lblDefinedBillGroups.Name = "lblDefinedBillGroups"
        Me.lblDefinedBillGroups.Size = New System.Drawing.Size(199, 32)
        Me.lblDefinedBillGroups.TabIndex = 19
        Me.lblDefinedBillGroups.Text = "DEFINED BILL GROUPS"
        Me.lblDefinedBillGroups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNewBillGroup
        '
        Me.btnNewBillGroup.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnNewBillGroup.BackColor = System.Drawing.SystemColors.Control
        Me.btnNewBillGroup.Location = New System.Drawing.Point(1, 558)
        Me.btnNewBillGroup.Name = "btnNewBillGroup"
        Me.btnNewBillGroup.Size = New System.Drawing.Size(199, 32)
        Me.btnNewBillGroup.TabIndex = 21
        Me.btnNewBillGroup.Text = "NEW MANUFACTURER, MODEL, ENTERPRISE GROUP"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(784, 36)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 21)
        Me.btnCancel.TabIndex = 27
        Me.btnCancel.Text = "CANCEL"
        '
        'btnCreateModelEnt
        '
        Me.btnCreateModelEnt.BackColor = System.Drawing.SystemColors.Control
        Me.btnCreateModelEnt.Location = New System.Drawing.Point(712, 8)
        Me.btnCreateModelEnt.Name = "btnCreateModelEnt"
        Me.btnCreateModelEnt.Size = New System.Drawing.Size(208, 21)
        Me.btnCreateModelEnt.TabIndex = 32
        Me.btnCreateModelEnt.Text = "CREATE MODEL FOR ENTERPRISE"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMain.Location = New System.Drawing.Point(208, 152)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(812, 440)
        Me.pnlMain.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.MintCream
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(216, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "PART #"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.MintCream
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(320, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "DESCRIPTION"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.MintCream
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(480, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Level"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.MintCream
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(520, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "PRICE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label5.BackColor = System.Drawing.Color.PaleGreen
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(575, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "BG1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(623, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "BG2"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label7.BackColor = System.Drawing.Color.PaleGreen
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(671, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "BG3"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(719, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "BG4"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label9.BackColor = System.Drawing.Color.PaleGreen
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(767, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "BG5"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(815, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "BG6"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label11.BackColor = System.Drawing.Color.PaleGreen
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(863, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "BG7"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(911, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "BG8"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label13.BackColor = System.Drawing.Color.PaleGreen
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(959, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 16)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "BG9"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTargetName
        '
        Me.lblTargetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetName.ForeColor = System.Drawing.Color.Black
        Me.lblTargetName.Location = New System.Drawing.Point(304, 72)
        Me.lblTargetName.Name = "lblTargetName"
        Me.lblTargetName.Size = New System.Drawing.Size(80, 16)
        Me.lblTargetName.TabIndex = 47
        Me.lblTargetName.Text = "TARGET"
        Me.lblTargetName.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBERN
        '
        Me.lblBERN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBERN.ForeColor = System.Drawing.Color.Blue
        Me.lblBERN.Location = New System.Drawing.Point(392, 72)
        Me.lblBERN.Name = "lblBERN"
        Me.lblBERN.Size = New System.Drawing.Size(80, 16)
        Me.lblBERN.TabIndex = 48
        Me.lblBERN.Text = "BER CAP"
        Me.lblBERN.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblTarget
        '
        Me.lblTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarget.ForeColor = System.Drawing.Color.Black
        Me.lblTarget.Location = New System.Drawing.Point(304, 88)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(80, 24)
        Me.lblTarget.TabIndex = 49
        Me.lblTarget.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBER
        '
        Me.lblBER.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBER.ForeColor = System.Drawing.Color.Blue
        Me.lblBER.Location = New System.Drawing.Point(392, 88)
        Me.lblBER.Name = "lblBER"
        Me.lblBER.Size = New System.Drawing.Size(80, 24)
        Me.lblBER.TabIndex = 50
        Me.lblBER.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label14.BackColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(208, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(800, 8)
        Me.Label14.TabIndex = 61
        '
        'L8
        '
        Me.L8.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L8.BackColor = System.Drawing.Color.SteelBlue
        Me.L8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L8.ForeColor = System.Drawing.Color.White
        Me.L8.Location = New System.Drawing.Point(911, 72)
        Me.L8.Name = "L8"
        Me.L8.Size = New System.Drawing.Size(48, 32)
        Me.L8.TabIndex = 60
        Me.L8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L6
        '
        Me.L6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L6.BackColor = System.Drawing.Color.SteelBlue
        Me.L6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L6.ForeColor = System.Drawing.Color.White
        Me.L6.Location = New System.Drawing.Point(815, 72)
        Me.L6.Name = "L6"
        Me.L6.Size = New System.Drawing.Size(48, 32)
        Me.L6.TabIndex = 59
        Me.L6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L4
        '
        Me.L4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L4.BackColor = System.Drawing.Color.SteelBlue
        Me.L4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L4.ForeColor = System.Drawing.Color.White
        Me.L4.Location = New System.Drawing.Point(719, 72)
        Me.L4.Name = "L4"
        Me.L4.Size = New System.Drawing.Size(48, 32)
        Me.L4.TabIndex = 58
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L2
        '
        Me.L2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L2.BackColor = System.Drawing.Color.SteelBlue
        Me.L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L2.ForeColor = System.Drawing.Color.White
        Me.L2.Location = New System.Drawing.Point(623, 72)
        Me.L2.Name = "L2"
        Me.L2.Size = New System.Drawing.Size(48, 32)
        Me.L2.TabIndex = 57
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L9
        '
        Me.L9.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L9.BackColor = System.Drawing.Color.LightGreen
        Me.L9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L9.ForeColor = System.Drawing.Color.Red
        Me.L9.Location = New System.Drawing.Point(959, 72)
        Me.L9.Name = "L9"
        Me.L9.Size = New System.Drawing.Size(48, 32)
        Me.L9.TabIndex = 56
        Me.L9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L7
        '
        Me.L7.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L7.BackColor = System.Drawing.Color.LightGreen
        Me.L7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L7.ForeColor = System.Drawing.Color.Red
        Me.L7.Location = New System.Drawing.Point(863, 72)
        Me.L7.Name = "L7"
        Me.L7.Size = New System.Drawing.Size(48, 32)
        Me.L7.TabIndex = 55
        Me.L7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L5
        '
        Me.L5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L5.BackColor = System.Drawing.Color.LightGreen
        Me.L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L5.ForeColor = System.Drawing.Color.Red
        Me.L5.Location = New System.Drawing.Point(767, 72)
        Me.L5.Name = "L5"
        Me.L5.Size = New System.Drawing.Size(48, 32)
        Me.L5.TabIndex = 54
        Me.L5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L3
        '
        Me.L3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L3.BackColor = System.Drawing.Color.LightGreen
        Me.L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L3.ForeColor = System.Drawing.Color.Red
        Me.L3.Location = New System.Drawing.Point(671, 72)
        Me.L3.Name = "L3"
        Me.L3.Size = New System.Drawing.Size(48, 32)
        Me.L3.TabIndex = 53
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L1
        '
        Me.L1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.L1.BackColor = System.Drawing.Color.LightGreen
        Me.L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L1.ForeColor = System.Drawing.Color.Red
        Me.L1.Location = New System.Drawing.Point(575, 72)
        Me.L1.Name = "L1"
        Me.L1.Size = New System.Drawing.Size(48, 32)
        Me.L1.TabIndex = 52
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label15.BackColor = System.Drawing.Color.Gainsboro
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(484, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 32)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "BILL GROUP VALUE"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label16.BackColor = System.Drawing.Color.MintCream
        Me.Label16.Location = New System.Drawing.Point(208, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(800, 16)
        Me.Label16.TabIndex = 62
        '
        'Label17
        '
        Me.Label17.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label17.BackColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(208, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(800, 8)
        Me.Label17.TabIndex = 63
        '
        'idx_txtBG
        '
        Me.idx_txtBG.BackColor = System.Drawing.Color.LightBlue
        Me.idx_txtBG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.idx_txtBG.Location = New System.Drawing.Point(200, 40)
        Me.idx_txtBG.Name = "idx_txtBG"
        Me.idx_txtBG.Size = New System.Drawing.Size(16, 13)
        Me.idx_txtBG.TabIndex = 64
        Me.idx_txtBG.Text = ""
        '
        'Label18
        '
        Me.Label18.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label18.BackColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(484, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(524, 8)
        Me.Label18.TabIndex = 65
        '
        'Label28
        '
        Me.Label28.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label28.BackColor = System.Drawing.Color.Firebrick
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(484, 104)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 16)
        Me.Label28.TabIndex = 75
        Me.Label28.Text = "INACTIVE"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive1
        '
        Me.chkInactive1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive1.BackColor = System.Drawing.Color.LightGreen
        Me.chkInactive1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive1.Location = New System.Drawing.Point(575, 104)
        Me.chkInactive1.Name = "chkInactive1"
        Me.chkInactive1.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive1.TabIndex = 76
        Me.chkInactive1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive2
        '
        Me.chkInactive2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive2.BackColor = System.Drawing.Color.SteelBlue
        Me.chkInactive2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive2.Location = New System.Drawing.Point(623, 104)
        Me.chkInactive2.Name = "chkInactive2"
        Me.chkInactive2.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive2.TabIndex = 77
        Me.chkInactive2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive3
        '
        Me.chkInactive3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive3.BackColor = System.Drawing.Color.LightGreen
        Me.chkInactive3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive3.Location = New System.Drawing.Point(671, 104)
        Me.chkInactive3.Name = "chkInactive3"
        Me.chkInactive3.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive3.TabIndex = 78
        Me.chkInactive3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive4
        '
        Me.chkInactive4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive4.BackColor = System.Drawing.Color.SteelBlue
        Me.chkInactive4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive4.Location = New System.Drawing.Point(719, 104)
        Me.chkInactive4.Name = "chkInactive4"
        Me.chkInactive4.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive4.TabIndex = 79
        Me.chkInactive4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive5
        '
        Me.chkInactive5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive5.BackColor = System.Drawing.Color.LightGreen
        Me.chkInactive5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive5.Location = New System.Drawing.Point(767, 104)
        Me.chkInactive5.Name = "chkInactive5"
        Me.chkInactive5.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive5.TabIndex = 80
        Me.chkInactive5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive6
        '
        Me.chkInactive6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive6.BackColor = System.Drawing.Color.SteelBlue
        Me.chkInactive6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive6.Location = New System.Drawing.Point(815, 104)
        Me.chkInactive6.Name = "chkInactive6"
        Me.chkInactive6.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive6.TabIndex = 81
        Me.chkInactive6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive7
        '
        Me.chkInactive7.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive7.BackColor = System.Drawing.Color.LightGreen
        Me.chkInactive7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive7.Location = New System.Drawing.Point(863, 104)
        Me.chkInactive7.Name = "chkInactive7"
        Me.chkInactive7.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive7.TabIndex = 82
        Me.chkInactive7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive8
        '
        Me.chkInactive8.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive8.BackColor = System.Drawing.Color.SteelBlue
        Me.chkInactive8.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive8.Location = New System.Drawing.Point(911, 104)
        Me.chkInactive8.Name = "chkInactive8"
        Me.chkInactive8.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive8.TabIndex = 83
        Me.chkInactive8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkInactive9
        '
        Me.chkInactive9.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkInactive9.BackColor = System.Drawing.Color.LightGreen
        Me.chkInactive9.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInactive9.Location = New System.Drawing.Point(959, 104)
        Me.chkInactive9.Name = "chkInactive9"
        Me.chkInactive9.Size = New System.Drawing.Size(48, 16)
        Me.chkInactive9.TabIndex = 84
        Me.chkInactive9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLabor
        '
        Me.lblLabor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabor.ForeColor = System.Drawing.Color.Red
        Me.lblLabor.Location = New System.Drawing.Point(208, 88)
        Me.lblLabor.Name = "lblLabor"
        Me.lblLabor.Size = New System.Drawing.Size(80, 24)
        Me.lblLabor.TabIndex = 86
        Me.lblLabor.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(208, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 16)
        Me.Label20.TabIndex = 85
        Me.Label20.Text = "PART VAL"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmBillGroupsAdmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(1028, 621)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLabor, Me.Label20, Me.chkInactive9, Me.chkInactive7, Me.chkInactive6, Me.chkInactive5, Me.chkInactive3, Me.L1, Me.chkInactive1, Me.Label28, Me.idx_txtBG, Me.Label17, Me.Label14, Me.L8, Me.L6, Me.L4, Me.L2, Me.L9, Me.L7, Me.L5, Me.L3, Me.Label15, Me.lblBER, Me.lblTarget, Me.lblBERN, Me.lblTargetName, Me.Label13, Me.Label12, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.pnlMain, Me.lblDefinedBillGroups, Me.tvMAIN, Me.cboEnterprise, Me.cboModel, Me.cboManufacturer, Me.lblEnterprise, Me.lblManufacturer, Me.cboCustomer, Me.lblModel, Me.lblCustomer, Me.Label16, Me.Label18, Me.chkInactive2, Me.chkInactive4, Me.chkInactive8, Me.btnNewBillGroup, Me.btnCreateModelEnt, Me.btnCancel})
        Me.Name = "frmBillGroupsAdmin"
        Me.Text = "frmABgroup"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*****************************************************************
    Private Sub frmABgroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            System.Windows.Forms.Application.DoEvents()

            'Populate combo box
            Load_CustomerList()
            Load_ManufacturerList()
            Load_EnterpriseList()

            'Disable Combo box
            Enable_Disable_cboboxes(False)

            _Active = True

            'Hide create new billgroup button
            HideShowButtons(False)

            'Populate Treeview
            _objBillGrpAdmin.PopulateTreeView(tvMAIN, cboCustomer.SelectedValue)

            System.Windows.Forms.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmABgroup_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub Load_CustomerList()
        Try
            dtCustomer = _objBillGrpAdmin.GetCustomerList
            cboCustomer.DataSource = dtCustomer
            cboCustomer.ValueMember = dtCustomer.Columns("Cust_ID").ToString
            cboCustomer.DisplayMember = dtCustomer.Columns("Cust_Name").ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub Load_ManufacturerList()
        Try
            dtManufacturer = _objBillGrpAdmin.GetManufacturerList
            cboManufacturer.DataSource = dtManufacturer
            cboManufacturer.ValueMember = dtManufacturer.Columns("Manuf_ID").ToString
            cboManufacturer.DisplayMember = dtManufacturer.Columns("Manuf_Desc").ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub Load_EnterpriseList()
        Try
            dtEnterprise = _objBillGrpAdmin.GetEnterpriseList(cboCustomer.SelectedValue)
            cboEnterprise.DataSource = dtEnterprise
            cboEnterprise.ValueMember = dtEnterprise.Columns("Ent_ID").ToString
            cboEnterprise.DisplayMember = dtEnterprise.Columns("Ent_Desc").ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub Enable_Disable_cboboxes(ByVal booEnableDisableVal As Boolean)
        cboManufacturer.Enabled = booEnableDisableVal
        cboModel.Enabled = booEnableDisableVal
        cboEnterprise.Enabled = booEnableDisableVal
    End Sub

    '*****************************************************************
    Private Sub HideShowButtons(ByVal booVisibleInvisibleVal As Boolean)
        btnCancel.Visible = booVisibleInvisibleVal
        btnCreateModelEnt.Visible = booVisibleInvisibleVal
    End Sub

    '*****************************************************************
    Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
        Try
            If Me._Active = True Then

                'Refresh treeview
                tvMAIN.Nodes.Clear()

                If Me._booNewBillGrp = False Then
                    Me._objBillGrpAdmin.PopulateTreeView(tvMAIN, cboCustomer.SelectedValue)
                End If

                '//setCustomerMarkup
                dbCustMarkup = 1 + Me._objBillGrpAdmin.GetMarkup(cboCustomer.SelectedValue)

                'Refresh Enterprise list
                Load_EnterpriseList()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Customer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub cboManufacturer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectedValueChanged
        Try
            If _Active = True Then Load_ModelList()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Manufacturer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub Load_ModelList()
        Try
            If cboManufacturer.SelectedValue > 0 Then
                dtModel = _objBillGrpAdmin.GetModelList(cboManufacturer.SelectedValue)
                cboModel.DataSource = dtModel
                cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
                cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub cboModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
        Try
            If _Active = True Then
                If Me._booNewBillGrp = False Then
                    Me.PopulateBillCodes()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Model_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub PopulateBillCodes()
        Dim wPanel As Integer = pnlMain.Width - 10
        Dim iTop As Integer = 0 '+ ctlHead.Height
        Dim i As Integer
        Dim R1 As DataRow
        Dim ctlPart() As ucABtemplate

        Try
            pnlMain.Controls.Clear()
            dtBillCodes = Me._objBillGrpAdmin.GetAllBillCodes_OfModel(cboModel.SelectedValue)

            ReDim ctlPart(dtBillCodes.Rows.Count)

            For i = 0 To dtBillCodes.Rows.Count - 1
                R1 = dtBillCodes.Rows(i)

                ctlPart(i) = New ucABtemplate(cboCustomer.SelectedValue, _
                                              cboModel.SelectedValue, _
                                              cboEnterprise.Text, _
                                              R1("billcode_id"), _
                                              R1("psprice"), _
                                              R1("PSPrice_Desc"), _
                                              R1("billcode_desc"), _
                                              R1("Laborlvl_ID"), _
                                              CDbl(CDbl(R1("psprice_stndcost")) * dbCustMarkup))

                ctlPart(i).Visible = False
                ctlPart(i).Enabled = True
                ctlPart(i).Name = "uceu" & i
                ctlPart(i).Tag = "TAG" & i
                pnlMain.Controls.Add(ctlPart(i))
                ctlPart(i).Left = 1
                ctlPart(i).Top = iTop + 1
                ctlPart(i).Width = wPanel
                ctlPart(i).Anchor = AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right
                ctlPart(i).Show()
                ctlPart(i).BringToFront()
                ctlPart(i).TabIndex = i

                iTop += ctlPart(i).Height
            Next i

            For i = 0 To UBound(ctlPart) - 1
                ctlPart(i).Visible = True
                ctlPart(i).Width = wPanel - 5
            Next i

            CalcValue(1)
            CalcValue(2)
            CalcValue(3)
            CalcValue(4)
            CalcValue(5)
            CalcValue(6)
            CalcValue(7)
            CalcValue(8)
            CalcValue(9)

        Catch ex As Exception
            Throw ex
            'MessageBox.Show(ex.ToString, "PopulateBillCodes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            If Not IsNothing(dtBillCodes) Then
                dtBillCodes.Dispose()
                dtBillCodes = Nothing
            End If
            If Not IsNothing(ctlPart) Then
                ctlPart = Nothing
            End If
        End Try
    End Sub

    '*****************************************************************
    Private Sub CalcValue(ByVal iBgv As Integer)
        Dim dResult As Double
        Dim strBillGrpName As String = ""

        Try
            strBillGrpName = "BG" & iBgv

            dResult = Me._objBillGrpAdmin.CalcBillGrpTotal(cboCustomer.SelectedValue, _
                                                         cboModel.SelectedValue, _
                                                         cboEnterprise.Text, _
                                                         strBillGrpName, _
                                                         dbCustMarkup)

            Select Case CInt(iBgv)
                Case 1
                    L1.Text = dResult
                Case 2
                    L2.Text = dResult
                Case 3
                    L3.Text = dResult
                Case 4
                    L4.Text = dResult
                Case 5
                    L5.Text = dResult
                Case 6
                    L6.Text = dResult
                Case 7
                    L7.Text = dResult
                Case 8
                    L8.Text = dResult
                Case 9
                    L9.Text = dResult
            End Select

            idx_txtBG.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub btnNewBillGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewBillGroup.Click
        Try
            Me._booNewBillGrp = True

            lblTarget.Text = ""
            lblBER.Text = ""
            lblLabor.Text = ""

            pnlMain.Controls.Clear()

            tvMAIN.Enabled = False
            Enable_Disable_cboboxes(True)
            HideShowButtons(True)
            btnNewBillGroup.Visible = False
            Enable_Disable_InactiveChkBoxes(False)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "NewBillGroup_ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub btnCreateModelEnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateModelEnt.Click
        Dim dt1 As DataTable
        Dim i As Integer = 0
        Dim R1 As DataRow
        Dim iModelBillLevel As Integer
        Dim decModelTarget As Decimal

        Try
            pnlMain.Controls.Clear()

            'Check if Model is auto-bill
            If Me._objBillGrpAdmin.GetModelAutoBillFlag(Me.cboModel.SelectedValue) = 0 Then
                MsgBox("This model does not set up for auto-bill.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'Check Target
            decModelTarget = _objBillGrpAdmin.GetTargetValue(cboCustomer.SelectedValue, Me.cboModel.SelectedValue, Me.cboEnterprise.Text)
            If decModelTarget = 0 Then
                MsgBox("Target does not exist for this model. Please set the target first.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            '//Check to see if customer/ model/ enterprise relation exists
            dt1 = Me._objBillGrpAdmin.GetBillGroupInfo_ByCustModEnt(cboCustomer.SelectedValue, cboModel.SelectedValue, cboEnterprise.Text)

            If dt1.Rows.Count > 0 Then
                MsgBox("This grouping already exists.", MsgBoxStyle.Critical)
                Exit Sub
            Else
                If MsgBox("Are you certain you want to add this definition?", MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.No Then
                    Exit Sub
                End If

                'Get Model bill level
                iModelBillLevel = Me._objBillGrpAdmin.GetBillLevel(cboCustomer.SelectedValue, cboModel.SelectedValue)

                '//get all billcodes for model from tpsmap
                dt1 = Me._objBillGrpAdmin.GetAllBillCodes_OfModel(cboModel.SelectedValue)

                'Insert each billcode into tbillgroup table
                For Each R1 In dt1.Rows
                    If _objBillGrpAdmin.DoesBillCodeExist(cboCustomer.SelectedValue, cboModel.SelectedValue, cboEnterprise.Text, "BG1", R1("billcode_id")) = False Then
                        i += Me._objBillGrpAdmin.InsertNewRecord_ToBillGroup(cboCustomer.SelectedValue, cboModel.SelectedValue, cboEnterprise.Text, "BG1", R1("billcode_id"), 1, iModelBillLevel)
                    End If
                Next R1
            End If

            _objBillGrpAdmin.PopulateTreeView(tvMAIN, cboCustomer.SelectedValue)
            System.Windows.Forms.Application.DoEvents()

            HideShowButtons(False)
            btnNewBillGroup.Visible = True

            Enable_Disable_cboboxes(False)
            Enable_Disable_InactiveChkBoxes(True)

            tvMAIN.Enabled = True
            Me._booNewBillGrp = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CreateModelEnt_ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*****************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Try
            tvMAIN.Enabled = True
            btnNewBillGroup.Visible = True

            HideShowButtons(False)
            Enable_Disable_cboboxes(False)
            Enable_Disable_InactiveChkBoxes(True)

            Me._booNewBillGrp = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CancelNewBillGroup_ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub Enable_Disable_InactiveChkBoxes(ByVal booCheckVal As Boolean)
        chkInactive1.Enabled = booCheckVal
        chkInactive2.Enabled = booCheckVal
        chkInactive3.Enabled = booCheckVal
        chkInactive4.Enabled = booCheckVal
        chkInactive5.Enabled = booCheckVal
        chkInactive6.Enabled = booCheckVal
        chkInactive7.Enabled = booCheckVal
        chkInactive8.Enabled = booCheckVal
        chkInactive9.Enabled = booCheckVal
    End Sub

    '*****************************************************************
    Private Sub Uncheck_InactiveChkboxes()
        chkInactive1.Checked = False
        chkInactive2.Checked = False
        chkInactive3.Checked = False
        chkInactive4.Checked = False
        chkInactive5.Checked = False
        chkInactive6.Checked = False
        chkInactive7.Checked = False
        chkInactive8.Checked = False
        chkInactive9.Checked = False
    End Sub

    '*****************************************************************
    Private Sub chkInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                            Handles chkInactive1.CheckedChanged, _
                                                    chkInactive2.CheckedChanged, _
                                                    chkInactive3.CheckedChanged, _
                                                    chkInactive4.CheckedChanged, _
                                                    chkInactive5.CheckedChanged, _
                                                    chkInactive6.CheckedChanged, _
                                                    chkInactive7.CheckedChanged, _
                                                    chkInactive8.CheckedChanged, _
                                                    chkInactive9.CheckedChanged
        Dim strBillGrpName As String = ""
        Dim booBillgrpExisted As Boolean = False
        Dim i As Integer = 0
        Dim iBillGrpNum As Integer = 0

        Try
            If sender.checked = False Then
                Exit Sub
            End If

            Select Case sender.name
                Case "chkInactive1"
                    iBillGrpNum = 1
                Case "chkInactive2"
                    iBillGrpNum = 2
                Case "chkInactive3"
                    iBillGrpNum = 3
                Case "chkInactive4"
                    iBillGrpNum = 4
                Case "chkInactive5"
                    iBillGrpNum = 5
                Case "chkInactive6"
                    iBillGrpNum = 6
                Case "chkInactive7"
                    iBillGrpNum = 7
                Case "chkInactive8"
                    iBillGrpNum = 8
                Case "chkInactive9"
                    iBillGrpNum = 9
            End Select

            If iBillGrpNum <> 0 Then

                strBillGrpName = "BG" & iBillGrpNum

                'Check for existing of billgroup
                booBillgrpExisted = Me._objBillGrpAdmin.DoesBillGroupExist(Me.cboCustomer.SelectedValue, Me.cboModel.SelectedValue, Me.cboEnterprise.Text, strBillGrpName)

                If booBillgrpExisted = True Then
                    'Set inactive flag to 1
                    i = Me._objBillGrpAdmin.SetBillGroupToInactive(Me.cboCustomer.SelectedValue, Me.cboModel.SelectedValue, Me.cboEnterprise.Text, strBillGrpName)

                    'Recalculate the bill group total and refresh control
                    Me.PopulateBillCodes()
                End If
            End If

            sender.checked = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "InactiveCheckBox_CheckedChangeEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub tvMAIN_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvMAIN.AfterSelect
        Dim i As Integer = 0
        Dim strEnt, strManuf, strModel As String
        Dim decTarget As Decimal = 0
        Dim decLvl3Labor As Decimal = 0

        Try
            Uncheck_InactiveChkboxes()

            lblTarget.Text = ""
            lblBER.Text = ""
            lblLabor.Text = ""
            strEnt = ""
            strManuf = ""
            strModel = ""

            If Not IsNothing(e.Node.Parent) Then
                If Not IsNothing(e.Node.Parent.Parent) Then
                    strModel = e.Node.Text
                    strManuf = e.Node.Parent.Text
                    strEnt = e.Node.Parent.Parent.Text
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            '//display Manufacturer into combobox
            For i = 0 To Me.cboManufacturer.Items.Count - 1
                If Me.cboManufacturer.Items(i)("Manuf_Desc") = strManuf Then
                    Me.cboManufacturer.SelectedValue = Me.cboManufacturer.Items(i)("Manuf_ID")
                    Exit For
                End If
            Next i

            'display Model into combobox
            Load_ModelList()

            For i = 0 To Me.cboModel.Items.Count - 1
                If Me.cboModel.Items(i)("Model_Desc") = strModel Then
                    Me.cboModel.SelectedValue = Me.cboModel.Items(i)("Model_ID")
                    Exit For
                End If
            Next i

            'display Enterprise into combobox
            For i = 0 To Me.cboEnterprise.Items.Count - 1
                If cboEnterprise.Items(i)("Ent_Desc") = strEnt Then
                    cboEnterprise.SelectedIndex = i
                    Exit For
                End If
            Next i

            System.Windows.Forms.Application.DoEvents()

            '//get target value
            decTarget = _objBillGrpAdmin.GetTargetValue(cboCustomer.SelectedValue, Me.cboModel.SelectedValue, strEnt)
            Me.lblTarget.Text = Format(decTarget, "####.##")
            '//get target value
            Me.lblBER.Text = Format(_objBillGrpAdmin.GetBERcap(cboCustomer.SelectedValue, Me.cboModel.SelectedValue, strEnt), "####.##")
            '//get labor value
            decLvl3Labor = _objBillGrpAdmin.GetLvl3LaborCharge(cboCustomer.SelectedValue, Me.cboModel.SelectedValue)
            Me.lblLabor.Text = Format(decTarget - decLvl3Labor, "####.##")

            'Make sure all billcodes in billgroup are active in tpsmap
            Me._objBillGrpAdmin.UpdateBillcodes_Status(cboCustomer.SelectedValue, Me.cboModel.SelectedValue, strEnt)

            PopulateBillCodes()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "treeviewMain_AfterSelect_Event", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************
    Private Sub idx_txtBG_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles idx_txtBG.TextChanged
        If Trim(idx_txtBG.Text) <> "" Then CalcValue(Trim(idx_txtBG.Text))
    End Sub

    '*****************************************************************


End Class


