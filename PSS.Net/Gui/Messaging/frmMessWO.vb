Option Explicit On 

Imports PSS.Core.Global

Public Class frmMessWO
    Inherits System.Windows.Forms.Form

    Private objMessAdmin As PSS.Data.Buisness.MessAdmin
    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iPSSWO_ID As Integer = 0
    Private iParentMiscWO_ID As Integer = 0
    Private iUSAMobWO_ID As Integer = 0
    Private iChildMiscWO_ID As Integer = 0
    Private iChildWOFlg As Integer = 0
    Private iLoc As Integer = 0
    Private strParentWorkOrder As String = ""
    Private Const strSpecialWO As String = "SpecialWO"
    Private _objDataProc As DBQuery.DataProc


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMessAdmin = New PSS.Data.Buisness.MessAdmin()

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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbLoc As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPO As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdAdminWOCancel As System.Windows.Forms.Button
    Friend WithEvents chkHasFile As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFinishedSKU As System.Windows.Forms.TextBox
    Friend WithEvents txtWOMemo As System.Windows.Forms.TextBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents cmbFreq As PSS.Gui.Controls.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdPSSWODel As System.Windows.Forms.Button
    Friend WithEvents PnlCustWO As System.Windows.Forms.Panel
    Friend WithEvents txtCapHigh As System.Windows.Forms.TextBox
    Friend WithEvents txtCapLength As System.Windows.Forms.TextBox
    Friend WithEvents txtCapLow As System.Windows.Forms.TextBox
    Friend WithEvents txtInstruction As System.Windows.Forms.TextBox
    Friend WithEvents lblInstruction As System.Windows.Forms.Label
    Friend WithEvents cmdWOSave As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents panelUSAMob As System.Windows.Forms.Panel
    Friend WithEvents lbl512 As System.Windows.Forms.Label
    Friend WithEvents lbl2400 As System.Windows.Forms.Label
    Friend WithEvents lbl1200 As System.Windows.Forms.Label
    Friend WithEvents lblFlex As System.Windows.Forms.Label
    Friend WithEvents txtChildWO As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtParentWO As System.Windows.Forms.TextBox
    Friend WithEvents lstChildWOs As System.Windows.Forms.ListBox
    Friend WithEvents lblChildWO As System.Windows.Forms.Label
    Friend WithEvents chkSpecialProj As System.Windows.Forms.CheckBox
    Friend WithEvents chkManualWO As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCOAMAcct As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkHasFile = New System.Windows.Forms.CheckBox()
        Me.cmdWOSave = New System.Windows.Forms.Button()
        Me.PnlCustWO = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl512 = New System.Windows.Forms.Label()
        Me.lbl2400 = New System.Windows.Forms.Label()
        Me.lbl1200 = New System.Windows.Forms.Label()
        Me.lblFlex = New System.Windows.Forms.Label()
        Me.cmbFreq = New PSS.Gui.Controls.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFinishedSKU = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtInstruction = New System.Windows.Forms.TextBox()
        Me.lblInstruction = New System.Windows.Forms.Label()
        Me.txtCapHigh = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCapLow = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCapLength = New System.Windows.Forms.TextBox()
        Me.cmdAdminWOCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtParentWO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPO = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLoc = New PSS.Gui.Controls.ComboBox()
        Me.txtWOMemo = New System.Windows.Forms.TextBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.cmdPSSWODel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelUSAMob = New System.Windows.Forms.Panel()
        Me.lblChildWO = New System.Windows.Forms.Label()
        Me.txtChildWO = New System.Windows.Forms.TextBox()
        Me.lstChildWOs = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkManualWO = New System.Windows.Forms.CheckBox()
        Me.chkSpecialProj = New System.Windows.Forms.CheckBox()
        Me.txtCOAMAcct = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PnlCustWO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelUSAMob.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(120, 48)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(176, 21)
        Me.cmbCustomer.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(40, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Customer:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkHasFile
        '
        Me.chkHasFile.BackColor = System.Drawing.Color.Transparent
        Me.chkHasFile.Checked = True
        Me.chkHasFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHasFile.Enabled = False
        Me.chkHasFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHasFile.ForeColor = System.Drawing.Color.Black
        Me.chkHasFile.Location = New System.Drawing.Point(24, 56)
        Me.chkHasFile.Name = "chkHasFile"
        Me.chkHasFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkHasFile.Size = New System.Drawing.Size(120, 16)
        Me.chkHasFile.TabIndex = 3
        Me.chkHasFile.Text = "Has Data File"
        '
        'cmdWOSave
        '
        Me.cmdWOSave.BackColor = System.Drawing.Color.Green
        Me.cmdWOSave.Enabled = False
        Me.cmdWOSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWOSave.ForeColor = System.Drawing.Color.White
        Me.cmdWOSave.Location = New System.Drawing.Point(80, 320)
        Me.cmdWOSave.Name = "cmdWOSave"
        Me.cmdWOSave.Size = New System.Drawing.Size(152, 32)
        Me.cmdWOSave.TabIndex = 4
        Me.cmdWOSave.Text = "SAVE WO"
        '
        'PnlCustWO
        '
        Me.PnlCustWO.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PnlCustWO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlCustWO.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label18, Me.lbl512, Me.lbl2400, Me.lbl1200, Me.lblFlex, Me.cmbFreq, Me.Label13, Me.txtFinishedSKU, Me.Label12})
        Me.PnlCustWO.Location = New System.Drawing.Point(312, 120)
        Me.PnlCustWO.Name = "PnlCustWO"
        Me.PnlCustWO.Size = New System.Drawing.Size(360, 176)
        Me.PnlCustWO.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(24, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(312, 48)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "The following information comes from the customer data file. If you are creating " & _
        "a WO without the customer data file you need to fill in the following informatio" & _
        "n."
        '
        'lbl512
        '
        Me.lbl512.BackColor = System.Drawing.Color.Transparent
        Me.lbl512.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl512.ForeColor = System.Drawing.Color.Blue
        Me.lbl512.Location = New System.Drawing.Point(164, 120)
        Me.lbl512.Name = "lbl512"
        Me.lbl512.Size = New System.Drawing.Size(208, 16)
        Me.lbl512.TabIndex = 4
        Me.lbl512.Text = "POCSAG 512 SKU:    XXFXXXXXXX"
        Me.lbl512.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl2400
        '
        Me.lbl2400.BackColor = System.Drawing.Color.Transparent
        Me.lbl2400.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2400.ForeColor = System.Drawing.Color.Blue
        Me.lbl2400.Location = New System.Drawing.Point(165, 152)
        Me.lbl2400.Name = "lbl2400"
        Me.lbl2400.Size = New System.Drawing.Size(208, 16)
        Me.lbl2400.TabIndex = 6
        Me.lbl2400.Text = "POCSAG 2400 SKU:  XX4XXXXXXX"
        Me.lbl2400.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl1200
        '
        Me.lbl1200.BackColor = System.Drawing.Color.Transparent
        Me.lbl1200.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1200.ForeColor = System.Drawing.Color.Blue
        Me.lbl1200.Location = New System.Drawing.Point(165, 136)
        Me.lbl1200.Name = "lbl1200"
        Me.lbl1200.Size = New System.Drawing.Size(208, 16)
        Me.lbl1200.TabIndex = 5
        Me.lbl1200.Text = "POCSAG 1200 SKU:  XXTXXXXXXX"
        Me.lbl1200.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFlex
        '
        Me.lblFlex.BackColor = System.Drawing.Color.Transparent
        Me.lblFlex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlex.ForeColor = System.Drawing.Color.Blue
        Me.lblFlex.Location = New System.Drawing.Point(164, 104)
        Me.lblFlex.Name = "lblFlex"
        Me.lblFlex.Size = New System.Drawing.Size(208, 16)
        Me.lblFlex.TabIndex = 3
        Me.lblFlex.Text = "Flex SKU:                    XXXXXXFLXX "
        Me.lblFlex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFreq
        '
        Me.cmbFreq.AutoComplete = True
        Me.cmbFreq.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFreq.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFreq.ForeColor = System.Drawing.Color.Black
        Me.cmbFreq.Location = New System.Drawing.Point(167, 56)
        Me.cmbFreq.Name = "cmbFreq"
        Me.cmbFreq.Size = New System.Drawing.Size(177, 21)
        Me.cmbFreq.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 16)
        Me.Label13.TabIndex = 107
        Me.Label13.Text = "Finished Goods SKU:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFinishedSKU
        '
        Me.txtFinishedSKU.Enabled = False
        Me.txtFinishedSKU.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtFinishedSKU.Location = New System.Drawing.Point(167, 80)
        Me.txtFinishedSKU.Name = "txtFinishedSKU"
        Me.txtFinishedSKU.Size = New System.Drawing.Size(176, 21)
        Me.txtFinishedSKU.TabIndex = 2
        Me.txtFinishedSKU.Text = ""
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(71, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "Frequency:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInstruction
        '
        Me.txtInstruction.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtInstruction.Location = New System.Drawing.Point(168, 80)
        Me.txtInstruction.Multiline = True
        Me.txtInstruction.Name = "txtInstruction"
        Me.txtInstruction.Size = New System.Drawing.Size(176, 54)
        Me.txtInstruction.TabIndex = 119
        Me.txtInstruction.Text = ""
        '
        'lblInstruction
        '
        Me.lblInstruction.BackColor = System.Drawing.Color.Transparent
        Me.lblInstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruction.ForeColor = System.Drawing.Color.Black
        Me.lblInstruction.Location = New System.Drawing.Point(32, 80)
        Me.lblInstruction.Name = "lblInstruction"
        Me.lblInstruction.Size = New System.Drawing.Size(120, 16)
        Me.lblInstruction.TabIndex = 109
        Me.lblInstruction.Text = "Instruction:"
        Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapHigh
        '
        Me.txtCapHigh.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCapHigh.Location = New System.Drawing.Point(168, 32)
        Me.txtCapHigh.Name = "txtCapHigh"
        Me.txtCapHigh.Size = New System.Drawing.Size(177, 21)
        Me.txtCapHigh.TabIndex = 2
        Me.txtCapHigh.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(48, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Cap Code Low:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapLow
        '
        Me.txtCapLow.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCapLow.Location = New System.Drawing.Point(168, 8)
        Me.txtCapLow.Name = "txtCapLow"
        Me.txtCapLow.Size = New System.Drawing.Size(177, 21)
        Me.txtCapLow.TabIndex = 1
        Me.txtCapLow.Text = ""
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(40, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 16)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "Cap Code High:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(24, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Cap Code Length:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapLength
        '
        Me.txtCapLength.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCapLength.Location = New System.Drawing.Point(168, 56)
        Me.txtCapLength.Name = "txtCapLength"
        Me.txtCapLength.Size = New System.Drawing.Size(50, 21)
        Me.txtCapLength.TabIndex = 3
        Me.txtCapLength.Text = ""
        '
        'cmdAdminWOCancel
        '
        Me.cmdAdminWOCancel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdAdminWOCancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdminWOCancel.ForeColor = System.Drawing.Color.Black
        Me.cmdAdminWOCancel.Location = New System.Drawing.Point(448, 320)
        Me.cmdAdminWOCancel.Name = "cmdAdminWOCancel"
        Me.cmdAdminWOCancel.Size = New System.Drawing.Size(88, 32)
        Me.cmdAdminWOCancel.TabIndex = 6
        Me.cmdAdminWOCancel.Text = "EXIT"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(0, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Work Order Memo:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtParentWO
        '
        Me.txtParentWO.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtParentWO.Location = New System.Drawing.Point(120, 96)
        Me.txtParentWO.Name = "txtParentWO"
        Me.txtParentWO.Size = New System.Drawing.Size(176, 21)
        Me.txtParentWO.TabIndex = 3
        Me.txtParentWO.Text = ""
        Me.txtParentWO.WordWrap = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(32, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Parent WO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(32, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "PO:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPO
        '
        Me.cmbPO.AutoComplete = True
        Me.cmbPO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPO.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPO.ForeColor = System.Drawing.Color.Black
        Me.cmbPO.Location = New System.Drawing.Point(128, 32)
        Me.cmbPO.Name = "cmbPO"
        Me.cmbPO.Size = New System.Drawing.Size(216, 21)
        Me.cmbPO.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Location:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLoc
        '
        Me.cmbLoc.AutoComplete = True
        Me.cmbLoc.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLoc.ForeColor = System.Drawing.Color.Black
        Me.cmbLoc.Location = New System.Drawing.Point(120, 72)
        Me.cmbLoc.Name = "cmbLoc"
        Me.cmbLoc.Size = New System.Drawing.Size(176, 21)
        Me.cmbLoc.TabIndex = 2
        '
        'txtWOMemo
        '
        Me.txtWOMemo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtWOMemo.Location = New System.Drawing.Point(128, 8)
        Me.txtWOMemo.Name = "txtWOMemo"
        Me.txtWOMemo.Size = New System.Drawing.Size(216, 21)
        Me.txtWOMemo.TabIndex = 1
        Me.txtWOMemo.Text = ""
        Me.txtWOMemo.WordWrap = False
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Location = New System.Drawing.Point(1, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(720, 40)
        Me.lblHeader.TabIndex = 112
        Me.lblHeader.Text = "CREATE MESSAGING WOs"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdPSSWODel
        '
        Me.cmdPSSWODel.BackColor = System.Drawing.Color.Red
        Me.cmdPSSWODel.Enabled = False
        Me.cmdPSSWODel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPSSWODel.ForeColor = System.Drawing.Color.White
        Me.cmdPSSWODel.Location = New System.Drawing.Point(312, 320)
        Me.cmdPSSWODel.Name = "cmdPSSWODel"
        Me.cmdPSSWODel.Size = New System.Drawing.Size(88, 32)
        Me.cmdPSSWODel.TabIndex = 5
        Me.cmdPSSWODel.Text = "DELETE WO"
        Me.cmdPSSWODel.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkHasFile, Me.Label2, Me.cmbPO, Me.txtWOMemo, Me.Label4})
        Me.Panel1.Location = New System.Drawing.Point(312, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 80)
        Me.Panel1.TabIndex = 2
        '
        'panelUSAMob
        '
        Me.panelUSAMob.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelUSAMob.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelUSAMob.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtInstruction, Me.lblInstruction, Me.txtCapHigh, Me.Label6, Me.txtCapLow, Me.Label10, Me.Label8, Me.txtCapLength})
        Me.panelUSAMob.Location = New System.Drawing.Point(632, 320)
        Me.panelUSAMob.Name = "panelUSAMob"
        Me.panelUSAMob.Size = New System.Drawing.Size(31, 24)
        Me.panelUSAMob.TabIndex = 116
        Me.panelUSAMob.Visible = False
        '
        'lblChildWO
        '
        Me.lblChildWO.BackColor = System.Drawing.Color.Transparent
        Me.lblChildWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildWO.ForeColor = System.Drawing.Color.Black
        Me.lblChildWO.Location = New System.Drawing.Point(8, 208)
        Me.lblChildWO.Name = "lblChildWO"
        Me.lblChildWO.Size = New System.Drawing.Size(104, 16)
        Me.lblChildWO.TabIndex = 118
        Me.lblChildWO.Text = "New Child WO:"
        Me.lblChildWO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtChildWO
        '
        Me.txtChildWO.Enabled = False
        Me.txtChildWO.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtChildWO.Location = New System.Drawing.Point(120, 208)
        Me.txtChildWO.Name = "txtChildWO"
        Me.txtChildWO.Size = New System.Drawing.Size(176, 21)
        Me.txtChildWO.TabIndex = 5
        Me.txtChildWO.Text = ""
        '
        'lstChildWOs
        '
        Me.lstChildWOs.Enabled = False
        Me.lstChildWOs.Location = New System.Drawing.Point(120, 144)
        Me.lstChildWOs.Name = "lstChildWOs"
        Me.lstChildWOs.Size = New System.Drawing.Size(176, 56)
        Me.lstChildWOs.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(16, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "All Child WOs:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCOAMAcct, Me.Label7, Me.chkManualWO, Me.chkSpecialProj, Me.lstChildWOs, Me.Label1, Me.txtChildWO, Me.cmbCustomer, Me.txtParentWO, Me.Label9, Me.lblChildWO, Me.Label3, Me.Label5, Me.cmbLoc})
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(312, 256)
        Me.Panel2.TabIndex = 1
        '
        'chkManualWO
        '
        Me.chkManualWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManualWO.ForeColor = System.Drawing.Color.Red
        Me.chkManualWO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkManualWO.Location = New System.Drawing.Point(32, 120)
        Me.chkManualWO.Name = "chkManualWO"
        Me.chkManualWO.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkManualWO.TabIndex = 121
        Me.chkManualWO.Text = "Manual WO"
        '
        'chkSpecialProj
        '
        Me.chkSpecialProj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSpecialProj.ForeColor = System.Drawing.Color.Red
        Me.chkSpecialProj.Location = New System.Drawing.Point(6, 232)
        Me.chkSpecialProj.Name = "chkSpecialProj"
        Me.chkSpecialProj.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSpecialProj.Size = New System.Drawing.Size(128, 24)
        Me.chkSpecialProj.TabIndex = 6
        Me.chkSpecialProj.Text = "Special Project"
        Me.chkSpecialProj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCOAMAcct
        '
        Me.txtCOAMAcct.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCOAMAcct.Location = New System.Drawing.Point(120, 16)
        Me.txtCOAMAcct.Name = "txtCOAMAcct"
        Me.txtCOAMAcct.Size = New System.Drawing.Size(176, 21)
        Me.txtCOAMAcct.TabIndex = 122
        Me.txtCOAMAcct.Text = ""
        Me.txtCOAMAcct.WordWrap = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 32)
        Me.Label7.TabIndex = 123
        Me.Label7.Text = "COAM Repair Account:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMessWO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(672, 359)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Panel1, Me.lblHeader, Me.PnlCustWO, Me.cmdAdminWOCancel, Me.cmdWOSave, Me.cmdPSSWODel, Me.panelUSAMob})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessWO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Messaging Work Orders"
        Me.PnlCustWO.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.panelUSAMob.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Protected Overrides Sub Finalize()
        objMessAdmin = Nothing
        MyBase.Finalize()
    End Sub

    '********************************************************************
    Private Sub cmdAdminWOCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdminWOCancel.Click
        Me.Close()
    End Sub

    '********************************************************************
    Private Sub frmMessWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadCustomers()
            Me.LoadFrequency()

            If ApplicationUser.GetPermission("MessEditDevices") = 0 Then
                Me.txtParentWO.Text = "SpecialWO"
                Me.ProcessParentWO()
                Me.cmbCustomer.Enabled = False
                Me.cmbLoc.Enabled = False
                Me.txtParentWO.Enabled = False
                Me.lstChildWOs.Enabled = False
                Me.cmbPO.Enabled = False
                Me.PnlCustWO.Visible = False
                Me.txtChildWO.Focus()
            End If

            SetFeaturesBasedOnCustomer()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub LoadCustomers()
        Dim dtCustomers As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim iCustID As Integer = 0
        
        Try
            dtCustomers = objMisc.GetCustomers(1)
            With Me.cmbCustomer
                .DataSource = dtCustomers.DefaultView
                .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                '****************************************
                'by default select 'American Messaging'
                '****************************************
                .SelectedValue = 14
                LoadLocations(14)
                '****************************************
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtCustomers) Then
                dtCustomers.Dispose()
                dtCustomers = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '********************************************************************
    Private Sub GetLocation(ByVal sLoc_name As String)
        Dim dtLoc As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            If sLoc_name = "" Then
                Exit Sub
            End If

            dtLoc = objMisc.GetLocation(sLoc_name)
            '**************************************************
            'Fill the Customer combo box
            '**************************************************
            With Me.cmbLoc
                .DataSource = dtLoc.DefaultView
                .ValueMember = dtLoc.Columns("Loc_id").ToString
                .DisplayMember = dtLoc.Columns("Loc_Name").ToString
                If dtLoc.Rows.Count = 2 Then
                    For Each R1 In dtLoc.Rows
                        If R1("Loc_id") <> 0 Then
                            .SelectedValue = R1("Loc_id")
                            LoadPOs(R1("Loc_id"))
                        End If
                    Next R1
                Else
                    .SelectedValue = 0
                End If

            End With
            '**************************************************
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtLoc) Then
                dtLoc.Dispose()
                dtLoc = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '********************************************************************
    Private Sub LoadFrequency()
        Dim dtFreq As New DataTable()
        Dim objMessMisc As New PSS.Data.Buisness.MessMisc()

        Try
            dtFreq = objMessMisc.GetFrequencies
            dtFreq.LoadDataRow(New Object() {"0", "-- Select --"}, False)

            With Me.cmbFreq
                .DataSource = dtFreq.DefaultView
                .DisplayMember = dtFreq.Columns("freq_Number").ToString
                .ValueMember = dtFreq.Columns("freq_id").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtFreq) Then
                dtFreq.Dispose()
                dtFreq = Nothing
            End If
            objMessMisc = Nothing
        End Try
    End Sub

    '********************************************************************
    Private Sub LoadLocations(ByVal iCust_id As Integer)
        Dim dtLoc As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            If iCust_id = 0 Then
                Exit Sub
            End If

            dtLoc = objMisc.GetLocations(iCust_id)
            '**************************************************
            'Fill the Customer combo box
            '**************************************************
            With Me.cmbLoc
                .DataSource = dtLoc.DefaultView
                .ValueMember = dtLoc.Columns("Loc_id").ToString
                .DisplayMember = dtLoc.Columns("Loc_Name").ToString
                If dtLoc.Rows.Count = 2 Then
                    For Each R1 In dtLoc.Rows
                        If R1("Loc_id") <> 0 Then
                            .SelectedValue = R1("Loc_id")
                            LoadPOs(R1("Loc_id"))
                        End If
                    Next R1
                Else
                    .SelectedValue = 0
                End If

            End With
            '**************************************************
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtLoc) Then
                dtLoc.Dispose()
                dtLoc = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadPOs(ByVal iLoc_id As Integer)
        Dim dtPO As DataTable
        Dim objMessRec As New PSS.Data.Buisness.MessReceive()

        Try
            If iLoc_id = 0 Then
                Exit Sub
            End If

            dtPO = objMessRec.GetPurchaseOrders(iLoc_id)
            '**************************************************
            'Fill the Customer combo box
            '**************************************************
            With Me.cmbPO
                .DataSource = dtPO.DefaultView
                .ValueMember = dtPO.Columns("PO_id").ToString
                .DisplayMember = dtPO.Columns("DisplayDesc").ToString
                .SelectedValue = 0
            End With
            '**************************************************
        Catch ex As Exception
            Throw ex
        Finally
            objMessRec = Nothing
            If Not IsNothing(dtPO) Then
                dtPO.Dispose()
                dtPO = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
        Try
            SetFeaturesBasedOnCustomer()

            'Me.ClearControls()

            'If Me.cmbCustomer.SelectedValue > 0 Then
            '    LoadLocations(Me.cmbCustomer.SelectedValue)
            'End If

            ''If Me.cmbCustomer.SelectedValue = 1 Then
            ''    Me.panelUSAMob.Visible = True
            ''Else
            ''    Me.panelUSAMob.Visible = False
            ''End If

            'If Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
            '    Me.PnlCustWO.Visible = False
            '    Me.Panel1.Visible = False
            '    txtChildWO.Visible = False
            '    lblChildWO.Visible = False
            '    chkSpecialProj.Visible = False
            'ElseIf Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID Then
            '    With Me
            '        .lstChildWOs.Items.Clear() : .lstChildWOs.Visible = False
            '        .Label9.Visible = False
            '        .lblChildWO.Visible = False
            '        .txtChildWO.Text = "" : .txtChildWO.Visible = False
            '        .chkSpecialProj.Checked = False : .chkSpecialProj.Visible = False
            '        .Label2.Visible = False
            '        If .cmbPO.Items.Count > 0 Then .cmbPO.SelectedValue = 0
            '        If .cmbFreq.Items.Count > 0 Then .cmbFreq.SelectedValue = 0
            '        .txtFinishedSKU.Text = ""
            '        .PnlCustWO.Visible = False
            '    End With
            'Else
            '    Me.panelUSAMob.Visible = True
            '    Me.Panel1.Visible = True
            '    txtChildWO.Visible = True
            '    lblChildWO.Visible = True
            '    chkSpecialProj.Visible = True
            'End If

            'Me.cmbLoc.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cmbCustomer_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub SetFeaturesBasedOnCustomer()
        Try
            Me.ClearControls()

            If Me.cmbCustomer.SelectedValue > 0 Then
                LoadLocations(Me.cmbCustomer.SelectedValue)
            End If

            'If Me.cmbCustomer.SelectedValue = 1 Then
            '    Me.panelUSAMob.Visible = True
            'Else
            '    Me.panelUSAMob.Visible = False
            'End If
            Me.chkManualWO.Checked = False : Me.chkManualWO.Visible = False

            If Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                Me.PnlCustWO.Visible = False
                Me.Panel1.Visible = False
                txtChildWO.Visible = False
                lblChildWO.Visible = False
                chkSpecialProj.Visible = False
            ElseIf Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID Then
                With Me
                    Me.Panel1.Visible = True
                    Me.txtWOMemo.Text = "REPAIR"
                    Me.txtParentWO.Text = "SpecialWO " & Format(Now(), "MMddyyyy")
                    .lstChildWOs.Items.Clear() : .lstChildWOs.Visible = False
                    .Label9.Visible = False
                    .lblChildWO.Visible = False
                    .txtChildWO.Text = "" : .txtChildWO.Visible = False
                    .chkSpecialProj.Checked = False : .chkSpecialProj.Visible = False
                    .Label2.Visible = False
                    If .cmbPO.Items.Count > 0 Then .cmbPO.SelectedValue = 0
                    If .cmbFreq.Items.Count > 0 Then .cmbFreq.SelectedValue = 0
                    .cmbPO.Visible = False
                    .txtFinishedSKU.Text = ""
                    .PnlCustWO.Visible = False
                    Me.chkManualWO.Visible = True
                    'Me.txtParentWO.SelectAll() : Me.txtParentWO.Focus()
                End With
            Else
                Me.panelUSAMob.Visible = True
                Me.Panel1.Visible = True
                txtChildWO.Visible = True
                lblChildWO.Visible = True
                chkSpecialProj.Visible = True
            End If

            Me.cmbLoc.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CheckCustomer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbCustomer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCustomer.KeyUp
        If e.KeyValue = 13 Then
            If Me.cmbCustomer.SelectedValue > 0 Then
                Me.cmbLoc.Focus()
            End If
        End If
    End Sub

    '*********************************************************
    Private Sub txtCOAMAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCOAMAcct.KeyUp
        Dim intLoc As Integer = 0
        Dim strLoc As String = ""

        If e.KeyCode = Keys.Enter Then
            If Not Me.txtCOAMAcct.Text = "" Then
                strLoc = Me.txtCOAMAcct.Text
                GetLocation(strLoc)
                intLoc = CInt(Me.cmbLoc.SelectedValue)
                If intLoc = PSS.Data.Buisness.SkyTel.Franciscan_LOC_ID Then
                    Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID
                ElseIf intLoc = PSS.Data.Buisness.SkyTel.Anna_LOC_ID Then
                    Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID
                ElseIf intLoc = PSS.Data.Buisness.SkyTel.Lahey_LOC_ID Then
                    Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID
                ElseIf intLoc = PSS.Data.Buisness.SkyTel.Masco_LOC_ID Then
                    Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID
                ElseIf intLoc = PSS.Data.Buisness.SkyTel.Maine_LOC_ID Then
                    Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID
                ElseIf intLoc = PSS.Data.Buisness.SkyTel.SMHC_LOC_ID Then
                    Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID
                End If
                Me.txtCOAMAcct.Text = strLoc
                Me.txtParentWO.Text = ""
                Me.txtParentWO.Focus()
            End If
        End If
    End Sub

    '*********************************************************
    Private Sub cmbLoc_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLoc.SelectionChangeCommitted

        Try
            If Me.cmbLoc.SelectedValue > 0 Then
                LoadPOs(Me.cmbLoc.SelectedValue)
                Me.ClearControls(1)
                Me.txtParentWO.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Location", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmbLoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbLoc.KeyUp
        If e.KeyValue = 13 Then
            If Me.cmbLoc.SelectedValue > 0 Then
                Me.txtParentWO.Focus()
            End If
        End If
    End Sub

    '*********************************************************
    Private Sub txtParentWO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParentWO.TextChanged
        Try
            If Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID AndAlso Trim(Me.txtParentWO.Text) <> "" Then
                Me.cmdWOSave.Enabled = False
            ElseIf Trim(Me.txtParentWO.Text) <> "" Then
                Me.cmdWOSave.Enabled = True
            Else
                Me.cmdWOSave.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub txtParentWO_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtParentWO.KeyUp
        Try
            If e.KeyValue = 13 Then
                Me.ProcessParentWO()
                If Me.iChildWOFlg = 1 Then
                    Me.txtChildWO.Focus()
                ElseIf Trim(Me.txtParentWO.Text) <> "" Then
                    Me.txtWOMemo.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub txtParentWO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParentWO.Leave
        Try
            If (Not Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID) AndAlso Me.strParentWorkOrder <> Trim(Me.txtParentWO.Text) Then
                Me.ProcessParentWO()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Work Ordeifest repotr", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub ProcessParentWO()
        Dim dt1, dt2 As DataTable
        Dim R1 As DataRow
        Dim iCustWO_ID As Integer = 0
        Dim objMessReceive As New PSS.Data.Buisness.MessReceive()
        Dim iWORcvdDevCnt As Integer = 0
        Dim strBeginDTime As String = Format(Now.Date, "yyyyMMdd") & "000000"
        Dim strEndDTime As String = Format(Now.Date, "yyyyMMdd") & "235959"

        Try
            Me.ClearControls(2)

            '******************************************
            'validate customer, location and ParentWO
            '******************************************
            If Trim(Me.txtParentWO.Text) = "" Then
                Exit Sub
            End If

            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Process Parent WO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtParentWO.Text = ""
                Me.cmbCustomer.Focus()
                Exit Sub
            End If

            If Me.cmbLoc.SelectedValue = 0 Then
                MessageBox.Show("Please select Location.", "Process Parent WO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtParentWO.Text = ""
                Me.cmbLoc.Focus()
                Exit Sub
            End If

            '****************************************************
            'Check if wo is special wo then child wo is required
            '****************************************************
            Me.strParentWorkOrder = Trim(Me.txtParentWO.Text)
            If Me.cmbCustomer.SelectedValue <> 1 And UCase(Me.strParentWorkOrder) = UCase(Me.strSpecialWO) Then
                Me.iChildWOFlg = 1
                Me.lstChildWOs.Enabled = True
                Me.txtChildWO.Enabled = True
            Else
                Me.lstChildWOs.Enabled = False
                Me.txtChildWO.Enabled = False
            End If

            '**********************************
            'Get Customer Wo information
            '**********************************
            Select Case Me.cmbCustomer.SelectedValue
                Case 1              'USA Mobility
                    iCustWO_ID = LoadUSAMobWOData(UCase(Trim(Me.txtParentWO.Text)))
                Case Else
                    iCustWO_ID = LoadParentMiscCustWOData(UCase(Trim(Me.txtParentWO.Text)))
            End Select

            '''**********************************
            '''Get PSS Wo information
            '''**********************************
            ''If iCustWoExist = 0 Then
            ''    If (MessageBox.Show("The Work Order you entered did not get loaded with a 'Customer Data File'. Please make sure this is the case. Proceeding further will create a brand new workorder and you have to manually fill in all data for this Work Order. Proceed?", "Get Cutomer WO", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)) = DialogResult.Yes Then
            ''        iCreateCustWo = 1
            ''        iCreatePSSWo = 1
            ''    Else
            ''        Me.ClearControls(1)
            ''        Exit Sub
            ''    End If
            ''ElseIf iPSSWoExist = 0 Then
            ''    If (MessageBox.Show("PSS Work Order has not yet been created. Do you want to manully create it now?", "Get Cutomer WO", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)) = DialogResult.Yes Then
            ''        iCreatePSSWo = 1
            ''    Else
            ''        Me.ClearControls(1)
            ''        Exit Sub
            ''    End If
            ''End If

            '''If iWO_ID = 0 Then
            '''    MessageBox.Show("This is a new Work Order. Going ahead with this WO will create a New WO in the system.", "Add WO/Edit WO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '''Else
            '''    MessageBox.Show("This is an existing Work Order. Going ahead with this WO will update this WO in the system.", "Add WO/Edit WO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '''End If
            '''**********************************

            '*************************************
            'Can not update if wo contain devices
            '*************************************
            If iPSSWO_ID > 0 And Me.iChildWOFlg = 0 Then
                iWORcvdDevCnt = objMessReceive.GetWORcvdQty(iPSSWO_ID)
                If iWORcvdDevCnt > 0 Then
                    MsgBox("There are " & iWORcvdDevCnt & " devices already received for this WO. Can not modify WO.", MsgBoxStyle.Critical)
                    Me.ClearControls(1)
                    Me.txtParentWO.Focus()
                End If
            End If

            If Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID Then
                dt2 = Me.objMessAdmin.GetABACUSDownloadedData(strBeginDTime, strEndDTime, 2)
                If dt2.Rows.Count > 0 AndAlso Me.chkManualWO.Checked = False Then
                    Me.chkHasFile.Checked = True
                    Me.chkManualWO.Enabled = False
                    Me.cmdWOSave.Enabled = True
                    Me.cmdWOSave.Focus()
                ElseIf dt2.Rows.Count > 0 AndAlso Me.chkManualWO.Checked Then
                    Me.chkHasFile.Checked = False
                    Me.chkManualWO.Enabled = False
                    Me.cmdWOSave.Enabled = True
                    Me.cmdWOSave.Focus()
                Else
                    Dim result As Integer = MessageBox.Show("No new (unreceived) ABACUS data for today. Do you want to create a manual WO?", "Select", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        'MessageBox.Show("No pressed")
                        Me.chkHasFile.Checked = False
                        Me.chkManualWO.Enabled = False : Me.chkManualWO.Checked = True
                        Me.cmdWOSave.Enabled = True
                        Me.cmdWOSave.Focus()
                    Else
                        Me.cmdWOSave.Enabled = False
                        Me.txtParentWO.SelectAll() : Me.txtParentWO.Focus()
                    End If

                End If

            End If
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            objMessReceive = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '********************************************************************
    Private Sub ClearControls(Optional ByVal iKeepCtrl As Integer = 0)
        Try
            Me.iChildWOFlg = 0
            Me.iUSAMobWO_ID = 0
            Me.iParentMiscWO_ID = 0
            Me.iChildMiscWO_ID = 0
            Me.iPSSWO_ID = 0

            If iKeepCtrl = 0 Then
                If Me.cmbLoc.Items.Count > 0 Then
                    Me.cmbLoc.SelectedValue = 0
                End If
                Me.txtParentWO.Text = ""
                Me.txtChildWO.Text = ""
            End If

            If iKeepCtrl = 1 Then
                Me.txtParentWO.Text = ""
                Me.strParentWorkOrder = ""
            End If

            Me.lstChildWOs.DataSource = Nothing
            Me.lstChildWOs.Items.Clear()
            Me.lstChildWOs.Refresh()
            Me.txtChildWO.Text = ""
            Me.lstChildWOs.Enabled = False
            Me.txtChildWO.Enabled = False
            If Not Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID Then
                Me.txtWOMemo.Text = ""
            End If

            If Me.cmbPO.Items.Count > 0 Then
                Me.cmbPO.SelectedValue = 0
            End If
            'Me.chkHasFile.Checked = False

            Me.cmbFreq.SelectedValue = 0
            Me.txtFinishedSKU.Text = ""
            If Me.cmbFreq.Items.Count > 0 Then
                Me.cmbFreq.SelectedValue = 0
            End If

            Me.txtCapLow.Text = ""
            Me.txtCapHigh.Text = ""
            Me.txtCapLength.Text = ""
            Me.txtInstruction.Text = ""

            Me.chkSpecialProj.Checked = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All Controls", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Function LoadUSAMobWOData(ByVal strWO_Name As String) As Integer
        Dim R1 As DataRow
        Dim R2 As DataRowView
        Dim dt1 As DataTable
        Dim i As Integer = 0

        Try
            dt1 = Me.objMessAdmin.GetUSAMobWOInfo(strWO_Name)

            If Not IsNothing(dt1) Then
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)

                    Me.iUSAMobWO_ID = R1("USA_ID")

                    If Not IsDBNull(R1("USA_CapLow")) Then
                        Me.txtCapLow.Text = Trim(R1("USA_CapLow"))
                    End If

                    If Not IsDBNull(R1("USA_CapHigh")) Then
                        Me.txtCapHigh.Text = Trim(R1("USA_CapHigh"))
                    End If

                    If Not IsDBNull(R1("USA_Pad")) Then
                        Me.txtCapLength.Text = Trim(R1("USA_Pad"))
                    End If

                    If Not IsDBNull(R1("USA_Freq")) Then
                        For i = 0 To Me.cmbFreq.Items.Count - 1
                            R2 = Me.cmbFreq.Items.Item(i)
                            If R2(Me.cmbFreq.DisplayMember) = R1("USA_Freq") Then
                                Me.cmbFreq.SelectedValue = R2(Me.cmbFreq.ValueMember)
                                Exit For
                            End If
                        Next i
                    End If

                    If Not IsDBNull(R1("USA_FinishedGoodsSKU")) Then
                        Me.txtFinishedSKU.Text = Trim(R1("USA_FinishedGoodsSKU"))
                    End If

                    If Not IsDBNull(R1("USA_Instructions")) Then
                        Me.txtInstruction.Text = Trim(R1("USA_Instructions"))
                        Me.txtInstruction.ReadOnly = True
                    End If

                    Me.chkHasFile.Checked = True


                    '**********************************
                    'Get PSS Wo information
                    '**********************************
                    Me.LoadPSSData(UCase(Trim(Me.txtParentWO.Text)))
                    '**********************************
                Else
                    Me.chkHasFile.Checked = False
                End If
            Else
                Me.chkHasFile.Checked = False
            End If

            Me.lstChildWOs.Enabled = False
            Me.txtChildWO.Enabled = False

            Return Me.iUSAMobWO_ID
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    '*********************************************************
    Private Function LoadParentMiscCustWOData(ByVal strWO_Name As String) As Integer
        Dim R1 As DataRow
        Dim R2 As DataRowView
        Dim dt1, dt2 As DataTable
        Dim i As Integer = 0

        Try

            dt1 = Me.objMessAdmin.GetMiscCustWOInfo(strWO_Name, Me.cmbCustomer.SelectedValue)

            If Not IsNothing(dt1) Then
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)

                    If Not IsDBNull(R1("parent_mmw_id")) Then
                        MessageBox.Show("This is a 'Child WO'. Please enter 'Parent WO'.", "Process Parent WO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.ClearControls(1)
                        Me.txtParentWO.Focus()
                        Exit Function
                    End If

                    Me.iParentMiscWO_ID = R1("mmw_id")

                    '**************************
                    'Get all child WOs
                    '**************************
                    If Me.iChildWOFlg = 1 Then
                        dt2 = Me.objMessAdmin.GetAllChildWOs(Me.iParentMiscWO_ID, Me.cmbCustomer.SelectedValue)

                        If dt2.Rows.Count > 0 Then
                            Me.lstChildWOs.DataSource = dt2.DefaultView
                            Me.lstChildWOs.DisplayMember = dt2.Columns("mmw_wo").ToString
                            Me.lstChildWOs.ValueMember = dt2.Columns("mmw_id").ToString
                        End If
                        Me.chkHasFile.Checked = True
                        Exit Function
                    Else
                        '**********************************
                        'Get PSS Wo information
                        '**********************************
                        Me.LoadPSSData(UCase(Trim(Me.txtParentWO.Text)))
                        '**********************************
                    End If

                    '**************************

                    If Not IsDBNull(R1("mmw_caplow")) Then
                        Me.txtCapLow.Text = Trim(R1("mmw_caplow"))
                    End If

                    If Not IsDBNull(R1("mmw_caphigh")) Then
                        Me.txtCapHigh.Text = Trim(R1("mmw_caphigh"))
                    End If

                    If Not IsDBNull(R1("mmw_CapCodeLen")) Then
                        Me.txtCapLength.Text = Trim(R1("mmw_CapCodeLen"))
                    End If

                    If Not IsDBNull(R1("mmw_freq")) Then
                        For i = 0 To Me.cmbFreq.Items.Count - 1
                            R2 = Me.cmbFreq.Items.Item(i)
                            If R2(Me.cmbFreq.DisplayMember) = R1("mmw_freq") Then
                                Me.cmbFreq.SelectedValue = R2(Me.cmbFreq.ValueMember)
                                Exit For
                            End If
                        Next i
                    End If

                    If Not IsDBNull(R1("mmw_sku")) Then
                        Me.txtFinishedSKU.Text = R1("mmw_sku")
                    End If

                    If Not IsDBNull(R1("mmw_CameWithFileFlag")) Then
                        If R1("mmw_CameWithFileFlag") = 1 Then
                            Me.chkHasFile.Checked = True
                        Else
                            Me.chkHasFile.Checked = False
                        End If
                    Else
                        Me.chkHasFile.Checked = False
                    End If
                Else
                    Me.chkHasFile.Checked = False
                End If
            Else
                Me.chkHasFile.Checked = False
            End If

            Return Me.iParentMiscWO_ID
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            R2 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            If Not IsNothing(dt2) Then
                dt2.Dispose()
                dt2 = Nothing
            End If
        End Try
    End Function

    '*********************************************************
    Private Function LoadPSSData(ByVal strWO_Name As String) As Integer
        Dim objMessRec As New PSS.Data.Buisness.MessReceive()
        Dim R1 As DataRow
        Dim dt1 As DataTable

        Try
            dt1 = objMessAdmin.GetPSSWOInfo(strWO_Name, Me.cmbLoc.SelectedValue)

            For Each R1 In dt1.Rows
                If Not IsDBNull(R1("WO_ID")) Then
                    Me.iPSSWO_ID = R1("WO_ID")

                    If Not IsDBNull(R1("WO_Memo")) Then
                        Me.txtWOMemo.Text = Trim(R1("WO_Memo"))
                    End If

                    If Not IsDBNull(R1("PO_ID")) Then
                        Me.cmbPO.SelectedValue = R1("PO_ID")
                    End If

                    Exit For
                End If
            Next R1

            Return Me.iPSSWO_ID
        Catch ex As Exception
            Throw ex
        Finally
            objMessRec = Nothing
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    '*********************************************************
    Private Sub txtChildWO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChildWO.KeyUp
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim R2 As DataRowView
        Dim i = 0
        Dim iPSSWO_ID As Integer = 0
        Dim iWORcvdDevCnt As Integer = 0
        Dim objMessReceive As New PSS.Data.Buisness.MessReceive()

        Try
            If e.KeyValue = 13 Then
                '***********************************
                'Reset global variable for child wo
                '***********************************
                Me.ClearChildGlobalVarAndCtrls()
                '*****************************
                'validation parent WO
                '*****************************
                If Trim(Me.txtChildWO.Text) = "" Then
                    Exit Sub
                End If

                If Me.iParentMiscWO_ID = 0 Then
                    MessageBox.Show("Can not create child pallet when parent pallet is missing.", "Get Child WO Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '**********************************************
                'get child WO info and populate into controls
                '**********************************************
                dt1 = Me.objMessAdmin.GetChildWOInfo(Me.iParentMiscWO_ID, Trim(Me.txtChildWO.Text), Me.cmbCustomer.SelectedValue)

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)

                    Me.iChildMiscWO_ID = R1("mmw_id")

                    If Not IsDBNull(R1("mmw_caplow")) Then
                        Me.txtCapLow.Text = Trim(R1("mmw_caplow"))
                    End If

                    If Not IsDBNull(R1("mmw_caphigh")) Then
                        Me.txtCapHigh.Text = Trim(R1("mmw_caphigh"))
                    End If

                    If Not IsDBNull(R1("mmw_CapCodeLen")) Then
                        Me.txtCapLength.Text = Trim(R1("mmw_CapCodeLen"))
                    End If

                    If Not IsDBNull(R1("mmw_freq")) Then
                        For i = 0 To Me.cmbFreq.Items.Count - 1
                            R2 = Me.cmbFreq.Items.Item(i)
                            If R2(Me.cmbFreq.DisplayMember) = R1("mmw_freq") Then
                                Me.cmbFreq.SelectedValue = R2(Me.cmbFreq.ValueMember)
                                Exit For
                            End If
                        Next i
                    End If

                    If Not IsDBNull(R1("mmw_sku")) Then
                        Me.txtFinishedSKU.Text = R1("mmw_sku")
                    End If

                    If Not IsDBNull(R1("mmw_CameWithFileFlag")) Then
                        If R1("mmw_CameWithFileFlag") = 1 Then
                            Me.chkHasFile.Checked = True
                        Else
                            Me.chkHasFile.Checked = False
                        End If
                    Else
                        Me.chkHasFile.Checked = False
                    End If

                    '**********************************
                    'Get PSS Wo information
                    '**********************************
                    iPSSWO_ID = Me.LoadPSSData(Trim(Me.txtChildWO.Text))
                    '*****************************************************
                    'If PSS Wo contain devices then stop user from update WO
                    '*****************************************************
                    If iPSSWO_ID > 0 Then
                        iWORcvdDevCnt = objMessReceive.GetWORcvdQty(iPSSWO_ID)
                        If iWORcvdDevCnt > 0 Then
                            MsgBox("There are " & iWORcvdDevCnt & " devices already received for this WO. Can not modify WO.", MsgBoxStyle.Critical)
                            Me.ClearChildGlobalVarAndCtrls()
                            Me.txtChildWO.SelectAll()
                            Exit Sub
                        End If
                    End If
                    '*****************************************************
                End If

                Me.txtWOMemo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Child WO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            objMessReceive = Nothing
            R1 = Nothing
            R2 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub ClearChildGlobalVarAndCtrls()
        Me.iChildMiscWO_ID = 0
        Me.iPSSWO_ID = 0
        Me.txtWOMemo.Text = ""
        If Me.cmbPO.SelectedValue > 0 Then
            Me.cmbPO.SelectedValue = 0
        End If
        'Me.chkHasFile.Checked = False
        Me.txtFinishedSKU.Text = ""
        Me.cmbFreq.SelectedValue = 0
    End Sub

    '*********************************************************
    Private Sub cmdWOSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWOSave.Click
        Dim i As Integer = 0
        Dim iHasDataFile As Integer = 0
        Dim strFreqNum As String = ""
        Dim iSpecialProject As Integer = 0

        Try
            '************************************
            If (Not Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID _
                OrElse Not Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID) _
                AndAlso Trim(Me.txtChildWO.Text) = "" AndAlso Me.iChildWOFlg = 1 Then
                MessageBox.Show("This Workorder requires 'Child WO'. Please enter 'Child WO'.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            '*************************
            'Validate pss wo data
            '*************************
            If Trim(Me.txtParentWO.Text) = "" Then
                Me.txtParentWO.Focus()
                MessageBox.Show("Please enter Parent Work Order.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Me.cmbLoc.SelectedValue = 0 Then
                Me.cmbLoc.Focus()
                MessageBox.Show("Please select Location.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Trim(Me.txtWOMemo.Text) = "" AndAlso Me.cmbCustomer.SelectedValue <> PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                Me.txtWOMemo.Focus()
                MessageBox.Show("Please enter Work Order Memo.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If (Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID _
                OrElse Me.cmbCustomer.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID) _
                AndAlso Me.objMessAdmin.IsWorkOrderExist(Trim(Me.txtParentWO.Text)) Then
                MessageBox.Show("This work order '" & Trim(Me.txtParentWO.Text) & "' already exists.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtParentWO.Focus()
                Exit Sub
            End If
            '************************************
            'Capcode validations
            '************************************
            If Trim(Me.txtCapLow.Text) = "" And Trim(Me.txtCapHigh.Text) <> "" Then
                Me.txtCapLow.Focus()
                MessageBox.Show("If 'Cap Code Low' is provided you must provide 'Cap Code High' also.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Trim(Me.txtCapLow.Text) <> "" And Trim(Me.txtCapHigh.Text) = "" Then
                Me.txtCapHigh.Focus()
                MessageBox.Show("If 'Cap Code High' is provided you must provide 'Cap Code Low' also.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Trim(Me.txtCapHigh.Text) <> "" And Trim(Me.txtCapLow.Text) <> "" Then
                If Not IsNumeric(Trim(Me.txtCapHigh.Text)) Then
                    Me.txtCapHigh.Focus()
                    MessageBox.Show("'Cap Code High' must be a number. It can not be alpha-numeric.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If Not IsNumeric(Trim(Me.txtCapLow.Text)) Then
                    Me.txtCapLow.Focus()
                    MessageBox.Show("'Cap Code Low' must be a number. It can not be alpha-numeric.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                If CInt(Trim(Me.txtCapLow.Text)) > CInt(Trim(Me.txtCapHigh.Text)) Then
                    Me.txtCapLow.Focus()
                    MessageBox.Show("'Cap Code Low' must not be greater than 'Cap Code High'.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If Trim(Me.txtCapLength.Text) <> "" Then
                    If Not IsNumeric(Trim(Me.txtCapLength.Text)) Then
                        Me.txtCapLow.Focus()
                        MessageBox.Show("'Cap Code Length' must be a number. It can not be alpha-numeric.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    Me.txtCapLow.Focus()
                    MessageBox.Show("'Cap Code Length' must be provided if 'Cap Code Low' and 'Cap Code High' are entered.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If CInt(Trim(Me.txtCapLength.Text)) <> 7 And CInt(Trim(Me.txtCapLength.Text)) <> 9 Then
                    MessageBox.Show("'Cap Code Length' must be either 7 or 9.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
            If Trim(Me.txtCapLength.Text) = "" Then
                Me.txtCapLength.Text = "0"
            End If
            '*****************************************

            'If Me.cmbFreq.SelectedValue = 0 Then
            '    Me.cmbFreq.Focus()
            '    MessageBox.Show("Please select Frequency.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
            'If Trim(Me.txtFinishedSKU.Text) = "" Then
            '    Me.txtFinishedSKU.Focus()
            '    MessageBox.Show("Please enter Finished Goods Sku.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If


            '************************************
            Cursor.Current = Cursors.WaitCursor
            Me.cmdWOSave.Enabled = False

            If Me.chkHasFile.Checked = True Then
                iHasDataFile = 1
            End If
            If Me.cmbFreq.SelectedValue <> 0 Then
                strFreqNum = Trim(Me.cmbFreq.SelectedItem(Me.cmbFreq.DisplayMember))
            End If
            If Me.chkSpecialProj.Checked = True Then
                iSpecialProject = 1
            End If

            Me.Enabled = False

            i = Me.objMessAdmin.SaveWO(iPSSWO_ID, _
                                        Me.iUSAMobWO_ID, _
                                        Me.iParentMiscWO_ID, _
                                        Me.iChildMiscWO_ID, _
                                        Me.iChildWOFlg, _
                                        Me.cmbCustomer.SelectedValue, _
                                        UCase(Trim(Me.txtParentWO.Text)), _
                                        UCase(Trim(Me.txtChildWO.Text)), _
                                        Me.cmbLoc.SelectedValue, _
                                        UCase(Trim(Me.txtWOMemo.Text)), _
                                        Me.cmbPO.SelectedValue, _
                                        iHasDataFile, _
                                        UCase(Trim(Me.txtCapLow.Text)), _
                                        UCase(Trim(Me.txtCapHigh.Text)), _
                                        CInt(Trim(Me.txtCapLength.Text)), _
                                        strFreqNum, _
                                        UCase(Trim(Me.txtFinishedSKU.Text)), _
                                        UCase(Trim(Me.txtInstruction.Text)), _
                                        Me.strUserName, _
                                        Me.iUserID, _
                                        iSpecialProject)


            If i = 0 Then
                MessageBox.Show("Nothing get update in Workorder.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Work Order has been saved.", "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If ApplicationUser.GetPermission("MessEditDevices") = 0 Then
                Me.Close()
            End If
            Me.ClearControls()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Save Work Order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.ClearControls()
        Finally
            Cursor.Current = Cursors.Default
            Me.Enabled = True
            'Me.Close()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*********************************************************
    Private Sub RemoveSKU(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFlex.Click, lbl512.Click, lbl1200.Click, lbl2400.Click
        Try
            Me.txtFinishedSKU.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get SKU", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub GetSKU(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFlex.DoubleClick, lbl512.DoubleClick, lbl1200.DoubleClick, lbl2400.DoubleClick
        Try
            Me.txtFinishedSKU.Text = ""

            Me.txtFinishedSKU.Text = Microsoft.VisualBasic.Right(Trim(sender.Text), 10)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get SKU", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub txtWOMemo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWOMemo.KeyUp
        If e.KeyValue = 13 Then
            Me.cmbPO.Focus()
        End If
    End Sub

    '*********************************************************
    Private Sub cmbPO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbPO.KeyUp
        Me.cmbFreq.Focus()
    End Sub

    '*********************************************************
    Private Sub cmbPO_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPO.SelectionChangeCommitted
        If Me.cmbPO.SelectedValue > 0 Then
            Me.cmbFreq.Focus()
        End If
    End Sub

    '*********************************************************
    Private Sub cmbFreq_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbFreq.KeyUp
        Me.txtFinishedSKU.Focus()
    End Sub

    '*********************************************************
    Private Sub cmbFreq_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFreq.SelectionChangeCommitted
        If Me.cmbFreq.SelectedValue Then
            Me.txtFinishedSKU.Focus()
        End If
    End Sub

    '*********************************************************

    Private Sub chkManualWO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkManualWO.Click
        If chkManualWO.Checked Then
            Me.chkHasFile.Checked = False
        Else
            Me.chkHasFile.Checked = True
        End If
    End Sub

    Private Sub cmbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Dim iCustID As Integer = 0
        Try
            iCustID = CInt(Me.cmbCustomer.SelectedValue)
        Catch ex As Exception
            Exit Sub
        End Try

        If iCustID = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                OrElse iCustID = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                OrElse iCustID = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                OrElse iCustID = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                OrElse iCustID = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                OrElse iCustID = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
            Me.chkManualWO.Visible = True
            Me.chkManualWO.Checked = True
            Me.chkHasFile.Checked = False
            Me.lblChildWO.Visible = False
            Me.txtChildWO.Visible = False
            Me.chkSpecialProj.Visible = False
            Me.txtCOAMAcct.Text = Me.cmbLoc.SelectedText
        Else
            Me.chkManualWO.Checked = False
            Me.chkHasFile.Checked = True
            Me.txtCOAMAcct.Text = ""
        End If
        Me.txtParentWO.Focus()
    End Sub
End Class
