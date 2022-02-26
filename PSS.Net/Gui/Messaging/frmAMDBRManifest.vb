Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Data.Buisness

Public Class frmAMDBRManifest
    Inherits System.Windows.Forms.Form

    Private Const _iNER_BillcodeID As Integer = 89
    Private _objDBRManifest As Data.Buisness.DBRManifest
    Private _dtDBRUnits As DataTable
    Private _dtNERUnits As DataTable
    Private _iMenuCustID As Integer
    Private _iMenuLocID As Integer
    Private _strWork_Dt As String = Core.Global.ApplicationUser.Workdate
    Private _strTabPageTitle As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String, ByVal iCustID As Integer, ByVal iLocID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objDBRManifest = New Data.Buisness.DBRManifest()
        _strTabPageTitle = strTabPageTitle
        _iMenuCustID = iCustID
        _iMenuLocID = iLocID
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
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lstSN As System.Windows.Forms.ListBox
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents rtfSNCount As System.Windows.Forms.RichTextBox
    Friend WithEvents btnDeleteOne As System.Windows.Forms.Button
    Friend WithEvents lstNoneDBR As System.Windows.Forms.ListBox
    Friend WithEvents lblAssignedDBRPallet As System.Windows.Forms.Label
    Friend WithEvents lstAssignedDBRPallet As System.Windows.Forms.ListBox
    Friend WithEvents lblNoneDBR As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpDBR As System.Windows.Forms.TabPage
    Friend WithEvents cmbSubContractor As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRepDelAll As System.Windows.Forms.Button
    Friend WithEvents btnRepDelOne As System.Windows.Forms.Button
    Friend WithEvents btnRepPrintManifest As System.Windows.Forms.Button
    Friend WithEvents txtRepSN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRepCounter As System.Windows.Forms.Label
    Friend WithEvents tpOtherManifest As System.Windows.Forms.TabPage
    Friend WithEvents lstRepSN As System.Windows.Forms.ListBox
    Friend WithEvents btnRepLoadSNFrExcel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRepLoadSNNote As System.Windows.Forms.TextBox
    Friend WithEvents btnReprintManifest As System.Windows.Forms.Button
    Friend WithEvents btnRepRePrintLotLabel As System.Windows.Forms.Button
    Friend WithEvents tpNER As System.Windows.Forms.TabPage
    Friend WithEvents btnNERDelAll As System.Windows.Forms.Button
    Friend WithEvents rtxtNER_SN_cnt As System.Windows.Forms.RichTextBox
    Friend WithEvents txtNER_SN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstNER_SNs As System.Windows.Forms.ListBox
    Friend WithEvents btnNERDelOne As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnNER_ReprintLotLabel As System.Windows.Forms.Button
    Friend WithEvents btnNERCreatLot As System.Windows.Forms.Button
    Friend WithEvents btnCreateDBRLot As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnRecreateDBRManifest As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents pnlNER_Reason As System.Windows.Forms.Panel
    Friend WithEvents cboNER_Reasons As C1.Win.C1List.C1Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAMDBRManifest))
        Me.lblSN = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lstSN = New System.Windows.Forms.ListBox()
        Me.rtfSNCount = New System.Windows.Forms.RichTextBox()
        Me.btnDeleteOne = New System.Windows.Forms.Button()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnCreateDBRLot = New System.Windows.Forms.Button()
        Me.lstNoneDBR = New System.Windows.Forms.ListBox()
        Me.lblNoneDBR = New System.Windows.Forms.Label()
        Me.lblAssignedDBRPallet = New System.Windows.Forms.Label()
        Me.lstAssignedDBRPallet = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpDBR = New System.Windows.Forms.TabPage()
        Me.btnRecreateDBRManifest = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnReprintManifest = New System.Windows.Forms.Button()
        Me.tpOtherManifest = New System.Windows.Forms.TabPage()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnRepRePrintLotLabel = New System.Windows.Forms.Button()
        Me.txtRepLoadSNNote = New System.Windows.Forms.TextBox()
        Me.btnRepLoadSNFrExcel = New System.Windows.Forms.Button()
        Me.lblRepCounter = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRepSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnRepDelAll = New System.Windows.Forms.Button()
        Me.btnRepDelOne = New System.Windows.Forms.Button()
        Me.btnRepPrintManifest = New System.Windows.Forms.Button()
        Me.lstRepSN = New System.Windows.Forms.ListBox()
        Me.cmbSubContractor = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpNER = New System.Windows.Forms.TabPage()
        Me.pnlNER_Reason = New System.Windows.Forms.Panel()
        Me.cboNER_Reasons = New C1.Win.C1List.C1Combo()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnNER_ReprintLotLabel = New System.Windows.Forms.Button()
        Me.btnNERDelAll = New System.Windows.Forms.Button()
        Me.btnNERCreatLot = New System.Windows.Forms.Button()
        Me.rtxtNER_SN_cnt = New System.Windows.Forms.RichTextBox()
        Me.txtNER_SN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstNER_SNs = New System.Windows.Forms.ListBox()
        Me.btnNERDelOne = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.tpDBR.SuspendLayout()
        Me.tpOtherManifest.SuspendLayout()
        Me.tpNER.SuspendLayout()
        Me.pnlNER_Reason.SuspendLayout()
        CType(Me.cboNER_Reasons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSN
        '
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Black
        Me.lblSN.Location = New System.Drawing.Point(16, 40)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(88, 16)
        Me.lblSN.TabIndex = 0
        Me.lblSN.Text = "Serial Number:"
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.White
        Me.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(16, 56)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(176, 20)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'lstSN
        '
        Me.lstSN.BackColor = System.Drawing.Color.White
        Me.lstSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSN.Location = New System.Drawing.Point(16, 80)
        Me.lstSN.Name = "lstSN"
        Me.lstSN.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstSN.Size = New System.Drawing.Size(176, 368)
        Me.lstSN.TabIndex = 2
        '
        'rtfSNCount
        '
        Me.rtfSNCount.BackColor = System.Drawing.Color.Black
        Me.rtfSNCount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfSNCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfSNCount.ForeColor = System.Drawing.Color.Lime
        Me.rtfSNCount.Location = New System.Drawing.Point(208, 56)
        Me.rtfSNCount.Name = "rtfSNCount"
        Me.rtfSNCount.ReadOnly = True
        Me.rtfSNCount.Size = New System.Drawing.Size(88, 56)
        Me.rtfSNCount.TabIndex = 3
        Me.rtfSNCount.Text = "SN Count: 0"
        '
        'btnDeleteOne
        '
        Me.btnDeleteOne.BackColor = System.Drawing.Color.Red
        Me.btnDeleteOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteOne.ForeColor = System.Drawing.Color.White
        Me.btnDeleteOne.Location = New System.Drawing.Point(208, 192)
        Me.btnDeleteOne.Name = "btnDeleteOne"
        Me.btnDeleteOne.Size = New System.Drawing.Size(104, 24)
        Me.btnDeleteOne.TabIndex = 4
        Me.btnDeleteOne.Text = "Delete One"
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackColor = System.Drawing.Color.Red
        Me.btnDeleteAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAll.ForeColor = System.Drawing.Color.White
        Me.btnDeleteAll.Location = New System.Drawing.Point(208, 232)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(104, 24)
        Me.btnDeleteAll.TabIndex = 5
        Me.btnDeleteAll.Text = "Delete All"
        '
        'btnCreateDBRLot
        '
        Me.btnCreateDBRLot.BackColor = System.Drawing.Color.Orange
        Me.btnCreateDBRLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateDBRLot.ForeColor = System.Drawing.Color.Black
        Me.btnCreateDBRLot.Location = New System.Drawing.Point(208, 416)
        Me.btnCreateDBRLot.Name = "btnCreateDBRLot"
        Me.btnCreateDBRLot.Size = New System.Drawing.Size(152, 32)
        Me.btnCreateDBRLot.TabIndex = 3
        Me.btnCreateDBRLot.Text = "Create DBR Ship Lot"
        '
        'lstNoneDBR
        '
        Me.lstNoneDBR.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lstNoneDBR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstNoneDBR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNoneDBR.ForeColor = System.Drawing.Color.Black
        Me.lstNoneDBR.Location = New System.Drawing.Point(376, 60)
        Me.lstNoneDBR.Name = "lstNoneDBR"
        Me.lstNoneDBR.Size = New System.Drawing.Size(136, 377)
        Me.lstNoneDBR.TabIndex = 7
        Me.lstNoneDBR.Visible = False
        '
        'lblNoneDBR
        '
        Me.lblNoneDBR.BackColor = System.Drawing.Color.Transparent
        Me.lblNoneDBR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoneDBR.ForeColor = System.Drawing.Color.Blue
        Me.lblNoneDBR.Location = New System.Drawing.Point(376, 36)
        Me.lblNoneDBR.Name = "lblNoneDBR"
        Me.lblNoneDBR.Size = New System.Drawing.Size(136, 16)
        Me.lblNoneDBR.TabIndex = 8
        Me.lblNoneDBR.Text = "Don't Meet DBR Criteria:"
        Me.lblNoneDBR.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblNoneDBR.Visible = False
        '
        'lblAssignedDBRPallet
        '
        Me.lblAssignedDBRPallet.BackColor = System.Drawing.Color.Transparent
        Me.lblAssignedDBRPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedDBRPallet.ForeColor = System.Drawing.Color.Blue
        Me.lblAssignedDBRPallet.Location = New System.Drawing.Point(544, 36)
        Me.lblAssignedDBRPallet.Name = "lblAssignedDBRPallet"
        Me.lblAssignedDBRPallet.Size = New System.Drawing.Size(136, 16)
        Me.lblAssignedDBRPallet.TabIndex = 10
        Me.lblAssignedDBRPallet.Text = "Have DBR Lot:"
        Me.lblAssignedDBRPallet.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblAssignedDBRPallet.Visible = False
        '
        'lstAssignedDBRPallet
        '
        Me.lstAssignedDBRPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lstAssignedDBRPallet.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAssignedDBRPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAssignedDBRPallet.ForeColor = System.Drawing.Color.Black
        Me.lstAssignedDBRPallet.Location = New System.Drawing.Point(544, 60)
        Me.lstAssignedDBRPallet.Name = "lstAssignedDBRPallet"
        Me.lstAssignedDBRPallet.Size = New System.Drawing.Size(136, 377)
        Me.lstAssignedDBRPallet.TabIndex = 9
        Me.lstAssignedDBRPallet.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpDBR, Me.tpOtherManifest, Me.tpNER})
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(728, 496)
        Me.TabControl1.TabIndex = 11
        '
        'tpDBR
        '
        Me.tpDBR.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpDBR.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecreateDBRManifest, Me.Label6, Me.btnReprintManifest, Me.btnDeleteAll, Me.btnCreateDBRLot, Me.rtfSNCount, Me.txtSN, Me.lstNoneDBR, Me.lblAssignedDBRPallet, Me.lblSN, Me.lstSN, Me.lstAssignedDBRPallet, Me.btnDeleteOne, Me.lblNoneDBR})
        Me.tpDBR.Location = New System.Drawing.Point(4, 22)
        Me.tpDBR.Name = "tpDBR"
        Me.tpDBR.Size = New System.Drawing.Size(720, 470)
        Me.tpDBR.TabIndex = 0
        Me.tpDBR.Text = "Build DBR Ship Lot"
        '
        'btnRecreateDBRManifest
        '
        Me.btnRecreateDBRManifest.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRecreateDBRManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecreateDBRManifest.ForeColor = System.Drawing.Color.White
        Me.btnRecreateDBRManifest.Location = New System.Drawing.Point(208, 288)
        Me.btnRecreateDBRManifest.Name = "btnRecreateDBRManifest"
        Me.btnRecreateDBRManifest.Size = New System.Drawing.Size(152, 40)
        Me.btnRecreateDBRManifest.TabIndex = 18
        Me.btnRecreateDBRManifest.Text = "Re-Create DBR or NER Manifest"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 24)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "DBR"
        '
        'btnReprintManifest
        '
        Me.btnReprintManifest.BackColor = System.Drawing.Color.SteelBlue
        Me.btnReprintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintManifest.ForeColor = System.Drawing.Color.White
        Me.btnReprintManifest.Location = New System.Drawing.Point(208, 360)
        Me.btnReprintManifest.Name = "btnReprintManifest"
        Me.btnReprintManifest.Size = New System.Drawing.Size(152, 32)
        Me.btnReprintManifest.TabIndex = 11
        Me.btnReprintManifest.Text = "Reprint Lot Label"
        '
        'tpOtherManifest
        '
        Me.tpOtherManifest.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpOtherManifest.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.btnRepRePrintLotLabel, Me.txtRepLoadSNNote, Me.btnRepLoadSNFrExcel, Me.lblRepCounter, Me.Label3, Me.txtRepSN, Me.Label2, Me.btnRepDelAll, Me.btnRepDelOne, Me.btnRepPrintManifest, Me.lstRepSN, Me.cmbSubContractor, Me.Label1})
        Me.tpOtherManifest.Location = New System.Drawing.Point(4, 22)
        Me.tpOtherManifest.Name = "tpOtherManifest"
        Me.tpOtherManifest.Size = New System.Drawing.Size(720, 470)
        Me.tpOtherManifest.TabIndex = 1
        Me.tpOtherManifest.Text = "Build Ship Lot"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(400, 32)
        Me.lblTitle.TabIndex = 18
        Me.lblTitle.Text = "Label"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRepRePrintLotLabel
        '
        Me.btnRepRePrintLotLabel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRepRePrintLotLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepRePrintLotLabel.ForeColor = System.Drawing.Color.White
        Me.btnRepRePrintLotLabel.Location = New System.Drawing.Point(216, 352)
        Me.btnRepRePrintLotLabel.Name = "btnRepRePrintLotLabel"
        Me.btnRepRePrintLotLabel.Size = New System.Drawing.Size(160, 32)
        Me.btnRepRePrintLotLabel.TabIndex = 17
        Me.btnRepRePrintLotLabel.Text = "Reprint Lot Label"
        '
        'txtRepLoadSNNote
        '
        Me.txtRepLoadSNNote.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtRepLoadSNNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRepLoadSNNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepLoadSNNote.ForeColor = System.Drawing.Color.Black
        Me.txtRepLoadSNNote.Location = New System.Drawing.Point(408, 56)
        Me.txtRepLoadSNNote.Multiline = True
        Me.txtRepLoadSNNote.Name = "txtRepLoadSNNote"
        Me.txtRepLoadSNNote.ReadOnly = True
        Me.txtRepLoadSNNote.Size = New System.Drawing.Size(296, 96)
        Me.txtRepLoadSNNote.TabIndex = 16
        Me.txtRepLoadSNNote.Text = ""
        '
        'btnRepLoadSNFrExcel
        '
        Me.btnRepLoadSNFrExcel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRepLoadSNFrExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepLoadSNFrExcel.ForeColor = System.Drawing.Color.White
        Me.btnRepLoadSNFrExcel.Location = New System.Drawing.Point(216, 48)
        Me.btnRepLoadSNFrExcel.Name = "btnRepLoadSNFrExcel"
        Me.btnRepLoadSNFrExcel.Size = New System.Drawing.Size(184, 24)
        Me.btnRepLoadSNFrExcel.TabIndex = 7
        Me.btnRepLoadSNFrExcel.Text = "Load SN From Excel"
        '
        'lblRepCounter
        '
        Me.lblRepCounter.BackColor = System.Drawing.Color.Black
        Me.lblRepCounter.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepCounter.ForeColor = System.Drawing.Color.Lime
        Me.lblRepCounter.Location = New System.Drawing.Point(216, 104)
        Me.lblRepCounter.Name = "lblRepCounter"
        Me.lblRepCounter.Size = New System.Drawing.Size(88, 40)
        Me.lblRepCounter.TabIndex = 14
        Me.lblRepCounter.Text = "0"
        Me.lblRepCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(216, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "SN Count:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRepSN
        '
        Me.txtRepSN.BackColor = System.Drawing.Color.White
        Me.txtRepSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRepSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepSN.Location = New System.Drawing.Point(16, 88)
        Me.txtRepSN.Name = "txtRepSN"
        Me.txtRepSN.Size = New System.Drawing.Size(176, 20)
        Me.txtRepSN.TabIndex = 2
        Me.txtRepSN.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Serial Number:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnRepDelAll
        '
        Me.btnRepDelAll.BackColor = System.Drawing.Color.Red
        Me.btnRepDelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepDelAll.ForeColor = System.Drawing.Color.White
        Me.btnRepDelAll.Location = New System.Drawing.Point(216, 240)
        Me.btnRepDelAll.Name = "btnRepDelAll"
        Me.btnRepDelAll.Size = New System.Drawing.Size(104, 24)
        Me.btnRepDelAll.TabIndex = 6
        Me.btnRepDelAll.Text = "Delete All"
        '
        'btnRepDelOne
        '
        Me.btnRepDelOne.BackColor = System.Drawing.Color.Red
        Me.btnRepDelOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepDelOne.ForeColor = System.Drawing.Color.White
        Me.btnRepDelOne.Location = New System.Drawing.Point(216, 200)
        Me.btnRepDelOne.Name = "btnRepDelOne"
        Me.btnRepDelOne.Size = New System.Drawing.Size(104, 24)
        Me.btnRepDelOne.TabIndex = 5
        Me.btnRepDelOne.Text = "Delete One"
        '
        'btnRepPrintManifest
        '
        Me.btnRepPrintManifest.BackColor = System.Drawing.Color.Green
        Me.btnRepPrintManifest.Enabled = False
        Me.btnRepPrintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRepPrintManifest.ForeColor = System.Drawing.Color.White
        Me.btnRepPrintManifest.Location = New System.Drawing.Point(216, 400)
        Me.btnRepPrintManifest.Name = "btnRepPrintManifest"
        Me.btnRepPrintManifest.Size = New System.Drawing.Size(160, 32)
        Me.btnRepPrintManifest.TabIndex = 4
        Me.btnRepPrintManifest.Text = "Create/Close Lot"
        '
        'lstRepSN
        '
        Me.lstRepSN.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstRepSN.BackColor = System.Drawing.Color.White
        Me.lstRepSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRepSN.Location = New System.Drawing.Point(16, 120)
        Me.lstRepSN.Name = "lstRepSN"
        Me.lstRepSN.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstRepSN.Size = New System.Drawing.Size(176, 342)
        Me.lstRepSN.TabIndex = 3
        '
        'cmbSubContractor
        '
        Me.cmbSubContractor.AutoComplete = True
        Me.cmbSubContractor.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSubContractor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubContractor.ForeColor = System.Drawing.Color.Black
        Me.cmbSubContractor.Location = New System.Drawing.Point(16, 48)
        Me.cmbSubContractor.Name = "cmbSubContractor"
        Me.cmbSubContractor.Size = New System.Drawing.Size(176, 21)
        Me.cmbSubContractor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Send To Location:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpNER
        '
        Me.tpNER.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNER_Reason, Me.Label5, Me.btnNER_ReprintLotLabel, Me.btnNERDelAll, Me.btnNERCreatLot, Me.rtxtNER_SN_cnt, Me.txtNER_SN, Me.Label4, Me.lstNER_SNs, Me.btnNERDelOne})
        Me.tpNER.Location = New System.Drawing.Point(4, 22)
        Me.tpNER.Name = "tpNER"
        Me.tpNER.Size = New System.Drawing.Size(720, 470)
        Me.tpNER.TabIndex = 2
        Me.tpNER.Text = "Build NER Ship Lot"
        '
        'pnlNER_Reason
        '
        Me.pnlNER_Reason.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboNER_Reasons, Me.Label22})
        Me.pnlNER_Reason.Location = New System.Drawing.Point(8, 40)
        Me.pnlNER_Reason.Name = "pnlNER_Reason"
        Me.pnlNER_Reason.Size = New System.Drawing.Size(384, 40)
        Me.pnlNER_Reason.TabIndex = 0
        Me.pnlNER_Reason.Visible = False
        '
        'cboNER_Reasons
        '
        Me.cboNER_Reasons.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboNER_Reasons.AutoCompletion = True
        Me.cboNER_Reasons.AutoDropDown = True
        Me.cboNER_Reasons.AutoSelect = True
        Me.cboNER_Reasons.Caption = ""
        Me.cboNER_Reasons.CaptionHeight = 17
        Me.cboNER_Reasons.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboNER_Reasons.ColumnCaptionHeight = 17
        Me.cboNER_Reasons.ColumnFooterHeight = 17
        Me.cboNER_Reasons.ColumnHeaders = False
        Me.cboNER_Reasons.ContentHeight = 15
        Me.cboNER_Reasons.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboNER_Reasons.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboNER_Reasons.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNER_Reasons.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboNER_Reasons.EditorHeight = 15
        Me.cboNER_Reasons.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboNER_Reasons.ItemHeight = 15
        Me.cboNER_Reasons.Location = New System.Drawing.Point(64, 8)
        Me.cboNER_Reasons.MatchEntryTimeout = CType(2000, Long)
        Me.cboNER_Reasons.MaxDropDownItems = CType(10, Short)
        Me.cboNER_Reasons.MaxLength = 32767
        Me.cboNER_Reasons.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboNER_Reasons.Name = "cboNER_Reasons"
        Me.cboNER_Reasons.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboNER_Reasons.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboNER_Reasons.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboNER_Reasons.Size = New System.Drawing.Size(304, 21)
        Me.cboNER_Reasons.TabIndex = 0
        Me.cboNER_Reasons.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
        "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
        "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
        "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
        "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
        "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
        "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
        "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
        "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
        """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
        "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
        "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
        "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
        "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
        "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
        """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
        "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
        "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(8, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 16)
        Me.Label22.TabIndex = 96
        Me.Label22.Text = "Reason :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(16, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 24)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "NER"
        '
        'btnNER_ReprintLotLabel
        '
        Me.btnNER_ReprintLotLabel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnNER_ReprintLotLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNER_ReprintLotLabel.ForeColor = System.Drawing.Color.White
        Me.btnNER_ReprintLotLabel.Location = New System.Drawing.Point(208, 344)
        Me.btnNER_ReprintLotLabel.Name = "btnNER_ReprintLotLabel"
        Me.btnNER_ReprintLotLabel.Size = New System.Drawing.Size(160, 32)
        Me.btnNER_ReprintLotLabel.TabIndex = 4
        Me.btnNER_ReprintLotLabel.Text = "Reprint NER Lot Label"
        '
        'btnNERDelAll
        '
        Me.btnNERDelAll.BackColor = System.Drawing.Color.Red
        Me.btnNERDelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNERDelAll.ForeColor = System.Drawing.Color.White
        Me.btnNERDelAll.Location = New System.Drawing.Point(208, 272)
        Me.btnNERDelAll.Name = "btnNERDelAll"
        Me.btnNERDelAll.Size = New System.Drawing.Size(104, 24)
        Me.btnNERDelAll.TabIndex = 6
        Me.btnNERDelAll.Text = "Delete All"
        '
        'btnNERCreatLot
        '
        Me.btnNERCreatLot.BackColor = System.Drawing.Color.Orange
        Me.btnNERCreatLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNERCreatLot.ForeColor = System.Drawing.Color.Black
        Me.btnNERCreatLot.Location = New System.Drawing.Point(208, 392)
        Me.btnNERCreatLot.Name = "btnNERCreatLot"
        Me.btnNERCreatLot.Size = New System.Drawing.Size(160, 32)
        Me.btnNERCreatLot.TabIndex = 3
        Me.btnNERCreatLot.Text = "Create NER Lot"
        '
        'rtxtNER_SN_cnt
        '
        Me.rtxtNER_SN_cnt.BackColor = System.Drawing.Color.Black
        Me.rtxtNER_SN_cnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtxtNER_SN_cnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxtNER_SN_cnt.ForeColor = System.Drawing.Color.Lime
        Me.rtxtNER_SN_cnt.Location = New System.Drawing.Point(208, 136)
        Me.rtxtNER_SN_cnt.Name = "rtxtNER_SN_cnt"
        Me.rtxtNER_SN_cnt.ReadOnly = True
        Me.rtxtNER_SN_cnt.Size = New System.Drawing.Size(88, 56)
        Me.rtxtNER_SN_cnt.TabIndex = 15
        Me.rtxtNER_SN_cnt.Text = "SN Count: 0"
        '
        'txtNER_SN
        '
        Me.txtNER_SN.BackColor = System.Drawing.Color.White
        Me.txtNER_SN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNER_SN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNER_SN.Location = New System.Drawing.Point(16, 96)
        Me.txtNER_SN.Name = "txtNER_SN"
        Me.txtNER_SN.Size = New System.Drawing.Size(176, 20)
        Me.txtNER_SN.TabIndex = 1
        Me.txtNER_SN.Text = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Serial Number:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lstNER_SNs
        '
        Me.lstNER_SNs.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstNER_SNs.BackColor = System.Drawing.Color.White
        Me.lstNER_SNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstNER_SNs.Location = New System.Drawing.Point(16, 128)
        Me.lstNER_SNs.Name = "lstNER_SNs"
        Me.lstNER_SNs.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstNER_SNs.Size = New System.Drawing.Size(176, 303)
        Me.lstNER_SNs.TabIndex = 2
        '
        'btnNERDelOne
        '
        Me.btnNERDelOne.BackColor = System.Drawing.Color.Red
        Me.btnNERDelOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNERDelOne.ForeColor = System.Drawing.Color.White
        Me.btnNERDelOne.Location = New System.Drawing.Point(208, 232)
        Me.btnNERDelOne.Name = "btnNERDelOne"
        Me.btnNERDelOne.Size = New System.Drawing.Size(104, 24)
        Me.btnNERDelOne.TabIndex = 5
        Me.btnNERDelOne.Text = "Delete One"
        '
        'frmAMDBRManifest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(744, 510)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmAMDBRManifest"
        Me.Text = "Build American Messaging Ship Lot"
        Me.TabControl1.ResumeLayout(False)
        Me.tpDBR.ResumeLayout(False)
        Me.tpOtherManifest.ResumeLayout(False)
        Me.tpNER.ResumeLayout(False)
        Me.pnlNER_Reason.ResumeLayout(False)
        CType(Me.cboNER_Reasons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*************************************************************************
    Private Sub frmAMDBRManifest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSql As String = ""
        Dim strMsg As String = ""

        Try
            Me.lblTitle.Text = _strTabPageTitle

            If _iMenuCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID Then
                TabControl1.SelectedTab = Me.tpDBR
                Me.tpDBR.Enabled = True
                Me.tpOtherManifest.Enabled = True
                Me.tpNER.Enabled = True
            Else
                TabControl1.SelectedTab = Me.tpOtherManifest
                'Me.tpDBR.Enabled = False
                EnableTab(Me.tpDBR, False)
                Me.tpOtherManifest.Enabled = True
                'Me.tpNER.Enabled = False
                EnableTab(Me.tpNER, False)
            End If

            Me._dtDBRUnits = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtDBRUnits, "Device_SN", "System.String", "")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtDBRUnits, "Device_ID", "System.Int64", "0")
            Me._dtNERUnits = New DataTable()
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtNERUnits, "Device_SN", "System.String", "")
            PSS.Data.Buisness.Generic.AddNewColumnToDataTable(Me._dtNERUnits, "Device_ID", "System.Int64", "0")

            UpdateCount()
            SelectSNText()

            strSql = "SELECT SC_ID as ID, SC_Desc as 'Desc' FROM tsubcontractor WHERE Prod_ID = 1 and SC_Inactive = 0;"
            PSS.Data.Buisness.Generic.LoadComboBox(Me.cmbSubContractor, strSql, 1)

            strMsg = "Required Items in Excel File:" & Environment.NewLine
            strMsg &= "(1) Serial Number must be in column A of sheet #1" & Environment.NewLine
            strMsg &= "(2) Serial number must start at row 1" & Environment.NewLine
            strMsg &= "(3) No empty row between serial number"
            Me.txtRepLoadSNNote.Text = strMsg

            If Me._iMenuCustID = 14 Then Me.pnlNER_Reason.Visible = True

            Me.LoadNERReasons()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************
    'Disable controls
    Private Sub EnableTab(ByVal page As TabPage, ByVal enable As Boolean)
        EnableControls(page.Controls, enable)
    End Sub
    Private Sub EnableControls(ByVal ctls As Control.ControlCollection, ByVal enable As Boolean)
        Dim ctl As Control
        For Each ctl In ctls
            ctl.Enabled = enable
            EnableControls(ctl.Controls, enable)
        Next
    End Sub

#Region "DBR Manifest TabPage"

    '*******************************************************************
    Private Sub tabModelMaster_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Try
            DrawTab(sender, e, Color.LightSteelBlue, Color.Blue, Color.AntiqueWhite, Color.Black)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error in tabModelMaster_DrawItem")
        End Try
    End Sub

    '*******************************************************************
    Private Sub DrawTab(ByVal sender As Object, _
                        ByVal e As System.Windows.Forms.DrawItemEventArgs, _
                        ByVal FocusedBackColor As Color, _
                        ByVal FocusedForeColor As Color, _
                        ByVal NonFocusedBackColor As Color, _
                        ByVal NonFocusedForeColor As Color)
        Dim f As Font
        Dim backBrush, foreBrush As Brush
        Dim sf As StringFormat
        Dim strTabName As String
        Dim rect As Rectangle
        Dim r As RectangleF
        Dim iAddX(), iAddY(), iAddHeight(), iAddWidth() As Integer

        Try
            sf = New StringFormat()
            f = New Font(e.Font, FontStyle.Regular)

            ReDim iAddX(1)
            ReDim iAddY(1)
            ReDim iAddHeight(1)
            ReDim iAddWidth(1)

            If e.Index = Me.TabControl1.SelectedIndex Then
                backBrush = New System.Drawing.SolidBrush(FocusedBackColor)
                foreBrush = New System.Drawing.SolidBrush(FocusedForeColor)

                Me.TabControl1.TabPages(e.Index).BackColor = FocusedBackColor

                iAddX(0) = 4
                iAddY(0) = -6
                iAddWidth(0) = -6
                iAddHeight(0) = 3
                iAddX(1) = 1
                iAddY(1) = 4
            Else
                backBrush = New System.Drawing.SolidBrush(NonFocusedBackColor)
                foreBrush = New System.Drawing.SolidBrush(NonFocusedForeColor)

                Me.TabControl1.TabPages(e.Index).BackColor = FocusedBackColor

                iAddX(0) = 1
                iAddY(0) = 0
                iAddWidth(0) = -1
                iAddHeight(0) = 1
                iAddX(1) = 0
                iAddY(1) = 4
            End If

            rect = New Rectangle(e.Bounds.X + iAddX(0), e.Bounds.Y + iAddY(0), e.Bounds.Width + iAddWidth(0), e.Bounds.Height + iAddHeight(0))

            sf.Alignment = StringAlignment.Center
            e.Graphics.FillRectangle(backBrush, rect)

            iAddWidth(1) = 0
            iAddHeight(1) = -4

            r = New RectangleF(e.Bounds.X + iAddX(1), e.Bounds.Y + iAddY(1), e.Bounds.Width + iAddWidth(1), e.Bounds.Height + iAddHeight(1))

            strTabName = Me.TabControl1.TabPages(e.Index).Text
            e.Graphics.DrawString(strTabName, f, foreBrush, r, sf)
        Catch ex As Exception
            Throw ex
        Finally
            sf.Dispose()
            f.Dispose()
            backBrush.Dispose()
            foreBrush.Dispose()
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnCreateDBRLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDBRLot.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Const strRptTitle As String = "American Messaging DBR Manifest"
        Const strRptDir As String = "P:\Dept\Messaging\DBR Manifest\"
        Dim strDevice_IDsIN As String = ""
        Dim dt, dtHasDBRPallet, dtShipPalletRpt As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strDBRPallett_name As String = ""
        Dim objRpt As ReportDocument

        Try
            If Me.lstSN.Items.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            '********************
            'Get Device_ID list
            '********************
            For Each R1 In Me._dtDBRUnits.Rows
                If strDevice_IDsIN.Length > 0 Then strDevice_IDsIN &= ", "

                strDevice_IDsIN &= R1("Device_ID")
            Next R1

            '****************************************
            'Get Devices have DBR-Pallett asssigned
            '****************************************
            dtHasDBRPallet = Me._objDBRManifest.GetDevicesHasDBRPallet(strDevice_IDsIN)
            If dtHasDBRPallet.Rows.Count > 0 Then
                R1 = Nothing
                Me.lstAssignedDBRPallet.Items.Clear()
                For Each R1 In dtHasDBRPallet.Rows
                    Me.lstAssignedDBRPallet.Items.Add(R1("Device_SN"))
                Next R1

                Me.lblAssignedDBRPallet.Visible = True
                Me.lstAssignedDBRPallet.Visible = True
                MessageBox.Show("Some devices in the list have DBR-Pallet. Please refer to ""Assigned DBR-Pallet"" list and remove them out from main list.")
                Exit Sub
            End If

            '************************************
            'Create and assigned Pallet to devices
            '************************************
            strDBRPallett_name = Me._objDBRManifest.PalletizeAM_DBRPallet(_iMenuLocID, Me._iMenuCustID, strDevice_IDsIN, Me._strWork_Dt, Me._dtDBRUnits.Rows.Count)

            If strDBRPallett_name = "" Then
                Exit Sub    'Failed to create pallet
            End If

            '************************************
            'Create Excel Report
            '************************************
            dt = Me._objDBRManifest.GetDBRSNData(strDevice_IDsIN)

            objExcelRpt = New Data.ExcelReports()

            objExcelRpt.RunAMManifestReport(dt, strDBRPallett_name, strRptDir, strRptTitle, True)

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strDBRPallett_name, dt.Rows.Count, "DBR", "Fail", New String() {"DBR Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            '************************************
            'Reset controls and global variables
            '************************************
            Me.lblNoneDBR.Visible = False
            Me.lstNoneDBR.Items.Clear()
            Me.lstNoneDBR.Refresh()
            Me.lstNoneDBR.Visible = False
            Me.lblAssignedDBRPallet.Visible = False
            Me.lstAssignedDBRPallet.Items.Clear()
            Me.lstAssignedDBRPallet.Refresh()
            Me.lstAssignedDBRPallet.Visible = False
            Me.btnDeleteAll.Enabled = False
            Me.btnDeleteOne.Enabled = False
            Me.btnCreateDBRLot.Enabled = False
            Me._dtDBRUnits.Rows.Clear()
            Me.lstSN.Items.Clear()
            Me.lstSN.Refresh()

            UpdateCount()
            SelectSNText()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating DBR Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dtHasDBRPallet)
            Generic.DisposeDT(dtShipPalletRpt)
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub txtSN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSN.KeyDown
        Const iDBR_BillcodeID As Integer = 25
        Dim strSN, strSNStatus As String
        Dim iDevice_ID As Int64
        Dim iDCode_ID As Integer = 0    'DBR Failure Code
        Dim iModelID As Integer = 0    'DBR Failure Code
        Dim R1 As DataRow
        Dim dtBillingInfo As DataTable

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtSN.Text.Trim.Length > 0 Then
                    strSN = Me.txtSN.Text.Trim.ToUpper

                    '*****************************
                    'Check for limitation
                    '*****************************
                    If Me._dtDBRUnits.Rows.Count >= 200 Then
                        MessageBox.Show("You have reached the limit of ""200 Devices"". Please click ""Print Manifest"" button before you continue.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.Text = ""
                        Exit Sub
                    End If

                    '*****************************
                    'Check for duplicate in list
                    '*****************************
                    If Me.lstSN.Items.IndexOf(strSN) > -1 Then
                        MsgBox("This serial number is already listed.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Listed")
                        SelectSNText()
                        Exit Sub
                    End If

                    '*****************************
                    'Check for device status
                    'After this call variable iDevice_ID 
                    ' will be available(pass by reference)
                    '*****************************
                    strSNStatus = Me._objDBRManifest.CheckSN(Me._iMenuLocID, strSN, iDevice_ID, iModelID, "DBR")

                    If strSNStatus.Length > 0 Then
                        If Me.lstNoneDBR.Items.IndexOf(strSN) < 0 Then
                            Me.lstNoneDBR.Items.Add(strSN)
                        End If

                        Me.txtSN.Text = ""
                        MsgBox(strSNStatus, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                        SelectSNText()
                    Else
                        '**********************
                        'validate NER criteria
                        '**********************
                        dtBillingInfo = Me._objDBRManifest.GetDeviceBillingInfo(iDevice_ID)
                        If dtBillingInfo.Rows.Count = 0 Then
                            MessageBox.Show("No billing information for this unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                        ElseIf dtBillingInfo.Rows.Count > 1 Then
                            MessageBox.Show("Device has parts/service. Please remove all.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                        ElseIf dtBillingInfo.Rows.Count = 1 And dtBillingInfo.Rows(0)("Billcode_ID") <> iDBR_BillcodeID Then
                            MessageBox.Show("This is not an DBR unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                        Else
                            '***************************
                            'Get DBR Reason if missing
                            '***************************
                            iDCode_ID = Me._objDBRManifest.GetDBRFailCode(iDevice_ID)
                            While iDCode_ID = 0
                                Me.ShowDBRReasonScreen(iDevice_ID)
                                iDCode_ID = Me._objDBRManifest.GetDBRFailCode(iDevice_ID)

                                If iDCode_ID = 0 Then
                                    If MessageBox.Show("DBR Reason can't be saved." & Environment.NewLine & "Would you like to select 'DBR Reason' again or click No button to exit.", "DBR Reason", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                                        MsgBox("No DBR Reason and device is not listed.", MsgBoxStyle.Critical, "DBR Reason")
                                        Me.txtSN.SelectAll()
                                        Exit Sub
                                    End If
                                End If
                            End While

                            '*******************
                            'Add Record
                            '*******************
                            R1 = Nothing
                            R1 = Me._dtDBRUnits.NewRow
                            R1("Device_SN") = strSN
                            R1("Device_ID") = iDevice_ID
                            Me._dtDBRUnits.Rows.Add(R1)
                            Me._dtDBRUnits.AcceptChanges()

                            Me.lstSN.Items.Add(strSN)
                            Me.lstSN.Refresh()

                            If Me._dtDBRUnits.Rows.Count > 0 Then Me.btnCreateDBRLot.Enabled = True

                            '*******************
                            'Update counter
                            '*******************
                            UpdateCount()
                            Me.txtSN.Text = ""
                            SelectSNText()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Processing Serial Number")
        Finally
            If Me.lstNoneDBR.Items.Count > 0 Then
                Me.lstNoneDBR.Visible = True
                Me.lblNoneDBR.Visible = True
            End If
            Generic.DisposeDT(dtBillingInfo)
        End Try
    End Sub

    '*************************************************
    '//Added by Asif
    'This provides a window to the user to select 
    'the DBR reason for METROCALL & AM customer only
    '*************************************************
    Private Sub ShowDBRReasonScreen(ByVal iDevice_ID As Integer)
        Dim objDBR As New Gui.Billing.frmDBRReason()
        Dim i As Integer = 0
        Try
            With objDBR
                .CustID = Me._iMenuCustID
                .DeviceID = iDevice_ID
                .ShowDialog()
                'Update the DB with the selected DBR reason
                i = .UPD
            End With
            'End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objDBR) Then
                objDBR.Dispose()
                objDBR = Nothing
            End If

        End Try
    End Sub

    '*************************************************************************
    Private Sub btnDeleteOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOne.Click
        Dim strSN As String = ""
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            If Me.lstSN.Items.Count > 0 Then
                '*******************
                'Get Removed SN
                '*******************
                strSN = Trim(InputBox("Scan SN:", "Delete One SN From List", "", )).ToUpper
                If strSN = "" Then
                    Exit Sub
                End If

                '****************************************************
                'Removed SN from the main list and global datatable
                '****************************************************
                For Each R1 In Me._dtDBRUnits.Rows
                    If R1("Device_SN").ToString.ToUpper.Trim = strSN.ToUpper.Trim Then
                        R1.Delete()
                        Exit For
                    End If
                Next R1

                Me._dtDBRUnits.AcceptChanges()

                i = Me.lstSN.Items.IndexOf(strSN)
                If i > -1 Then
                    Me.lstSN.Items.RemoveAt(Me.lstSN.Items.IndexOf(strSN))
                    Me.lstSN.Refresh()
                Else
                    MessageBox.Show("SN is not listed.", "Remove One Item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSN.Focus()
                    Exit Sub
                End If

                '*********************************************
                'Removed SN from the "Has DBR-Pallet" list
                '*********************************************
                For i = 0 To Me.lstAssignedDBRPallet.Items.Count - 1
                    If Me.lstAssignedDBRPallet.Items.Item(i).ToString.Trim.ToUpper = strSN.Trim.ToUpper Then
                        Me.lstSN.Items.RemoveAt(i)
                        Exit For
                    End If
                Next i

                '********************
                'Update counter
                '********************
                UpdateCount()
            End If

            SelectSNText()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Selected Serial Number")
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnDeleteAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim i As Integer

        Try
            If Me.lstSN.Items.Count > 0 Then
                If MsgBox("Delete all serial numbers from list?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete All SNs") = MsgBoxResult.Yes Then

                    Me._dtDBRUnits.Rows.Clear()
                    Me.lstSN.Refresh()

                    Me.lstSN.Items.Clear()
                    Me.lstSN.Refresh()

                    Me.lblAssignedDBRPallet.Visible = False
                    Me.lstAssignedDBRPallet.Items.Clear()
                    Me.lstAssignedDBRPallet.Refresh()

                    Me.lblNoneDBR.Visible = False
                    Me.lstNoneDBR.Items.Clear()
                    Me.lstNoneDBR.Refresh()

                    UpdateCount()
                End If
            End If

            SelectSNText()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Serial Numbers")
        End Try
    End Sub

    '*************************************************************************
    Private Sub UpdateCount()
        Dim iStart As Integer

        Try
            Me.rtfSNCount.Text = "SN Count: " & Me.lstSN.Items.Count.ToString

            Me.rtfSNCount.SelectionStart = 0
            Me.rtfSNCount.SelectionLength = Me.rtfSNCount.Text.Length
            Me.rtfSNCount.SelectionAlignment = HorizontalAlignment.Center

            iStart = Me.rtfSNCount.Text.IndexOf(":")

            If iStart > -1 Then
                iStart += 2

                Me.rtfSNCount.SelectionStart = iStart
                Me.rtfSNCount.SelectionLength = Me.rtfSNCount.Text.Length - iStart
                Me.rtfSNCount.SelectionFont = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                Me.rtfSNCount.SelectionColor = Color.Green
            End If

            If Me.lstSN.Items.Count > 0 Then
                Me.btnDeleteOne.Enabled = True
                Me.btnDeleteAll.Enabled = True
                Me.btnCreateDBRLot.Enabled = True
            Else
                Me.btnDeleteOne.Enabled = False
                Me.btnDeleteAll.Enabled = False
                Me.btnCreateDBRLot.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*************************************************************************
    Private Sub SelectSNText()
        If Me.txtSN.Text.Trim.Length > 0 Then Me.txtSN.SelectAll()
        Me.txtSN.Focus()
    End Sub

    '*************************************************************************
    Private Sub btnReprintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintManifest.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim dt, dtShipPalletRpt As DataTable
        Dim strDBRPallett_name, strResult As String
        Dim objRpt As ReportDocument
        Dim objMisc As Data.Buisness.Misc
        Dim iPallettQty As Integer = 0

        Try
            strDBRPallett_name = "" : strResult = ""

            strDBRPallett_name = InputBox("Enter Pallet Name:", "Pallet", "").Trim.ToUpper
            If strDBRPallett_name = "" Then
                Exit Sub
            End If

            strResult = Microsoft.VisualBasic.Left(strDBRPallett_name, 3)

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            '************************************
            'Get Pallett information
            '************************************
            objMisc = New Data.Buisness.Misc()
            dt = objMisc.GetPalletInfo_ByPallettName(strDBRPallett_name)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pallet name does not exist.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSN.Focus()
                Exit Sub
            End If

            If Not IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                iPallettQty = dt.Rows(0)("Pallett_QTY")
            Else
                iPallettQty = Me._objDBRManifest.GetDevCountByPalletID(dt.Rows(0)("Pallett_ID"))
            End If

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strDBRPallett_name, iPallettQty, strResult, "Fail", New String() {"DBR Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            SelectSNText()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Reprint Manifest Label")
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub tpDBR_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpDBR.Enter
        Me.txtSN.Text = ""
        Me.txtSN.Focus()
    End Sub

    ''*************************************************************************
    'Private Sub tpDBR_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpDBR.Leave
    '    Me.txtSN.Text = ""
    '    Me.lstSN.Items.Clear()
    '    Me._dtDBRUnits.Rows.Clear()
    '    Me.btnPrintManifest.Enabled = False
    '    Me.UpdateCount()
    'End Sub

    '*************************************************************************
    Private Sub btnRecreateDBRManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecreateDBRManifest.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Const strRptDir As String = "P:\Dept\Messaging\DBR Manifest\"
        'Const strRptDir As String = "C:\DBR Manifest\"
        Dim strRptTitle As String
        Dim strDevice_IDsIN As String = ""
        Dim dt, dt1 As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strDBRPallett_name As String = ""
        Dim objRpt As ReportDocument
        Dim booPrintRpt As Boolean = True

        Try

            strDBRPallett_name = InputBox("Please enter Pallet Name:", "Information").Trim
            If strDBRPallett_name.Length = 0 Then Exit Sub

            If strDBRPallett_name.StartsWith("DBR") Then
                strRptTitle = "American Messaging DBR Manifest"
            ElseIf strDBRPallett_name.StartsWith("NER") Then
                strRptTitle = "American Messaging NER Manifest"
            Else
                MessageBox.Show("Invalid Entry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If System.IO.File.Exists(strRptDir & strDBRPallett_name & ".xls") = True Then
                MessageBox.Show("File is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

                If MessageBox.Show("Do you want to print the report?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then booPrintRpt = False

                '************************************
                'Create Excel Report
                '************************************
                dt = Me._objDBRManifest.GetDBRSNDataByPalletName(strDBRPallett_name)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Please check Pallet Name again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                objExcelRpt = New Data.ExcelReports()

                objExcelRpt.RunAMManifestReport(dt, strDBRPallett_name, strRptDir, strRptTitle, True, booPrintRpt)

                '************************************
                'Reset controls and global variables
                '************************************

                SelectSNText()

                MsgBox("Completed.", MsgBoxStyle.Information, "Information")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating DBR Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dt1)
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************

#End Region

#Region "Other Manifest TabPage"

    '*************************************************************************
    Private Sub txtRepSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRepSN.KeyDown
        Dim strSN As String = ""
        Dim strSNStatus As String = ""
        Dim iDCode_ID As Integer = 0    'DBR Failure Code
        Dim R1 As DataRow

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtRepSN.Text.Trim.Length > 0 Then
                    strSN = Me.txtRepSN.Text.Trim.ToUpper

                    '*****************************
                    'Check for location
                    '*****************************
                    If Me.cmbSubContractor.SelectedValue = 0 Then
                        MessageBox.Show("Please select ""Send To Location"".", "Repair SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.cmbSubContractor.Focus()
                        Exit Sub
                    End If

                    '*****************************
                    'Check for limitation
                    '*****************************
                    'If Me.lstRepSN.Items.Count > 200 Then
                    '    MessageBox.Show("You have reached the limit of ""200 Devices"". Please click ""Print Manifest"" button before you continue.", "Repair SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    '    Me.txtRepSN.Text = ""
                    '    Exit Sub
                    'End If

                    '*****************************
                    'Check for duplicate in list
                    '*****************************
                    If Me.lstRepSN.Items.IndexOf(strSN) > -1 Then
                        MsgBox("This serial number is already listed.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Listed")
                        Me.txtRepSN.Text = ""
                        Exit Sub
                    End If

                    '''*****************************
                    '''Check for existing of SN
                    '''*****************************
                    ''If Me.cmbSubContractor.SelectedValue <> 11 Then
                    ''    strSNStatus = Me._objDBRManifest.CheckExistingOfSN(strSN)
                    ''End If

                    If strSNStatus.Length > 0 Then
                        MsgBox(strSNStatus, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                        Me.txtRepSN.SelectAll()
                        Exit Sub
                    Else
                        '*******************
                        'Add Record
                        '*******************
                        Me.lstRepSN.Items.Add(strSN)
                        Me.lstRepSN.Refresh()

                        '*******************
                        'Update counter
                        '*******************
                        Me.lblRepCounter.Text = Me.lstRepSN.Items.Count.ToString

                        If Me.lstRepSN.Items.Count > 0 Then
                            Me.btnRepDelOne.Enabled = True
                            Me.btnRepDelAll.Enabled = True
                            Me.btnRepPrintManifest.Enabled = True
                        Else
                            Me.btnRepDelOne.Enabled = False
                            Me.btnRepDelAll.Enabled = False
                            Me.btnRepPrintManifest.Enabled = False
                        End If

                        Me.txtRepSN.Text = ""
                        Me.txtRepSN.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Processing Serial Number")
            Me.txtRepSN.SelectAll()
        Finally

        End Try
    End Sub

    '*************************************************************************
    Private Sub btnRepPrintManifest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRepPrintManifest.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim dt, dtDupSN, dtShipPalletRpt As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strToRepPallett_Name As String = ""
        Dim strSNs As String = ""
        Dim objRpt As ReportDocument
        Dim i As Integer = 0
        Dim iPallett_ID As Integer = 0
        Dim strRptTitle As String = "" '"AMS "
        Dim strRptDir As String = "" 'P:\Dept\Messaging\OtherManifest\"

        Try
            If Me.lstRepSN.Items.Count = 0 Then
                Exit Sub
            End If

            Select Case Me._iMenuCustID
                Case PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID
                    strRptTitle = "AMS "
                    strRptDir = "P:\Dept\Messaging\OtherManifest\"
                Case PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID
                    strRptTitle = "SkyTel "
                    strRptDir = "P:\Dept\Messaging\OtherManifest_SkyTel\"
                Case PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID
                    strRptTitle = "MorrisCom "
                    strRptDir = "P:\Dept\Messaging\OtherManifest_MorrisCom\"
                Case PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID
                    strRptTitle = "Propage "
                    strRptDir = "P:\Dept\Messaging\OtherManifest_Propage\"
                Case Else
                    MessageBox.Show("Invalid Customer ID!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
            End Select


            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            If Me.cmbSubContractor.SelectedValue = 0 Then
                MessageBox.Show("Please select ""Send to Location"".", "Create Manifest", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cmbSubContractor.Focus()
                Exit Sub
            End If

            strRptTitle &= Me.cmbSubContractor.Text & " Manifest"
            strRptDir &= Me.cmbSubContractor.Text & "\"

            '********************
            'Get Device_ID list
            '********************
            For i = 0 To Me.lstRepSN.Items.Count - 1
                If strSNs.Length > 0 Then strSNs &= ", "
                strSNs &= "'" & Me.lstRepSN.Items.Item(i) & "'"
            Next i

            '************************************
            'Create and assigned Pallet to devices
            '************************************
            strToRepPallett_Name = Me._objDBRManifest.PalletizeAM_OutToRepPallet(_iMenuLocID, Me._iMenuCustID, Me.lstRepSN, Me._strWork_Dt, Me.cmbSubContractor.SelectedValue, iPallett_ID)
            If strToRepPallett_Name = "" Then
                Exit Sub    'Failed to create pallet
            End If

            '************************************
            'Create Excel Report
            '************************************
            dt = Me._objDBRManifest.GetOTRep_SNData(iPallett_ID)

            objExcelRpt = New Data.ExcelReports()

            objExcelRpt.RunAMManifestReport(dt, strToRepPallett_Name, strRptDir, strRptTitle)

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strToRepPallett_Name, dt.Rows.Count, "", Me.cmbSubContractor.Text, New String() {"DBR Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            '************************************
            'Reset controls and global variables
            '************************************
            Me.btnRepDelAll.Enabled = False
            Me.btnRepDelOne.Enabled = False
            Me.btnRepPrintManifest.Enabled = False
            Me.lstRepSN.Items.Clear()
            Me.lstRepSN.Refresh()

            Me.lblRepCounter.Text = Me.lstRepSN.Items.Count
            Me.txtRepSN.SelectAll()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating DBR Manifest")
            Me.txtRepSN.Focus()
        Finally
            R1 = Nothing
            If Not IsNothing(dtDupSN) Then
                dtDupSN.Dispose()
                dtDupSN = Nothing
            End If
            Me.Enabled = True
            Me.txtRepSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnRepDelOne_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRepDelOne.Click
        Dim i As Integer = 0
        Dim strSN As String = ""

        Try
            If Me.lstRepSN.Items.Count > 0 Then
                '*******************
                'Get Removed SN
                '*******************
                strSN = Trim(InputBox("Scan SN:", "Delete One SN From List", "", )).ToUpper
                If strSN = "" Then
                    Exit Sub
                End If

                '******************************
                'Removed SN from the maim list
                '******************************
                i = Me.lstRepSN.Items.IndexOf(strSN)
                If i > -1 Then
                    Me.lstRepSN.Items.RemoveAt(i)
                    Me.lstRepSN.Refresh()
                Else
                    MessageBox.Show("SN is not listed.", "Remove One Item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtRepSN.Focus()
                    Exit Sub
                End If

                '**************************************
                'Reset controls
                '**************************************
                Me.lblRepCounter.Text = Me.lstRepSN.Items.Count.ToString

                If Me.lstRepSN.Items.Count > 0 Then
                    Me.btnRepDelOne.Enabled = True
                    Me.btnRepDelAll.Enabled = True
                    Me.btnRepPrintManifest.Enabled = True
                Else
                    Me.btnRepDelOne.Enabled = False
                    Me.btnRepDelAll.Enabled = False
                    Me.btnRepPrintManifest.Enabled = False
                End If

                Me.txtRepSN.Text = ""
                Me.txtRepSN.Focus()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete One SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnRepDelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRepDelAll.Click
        If Me.lstRepSN.Items.Count > 0 Then

            If MessageBox.Show("Are you sure you want to delete all SNs from list?", "Delete All SN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.lstRepSN.Items.Clear()
            Me.lstRepSN.Refresh()

            Me.lblRepCounter.Text = Me.lstRepSN.Items.Count.ToString
            Me.btnRepDelOne.Enabled = False
            Me.btnRepDelAll.Enabled = False
            Me.btnRepPrintManifest.Enabled = False

            Me.txtRepSN.Text = ""
            Me.txtRepSN.Focus()
        End If
    End Sub

    '*************************************************************************
    Private Sub cmbSubContractor_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubContractor.SelectionChangeCommitted
        If Me.cmbSubContractor.SelectedValue > 0 Then
            Me.txtRepSN.Focus()
        End If
    End Sub

    '*************************************************************************
    Private Sub btnRepLoadSNFrExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepLoadSNFrExcel.Click
        Dim strFilePath As String = ""
        Dim strSN As String = ""
        Dim objExcel As Excel.Application    ' Excel application
        Dim objBook As Excel.Workbook     ' Excel workbook
        Dim objSheet As Excel.Worksheet    ' Excel Worksheet
        Dim i As Integer = 1
        Dim j As Integer = 0

        Try
            'Clear list box
            Me.lstRepSN.Items.Clear()
            Me.lstRepSN.Refresh()
            Me.lblRepCounter.Text = "0"

            'Get excel file
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.FilterIndex = 1
            Me.OpenFileDialog1.FileName = "*.xls"
            Me.OpenFileDialog1.ShowDialog()
            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MessageBox.Show("Incorrect file extension. It must be ""XLS"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                strFilePath = Trim(Me.OpenFileDialog1.FileName)

                '*****************************
                'Load SN in file to list box
                '*****************************
                objExcel = New Excel.Application()
                objBook = objExcel.Workbooks.Open(strFilePath)
                objSheet = objExcel.Worksheets(1)

                While j < 20
                    If Len(Trim(objSheet.Range("A" & i).Value)) > 0 Then
                        strSN = UCase(Trim(objSheet.Range("A" & i).Value))
                        Me.lstRepSN.Items.Add(strSN)
                        j = 0
                    Else
                        j += 1
                    End If
                    strSN = ""
                    i += 1
                End While

                '*****************************
            Else
                MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Me.lblRepCounter.Text = Me.lstRepSN.Items.Count.ToString
            If Me.lstRepSN.Items.Count > 0 Then
                Me.btnRepDelOne.Enabled = True
                Me.btnRepDelAll.Enabled = True
                Me.btnRepPrintManifest.Enabled = True
            Else
                Me.btnRepDelOne.Enabled = False
                Me.btnRepDelAll.Enabled = False
                Me.btnRepPrintManifest.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Load SN From Excel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(objSheet) Then
                objSheet = Nothing
                NAR(objSheet)
            End If
            If Not IsNothing(objBook) Then
                objBook.Close()
                objBook = Nothing
                NAR(objBook)
            End If
            If Not IsNothing(objExcel) Then
                objExcel.Quit()
                objExcel = Nothing
                NAR(objExcel)
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()

            Me.txtRepSN.Focus()
        End Try
    End Sub

    '*************************************************************************
    Private Sub NAR(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnRepRePrintLotLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepRePrintLotLabel.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim dt As DataTable
        Dim strPalletName As String = ""
        Dim dtShipPalletRpt As DataTable
        Dim objRpt As ReportDocument

        Try
            strPalletName = InputBox("Please enter Lot Name:").Trim

            If strPalletName.Trim = "" Then
                Exit Sub
            End If

            dt = Me._objDBRManifest.GetAMOutToRepLotInfo(strPalletName)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Lot Name does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strPalletName, dt.Rows.Count, "", dt.Rows(0)("SC_Desc"), New String() {"DBR Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Reprint Lot Label", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objRpt = Nothing
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
            If Not IsNothing(dtShipPalletRpt) Then
                dtShipPalletRpt.Dispose()
                dtShipPalletRpt = Nothing
            End If
        End Try
    End Sub

    '*************************************************************************

#End Region

#Region "NER Manifest TabPage"

    '*************************************************************************
    Private Sub LoadNERReasons()
        Dim dt As DataTable

        Try
            dt = Me._objDBRManifest.GetNERReasons(True, True, True)
            Misc.PopulateC1DropDownList(Me.cboNER_Reasons, dt, "DispalyDesc", "Dcode_ID")
            'Me.cboNER_Reasons.SelectedValue = 0   'Empty Row      0 is a Magoc number :)
            If dt.Rows.Count >= 1 AndAlso dt.Rows.Count <= 2 Then
                Me.cboNER_Reasons.SelectedValue = dt.Rows(0).Item("Dcode_ID")
                ' pnlNER_Reason.Visible = False
            Else
                Me.cboNER_Reasons.SelectedValue = 0
                'pnlNER_Reason.Enabled = True
            End If

            pnlNER_Reason.Visible = False 'no need

        Catch ex As Exception
            Throw ex
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNERCreatLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNERCreatLot.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim strDevice_IDsIN As String = ""
        Dim dt, dtHasDBRPallet, dtShipPalletRpt As DataTable
        Dim R1 As DataRow
        Dim objExcelRpt As Data.ExcelReports
        Dim strNERPallett_name As String = ""
        Dim objRpt As ReportDocument
        Dim strRptTitle As String = "American Messaging NER Manifest"
        Dim strRptDir As String = "P:\Dept\Messaging\DBR Manifest\"

        Try
            If Me.lstNER_SNs.Items.Count = 0 Then
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            '********************
            'Get Device_ID list
            '********************
            For Each R1 In Me._dtNERUnits.Rows
                If strDevice_IDsIN.Length > 0 Then strDevice_IDsIN &= ", "

                strDevice_IDsIN &= R1("Device_ID")
            Next R1

            '****************************************
            'Get Devices have DBR-Pallett asssigned
            '****************************************
            dtHasDBRPallet = Me._objDBRManifest.GetDevicesHasDBRPallet(strDevice_IDsIN)
            If dtHasDBRPallet.Rows.Count > 0 Then
                R1 = Nothing

                MessageBox.Show("Some devices in the list have already assigned Pallet. Please remove them out from main list.")
                Exit Sub
            End If

            '************************************
            'Create and assigned Pallet to devices
            '************************************
            strNERPallett_name = Me._objDBRManifest.PalletizeAM_NERPallet(_iMenuLocID, Me._iMenuCustID, strDevice_IDsIN, Me._strWork_Dt, Me._dtNERUnits.Rows.Count, PSS.Core.ApplicationUser.IDShift)

            If strNERPallett_name = "" Then
                Exit Sub    'Failed to create pallet
            End If

            '************************************
            'Create Excel Report
            '************************************
            dt = Me._objDBRManifest.GetNERSNData(strDevice_IDsIN)

            objExcelRpt = New Data.ExcelReports()

            objExcelRpt.RunAMManifestReport(dt, strNERPallett_name, strRptDir, strRptTitle, True)

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strNERPallett_name, dt.Rows.Count, "NER", "Fail", New String() {"NER Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            '************************************
            'Reset controls and global variables
            '************************************
            Me.btnNERDelAll.Enabled = False
            Me.btnNERDelOne.Enabled = False
            Me.btnNERCreatLot.Enabled = False
            Me._dtNERUnits.Rows.Clear()
            Me.lstNER_SNs.Items.Clear()
            Me.lstNER_SNs.Refresh()

            Me.cboNER_Reasons.Enabled = True

            UpdateNERCount()
            If Me.txtNER_SN.Text.Trim.Length > 0 Then Me.txtNER_SN.SelectAll()
            Me.txtNER_SN.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating NER Manifest")
        Finally
            objRpt = Nothing
            objExcelRpt = Nothing
            R1 = Nothing
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dtHasDBRPallet)
            Generic.DisposeDT(dtShipPalletRpt)
            Me.Enabled = True
            Me.txtNER_SN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub txtNER_SN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNER_SN.KeyDown
        Dim strSN, strSNStatus As String
        Dim iDevice_ID, iModelID As Integer
        Dim R1 As DataRow
        Dim dtBillingInfo As DataTable
        Dim objDevice As Rules.Device
        Dim dt As DataTable

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtNER_SN.Text.Trim.Length > 0 Then
                    strSN = Me.txtNER_SN.Text.Trim.ToUpper

                    '*****************************
                    'Check for limitation
                    '*****************************
                    If Me._dtNERUnits.Rows.Count >= 200 Then
                        MessageBox.Show("You have reached the limit of ""200 Devices"".", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtNER_SN.Text = ""
                        Exit Sub
                    End If

                    '*****************************
                    'Check for duplicate in list
                    '*****************************
                    If Me.lstNER_SNs.Items.IndexOf(strSN) > -1 Then
                        MsgBox("This serial number is already listed.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "SN Listed")
                        SelectSNText()
                        Exit Sub
                    End If

                    '*****************************
                    'Check for device status
                    'After this call variable iDevice_ID 
                    ' will be available(pass by reference)
                    '*****************************
                    strSNStatus = Me._objDBRManifest.CheckSN(Me._iMenuLocID, strSN, iDevice_ID, iModelID, "NER")

                    If strSNStatus.Length > 0 Then
                        Me.txtNER_SN.Text = ""
                        MsgBox(strSNStatus, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Invalid Device")
                        Me.txtNER_SN.Focus()
                    Else
                        '**********************
                        'Bill NER
                        '**********************
                        dtBillingInfo = Me._objDBRManifest.GetDeviceBillingInfo(iDevice_ID)
                        If dtBillingInfo.Rows.Count = 0 Then
                            'check for valid NER billcode
                            If Me._objDBRManifest.IsBillableBillcode(Me._iNER_BillcodeID, iModelID) = False Then
                                MsgBox("NER billcode is not available for this model.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Invalid Device")
                                Me.txtNER_SN.Text = ""
                                Me.txtNER_SN.Focus()
                                Exit Sub
                            End If

                            objDevice = New Rules.Device(iDevice_ID)
                            objDevice.AddPart(_iNER_BillcodeID)
                            objDevice.Update()
                            dtBillingInfo = Me._objDBRManifest.GetDeviceBillingInfo(iDevice_ID)
                        End If

                        '**********************
                        'validate NER criteria
                        '**********************
                        If dtBillingInfo.Rows.Count = 0 Then
                            MessageBox.Show("System has failed to bill NER for this unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtNER_SN.SelectAll()
                        ElseIf dtBillingInfo.Rows.Count > 1 Then
                            MessageBox.Show("This device has parts/service. Please remove all.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtNER_SN.SelectAll()
                        ElseIf dtBillingInfo.Rows.Count = 1 And dtBillingInfo.Rows(0)("Billcode_ID") <> _iNER_BillcodeID Then
                            MessageBox.Show("This is not an NER unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtNER_SN.SelectAll()
                        Else
                            dt = Me._objDBRManifest.GetDeviceData(iDevice_ID)
                            If dt.Rows(0).IsNull("Device_DateShip") Then 'old way, billing NER didn't update Device_DateShip
                                'Me.cboNER_Reasons.Visible = True
                                If Me.cboNER_Reasons.SelectedValue > 0 Then Me._objDBRManifest.AddDeviceCode(iDevice_ID, Me.cboNER_Reasons.SelectedValue)
                                'Else
                                'Me.cboNER_Reasons.Visible = False
                            End If
                            'If Me.cboNER_Reasons.SelectedValue > 0 Then Me._objDBRManifest.AddDeviceCode(iDevice_ID, Me.cboNER_Reasons.SelectedValue)

                            '*******************
                            'Add Record
                            '*******************
                            R1 = Nothing
                            R1 = Me._dtNERUnits.NewRow
                            R1("Device_SN") = strSN
                            R1("Device_ID") = iDevice_ID
                            Me._dtNERUnits.Rows.Add(R1)
                            Me._dtNERUnits.AcceptChanges()

                            Me.lstNER_SNs.Items.Add(strSN)
                            Me.lstNER_SNs.Refresh()

                            If Me._dtNERUnits.Rows.Count > 0 Then Me.btnNERCreatLot.Enabled = True

                            '*******************
                            'Update counter
                            '*******************
                            UpdateNERCount()
                            Me.txtNER_SN.Text = ""
                            If Me.txtNER_SN.Text.Trim.Length > 0 Then Me.txtNER_SN.SelectAll()
                            Me.txtNER_SN.Focus()
                            End If
                    End If
                End If

                If Me.lstNER_SNs.Items.Count > 0 Then Me.cboNER_Reasons.Enabled = False Else Me.cboNER_Reasons.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Processing Serial Number")
        Finally
            R1 = Nothing : dt = Nothing
            Generic.DisposeDT(dtBillingInfo)
            If Not IsNothing(objDevice) Then
                objDevice.Dispose()
                objDevice = Nothing
            End If
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNERDelOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNERDelOne.Click
        Dim strSN As String = ""
        Dim R1 As DataRow
        Dim i As Integer = 0
        Dim objDevice As Rules.Device

        Try
            If Me.lstNER_SNs.Items.Count > 0 Then
                '*******************
                'Get Removed SN
                '*******************
                strSN = Trim(InputBox("Scan SN:", "Delete One SN From List", "", )).ToUpper
                If strSN = "" Then
                    Exit Sub
                End If

                '****************************************************
                'Removed SN from the main list and global datatable
                '****************************************************
                For Each R1 In Me._dtNERUnits.Rows
                    If R1("Device_SN").ToString.ToUpper.Trim = strSN.ToUpper.Trim Then

                        If Generic.IsBillcodeExisted(R1("Device_ID"), Me._iNER_BillcodeID) Then
                            objDevice = New Rules.Device(R1("Device_ID"))
                            objDevice.DeletePart(Me._iNER_BillcodeID)
                            objDevice.Update() : objDevice.Dispose() : objDevice = Nothing

                            'Remove NER Reason
                            If Me.cboNER_Reasons.SelectedValue > 0 Then Me._objDBRManifest.RemoveNERReason(R1("Device_ID"), Me.cboNER_Reasons.SelectedValue)
                        End If

                        R1.Delete()
                        Exit For
                    End If
                Next R1

                Me._dtNERUnits.AcceptChanges()

                i = Me.lstNER_SNs.Items.IndexOf(strSN)
                If i > -1 Then
                    Me.lstNER_SNs.Items.RemoveAt(Me.lstNER_SNs.Items.IndexOf(strSN))
                    Me.lstNER_SNs.Refresh()
                Else
                    MessageBox.Show("SN is not listed.", "Remove One Item From List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSN.Focus()
                    Exit Sub
                End If

                '********************
                'Update counter
                '********************
                UpdateNERCount()
            End If

            If Me.lstNER_SNs.Items.Count > 0 Then Me.cboNER_Reasons.Enabled = False Else Me.cboNER_Reasons.Enabled = True

            If Me.txtNER_SN.Text.Trim.Length > 0 Then Me.txtNER_SN.SelectAll()
            Me.txtNER_SN.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Selected Serial Number")
        Finally
            R1 = Nothing
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNERDelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNERDelAll.Click
        Dim i As Integer
        Dim R1 As DataRow
        Dim objDevice As Rules.Device

        Try
            If Me.lstNER_SNs.Items.Count > 0 Then
                If MsgBox("Delete all serial numbers from list?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete All SNs") = MsgBoxResult.Yes Then

                    For Each R1 In _dtNERUnits.Rows
                        If Generic.IsBillcodeExisted(R1("Device_ID"), Me._iNER_BillcodeID) Then
                            objDevice = New Rules.Device(R1("Device_ID"))
                            objDevice.DeletePart(Me._iNER_BillcodeID)
                            objDevice.Update() : objDevice.Dispose() : objDevice = Nothing

                            'Remove NER Reason
                            If Me.cboNER_Reasons.SelectedValue > 0 Then Me._objDBRManifest.RemoveNERReason(R1("Device_ID"), Me.cboNER_Reasons.SelectedValue)
                        End If
                    Next R1

                    Me._dtNERUnits.Rows.Clear()
                    Me.lstNER_SNs.Refresh()

                    Me.lstNER_SNs.Items.Clear()
                    Me.lstNER_SNs.Refresh()

                    UpdateNERCount()
                End If
            End If

            Me.cboNER_Reasons.Enabled = True

            If Me.txtNER_SN.Text.Trim.Length > 0 Then Me.txtNER_SN.SelectAll()
            Me.txtNER_SN.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Deleting Serial Numbers")
        End Try
    End Sub

    '*************************************************************************
    Private Sub UpdateNERCount()
        Dim iStart As Integer

        Try
            Me.rtxtNER_SN_cnt.Text = "SN Count: " & Me.lstNER_SNs.Items.Count.ToString

            Me.rtxtNER_SN_cnt.SelectionStart = 0
            Me.rtxtNER_SN_cnt.SelectionLength = Me.rtfSNCount.Text.Length
            Me.rtxtNER_SN_cnt.SelectionAlignment = HorizontalAlignment.Center

            iStart = Me.rtxtNER_SN_cnt.Text.IndexOf(":")

            If iStart > -1 Then
                iStart += 2

                Me.rtxtNER_SN_cnt.SelectionStart = iStart
                Me.rtxtNER_SN_cnt.SelectionLength = Me.rtfSNCount.Text.Length - iStart
                Me.rtxtNER_SN_cnt.SelectionFont = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
                Me.rtxtNER_SN_cnt.SelectionColor = Color.Green
            End If

            If Me.lstNER_SNs.Items.Count > 0 Then
                Me.btnNERDelOne.Enabled = True
                Me.btnNERDelAll.Enabled = True
                Me.btnNERCreatLot.Enabled = True
            Else
                Me.btnNERDelOne.Enabled = False
                Me.btnNERDelAll.Enabled = False
                Me.btnNERCreatLot.Enabled = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnNER_ReprintLotLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNER_ReprintLotLabel.Click
        Const strReportName As String = "Ship Pallet Label Push.rpt"
        Dim dt, dtShipPalletRpt As DataTable
        Dim strPallett_name, strResult As String
        Dim objRpt As ReportDocument
        Dim objMisc As Data.Buisness.Misc
        Dim iPallettQty As Integer = 0

        Try
            strPallett_name = "" : strResult = ""
            strPallett_name = InputBox("Enter Pallet Name:", "Pallet", "").Trim.ToUpper
            If strPallett_name = "" Then
                Exit Sub
            End If

            strResult = Microsoft.VisualBasic.Left(strPallett_name, 3)

            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            '************************************
            'Get Pallett information
            '************************************
            objMisc = New Data.Buisness.Misc()
            dt = objMisc.GetPalletInfo_ByPallettName(strPallett_name)

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Pallet name does not exist.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtSN.Focus()
                Exit Sub
            End If

            If Not IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                iPallettQty = dt.Rows(0)("Pallett_QTY")
            Else
                iPallettQty = Me._objDBRManifest.GetDevCountByPalletID(dt.Rows(0)("Pallett_ID"))
            End If

            '************************************
            'Create Crystal Report
            '************************************
            dtShipPalletRpt = Me._objDBRManifest.GetShipPalletData(strPallett_name, iPallettQty, strResult, "Fail", New String() {"NER Verification:", "Material Verification:", "Shipper Verification:"})

            If Not IsNothing(dtShipPalletRpt) Then
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & strReportName)
                    .SetDataSource(dtShipPalletRpt)
                    .PrintToPrinter(2, True, 0, 0)
                End With
            End If

            If Me.txtNER_SN.Text.Trim.Length > 0 Then Me.txtNER_SN.SelectAll()
            Me.txtNER_SN.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Reprint Manifest Label")
        Finally
            objMisc = Nothing
            Me.Enabled = True
            Me.txtSN.Focus()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''*************************************************************************
    'Private Sub tpNER_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpNER.Leave
    '    Me.txtNER_SN.Text = ""
    '    Me.lstNER_SNs.Items.Clear()
    '    Me._dtNERUnits.Rows.Clear()
    '    Me.btnNERCreatLot.Enabled = False
    '    Me.UpdateNERCount()
    'End Sub

    '*************************************************************************
    Private Sub tpNER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpNER.Enter
        Me.txtNER_SN.Text = ""
        Me.txtNER_SN.Focus()
    End Sub



#End Region

    Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        If Not Me._iMenuCustID = PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID Then
            If Me.TabControl1.SelectedTab Is Me.tpDBR Then
                TabControl1.SelectedTab = Me.tpOtherManifest
            End If
            If Me.TabControl1.SelectedTab Is Me.tpNER Then
                TabControl1.SelectedTab = Me.tpOtherManifest
            End If
        End If
    End Sub


End Class

