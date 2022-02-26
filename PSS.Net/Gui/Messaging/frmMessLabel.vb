Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmMessLabel
    Inherits System.Windows.Forms.Form

    Private _objMessLabel As MessLabel
    Private _booHasRelabelPermission As Boolean = False
    Private _booOverideCapcodeVisible As Boolean = False
    Private _booIsAMSShareableInvCust As Boolean = False
    Private _iReserveCapcodeID As Integer = 0
    Private _strScreenName As String = "Label"
    Private _iLocID As Integer = 0


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objMessLabel = New MessLabel()
        If PSS.Core.ApplicationUser.GetPermission("MessRelabel") > 0 Then _booHasRelabelPermission = True
        If PSS.Core.ApplicationUser.GetPermission("MessRelabel") > 0 Then _booOverideCapcodeVisible = True
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objMessLabel = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents dbgDailyWeeklyProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chkPrintSkyTellLetter As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmblblBaud As System.Windows.Forms.ComboBox
    Friend WithEvents lbllblModel As System.Windows.Forms.Label
    Friend WithEvents chkPrintModelLetter As System.Windows.Forms.CheckBox
    Friend WithEvents txtlblSN As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lbllblweekly As System.Windows.Forms.Label
    Friend WithEvents chklblPlus As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbllblDaily As System.Windows.Forms.Label
    Friend WithEvents lstModelType As System.Windows.Forms.ListBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtlblCap As System.Windows.Forms.TextBox
    Friend WithEvents chklblND As System.Windows.Forms.CheckBox
    Friend WithEvents chkClearData As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbllblCust As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblModelType As System.Windows.Forms.Label
    Friend WithEvents cmdlblPrint As System.Windows.Forms.Button
    Friend WithEvents msklblFreq As AxMSMask.AxMaskEdBox
    Friend WithEvents cboLabelType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents lblCusts As System.Windows.Forms.Label
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents lblModels As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkNoLabelPrintOut As System.Windows.Forms.CheckBox
    Friend WithEvents chkOverrideCapcode As System.Windows.Forms.CheckBox
    Friend WithEvents chkBackgroudBlack As System.Windows.Forms.CheckBox
    Friend WithEvents cboChangeToCust As C1.Win.C1List.C1Combo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbShareableInvData As System.Windows.Forms.GroupBox
    Friend WithEvents btnSaveNewCust As System.Windows.Forms.Button
    Friend WithEvents dbgAvailableCapCodeList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboChangeToWO As C1.Win.C1List.C1Combo
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpPrintLabel As System.Windows.Forms.TabPage
    Friend WithEvents tpUpdateFreqBaudCap As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblUpdFreq_Freq As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblUpdFreq_Baud As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cboUpdFreq_NewFreq As C1.Win.C1List.C1Combo
    Friend WithEvents lblFreq As System.Windows.Forms.Label
    Friend WithEvents txtUpdFreq_SN As System.Windows.Forms.TextBox
    Friend WithEvents cboUpdFreq_Customers As C1.Win.C1List.C1Combo
    Friend WithEvents lblUpdFreq_Customers As System.Windows.Forms.Label
    Friend WithEvents btnUpdFreq_Save As System.Windows.Forms.Button
    Friend WithEvents cboUpdFreq_NewBaud As C1.Win.C1List.C1Combo
    Friend WithEvents lblUpdFreq_Model As System.Windows.Forms.Label
    Friend WithEvents lblUpdFreq_CapCode As System.Windows.Forms.Label
    Friend WithEvents txtUpdFreq_NewCapCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessLabel))
        Me.dbgDailyWeeklyProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chkPrintSkyTellLetter = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cmblblBaud = New System.Windows.Forms.ComboBox()
        Me.lbllblModel = New System.Windows.Forms.Label()
        Me.chkPrintModelLetter = New System.Windows.Forms.CheckBox()
        Me.txtlblSN = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lbllblweekly = New System.Windows.Forms.Label()
        Me.chklblPlus = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbllblDaily = New System.Windows.Forms.Label()
        Me.lstModelType = New System.Windows.Forms.ListBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtlblCap = New System.Windows.Forms.TextBox()
        Me.chklblND = New System.Windows.Forms.CheckBox()
        Me.chkClearData = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbllblCust = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblModelType = New System.Windows.Forms.Label()
        Me.cmdlblPrint = New System.Windows.Forms.Button()
        Me.msklblFreq = New AxMSMask.AxMaskEdBox()
        Me.cboLabelType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCusts = New System.Windows.Forms.Label()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.lblModels = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.chkNoLabelPrintOut = New System.Windows.Forms.CheckBox()
        Me.chkOverrideCapcode = New System.Windows.Forms.CheckBox()
        Me.chkBackgroudBlack = New System.Windows.Forms.CheckBox()
        Me.gbShareableInvData = New System.Windows.Forms.GroupBox()
        Me.btnSaveNewCust = New System.Windows.Forms.Button()
        Me.cboChangeToCust = New C1.Win.C1List.C1Combo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dbgAvailableCapCodeList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboChangeToWO = New C1.Win.C1List.C1Combo()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpPrintLabel = New System.Windows.Forms.TabPage()
        Me.tpUpdateFreqBaudCap = New System.Windows.Forms.TabPage()
        Me.btnUpdFreq_Save = New System.Windows.Forms.Button()
        Me.lblUpdFreq_Customers = New System.Windows.Forms.Label()
        Me.cboUpdFreq_Customers = New C1.Win.C1List.C1Combo()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtUpdFreq_NewCapCode = New System.Windows.Forms.TextBox()
        Me.cboUpdFreq_NewBaud = New C1.Win.C1List.C1Combo()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cboUpdFreq_NewFreq = New C1.Win.C1List.C1Combo()
        Me.lblFreq = New System.Windows.Forms.Label()
        Me.lblUpdFreq_CapCode = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblUpdFreq_Baud = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblUpdFreq_Model = New System.Windows.Forms.Label()
        Me.lblUpdFreq_Freq = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUpdFreq_SN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dbgDailyWeeklyProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msklblFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbShareableInvData.SuspendLayout()
        CType(Me.cboChangeToCust, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgAvailableCapCodeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboChangeToWO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpPrintLabel.SuspendLayout()
        Me.tpUpdateFreqBaudCap.SuspendLayout()
        CType(Me.cboUpdFreq_Customers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUpdFreq_NewBaud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUpdFreq_NewFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dbgDailyWeeklyProd
        '
        Me.dbgDailyWeeklyProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgDailyWeeklyProd.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgDailyWeeklyProd.Name = "dbgDailyWeeklyProd"
        Me.dbgDailyWeeklyProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgDailyWeeklyProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgDailyWeeklyProd.PreviewInfo.ZoomFactor = 75
        Me.dbgDailyWeeklyProd.TabIndex = 173
        Me.dbgDailyWeeklyProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
        "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
        "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
        "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
        "=""1""><Height>0</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
        " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
        "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
        "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
        """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
        "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
        "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
        "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
        "0, 0, 0</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
        "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
        """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
        "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
        "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
        "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
        "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
        "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
        "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
        "ut><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 0, 0</ClientArea" & _
        "><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" " & _
        "me=""Style15"" /></Blob>"
        '
        'chkPrintSkyTellLetter
        '
        Me.chkPrintSkyTellLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintSkyTellLetter.Location = New System.Drawing.Point(200, 448)
        Me.chkPrintSkyTellLetter.Name = "chkPrintSkyTellLetter"
        Me.chkPrintSkyTellLetter.Size = New System.Drawing.Size(187, 18)
        Me.chkPrintSkyTellLetter.TabIndex = 187
        Me.chkPrintSkyTellLetter.Text = "Print SkyTel Letter"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(552, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 20)
        Me.Label14.TabIndex = 178
        Me.Label14.Text = "WEEKLY"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(464, 8)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 20)
        Me.Label35.TabIndex = 181
        Me.Label35.Text = "DAILY"
        '
        'cmblblBaud
        '
        Me.cmblblBaud.Location = New System.Drawing.Point(200, 200)
        Me.cmblblBaud.Name = "cmblblBaud"
        Me.cmblblBaud.Size = New System.Drawing.Size(215, 21)
        Me.cmblblBaud.TabIndex = 186
        '
        'lbllblModel
        '
        Me.lbllblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllblModel.Location = New System.Drawing.Point(200, 224)
        Me.lbllblModel.Name = "lbllblModel"
        Me.lbllblModel.Size = New System.Drawing.Size(215, 23)
        Me.lbllblModel.TabIndex = 179
        Me.lbllblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPrintModelLetter
        '
        Me.chkPrintModelLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintModelLetter.Location = New System.Drawing.Point(200, 424)
        Me.chkPrintModelLetter.Name = "chkPrintModelLetter"
        Me.chkPrintModelLetter.Size = New System.Drawing.Size(187, 19)
        Me.chkPrintModelLetter.TabIndex = 180
        Me.chkPrintModelLetter.Text = "Print Model Letter"
        '
        'txtlblSN
        '
        Me.txtlblSN.Location = New System.Drawing.Point(200, 104)
        Me.txtlblSN.Name = "txtlblSN"
        Me.txtlblSN.Size = New System.Drawing.Size(215, 20)
        Me.txtlblSN.TabIndex = 160
        Me.txtlblSN.Text = ""
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(80, 104)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(112, 20)
        Me.Label31.TabIndex = 182
        Me.Label31.Text = "Serial Number:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbllblweekly
        '
        Me.lbllblweekly.BackColor = System.Drawing.Color.Black
        Me.lbllblweekly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbllblweekly.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblweekly.ForeColor = System.Drawing.Color.Lime
        Me.lbllblweekly.Location = New System.Drawing.Point(544, 8)
        Me.lbllblweekly.Name = "lbllblweekly"
        Me.lbllblweekly.Size = New System.Drawing.Size(94, 56)
        Me.lbllblweekly.TabIndex = 183
        Me.lbllblweekly.Text = "0"
        Me.lbllblweekly.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chklblPlus
        '
        Me.chklblPlus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklblPlus.Location = New System.Drawing.Point(200, 296)
        Me.chklblPlus.Name = "chklblPlus"
        Me.chklblPlus.Size = New System.Drawing.Size(187, 16)
        Me.chklblPlus.TabIndex = 184
        Me.chklblPlus.Text = "Plus (ST 800 only)"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(96, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 174
        Me.Label5.Text = "Baud Rate:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbllblDaily
        '
        Me.lbllblDaily.BackColor = System.Drawing.Color.Black
        Me.lbllblDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbllblDaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblDaily.ForeColor = System.Drawing.Color.Lime
        Me.lbllblDaily.Location = New System.Drawing.Point(440, 8)
        Me.lbllblDaily.Name = "lbllblDaily"
        Me.lbllblDaily.Size = New System.Drawing.Size(94, 56)
        Me.lbllblDaily.TabIndex = 175
        Me.lbllblDaily.Text = "0"
        Me.lbllblDaily.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lstModelType
        '
        Me.lstModelType.Items.AddRange(New Object() {"Motorola", "Unication"})
        Me.lstModelType.Location = New System.Drawing.Point(296, 392)
        Me.lstModelType.Name = "lstModelType"
        Me.lstModelType.Size = New System.Drawing.Size(119, 30)
        Me.lstModelType.TabIndex = 177
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(96, 168)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 21)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Frequency:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtlblCap
        '
        Me.txtlblCap.Location = New System.Drawing.Point(200, 136)
        Me.txtlblCap.Name = "txtlblCap"
        Me.txtlblCap.Size = New System.Drawing.Size(215, 20)
        Me.txtlblCap.TabIndex = 159
        Me.txtlblCap.Text = ""
        '
        'chklblND
        '
        Me.chklblND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklblND.Location = New System.Drawing.Point(200, 320)
        Me.chklblND.Name = "chklblND"
        Me.chklblND.Size = New System.Drawing.Size(215, 17)
        Me.chklblND.TabIndex = 176
        Me.chklblND.Text = "ND (AE Advisor Elite only)"
        '
        'chkClearData
        '
        Me.chkClearData.Checked = True
        Me.chkClearData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClearData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearData.Location = New System.Drawing.Point(200, 272)
        Me.chkClearData.Name = "chkClearData"
        Me.chkClearData.Size = New System.Drawing.Size(121, 16)
        Me.chkClearData.TabIndex = 185
        Me.chkClearData.Text = "Clear Data"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(112, 136)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 19)
        Me.Label15.TabIndex = 188
        Me.Label15.Text = "Cap Code:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(128, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 19)
        Me.Label11.TabIndex = 149
        Me.Label11.Text = "Model:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbllblCust
        '
        Me.lbllblCust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllblCust.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblCust.ForeColor = System.Drawing.Color.Black
        Me.lbllblCust.Location = New System.Drawing.Point(200, 248)
        Me.lbllblCust.Name = "lbllblCust"
        Me.lbllblCust.Size = New System.Drawing.Size(215, 24)
        Me.lbllblCust.TabIndex = 152
        Me.lbllblCust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(24, 248)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 19)
        Me.Label13.TabIndex = 151
        Me.Label13.Text = "Customer:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModelType
        '
        Me.lblModelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelType.Location = New System.Drawing.Point(200, 392)
        Me.lblModelType.Name = "lblModelType"
        Me.lblModelType.Size = New System.Drawing.Size(85, 20)
        Me.lblModelType.TabIndex = 158
        Me.lblModelType.Text = "Model Type:"
        Me.lblModelType.Visible = False
        '
        'cmdlblPrint
        '
        Me.cmdlblPrint.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdlblPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlblPrint.ForeColor = System.Drawing.Color.White
        Me.cmdlblPrint.Location = New System.Drawing.Point(200, 480)
        Me.cmdlblPrint.Name = "cmdlblPrint"
        Me.cmdlblPrint.Size = New System.Drawing.Size(215, 38)
        Me.cmdlblPrint.TabIndex = 14
        Me.cmdlblPrint.Text = "PRINT (F12)"
        '
        'msklblFreq
        '
        Me.msklblFreq.ContainingControl = Me
        Me.msklblFreq.Location = New System.Drawing.Point(200, 168)
        Me.msklblFreq.Name = "msklblFreq"
        Me.msklblFreq.OcxState = CType(resources.GetObject("msklblFreq.OcxState"), System.Windows.Forms.AxHost.State)
        Me.msklblFreq.Size = New System.Drawing.Size(215, 22)
        Me.msklblFreq.TabIndex = 6
        '
        'cboLabelType
        '
        Me.cboLabelType.Items.AddRange(New Object() {"Label", "Relabel"})
        Me.cboLabelType.Location = New System.Drawing.Point(200, 40)
        Me.cboLabelType.Name = "cboLabelType"
        Me.cboLabelType.Size = New System.Drawing.Size(215, 21)
        Me.cboLabelType.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(80, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 19)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Label Type:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCusts
        '
        Me.lblCusts.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCusts.ForeColor = System.Drawing.Color.Black
        Me.lblCusts.Location = New System.Drawing.Point(80, 8)
        Me.lblCusts.Name = "lblCusts"
        Me.lblCusts.Size = New System.Drawing.Size(112, 24)
        Me.lblCusts.TabIndex = 166
        Me.lblCusts.Text = "Customer:"
        Me.lblCusts.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboCustomers
        '
        Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomers.Caption = ""
        Me.cboCustomers.CaptionHeight = 17
        Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomers.ColumnCaptionHeight = 17
        Me.cboCustomers.ColumnFooterHeight = 17
        Me.cboCustomers.ContentHeight = 15
        Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomers.EditorHeight = 15
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(200, 8)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(215, 21)
        Me.cboCustomers.TabIndex = 1
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(200, 72)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(215, 21)
        Me.cboModels.TabIndex = 3
        Me.cboModels.Visible = False
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'lblModels
        '
        Me.lblModels.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModels.ForeColor = System.Drawing.Color.Black
        Me.lblModels.Location = New System.Drawing.Point(80, 72)
        Me.lblModels.Name = "lblModels"
        Me.lblModels.Size = New System.Drawing.Size(112, 19)
        Me.lblModels.TabIndex = 168
        Me.lblModels.Text = "Model:"
        Me.lblModels.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblModels.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.AddRange(New Object() {"A06CQB5812AA", "A06GJB5806AA", "A06CXB5806BA", "A06FXB5806AA"})
        Me.ComboBox1.Location = New System.Drawing.Point(296, 352)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(116, 21)
        Me.ComboBox1.TabIndex = 169
        Me.ComboBox1.Text = "--Model Number--"
        Me.ComboBox1.Visible = False
        '
        'chkNoLabelPrintOut
        '
        Me.chkNoLabelPrintOut.BackColor = System.Drawing.Color.Transparent
        Me.chkNoLabelPrintOut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoLabelPrintOut.ForeColor = System.Drawing.Color.Black
        Me.chkNoLabelPrintOut.Location = New System.Drawing.Point(80, 488)
        Me.chkNoLabelPrintOut.Name = "chkNoLabelPrintOut"
        Me.chkNoLabelPrintOut.Size = New System.Drawing.Size(112, 18)
        Me.chkNoLabelPrintOut.TabIndex = 170
        Me.chkNoLabelPrintOut.Text = "No Label"
        '
        'chkOverrideCapcode
        '
        Me.chkOverrideCapcode.Location = New System.Drawing.Point(440, 80)
        Me.chkOverrideCapcode.Name = "chkOverrideCapcode"
        Me.chkOverrideCapcode.Size = New System.Drawing.Size(144, 24)
        Me.chkOverrideCapcode.TabIndex = 172
        Me.chkOverrideCapcode.Text = "Override Capcode"
        Me.chkOverrideCapcode.Visible = False
        '
        'chkBackgroudBlack
        '
        Me.chkBackgroudBlack.BackColor = System.Drawing.Color.Black
        Me.chkBackgroudBlack.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBackgroudBlack.ForeColor = System.Drawing.Color.White
        Me.chkBackgroudBlack.Location = New System.Drawing.Point(424, 494)
        Me.chkBackgroudBlack.Name = "chkBackgroudBlack"
        Me.chkBackgroudBlack.Size = New System.Drawing.Size(190, 18)
        Me.chkBackgroudBlack.TabIndex = 173
        Me.chkBackgroudBlack.Text = "Label Background in Black"
        '
        'gbShareableInvData
        '
        Me.gbShareableInvData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSaveNewCust, Me.cboChangeToCust, Me.Label2})
        Me.gbShareableInvData.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbShareableInvData.Location = New System.Drawing.Point(440, 120)
        Me.gbShareableInvData.Name = "gbShareableInvData"
        Me.gbShareableInvData.Size = New System.Drawing.Size(416, 64)
        Me.gbShareableInvData.TabIndex = 174
        Me.gbShareableInvData.TabStop = False
        Me.gbShareableInvData.Visible = False
        '
        'btnSaveNewCust
        '
        Me.btnSaveNewCust.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSaveNewCust.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveNewCust.ForeColor = System.Drawing.Color.White
        Me.btnSaveNewCust.Location = New System.Drawing.Point(240, 30)
        Me.btnSaveNewCust.Name = "btnSaveNewCust"
        Me.btnSaveNewCust.Size = New System.Drawing.Size(91, 24)
        Me.btnSaveNewCust.TabIndex = 176
        Me.btnSaveNewCust.Text = "SAVE"
        '
        'cboChangeToCust
        '
        Me.cboChangeToCust.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboChangeToCust.Caption = ""
        Me.cboChangeToCust.CaptionHeight = 17
        Me.cboChangeToCust.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboChangeToCust.ColumnCaptionHeight = 17
        Me.cboChangeToCust.ColumnFooterHeight = 17
        Me.cboChangeToCust.ContentHeight = 15
        Me.cboChangeToCust.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboChangeToCust.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboChangeToCust.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboChangeToCust.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboChangeToCust.EditorHeight = 15
        Me.cboChangeToCust.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboChangeToCust.ItemHeight = 15
        Me.cboChangeToCust.Location = New System.Drawing.Point(8, 32)
        Me.cboChangeToCust.MatchEntryTimeout = CType(2000, Long)
        Me.cboChangeToCust.MaxDropDownItems = CType(5, Short)
        Me.cboChangeToCust.MaxLength = 32767
        Me.cboChangeToCust.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboChangeToCust.Name = "cboChangeToCust"
        Me.cboChangeToCust.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboChangeToCust.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboChangeToCust.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboChangeToCust.Size = New System.Drawing.Size(215, 21)
        Me.cboChangeToCust.TabIndex = 167
        Me.cboChangeToCust.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 20)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "Change to Customer:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dbgAvailableCapCodeList
        '
        Me.dbgAvailableCapCodeList.AllowUpdate = False
        Me.dbgAvailableCapCodeList.AlternatingRows = True
        Me.dbgAvailableCapCodeList.FilterBar = True
        Me.dbgAvailableCapCodeList.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgAvailableCapCodeList.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.dbgAvailableCapCodeList.Location = New System.Drawing.Point(440, 192)
        Me.dbgAvailableCapCodeList.Name = "dbgAvailableCapCodeList"
        Me.dbgAvailableCapCodeList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgAvailableCapCodeList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgAvailableCapCodeList.PreviewInfo.ZoomFactor = 75
        Me.dbgAvailableCapCodeList.Size = New System.Drawing.Size(224, 272)
        Me.dbgAvailableCapCodeList.TabIndex = 175
        Me.dbgAvailableCapCodeList.TabStop = False
        Me.dbgAvailableCapCodeList.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
        "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
        "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
        "le11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:" & _
        "HighlightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Sty" & _
        "le21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;" & _
        "}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised" & _
        ",,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft S" & _
        "ans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Sty" & _
        "le8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Cente" & _
        "r;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1Tru" & _
        "eDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCa" & _
        "ptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCe" & _
        "llBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" H" & _
        "orizontalScrollGroup=""1""><Height>268</Height><CaptionStyle parent=""Style2"" me=""S" & _
        "tyle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenR" & _
        "ow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle" & _
        " parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Headin" & _
        "gStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" m" & _
        "e=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=" & _
        """OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11""" & _
        " /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Sty" & _
        "le1"" /><ClientRect>0, 0, 220, 268</ClientRect><BorderSide>0</BorderSide><BorderS" & _
        "tyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><" & _
        "Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style paren" & _
        "t=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""" & _
        "Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""N" & _
        "ormal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""N" & _
        "ormal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headin" & _
        "g"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""" & _
        "Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</hor" & _
        "zSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientA" & _
        "rea>0, 0, 220, 268</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><P" & _
        "rintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
        '
        'cboChangeToWO
        '
        Me.cboChangeToWO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboChangeToWO.Caption = ""
        Me.cboChangeToWO.CaptionHeight = 17
        Me.cboChangeToWO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboChangeToWO.ColumnCaptionHeight = 17
        Me.cboChangeToWO.ColumnFooterHeight = 17
        Me.cboChangeToWO.ContentHeight = 15
        Me.cboChangeToWO.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboChangeToWO.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboChangeToWO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboChangeToWO.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboChangeToWO.EditorHeight = 15
        Me.cboChangeToWO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboChangeToWO.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.cboChangeToWO.ItemHeight = 15
        Me.cboChangeToWO.Location = New System.Drawing.Point(8, 80)
        Me.cboChangeToWO.MatchEntryTimeout = CType(2000, Long)
        Me.cboChangeToWO.MaxDropDownItems = CType(5, Short)
        Me.cboChangeToWO.MaxLength = 32767
        Me.cboChangeToWO.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboChangeToWO.Name = "cboChangeToWO"
        Me.cboChangeToWO.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboChangeToWO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboChangeToWO.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboChangeToWO.Size = New System.Drawing.Size(215, 21)
        Me.cboChangeToWO.TabIndex = 177
        Me.cboChangeToWO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpPrintLabel, Me.tpUpdateFreqBaudCap})
        Me.TabControl1.Location = New System.Drawing.Point(16, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(912, 592)
        Me.TabControl1.TabIndex = 176
        '
        'tpPrintLabel
        '
        Me.tpPrintLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tpPrintLabel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label32, Me.lblModelType, Me.txtlblCap, Me.cboLabelType, Me.txtlblSN, Me.chkOverrideCapcode, Me.dbgDailyWeeklyProd, Me.Label5, Me.Label1, Me.chklblND, Me.lblCusts, Me.lstModelType, Me.msklblFreq, Me.Label14, Me.lblModels, Me.lbllblModel, Me.chkPrintModelLetter, Me.Label35, Me.ComboBox1, Me.lbllblCust, Me.Label31, Me.dbgAvailableCapCodeList, Me.lbllblweekly, Me.cmdlblPrint, Me.chklblPlus, Me.chkClearData, Me.cmblblBaud, Me.chkPrintSkyTellLetter, Me.chkBackgroudBlack, Me.cboCustomers, Me.gbShareableInvData, Me.cboModels, Me.Label15, Me.Label11, Me.chkNoLabelPrintOut, Me.Label13, Me.lbllblDaily})
        Me.tpPrintLabel.Location = New System.Drawing.Point(4, 22)
        Me.tpPrintLabel.Name = "tpPrintLabel"
        Me.tpPrintLabel.Size = New System.Drawing.Size(904, 566)
        Me.tpPrintLabel.TabIndex = 0
        Me.tpPrintLabel.Text = "Label"
        '
        'tpUpdateFreqBaudCap
        '
        Me.tpUpdateFreqBaudCap.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdFreq_Save, Me.lblUpdFreq_Customers, Me.cboUpdFreq_Customers, Me.Label51, Me.txtUpdFreq_NewCapCode, Me.cboUpdFreq_NewBaud, Me.Label50, Me.cboUpdFreq_NewFreq, Me.lblFreq, Me.lblUpdFreq_CapCode, Me.Label16, Me.lblUpdFreq_Baud, Me.Label10, Me.lblUpdFreq_Model, Me.lblUpdFreq_Freq, Me.Label7, Me.Label8, Me.txtUpdFreq_SN, Me.Label3})
        Me.tpUpdateFreqBaudCap.Location = New System.Drawing.Point(4, 22)
        Me.tpUpdateFreqBaudCap.Name = "tpUpdateFreqBaudCap"
        Me.tpUpdateFreqBaudCap.Size = New System.Drawing.Size(904, 566)
        Me.tpUpdateFreqBaudCap.TabIndex = 1
        Me.tpUpdateFreqBaudCap.Text = "Update Freq, Baud and Cap Code"
        '
        'btnUpdFreq_Save
        '
        Me.btnUpdFreq_Save.BackColor = System.Drawing.Color.SteelBlue
        Me.btnUpdFreq_Save.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdFreq_Save.ForeColor = System.Drawing.Color.White
        Me.btnUpdFreq_Save.Location = New System.Drawing.Point(176, 312)
        Me.btnUpdFreq_Save.Name = "btnUpdFreq_Save"
        Me.btnUpdFreq_Save.Size = New System.Drawing.Size(215, 38)
        Me.btnUpdFreq_Save.TabIndex = 170
        Me.btnUpdFreq_Save.Text = "SAVE"
        '
        'lblUpdFreq_Customers
        '
        Me.lblUpdFreq_Customers.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdFreq_Customers.ForeColor = System.Drawing.Color.Black
        Me.lblUpdFreq_Customers.Location = New System.Drawing.Point(56, 16)
        Me.lblUpdFreq_Customers.Name = "lblUpdFreq_Customers"
        Me.lblUpdFreq_Customers.Size = New System.Drawing.Size(112, 20)
        Me.lblUpdFreq_Customers.TabIndex = 169
        Me.lblUpdFreq_Customers.Text = "Customer:"
        Me.lblUpdFreq_Customers.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboUpdFreq_Customers
        '
        Me.cboUpdFreq_Customers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboUpdFreq_Customers.Caption = ""
        Me.cboUpdFreq_Customers.CaptionHeight = 17
        Me.cboUpdFreq_Customers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUpdFreq_Customers.ColumnCaptionHeight = 17
        Me.cboUpdFreq_Customers.ColumnFooterHeight = 17
        Me.cboUpdFreq_Customers.ContentHeight = 15
        Me.cboUpdFreq_Customers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboUpdFreq_Customers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboUpdFreq_Customers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdFreq_Customers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboUpdFreq_Customers.EditorHeight = 15
        Me.cboUpdFreq_Customers.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
        Me.cboUpdFreq_Customers.ItemHeight = 15
        Me.cboUpdFreq_Customers.Location = New System.Drawing.Point(176, 16)
        Me.cboUpdFreq_Customers.MatchEntryTimeout = CType(2000, Long)
        Me.cboUpdFreq_Customers.MaxDropDownItems = CType(5, Short)
        Me.cboUpdFreq_Customers.MaxLength = 32767
        Me.cboUpdFreq_Customers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboUpdFreq_Customers.Name = "cboUpdFreq_Customers"
        Me.cboUpdFreq_Customers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboUpdFreq_Customers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboUpdFreq_Customers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboUpdFreq_Customers.Size = New System.Drawing.Size(215, 21)
        Me.cboUpdFreq_Customers.TabIndex = 0
        Me.cboUpdFreq_Customers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(64, 256)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(104, 18)
        Me.Label51.TabIndex = 167
        Me.Label51.Text = "New Cap Code :"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUpdFreq_NewCapCode
        '
        Me.txtUpdFreq_NewCapCode.BackColor = System.Drawing.Color.White
        Me.txtUpdFreq_NewCapCode.Location = New System.Drawing.Point(176, 256)
        Me.txtUpdFreq_NewCapCode.MaxLength = 15
        Me.txtUpdFreq_NewCapCode.Name = "txtUpdFreq_NewCapCode"
        Me.txtUpdFreq_NewCapCode.Size = New System.Drawing.Size(160, 20)
        Me.txtUpdFreq_NewCapCode.TabIndex = 4
        Me.txtUpdFreq_NewCapCode.Text = ""
        '
        'cboUpdFreq_NewBaud
        '
        Me.cboUpdFreq_NewBaud.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboUpdFreq_NewBaud.AutoCompletion = True
        Me.cboUpdFreq_NewBaud.AutoDropDown = True
        Me.cboUpdFreq_NewBaud.AutoSelect = True
        Me.cboUpdFreq_NewBaud.Caption = ""
        Me.cboUpdFreq_NewBaud.CaptionHeight = 17
        Me.cboUpdFreq_NewBaud.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUpdFreq_NewBaud.ColumnCaptionHeight = 17
        Me.cboUpdFreq_NewBaud.ColumnFooterHeight = 17
        Me.cboUpdFreq_NewBaud.ColumnHeaders = False
        Me.cboUpdFreq_NewBaud.ContentHeight = 15
        Me.cboUpdFreq_NewBaud.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboUpdFreq_NewBaud.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboUpdFreq_NewBaud.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdFreq_NewBaud.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboUpdFreq_NewBaud.EditorHeight = 15
        Me.cboUpdFreq_NewBaud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdFreq_NewBaud.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
        Me.cboUpdFreq_NewBaud.ItemHeight = 15
        Me.cboUpdFreq_NewBaud.Location = New System.Drawing.Point(176, 224)
        Me.cboUpdFreq_NewBaud.MatchEntryTimeout = CType(2000, Long)
        Me.cboUpdFreq_NewBaud.MaxDropDownItems = CType(10, Short)
        Me.cboUpdFreq_NewBaud.MaxLength = 32767
        Me.cboUpdFreq_NewBaud.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboUpdFreq_NewBaud.Name = "cboUpdFreq_NewBaud"
        Me.cboUpdFreq_NewBaud.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboUpdFreq_NewBaud.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboUpdFreq_NewBaud.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboUpdFreq_NewBaud.Size = New System.Drawing.Size(160, 21)
        Me.cboUpdFreq_NewBaud.TabIndex = 3
        Me.cboUpdFreq_NewBaud.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(72, 224)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(96, 14)
        Me.Label50.TabIndex = 166
        Me.Label50.Text = "New Baud :"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboUpdFreq_NewFreq
        '
        Me.cboUpdFreq_NewFreq.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboUpdFreq_NewFreq.AutoCompletion = True
        Me.cboUpdFreq_NewFreq.AutoDropDown = True
        Me.cboUpdFreq_NewFreq.AutoSelect = True
        Me.cboUpdFreq_NewFreq.Caption = ""
        Me.cboUpdFreq_NewFreq.CaptionHeight = 17
        Me.cboUpdFreq_NewFreq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUpdFreq_NewFreq.ColumnCaptionHeight = 17
        Me.cboUpdFreq_NewFreq.ColumnFooterHeight = 17
        Me.cboUpdFreq_NewFreq.ColumnHeaders = False
        Me.cboUpdFreq_NewFreq.ContentHeight = 15
        Me.cboUpdFreq_NewFreq.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboUpdFreq_NewFreq.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboUpdFreq_NewFreq.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdFreq_NewFreq.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboUpdFreq_NewFreq.EditorHeight = 15
        Me.cboUpdFreq_NewFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUpdFreq_NewFreq.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
        Me.cboUpdFreq_NewFreq.ItemHeight = 15
        Me.cboUpdFreq_NewFreq.Location = New System.Drawing.Point(176, 192)
        Me.cboUpdFreq_NewFreq.MatchEntryTimeout = CType(2000, Long)
        Me.cboUpdFreq_NewFreq.MaxDropDownItems = CType(10, Short)
        Me.cboUpdFreq_NewFreq.MaxLength = 32767
        Me.cboUpdFreq_NewFreq.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboUpdFreq_NewFreq.Name = "cboUpdFreq_NewFreq"
        Me.cboUpdFreq_NewFreq.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboUpdFreq_NewFreq.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboUpdFreq_NewFreq.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboUpdFreq_NewFreq.Size = New System.Drawing.Size(160, 21)
        Me.cboUpdFreq_NewFreq.TabIndex = 2
        Me.cboUpdFreq_NewFreq.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
        "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
        "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
        "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
        ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
        "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
        'lblFreq
        '
        Me.lblFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFreq.Location = New System.Drawing.Point(80, 192)
        Me.lblFreq.Name = "lblFreq"
        Me.lblFreq.Size = New System.Drawing.Size(88, 21)
        Me.lblFreq.TabIndex = 165
        Me.lblFreq.Text = "New Freq :"
        Me.lblFreq.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUpdFreq_CapCode
        '
        Me.lblUpdFreq_CapCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpdFreq_CapCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdFreq_CapCode.ForeColor = System.Drawing.Color.Black
        Me.lblUpdFreq_CapCode.Location = New System.Drawing.Point(176, 152)
        Me.lblUpdFreq_CapCode.Name = "lblUpdFreq_CapCode"
        Me.lblUpdFreq_CapCode.Size = New System.Drawing.Size(215, 24)
        Me.lblUpdFreq_CapCode.TabIndex = 161
        Me.lblUpdFreq_CapCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(88, 152)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 19)
        Me.Label16.TabIndex = 160
        Me.Label16.Text = "Cap Code :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUpdFreq_Baud
        '
        Me.lblUpdFreq_Baud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpdFreq_Baud.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdFreq_Baud.ForeColor = System.Drawing.Color.Black
        Me.lblUpdFreq_Baud.Location = New System.Drawing.Point(176, 128)
        Me.lblUpdFreq_Baud.Name = "lblUpdFreq_Baud"
        Me.lblUpdFreq_Baud.Size = New System.Drawing.Size(215, 24)
        Me.lblUpdFreq_Baud.TabIndex = 159
        Me.lblUpdFreq_Baud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(88, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 19)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Baud Rate :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUpdFreq_Model
        '
        Me.lblUpdFreq_Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpdFreq_Model.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdFreq_Model.ForeColor = System.Drawing.Color.Black
        Me.lblUpdFreq_Model.Location = New System.Drawing.Point(176, 80)
        Me.lblUpdFreq_Model.Name = "lblUpdFreq_Model"
        Me.lblUpdFreq_Model.Size = New System.Drawing.Size(215, 23)
        Me.lblUpdFreq_Model.TabIndex = 157
        Me.lblUpdFreq_Model.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUpdFreq_Freq
        '
        Me.lblUpdFreq_Freq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUpdFreq_Freq.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdFreq_Freq.ForeColor = System.Drawing.Color.Black
        Me.lblUpdFreq_Freq.Location = New System.Drawing.Point(176, 104)
        Me.lblUpdFreq_Freq.Name = "lblUpdFreq_Freq"
        Me.lblUpdFreq_Freq.Size = New System.Drawing.Size(215, 24)
        Me.lblUpdFreq_Freq.TabIndex = 156
        Me.lblUpdFreq_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(104, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 19)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "Model :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(88, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 19)
        Me.Label8.TabIndex = 155
        Me.Label8.Text = "Freq :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUpdFreq_SN
        '
        Me.txtUpdFreq_SN.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtUpdFreq_SN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdFreq_SN.Location = New System.Drawing.Point(176, 48)
        Me.txtUpdFreq_SN.Name = "txtUpdFreq_SN"
        Me.txtUpdFreq_SN.Size = New System.Drawing.Size(215, 20)
        Me.txtUpdFreq_SN.TabIndex = 1
        Me.txtUpdFreq_SN.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(56, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Serial Number :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmMessLabel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(952, 622)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmMessLabel"
        Me.Text = "frmMessLabel"
        CType(Me.dbgDailyWeeklyProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msklblFreq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbShareableInvData.ResumeLayout(False)
        CType(Me.cboChangeToCust, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgAvailableCapCodeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboChangeToWO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpPrintLabel.ResumeLayout(False)
        Me.tpUpdateFreqBaudCap.ResumeLayout(False)
        CType(Me.cboUpdFreq_Customers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUpdFreq_NewBaud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUpdFreq_NewFreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Label"
    '*********************************************************
    Private Sub ClearPage_Label()
        Me.txtlblSN.Text = ""
        Me.txtlblCap.Text = ""
        SetFreqMaskControlText_Label()
        Me.cmblblBaud.SelectedValue = 0
        Me.lbllblModel.Text = ""
        Me.lbllblCust.Text = ""
        Me.lbllblModel.Tag = 0

        Me.HideShowLableOption()
        Me.lstModelType.SelectedIndex = -1

        If Not IsNothing(_objMessLabel) Then
            With Me._objMessLabel
                .ModelID = 0
                .DeviceID = 0
                .DeviceOldSN = ""
                .DeviceSN = ""

                .FreqID = 0
                .Frequency = ""
                .OldFreqID = 0

                .BaudID = 0
                .OldBaudID = 0

                .CapCode = ""
                .OldCapCode = ""
                .CustID = 0

                .ModelTypeLetter = ""
                .ModelType = ""
            End With
        End If

        Me.dbgAvailableCapCodeList.DataSource = Nothing
        Me.dbgAvailableCapCodeList.Caption = ""

        If _iReserveCapcodeID > 0 Then
            Me._objMessLabel.ResetReserveCapcode(_iReserveCapcodeID)
        End If

        _iReserveCapcodeID = 0
    End Sub

    '*********************************************************
    Private Sub txtlblSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlblSN.KeyUp

        If e.KeyValue = 13 Then             'Carriage Return
            If Trim(Me.txtlblSN.Text) = "" Then
                Exit Sub
            ElseIf Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtlblSN.Text = ""
                Me.cboCustomers.Focus()
            ElseIf Me.cboLabelType.SelectedIndex < 0 Then
                MessageBox.Show("Please select label type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtlblSN.Text = ""
                Me.cboLabelType.Focus()
            End If
            Me.ComboBox1.Visible = False
            If Me.cboLabelType.SelectedIndex = 0 Then
                FillLabelInfo_Label()
            End If

            If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
               OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
               OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
               OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
               OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
               OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                Me.cmblblBaud.Focus()
            Else
                Me.txtlblCap.Focus()
            End If

            'Me.txtlblCap.Focus()
        ElseIf e.KeyValue = 123 Then        'F12
            'DoPrint()
            Me.txtlblCap.Focus()
        End If
    End Sub

    '*********************************************************
    Private Sub ShowHideOptionals_Label(ByVal imodel_id As Integer)
        chklblPlus.Visible = False
        chklblND.Visible = False

        Select Case imodel_id
            Case 276    'ST800-
                chklblPlus.Visible = False
                chklblPlus.Checked = True
            Case 3      'AE-Advisor Elite
                chklblND.Visible = True
            Case 2      'AG-Advisor Gold
                chklblND.Visible = True
        End Select

        ShowHideTwoWay(imodel_id)
    End Sub

    '*********************************************************
    Private Sub FillLabelInfo_Label()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim strSN As String = ""

        Try
            strSN = Me.txtlblSN.Text
            ClearPage_Label()
            Me.txtlblSN.Text = strSN
            dt1 = Me._objMessLabel.GetMessDeviceInfoForLabel(Trim(Me.txtlblSN.Text), Me.cboCustomers.SelectedValue)

            For Each R1 In dt1.Rows

                'Cap code
                If Not IsDBNull(R1("capcode")) Then
                    Me.txtlblCap.Text = Trim(R1("capcode"))
                    Me._objMessLabel.CapCode = Trim(R1("capcode"))
                Else
                    Me.txtlblCap.Text = ""
                    Me._objMessLabel.CapCode = ""
                End If

                'Frequency
                If Not IsDBNull(R1("freq_Number")) Then
                    Me.SetFreqMaskControlText_Label(Trim(R1("freq_number")))
                    Me._objMessLabel.Frequency = Trim(R1("freq_number"))
                Else
                    SetFreqMaskControlText_Label()
                    Me._objMessLabel.Frequency = ""
                End If

                'FreqID
                If Not IsDBNull(R1("Freq_id")) Then
                    Me._objMessLabel.FreqID = R1("Freq_id")
                    If CInt(R1("Freq_id")) > 0 Then Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                Else
                    Me._objMessLabel.FreqID = 0
                    Me.dbgAvailableCapCodeList.DataSource = Nothing
                End If

                'Baud_ID
                If Not IsDBNull(R1("baud_id")) Then
                    Me.cmblblBaud.SelectedValue = R1("baud_id")
                    Me._objMessLabel.BaudID = R1("baud_id")
                Else
                    Me.cmblblBaud.SelectedValue = 0
                    Me._objMessLabel.BaudID = 0
                End If

                'OldCapCode
                If Not IsDBNull(R1("capcode_old")) Then
                    Me._objMessLabel.OldCapCode = R1("capcode_old")
                Else
                    Me._objMessLabel.OldCapCode = ""
                End If

                'OldBaudID
                If Not IsDBNull(R1("baud_id_old")) Then
                    Me._objMessLabel.OldBaudID = R1("baud_id_old")
                Else
                    Me._objMessLabel.OldBaudID = 0
                End If

                'OldFreqID
                If Not IsDBNull(R1("freq_id_old")) Then
                    Me._objMessLabel.OldFreqID = R1("freq_id_old")
                Else
                    Me._objMessLabel.OldFreqID = 0
                End If

                'Model
                If Not IsDBNull(R1("model_desc")) Then
                    Me.lbllblModel.Text = Trim(R1("model_desc"))
                    Me.lbllblModel.Tag = 0
                    Me.lbllblModel.Tag = R1("model_id")
                Else
                    Me.lbllblModel.Text = ""
                End If

                'Model_ID
                If Not IsDBNull(R1("model_id")) Then
                    ShowHideOptionals_Label(R1("model_id"))
                End If

                'Customer
                Me.Label13.Text = "Customer:"
                If Not IsDBNull(R1("cust_name1")) Then
                    If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID Then
                        Me.lbllblCust.Text = Trim(R1("cust_name1")) & " - " & R1("Loc_Name")
                        Me.Label13.Text = "Customer - Location:"

                    Else
                        Me.lbllblCust.Text = Trim(R1("cust_name1"))
                    End If
                Else
                    Me.lbllblCust.Text = ""
                End If

                'CustID
                If Not IsDBNull(R1("cust_id")) Then
                    Me._objMessLabel.CustID = R1("cust_id")
                    Me._iLocID = R1("Loc_ID")
                Else
                    Me._objMessLabel.CustID = 0
                    Me._iLocID = 0
                End If

                Exit For
            Next R1

            If Me.msklblFreq.Text.Trim.Length > 0 AndAlso Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(Me.cboCustomers.SelectedValue) Then
                LoadShareableInvCustList()
            End If
            '*****************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "SN Scan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt1) : R1 = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdlblPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlblPrint.Click
        DoPrint()
    End Sub

    '*********************************************************
    Private Sub DoPrint()
        Dim i As Integer = 0, j As Integer = 0, iWipOwnerID As Integer = 0, iDeviceID As Integer
        Dim strND As String = "", strPlus As String = "", strModelNumber As String = ""
        Dim booPrintNoLabel As Boolean = False
        Dim objMess As PSS.Data.Buisness.Messaging
        Dim objMessRpt As New PSS.Data.Buisness.MessReports()
        Dim dt As DataTable
        Dim tmpArray() As String
        Dim strS As String = ""

        Try
            iDeviceID = Me._objMessLabel.DeviceID
            '*******************************************
            'Validate capcode added on 0813/09
            ''*******************************************
            Me.txtlblCap.Text = Me.txtlblCap.Text.Trim
            'Select Case Me.lbllblModel.Tag
            '    Case 1121, 1110, 87, 808, 76, 130, 1142
            '        For i = 1 To Me.txtlblCap.Text.Length
            '            If Char.IsDigit(CChar(Mid(Me.txtlblCap.Text, i, 1))) = False Then
            '                MessageBox.Show("This model does not allow to have any letter in the capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '                Me.txtlblCap.Focus()
            '                Exit Sub
            '            End If
            '        Next i
            'End Select
            strS = ModManuf.GetExceptionCriteria("AMS_CAPCODE_NOLETTER", "ModelIDs").Trim
            tmpArray = Split(strS, ",")
            If tmpArray.Length > 0 Then
                For j = 0 To tmpArray.Length - 1
                    If tmpArray(j) = Me.lbllblModel.Tag Then
                        For i = 1 To Me.txtlblCap.Text.Length
                            If Char.IsDigit(CChar(Mid(Me.txtlblCap.Text, i, 1))) = False Then
                                MessageBox.Show("This model does not allow to have any letter in the capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtlblCap.Focus()
                                Exit Sub
                            End If
                        Next i
                    End If
                Next j
            End If


            '********************************************
            'Validate Freq 09/12/2011 06/23/2014
            ''*******************************************
            If Me.msklblFreq.CtlText.IndexOfAny("_") <> -1 Or Me.msklblFreq.CtlText.IndexOf("000.0000") <> -1 Then
                MessageBox.Show("The Frequency is not valid. Please enter 7 digits number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Me._objMessLabel.IsFreqExisted(Trim(Me.msklblFreq.CtlText)) = False Then
                If MessageBox.Show("The Frequency: " & Trim(Me.msklblFreq.CtlText) & " is not found in the system. Click 'YES' to add this new frequency and continue print label, click 'NO' to cancel.", "Frequency Not Found !", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                Else
                    Me._objMessLabel.InsertFreq(Trim(Me.msklblFreq.CtlText), 0)
                End If
            End If


            '########  CHECK DEMAND QTY (FC,Prodiced)  ########******************************************************************************
            If Me._booIsAMSShareableInvCust = True _
               AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
               AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
               AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
               AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
               AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
               AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                'Validate Label, QC and Produce Number vs FC + 5%
                If objMessRpt.CheckFCDemand(UCase(Trim(Me.txtlblSN.Text)), Me.cboCustomers.SelectedValue, Me._iLocID, Trim(Me.msklblFreq.CtlText), Me.cmblblBaud.SelectedValue) = False Then Exit Sub
                '**********************************
                'Get Wipowner for Messaging
                '**********************************
                iWipOwnerID = Data.Buisness.MessReceive.GetAMSNextWipOwner(Me.cboCustomers.SelectedValue, Me._strScreenName, 0)
                '**********************************
            End If
            '########  ********************************************************************************************************


            If Me.chklblND.Checked Then
                strND = "ND"
            Else
                strND = ""
            End If
            If Me.cboModels.SelectedValue = 276 Then
                strPlus = "PLUS"
            Else
                If Me.chklblPlus.Checked Then
                    strPlus = "PLUS"
                Else
                    strPlus = ""
                End If
            End If

            If (Me.cboModels.SelectedValue = 76 Or Me.lbllblModel.Tag = 76) Then
                'Me.ComboBox1.Visible = True
                If (Me.ComboBox1.SelectedIndex = -1) Then
                    MessageBox.Show("Please select model number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.ComboBox1.Focus()
                    Exit Sub
                Else
                    strModelNumber = Me.ComboBox1.SelectedItem
                End If
            Else
                Me.ComboBox1.Visible = False
            End If

            If Me.chkNoLabelPrintOut.Checked = True Then booPrintNoLabel = True

            '*****************************************************
            If Me._booIsAMSShareableInvCust Then Me._objMessLabel.ReleaseCapcode(iDeviceID)
            If Me._iReserveCapcodeID > 0 Then
                dt = Me._objMessLabel.GetCapcode(Me._iReserveCapcodeID)
                If dt.Rows.Count > 0 AndAlso (dt.Rows(0)("Capcode").ToString.Trim.ToLower = Me.txtlblCap.Text.Trim.ToLower OrElse Me._objMessLabel.ReservedCapCode_Reset.Trim.ToLower = Me.txtlblCap.Text.Trim.ToLower) Then
                    If dt.Rows(0)("Cust_ID") <> Me.cboCustomers.SelectedValue Then
                        MessageBox.Show("New capcode does not belong to selected customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf CInt(dt.Rows(0)("Device_ID")) > 0 Then
                        MessageBox.Show("Capcode is used by another device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf CInt(dt.Rows(0)("Reserve")) = 1 AndAlso CInt(dt.Rows(0)("Reserve_UserID")) <> Core.ApplicationUser.IDuser Then
                        MessageBox.Show("Capcode is reserved for another user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Else
                    Me._objMessLabel.ResetReserveCapcode(_iReserveCapcodeID) : _iReserveCapcodeID = 0
                End If
            End If

            If _iReserveCapcodeID = 0 Then
                dt = Me._objMessLabel.GetAvailableCapcodeByCapcode(Me.txtlblCap.Text.Trim)
                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate capcode in customer-freq-capcode set up.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf dt.Rows.Count > 0 Then
                    If Me.cboCustomers.SelectedValue <> dt.Rows(0)("Cust_ID") Then
                        MessageBox.Show("Capcode belongs to customer '" & dt.Rows(0)("Cust_Name1") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf dt.Rows(0)("Freq_Number").ToString.Trim.ToLower <> Trim(Me.msklblFreq.CtlText).Trim.ToLower Then
                        MessageBox.Show("Capcode belongs to frequency '" & dt.Rows(0)("Freq_Number") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf CInt(dt.Rows(0)("Reserve")) = 1 AndAlso CInt(dt.Rows(0)("Reserve_UserID")) <> Core.ApplicationUser.IDuser Then
                        MessageBox.Show("Capcode is reserved for another user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    Else
                        _iReserveCapcodeID = dt.Rows(0)("FCP_ID")
                    End If
                End If
            End If

            '*****************************************************

            If Me.cboLabelType.SelectedIndex = 0 Then 'LABEL
                ' Aquis customer only : No duplicate capcode allow

                If Me.chkOverrideCapcode.Checked = False Then
                    If cboCustomers.SelectedValue = 444 Then
                        objMess = New PSS.Data.Buisness.Messaging()
                        If objMess.IsCapCodeExist(442, Me.txtlblCap.Text) = True Then
                            MessageBox.Show("The Aquis capcode:" & Me.txtlblCap.Text & " already existed. Please enter different capcode." & vbCrLf & "Aquis customer doesn't allow duplicate capcode... ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtlblCap.SelectAll() : Me.txtlblCap.Focus()
                            Exit Sub
                        End If

                    End If
                End If


                i = Me._objMessLabel.PrintLabel(UCase(Trim(Me.txtlblSN.Text)), _
                                    UCase(Trim(Me.txtlblCap.Text)), _
                                    Trim(Me.msklblFreq.CtlText), _
                                    Me.cmblblBaud.SelectedValue, _
                                    UCase(Trim(strND)), _
                                    UCase(Trim(strPlus)), _
                                    PSS.Core.Global.ApplicationUser.IDuser, _
                                    Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift), _iReserveCapcodeID, _
                                    UCase(Trim(strModelNumber)), _
                                    booPrintNoLabel, Me.chkBackgroudBlack.Checked)

                '**********************************
                'Set Wipowner for Messaging
                '**********************************
                If Me._booIsAMSShareableInvCust Then Generic.SetTmessdataWipOwnerdataForDevices(iDeviceID, iWipOwnerID, 0, 0)
                If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                    Generic.SetTmessdataWipOwnerdataForDevices(iDeviceID, iWipOwnerID, 0, 0)
                End If
                '**********************************

                'get Daily and weekly label production numbers
                Me.lbllblDaily.Text = Me._objMessLabel.GetLabelProductionNumbersByCC(Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift), 0)
                Me.lbllblweekly.Text = Me._objMessLabel.GetLabelProductionNumbersByCC(Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift), 1)
                Me.LoadDailyWeeklyLabelProd()
            Else    'RELABEL
                    If Me.cboCustomers.SelectedValue = 0 Then
                        MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cboCustomers.Focus()
                        Exit Sub
                    ElseIf Me.cboModels.SelectedValue = 0 Then
                        MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.cboModels.Focus()
                        Exit Sub
                    Else
                        i = Me._objMessLabel.RePrintLabel(UCase(Trim(Me.txtlblSN.Text)), _
                                                          UCase(Trim(Me.txtlblCap.Text)), _
                                                          Trim(Me.msklblFreq.CtlText), _
                                                          Me.cmblblBaud.SelectedValue, _
                                                          Me.cmblblBaud.Text, _
                                                          strND.Trim.ToUpper, _
                                                          strPlus.Trim.ToUpper, _
                                                          Me.cboCustomers.SelectedValue, _
                                                          Me.cboModels.SelectedValue, _
                                                          Me.cboModels.Text, _
                                                          UCase(Trim(strModelNumber)), _
                                                          Me.chkBackgroudBlack.Checked)
                    End If
                End If

                'Clear Screen
                If Me.chkClearData.Checked Then
                    ClearPage_Label()
                Else
                    Me.txtlblSN.SelectAll()
                End If

                Me.chklblND.Checked = False
                Me.chklblND.Visible = False
                Me.chklblPlus.Checked = False
                Me.chklblPlus.Visible = False
                Me.chkClearData.Visible = False
                Me.chkBackgroudBlack.Checked = False

                Me.txtlblSN.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Print Label", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objMess = Nothing : Generic.DisposeDT(dt)
        End Try
    End Sub

    '*************************************************************************
    Private Sub KeyDownInControls(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlblCap.KeyUp, cmblblBaud.KeyUp, chklblPlus.KeyUp, chklblND.KeyUp, chkClearData.KeyUp, txtlblSN.KeyUp, lstModelType.KeyUp, chkPrintModelLetter.KeyUp
        If e.KeyValue = 123 Then        'F12

            DoPrint()
        End If
    End Sub

    '*********************************************************
    Private Sub msklblFreq_KeyUpEvent(ByVal sender As Object, ByVal e As AxMSMask.MaskEdBoxEvents_KeyUpEvent) Handles msklblFreq.KeyUpEvent
        If e.keyCode = 123 Then        'F12
            DoPrint()
        End If
    End Sub

    '*********************************************************
    Private Sub SetFreqMaskControlText_Label(Optional ByVal strText As String = "")
        Dim strMask As String = ""

        With Me.msklblFreq
            strMask = .Mask
            .Mask = ""
            .CtlText = strText
            .Mask = strMask
        End With
    End Sub

    '*********************************************************
    Private Sub PrintModelTypeLetterCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintModelLetter.CheckedChanged
        Try
            If Not Me.chkPrintModelLetter.Visible Then Exit Sub

            If Me.chkPrintModelLetter.Checked Then
                If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.ModelTypeLetter = "R"
            Else
                If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.ModelTypeLetter = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Print Model Type Letter Error")
        End Try
    End Sub

    '*********************************************************
    Private Sub chkPrintSkyTellLetter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPrintSkyTellLetter.CheckedChanged
        Try
            If Not Me.chkPrintSkyTellLetter.Visible Then Exit Sub

            If Me.chkPrintSkyTellLetter.Checked Then
                If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.SkyTellLetter = "S"
            Else
                If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.SkyTellLetter = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Print SkyTell Letter Error")
        End Try
    End Sub

    '*********************************************************
    Private Sub ModelTypeSelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstModelType.SelectedIndexChanged
        Try
            If Not (Me.lstModelType.Visible And Me.lstModelType.Enabled) Then Exit Sub

            If Me.lstModelType.SelectedIndex = -1 Then
                If Not IsNothing(Me._objMessLabel) Then
                    Me._objMessLabel.ModelType = ""
                    Me._objMessLabel.ModelTypeLetter = ""
                End If
            Else
                If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.ModelType = Me.lstModelType.SelectedItem

                If Me.lstModelType.SelectedItem.ToString.ToUpper = "UNICATION" Then
                    If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.ModelTypeLetter = "R"
                    Me.chkPrintModelLetter.Checked = True
                    Me.chkPrintModelLetter.Enabled = False
                Else
                    Me.chkPrintModelLetter.Enabled = True
                    If Not IsNothing(Me._objMessLabel) Then Me._objMessLabel.ModelTypeLetter = IIf(Me.chkPrintModelLetter.Checked, "R", "")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Select Model Type Error")
        End Try
    End Sub

    '*********************************************************
    Private Sub ShowHideTwoWay(ByVal iModelID As Integer)
        Try
            If iModelID = 76 Then
                Me.ComboBox1.Visible = True
                Me.lblModelType.Enabled = True
                Me.lstModelType.Enabled = True
                Me.lblModelType.Visible = True
                Me.lstModelType.Visible = True
                Me.chkPrintModelLetter.Visible = True
                Me.chkPrintSkyTellLetter.Visible = True

            ElseIf iModelID = 87 Or iModelID = 808 Or iModelID = 1110 Then
                Me.lblModelType.Enabled = True
                Me.lstModelType.Enabled = True
                Me.lblModelType.Visible = True
                Me.lstModelType.Visible = True
                Me.chkPrintModelLetter.Visible = True
                Me.chkPrintSkyTellLetter.Visible = True
            Else
                Me.lblModelType.Visible = False
                Me.lstModelType.Visible = False
                Me.chkPrintModelLetter.Visible = False
                Me.chkPrintSkyTellLetter.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadDailyWeeklyLabelProd()
        'Dim iLoc_ID As Integer = 19
        'Dim dt As DataTable

        'Try
        '    dt = Me._objMessLabel.GetDailyWeeklyLabelProdByModelFreq(iLoc_ID)

        '    If dt.Rows.Count > 0 Then
        '        Me.dbgDailyWeeklyProd.Visible = True
        '        Me.dbgDailyWeeklyProd.DataSource = dt.DefaultView

        '        With Me.dbgDailyWeeklyProd
        '            'Heading style (Horizontal Alignment to Center)
        '            .Splits(0).DisplayColumns("Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
        '            .Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        '            .Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
        '            .Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

        '            'Set Column Widths
        '            .Splits(0).DisplayColumns("Model").Width = 130
        '            .Splits(0).DisplayColumns("Frequency").Width = 80
        '            .Splits(0).DisplayColumns("Daily").Width = 80
        '            .Splits(0).DisplayColumns("Weekly").Width = 80

        '            .Splits(0).DisplayColumns("Model_ID").Visible = False

        '            .ColumnFooters = True
        '            .Columns("Model").FooterText = "TOTAL"
        '            .Columns("Daily").FooterText = dt.Compute("SUM([Daily])", "")
        '            .Columns("Weekly").FooterText = dt.Compute("SUM([Weekly])", "")
        '        End With
        '    Else
        '        Me.dbgDailyWeeklyProd.Visible = True
        '    End If

        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    If Not IsNothing(dt) Then
        '        dt.Dispose()
        '        dt = Nothing
        '    End If
        'End Try
    End Sub

    '*********************************************************
    Private Sub dbgDailyWeeklyProd_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles dbgDailyWeeklyProd.AfterFilter
        Dim iRow As Integer = 0
        Dim iDailyGrandTotal As Integer = 0
        Dim iWeeklyGrandTotal As Integer = 0

        Try
            If Me.dbgDailyWeeklyProd.RowCount > 0 And Me.dbgDailyWeeklyProd.Columns.Count > 0 Then
                'loop through each selected row
                For iRow = 0 To Me.dbgDailyWeeklyProd.RowCount - 1
                    'Calculate Grand Total
                    iDailyGrandTotal = iDailyGrandTotal + CInt(Me.dbgDailyWeeklyProd.Columns("Daily").CellText(iRow).ToString)
                    iWeeklyGrandTotal = iWeeklyGrandTotal + CInt(Me.dbgDailyWeeklyProd.Columns("Weekly").CellText(iRow).ToString)
                Next iRow

                Me.dbgDailyWeeklyProd.Columns("Daily").FooterText = iDailyGrandTotal.ToString
                Me.dbgDailyWeeklyProd.Columns("Weekly").FooterText = iWeeklyGrandTotal.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AfterFilter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboLabelType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLabelType.SelectedIndexChanged
        If Me.cboLabelType.SelectedIndex > -1 Then
            If Me.cboLabelType.SelectedIndex = 0 Then
                Me.cboModels.Text = ""
                Me.cboModels.Visible = False
                Me.lblModels.Visible = False

                Me.HideShowLableOption()

                Me.txtlblSN.SelectAll()
                Me.txtlblSN.Focus()
            Else
                Me.cboModels.SelectedValue = 0
                Me.cboModels.Text = ""

                If Me._booHasRelabelPermission = False Then
                    MessageBox.Show("You don't have permission to relabel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboLabelType.SelectedIndex = -1
                    Me.cboLabelType.Text = ""
                Else
                    Me.cboModels.Visible = True
                    Me.lblModels.Visible = True

                    Me.HideShowLableOption()

                    Me.cboCustomers.Focus()
                End If
            End If
        End If
    End Sub

    '*********************************************************
    Private Sub frmMessLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objML As New PSS.Data.Buisness.MessLabel()
        Dim dt, dt2 As DataTable
        Dim iCustID As Integer = 0
        Dim strToday As String = ""

        Try
            'Load Customer
            iCustID = PSS.Data.Buisness.Generic.GetCustIDByMachine()
            dt = Generic.GetCustomers(True, 1)
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            If iCustID > 0 Then
                Me.cboCustomers.SelectedValue = iCustID
                Me._booIsAMSShareableInvCust = Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(iCustID)
                If Me._booIsAMSShareableInvCust Then
                    Me.gbShareableInvData.Visible = True
                    Me.LoadShareableInvCustList()
                Else
                    Me.gbShareableInvData.Visible = False
                End If
            Else
                Me.cboCustomers.SelectedValue = 0
            End If

            dt2 = New DataTable()
            dt2 = dt.Copy
            Misc.PopulateC1DropDownList(Me.cboUpdFreq_Customers, dt2, "Cust_Name1", "Cust_ID")
            cboUpdFreq_Customers.SelectedValue = 0 : cboUpdFreq_Customers.Enabled = False

            'Load Model
            dt = Generic.GetModels(True, 1, )
            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
            Me.cboModels.SelectedValue = 0

            'Load Frequency
            LoadBaudRates(Me.cmblblBaud)
            dt2 = Generic.GetFreqs(True)
            Misc.PopulateC1DropDownList(Me.cboUpdFreq_NewFreq, dt2, "freq_Number", "freq_id")
            Me.cboUpdFreq_NewFreq.SelectedValue = 0

            'Load Baud Rate
            dt2 = objML.GetBaudRates()
            Misc.PopulateC1DropDownList(Me.cboUpdFreq_NewBaud, dt2, "baud_Number", "Baud_ID")
            Me.cboUpdFreq_NewBaud.SelectedValue = 0

            'Set security access for update Freq, baud and capcode
            If Core.ApplicationUser.GetPermission("Mess_UpdateFreqBaudCapcode") > 0 Then Me.tpUpdateFreqBaudCap.Enabled = True Else Me.tpUpdateFreqBaudCap.Enabled = False

            Me.cboLabelType.SelectedIndex = 0
            Me.chkOverrideCapcode.Visible = Me._booOverideCapcodeVisible
            Me.txtlblSN.Focus()
            Me.chkBackgroudBlack.Visible = False : Me.chkBackgroudBlack.Checked = False

            'Reset all reserve capcode without using....
            Me._objMessLabel.ResetReserveCapcodeWithOldDate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmMessLabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt) : Generic.DisposeDT(dt2) : objML = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadBaudRates(ByRef cmbBaud As ComboBox)
        Dim dtBaudRates As New DataTable()
        Dim objML As New PSS.Data.Buisness.MessLabel()

        Try
            dtBaudRates = objML.GetBaudRates()
            With cmbBaud
                .DataSource = dtBaudRates.DefaultView
                .DisplayMember = dtBaudRates.Columns("baud_Number").ToString
                .ValueMember = dtBaudRates.Columns("Baud_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtBaudRates) Then
                dtBaudRates.Dispose()
                dtBaudRates = Nothing
            End If
            objML = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub KeyUpEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp, cboModels.KeyUp, txtlblCap.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case sender.Name
                    Case "cboCustomers"
                        If Me.cboCustomers.SelectedValue > 0 Then
                            If Me.cboLabelType.SelectedIndex = 0 Then
                                Me.txtlblSN.Focus()
                            Else
                                Me.cboModels.SelectAll()
                                Me.cboModels.Focus()
                            End If
                        End If
                    Case "cboModels"
                        If Me.cboModels.SelectedValue > 0 Then
                            ShowHideOptionals_Label(Me.cboModels.SelectedValue)
                            Me.txtlblSN.SelectAll()
                            Me.txtlblSN.Focus()
                        End If
                    Case "txtlblCap"
                        If Me.txtlblCap.Text.Trim.Length > 0 Then
                            Me.msklblFreq.SelStart = 0
                            Me.msklblFreq.SelLength = 8
                            Me.msklblFreq.Focus()
                        End If
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboCustomers_cboLabelType_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Enter, cboLabelType.Enter
        Me.cboModels.SelectedValue = 0
        Me.cboModels.Text = ""
        'Clear Screen
        If Me.chkClearData.Checked Then
            ClearPage_Label()
        Else
            Me.txtlblSN.SelectAll()
        End If

        Me.chkClearData.Visible = False
    End Sub

    '*********************************************************
    Private Sub HideShowLableOption()
        If Me.cboLabelType.SelectedIndex = 0 Then
            Me.chklblPlus.Visible = False
            Me.chklblND.Visible = False
            Me.lblModelType.Visible = False
            Me.lstModelType.Visible = False
            Me.chkPrintModelLetter.Visible = False
            Me.chkPrintSkyTellLetter.Visible = False
            Me.ComboBox1.Visible = False

        Else
            Me.chklblPlus.Visible = True
            Me.chklblND.Visible = True
            Me.lblModelType.Visible = True
            Me.lstModelType.Visible = True
            Me.chkPrintModelLetter.Visible = True
            Me.chkPrintSkyTellLetter.Visible = True
            Me.ComboBox1.Visible = True
        End If
    End Sub

    '*********************************************************
    Private Sub cboCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomers.TextChanged
        Try
            If cboCustomers.SelectedValue = 14 Then
                Me.chkBackgroudBlack.Visible = True
            Else
                Me.chkBackgroudBlack.Visible = False
            End If
            Me.chkBackgroudBlack.Checked = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboCustomers_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************************************************************************
    Private Sub cboCustomers_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Leave
        Try
            If Not (IsNothing(Me.cboCustomers.DataSource)) AndAlso Me.cboCustomers.SelectedValue > 0 Then
                Me._booIsAMSShareableInvCust = Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(Me.cboCustomers.SelectedValue)
                If Me._booIsAMSShareableInvCust Then
                    Me.gbShareableInvData.Visible = True
                    Me.dbgAvailableCapCodeList.Visible = True
                    Me.LoadShareableInvCustList()
                Else
                    Me.gbShareableInvData.Visible = False
                    If Not IsNothing(Me.cboChangeToCust.DataSource) Then Me.cboChangeToCust.DataSource = Nothing
                End If
                If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                   OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                    Me.gbShareableInvData.Enabled = False
                    Me.dbgAvailableCapCodeList.Visible = False
                End If
            Else
                Me._booIsAMSShareableInvCust = False
                Me.gbShareableInvData.Visible = False
                Me.dbgAvailableCapCodeList.Visible = False
                If Not (IsNothing(Me.cboChangeToCust.DataSource)) Then Me.cboChangeToCust.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub LoadShareableInvCustList()
        Dim dt As DataTable

        Try
            dt = Me._objMessLabel.GetShareableInventoryCustList(Me.cboCustomers.SelectedValue, True)
            Misc.PopulateC1DropDownList(Me.cboChangeToCust, dt, "Cust_Name1", "Cust_ID")
            Me.cboChangeToCust.SelectedValue = 0
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub LoadAvailableCapcode(ByVal iCustID As Integer, ByVal strFreqNo As String)
        Dim dt As DataTable

        Try
            dt = Me._objMessLabel.GetAvailableCapcodeByCustFreq(iCustID, strFreqNo)
            With Me.dbgAvailableCapCodeList
                .Caption = strFreqNo
                .DataSource = dt.DefaultView
                .Splits(0).DisplayColumns("FCP_ID").Visible = False
                .Splits(0).DisplayColumns("Freq_ID").Visible = False
                .Splits(0).DisplayColumns("CapCode").Width = 100
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub btnSaveNewCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNewCust.Click
        Dim iLocID As Integer, i As Integer, iWOID As Integer
        Dim objTech As NewTech
        Dim dr As DataRow
        Dim booUpdOrgCustID As Boolean = False
        Dim strSN As String = ""

        Try
            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboCustomers.SelectAll() : Me.cboCustomers.Focus()
            ElseIf Me.cboChangeToCust.SelectedValue = 0 Then
                Exit Sub
            ElseIf Me.txtlblSN.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtlblSN.SelectAll() : Me.txtlblSN.Focus()
            ElseIf Me.cboChangeToCust.SelectedValue = 0 Then
                MessageBox.Show("Please select new customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboChangeToCust.SelectAll() : Me.cboChangeToCust.Focus()
            ElseIf Me._objMessLabel.DeviceID = 0 Then
                MessageBox.Show("System can't define device's ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtlblSN.SelectAll() : Me.txtlblSN.Focus()
            ElseIf Me._objMessLabel.IsWorkorderHasPO(Me._objMessLabel.WorkOrderID) = True Then
                MessageBox.Show("SN received under PO. Can't change customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.cboCustomers.SelectedValue = Me.cboChangeToCust.SelectedValue Then
                Exit Sub ' Do nothing
            Else
                iLocID = Generic.GetLocID(Me.cboChangeToCust.SelectedValue)
                If iLocID = 0 Then Throw New Exception("System can't define location ID for new customer.")

                iWOID = Me._objMessLabel.GetLastCreateOpenWorkorderWithoutPO(iLocID)
                If iWOID = 0 Then Throw New Exception("System can't find any open workorder for this customer. Please create one.")

                objTech = New NewTech()
                dr = objTech.GetMessData(Me._objMessLabel.DeviceID)
                If IsNothing(dr) Then Throw New Exception("Messaging data is missing.")
                If CInt(dr("Rec_Cust_ID")) = 0 Then booUpdOrgCustID = True

                'Reset cust-freq-capcode
                Me._objMessLabel.ReleaseCapcode(Me._objMessLabel.DeviceID)

                i = Me._objMessLabel.ChangeCustomer(Me.cboCustomers.SelectedValue, Me._objMessLabel.DeviceID, iLocID, booUpdOrgCustID, iWOID, Core.ApplicationUser.IDuser)

                If i > 0 Then
                    strSN = Me.txtlblSN.Text.Trim
                    ClearPage_Label()
                    Me.cboCustomers.SelectedValue = Me.cboChangeToCust.SelectedValue
                    cboCustomers_Leave(Nothing, Nothing)
                    Me.txtlblSN.Text = strSN
                    Me.FillLabelInfo_Label()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnSaveNewCust_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            objTech = Nothing
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub dbgAvailableCapCodeList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgAvailableCapCodeList.DoubleClick
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim strTmpCapCode As String = ""
        Dim strS As String = ""
        Dim iRow As Integer

        Try
            With Me.dbgAvailableCapCodeList
                If .Columns.Count > 0 AndAlso .RowCount > 0 Then
                    If CInt(.Columns("FCP_ID").CellValue(.Row)) > 0 Then
                        dt = Me._objMessLabel.GetCapcode(CInt(.Columns("FCP_ID").CellValue(.Row)))
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Can't define capcode in database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate capcode. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                        ElseIf CInt(dt.Rows(0)("Available")) = 0 Then
                            MessageBox.Show("This capcode is no longer available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                        ElseIf CInt(dt.Rows(0)("Reserve")) = 1 Then
                            MessageBox.Show("This capcode is reserve for another user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                            'Check capcode and reset if need
                        ElseIf CInt(dt.Rows(0)("Reserve")) = 0 Then
                            strTmpCapCode = .Columns("CapCode").CellValue(.Row)
                            If Me._objMessLabel.IsValidCapCode(strTmpCapCode) Then
                                If Me.cboModels.SelectedValue > 0 AndAlso Me.cmblblBaud.SelectedValue > 0 AndAlso Me.cmblblBaud.Text.Length > 0 Then
                                    MessageBox.Show("Neither model nor baud rate are selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Else
                                    i = Me._objMessLabel.ReserveCapCode(CInt(.Columns("FCP_ID").CellValue(.Row)), Core.ApplicationUser.IDuser)
                                    If i = 0 Then
                                        MessageBox.Show("System has failed to reserve this capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Else
                                        Me._iReserveCapcodeID = CInt(.Columns("FCP_ID").CellValue(.Row))
                                        Me._objMessLabel.ReservedCapCode_Selected = strTmpCapCode
                                        strTmpCapCode = Me._objMessLabel.ResetCorrectCapCode(strTmpCapCode, Me.lbllblModel.Tag, Me.cmblblBaud.SelectedValue, Me.cmblblBaud.Text)
                                        Me._objMessLabel.ReservedCapCode_Reset = strTmpCapCode
                                        If Not Me._objMessLabel.ReservedCapCode_Selected.Trim.ToUpper = Me._objMessLabel.ReservedCapCode_Reset.Trim.ToUpper Then
                                            For iRow = 0 To .RowCount - 1
                                                strS = .Columns("CapCode").CellValue(iRow)
                                                If strS.Trim.ToUpper = Me._objMessLabel.ReservedCapCode_Reset.Trim.ToUpper Then
                                                    MessageBox.Show("Can't reset capcode. ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                                    Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                                                    Exit Sub
                                                End If
                                            Next
                                        End If
                                        Me.txtlblCap.Text = strTmpCapCode
                                    End If
                                End If
                            Else
                                MessageBox.Show("Invalid capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))

                            'i = Me._objMessLabel.ReserveCapCode(CInt(.Columns("FCP_ID").CellValue(.Row)), Core.ApplicationUser.IDuser)
                            'If i = 0 Then
                            '    MessageBox.Show("System has failed to reserve this capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            'Else
                            '    Me._iReserveCapcodeID = CInt(.Columns("FCP_ID").CellValue(.Row))
                            '    Me.txtlblCap.Text = .Columns("CapCode").CellValue(.Row)
                            '    Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
                            'End If
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dbgAvailableCapCodeList_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub msklblFreq_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles msklblFreq.Leave
        Try
            If _iReserveCapcodeID > 0 Then
                Me._objMessLabel.ResetReserveCapcode(_iReserveCapcodeID)
            End If

            _iReserveCapcodeID = 0

            Me.LoadAvailableCapcode(Me.cboCustomers.SelectedValue, Trim(Me.msklblFreq.CtlText))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "msklblFreq_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************************************************************
#End Region

#Region "Update Freq, Baud and Cap Code"

    '******************************************************************************************************************
    Private Sub UpdFreq_Trls_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUpdFreq_SN.KeyUp, cboCustomers.KeyUp, cboUpdFreq_NewFreq.KeyUp, cboUpdFreq_NewBaud.KeyUp, txtUpdFreq_NewCapCode.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If sender.name = "cboCustomers" Then
                    If Me.cboCustomers.SelectedValue > 0 Then
                        Me.cboUpdFreq_NewFreq.SelectAll() : Me.cboUpdFreq_NewFreq.Focus()
                    End If
                ElseIf sender.name = "txtUpdFreq_SN" Then
                    If Me.txtUpdFreq_SN.Text.Trim.Length > 0 Then Me.ProcessUpdFreq_SN()
                ElseIf sender.name = "cboUpdFreq_NewFreq" Then
                    If Me.cboUpdFreq_NewFreq.SelectedValue > 0 Then
                        Me.cboUpdFreq_NewBaud.SelectAll() : Me.cboUpdFreq_NewBaud.Focus()
                    End If
                ElseIf sender.name = "cboUpdFreq_NewBaud" Then
                    If Me.cboUpdFreq_NewBaud.SelectedValue > 0 Then
                        Me.txtUpdFreq_NewCapCode.SelectAll() : Me.txtUpdFreq_NewCapCode.Focus()
                    End If
                ElseIf sender.name = "txtUpdFeq_NewCapCode" Then
                    'DO NOTHING
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, sender.name & "_KeyUP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************************************************************
    Private Function ProcessUpdFreq_SN() As DataTable
        Dim dt As DataTable
        Try
            dt = Me._objMessLabel.GetDeviceInWip(Me.txtUpdFreq_SN.Text.Trim.ToUpper, Me.cboUpdFreq_Customers.SelectedValue)
            If dt.Rows.Count = 0 Then
                Throw New Exception("Device does not exist in WIP.")
            ElseIf dt.Rows.Count > 1 Then
                Me.cboUpdFreq_Customers.Enabled = True : Me.cboUpdFreq_Customers.SelectAll() : Me.cboUpdFreq_Customers.Focus()
                Throw New Exception("Duplicate SN. Please select customer.")
            Else
                If Not IsDBNull(dt.Rows(0)("Model_Desc")) Then Me.lblUpdFreq_Model.Text = dt.Rows(0)("Model_Desc")
                If Not IsDBNull(dt.Rows(0)("freq_Number")) Then Me.lblUpdFreq_Freq.Text = dt.Rows(0)("freq_Number")
                If Not IsDBNull(dt.Rows(0)("baud_Number")) Then Me.lblUpdFreq_Baud.Text = dt.Rows(0)("baud_Number")
                If Not IsDBNull(dt.Rows(0)("capcode")) Then Me.lblUpdFreq_CapCode.Text = dt.Rows(0)("capcode")
                Me.cboUpdFreq_NewFreq.SelectAll() : Me.cboUpdFreq_NewFreq.Focus()
            End If

            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Function

    '******************************************************************************************************************
    Private Sub btnUpdFreq_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdFreq_Save.Click
        Dim dt As DataTable
        Dim iFreqID, iBaudID, iOldFreqID, iOldBaudID, iNewFreqID, iNewBaudID As Integer
        Dim strCapCode As String = "", strOldCapCode As String = "", strNewCapCode As String = ""

        Try
            If Me.cboUpdFreq_NewFreq.SelectedValue = 0 AndAlso Me.cboUpdFreq_NewBaud.SelectedValue = 0 AndAlso Me.txtUpdFreq_NewCapCode.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter either new frequency, new baud rate or new cap code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dt = ProcessUpdFreq_SN()
                If Not IsDBNull(dt.Rows(0)("Freq_ID")) Then iFreqID = CInt(dt.Rows(0)("Freq_ID"))
                If Not IsDBNull(dt.Rows(0)("Baud_ID")) Then iBaudID = CInt(dt.Rows(0)("Baud_ID"))
                If Not IsDBNull(dt.Rows(0)("capcode")) Then strCapCode = dt.Rows(0)("capcode").ToString.Trim.ToUpper

                If Me.cboUpdFreq_NewFreq.SelectedValue > 0 AndAlso iFreqID <> Me.cboUpdFreq_NewFreq.SelectedValue Then
                    iNewFreqID = Me.cboUpdFreq_NewFreq.SelectedValue
                    If (IsDBNull(dt.Rows(0)("freq_id_old")) OrElse CInt(dt.Rows(0)("freq_id_old")) = 0) Then iOldFreqID = iFreqID
                End If

                If Me.cboUpdFreq_NewBaud.SelectedValue > 0 AndAlso iBaudID <> Me.cboUpdFreq_NewBaud.SelectedValue Then
                    iNewBaudID = Me.cboUpdFreq_NewBaud.SelectedValue
                    If (IsDBNull(dt.Rows(0)("baud_id_old")) OrElse CInt(dt.Rows(0)("baud_id_old")) = 0) Then iOldBaudID = iBaudID
                End If

                If Me.txtUpdFreq_NewCapCode.Text.Trim.Length > 0 AndAlso strCapCode <> Me.txtUpdFreq_NewCapCode.Text.Trim.ToUpper Then
                    strNewCapCode = Me.txtUpdFreq_NewCapCode.Text.Trim.ToUpper
                    If (IsDBNull(dt.Rows(0)("capcode_old")) OrElse dt.Rows(0)("capcode_old").ToString.Trim.Length = 0) Then strOldCapCode = strCapCode
                End If

                If iNewFreqID = 0 AndAlso iNewBaudID = 0 AndAlso strNewCapCode.Length = 0 Then
                    MessageBox.Show("Current Freq and baud rate are the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me._objMessLabel.UpdateFreqBaudCap(dt.Rows(0)("Device_ID"), iNewFreqID, iNewBaudID, strNewCapCode, iOldFreqID, iOldBaudID, strOldCapCode, Core.ApplicationUser.IDuser)
                    Me.cboUpdFreq_Customers.SelectedValue = 0 : Me.cboUpdFreq_Customers.Enabled = False
                    Me.lblUpdFreq_Freq.Text = ""
                    Me.lblUpdFreq_Baud.Text = ""
                    Me.lblUpdFreq_CapCode.Text = ""
                    Me.cboUpdFreq_NewFreq.SelectedValue = 0
                    Me.cboUpdFreq_NewBaud.SelectedValue = 0
                    Me.txtUpdFreq_NewCapCode.Text = ""
                    Me.txtUpdFreq_SN.Text = "" : Me.txtUpdFreq_SN.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnUpdFreq_Save_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************************************************************

#End Region




End Class
