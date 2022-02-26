Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmMessLabel
    Inherits System.Windows.Forms.Form

    Private _objMessLabel As MessLabel
    Private _booHasRelabelPermission As Boolean = False
    Private _booOverideCapcodeVisible As Boolean = False

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
        CType(Me.dbgDailyWeeklyProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.msklblFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dbgDailyWeeklyProd.TabIndex = 171
        Me.dbgDailyWeeklyProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Alig" & _
        "nVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styl" & _
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
        Me.chkPrintSkyTellLetter.BackColor = System.Drawing.Color.Transparent
        Me.chkPrintSkyTellLetter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintSkyTellLetter.ForeColor = System.Drawing.Color.Black
        Me.chkPrintSkyTellLetter.Location = New System.Drawing.Point(131, 456)
        Me.chkPrintSkyTellLetter.Name = "chkPrintSkyTellLetter"
        Me.chkPrintSkyTellLetter.Size = New System.Drawing.Size(187, 18)
        Me.chkPrintSkyTellLetter.TabIndex = 13
        Me.chkPrintSkyTellLetter.Text = "Print SkyTel Letter"
        Me.chkPrintSkyTellLetter.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(486, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 20)
        Me.Label14.TabIndex = 160
        Me.Label14.Text = "WEEKLY"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(393, 9)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 20)
        Me.Label35.TabIndex = 159
        Me.Label35.Text = "DAILY"
        '
        'cmblblBaud
        '
        Me.cmblblBaud.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmblblBaud.Location = New System.Drawing.Point(131, 196)
        Me.cmblblBaud.Name = "cmblblBaud"
        Me.cmblblBaud.Size = New System.Drawing.Size(215, 22)
        Me.cmblblBaud.TabIndex = 7
        '
        'lbllblModel
        '
        Me.lbllblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbllblModel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblModel.ForeColor = System.Drawing.Color.Black
        Me.lbllblModel.Location = New System.Drawing.Point(131, 227)
        Me.lbllblModel.Name = "lbllblModel"
        Me.lbllblModel.Size = New System.Drawing.Size(215, 23)
        Me.lbllblModel.TabIndex = 153
        Me.lbllblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkPrintModelLetter
        '
        Me.chkPrintModelLetter.BackColor = System.Drawing.Color.Transparent
        Me.chkPrintModelLetter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintModelLetter.ForeColor = System.Drawing.Color.Black
        Me.chkPrintModelLetter.Location = New System.Drawing.Point(131, 432)
        Me.chkPrintModelLetter.Name = "chkPrintModelLetter"
        Me.chkPrintModelLetter.Size = New System.Drawing.Size(187, 19)
        Me.chkPrintModelLetter.TabIndex = 12
        Me.chkPrintModelLetter.Text = "Print Model Letter"
        Me.chkPrintModelLetter.Visible = False
        '
        'txtlblSN
        '
        Me.txtlblSN.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtlblSN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlblSN.Location = New System.Drawing.Point(131, 112)
        Me.txtlblSN.Name = "txtlblSN"
        Me.txtlblSN.Size = New System.Drawing.Size(215, 20)
        Me.txtlblSN.TabIndex = 4
        Me.txtlblSN.Text = ""
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(9, 112)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(112, 20)
        Me.Label31.TabIndex = 138
        Me.Label31.Text = "Serial Number:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbllblweekly
        '
        Me.lbllblweekly.BackColor = System.Drawing.Color.Black
        Me.lbllblweekly.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbllblweekly.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblweekly.ForeColor = System.Drawing.Color.Lime
        Me.lbllblweekly.Location = New System.Drawing.Point(477, 9)
        Me.lbllblweekly.Name = "lbllblweekly"
        Me.lbllblweekly.Size = New System.Drawing.Size(94, 56)
        Me.lbllblweekly.TabIndex = 155
        Me.lbllblweekly.Text = "0"
        Me.lbllblweekly.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'chklblPlus
        '
        Me.chklblPlus.BackColor = System.Drawing.Color.Transparent
        Me.chklblPlus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklblPlus.ForeColor = System.Drawing.Color.Black
        Me.chklblPlus.Location = New System.Drawing.Point(131, 304)
        Me.chklblPlus.Name = "chklblPlus"
        Me.chklblPlus.Size = New System.Drawing.Size(187, 16)
        Me.chklblPlus.TabIndex = 8
        Me.chklblPlus.Text = "Plus (ST 800 only)"
        Me.chklblPlus.Visible = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 19)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Baud Rate:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbllblDaily
        '
        Me.lbllblDaily.BackColor = System.Drawing.Color.Black
        Me.lbllblDaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbllblDaily.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblDaily.ForeColor = System.Drawing.Color.Lime
        Me.lbllblDaily.Location = New System.Drawing.Point(374, 9)
        Me.lbllblDaily.Name = "lbllblDaily"
        Me.lbllblDaily.Size = New System.Drawing.Size(94, 56)
        Me.lbllblDaily.TabIndex = 154
        Me.lbllblDaily.Text = "0"
        Me.lbllblDaily.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lstModelType
        '
        Me.lstModelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstModelType.Items.AddRange(New Object() {"Motorola", "Unication"})
        Me.lstModelType.Location = New System.Drawing.Point(225, 392)
        Me.lstModelType.Name = "lstModelType"
        Me.lstModelType.Size = New System.Drawing.Size(119, 30)
        Me.lstModelType.TabIndex = 11
        Me.lstModelType.Visible = False
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(28, 169)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 21)
        Me.Label32.TabIndex = 142
        Me.Label32.Text = "Frequency:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtlblCap
        '
        Me.txtlblCap.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlblCap.Location = New System.Drawing.Point(131, 140)
        Me.txtlblCap.Name = "txtlblCap"
        Me.txtlblCap.Size = New System.Drawing.Size(215, 20)
        Me.txtlblCap.TabIndex = 5
        Me.txtlblCap.Text = ""
        '
        'chklblND
        '
        Me.chklblND.BackColor = System.Drawing.Color.Transparent
        Me.chklblND.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklblND.ForeColor = System.Drawing.Color.Black
        Me.chklblND.Location = New System.Drawing.Point(131, 328)
        Me.chklblND.Name = "chklblND"
        Me.chklblND.Size = New System.Drawing.Size(215, 17)
        Me.chklblND.TabIndex = 9
        Me.chklblND.Text = "ND (AE Advisor Elite only)"
        Me.chklblND.Visible = False
        '
        'chkClearData
        '
        Me.chkClearData.BackColor = System.Drawing.Color.Transparent
        Me.chkClearData.Checked = True
        Me.chkClearData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClearData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClearData.ForeColor = System.Drawing.Color.Black
        Me.chkClearData.Location = New System.Drawing.Point(131, 280)
        Me.chkClearData.Name = "chkClearData"
        Me.chkClearData.Size = New System.Drawing.Size(121, 16)
        Me.chkClearData.TabIndex = 10
        Me.chkClearData.Text = "Clear Data"
        Me.chkClearData.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(37, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 19)
        Me.Label15.TabIndex = 139
        Me.Label15.Text = "Cap Code:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(56, 227)
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
        Me.lbllblCust.Location = New System.Drawing.Point(131, 256)
        Me.lbllblCust.Name = "lbllblCust"
        Me.lbllblCust.Size = New System.Drawing.Size(215, 24)
        Me.lbllblCust.TabIndex = 152
        Me.lbllblCust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(37, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 19)
        Me.Label13.TabIndex = 151
        Me.Label13.Text = "Customer:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModelType
        '
        Me.lblModelType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelType.Location = New System.Drawing.Point(131, 394)
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
        Me.cmdlblPrint.Location = New System.Drawing.Point(131, 488)
        Me.cmdlblPrint.Name = "cmdlblPrint"
        Me.cmdlblPrint.Size = New System.Drawing.Size(215, 38)
        Me.cmdlblPrint.TabIndex = 14
        Me.cmdlblPrint.Text = "PRINT (F12)"
        '
        'msklblFreq
        '
        Me.msklblFreq.Location = New System.Drawing.Point(131, 169)
        Me.msklblFreq.Name = "msklblFreq"
        Me.msklblFreq.OcxState = CType(resources.GetObject("msklblFreq.OcxState"), System.Windows.Forms.AxHost.State)
        Me.msklblFreq.Size = New System.Drawing.Size(215, 22)
        Me.msklblFreq.TabIndex = 6
        '
        'cboLabelType
        '
        Me.cboLabelType.Items.AddRange(New Object() {"Label", "Relabel"})
        Me.cboLabelType.Location = New System.Drawing.Point(131, 44)
        Me.cboLabelType.Name = "cboLabelType"
        Me.cboLabelType.Size = New System.Drawing.Size(215, 21)
        Me.cboLabelType.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 44)
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
        Me.lblCusts.Location = New System.Drawing.Point(9, 9)
        Me.lblCusts.Name = "lblCusts"
        Me.lblCusts.Size = New System.Drawing.Size(112, 20)
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
        Me.cboCustomers.Location = New System.Drawing.Point(131, 9)
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
        Me.cboModels.Location = New System.Drawing.Point(131, 76)
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
        'lblModels
        '
        Me.lblModels.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModels.ForeColor = System.Drawing.Color.Black
        Me.lblModels.Location = New System.Drawing.Point(9, 79)
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
        Me.ComboBox1.Location = New System.Drawing.Point(227, 360)
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
        Me.chkNoLabelPrintOut.Location = New System.Drawing.Point(8, 496)
        Me.chkNoLabelPrintOut.Name = "chkNoLabelPrintOut"
        Me.chkNoLabelPrintOut.Size = New System.Drawing.Size(112, 18)
        Me.chkNoLabelPrintOut.TabIndex = 170
        Me.chkNoLabelPrintOut.Text = "No Label"
        '
        'chkOverrideCapcode
        '
        Me.chkOverrideCapcode.Location = New System.Drawing.Point(376, 88)
        Me.chkOverrideCapcode.Name = "chkOverrideCapcode"
        Me.chkOverrideCapcode.Size = New System.Drawing.Size(144, 24)
        Me.chkOverrideCapcode.TabIndex = 172
        Me.chkOverrideCapcode.Text = "Override Capcode"
        Me.chkOverrideCapcode.Visible = False
        '
        'frmMessLabel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(832, 549)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkOverrideCapcode, Me.chkNoLabelPrintOut, Me.ComboBox1, Me.cboModels, Me.lblModels, Me.cboCustomers, Me.lblCusts, Me.Label1, Me.cboLabelType, Me.dbgDailyWeeklyProd, Me.chkPrintSkyTellLetter, Me.Label14, Me.Label35, Me.cmblblBaud, Me.lbllblModel, Me.chkPrintModelLetter, Me.txtlblSN, Me.Label31, Me.lbllblweekly, Me.chklblPlus, Me.Label5, Me.lbllblDaily, Me.lstModelType, Me.Label32, Me.txtlblCap, Me.chklblND, Me.chkClearData, Me.Label15, Me.Label11, Me.lbllblCust, Me.Label13, Me.lblModelType, Me.cmdlblPrint, Me.msklblFreq})
        Me.Name = "frmMessLabel"
        Me.Text = "frmMessLabel"
        CType(Me.dbgDailyWeeklyProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.msklblFreq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

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

            Me.txtlblCap.Focus()
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
        'Dim strMask As String = ""

        Try
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
                Else
                    Me._objMessLabel.FreqID = 0
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
                If Not IsDBNull(R1("cust_name1")) Then
                    Me.lbllblCust.Text = Trim(R1("cust_name1"))
                Else
                    Me.lbllblCust.Text = ""
                End If

                'CustID
                If Not IsDBNull(R1("cust_id")) Then
                    Me._objMessLabel.CustID = R1("cust_id")
                Else
                    Me._objMessLabel.CustID = 0
                End If

                Exit For
            Next R1

            '*****************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "SN Scan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            R1 = Nothing
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdlblPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdlblPrint.Click
        DoPrint()
    End Sub

    '*********************************************************
    Private Sub DoPrint()
        Dim i As Integer = 0
        Dim strND As String = ""
        Dim strPlus As String = ""
        Dim strModelNumber As String = ""
        Dim booPrintNoLabel As Boolean = False
        Dim objMess As PSS.Data.Buisness.Messaging

        Try
            '*******************************************
            'Validate capcode added on 0813/09
            ''*******************************************
            Me.txtlblCap.Text = Me.txtlblCap.Text.Trim
            Select Case Me.lbllblModel.Tag
                Case 1121, 1110, 87, 808, 76, 130, 1142
                    For i = 1 To Me.txtlblCap.Text.Length
                        If Char.IsDigit(CChar(Mid(Me.txtlblCap.Text, i, 1))) = False Then
                            MessageBox.Show("This model does not allow to have any letter in the capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtlblCap.Focus()
                            Exit Sub
                        End If
                    Next i
            End Select
            '********************************************
            'Validate Freq 09/12/2011
            ''*******************************************
            If Me._objMessLabel.IsFreqExisted(Trim(Me.msklblFreq.CtlText)) = False Then
                If MessageBox.Show("The Frequency: " & Trim(Me.msklblFreq.CtlText) & " is not found in the system. Please verify if this frequency is valid. Click 'YES' to add this new frequency and continue print label, click 'NO' to cancel.", "Frequency Not Found !", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Exit Sub
                Else
                    Me._objMessLabel.InsertFreq(Trim(Me.msklblFreq.CtlText), 0)
                End If

            End If

            '*******************************************

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

            If Me.cboLabelType.SelectedIndex = 0 Then

                'Hung Nguyen 11/11/2011
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
                                    PSS.Core.[Global].ApplicationUser.IDuser, _
                                    Generic.GetWorkDate(PSS.Core.ApplicationUser.IDShift), _
                                    UCase(Trim(strModelNumber)), _
                                    booPrintNoLabel)

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
                                                      UCase(Trim(strModelNumber)))
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


            Me.txtlblSN.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Print Label", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            objMess = Nothing
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
        Dim iLoc_ID As Integer = 19
        Dim dt As DataTable

        Try
            dt = Me._objMessLabel.GetDailyWeeklyLabelProdByModelFreq(iLoc_ID)

            If dt.Rows.Count > 0 Then
                Me.dbgDailyWeeklyProd.Visible = True
                Me.dbgDailyWeeklyProd.DataSource = dt.DefaultView

                With Me.dbgDailyWeeklyProd
                    'Heading style (Horizontal Alignment to Center)
                    .Splits(0).DisplayColumns("Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    .Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    .Splits(0).DisplayColumns("Frequency").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                    'Set Column Widths
                    .Splits(0).DisplayColumns("Model").Width = 130
                    .Splits(0).DisplayColumns("Frequency").Width = 80
                    .Splits(0).DisplayColumns("Daily").Width = 80
                    .Splits(0).DisplayColumns("Weekly").Width = 80

                    .Splits(0).DisplayColumns("Model_ID").Visible = False

                    .ColumnFooters = True
                    .Columns("Model").FooterText = "TOTAL"
                    .Columns("Daily").FooterText = dt.Compute("SUM([Daily])", "")
                    .Columns("Weekly").FooterText = dt.Compute("SUM([Weekly])", "")
                End With
            Else
                Me.dbgDailyWeeklyProd.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
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
        Dim dt As DataTable
        Dim iCustID As Integer = 0
        Try
            iCustID = PSS.Data.Buisness.Generic.GetCustIDByMachine()
            dt = Generic.GetCustomers(True, 1)
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            If iCustID > 0 Then Me.cboCustomers.SelectedValue = iCustID Else Me.cboCustomers.SelectedValue = 0

            dt = Generic.GetModels(True, 1, )
            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
            Me.cboModels.SelectedValue = 0

            LoadBaudRates(Me.cmblblBaud)

            Me.cboLabelType.SelectedIndex = 0
            Me.chkOverrideCapcode.Visible = Me._booOverideCapcodeVisible
            Me.txtlblSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmMessLabel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
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


End Class
