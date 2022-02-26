Option Explicit On 

Imports C1.Win.C1TrueDBGrid
Imports PSS.Core.Global

Public Class frmDiagnosticTest
    Inherits System.Windows.Forms.Form

    Private Const TESTTYPEID As Integer = 5
    Private _objHTC As PSS.Data.Buisness.HTC
    Private _strScreenName As String = ""
    Private _iDeviceID As Integer = 0
    Private _iModelID As Integer = 0
    Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTestType As String, ByVal strScreenName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strScreenName = strScreenName

        Me.lblTitle.Text = "Diagnostic Test"
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
    Friend WithEvents pnlTestResult As System.Windows.Forms.Panel
    Friend WithEvents pnlEMEI_Info As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chklstFailMainArea As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnDeleteFailCode As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAllFailCodes As System.Windows.Forms.Button
    Friend WithEvents btnRUR As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnShowSelection As System.Windows.Forms.Button
    Friend WithEvents pnlFailCodes_MainCategory As System.Windows.Forms.Panel
    Friend WithEvents chklstFailCodes As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDiagnosticTest))
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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnShowSelection = New System.Windows.Forms.Button()
        Me.btnRUR = New System.Windows.Forms.Button()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlTestResult = New System.Windows.Forms.Panel()
        Me.btnDeleteAllFailCodes = New System.Windows.Forms.Button()
        Me.btnDeleteFailCode = New System.Windows.Forms.Button()
        Me.dbgTestResult = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chklstFailMainArea = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlFailCodes_MainCategory = New System.Windows.Forms.Panel()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chklstFailCodes = New System.Windows.Forms.CheckedListBox()
        Me.Panel6.SuspendLayout()
        Me.pnlEMEI_Info.SuspendLayout()
        Me.pnlTestResult.SuspendLayout()
        CType(Me.dbgTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFailCodes_MainCategory.SuspendLayout()
        Me.pnlFailCodes.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblTitle.TabIndex = 120
        Me.lblTitle.Text = "Diagnostic Test"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPartNo, Me.Label5, Me.lblIMEI, Me.Label9, Me.lblSku, Me.Label6, Me.lblModel, Me.Label8, Me.lblCustomer, Me.Label4, Me.lblRMA, Me.Label1, Me.lblSymptom, Me.Label10})
        Me.Panel6.Location = New System.Drawing.Point(304, -1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(664, 57)
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
        Me.pnlEMEI_Info.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlEMEI_Info.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlEMEI_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlEMEI_Info.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.btnShowSelection, Me.btnRUR, Me.btnFinish, Me.txtSN, Me.Label2})
        Me.pnlEMEI_Info.Location = New System.Drawing.Point(1, 56)
        Me.pnlEMEI_Info.Name = "pnlEMEI_Info"
        Me.pnlEMEI_Info.Size = New System.Drawing.Size(967, 44)
        Me.pnlEMEI_Info.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(736, 10)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(56, 20)
        Me.btnClear.TabIndex = 127
        Me.btnClear.Text = "Clear"
        '
        'btnShowSelection
        '
        Me.btnShowSelection.BackColor = System.Drawing.Color.SteelBlue
        Me.btnShowSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowSelection.ForeColor = System.Drawing.Color.White
        Me.btnShowSelection.Location = New System.Drawing.Point(800, 10)
        Me.btnShowSelection.Name = "btnShowSelection"
        Me.btnShowSelection.Size = New System.Drawing.Size(152, 20)
        Me.btnShowSelection.TabIndex = 126
        Me.btnShowSelection.Text = "SHOW SELECTION"
        '
        'btnRUR
        '
        Me.btnRUR.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnRUR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRUR.ForeColor = System.Drawing.Color.White
        Me.btnRUR.Location = New System.Drawing.Point(368, 10)
        Me.btnRUR.Name = "btnRUR"
        Me.btnRUR.Size = New System.Drawing.Size(88, 20)
        Me.btnRUR.TabIndex = 125
        Me.btnRUR.Text = "RUR"
        '
        'btnFinish
        '
        Me.btnFinish.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnFinish.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinish.ForeColor = System.Drawing.Color.White
        Me.btnFinish.Location = New System.Drawing.Point(512, 10)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(88, 20)
        Me.btnFinish.TabIndex = 124
        Me.btnFinish.Text = "FINISH"
        '
        'txtSN
        '
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(43, 9)
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
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "S/N:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTestResult
        '
        Me.pnlTestResult.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlTestResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTestResult.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteAllFailCodes, Me.btnDeleteFailCode, Me.dbgTestResult})
        Me.pnlTestResult.Location = New System.Drawing.Point(8, 101)
        Me.pnlTestResult.Name = "pnlTestResult"
        Me.pnlTestResult.Size = New System.Drawing.Size(960, 547)
        Me.pnlTestResult.TabIndex = 4
        Me.pnlTestResult.Visible = False
        '
        'btnDeleteAllFailCodes
        '
        Me.btnDeleteAllFailCodes.BackColor = System.Drawing.Color.Red
        Me.btnDeleteAllFailCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteAllFailCodes.ForeColor = System.Drawing.Color.White
        Me.btnDeleteAllFailCodes.Location = New System.Drawing.Point(505, 1)
        Me.btnDeleteAllFailCodes.Name = "btnDeleteAllFailCodes"
        Me.btnDeleteAllFailCodes.Size = New System.Drawing.Size(88, 20)
        Me.btnDeleteAllFailCodes.TabIndex = 4
        Me.btnDeleteAllFailCodes.Text = "Delete All"
        '
        'btnDeleteFailCode
        '
        Me.btnDeleteFailCode.BackColor = System.Drawing.Color.Red
        Me.btnDeleteFailCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteFailCode.ForeColor = System.Drawing.Color.White
        Me.btnDeleteFailCode.Location = New System.Drawing.Point(360, 1)
        Me.btnDeleteFailCode.Name = "btnDeleteFailCode"
        Me.btnDeleteFailCode.Size = New System.Drawing.Size(88, 20)
        Me.btnDeleteFailCode.TabIndex = 3
        Me.btnDeleteFailCode.Text = "Delete"
        '
        'dbgTestResult
        '
        Me.dbgTestResult.AllowArrows = False
        Me.dbgTestResult.AllowColMove = False
        Me.dbgTestResult.AllowFilter = False
        Me.dbgTestResult.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.IndividualRows
        Me.dbgTestResult.AllowUpdate = False
        Me.dbgTestResult.AlternatingRows = True
        Me.dbgTestResult.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgTestResult.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgTestResult.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dbgTestResult.Caption = "Failcodes / Repaircodes Data"
        Me.dbgTestResult.FetchRowStyles = True
        Me.dbgTestResult.FilterBar = True
        Me.dbgTestResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgTestResult.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgTestResult.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgTestResult.LinesPerRow = 3
        Me.dbgTestResult.Location = New System.Drawing.Point(8, 24)
        Me.dbgTestResult.Name = "dbgTestResult"
        Me.dbgTestResult.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgTestResult.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgTestResult.PreviewInfo.ZoomFactor = 75
        Me.dbgTestResult.RowHeight = 35
        Me.dbgTestResult.RowSubDividerColor = System.Drawing.Color.DimGray
        Me.dbgTestResult.Size = New System.Drawing.Size(944, 499)
        Me.dbgTestResult.TabIndex = 1
        Me.dbgTestResult.Text = "C1TrueDBGrid1"
        Me.dbgTestResult.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Wrap:True;Font:Microsoft " & _
        "Sans Serif, 6.75pt, style=Bold;AlignHorz:Near;Trimming:Character;BackColor:Wheat" & _
        ";ForegroundImagePos:LeftOfText;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
        "ight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}" & _
        "FilterBar{ForeColor:Red;BackColor:White;}Footer{Font:Microsoft Sans Serif, 8.25p" & _
        "t, style=Bold;}Caption{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:C" & _
        "enter;BackColor:SlateGray;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
        "Color:LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}" & _
        "Style14{}OddRow{Wrap:True;Font:Microsoft Sans Serif, 6.75pt, style=Bold;AlignHor" & _
        "z:Near;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Micros" & _
        "oft Sans Serif, 8.25pt, style=Bold;BackColor:SteelBlue;Border:Raised,,1, 1, 1, 1" & _
        ";ForeColor:White;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Styl" & _
        "e12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBa" & _
        "rHeight=""10"" AllowColMove=""False"" Name="""" AllowRowSizing=""IndividualRows"" Altern" & _
        "atingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHei" & _
        "ght=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" " & _
        "RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalS" & _
        "crollGroup=""1""><Height>482</Height><CaptionStyle parent=""Style2"" me=""Style10"" />" & _
        "<EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""St" & _
        "yle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""F" & _
        "ooter"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle par" & _
        "ent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7""" & _
        " /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" m" & _
        "e=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Select" & _
        "edStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Cl" & _
        "ientRect>0, 17, 944, 482</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunk" & _
        "en</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
        "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
        "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
        "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
        "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
        "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
        "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
        "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
        "Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0," & _
        " 944, 499</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageF" & _
        "ooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'chklstFailMainArea
        '
        Me.chklstFailMainArea.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.chklstFailMainArea.Location = New System.Drawing.Point(6, 24)
        Me.chklstFailMainArea.Name = "chklstFailMainArea"
        Me.chklstFailMainArea.Size = New System.Drawing.Size(288, 514)
        Me.chklstFailMainArea.TabIndex = 121
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(6, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 16)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Fail Area:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlFailCodes_MainCategory
        '
        Me.pnlFailCodes_MainCategory.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.pnlFailCodes_MainCategory.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes_MainCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes_MainCategory.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.chklstFailMainArea})
        Me.pnlFailCodes_MainCategory.Location = New System.Drawing.Point(1, 101)
        Me.pnlFailCodes_MainCategory.Name = "pnlFailCodes_MainCategory"
        Me.pnlFailCodes_MainCategory.Size = New System.Drawing.Size(303, 564)
        Me.pnlFailCodes_MainCategory.TabIndex = 2
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.chklstFailCodes})
        Me.pnlFailCodes.Location = New System.Drawing.Point(312, 101)
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(656, 564)
        Me.pnlFailCodes.TabIndex = 3
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
        Me.chklstFailCodes.Size = New System.Drawing.Size(450, 514)
        Me.chklstFailCodes.TabIndex = 121
        '
        'frmDiagnosticTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(976, 669)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlFailCodes_MainCategory, Me.pnlEMEI_Info, Me.Panel6, Me.lblTitle, Me.pnlTestResult, Me.pnlFailCodes})
        Me.Name = "frmDiagnosticTest"
        Me.Text = "frmTest"
        Me.Panel6.ResumeLayout(False)
        Me.pnlEMEI_Info.ResumeLayout(False)
        Me.pnlTestResult.ResumeLayout(False)
        CType(Me.dbgTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFailCodes_MainCategory.ResumeLayout(False)
        Me.pnlFailCodes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmDiagnoticTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.PopulateFailCodesMainCategories()

            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateFailCodesMainCategories()
        Dim dt As DataTable

        Try
            dt = Me._objHTC.GetFailcodesMainCategories(True)
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
        Dim strSN As String = ""

        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                Else
                    strSN = Me.txtSN.Text.Trim.ToUpper
                    ClearGlobalVarAndCtrls()
                    Me.txtSN.Text = strSN

                    dtDevice = Me._objHTC.GetHTC_thtcdataInfo_InWIP(Me.txtSN.Text.Trim)
                    If dtDevice.Rows.Count > 0 Then
                        If dtDevice.Rows(0)("DiscUnit") = 1 Then
                            MessageBox.Show("S/N is a discrepant unit(" & dtDevice.Rows(0)("Discrepancy Reason") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll()
                        ElseIf dtDevice.Rows(0)("hd_Station") <> Me._strScreenName Then
                            If MessageBox.Show("This Device is at " & dtDevice.Rows(0)("hd_Station") & "." & Environment.NewLine & "Would you like to view the fail codes and repair code of this unit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Me._iDeviceID = dtDevice.Rows(0)("Device_ID")
                                Me.PopulateSelection(False)
                                Me._iDeviceID = 0

                                Me.btnShowSelection.Text = "RETURN"
                                Me.pnlTestResult.Visible = True
                                Me.pnlFailCodes_MainCategory.Visible = False
                                Me.pnlFailCodes.Visible = False
                            End If
                            Me.txtSN.Text = ""
                            Me.txtSN.Focus()
                        Else
                            dtRepStatus = Me._objHTC.CheckDeviceRepairStatus(Me._iDeviceID)

                            If dtRepStatus.Rows.Count > 0 AndAlso dtRepStatus.Rows(0)("BillCode_Rule") = 1 Then
                                MessageBox.Show("This is an RUR unit please send it to packaging.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.SelectAll()
                            Else
                                Me._iDeviceID = dtDevice.Rows(0)("Device_ID")
                                Me._iModelID = dtDevice.Rows(0)("Model_ID")

                                Me.lblRMA.Text = dtDevice.Rows(0)("hd_RMA")
                                Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                                Me.lblSku.Text = dtDevice.Rows(0)("Sku_Number")
                                'Me.lblSN.Text = dtDevice.Rows(0)("hd_SN")
                                Me.lblIMEI.Text = dtDevice.Rows(0)("Label_IMEI")
                                Me.lblPartNo.Text = dtDevice.Rows(0)("hd_PartNo")
                                Me.lblSymptom.Text = dtDevice.Rows(0)("hd_Symptom")

                                Me.PopulateSelection(True)
                                Me.pnlTestResult.Visible = False
                                Me.pnlFailCodes_MainCategory.Visible = True
                                Me.pnlFailCodes.Visible = False
                                Me.btnDeleteFailCode.Enabled = True
                                Me.btnDeleteAllFailCodes.Enabled = True
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
    Private Sub PopulateSelection(ByVal booCheckSelectedItem As Boolean)
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim R1 As DataRow

        Try
            dt = Me._objHTC.GetDeviceRepairDisplayList(Me._iDeviceID)
            With Me.dbgTestResult
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Visible = True

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    '.Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
                    '.Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Top
                Next i
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
                .Splits(0).DisplayColumns("Completed Date").Width = 62

                '.Splits(0).DisplayColumns("Completed??").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '.Splits(0).DisplayColumns("Completed??").Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                .Splits(0).DisplayColumns("Fail_ID").Visible = False
                .Splits(0).DisplayColumns("Repair_ID").Visible = False
                .Splits(0).DisplayColumns("Device_ID").Visible = False
                .Splits(0).DisplayColumns("RI_ID").Visible = False
                .Splits(0).DisplayColumns("BillCode_ID").Visible = False
                .Splits(0).DisplayColumns("PSPrice_ID").Visible = False
                .Splits(0).DisplayColumns("MC_ID").Visible = False

                .Splits(0).Style.WrapText = True
                '.Splits(0).FooterStyle.WrapText = True

                If booCheckSelectedItem = True Then
                    Me._booPopulateData = True
                    For i = 0 To Me.chklstFailMainArea.Items.Count - 1
                        Me.chklstFailMainArea.SetItemChecked(i, False)
                    Next i

                    For i = 0 To Me.chklstFailMainArea.Items.Count - 1
                        For Each R1 In dt.Rows
                            If R1("MC_ID") = Me.chklstFailMainArea.Items.Item(i)("MC_ID") Then
                                Me.chklstFailMainArea.SetItemChecked(i, True)
                                Exit For
                            End If
                        Next R1
                    Next i
                    Me._booPopulateData = False
                End If

            End With
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailMainArea_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstFailMainArea.ItemCheck
        Try
            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me._iDeviceID = 0 Then
                MessageBox.Show("Device ID is missing. Please scan S/N again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._booPopulateData = True Then
                Exit Sub
            ElseIf e.NewValue = CheckState.Checked Then
                Me.PopulateFailCodes(Me.chklstFailMainArea.SelectedItem("MC_ID"))
                Me.pnlFailCodes.Visible = True
            ElseIf e.NewValue = CheckState.Unchecked Then
                Me._objHTC.RemoveFailCodesFrRepairTableByMainCategory(Me._iDeviceID, Me.chklstFailMainArea.SelectedItem("MC_ID"), ApplicationUser.IDuser, Me._strScreenName)
                Me.PopulateSelection(True)
                Me.PopulateFailCodes(Me.chklstFailMainArea.SelectedItem("MC_ID"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailMainArea_ItemCheck", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailMainArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chklstFailMainArea.SelectedIndexChanged
        Dim i As Integer = 0
        Dim j As Integer = 0

        Try
            Me._booPopulateData = True
            For i = 0 To Me.chklstFailMainArea.Items.Count - 1
                Me.chklstFailMainArea.SetItemChecked(i, False)
            Next i

            For i = 0 To Me.chklstFailMainArea.Items.Count - 1
                For j = 0 To Me.dbgTestResult.RowCount - 1
                    If chklstFailMainArea.Items.Item(i)("MC_ID") = Me.dbgTestResult.Columns("MC_ID").CellValue(j) Then
                        Me.chklstFailMainArea.SetItemChecked(i, True)
                        Exit For
                    End If
                Next j
            Next i
            Me._booPopulateData = False

            If Me._booPopulateData = False Then Me.PopulateFailCodes(Me.chklstFailMainArea.SelectedItem("MC_ID"))

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailCodes_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateFailCodes(ByVal iFailcodeMainCategoryID As Integer)
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim R1 As DataRow

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
                If Me.chklstFailMainArea.Visible = True Then Me.pnlFailCodes.Visible = True

                '*****************************************
                'set check item from previous selection
                '*****************************************
                Me._booPopulateData = True
                For j = 0 To Me.chklstFailCodes.Items.Count - 1
                    Me.chklstFailCodes.SetItemChecked(j, False)
                Next j

                For j = 0 To Me.chklstFailCodes.Items.Count - 1
                    For i = 0 To Me.dbgTestResult.RowCount - 1
                        If chklstFailCodes.Items.Item(j)("Fail_ID") = Me.dbgTestResult.Columns("Fail_ID").CellValue(i) And chklstFailCodes.Tag = Me.dbgTestResult.Columns("MC_ID").CellValue(i) Then
                            Me.chklstFailCodes.SetItemChecked(j, True)
                            Exit For
                        End If
                    Next i
                Next j
                Me._booPopulateData = False

                '*****************************************
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailCodes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstFailCodes.ItemCheck
        Dim i As Integer = 0
        Dim booExisted As Boolean = False

        Try
            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me._iDeviceID = 0 Then
                MessageBox.Show("Device ID is missing. Please scan S/N again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me._booPopulateData = True Then
                Exit Sub
            ElseIf e.NewValue = CheckState.Checked Then
                For i = 0 To Me.dbgTestResult.RowCount - 1
                    If Me.chklstFailCodes.SelectedItem("Fail_ID") = Me.dbgTestResult.Columns("Fail_ID").CellValue(i) And Me.chklstFailCodes.Tag = Me.dbgTestResult.Columns("MC_ID").CellValue(i) Then
                        booExisted = True
                        Exit For
                    End If
                Next i

                If booExisted = False Then
                    Me._objHTC.InsertFailCodeToRepairTable(_iDeviceID, Me.chklstFailCodes.Tag, Me.chklstFailCodes.SelectedItem("Fail_ID"), PSS.Core.Global.ApplicationUser.IDuser, Me._strScreenName)
                    Me.PopulateSelection(True)
                End If
            ElseIf e.NewValue = CheckState.Unchecked Then
                For i = 0 To Me.dbgTestResult.RowCount - 1
                    If Me.chklstFailCodes.SelectedItem("Fail_ID") = Me.dbgTestResult.Columns("Fail_ID").CellValue(i) And Me.chklstFailCodes.Tag = Me.dbgTestResult.Columns("MC_ID").CellValue(i) And IsDBNull(Me.dbgTestResult.Columns("Repair_ID").CellValue(i)) Then
                        Me._objHTC.RemoveFailCodeFrRepairTable(Me.dbgTestResult.Columns("RI_ID").CellValue(i), ApplicationUser.IDuser, Me._strScreenName)
                        Me.PopulateSelection(True)
                        Exit For
                    End If
                Next i
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailCodes_ItemCheck", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub ClearGlobalVarAndCtrls()
        Me._iDeviceID = 0
        Me._iModelID = 0

        Me.lblRMA.Text = ""
        'Me.lblCustomer.Text = ""
        Me.lblModel.Text = ""
        Me.lblSku.Text = ""
        Me.lblIMEI.Text = ""
        Me.lblPartNo.Text = ""
        Me.lblSymptom.Text = ""

        Me.pnlTestResult.Visible = False
        Me.pnlFailCodes_MainCategory.Visible = False
        Me.pnlFailCodes.Visible = False
        Me.pnlFailCodes.Tag = 0
        Me.btnShowSelection.Text = "SHOW SELECTION"
        Me.dbgTestResult.DataSource = Nothing
        Me.chklstFailCodes.DataSource = Nothing

        Me.txtSN.Text = ""
        Me.txtSN.Focus()
    End Sub

    '******************************************************************
    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Const iTestResult = 1 'pass
        Dim strNextWrkStation As String = ""
        Dim i As Integer = 0

        Try
            If Me._iDeviceID = 0 Then Exit Sub
            If Me.dbgTestResult.RowCount = 0 Then
                MessageBox.Show("To finish this unit you must select at least one fail code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf Me._iDeviceID = 0 Then
                MessageBox.Show("Device ID is missing. Please scan S/N again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtSN.SelectAll()
                Exit Sub
            Else
                strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, Me._iModelID, Me._objHTC.HTC_CUSTOMER_ID)
                If strNextWrkStation.Trim.Length = 0 Then
                    MessageBox.Show("Can not find the next workstation of current " & Me._strScreenName.ToUpper & " station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    i = Me._objHTC.WriteTestResult(Me._iDeviceID, Me.TESTTYPEID, ApplicationUser.IDuser, 0, iTestResult, , , , , , )
                    i = Me._objHTC.PushUnitToNextWorkingStation(Me._iDeviceID, strNextWrkStation)
                    If i > 0 Then
                        MessageBox.Show("Device has moved to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.ClearGlobalVarAndCtrls()
                        Me.txtSN.Focus()
                    Else
                        MessageBox.Show("System failed to push the device to " & strNextWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            End If

            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnFinish_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDeleteFailCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFailCode.Click
        Dim strNextWrkStation As String = ""
        Dim iRow As Integer = 0
        Dim i As Integer = 0

        Try
            If Me.dbgTestResult.RowCount = 0 Then
                Exit Sub
            ElseIf Me.dbgTestResult.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select rows to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                For Each iRow In Me.dbgTestResult.SelectedRows
                    If Not IsDBNull(Me.dbgTestResult.Columns("Repair_ID").CellText(iRow)) AndAlso Me.dbgTestResult.Columns("Repair_ID").CellText(iRow).ToString.Trim.Length > 0 Then
                        Throw New Exception("This fail code was already completed by the technician. You are not allow to delete.")
                    End If
                Next iRow

                If MessageBox.Show("Are you sure you want to delete selected fail codes and repair codes from list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                '********************
                'no err, delete now
                '********************
                For Each iRow In Me.dbgTestResult.SelectedRows
                    If Me.dbgTestResult.Columns("RI_ID").CellText(iRow) = 0 Then
                        Throw New Exception("Repair ID is mising.")
                    Else
                        i = Me._objHTC.RemoveFailCodeFrRepairTable(Me.dbgTestResult.Columns("RI_ID").CellText(iRow), ApplicationUser.IDuser, Me._strScreenName)
                    End If
                Next iRow
                '********************
                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            Me.PopulateSelection(False)
            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Selected Record", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnDeleteAllFailCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAllFailCodes.Click
        Dim i As Integer

        Try
            If Me.dbgTestResult.RowCount = 0 Then
                Exit Sub
            Else
                If MessageBox.Show("Are you sure you want to delete all fail codes from the list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                i = Me.DeleteAllFailcodes()
                '********************
                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            Me.txtSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete All", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Function DeleteAllFailcodes() As Integer
        Dim iRow As Integer = 0
        Dim i As Integer = 0

        Try
            For iRow = 0 To Me.dbgTestResult.RowCount - 1
                If Not IsDBNull(Me.dbgTestResult.Columns("Repair_ID").CellText(iRow)) AndAlso Me.dbgTestResult.Columns("Repair_ID").CellText(iRow).ToString.Trim.Length > 0 Then
                    Throw New Exception("This fail code has already been repaired by the technician. You are not allow to delete.")
                End If
            Next iRow

            '****************************************
            'delete now if device ID greater than zero
            '****************************************
            If Me._iDeviceID = 0 Then
                Throw New Exception("Device ID is mising.")
            Else
                i = Me._objHTC.RemoveAllFailCodeFrRepairTable(Me._iDeviceID, ApplicationUser.IDuser, Me._strScreenName)
                Me.PopulateSelection(True)
            End If
            '********************

            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '******************************************************************
    Private Sub btnRUR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRUR.Click
        Const iTestResult As Integer = 2
        Dim objFrmRurReason As frmRURReason
        Dim i As Integer
        Dim booCancelSelection As Boolean = False

        Try
            If Me._iDeviceID = 0 Then Exit Sub
            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me._iDeviceID = 0 Then
                MessageBox.Show("Device ID is missing. Please scan S/N again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'ElseIf Me.dbgTestResult.RowCount > 0 Then
                'MessageBox.Show("Please remove all the fail codes before RUR this unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False

                'remove all fail codes
                If Me.dbgTestResult.RowCount > 0 Then i = Me.DeleteAllFailcodes()

                objFrmRurReason = New frmRURReason(Me._iDeviceID, Me._strScreenName, Me._iModelID)
                objFrmRurReason.ShowDialog()

                If objFrmRurReason._booCancel = True Then
                    Exit Sub
                Else
                    '***********************************************
                    '3.1: Write station Result into ttestdata table
                    ' Adding this block because Robert Mcvey want to see it in report
                    '***********************************************
                    i = Me._objHTC.WriteTestResult(Me._iDeviceID, Me.TESTTYPEID, ApplicationUser.IDuser, 0, iTestResult, , , , "RUR", objFrmRurReason._iFailID, )
                    'If i = 0 Then
                    '    MessageBox.Show("System failed to record action result.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                    Me.ClearGlobalVarAndCtrls()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRUR_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Me.txtSN.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub btnShowSelection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowSelection.Click
        Try
            If Me._iDeviceID = 0 Then
                Exit Sub
            ElseIf Me.btnShowSelection.Text.Trim.ToUpper = "RETURN" Then
                Me.btnShowSelection.Text = "SHOW SELECTION"
                Me.pnlTestResult.Visible = False
                If Me._iDeviceID > 0 Then
                    Me.pnlFailCodes_MainCategory.Visible = True
                    Me.pnlFailCodes.Visible = True
                End If
            Else
                Me.btnShowSelection.Text = "RETURN"
                Me.pnlTestResult.Visible = True
                Me.pnlFailCodes_MainCategory.Visible = False
                Me.pnlFailCodes.Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRUR_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtSN.SelectAll()
            Me.txtSN.Focus()
        End Try
    End Sub


    '******************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.pnlFailCodes_MainCategory.Visible = False
        Me.pnlFailCodes.Visible = False
        Me.pnlTestResult.Visible = False
        Me.dbgTestResult.DataSource = Nothing
        Me.chklstFailCodes.DataSource = Nothing
        Me.txtSN.Text = ""

        Me._iDeviceID = 0
        Me._iModelID = 0
        Me.txtSN.Focus()
    End Sub

    '******************************************************************


End Class
