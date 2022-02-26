Option Explicit On 

Imports C1.Win.C1TrueDBGrid
Imports PSS.Data.Buisness

Public Class frmTest
    Inherits System.Windows.Forms.Form

    Private _objHTC As PSS.Data.Buisness.HTC
    Private _strScreenName As String = ""
    Private _iTestTypeID As Integer = 0
    Private _iDeviceID As Integer = 0
    Private _iModelID As Integer = 0
    Private _iPalletID As Integer = 0
    Private _iPalletQty As Integer = 0
    Private _iTestResult As Integer = 0
    Private _iCompletedUsrID As Integer = 0
    Private _iFinalTestUsrID As Integer = 0
    Private _dtFailCodesDetail As DataTable = Nothing

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTestType As String, ByVal strScreenName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strScreenName = strScreenName

        Me.lblTitle.Text = strScreenName & " Test"
        _objHTC = New PSS.Data.Buisness.HTC()

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
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRMA As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dbgTestResult As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblSymptom As System.Windows.Forms.Label
    Friend WithEvents pnlEMEI_Info As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chklstFailMainArea As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnPass As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlFailCodes_MainCategory As System.Windows.Forms.Panel
    Friend WithEvents chklstFailCodes As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnFail As System.Windows.Forms.Button
    Friend WithEvents pnlTestHistory As System.Windows.Forms.Panel
    Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
    Friend WithEvents lblBoxName As System.Windows.Forms.Label
    Friend WithEvents lblLastComptedTechName As System.Windows.Forms.Label
    Friend WithEvents lblLastComptedTech As System.Windows.Forms.Label
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents chkSkipBox As System.Windows.Forms.CheckBox
    Friend WithEvents rdbtn2G As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtn3G As System.Windows.Forms.RadioButton
    Friend WithEvents cboFailDetails As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblFailDetails As System.Windows.Forms.Label
    Friend WithEvents lstFailDetails As System.Windows.Forms.ListBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTest))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSku = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRMA = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSymptom = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlEMEI_Info = New System.Windows.Forms.Panel()
        Me.rdbtn3G = New System.Windows.Forms.RadioButton()
        Me.rdbtn2G = New System.Windows.Forms.RadioButton()
        Me.chkSkipBox = New System.Windows.Forms.CheckBox()
        Me.lblLastComptedTechName = New System.Windows.Forms.Label()
        Me.lblLastComptedTech = New System.Windows.Forms.Label()
        Me.txtBoxName = New System.Windows.Forms.TextBox()
        Me.lblBoxName = New System.Windows.Forms.Label()
        Me.btnFail = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPass = New System.Windows.Forms.Button()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlTestHistory = New System.Windows.Forms.Panel()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lstFailDetails = New System.Windows.Forms.ListBox()
        Me.cboFailDetails = New PSS.Gui.Controls.ComboBox()
        Me.lblFailDetails = New System.Windows.Forms.Label()
        Me.dbgTestResult = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chklstFailMainArea = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlFailCodes_MainCategory = New System.Windows.Forms.Panel()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chklstFailCodes = New System.Windows.Forms.CheckedListBox()
        Me.Panel6.SuspendLayout()
        Me.pnlEMEI_Info.SuspendLayout()
        Me.pnlTestHistory.SuspendLayout()
        CType(Me.dbgTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFailCodes_MainCategory.SuspendLayout()
        Me.pnlFailCodes.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(203, 55)
        Me.lblTitle.TabIndex = 120
        Me.lblTitle.Text = "OOBA Test"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPartNo, Me.Label5, Me.lblIMEI, Me.Label9, Me.lblSku, Me.Label6, Me.lblModel, Me.Label8, Me.lblCustomer, Me.Label4, Me.lblRMA, Me.Label1, Me.lblSymptom, Me.Label10})
        Me.Panel6.Location = New System.Drawing.Point(206, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(762, 55)
        Me.Panel6.TabIndex = 1
        '
        'lblPartNo
        '
        Me.lblPartNo.BackColor = System.Drawing.Color.White
        Me.lblPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.ForeColor = System.Drawing.Color.Black
        Me.lblPartNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPartNo.Location = New System.Drawing.Point(368, 29)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(120, 16)
        Me.lblPartNo.TabIndex = 133
        Me.lblPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(320, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "Part #:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIMEI
        '
        Me.lblIMEI.BackColor = System.Drawing.Color.White
        Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.ForeColor = System.Drawing.Color.Black
        Me.lblIMEI.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblIMEI.Location = New System.Drawing.Point(368, 3)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(120, 16)
        Me.lblIMEI.TabIndex = 131
        Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(320, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "IMEI:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSku
        '
        Me.lblSku.BackColor = System.Drawing.Color.White
        Me.lblSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSku.ForeColor = System.Drawing.Color.Black
        Me.lblSku.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSku.Location = New System.Drawing.Point(208, 29)
        Me.lblSku.Name = "lblSku"
        Me.lblSku.Size = New System.Drawing.Size(105, 16)
        Me.lblSku.TabIndex = 129
        Me.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(160, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "SKU:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModel
        '
        Me.lblModel.BackColor = System.Drawing.Color.White
        Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.Black
        Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblModel.Location = New System.Drawing.Point(208, 3)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(105, 16)
        Me.lblModel.TabIndex = 127
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(160, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "Model:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.White
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.Black
        Me.lblCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomer.Location = New System.Drawing.Point(66, 29)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(86, 16)
        Me.lblCustomer.TabIndex = 125
        Me.lblCustomer.Text = "TRACFONE"
        Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(-6, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Customer:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRMA
        '
        Me.lblRMA.BackColor = System.Drawing.Color.White
        Me.lblRMA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRMA.ForeColor = System.Drawing.Color.Black
        Me.lblRMA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRMA.Location = New System.Drawing.Point(66, 3)
        Me.lblRMA.Name = "lblRMA"
        Me.lblRMA.Size = New System.Drawing.Size(86, 16)
        Me.lblRMA.TabIndex = 123
        Me.lblRMA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(10, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "RMA:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSymptom
        '
        Me.lblSymptom.BackColor = System.Drawing.Color.White
        Me.lblSymptom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSymptom.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymptom.ForeColor = System.Drawing.Color.Red
        Me.lblSymptom.Location = New System.Drawing.Point(496, 13)
        Me.lblSymptom.Name = "lblSymptom"
        Me.lblSymptom.Size = New System.Drawing.Size(136, 32)
        Me.lblSymptom.TabIndex = 128
        Me.lblSymptom.UseMnemonic = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(496, -3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 16)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "Trouble Indicated :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pnlEMEI_Info
        '
        Me.pnlEMEI_Info.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlEMEI_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEMEI_Info.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdbtn3G, Me.rdbtn2G, Me.chkSkipBox, Me.lblLastComptedTechName, Me.lblLastComptedTech, Me.txtBoxName, Me.lblBoxName, Me.btnFail, Me.btnClear, Me.btnPass, Me.txtSN, Me.Label2})
        Me.pnlEMEI_Info.Location = New System.Drawing.Point(1, 56)
        Me.pnlEMEI_Info.Name = "pnlEMEI_Info"
        Me.pnlEMEI_Info.Size = New System.Drawing.Size(203, 320)
        Me.pnlEMEI_Info.TabIndex = 0
        '
        'rdbtn3G
        '
        Me.rdbtn3G.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtn3G.Location = New System.Drawing.Point(104, 264)
        Me.rdbtn3G.Name = "rdbtn3G"
        Me.rdbtn3G.Size = New System.Drawing.Size(48, 24)
        Me.rdbtn3G.TabIndex = 7
        Me.rdbtn3G.Text = "3G"
        Me.rdbtn3G.Visible = False
        '
        'rdbtn2G
        '
        Me.rdbtn2G.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbtn2G.Location = New System.Drawing.Point(48, 264)
        Me.rdbtn2G.Name = "rdbtn2G"
        Me.rdbtn2G.Size = New System.Drawing.Size(48, 24)
        Me.rdbtn2G.TabIndex = 6
        Me.rdbtn2G.Text = "2G"
        Me.rdbtn2G.Visible = False
        '
        'chkSkipBox
        '
        Me.chkSkipBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSkipBox.Location = New System.Drawing.Point(8, 50)
        Me.chkSkipBox.Name = "chkSkipBox"
        Me.chkSkipBox.Size = New System.Drawing.Size(184, 16)
        Me.chkSkipBox.TabIndex = 1
        Me.chkSkipBox.Text = "Skip Box"
        Me.chkSkipBox.Visible = False
        '
        'lblLastComptedTechName
        '
        Me.lblLastComptedTechName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastComptedTechName.ForeColor = System.Drawing.Color.Blue
        Me.lblLastComptedTechName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLastComptedTechName.Location = New System.Drawing.Point(7, 130)
        Me.lblLastComptedTechName.Name = "lblLastComptedTechName"
        Me.lblLastComptedTechName.Size = New System.Drawing.Size(184, 16)
        Me.lblLastComptedTechName.TabIndex = 132
        Me.lblLastComptedTechName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastComptedTech
        '
        Me.lblLastComptedTech.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastComptedTech.ForeColor = System.Drawing.Color.Blue
        Me.lblLastComptedTech.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLastComptedTech.Location = New System.Drawing.Point(8, 114)
        Me.lblLastComptedTech.Name = "lblLastComptedTech"
        Me.lblLastComptedTech.Size = New System.Drawing.Size(184, 16)
        Me.lblLastComptedTech.TabIndex = 131
        Me.lblLastComptedTech.Text = "Last Completed By Tech :"
        Me.lblLastComptedTech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxName
        '
        Me.txtBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxName.Location = New System.Drawing.Point(7, 24)
        Me.txtBoxName.MaxLength = 20
        Me.txtBoxName.Name = "txtBoxName"
        Me.txtBoxName.Size = New System.Drawing.Size(184, 22)
        Me.txtBoxName.TabIndex = 0
        Me.txtBoxName.Text = ""
        Me.txtBoxName.Visible = False
        '
        'lblBoxName
        '
        Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxName.ForeColor = System.Drawing.Color.Black
        Me.lblBoxName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBoxName.Location = New System.Drawing.Point(7, 8)
        Me.lblBoxName.Name = "lblBoxName"
        Me.lblBoxName.Size = New System.Drawing.Size(81, 16)
        Me.lblBoxName.TabIndex = 130
        Me.lblBoxName.Text = "Box Name:"
        Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBoxName.Visible = False
        '
        'btnFail
        '
        Me.btnFail.BackColor = System.Drawing.Color.Red
        Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFail.ForeColor = System.Drawing.Color.White
        Me.btnFail.Location = New System.Drawing.Point(48, 232)
        Me.btnFail.Name = "btnFail"
        Me.btnFail.Size = New System.Drawing.Size(88, 20)
        Me.btnFail.TabIndex = 5
        Me.btnFail.Text = "FAIL"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(48, 200)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 20)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        '
        'btnPass
        '
        Me.btnPass.BackColor = System.Drawing.Color.Green
        Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPass.ForeColor = System.Drawing.Color.White
        Me.btnPass.Location = New System.Drawing.Point(48, 168)
        Me.btnPass.Name = "btnPass"
        Me.btnPass.Size = New System.Drawing.Size(88, 20)
        Me.btnPass.TabIndex = 3
        Me.btnPass.Text = "PASS"
        '
        'txtSN
        '
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(8, 90)
        Me.txtSN.MaxLength = 15
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(184, 22)
        Me.txtSN.TabIndex = 2
        Me.txtSN.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(8, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "S/N:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTestHistory
        '
        Me.pnlTestHistory.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlTestHistory.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTestHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTestHistory.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRemove, Me.lstFailDetails, Me.cboFailDetails, Me.lblFailDetails, Me.dbgTestResult})
        Me.pnlTestHistory.Location = New System.Drawing.Point(1, 377)
        Me.pnlTestHistory.Name = "pnlTestHistory"
        Me.pnlTestHistory.Size = New System.Drawing.Size(967, 143)
        Me.pnlTestHistory.TabIndex = 4
        Me.pnlTestHistory.Visible = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(900, 41)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(56, 20)
        Me.btnRemove.TabIndex = 85
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.Visible = False
        '
        'lstFailDetails
        '
        Me.lstFailDetails.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstFailDetails.Location = New System.Drawing.Point(512, 45)
        Me.lstFailDetails.Name = "lstFailDetails"
        Me.lstFailDetails.Size = New System.Drawing.Size(384, 82)
        Me.lstFailDetails.TabIndex = 84
        Me.lstFailDetails.Visible = False
        '
        'cboFailDetails
        '
        Me.cboFailDetails.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.cboFailDetails.AutoComplete = True
        Me.cboFailDetails.BackColor = System.Drawing.SystemColors.Window
        Me.cboFailDetails.DropDownWidth = 300
        Me.cboFailDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFailDetails.ForeColor = System.Drawing.Color.Black
        Me.cboFailDetails.Location = New System.Drawing.Point(512, 18)
        Me.cboFailDetails.MaxDropDownItems = 30
        Me.cboFailDetails.Name = "cboFailDetails"
        Me.cboFailDetails.Size = New System.Drawing.Size(384, 21)
        Me.cboFailDetails.TabIndex = 82
        Me.cboFailDetails.Visible = False
        '
        'lblFailDetails
        '
        Me.lblFailDetails.BackColor = System.Drawing.Color.Transparent
        Me.lblFailDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFailDetails.ForeColor = System.Drawing.Color.Black
        Me.lblFailDetails.Location = New System.Drawing.Point(512, 2)
        Me.lblFailDetails.Name = "lblFailDetails"
        Me.lblFailDetails.Size = New System.Drawing.Size(80, 16)
        Me.lblFailDetails.TabIndex = 83
        Me.lblFailDetails.Text = "Fail Details:"
        Me.lblFailDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblFailDetails.Visible = False
        '
        'dbgTestResult
        '
        Me.dbgTestResult.AllowArrows = False
        Me.dbgTestResult.AllowColMove = False
        Me.dbgTestResult.AllowFilter = False
        Me.dbgTestResult.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.IndividualRows
        Me.dbgTestResult.AllowSort = False
        Me.dbgTestResult.AllowUpdate = False
        Me.dbgTestResult.AlternatingRows = True
        Me.dbgTestResult.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dbgTestResult.BackColor = System.Drawing.Color.LightSteelBlue
        Me.dbgTestResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgTestResult.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgTestResult.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgTestResult.LinesPerRow = 3
        Me.dbgTestResult.Location = New System.Drawing.Point(2, 8)
        Me.dbgTestResult.Name = "dbgTestResult"
        Me.dbgTestResult.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgTestResult.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgTestResult.PreviewInfo.ZoomFactor = 75
        Me.dbgTestResult.RowHeight = 20
        Me.dbgTestResult.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgTestResult.Size = New System.Drawing.Size(499, 120)
        Me.dbgTestResult.TabIndex = 1
        Me.dbgTestResult.Text = "C1TrueDBGrid1"
        Me.dbgTestResult.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Wrap:True;Font:Microsoft " & _
        "Sans Serif, 6.75pt, style=Bold;AlignHorz:Near;Trimming:Character;BackColor:Wheat" & _
        ";ForegroundImagePos:LeftOfText;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
        "ight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
        "FilterBar{ForeColor:Red;BackColor:White;}Footer{Font:Microsoft Sans Serif, 8.25p" & _
        "t, style=Bold;}Caption{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:C" & _
        "enter;BackColor:SlateGray;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
        "Color:LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}" & _
        "Style12{}OddRow{Wrap:True;Font:Microsoft Sans Serif, 6.75pt, style=Bold;AlignHor" & _
        "z:Near;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Font:Micros" & _
        "oft Sans Serif, 8.25pt, style=Bold;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
        "reColor:White;BackColor:SteelBlue;}Style8{}Style10{AlignHorz:Near;}Style11{}Styl" & _
        "e14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBa" & _
        "rHeight=""10"" AllowColMove=""False"" Name="""" AllowRowSizing=""IndividualRows"" Altern" & _
        "atingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHei" & _
        "ght=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth" & _
        "=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>116</Height><Cap" & _
        "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
        """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
        "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
        "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
        "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
        """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
        "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
        "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 495, 116</ClientRect><Bo" & _
        "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
        "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
        "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
        " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
        "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
        "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
        "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
        "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
        "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
        "16</DefaultRecSelWidth><ClientArea>0, 0, 495, 116</ClientArea><PrintPageHeaderSt" & _
        "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
        "ob>"
        '
        'chklstFailMainArea
        '
        Me.chklstFailMainArea.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.chklstFailMainArea.Location = New System.Drawing.Point(2, 24)
        Me.chklstFailMainArea.Name = "chklstFailMainArea"
        Me.chklstFailMainArea.Size = New System.Drawing.Size(288, 274)
        Me.chklstFailMainArea.TabIndex = 121
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(10, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 16)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Fail Area:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlFailCodes_MainCategory
        '
        Me.pnlFailCodes_MainCategory.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes_MainCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes_MainCategory.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.chklstFailMainArea})
        Me.pnlFailCodes_MainCategory.Location = New System.Drawing.Point(206, 56)
        Me.pnlFailCodes_MainCategory.Name = "pnlFailCodes_MainCategory"
        Me.pnlFailCodes_MainCategory.Size = New System.Drawing.Size(297, 320)
        Me.pnlFailCodes_MainCategory.TabIndex = 1
        Me.pnlFailCodes_MainCategory.Visible = False
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.chklstFailCodes})
        Me.pnlFailCodes.Location = New System.Drawing.Point(504, 56)
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(464, 320)
        Me.pnlFailCodes.TabIndex = 2
        Me.pnlFailCodes.Visible = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(6, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 16)
        Me.Label7.TabIndex = 123
        Me.Label7.Text = "Fail Codes:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chklstFailCodes
        '
        Me.chklstFailCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.chklstFailCodes.Location = New System.Drawing.Point(6, 24)
        Me.chklstFailCodes.Name = "chklstFailCodes"
        Me.chklstFailCodes.Size = New System.Drawing.Size(450, 274)
        Me.chklstFailCodes.TabIndex = 121
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(976, 533)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlFailCodes_MainCategory, Me.pnlEMEI_Info, Me.Panel6, Me.lblTitle, Me.pnlTestHistory, Me.pnlFailCodes})
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.Panel6.ResumeLayout(False)
        Me.pnlEMEI_Info.ResumeLayout(False)
        Me.pnlTestHistory.ResumeLayout(False)
        CType(Me.dbgTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFailCodes_MainCategory.ResumeLayout(False)
        Me.pnlFailCodes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            If _strScreenName = "OOBA" Then
                Me.lblBoxName.Visible = True
                Me.txtBoxName.Visible = True
                Me.chkSkipBox.Visible = True
                Me.txtBoxName.Focus()
            End If

            _iTestTypeID = Me._objHTC.GetTestTypeID(Me._strScreenName)
            If Me._iTestTypeID = 0 Then
                MessageBox.Show("System can't identify test type ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'PSS.Gui.MainWin.WorkArea.TabPages.RemoveAt(PSS.Gui.MainWin.wrkArea.SelectedIndex)
                Me.Close()
            End If

            Me.PopulateFailCodesMainCategories()
            Me.PopulateTestFailCodesDetail()

            Generic.DisposeDT(Me._dtFailCodesDetail)
            Me._dtFailCodesDetail = New DataTable()
            Generic.AddNewColumnToDataTable(Me._dtFailCodesDetail, "Dcode_id", "System.Int32", "0")
            Generic.AddNewColumnToDataTable(Me._dtFailCodesDetail, "Desc", "System.String", "")

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Me._strScreenName.Trim.ToUpper = "OOBA" Then Me.txtBoxName.Focus() Else Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateFailCodesMainCategories()
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetFailcodesMainCategories(False)
            With Me.chklstFailMainArea
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "MC_Desc"
                .ValueMember = "MC_ID"
                .ItemHeight = 150
            End With

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim dtDevice As DataTable
        Dim dtRepStatus As DataTable
        Dim i As Integer = 0

        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me._iDeviceID = 0
                    Me._iModelID = 0
                    Me.pnlFailCodes_MainCategory.Visible = False
                    Me.pnlFailCodes.Visible = False
                    Me.pnlTestHistory.Visible = False
                    Me.lblLastComptedTech.Visible = False
                    Me.lblLastComptedTechName.Visible = False

                    If Me._strScreenName.Trim.ToUpper = "OOBA" And Me.chkSkipBox.Checked = False And Me._iPalletID = 0 Then
                        MessageBox.Show("Please scan box name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.Text = ""
                        Me.txtBoxName.SelectAll()
                        Exit Sub
                    End If

                    dtDevice = Me._objHTC.GetHTC_thtcdataInfo_InWIP(Me.txtSN.Text.Trim)
                    If dtDevice.Rows.Count > 0 Then
                        '********************************
                        'Check if device is discrepancy
                        '********************************
                        If dtDevice.Rows(0)("DiscUnit") = 1 Then
                            MessageBox.Show("S/N is a discrepant unit(" & dtDevice.Rows(0)("Discrepancy Reason") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll()
                        ElseIf (Me._strScreenName.Trim.ToUpper = "OOBA" And Me.chkSkipBox.Checked = False And dtDevice.Rows(0)("hd_Station").ToString.ToUpper <> "SHIPPING") Or (Me._strScreenName.Trim.ToUpper <> "OOBA" And dtDevice.Rows(0)("hd_Station") <> Me._strScreenName) Then
                            If MessageBox.Show("This Device is at " & dtDevice.Rows(0)("hd_Station") & "." & Environment.NewLine & "Would you like to view the history of this unit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Me.PopulateTestHistory(dtDevice.Rows(0)("Device_ID"), 0)
                            End If
                            Me.txtSN.Text = ""
                            Me.txtSN.Focus()
                        ElseIf Me._strScreenName.Trim.ToUpper = "OOBA" And Me.chkSkipBox.Checked = False Then
                            If IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                                MessageBox.Show("This device does not belong to any box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            ElseIf Me._iPalletID <> dtDevice.Rows(0)("Pallett_ID") Then
                                MessageBox.Show("This device does not belong to box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            End If
                        Else
                            '****************************
                            'Check if device is RUR
                            '****************************
                            dtRepStatus = Me._objHTC.CheckDeviceRepairStatus(dtDevice.Rows(0)("Device_ID"))
                            If dtRepStatus.Rows.Count = 0 Then
                                MessageBox.Show("This unit has no billcode bill to it please verify it with Billing Auditor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            ElseIf dtRepStatus.Rows.Count > 0 AndAlso dtRepStatus.Rows(0)("BillCode_Rule") = 1 Then
                                MessageBox.Show("This is an RUR unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            ElseIf CheckTestCriteria(dtDevice.Rows(0)("Device_ID")) = False Then
                                Me.txtSN.SelectAll()
                                Exit Sub
                            Else
                                Me._iDeviceID = dtDevice.Rows(0)("Device_ID")
                                Me._iModelID = dtDevice.Rows(0)("Model_ID")
                                Me._iCompletedUsrID = dtDevice.Rows(0)("LastCompleted_TechUsrID")

                                Me.lblRMA.Text = dtDevice.Rows(0)("hd_RMA")
                                'Me.lblCustomer.Text = dtDevice.Rows(0)("hd_Station")
                                Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                                Me.lblSku.Text = dtDevice.Rows(0)("Sku_Number")
                                'Me.lblSN.Text = dtDevice.Rows(0)("hd_SN")
                                Me.lblIMEI.Text = dtDevice.Rows(0)("Label_IMEI")
                                Me.lblPartNo.Text = dtDevice.Rows(0)("hd_PartNo")
                                Me.lblSymptom.Text = dtDevice.Rows(0)("hd_Symptom")
                                Me.lblLastComptedTech.Visible = True
                                Me.lblLastComptedTechName.Visible = True
                                Me.lblLastComptedTechName.Text = dtDevice.Rows(0)("LastCompletedUser")

                                Me.PopulateTestHistory(Me._iDeviceID, 0)
                            End If
                        End If
                    Else
                        MessageBox.Show("S/N either does not exist, belongs to a different customer or already been ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dtDevice)
            PSS.Data.Buisness.Generic.DisposeDT(dtRepStatus)
        End Try
    End Sub

    '******************************************************************
    Private Function CheckTestCriteria(ByVal iDeviceID As Integer) As Boolean
        Dim booResult As Boolean = True
        Dim strTechName As String = ""
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetTestStationHistory(iDeviceID, )
            If Me._strScreenName.Trim.ToUpper = "RF" Then
                If Me._objHTC.IsCompletedByTechnician(iDeviceID, strTechName) = False Then
                    MessageBox.Show("This device has not yet completed by technician " & strTechName & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf dt.Rows.Count > 0 AndAlso dt.Rows(0)("Reject") = 0 AndAlso dt.Rows(0)("Test_ID") = Me._iTestTypeID Then
                    MessageBox.Show("Device is already " & dt.Rows(0)("Result") & " at RF test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            ElseIf Me._strScreenName.Trim.ToUpper = "FINAL" Then
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device has not been to RF test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 AndAlso dt.Rows(0)("Test_ID") = PSS.Data.Buisness.HTC.TEST_TYPE_ID.RF AndAlso dt.Rows(0)("Result") = "FAIL" Then
                        MessageBox.Show("Device is failed at RF test please send it to repair.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 AndAlso dt.Rows(0)("Reject") = 0 AndAlso dt.Rows(0)("Test_ID") = Me._iTestTypeID AndAlso dt.Rows(0)("Result") = "FAIL" Then
                        MessageBox.Show("Device is already fail at FINAL test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 AndAlso dt.Rows(0)("Reject") = 0 AndAlso dt.Rows(0)("Test_ID") = Me._iTestTypeID Then
                        MessageBox.Show("Device is already " & dt.Rows(0)("Result") & " at FINAL test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
            ElseIf Me._strScreenName.Trim.ToUpper = "OOBA" Then
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Device has not been to any test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 AndAlso dt.Rows(0)("Test_ID") = PSS.Data.Buisness.HTC.TEST_TYPE_ID.RF AndAlso dt.Rows(0)("Result").ToString = "FAIL" Then
                        MessageBox.Show("Device is failed at RF test please send it to repair.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 And dt.Rows(0)("Test_ID") = PSS.Data.Buisness.HTC.TEST_TYPE_ID.FINAL AndAlso dt.Rows(0)("Result").ToString = "FAIL" Then
                        MessageBox.Show("Device is failed at FINAL test please send it to repair.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 AndAlso dt.Rows(0)("Test_ID") = Me._iTestTypeID Then
                        MessageBox.Show("Device is already OOBA " & dt.Rows(0)("Result") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    ElseIf dt.Rows.Count > 0 And dt.Rows(0)("Test_ID") <> PSS.Data.Buisness.HTC.TEST_TYPE_ID.FINAL Then
                        MessageBox.Show("Device has not been to final test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    Else
                        Me._iFinalTestUsrID = dt.Rows(0)("TD_UsrID")
                    End If
                End If

                ''*****************************************************************
                ''show the last technician who push completed button on tech screen
                ''*****************************************************************
                'If strTechName.Trim.Length > 0 Then
                '    Me.lblLastComptedTech.Visible = True
                '    Me.lblLastComptedTechName.Text = strTechName
                'End If

                Return booResult
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Function

    '******************************************************************
    Private Sub PopulateTestHistory(ByVal iDeviceID As Integer, Optional ByVal iTestTypeID As Integer = 0)
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim R1 As DataRow

        Try
            dt = Me._objHTC.GetTestStationHistory(iDeviceID, iTestTypeID)
            With Me.dbgTestResult
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Visible = True
                .RowHeight = 15

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                .Columns("Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                .Splits(0).DisplayColumns("Station").Width = 60
                .Splits(0).DisplayColumns("Result").Width = 45
                .Splits(0).DisplayColumns("FailDetails").Width = 100
                .Splits(0).DisplayColumns("Inspector").Width = 80
                .Splits(0).DisplayColumns("Tech").Width = 80
                .Splits(0).DisplayColumns("FinalTester").Width = 80
                .Splits(0).DisplayColumns("Date").Width = 95
                .Splits(0).DisplayColumns("Seq").Width = 40

                .Splits(0).DisplayColumns("Device_ID").Visible = False
                .Splits(0).DisplayColumns("TD_ID").Visible = False
                .Splits(0).DisplayColumns("Test_ID").Visible = False
                .Splits(0).DisplayColumns("QCResult_ID").Visible = False
                .Splits(0).DisplayColumns("Reject").Visible = False
                .Splits(0).DisplayColumns("TD_UsrID").Visible = False

                '.Splits(0).DisplayColumns("Date").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                '.Splits(0).DisplayColumns("Result").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                Me.pnlTestHistory.Visible = True
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailMainArea_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstFailMainArea.ItemCheck
        Try
            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me._strScreenName.Trim.ToUpper = "OOBA" And Me.chkSkipBox.Checked = False And Me._iPalletID = 0 Then
                Exit Sub
            ElseIf Me._iDeviceID = 0 Then
                MessageBox.Show("Device ID is missing. Please scan S/N again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf e.NewValue = CheckState.Checked Then
                Me.PopulateFailCodes(Me.chklstFailMainArea.SelectedItem("MC_ID"))
            ElseIf e.NewValue = CheckState.Unchecked Then
                ''do nothing
            End If
            e.NewValue = CheckState.Unchecked
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailMainArea_ItemCheck", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailMainArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstFailMainArea.SelectedIndexChanged
        Try
            Me.PopulateFailCodes(Me.chklstFailMainArea.SelectedItem("MC_ID"))
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailCodes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateFailCodes(ByVal iFailcodeMainCategoryID As Integer)
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetFailCodes(2, Me._iModelID, , iFailcodeMainCategoryID)
            With Me.chklstFailCodes
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "Fail_LDesc"
                .ValueMember = "Fail_ID"
                .ItemHeight = 150
                .Visible = True
                .Tag = iFailcodeMainCategoryID
                '*****************************************
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailCodes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstFailCodes.ItemCheck
        Dim i As Integer = 0
        Dim strFailDetail As String = ""

        Try
            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me._iDeviceID = 0 Then
                MessageBox.Show("Device ID is missing. Please scan S/N again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._strScreenName = "RF" And Me.rdbtn2G.Checked = False And Me.rdbtn3G.Checked = False Then
                MessageBox.Show("Please select either 2G or 3G fail.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._strScreenName <> "RF" And Me._dtFailCodesDetail.Rows.Count = 0 Then
                MessageBox.Show("You must select at least one fail code detail.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboFailDetails.Focus()
            ElseIf e.NewValue = CheckState.Checked Then
                '***************************************
                If Me._strScreenName = "RF" Then
                    If Me.rdbtn2G.Checked = True Then
                        strFailDetail = "2G"
                    Else
                        strFailDetail = "3G"
                    End If
                End If

                '***************************************
                'Write fail result and fail information
                '***************************************
                i = Me._objHTC.WriteTestResultFailData(Me._iDeviceID, Me.chklstFailCodes.Tag, Me.chklstFailCodes.SelectedItem("Fail_ID"), Me._iTestTypeID, Me._iTestResult, PSS.Core.Global.ApplicationUser.IDuser, Me._iCompletedUsrID, Me._strScreenName, Me._dtFailCodesDetail, Me._iPalletID, Me.txtBoxName.Text, _iPalletQty, strFailDetail, Me._iFinalTestUsrID)
                If i = 0 Then
                    MessageBox.Show("System failed to write fail data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me._iPalletID > 0 Then
                        MessageBox.Show("All units have been removed from box ID. Please send the fail unit to REPAIR station technician " & Me.lblLastComptedTechName.Text.Trim.ToUpper & " and the rest of the box will go back to FINAL station for retest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Please send the fail unit to REPAIR station technician " & Me.lblLastComptedTechName.Text.Trim.ToUpper & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    Me.Enabled = False

                    Me._iPalletID = 0
                    Me._iPalletQty = 0
                    Me.txtBoxName.Text = ""

                    Me.pnlTestHistory.Visible = False
                    Me.dbgTestResult.DataSource = Nothing
                    ClearGlobalVarAndCtrls()
                    Me.Enabled = True

                    If Me._strScreenName.Trim.ToUpper = "OOBA" Then Me.txtBoxName.Focus() Else Me.txtSN.Focus()
                End If

            ElseIf e.NewValue = CheckState.Unchecked Then
                'nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailCodes_ItemCheck", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            e.NewValue = CheckState.Unchecked
        End Try
    End Sub

    '******************************************************************
    Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
        Dim strNextWrkStation As String = ""
        Dim i As Integer = 0

        Try
            If Me._iDeviceID = 0 Then
                Me.txtSN.SelectAll()
                Exit Sub
            Else
                Me._iTestResult = 1

                '****************************
                'Get next workstation
                '****************************
                If Me._strScreenName.Trim.ToUpper <> "OOBA" Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, Me._iModelID, Me._objHTC.HTC_CUSTOMER_ID, )
                    If strNextWrkStation.Trim.Length = 0 Then
                        MessageBox.Show("Can not find the next workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                '****************************
                'Write pass result
                '****************************
                i = Me._objHTC.WriteTestResult(Me._iDeviceID, Me._iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, Me._iCompletedUsrID, Me._iTestResult, , , , , , Me._iFinalTestUsrID)
                If i = 0 Then
                    MessageBox.Show("System failed to write test result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '***********************************************************
                'move unit to next workstation test function is not OOBA
                '***********************************************************
                If Me._strScreenName.Trim.ToUpper <> "OOBA" Then
                    i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation)
                    If i > 0 Then
                        'Me.lblNextStation.Text = "Device has moved to " & strNextWrkStation.ToUpper
                        MessageBox.Show("Device has moved to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System failed to move unit to " & strNextWrkStation, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                '********************************
                'refresh test history
                '********************************
                Me.PopulateTestHistory(Me._iDeviceID, 0)
                Me.ClearGlobalVarAndCtrls()
                '********************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnPass_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me._iPalletID = 0
        Me._iPalletQty = 0
        Me.txtBoxName.Text = ""
        Me.txtSN.Text = ""
        Me.lblLastComptedTech.Visible = False
        Me.lblLastComptedTechName.Text = ""

        Me.pnlTestHistory.Visible = False
        Me.dbgTestResult.DataSource = Nothing
        ClearGlobalVarAndCtrls()
        If Me._strScreenName.Trim.ToUpper = "OOBA" Then Me.txtBoxName.Focus() Else Me.txtSN.Focus()
    End Sub

    '******************************************************************
    Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
        Try
            If Me._iDeviceID = 0 Then
                Exit Sub
            ElseIf Me._strScreenName = "OOBA" And Me.chkSkipBox.Checked = False Then
                If MessageBox.Show("This action will release all devices in this box and send back to FINAL test for re-test." & Environment.NewLine & "Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            Me._iTestResult = 2

            If Me._strScreenName = "RF" Then
                Me.rdbtn2G.Visible = True
                Me.rdbtn3G.Visible = True
            Else
                Me.pnlFailCodes_MainCategory.Visible = True
                Me.pnlFailCodes.Visible = True
                Me.lblFailDetails.Visible = True
                Me.cboFailDetails.Visible = True
                Me.lstFailDetails.Visible = True
                Me.btnRemove.Visible = True
                Me.cboFailDetails.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnFail_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub ClearGlobalVarAndCtrls()
        Me._iTestResult = 0
        Me._iDeviceID = 0
        Me._iModelID = 0
        Me._iCompletedUsrID = 0
        Me._iFinalTestUsrID = 0

        Me.lblRMA.Text = ""
        'Me.lblCustomer.Text = ""
        Me.lblModel.Text = ""
        Me.lblSku.Text = ""
        Me.lblIMEI.Text = ""
        Me.lblPartNo.Text = ""
        Me.lblSymptom.Text = ""
        Me.chkSkipBox.Checked = False
        Me.rdbtn2G.Visible = False
        Me.rdbtn3G.Visible = False
        Me.rdbtn2G.Checked = False
        Me.rdbtn3G.Checked = False
        Me.lblFailDetails.Visible = False
        Me.cboFailDetails.Visible = False
        Me.lstFailDetails.Visible = False
        Me.btnRemove.Visible = False

        Me.pnlFailCodes_MainCategory.Visible = False
        Me.pnlFailCodes.Visible = False
        Me.chklstFailCodes.DataSource = Nothing
        Me.pnlFailCodes.Tag = 0

        Me._dtFailCodesDetail.Clear()
        Me.lstFailDetails.DataSource = Nothing
        Me.cboFailDetails.SelectedValue = 0

        Me.txtSN.Text = ""
        Me.txtSN.Focus()
    End Sub

    '******************************************************************
    Private Sub txtBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
        Dim dt As DataTable

        Try
            If e.KeyValue <> 13 Then Exit Sub
            If Me.txtBoxName.Text = "" Then Exit Sub

            Me._iPalletID = 0
            Me._iPalletQty = 0

            dt = Me._objHTC.GetPalletByName(Me.txtBoxName.Text.Trim.ToUpper)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Box Number does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows.Count > 1 Then
                MessageBox.Show("Box Number exist more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf IsDBNull(dt.Rows(0)("Cust_ID")) Or dt.Rows(0)("Cust_ID") <> PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID Then
                MessageBox.Show("Box Number does not belongs to HTC customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallet_ShipType") > 0 Then
                MessageBox.Show("This is an RUR box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf IsDBNull(dt.Rows(0)("Pallett_QTY")) Then
                MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf dt.Rows(0)("Pallett_QTY") = 0 Then
                MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                MessageBox.Show("Box is already shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me._iPalletID = dt.Rows(0)("Pallett_ID")
                Me._iPalletQty = dt.Rows(0)("Pallett_QTY")
                Me.txtSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub chkSkipBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSkipBox.CheckedChanged
        Me.txtBoxName.Text = ""
        If Me.chkSkipBox.Checked = True Then
            Me.txtBoxName.Visible = False
            Me.lblBoxName.Visible = False
            Me.txtSN.Focus()
        Else
            Me.txtBoxName.Visible = True
            Me.lblBoxName.Visible = True
            If Me._strScreenName.ToUpper = "OOBA" Then
                Me.txtBoxName.Focus()
            Else
                Me.txtSN.Focus()
            End If
        End If
    End Sub

    '******************************************************************
    Private Sub rdbtn2G_rdbtn3G_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbtn2G.CheckedChanged, rdbtn3G.CheckedChanged
        If sender.checked = True Then
            SetVisiblePanelFailCodes(True)
        End If
    End Sub

    '******************************************************************
    Private Sub SetVisiblePanelFailCodes(ByVal booVisibleVal As Boolean)
        Me.pnlFailCodes_MainCategory.Visible = booVisibleVal
        Me.pnlFailCodes.Visible = booVisibleVal
    End Sub

    '******************************************************************
    Public Sub PopulateTestFailCodesDetail()
        Dim dt As DataTable
        Try
            dt = Me._objHTC.GetTestFailCodes()
            With Me.cboFailDetails
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Desc").ToString
                .ValueMember = dt.Columns("Dcode_id").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboFailDetails_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFailDetails.KeyUp
        Dim i As Integer = 0

        Try
            If e.KeyValue = 13 Then
                If Me.cboFailDetails.Text.StartsWith("--Select--") = False Then
                    For i = 0 To Me.cboFailDetails.Items.Count - 1
                        If Me.cboFailDetails.Text.Trim = Me.cboFailDetails.Items.Item(i)("Desc").ToString.Trim Then
                            Me.cboFailDetails.SelectedValue = Me.cboFailDetails.Items.Item(i)("Dcode_id")
                            Me.AddFailCodesDetail(Me.cboFailDetails.SelectedValue, Me.cboFailDetails.Text)
                            Me.cboFailDetails.SelectAll()
                            Exit Sub
                        End If
                    Next i
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboFailDetails_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    ''******************************************************************
    'Private Sub cboFailDetails_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFailDetails.SelectionChangeCommitted
    '    Try
    '        Me.AddFailCodesDetail(Me.cboFailDetails.SelectedValue, Me.cboFailDetails.Text)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "cboFailDetails_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub

    '******************************************************************
    Private Function AddFailCodesDetail(ByVal iDcodeID As Integer, ByVal strDesc As String) As Integer
        Dim R1 As DataRow
        Try
            If Me.cboFailDetails.SelectedValue = 0 Then Exit Function
            If Me._dtFailCodesDetail.Select("Dcode_id = " & iDcodeID).Length > 0 Then
                MessageBox.Show("Fail is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Else
                R1 = Me._dtFailCodesDetail.NewRow
                R1("Dcode_id") = iDcodeID
                R1("Desc") = strDesc
                Me._dtFailCodesDetail.Rows.Add(R1)
                Me._dtFailCodesDetail.AcceptChanges()

                With Me.lstFailDetails
                    .DisplayMember = Me._dtFailCodesDetail.Columns("Desc").ColumnName
                    .ValueMember = Me._dtFailCodesDetail.Columns("Dcode_id").ColumnName
                    .DataSource = Me._dtFailCodesDetail.DefaultView
                End With
            End If
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
        End Try
    End Function

    '******************************************************************
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim R1 As DataRow
        Try
            If Me._dtFailCodesDetail.Rows.Count = 0 Then Exit Sub
            If Me.lstFailDetails.SelectedIndex < 0 Then Exit Sub

            For Each R1 In Me._dtFailCodesDetail.Rows
                If R1("Dcode_id") = Me.lstFailDetails.Items.Item(Me.lstFailDetails.SelectedIndex)("Dcode_id") Then
                    Me._dtFailCodesDetail.Rows.Remove(R1)
                    Exit For
                End If
            Next

            Me._dtFailCodesDetail.AcceptChanges()

            With Me.lstFailDetails
                .DisplayMember = Me._dtFailCodesDetail.Columns("Desc").ColumnName
                .ValueMember = Me._dtFailCodesDetail.Columns("Dcode_id").ColumnName
                .DataSource = Me._dtFailCodesDetail.DefaultView
            End With

            Me.cboFailDetails.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
        End Try
    End Sub

    '******************************************************************

    '******************************************************************

End Class
