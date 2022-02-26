Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmBillingAuditAndPartsReclaim
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC
    Private _strScreenName As String = ""
    Private _iDeviceID As Integer = 0
    Private _iModelID As Integer = 0
    Private _strLastCompletedTechName As String = ""
    Private _iLastCompletedTechID As Integer = 0
    Private _iRejectDevice As Integer = 0
    Private _iTestTypeID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strScreenName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objHTC = New HTC()
        Me._strScreenName = strScreenName.Trim.ToUpper
        Me.lblTitle.Text = strScreenName
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
    Friend WithEvents pnlEMEI_Info As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRMA As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSymptom As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnReclaimParts As System.Windows.Forms.Button
    Friend WithEvents pnlBillingData As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents dbgBillingData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnFail As System.Windows.Forms.Button
    Friend WithEvents btnPass As System.Windows.Forms.Button
    Friend WithEvents lblLastCompletedTechName As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents btnChangeLastDigitOfPN As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBillingAuditAndPartsReclaim))
        Me.pnlEMEI_Info = New System.Windows.Forms.Panel()
        Me.btnChangeLastDigitOfPN = New System.Windows.Forms.Button()
        Me.btnPass = New System.Windows.Forms.Button()
        Me.btnFail = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnReclaimParts = New System.Windows.Forms.Button()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlBillingData = New System.Windows.Forms.Panel()
        Me.lblLastCompletedTechName = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dbgBillingData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlEMEI_Info.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlBillingData.SuspendLayout()
        CType(Me.dbgBillingData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEMEI_Info
        '
        Me.pnlEMEI_Info.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlEMEI_Info.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlEMEI_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEMEI_Info.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnChangeLastDigitOfPN, Me.btnPass, Me.btnFail, Me.btnClear, Me.btnReclaimParts, Me.txtSN, Me.Label2})
        Me.pnlEMEI_Info.Location = New System.Drawing.Point(1, 57)
        Me.pnlEMEI_Info.Name = "pnlEMEI_Info"
        Me.pnlEMEI_Info.Size = New System.Drawing.Size(951, 44)
        Me.pnlEMEI_Info.TabIndex = 122
        '
        'btnChangeLastDigitOfPN
        '
        Me.btnChangeLastDigitOfPN.BackColor = System.Drawing.Color.Teal
        Me.btnChangeLastDigitOfPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeLastDigitOfPN.ForeColor = System.Drawing.Color.White
        Me.btnChangeLastDigitOfPN.Location = New System.Drawing.Point(672, 10)
        Me.btnChangeLastDigitOfPN.Name = "btnChangeLastDigitOfPN"
        Me.btnChangeLastDigitOfPN.Size = New System.Drawing.Size(176, 20)
        Me.btnChangeLastDigitOfPN.TabIndex = 130
        Me.btnChangeLastDigitOfPN.Text = "Change Last Digit of P/N"
        Me.btnChangeLastDigitOfPN.Visible = False
        '
        'btnPass
        '
        Me.btnPass.BackColor = System.Drawing.Color.Green
        Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPass.ForeColor = System.Drawing.Color.White
        Me.btnPass.Location = New System.Drawing.Point(512, 10)
        Me.btnPass.Name = "btnPass"
        Me.btnPass.Size = New System.Drawing.Size(104, 20)
        Me.btnPass.TabIndex = 129
        Me.btnPass.Text = "Pass"
        Me.btnPass.Visible = False
        '
        'btnFail
        '
        Me.btnFail.BackColor = System.Drawing.Color.Red
        Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFail.ForeColor = System.Drawing.Color.White
        Me.btnFail.Location = New System.Drawing.Point(304, 10)
        Me.btnFail.Name = "btnFail"
        Me.btnFail.Size = New System.Drawing.Size(104, 20)
        Me.btnFail.TabIndex = 128
        Me.btnFail.Text = "Fail"
        Me.btnFail.Visible = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(880, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(56, 20)
        Me.btnClear.TabIndex = 127
        Me.btnClear.Text = "Clear"
        '
        'btnReclaimParts
        '
        Me.btnReclaimParts.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnReclaimParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReclaimParts.ForeColor = System.Drawing.Color.White
        Me.btnReclaimParts.Location = New System.Drawing.Point(304, 10)
        Me.btnReclaimParts.Name = "btnReclaimParts"
        Me.btnReclaimParts.Size = New System.Drawing.Size(208, 20)
        Me.btnReclaimParts.TabIndex = 125
        Me.btnReclaimParts.Text = "Part Reclaim Complete"
        Me.btnReclaimParts.Visible = False
        '
        'txtSN
        '
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(40, 9)
        Me.txtSN.MaxLength = 15
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(184, 22)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(9, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 16)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "S/N:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel6
        '
        Me.Panel6.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPartNo, Me.Label5, Me.lblIMEI, Me.Label9, Me.lblSku, Me.Label6, Me.lblModel, Me.Label8, Me.lblCustomer, Me.Label4, Me.lblRMA, Me.Label1, Me.lblSymptom, Me.Label10})
        Me.Panel6.Location = New System.Drawing.Point(305, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(647, 55)
        Me.Panel6.TabIndex = 121
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
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(1, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(303, 55)
        Me.lblTitle.TabIndex = 124
        Me.lblTitle.Text = "Reclaim Parts"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBillingData
        '
        Me.pnlBillingData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlBillingData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBillingData.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLastCompletedTechName, Me.btnDelete, Me.dbgBillingData})
        Me.pnlBillingData.Location = New System.Drawing.Point(1, 102)
        Me.pnlBillingData.Name = "pnlBillingData"
        Me.pnlBillingData.Size = New System.Drawing.Size(952, 223)
        Me.pnlBillingData.TabIndex = 123
        Me.pnlBillingData.Visible = False
        '
        'lblLastCompletedTechName
        '
        Me.lblLastCompletedTechName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastCompletedTechName.ForeColor = System.Drawing.Color.Orange
        Me.lblLastCompletedTechName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblLastCompletedTechName.Location = New System.Drawing.Point(656, 5)
        Me.lblLastCompletedTechName.Name = "lblLastCompletedTechName"
        Me.lblLastCompletedTechName.Size = New System.Drawing.Size(280, 16)
        Me.lblLastCompletedTechName.TabIndex = 123
        Me.lblLastCompletedTechName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Red
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(8, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 20)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.Visible = False
        '
        'dbgBillingData
        '
        Me.dbgBillingData.AllowArrows = False
        Me.dbgBillingData.AllowColMove = False
        Me.dbgBillingData.AllowFilter = False
        Me.dbgBillingData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.IndividualRows
        Me.dbgBillingData.AllowUpdate = False
        Me.dbgBillingData.AlternatingRows = True
        Me.dbgBillingData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgBillingData.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgBillingData.Caption = "Billing Data"
        Me.dbgBillingData.FetchRowStyles = True
        Me.dbgBillingData.FilterBar = True
        Me.dbgBillingData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgBillingData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgBillingData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgBillingData.LinesPerRow = 3
        Me.dbgBillingData.Location = New System.Drawing.Point(8, 24)
        Me.dbgBillingData.Name = "dbgBillingData"
        Me.dbgBillingData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgBillingData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgBillingData.PreviewInfo.ZoomFactor = 75
        Me.dbgBillingData.RowHeight = 35
        Me.dbgBillingData.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgBillingData.Size = New System.Drawing.Size(936, 179)
        Me.dbgBillingData.TabIndex = 1
        Me.dbgBillingData.Text = "C1TrueDBGrid1"
        Me.dbgBillingData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
        "ght=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" " & _
        "RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalS" & _
        "crollGroup=""1""><Height>158</Height><CaptionStyle parent=""Style2"" me=""Style10"" />" & _
        "<EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""St" & _
        "yle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""F" & _
        "ooter"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle par" & _
        "ent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7""" & _
        " /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" m" & _
        "e=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Select" & _
        "edStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Cl" & _
        "ientRect>0, 17, 932, 158</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunk" & _
        "en</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
        "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
        "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
        "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
        "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
        "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
        "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
        "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
        "Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0," & _
        " 932, 175</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageF" & _
        "ooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'frmBillingAuditAndPartsReclaim
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(960, 405)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlEMEI_Info, Me.Panel6, Me.lblTitle, Me.pnlBillingData})
        Me.Name = "frmBillingAuditAndPartsReclaim"
        Me.Text = "frmBillingAuditAndPartsReclaim"
        Me.pnlEMEI_Info.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.pnlBillingData.ResumeLayout(False)
        CType(Me.dbgBillingData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

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
                    Me._strLastCompletedTechName = ""
                    Me._iLastCompletedTechID = 0
                    Me._iRejectDevice = 0
                    Me.pnlBillingData.Visible = False

                    dtDevice = Me._objHTC.GetHTC_thtcdataInfo_InWIP(Me.txtSN.Text.Trim)
                    If dtDevice.Rows.Count > 0 Then
                        '********************************
                        'Check if device is discrepancy
                        '********************************
                        If dtDevice.Rows(0)("DiscUnit") = 1 Then
                            MessageBox.Show("S/N is a discrepant unit(" & dtDevice.Rows(0)("Discrepancy Reason") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll()
                        ElseIf dtDevice.Rows(0)("hd_Station").ToString.ToUpper <> Me._strScreenName.Trim.ToUpper Then
                            MessageBox.Show("This Device is at " & dtDevice.Rows(0)("hd_Station") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.Text = ""
                            Me.txtSN.Focus()
                            Exit Sub
                        Else
                            '****************************
                            'Check if device is RUR
                            '****************************
                            dtRepStatus = Me._objHTC.CheckDeviceRepairStatus(dtDevice.Rows(0)("Device_ID"))

                            If Me._strScreenName.Trim.ToUpper = "RECLAIM PARTS" And (dtRepStatus.Rows.Count > 0 AndAlso dtRepStatus.Rows(0)("BillCode_Rule") <> 1) Then
                                MessageBox.Show("This is not an RUR unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            ElseIf Me._strScreenName.Trim.ToUpper = "RECLAIM PARTS" And dtRepStatus.Rows.Count = 0 Then
                                MessageBox.Show("This unit has no part to reclaim.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            Else
                                Me._iDeviceID = dtDevice.Rows(0)("Device_ID")
                                Me._iModelID = dtDevice.Rows(0)("Model_ID")
                                Me._strLastCompletedTechName = dtDevice.Rows(0)("LastCompletedUser")
                                Me._iLastCompletedTechID = dtDevice.Rows(0)("LastCompleted_TechUsrID")
                                Me._iRejectDevice = dtDevice.Rows(0)("Reject")

                                Me.lblRMA.Text = dtDevice.Rows(0)("hd_RMA")
                                'Me.lblCustomer.Text = dtDevice.Rows(0)("hd_Station")
                                Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                                Me.lblSku.Text = dtDevice.Rows(0)("Sku_Number")
                                'Me.lblSN.Text = dtDevice.Rows(0)("hd_SN")
                                Me.lblIMEI.Text = dtDevice.Rows(0)("Label_IMEI")
                                Me.lblPartNo.Text = dtDevice.Rows(0)("hd_PartNo")
                                Me.lblSymptom.Text = dtDevice.Rows(0)("hd_Symptom")
                                Me.lblLastCompletedTechName.Text = "Completed by: " & dtDevice.Rows(0)("LastCompletedUser")

                                Me.PopulateSelection()

                                '*****************************************
                                'Only allow ATT 8925 model to change P/N
                                '*****************************************
                                If Me._strScreenName.ToUpper = "BILLING AUDITOR" And (Me._iModelID = 1120 Or Me._iModelID = 1123) Then
                                    Me.btnChangeLastDigitOfPN.Visible = True
                                End If
                                '*****************************************
                            End If
                        End If
                    Else
                        MessageBox.Show("S/N number either does not exist, belongs to a different customer or already been ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
    Private Sub PopulateSelection()
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim R1 As DataRow

        Try
            dt = Me._objHTC.GetDeviceRepairDisplayList(Me._iDeviceID)
            With Me.dbgBillingData
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Visible = True
                Me.pnlBillingData.Visible = True

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                .Columns("Completed Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                .Splits(0).DisplayColumns("Main Category").Width = 100
                .Splits(0).DisplayColumns("Fail Code").Width = 160
                .Splits(0).DisplayColumns("Fail At").Width = 80
                .Splits(0).DisplayColumns("Failed Inspector").Width = 100
                .Splits(0).DisplayColumns("Repair Code").Width = 160
                .Splits(0).DisplayColumns("Part").Width = 100
                .Splits(0).DisplayColumns("Part SN").Width = 100
                .Splits(0).DisplayColumns("Part IMEI").Width = 100
                .Splits(0).DisplayColumns("PartNumber").Width = 70
                .Splits(0).DisplayColumns("Tech").Width = 100
                '.Splits(0).DisplayColumns("Completed").Width = 62
                .Splits(0).DisplayColumns("Completed Date").Width = 100

                .Splits(0).DisplayColumns("Fail_ID").Visible = False
                .Splits(0).DisplayColumns("Repair_ID").Visible = False
                .Splits(0).DisplayColumns("Device_ID").Visible = False
                .Splits(0).DisplayColumns("RI_ID").Visible = False
                .Splits(0).DisplayColumns("BillCode_ID").Visible = False
                .Splits(0).DisplayColumns("PSPrice_ID").Visible = False
                .Splits(0).DisplayColumns("MC_ID").Visible = False

                .Splits(0).Style.WrapText = True

            End With
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
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
    Private Sub frmBillingAuditAndPartsReclaim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            If _strScreenName.Trim.ToUpper = "RECLAIM PARTS" Then
                Me.btnReclaimParts.Visible = True
            Else
                Me.btnFail.Visible = True
                Me.btnPass.Visible = True
            End If

            Me._iTestTypeID = Me._objHTC.GetTestTypeID(Me._strScreenName.Trim.ToUpper)
            If Me._iTestTypeID = 0 Then
                MessageBox.Show("System can't identify screen type ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'PSS.Gui.MainWin.WorkArea.TabPages.RemoveAt(PSS.Gui.MainWin.wrkArea.SelectedIndex)
                Me.Close()
            End If

            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.ClearAllVariableAndControls()
        Me.txtSN.Focus()
    End Sub

    '******************************************************************
    Private Sub ClearAllVariableAndControls()
        Me._iDeviceID = 0
        Me._iModelID = 0
        Me._strLastCompletedTechName = ""
        Me._iLastCompletedTechID = 0
        Me._iRejectDevice = 0
        Me.dbgBillingData.DataSource = Nothing
        Me.pnlBillingData.Visible = False

        Me.btnChangeLastDigitOfPN.Visible = False

        Me.lblRMA.Text = ""
        'Me.lblCustomer.Text = ""
        Me.lblModel.Text = ""
        Me.lblSku.Text = ""
        'Me.lblSN.Text = ""
        Me.lblIMEI.Text = ""
        Me.lblPartNo.Text = ""
        Me.lblSymptom.Text = ""
        Me.lblLastCompletedTechName.Text = ""
        Me.txtSN.Text = ""
    End Sub

    '******************************************************************
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim strNextWrkStation As String = ""
        Dim iRow As Integer = 0
        Dim i As Integer = 0
        Dim objDevice As PSS.Rules.Device = Nothing
        Dim booDeleteAll As Boolean = False

        Try
            If Me._iDeviceID = 0 Then Exit Sub
            If Me.dbgBillingData.RowCount = 0 Then
                Exit Sub
            ElseIf Me.dbgBillingData.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select rows to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                'For Each iRow In Me.dbgBillingData.SelectedRows
                '    If Not IsDBNull(Me.dbgTestResult.Columns("Repair_ID").CellText(iRow)) AndAlso Me.dbgTestResult.Columns("Repair_ID").CellText(iRow).ToString.Trim.Length > 0 Then
                '        Throw New Exception("This fail code was already completed by the technician. You are not allow to delete.")
                '    End If
                'Next iRow

                If Me.dbgBillingData.SelectedRows.Count = Me.dbgBillingData.RowCount Then
                    booDeleteAll = True
                End If

                If MessageBox.Show("Are you sure you want to delete selected fail codes and repair codes from list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                '********************
                'no err, delete now
                '********************
                objDevice = New PSS.Rules.Device(Me._iDeviceID)
                For Each iRow In Me.dbgBillingData.SelectedRows
                    If Me.dbgBillingData.Columns("RI_ID").CellText(iRow) = 0 Then
                        Throw New Exception("Repair ID is mising.")
                    Else
                        If Not IsDBNull(Me.dbgBillingData.Columns("Billcode_ID").CellText(iRow)) AndAlso Me.dbgBillingData.Columns("Billcode_ID").CellText(iRow).Trim.Length > 0 Then
                            'remove from repair table
                            i = Me._objHTC.RemoveRepairRecordByUnbill(Me._iDeviceID, Me.dbgBillingData.Columns("Billcode_ID").CellText(iRow), ApplicationUser.IDuser, Me._strScreenName, Me.dbgBillingData.Columns("RI_ID").CellText(iRow), Me.dbgBillingData.Columns("Part SN").CellText(iRow), 1)
                            'remve billing
                            objDevice.FailID = Me.dbgBillingData.Columns("Fail_ID").CellText(iRow)
                            objDevice.RepairID = Me.dbgBillingData.Columns("Repair_ID").CellText(iRow)
                            objDevice.DeletePart(Me.dbgBillingData.Columns("Billcode_ID").CellText(iRow))
                        Else
                            i = Me._objHTC.RemoveFailCodeFrRepairTable(Me.dbgBillingData.Columns("RI_ID").CellText(iRow), ApplicationUser.IDuser, Me._strScreenName)
                        End If
                    End If
                Next iRow
                objDevice.Update()

                Cursor.Current = System.Windows.Forms.Cursors.Default

                '*********************************************
                'push unit back to repair if no billcode exist
                '*********************************************
                If booDeleteAll = True Then
                    i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, "REPAIR")
                    If i > 0 Then
                        MessageBox.Show("Device has moved to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System failed to push the device to " & strNextWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                '*********************************************
                Me.PopulateSelection()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Selected Record", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(objDevice) Then
                objDevice.Dispose()
                objDevice = Nothing
            End If
            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnReclaimParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReclaimParts.Click
        Dim strNextWrkStation As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim objDevice As PSS.Rules.Device = Nothing
        Dim strBillcodeIDs As String = ""
        Dim iRUR_FailID As Integer = 0
        Dim iRUR_RepID As Integer = 0

        Try
            If Me._iDeviceID = 0 Then Exit Sub
            If Me.dbgBillingData.RowCount = 0 Then
                Exit Sub
            Else
                If MessageBox.Show("Are you sure you have removed all parts from this unit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, Me._iModelID, Me._objHTC.HTC_CUSTOMER_ID)
                If strNextWrkStation.Trim.Length = 0 Then
                    MessageBox.Show("Can not find the next workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                '********************
                'Delete all parts
                '********************
                For i = 0 To Me.dbgBillingData.RowCount - 1
                    If IsDBNull(Me.dbgBillingData.Columns("BillCode_ID").CellValue(i)) Or (Me.dbgBillingData.Columns("BillCode_ID").CellValue(i).ToString.Trim.Length > 0 And Me.dbgBillingData.Columns("BillCode_ID").CellValue(i) <> HTC.HTC_RUR_BILLCODEID) Then
                        j = Me._objHTC.RemoveFailCodeFrRepairTable(Me.dbgBillingData.Columns("RI_ID").CellText(i), ApplicationUser.IDuser, Me._strScreenName)

                        If Not IsDBNull(Me.dbgBillingData.Columns("BillCode_ID").CellValue(i)) Then
                            If strBillcodeIDs.Trim.Length > 0 Then strBillcodeIDs &= ", "
                            strBillcodeIDs &= Me.dbgBillingData.Columns("BillCode_ID").CellValue(i)
                        End If
                    ElseIf Not IsDBNull(Me.dbgBillingData.Columns("BillCode_ID").CellValue(i)) AndAlso (Me.dbgBillingData.Columns("BillCode_ID").CellValue(i).ToString.Trim.Length > 0 And Me.dbgBillingData.Columns("BillCode_ID").CellValue(i) = HTC.HTC_RUR_BILLCODEID) Then
                        iRUR_FailID = Me.dbgBillingData.Columns("Fail_ID").CellValue(i)
                        iRUR_RepID = Me.dbgBillingData.Columns("Repair_ID").CellValue(i)
                    End If
                Next i

                If strBillcodeIDs.Trim.Length > 0 Then
                    Me._objHTC.RemoveBillcodeFromTdevicebill(Me._iDeviceID, strBillcodeIDs)
                End If
                '********************
                'Bill RUR
                '********************
                objDevice = New PSS.Rules.Device(Me._iDeviceID)
                objDevice.FailID = iRUR_FailID
                objDevice.RepairID = iRUR_RepID
                objDevice.AddPart(HTC.HTC_RUR_BILLCODEID)
                objDevice.Update()

                Cursor.Current = System.Windows.Forms.Cursors.Default
                '********************
                'push to packaging
                '********************
                'push unit back to repair
                j = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation)
                If j > 0 Then
                    MessageBox.Show("Device has moved to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("System failed to push the device to " & strNextWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            Me.ClearAllVariableAndControls()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Selected Record", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            If Not IsNothing(objDevice) Then
                objDevice.Dispose()
                objDevice = Nothing
            End If
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnFail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFail.Click
        Const iResult As Integer = 2
        Dim strNextWorkStation As String = ""
        Dim i As Integer = 0

        Try
            '****************************
            'Write SCREEN result
            '****************************
            i = Me._objHTC.WriteTestResult(Me._iDeviceID, Me._iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, Me._iLastCompletedTechID, iResult, , , , , , )
            If i = 0 Then
                MessageBox.Show("System failed to write screen result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Send unit back to Repair
            strNextWorkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, Me._iModelID, HTC.HTC_CUSTOMER_ID, 1)
            If strNextWorkStation.Trim.Length = 0 Then
                MessageBox.Show("Can't find the next workstation for this unit.", "Informaiton", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWorkStation, )
                If i > 0 Then
                    MessageBox.Show("Please return unit back to technician """ & Me._strLastCompletedTechName & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.ClearAllVariableAndControls()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnFail_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtSN.SelectAll()
        Finally
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnPass_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPass.Click
        Dim strNextWrkStation As String = ""
        Dim strNewIMEI As String = ""
        Dim i As Integer = 0
        Dim iCopyNumber As Integer = 2
        Dim booChangeIMEI As Boolean = False
        Dim iScreenResult As Integer = 1

        Try
            If Me.txtSN.Text.Trim.Length = 0 Or Me._iDeviceID = 0 Then
                Exit Sub
            Else
                If Me._iRejectDevice = 1 Then iCopyNumber = 0

                '********************************************************
                '1: Get new IMEI number if technician change mother board
                '********************************************************
                strNewIMEI = Me._objHTC.GetNewIMEI(Me._iDeviceID)
                If strNewIMEI.Trim.Length = 0 Or strNewIMEI.Trim.ToUpper = Me.lblIMEI.Text.Trim.ToUpper Then
                    strNewIMEI = Me.lblIMEI.Text.Trim.ToUpper
                ElseIf strNewIMEI.Trim.ToUpper <> Me.lblIMEI.Text.Trim.ToUpper Then
                    booChangeIMEI = True
                End If

                Me.Enabled = False
                '*************************
                '2 :Get Next workstation
                '*************************
                strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, Me._iModelID, Me._objHTC.HTC_CUSTOMER_ID)
                If strNextWrkStation.Trim.Length = 0 Then
                    MessageBox.Show("Can not find the next workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll()
                    Exit Sub
                End If

                ''**********************
                ''3: Print Label 
                ''**********************
                'If iCopyNumber > 0 Then Me._objHTC.PrintIMEILabel(Me.lblPartNo.Text.Trim.ToUpper, strNewIMEI.Trim.ToUpper, Me.txtSN.Text.Trim.ToUpper, iCopyNumber, "HTC SN Bag Label.rpt")

                '''*****************************
                '''change tdevice.SN to new IMEI
                '''*****************************
                ''If booChangeSN = True Then
                ''    i = Me._objHTC.ChangeSN(Me._iDeviceID, strNewIMEI.Trim.ToUpper)
                ''    If i = 0 Then
                ''        MessageBox.Show("System havae failed to change new IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''        Me.txtIMEI.SelectAll()
                ''        Exit Sub
                ''    End If

                ''End If

                '****************************
                'Write SCREEN result
                '****************************
                i = Me._objHTC.WriteTestResult(Me._iDeviceID, Me._iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, Me._iLastCompletedTechID, iScreenResult, , , , , , )
                If i = 0 Then
                    MessageBox.Show("System failed to write screen result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                '*****************************
                '4: Push unit to next station
                '*****************************
                If booChangeIMEI = True Then
                    i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation, , strNewIMEI)
                Else
                    i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation, , )
                End If
                If i = 0 Then
                    MessageBox.Show("System failed to push the device to " & strNextWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '*****************************
                If i > 0 Then
                    'If booChangeIMEI = True Then
                    '    MessageBox.Show("Device has a new IMEI. Please throw way the old label.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Else
                    MessageBox.Show("Device has pushed to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If
                End If

                '*****************************
                Me.ClearAllVariableAndControls()
                '*****************************
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnPass_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtSN.SelectAll()
        Finally
            Me.Enabled = True
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnChangeLastDigitOfPN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeLastDigitOfPN.Click
        Dim strLastDigitOfPN As String = ""
        Dim strNewPN As String = ""
        Dim i As Integer = 0

        Try
            If Me._iDeviceID = 0 Then
                Exit Sub
            Else
                strLastDigitOfPN = InputBox("Enter Last Digit Number of P/N:", "P/N").Trim.ToUpper
                If strLastDigitOfPN = "" Then
                    Exit Sub
                Else
                    If strLastDigitOfPN <> "0" And strLastDigitOfPN <> "1" Then
                        MessageBox.Show("Invalid input.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.lblPartNo.Text.Trim.ToUpper.EndsWith(strLastDigitOfPN) Then
                        MessageBox.Show("Input number is the same with old value. No change have made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        strNewPN = Mid(Me.lblPartNo.Text.Trim.ToUpper, 1, Me.lblPartNo.Text.Trim.Length - 1) & strLastDigitOfPN
                        If Me.lblPartNo.Text.Trim.ToUpper <> strNewPN Then
                            i = Me._objHTC.ChangeLastCharOfPartNumber(Me._strScreenName.ToUpper, Me._iDeviceID, ApplicationUser.IDuser, ApplicationUser.User, strNewPN, Me.lblPartNo.Text.Trim.ToUpper)
                            If i = 0 Then
                                MessageBox.Show("System failed to change last digit of part number. Try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            Else
                                Me.lblPartNo.Text = strNewPN
                                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnChangeLastDigitOfPN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************

End Class
