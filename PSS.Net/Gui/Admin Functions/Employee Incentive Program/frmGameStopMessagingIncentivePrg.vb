Option Explicit On 

Imports PSS.Core.Global

Public Class frmIncentivePrg
    Inherits System.Windows.Forms.Form

    Private _objGSMsg As PSS.Data.Buisness.IncentivePrg

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objGSMsg = New PSS.Data.Buisness.IncentivePrg()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Me.lstGroup.DataBindings.Clear()

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
    Friend WithEvents lstGroup As System.Windows.Forms.ListBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblEENo As System.Windows.Forms.Label
    Friend WithEvents txtEENo As System.Windows.Forms.TextBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents btnDD_CellsCal As System.Windows.Forms.Button
    Friend WithEvents gbDynamicData As System.Windows.Forms.GroupBox
    Friend WithEvents btnDD_ProdPayout As System.Windows.Forms.Button
    Friend WithEvents cboPayPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents btnProdPayout As System.Windows.Forms.Button
    Friend WithEvents btnEEStatement As System.Windows.Forms.Button
    Friend WithEvents btnCellsData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEENoOption As System.Windows.Forms.Label
    Friend WithEvents pnlEEStatement As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbStaticData As System.Windows.Forms.GroupBox
    Friend WithEvents btnDD_EEStatement As System.Windows.Forms.Button
    Friend WithEvents lstDD_Grp As System.Windows.Forms.ListBox
    Friend WithEvents txtDD_EENo As System.Windows.Forms.TextBox
    Friend WithEvents lblDD_EENo As System.Windows.Forms.Label
    Friend WithEvents pnlDD_PIP_EEStatment As System.Windows.Forms.Panel
    Friend WithEvents chkWeekly As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstCostCenter As System.Windows.Forms.ListBox
    Friend WithEvents cboCC As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstGroup = New System.Windows.Forms.ListBox()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.btnDD_CellsCal = New System.Windows.Forms.Button()
        Me.lblEENo = New System.Windows.Forms.Label()
        Me.txtEENo = New System.Windows.Forms.TextBox()
        Me.gbDynamicData = New System.Windows.Forms.GroupBox()
        Me.pnlDD_PIP_EEStatment = New System.Windows.Forms.Panel()
        Me.btnDD_ProdPayout = New System.Windows.Forms.Button()
        Me.btnDD_EEStatement = New System.Windows.Forms.Button()
        Me.txtDD_EENo = New System.Windows.Forms.TextBox()
        Me.lblDD_EENo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstDD_Grp = New System.Windows.Forms.ListBox()
        Me.cboPayPeriod = New System.Windows.Forms.ComboBox()
        Me.btnProdPayout = New System.Windows.Forms.Button()
        Me.btnEEStatement = New System.Windows.Forms.Button()
        Me.btnCellsData = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEENoOption = New System.Windows.Forms.Label()
        Me.pnlEEStatement = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbStaticData = New System.Windows.Forms.GroupBox()
        Me.chkWeekly = New System.Windows.Forms.CheckBox()
        Me.lstCostCenter = New System.Windows.Forms.ListBox()
        Me.cboCC = New System.Windows.Forms.ComboBox()
        Me.gbDynamicData.SuspendLayout()
        Me.pnlDD_PIP_EEStatment.SuspendLayout()
        Me.pnlEEStatement.SuspendLayout()
        Me.gbStaticData.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstGroup
        '
        Me.lstGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGroup.ItemHeight = 16
        Me.lstGroup.Location = New System.Drawing.Point(32, 80)
        Me.lstGroup.Name = "lstGroup"
        Me.lstGroup.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstGroup.Size = New System.Drawing.Size(248, 116)
        Me.lstGroup.TabIndex = 2
        '
        'lblGroup
        '
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.White
        Me.lblGroup.Location = New System.Drawing.Point(32, 64)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(80, 16)
        Me.lblGroup.TabIndex = 3
        Me.lblGroup.Text = "Group"
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDate
        '
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.ForeColor = System.Drawing.Color.Yellow
        Me.lblStartDate.Location = New System.Drawing.Point(24, 25)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(64, 16)
        Me.lblStartDate.TabIndex = 7
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(88, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(88, 56)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpEndDate.TabIndex = 2
        Me.dtpEndDate.Value = New Date(2007, 8, 8, 0, 0, 0, 0)
        '
        'lblEndDate
        '
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.ForeColor = System.Drawing.Color.Yellow
        Me.lblEndDate.Location = New System.Drawing.Point(24, 56)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEndDate.TabIndex = 11
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDD_CellsCal
        '
        Me.btnDD_CellsCal.BackColor = System.Drawing.Color.SteelBlue
        Me.btnDD_CellsCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDD_CellsCal.ForeColor = System.Drawing.Color.White
        Me.btnDD_CellsCal.Location = New System.Drawing.Point(24, 232)
        Me.btnDD_CellsCal.Name = "btnDD_CellsCal"
        Me.btnDD_CellsCal.Size = New System.Drawing.Size(216, 32)
        Me.btnDD_CellsCal.TabIndex = 3
        Me.btnDD_CellsCal.Text = "Get Cells Calculation Data"
        Me.btnDD_CellsCal.Visible = False
        '
        'lblEENo
        '
        Me.lblEENo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEENo.ForeColor = System.Drawing.Color.White
        Me.lblEENo.Location = New System.Drawing.Point(6, 69)
        Me.lblEENo.Name = "lblEENo"
        Me.lblEENo.Size = New System.Drawing.Size(34, 16)
        Me.lblEENo.TabIndex = 14
        Me.lblEENo.Text = "EE #"
        Me.lblEENo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEENo
        '
        Me.txtEENo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEENo.Location = New System.Drawing.Point(48, 64)
        Me.txtEENo.Name = "txtEENo"
        Me.txtEENo.Size = New System.Drawing.Size(72, 22)
        Me.txtEENo.TabIndex = 2
        Me.txtEENo.Text = ""
        '
        'gbDynamicData
        '
        Me.gbDynamicData.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDD_PIP_EEStatment, Me.Label2, Me.lstDD_Grp, Me.btnDD_CellsCal, Me.lblEndDate, Me.dtpStartDate, Me.lblStartDate, Me.dtpEndDate})
        Me.gbDynamicData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDynamicData.ForeColor = System.Drawing.Color.White
        Me.gbDynamicData.Location = New System.Drawing.Point(368, 0)
        Me.gbDynamicData.Name = "gbDynamicData"
        Me.gbDynamicData.Size = New System.Drawing.Size(264, 504)
        Me.gbDynamicData.TabIndex = 6
        Me.gbDynamicData.TabStop = False
        Me.gbDynamicData.Text = "LIVE PRODUCTION DATA"
        Me.gbDynamicData.Visible = False
        '
        'pnlDD_PIP_EEStatment
        '
        Me.pnlDD_PIP_EEStatment.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDD_ProdPayout, Me.btnDD_EEStatement, Me.txtDD_EENo, Me.lblDD_EENo})
        Me.pnlDD_PIP_EEStatment.Location = New System.Drawing.Point(16, 280)
        Me.pnlDD_PIP_EEStatment.Name = "pnlDD_PIP_EEStatment"
        Me.pnlDD_PIP_EEStatment.Size = New System.Drawing.Size(232, 128)
        Me.pnlDD_PIP_EEStatment.TabIndex = 17
        Me.pnlDD_PIP_EEStatment.Visible = False
        '
        'btnDD_ProdPayout
        '
        Me.btnDD_ProdPayout.BackColor = System.Drawing.Color.SteelBlue
        Me.btnDD_ProdPayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDD_ProdPayout.ForeColor = System.Drawing.Color.White
        Me.btnDD_ProdPayout.Location = New System.Drawing.Point(8, 0)
        Me.btnDD_ProdPayout.Name = "btnDD_ProdPayout"
        Me.btnDD_ProdPayout.Size = New System.Drawing.Size(216, 32)
        Me.btnDD_ProdPayout.TabIndex = 5
        Me.btnDD_ProdPayout.Text = "Productivity Payout Report (This report will import into Legiant)"
        '
        'btnDD_EEStatement
        '
        Me.btnDD_EEStatement.BackColor = System.Drawing.Color.SteelBlue
        Me.btnDD_EEStatement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDD_EEStatement.ForeColor = System.Drawing.Color.White
        Me.btnDD_EEStatement.Location = New System.Drawing.Point(8, 88)
        Me.btnDD_EEStatement.Name = "btnDD_EEStatement"
        Me.btnDD_EEStatement.Size = New System.Drawing.Size(216, 32)
        Me.btnDD_EEStatement.TabIndex = 4
        Me.btnDD_EEStatement.Text = "Get EE Productivity Pay Statement"
        '
        'txtDD_EENo
        '
        Me.txtDD_EENo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDD_EENo.Location = New System.Drawing.Point(40, 56)
        Me.txtDD_EENo.Name = "txtDD_EENo"
        Me.txtDD_EENo.Size = New System.Drawing.Size(80, 22)
        Me.txtDD_EENo.TabIndex = 15
        Me.txtDD_EENo.Text = ""
        '
        'lblDD_EENo
        '
        Me.lblDD_EENo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDD_EENo.ForeColor = System.Drawing.Color.White
        Me.lblDD_EENo.Location = New System.Drawing.Point(8, 56)
        Me.lblDD_EENo.Name = "lblDD_EENo"
        Me.lblDD_EENo.Size = New System.Drawing.Size(32, 16)
        Me.lblDD_EENo.TabIndex = 16
        Me.lblDD_EENo.Text = "EE #"
        Me.lblDD_EENo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(24, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Group"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstDD_Grp
        '
        Me.lstDD_Grp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDD_Grp.ItemHeight = 16
        Me.lstDD_Grp.Location = New System.Drawing.Point(24, 96)
        Me.lstDD_Grp.Name = "lstDD_Grp"
        Me.lstDD_Grp.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstDD_Grp.Size = New System.Drawing.Size(215, 116)
        Me.lstDD_Grp.TabIndex = 12
        '
        'cboPayPeriod
        '
        Me.cboPayPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPayPeriod.Location = New System.Drawing.Point(32, 40)
        Me.cboPayPeriod.Name = "cboPayPeriod"
        Me.cboPayPeriod.Size = New System.Drawing.Size(248, 24)
        Me.cboPayPeriod.TabIndex = 1
        '
        'btnProdPayout
        '
        Me.btnProdPayout.BackColor = System.Drawing.Color.Green
        Me.btnProdPayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProdPayout.ForeColor = System.Drawing.Color.White
        Me.btnProdPayout.Location = New System.Drawing.Point(32, 264)
        Me.btnProdPayout.Name = "btnProdPayout"
        Me.btnProdPayout.Size = New System.Drawing.Size(248, 32)
        Me.btnProdPayout.TabIndex = 5
        Me.btnProdPayout.Text = "Productivity Payout Report (This report will import into Legiant system)"
        Me.btnProdPayout.Visible = False
        '
        'btnEEStatement
        '
        Me.btnEEStatement.BackColor = System.Drawing.Color.Green
        Me.btnEEStatement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEEStatement.ForeColor = System.Drawing.Color.White
        Me.btnEEStatement.Location = New System.Drawing.Point(8, 96)
        Me.btnEEStatement.Name = "btnEEStatement"
        Me.btnEEStatement.Size = New System.Drawing.Size(232, 32)
        Me.btnEEStatement.TabIndex = 2
        Me.btnEEStatement.Text = "Get EE Productivity Pay Statement"
        '
        'btnCellsData
        '
        Me.btnCellsData.BackColor = System.Drawing.Color.Green
        Me.btnCellsData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCellsData.ForeColor = System.Drawing.Color.White
        Me.btnCellsData.Location = New System.Drawing.Point(32, 204)
        Me.btnCellsData.Name = "btnCellsData"
        Me.btnCellsData.Size = New System.Drawing.Size(248, 32)
        Me.btnCellsData.TabIndex = 4
        Me.btnCellsData.Text = "Get Cells Calculation Data"
        Me.btnCellsData.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Date Period"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEENoOption
        '
        Me.lblEENoOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEENoOption.ForeColor = System.Drawing.Color.Lime
        Me.lblEENoOption.Location = New System.Drawing.Point(128, 64)
        Me.lblEENoOption.Name = "lblEENoOption"
        Me.lblEENoOption.Size = New System.Drawing.Size(112, 24)
        Me.lblEENoOption.TabIndex = 22
        Me.lblEENoOption.Text = "(Optional) Use by EE Statement only"
        Me.lblEENoOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlEEStatement
        '
        Me.pnlEEStatement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEEStatement.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCC, Me.Label3, Me.txtEENo, Me.lblEENo, Me.btnEEStatement, Me.lblEENoOption})
        Me.pnlEEStatement.Location = New System.Drawing.Point(32, 328)
        Me.pnlEEStatement.Name = "pnlEEStatement"
        Me.pnlEEStatement.Size = New System.Drawing.Size(248, 144)
        Me.pnlEEStatement.TabIndex = 3
        Me.pnlEEStatement.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Cost Center (Optional):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbStaticData
        '
        Me.gbStaticData.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkWeekly, Me.lstGroup, Me.pnlEEStatement, Me.btnCellsData, Me.cboPayPeriod, Me.btnProdPayout, Me.Label1, Me.lblGroup})
        Me.gbStaticData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStaticData.ForeColor = System.Drawing.Color.White
        Me.gbStaticData.Location = New System.Drawing.Point(16, 0)
        Me.gbStaticData.Name = "gbStaticData"
        Me.gbStaticData.Size = New System.Drawing.Size(304, 504)
        Me.gbStaticData.TabIndex = 22
        Me.gbStaticData.TabStop = False
        Me.gbStaticData.Text = "STATIC DATA"
        '
        'chkWeekly
        '
        Me.chkWeekly.ForeColor = System.Drawing.Color.Lime
        Me.chkWeekly.Location = New System.Drawing.Point(192, 16)
        Me.chkWeekly.Name = "chkWeekly"
        Me.chkWeekly.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkWeekly.Size = New System.Drawing.Size(88, 24)
        Me.chkWeekly.TabIndex = 22
        Me.chkWeekly.Text = "Weekly"
        '
        'lstCostCenter
        '
        Me.lstCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCostCenter.ItemHeight = 16
        Me.lstCostCenter.Location = New System.Drawing.Point(16, 24)
        Me.lstCostCenter.Name = "lstCostCenter"
        Me.lstCostCenter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstCostCenter.Size = New System.Drawing.Size(216, 116)
        Me.lstCostCenter.TabIndex = 25
        '
        'cboCC
        '
        Me.cboCC.DropDownWidth = 250
        Me.cboCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCC.ItemHeight = 16
        Me.cboCC.Location = New System.Drawing.Point(8, 24)
        Me.cboCC.MaxDropDownItems = 12
        Me.cboCC.Name = "cboCC"
        Me.cboCC.Size = New System.Drawing.Size(232, 24)
        Me.cboCC.TabIndex = 1
        '
        'frmIncentivePrg
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(664, 533)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbStaticData, Me.gbDynamicData})
        Me.Name = "frmIncentivePrg"
        Me.Text = "Incentive Data"
        Me.gbDynamicData.ResumeLayout(False)
        Me.pnlDD_PIP_EEStatment.ResumeLayout(False)
        Me.pnlEEStatement.ResumeLayout(False)
        Me.gbStaticData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmGameStopMessagingIncentivePrg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me.dtpStartDate
                .CustomFormat = "yyyy-MM-dd"
                .Format = DateTimePickerFormat.Custom
                .Value = Now
            End With

            With Me.dtpEndDate
                .CustomFormat = "yyyy-MM-dd"
                .Format = DateTimePickerFormat.Custom
                .Value = Now
            End With

            If ApplicationUser.GetPermission("EmpIncen_Accounting") > 0 Then
                Me.btnProdPayout.Visible = True
                Me.chkWeekly.Enabled = False
            End If
            If ApplicationUser.GetPermission("EmpIncen_Prod") > 0 Then
                Me.btnCellsData.Visible = True
                Me.pnlEEStatement.Visible = True
                Me.gbDynamicData.Visible = True
                Me.btnDD_CellsCal.Visible = True
            End If
            If ApplicationUser.GetPermission("563Bill_PreBillDevsInWIP") > 0 Then
                Me.gbDynamicData.Visible = True
                Me.btnDD_CellsCal.Visible = True
                Me.pnlDD_PIP_EEStatment.Visible = True
                Me.chkWeekly.Enabled = True
            End If

            LoadDatePeriod(1)
            Me.chkWeekly.Checked = True
            LoadGroups()
            Me.lstGroup.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "FormLoadEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadDatePeriod(ByVal iWeekly As Integer)
        Dim dt As DataTable

        Try
            If iWeekly = 1 Then
                dt = Me._objGSMsg.GetPayRollPeriodWeekly()
            ElseIf iWeekly = 2 Then
                dt = Me._objGSMsg.GetPayRollPeriodBiWeekly()
            End If

            With Me.cboPayPeriod
                .DisplayMember = dt.Columns("DatePeriod").ColumnName
                .ValueMember = dt.Columns("ID").ColumnName
                .DataSource = dt.DefaultView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Me._objGSMsg.DisplayMessage(ex.Message)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadGroups()
        Dim dt As DataTable

        Try
            dt = Me._objGSMsg.GetGroupData

            With Me.lstGroup
                .DisplayMember = dt.Columns(0).ColumnName
                .ValueMember = dt.Columns(1).ColumnName
                .DataSource = dt.DefaultView
                .SelectedIndex = -1
            End With

            With Me.lstDD_Grp
                .DisplayMember = dt.Columns(0).ColumnName
                .ValueMember = dt.Columns(1).ColumnName
                .DataSource = dt.DefaultView
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            Me._objGSMsg.DisplayMessage(ex.Message)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '******************************************************************
    Private Sub txtEENo_txtDD_EENo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEENo.KeyPress, txtDD_EENo.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    '******************************************************************
    Public Sub btnDD_CellsCal_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDD_CellsCal.Click
        Dim iGroupID As Integer = 0
        Dim i As Integer = 0

        Try
            Me.Enabled = False

            'Validate Start Date and End Date
            If Me.dtpEndDate.Value < Me.dtpStartDate.Value Then
                MessageBox.Show("The end date cannot precede the start date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.lstDD_Grp.SelectedItems.Count > 1 Then
                MessageBox.Show("Please select only one group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf Me.lstDD_Grp.SelectedIndex = -1 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                iGroupID = Me.lstDD_Grp.SelectedValue
            End If

            If iGroupID = 0 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.txtDD_EENo.Text.Trim.Length > 0 Then
                If MessageBox.Show("Employee # does not apply for this function. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            'Cell UPH Calculation
            If iGroupID > 0 Then
                Cursor.Current = Cursors.WaitCursor
                i = Me._objGSMsg.CreateDynamicCellsCalRpt(iGroupID, Me.lstDD_Grp.Items.Item(Me.lstDD_Grp.SelectedIndex)(0), Format(Me.dtpStartDate.Value, "yyyy-MM-dd"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd"), Me.lstGroup.SelectedItem("Special_Project"))
            End If

            'Me.lstDD_Grp.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnDD_CellsCal_Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDD_EEStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDD_EEStatement.Click
        Dim iGroupID As Integer = 0
        Dim i As Integer = 0
        Dim iEENo As Integer = 0

        Try
            Me.Enabled = False

            'Validate Start Date and End Date
            If Me.dtpEndDate.Value < Me.dtpStartDate.Value Then
                MessageBox.Show("The end date cannot precede the start date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.lstDD_Grp.SelectedItems.Count > 1 Then
                MessageBox.Show("Please select only one group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf Me.lstDD_Grp.SelectedIndex = -1 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                iGroupID = Me.lstDD_Grp.SelectedValue
            End If

            If iGroupID = 0 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.txtDD_EENo.Text.Trim <> "" Then
                iEENo = CInt(Me.txtDD_EENo.Text.Trim)
            End If

            'EE Statement
            If iGroupID > 0 Then
                Cursor.Current = Cursors.WaitCursor
                i = Me._objGSMsg.CreateDynamicEEStatement(Format(Me.dtpStartDate.Value, "yyyy-MM-dd"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd"), iGroupID, iEENo)
            End If

            Me.txtDD_EENo.Text = ""
            'Me.lstDD_Grp.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnDD_EEStatement_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDD_ProdPayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDD_ProdPayout.Click
        Dim i As Integer = 0
        Dim strGroupIDs As String = ""

        Try
            Me.Enabled = False

            'Validate Start Date and End Date
            If Me.dtpEndDate.Value < Me.dtpStartDate.Value Then
                MessageBox.Show("The end date cannot precede the start date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If Me.txtDD_EENo.Text.Trim.Length > 0 Then
                If MessageBox.Show("Employee # does not apply for this function. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            If Me.lstDD_Grp.SelectedIndex = -1 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            For i = 0 To Me.lstDD_Grp.SelectedItems.Count - 1
                If strGroupIDs.Trim.Length > 0 Then strGroupIDs &= ", "

                strGroupIDs = Me.lstDD_Grp.SelectedItems.Item(i)("ID")
            Next i

            If strGroupIDs.Trim.Length = 0 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            'Productivity Payout Report
            If strGroupIDs.Trim.Length > 0 Then
                Cursor.Current = Cursors.WaitCursor
                i = Me._objGSMsg.CreateDynamicProdIncPayRpt(Format(Me.dtpStartDate.Value, "yyyy-MM-dd"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd"), strGroupIDs)
            End If

            'Me.lstDD_Grp.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnDD_ProdPayout_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCellsData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCellsData.Click
        Dim iGroupID As Integer
        Dim i As Integer = 0

        Try
            If Me.cboPayPeriod.SelectedValue = 0 Then
                MessageBox.Show("Please select Date Period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.lstGroup.SelectedIndex = -1 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.lstGroup.SelectedItems.Count > 1 Then
                MessageBox.Show("Please select only one group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtEENo.Text.Trim.Length > 0 Then
                If MessageBox.Show("Employee # does not apply for this function. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                    Exit Sub
                End If
            Else
                iGroupID = Me.lstGroup.SelectedValue

                If iGroupID = 0 Then
                    MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objGSMsg.CreateStaticCellCalsRpt(iGroupID, Me.lstGroup.Items.Item(Me.lstGroup.SelectedIndex)(0), _
                                                        Format(Me.cboPayPeriod.Items.Item(Me.cboPayPeriod.SelectedIndex)("StartDate"), "yyyy-MM-dd"), _
                                                        Format(Me.cboPayPeriod.Items.Item(Me.cboPayPeriod.SelectedIndex)("EndDate"), "yyyy-MM-dd"))

                'Me.lstGroup.SelectedIndex = -1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnCellsData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub btnEEStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEEStatement.Click
        Dim strGroupIDs As String = ""
        Dim i As Integer = 0
        Dim iEENo As Integer = 0
        Dim strCCIDs As String = ""

        Try
            If Me.cboPayPeriod.SelectedValue = 0 Then
                MessageBox.Show("Please select Date Period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.lstGroup.SelectedIndex = -1 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                For i = 0 To Me.lstGroup.SelectedItems.Count - 1
                    If strGroupIDs.Trim.Length > 0 Then strGroupIDs &= ", "
                    strGroupIDs &= Me.lstGroup.SelectedItems.Item(i)("ID")
                Next i

                If strGroupIDs.Trim.Length = 0 Then
                    MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                If Me.txtEENo.Text.Trim.Length > 0 Then
                    iEENo = CInt(Me.txtEENo.Text.Trim)
                End If

                If Me.cboCC.SelectedValue > 0 Then strCCIDs = Me.cboCC.SelectedValue

                i = Me._objGSMsg.CreateStaticEEStatement(Format(Me.cboPayPeriod.Items.Item(Me.cboPayPeriod.SelectedIndex)("StartDate"), "yyyy-MM-dd"), _
                                                         Format(Me.cboPayPeriod.Items.Item(Me.cboPayPeriod.SelectedIndex)("EndDate"), "yyyy-MM-dd"), _
                                                         strGroupIDs, iEENo, strCCIDs)

                Me.txtEENo.Text = ""
                'Me.lstGroup.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnEEStatement_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnProdPayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProdPayout.Click
        Dim strGroupIDs As String = ""
        Dim i As Integer = 0

        Try
            If Me.cboPayPeriod.SelectedValue = 0 Then
                MessageBox.Show("Please select Date Period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.lstGroup.SelectedIndex = -1 Then
                MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.txtEENo.Text.Trim.Length > 0 Then
                If MessageBox.Show("Employee # does not apply for this function. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                    Exit Sub
                End If
            Else
                For i = 0 To Me.lstGroup.SelectedItems.Count - 1
                    If strGroupIDs.Trim.Length > 0 Then strGroupIDs &= ", "
                    strGroupIDs &= Me.lstGroup.SelectedItems.Item(i)("ID")
                Next i

                If strGroupIDs.Trim.Length = 0 Then
                    MessageBox.Show("Please select group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objGSMsg.CreateStaticProdIncPayRpt(Format(Me.cboPayPeriod.Items.Item(Me.cboPayPeriod.SelectedIndex)("StartDate"), "yyyy-MM-dd"), _
                                         Format(Me.cboPayPeriod.Items.Item(Me.cboPayPeriod.SelectedIndex)("EndDate"), "yyyy-MM-dd"), _
                                         strGroupIDs)
                'Me.lstGroup.SelectedIndex = -1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnProdPayout_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '******************************************************************
    Private Sub chkWeekly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWeekly.CheckedChanged
        Try
            Me.cboPayPeriod.DataSource = Nothing
            Me.cboPayPeriod.Items.Clear()

            If sender.checked = True Then Me.LoadDatePeriod(1) Else Me.LoadDatePeriod(2)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "chkWeekly_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub lstGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstGroup.SelectedIndexChanged
        Try
            If Me.lstGroup.SelectedIndex > -1 Then Me.LoadCostCenters(Me.lstGroup.Items.Item(Me.lstGroup.SelectedIndex)("ID"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "lstGroup_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadCostCenters(ByVal iGroupID As Integer)
        Dim dt As DataTable
        Try
            dt = Me._objGSMsg.GetCosCenters(iGroupID)

            With Me.cboCC
                .DisplayMember = dt.Columns("CC_Desc").ColumnName
                .ValueMember = dt.Columns("CC_ID").ColumnName
                .DataSource = dt.DefaultView
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************

End Class
