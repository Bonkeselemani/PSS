Imports PSS.Core.Global
Imports PSS.Data
Imports PSS.Data.Buisness
Imports System.Data
Imports System
Imports C1
Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1FlexGrid

Public Class frmQC
    Inherits System.Windows.Forms.Form

    Private _strScreenName As String = ""
    Private _iMenuCustID As Integer = 0
    Private _iMenuQCTypeID As Integer = 0

    Private objQC As PSS.Data.Buisness.QC
    Private iDevice_ID As Integer = 0
    Private arrSplitLine(0)
    Private Const strdelimiter As String = "~"
    Private iQCResult As Integer = 0

    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
    Private _objWIKO_BoxShip As PSS.Data.Buisness.WIKO.WIKO_BoxShip
    Private _objWIKO_Class As PSS.Data.Buisness.WIKO.WIKO
    Private _objWingTechATT_BoxShip As PSS.Data.Buisness.WingTechATT.WingTechATT_BoxShip
    Private _objWingTechATT_Class As PSS.Data.Buisness.WingTechATT.WingTechATT
    Private _objVinsmart_BoxShip As PSS.Data.Buisness.Vinsmart.Vinsmart_BoxShip
    Private _objVinsmart_Class As PSS.Data.Buisness.Vinsmart.Vinsmart
    Private dtFlash As DataTable
    Private strGroup As String = ""
    Private iLine_ID As Integer = 0
    Private strLineNumber As String = ""
    Private strLineSide As String = ""
    Private icc_id As Integer = 0
    Private _iCC_Group_ID As Integer = 0
    Private _iModelID As Integer = 0
    Private _iManufID As Integer = 0
    Private _iWrty As Integer = 0
    Private _iFunRep As Integer = 0
    Private _iLaborLevel As Integer = 0
    Private _iWO_GroupID As Integer = 0
    Private _iProdID As Integer = 0
    Private _iLoc_ID As Integer = 0
    Private _bIsNTF As Boolean = False
    Private _iNTF_When_FQA_Failed_X2FUN_Model_ID As Integer = 0

    Private Const MaxLotSize As Integer = 50 'Maximum devices in a bucket lot
    Private Const EnableAQLInspectionLog As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal strScreenName As String = "", _
                   Optional ByVal iCustID As Integer = 0, _
                   Optional ByVal iQCTypeID As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objQC = New PSS.Data.Buisness.QC()

        'radioPassFail(0) = Me.RadioPass
        'radioPassFail(1) = Me.RadioFail

        'radioFqaCqa(0) = Me.RadioCQA
        'radioFqaCqa(1) = Me.RadioFQA
        Me._objWIKO_BoxShip = New PSS.Data.Buisness.WIKO.WIKO_BoxShip()
        Me._objWingTechATT_BoxShip = New PSS.Data.Buisness.WingTechATT.WingTechATT_BoxShip()
        Me._objVinsmart_BoxShip = New PSS.Data.Buisness.Vinsmart.Vinsmart_BoxShip()
        _strScreenName = strScreenName
        If strScreenName.Trim.Length > 0 Then
            Me.lblTitle.Text = strScreenName & " Test"
        End If
        _iMenuCustID = iCustID
        _iMenuQCTypeID = iQCTypeID
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
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents cboQCType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnPass As System.Windows.Forms.Button
    Friend WithEvents btnFail As System.Windows.Forms.Button
    Friend WithEvents lblPassed As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents grdQCFailRate As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblDeviceLoc As System.Windows.Forms.Label
    Friend WithEvents lblTotalGoodUnitsByCell As System.Windows.Forms.Label
    Friend WithEvents cboCodes As C1.Win.C1List.C1Combo
    Friend WithEvents cboUsers As C1.Win.C1List.C1Combo
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSelectCustByPalletID As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblMainInputName As System.Windows.Forms.Label
    Friend WithEvents lblDateCode As System.Windows.Forms.Label
    Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
    Friend WithEvents lblDevRepType As System.Windows.Forms.Label
    Friend WithEvents pnlComponentQTY As System.Windows.Forms.Panel
    Friend WithEvents txtComponentQTY As System.Windows.Forms.TextBox
    Friend WithEvents lblComponentQTY As System.Windows.Forms.Label
    Friend WithEvents LabelFailOther As System.Windows.Forms.Label
    Friend WithEvents txtFailOther As System.Windows.Forms.TextBox
    Friend WithEvents pnlLotData As System.Windows.Forms.Panel
    Friend WithEvents lblLotSNNum As System.Windows.Forms.Label
    Friend WithEvents lblLotID As System.Windows.Forms.Label
    Friend WithEvents txtLotNum As System.Windows.Forms.TextBox
    Friend WithEvents btnLotDetail As System.Windows.Forms.Button
    Friend WithEvents btnLotClose As System.Windows.Forms.Button
    Friend WithEvents lblPnlLotDataDetailUpDown As System.Windows.Forms.Label
    Friend WithEvents pnlOBCosmGrade As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblRepairType As System.Windows.Forms.Label
    Friend WithEvents cboOBCosmGrade As C1.Win.C1List.C1Combo
    Friend WithEvents lblSNDesc As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmQC))
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblMainInputName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblSNDesc = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboUsers = New C1.Win.C1List.C1Combo()
        Me.lblDateCode = New System.Windows.Forms.Label()
        Me.lblWrtyStatus = New System.Windows.Forms.Label()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.LabelFailOther = New System.Windows.Forms.Label()
        Me.txtFailOther = New System.Windows.Forms.TextBox()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.lstFailCodes = New System.Windows.Forms.ListBox()
        Me.cboCodes = New C1.Win.C1List.C1Combo()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlComponentQTY = New System.Windows.Forms.Panel()
        Me.txtComponentQTY = New System.Windows.Forms.TextBox()
        Me.lblComponentQTY = New System.Windows.Forms.Label()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDeviceLoc = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cboQCType = New PSS.Gui.Controls.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSelectCustByPalletID = New System.Windows.Forms.Button()
        Me.lblTotalGoodUnitsByCell = New System.Windows.Forms.Label()
        Me.btnFail = New System.Windows.Forms.Button()
        Me.btnPass = New System.Windows.Forms.Button()
        Me.lblPassed = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCostCenter = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grdQCFailRate = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblDevRepType = New System.Windows.Forms.Label()
        Me.pnlLotData = New System.Windows.Forms.Panel()
        Me.lblPnlLotDataDetailUpDown = New System.Windows.Forms.Label()
        Me.btnLotClose = New System.Windows.Forms.Button()
        Me.btnLotDetail = New System.Windows.Forms.Button()
        Me.txtLotNum = New System.Windows.Forms.TextBox()
        Me.lblLotID = New System.Windows.Forms.Label()
        Me.lblLotSNNum = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlOBCosmGrade = New System.Windows.Forms.Panel()
        Me.cboOBCosmGrade = New C1.Win.C1List.C1Combo()
        Me.lblRepairType = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFailCodes.SuspendLayout()
        CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlComponentQTY.SuspendLayout()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdQCFailRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLotData.SuspendLayout()
        Me.pnlOBCosmGrade.SuspendLayout()
        CType(Me.cboOBCosmGrade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.Yellow
        Me.txtSN.Location = New System.Drawing.Point(88, 88)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(244, 20)
        Me.txtSN.TabIndex = 4
        Me.txtSN.Text = ""
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Black
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(321, 64)
        Me.lblTitle.TabIndex = 56
        Me.lblTitle.Text = "Quality Control"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMainInputName
        '
        Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
        Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainInputName.ForeColor = System.Drawing.Color.Blue
        Me.lblMainInputName.Location = New System.Drawing.Point(20, 88)
        Me.lblMainInputName.Name = "lblMainInputName"
        Me.lblMainInputName.Size = New System.Drawing.Size(60, 19)
        Me.lblMainInputName.TabIndex = 55
        Me.lblMainInputName.Text = "SN:"
        Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(0, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 19)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Fail Code:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSNDesc, Me.cmdDelete, Me.grdHistory, Me.Label4, Me.lblSN, Me.Label6, Me.cboUsers})
        Me.Panel3.Location = New System.Drawing.Point(0, 256)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(976, 200)
        Me.Panel3.TabIndex = 2
        '
        'lblSNDesc
        '
        Me.lblSNDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblSNDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSNDesc.ForeColor = System.Drawing.Color.Red
        Me.lblSNDesc.Location = New System.Drawing.Point(272, 8)
        Me.lblSNDesc.Name = "lblSNDesc"
        Me.lblSNDesc.Size = New System.Drawing.Size(248, 24)
        Me.lblSNDesc.TabIndex = 91
        Me.lblSNDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.Red
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.Color.White
        Me.cmdDelete.Location = New System.Drawing.Point(528, 4)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(136, 27)
        Me.cmdDelete.TabIndex = 15
        Me.cmdDelete.Text = "Delete (Are you sure?)"
        Me.cmdDelete.Visible = False
        '
        'grdHistory
        '
        Me.grdHistory.AllowSort = False
        Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdHistory.Location = New System.Drawing.Point(7, 35)
        Me.grdHistory.Name = "grdHistory"
        Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdHistory.PreviewInfo.ZoomFactor = 75
        Me.grdHistory.Size = New System.Drawing.Size(956, 149)
        Me.grdHistory.TabIndex = 14
        Me.grdHistory.Text = "C1TrueDBGrid1"
        Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
        "t;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
        "5{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
        "olText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style" & _
        "13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""2" & _
        "4"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
        "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vert" & _
        "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>145</Height><CaptionStyle " & _
        "parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
        "owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
        "yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
        "e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
        "rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
        "><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
        "elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
        "rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 952, 145</ClientRect><BorderSide>0" & _
        "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
        "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
        "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
        "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
        "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
        "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
        "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
        "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
        "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
        "tRecSelWidth><ClientArea>0, 0, 952, 145</ClientArea><PrintPageHeaderStyle parent" & _
        "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 19)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "QC History for "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSN
        '
        Me.lblSN.BackColor = System.Drawing.Color.Transparent
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Red
        Me.lblSN.Location = New System.Drawing.Point(104, 7)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(160, 19)
        Me.lblSN.TabIndex = 76
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(664, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 19)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Tech:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboUsers
        '
        Me.cboUsers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboUsers.AutoCompletion = True
        Me.cboUsers.AutoDropDown = True
        Me.cboUsers.AutoSelect = True
        Me.cboUsers.Caption = ""
        Me.cboUsers.CaptionHeight = 17
        Me.cboUsers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUsers.ColumnCaptionHeight = 17
        Me.cboUsers.ColumnFooterHeight = 17
        Me.cboUsers.ColumnHeaders = False
        Me.cboUsers.ContentHeight = 15
        Me.cboUsers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboUsers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboUsers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboUsers.EditorHeight = 15
        Me.cboUsers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboUsers.ItemHeight = 15
        Me.cboUsers.Location = New System.Drawing.Point(712, 5)
        Me.cboUsers.MatchEntryTimeout = CType(2000, Long)
        Me.cboUsers.MaxDropDownItems = CType(10, Short)
        Me.cboUsers.MaxLength = 32767
        Me.cboUsers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboUsers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboUsers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboUsers.Size = New System.Drawing.Size(253, 21)
        Me.cboUsers.TabIndex = 90
        Me.cboUsers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'lblDateCode
        '
        Me.lblDateCode.BackColor = System.Drawing.Color.Black
        Me.lblDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateCode.ForeColor = System.Drawing.Color.Lime
        Me.lblDateCode.Location = New System.Drawing.Point(768, 165)
        Me.lblDateCode.Name = "lblDateCode"
        Me.lblDateCode.Size = New System.Drawing.Size(208, 20)
        Me.lblDateCode.TabIndex = 134
        Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDateCode.Visible = False
        '
        'lblWrtyStatus
        '
        Me.lblWrtyStatus.BackColor = System.Drawing.Color.Black
        Me.lblWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWrtyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWrtyStatus.ForeColor = System.Drawing.Color.Lime
        Me.lblWrtyStatus.Location = New System.Drawing.Point(768, 144)
        Me.lblWrtyStatus.Name = "lblWrtyStatus"
        Me.lblWrtyStatus.Size = New System.Drawing.Size(208, 20)
        Me.lblWrtyStatus.TabIndex = 133
        Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblWrtyStatus.Visible = False
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelFailOther, Me.txtFailOther, Me.cmdRemove, Me.lstFailCodes, Me.Label3, Me.cboCodes})
        Me.pnlFailCodes.Location = New System.Drawing.Point(0, 456)
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(665, 147)
        Me.pnlFailCodes.TabIndex = 3
        Me.pnlFailCodes.Visible = False
        '
        'LabelFailOther
        '
        Me.LabelFailOther.Location = New System.Drawing.Point(40, 128)
        Me.LabelFailOther.Name = "LabelFailOther"
        Me.LabelFailOther.Size = New System.Drawing.Size(56, 12)
        Me.LabelFailOther.TabIndex = 129
        Me.LabelFailOther.Text = "Fail Other:"
        Me.LabelFailOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFailOther
        '
        Me.txtFailOther.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.txtFailOther.Location = New System.Drawing.Point(96, 120)
        Me.txtFailOther.Name = "txtFailOther"
        Me.txtFailOther.Size = New System.Drawing.Size(448, 20)
        Me.txtFailOther.TabIndex = 128
        Me.txtFailOther.Text = ""
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.Color.White
        Me.cmdRemove.Location = New System.Drawing.Point(552, 40)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(84, 37)
        Me.cmdRemove.TabIndex = 12
        Me.cmdRemove.Text = "REMOVE"
        '
        'lstFailCodes
        '
        Me.lstFailCodes.Location = New System.Drawing.Point(97, 37)
        Me.lstFailCodes.Name = "lstFailCodes"
        Me.lstFailCodes.Size = New System.Drawing.Size(449, 82)
        Me.lstFailCodes.TabIndex = 11
        '
        'cboCodes
        '
        Me.cboCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCodes.AutoCompletion = True
        Me.cboCodes.AutoDropDown = True
        Me.cboCodes.AutoSelect = True
        Me.cboCodes.Caption = ""
        Me.cboCodes.CaptionHeight = 17
        Me.cboCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCodes.ColumnCaptionHeight = 17
        Me.cboCodes.ColumnFooterHeight = 17
        Me.cboCodes.ColumnHeaders = False
        Me.cboCodes.ContentHeight = 15
        Me.cboCodes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCodes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCodes.EditorHeight = 15
        Me.cboCodes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboCodes.ItemHeight = 15
        Me.cboCodes.Location = New System.Drawing.Point(99, 5)
        Me.cboCodes.MatchEntryTimeout = CType(2000, Long)
        Me.cboCodes.MaxDropDownItems = CType(10, Short)
        Me.cboCodes.MaxLength = 32767
        Me.cboCodes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCodes.Name = "cboCodes"
        Me.cboCodes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCodes.Size = New System.Drawing.Size(448, 21)
        Me.cboCodes.TabIndex = 89
        Me.cboCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Green
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(680, 480)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(128, 85)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "SAVE (F5)"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlComponentQTY, Me.cboCustomers, Me.Label7, Me.lblDeviceLoc, Me.Button4, Me.cboQCType, Me.Label8, Me.txtSN, Me.lblMainInputName})
        Me.Panel6.Location = New System.Drawing.Point(321, 64)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(343, 192)
        Me.Panel6.TabIndex = 1
        '
        'pnlComponentQTY
        '
        Me.pnlComponentQTY.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtComponentQTY, Me.lblComponentQTY})
        Me.pnlComponentQTY.Location = New System.Drawing.Point(8, 112)
        Me.pnlComponentQTY.Name = "pnlComponentQTY"
        Me.pnlComponentQTY.Size = New System.Drawing.Size(328, 32)
        Me.pnlComponentQTY.TabIndex = 127
        Me.pnlComponentQTY.Visible = False
        '
        'txtComponentQTY
        '
        Me.txtComponentQTY.BackColor = System.Drawing.Color.Yellow
        Me.txtComponentQTY.Location = New System.Drawing.Point(212, 8)
        Me.txtComponentQTY.Name = "txtComponentQTY"
        Me.txtComponentQTY.Size = New System.Drawing.Size(112, 20)
        Me.txtComponentQTY.TabIndex = 56
        Me.txtComponentQTY.Text = ""
        '
        'lblComponentQTY
        '
        Me.lblComponentQTY.BackColor = System.Drawing.Color.Transparent
        Me.lblComponentQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComponentQTY.ForeColor = System.Drawing.Color.Blue
        Me.lblComponentQTY.Location = New System.Drawing.Point(40, 6)
        Me.lblComponentQTY.Name = "lblComponentQTY"
        Me.lblComponentQTY.Size = New System.Drawing.Size(144, 19)
        Me.lblComponentQTY.TabIndex = 57
        Me.lblComponentQTY.Text = "Component Quantity:"
        Me.lblComponentQTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(88, 8)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(244, 21)
        Me.cboCustomers.TabIndex = 2
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(-32, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 16)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Customer:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDeviceLoc
        '
        Me.lblDeviceLoc.BackColor = System.Drawing.Color.Transparent
        Me.lblDeviceLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceLoc.ForeColor = System.Drawing.Color.Blue
        Me.lblDeviceLoc.Location = New System.Drawing.Point(16, 152)
        Me.lblDeviceLoc.Name = "lblDeviceLoc"
        Me.lblDeviceLoc.Size = New System.Drawing.Size(320, 19)
        Me.lblDeviceLoc.TabIndex = 84
        Me.lblDeviceLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(168, 286)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(234, 37)
        Me.Button4.TabIndex = 66
        Me.Button4.TabStop = False
        Me.Button4.Text = "Generate Report"
        '
        'cboQCType
        '
        Me.cboQCType.AutoComplete = True
        Me.cboQCType.BackColor = System.Drawing.SystemColors.Window
        Me.cboQCType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQCType.ForeColor = System.Drawing.Color.Black
        Me.cboQCType.Location = New System.Drawing.Point(88, 48)
        Me.cboQCType.Name = "cboQCType"
        Me.cboQCType.Size = New System.Drawing.Size(244, 21)
        Me.cboQCType.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 19)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "QC Type:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelectCustByPalletID
        '
        Me.btnSelectCustByPalletID.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSelectCustByPalletID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectCustByPalletID.ForeColor = System.Drawing.Color.White
        Me.btnSelectCustByPalletID.Location = New System.Drawing.Point(672, 72)
        Me.btnSelectCustByPalletID.Name = "btnSelectCustByPalletID"
        Me.btnSelectCustByPalletID.Size = New System.Drawing.Size(87, 60)
        Me.btnSelectCustByPalletID.TabIndex = 126
        Me.btnSelectCustByPalletID.Text = "Select Customer By Box Name"
        '
        'lblTotalGoodUnitsByCell
        '
        Me.lblTotalGoodUnitsByCell.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalGoodUnitsByCell.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGoodUnitsByCell.ForeColor = System.Drawing.Color.Red
        Me.lblTotalGoodUnitsByCell.Location = New System.Drawing.Point(680, 144)
        Me.lblTotalGoodUnitsByCell.Name = "lblTotalGoodUnitsByCell"
        Me.lblTotalGoodUnitsByCell.Size = New System.Drawing.Size(75, 56)
        Me.lblTotalGoodUnitsByCell.TabIndex = 85
        Me.lblTotalGoodUnitsByCell.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFail
        '
        Me.btnFail.BackColor = System.Drawing.Color.SteelBlue
        Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFail.ForeColor = System.Drawing.Color.White
        Me.btnFail.Location = New System.Drawing.Point(896, 72)
        Me.btnFail.Name = "btnFail"
        Me.btnFail.Size = New System.Drawing.Size(80, 64)
        Me.btnFail.TabIndex = 5
        Me.btnFail.Text = "FAIL       (F12)"
        '
        'btnPass
        '
        Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPass.ForeColor = System.Drawing.Color.White
        Me.btnPass.Location = New System.Drawing.Point(776, 72)
        Me.btnPass.Name = "btnPass"
        Me.btnPass.Size = New System.Drawing.Size(88, 64)
        Me.btnPass.TabIndex = 4
        Me.btnPass.Text = "PASS      (F9)"
        '
        'lblPassed
        '
        Me.lblPassed.BackColor = System.Drawing.Color.Black
        Me.lblPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassed.ForeColor = System.Drawing.Color.Lime
        Me.lblPassed.Location = New System.Drawing.Point(448, 32)
        Me.lblPassed.Name = "lblPassed"
        Me.lblPassed.Size = New System.Drawing.Size(200, 27)
        Me.lblPassed.TabIndex = 84
        Me.lblPassed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblPassed})
        Me.Panel2.Location = New System.Drawing.Point(321, -2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(655, 66)
        Me.Panel2.TabIndex = 86
        '
        'lblCostCenter
        '
        Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
        Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
        Me.lblCostCenter.Location = New System.Drawing.Point(448, 5)
        Me.lblCostCenter.Name = "lblCostCenter"
        Me.lblCostCenter.Size = New System.Drawing.Size(200, 19)
        Me.lblCostCenter.TabIndex = 101
        Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(256, 6)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(198, 19)
        Me.lblUserName.TabIndex = 100
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(256, 24)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(198, 18)
        Me.lblWorkDate.TabIndex = 99
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(256, 41)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(198, 19)
        Me.lblShift.TabIndex = 98
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(0, 41)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(254, 19)
        Me.lblMachine.TabIndex = 97
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(64, 24)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(128, 18)
        Me.lblLineSide.TabIndex = 96
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(0, 6)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(254, 19)
        Me.lblGroup.TabIndex = 95
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(0, 24)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(66, 18)
        Me.lblLine.TabIndex = 94
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(168, 286)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(234, 37)
        Me.Button2.TabIndex = 66
        Me.Button2.TabStop = False
        Me.Button2.Text = "Generate Report"
        '
        'grdQCFailRate
        '
        Me.grdQCFailRate.AllowArrows = False
        Me.grdQCFailRate.AllowColMove = False
        Me.grdQCFailRate.AllowColSelect = False
        Me.grdQCFailRate.AllowFilter = False
        Me.grdQCFailRate.AllowRowSelect = False
        Me.grdQCFailRate.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdQCFailRate.AllowSort = False
        Me.grdQCFailRate.AllowUpdate = False
        Me.grdQCFailRate.AllowUpdateOnBlur = False
        Me.grdQCFailRate.CaptionHeight = 17
        Me.grdQCFailRate.CausesValidation = False
        Me.grdQCFailRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdQCFailRate.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdQCFailRate.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.grdQCFailRate.Location = New System.Drawing.Point(1, 64)
        Me.grdQCFailRate.Name = "grdQCFailRate"
        Me.grdQCFailRate.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdQCFailRate.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdQCFailRate.PreviewInfo.ZoomFactor = 75
        Me.grdQCFailRate.RowHeight = 15
        Me.grdQCFailRate.Size = New System.Drawing.Size(320, 144)
        Me.grdQCFailRate.TabIndex = 88
        Me.grdQCFailRate.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{Font:Microsoft Sans Serif, 9pt, style=Bold;ForeColor:Lime;Bac" & _
        "kColor:Black;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{" & _
        "}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;AlignVert:" & _
        "Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8" & _
        "{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Sp" & _
        "lits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""False"" AllowCo" & _
        "lSelect=""False"" AllowRowSelect=""False"" Name="""" AllowRowSizing=""None"" CaptionHeig" & _
        "ht=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCel" & _
        "lBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Ho" & _
        "rizontalScrollGroup=""1""><Height>140</Height><CaptionStyle parent=""Style2"" me=""St" & _
        "yle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRo" & _
        "w"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle " & _
        "parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Heading" & _
        "Style parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me" & _
        "=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""" & _
        "OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" " & _
        "/><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Styl" & _
        "e1"" /><ClientRect>0, 0, 316, 140</ClientRect><BorderSide>0</BorderSide><BorderSt" & _
        "yle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><S" & _
        "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
        "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
        "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
        "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
        "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
        """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
        "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
        "Splits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAr" & _
        "ea>0, 0, 316, 140</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Pr" & _
        "intPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(848, 480)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(128, 85)
        Me.btnClear.TabIndex = 89
        Me.btnClear.Text = "CLEAR"
        '
        'lblDevRepType
        '
        Me.lblDevRepType.BackColor = System.Drawing.Color.Black
        Me.lblDevRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDevRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevRepType.ForeColor = System.Drawing.Color.Lime
        Me.lblDevRepType.Location = New System.Drawing.Point(768, 186)
        Me.lblDevRepType.Name = "lblDevRepType"
        Me.lblDevRepType.Size = New System.Drawing.Size(208, 20)
        Me.lblDevRepType.TabIndex = 135
        Me.lblDevRepType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDevRepType.Visible = False
        '
        'pnlLotData
        '
        Me.pnlLotData.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.pnlLotData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlLotData.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPnlLotDataDetailUpDown, Me.btnLotClose, Me.btnLotDetail, Me.txtLotNum, Me.lblLotID, Me.lblLotSNNum})
        Me.pnlLotData.Location = New System.Drawing.Point(664, 208)
        Me.pnlLotData.Name = "pnlLotData"
        Me.pnlLotData.Size = New System.Drawing.Size(312, 48)
        Me.pnlLotData.TabIndex = 136
        '
        'lblPnlLotDataDetailUpDown
        '
        Me.lblPnlLotDataDetailUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPnlLotDataDetailUpDown.ForeColor = System.Drawing.Color.SaddleBrown
        Me.lblPnlLotDataDetailUpDown.Location = New System.Drawing.Point(56, 32)
        Me.lblPnlLotDataDetailUpDown.Name = "lblPnlLotDataDetailUpDown"
        Me.lblPnlLotDataDetailUpDown.Size = New System.Drawing.Size(14, 16)
        Me.lblPnlLotDataDetailUpDown.TabIndex = 5
        Me.lblPnlLotDataDetailUpDown.Text = "0"
        '
        'btnLotClose
        '
        Me.btnLotClose.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnLotClose.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLotClose.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnLotClose.Location = New System.Drawing.Point(216, 3)
        Me.btnLotClose.Name = "btnLotClose"
        Me.btnLotClose.Size = New System.Drawing.Size(88, 40)
        Me.btnLotClose.TabIndex = 4
        Me.btnLotClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.btnLotClose, "Close Lot")
        '
        'btnLotDetail
        '
        Me.btnLotDetail.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.btnLotDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLotDetail.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.btnLotDetail.Location = New System.Drawing.Point(154, 3)
        Me.btnLotDetail.Name = "btnLotDetail"
        Me.btnLotDetail.Size = New System.Drawing.Size(56, 40)
        Me.btnLotDetail.TabIndex = 3
        Me.btnLotDetail.Text = "View"
        Me.ToolTip1.SetToolTip(Me.btnLotDetail, "Toggle Display/Hide Lot Detail")
        '
        'txtLotNum
        '
        Me.txtLotNum.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLotNum.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.txtLotNum.Location = New System.Drawing.Point(112, 2)
        Me.txtLotNum.Name = "txtLotNum"
        Me.txtLotNum.Size = New System.Drawing.Size(40, 41)
        Me.txtLotNum.TabIndex = 2
        Me.txtLotNum.Text = "0"
        Me.txtLotNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLotID
        '
        Me.lblLotID.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotID.ForeColor = System.Drawing.Color.SaddleBrown
        Me.lblLotID.Name = "lblLotID"
        Me.lblLotID.Size = New System.Drawing.Size(96, 16)
        Me.lblLotID.TabIndex = 1
        Me.lblLotID.Text = "f435435 "
        '
        'lblLotSNNum
        '
        Me.lblLotSNNum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLotSNNum.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lblLotSNNum.Location = New System.Drawing.Point(8, 16)
        Me.lblLotSNNum.Name = "lblLotSNNum"
        Me.lblLotSNNum.Size = New System.Drawing.Size(104, 24)
        Me.lblLotSNNum.TabIndex = 0
        Me.lblLotSNNum.Text = "Total in the Lot"
        Me.ToolTip1.SetToolTip(Me.lblLotSNNum, "Total devices scanned in the lot")
        '
        'pnlOBCosmGrade
        '
        Me.pnlOBCosmGrade.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlOBCosmGrade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlOBCosmGrade.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboOBCosmGrade, Me.lblRepairType, Me.Button1})
        Me.pnlOBCosmGrade.Location = New System.Drawing.Point(1, 210)
        Me.pnlOBCosmGrade.Name = "pnlOBCosmGrade"
        Me.pnlOBCosmGrade.Size = New System.Drawing.Size(320, 45)
        Me.pnlOBCosmGrade.TabIndex = 138
        '
        'cboOBCosmGrade
        '
        Me.cboOBCosmGrade.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboOBCosmGrade.Caption = ""
        Me.cboOBCosmGrade.CaptionHeight = 17
        Me.cboOBCosmGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboOBCosmGrade.ColumnCaptionHeight = 17
        Me.cboOBCosmGrade.ColumnFooterHeight = 17
        Me.cboOBCosmGrade.ContentHeight = 15
        Me.cboOBCosmGrade.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboOBCosmGrade.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboOBCosmGrade.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOBCosmGrade.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboOBCosmGrade.EditorHeight = 15
        Me.cboOBCosmGrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOBCosmGrade.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.cboOBCosmGrade.ItemHeight = 15
        Me.cboOBCosmGrade.Location = New System.Drawing.Point(8, 6)
        Me.cboOBCosmGrade.MatchEntryTimeout = CType(2000, Long)
        Me.cboOBCosmGrade.MaxDropDownItems = CType(5, Short)
        Me.cboOBCosmGrade.MaxLength = 32767
        Me.cboOBCosmGrade.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboOBCosmGrade.Name = "cboOBCosmGrade"
        Me.cboOBCosmGrade.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboOBCosmGrade.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboOBCosmGrade.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboOBCosmGrade.Size = New System.Drawing.Size(136, 21)
        Me.cboOBCosmGrade.TabIndex = 86
        Me.cboOBCosmGrade.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
        "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
        "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'lblRepairType
        '
        Me.lblRepairType.BackColor = System.Drawing.Color.Transparent
        Me.lblRepairType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepairType.ForeColor = System.Drawing.Color.Blue
        Me.lblRepairType.Location = New System.Drawing.Point(168, 8)
        Me.lblRepairType.Name = "lblRepairType"
        Me.lblRepairType.Size = New System.Drawing.Size(136, 24)
        Me.lblRepairType.TabIndex = 85
        Me.lblRepairType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(168, 286)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(234, 37)
        Me.Button1.TabIndex = 66
        Me.Button1.TabStop = False
        Me.Button1.Text = "Generate Report"
        '
        'frmQC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1000, 630)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlOBCosmGrade, Me.pnlLotData, Me.lblDevRepType, Me.btnClear, Me.grdQCFailRate, Me.Panel2, Me.Panel6, Me.btnSave, Me.pnlFailCodes, Me.Panel3, Me.lblTitle, Me.btnFail, Me.btnPass, Me.lblDateCode, Me.lblWrtyStatus, Me.btnSelectCustByPalletID, Me.lblTotalGoodUnitsByCell})
        Me.Name = "frmQC"
        Me.Text = "frmQC"
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFailCodes.ResumeLayout(False)
        CType(Me.cboCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.pnlComponentQTY.ResumeLayout(False)
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdQCFailRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLotData.ResumeLayout(False)
        Me.pnlOBCosmGrade.ResumeLayout(False)
        CType(Me.cboOBCosmGrade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            i = CheckIfMachineTiedToLine()

            If i = 0 Then
                Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
            End If

            If Me._iMenuCustID = NI.CUSTOMERID Then Me.cboOBCosmGrade.Visible = True Else Me.cboOBCosmGrade.Visible = False

            LoadQCTypes()
            If Me._iMenuQCTypeID > 0 Then
                Me.cboQCType.SelectedValue = Me._iMenuQCTypeID
                Me.cboQCType.Enabled = False
            End If

            LoadUsers()
            LoadCustomers()

            objQC.SetShiftInfo(iShiftID)
            Me.lblShift.Text = objQC.Shift
            Me.lblUserName.Text = "Inspector: " & strUserName
            'Me.lbldate.Text = "Date: " & Format(Now, "MM-dd-yyyy")
            If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then Me.lblMainInputName.Text = "IMEI/MEID:"

            '****************************************
            'Load inbound cosmetic grade
            '****************************************
            dt = Generic.GetCosmeticGrades(True)
            Misc.PopulateC1DropDownList(Me.cboOBCosmGrade, dt, "DCode_LDesc", "DCode_ID")
            Me.cboOBCosmGrade.SelectedValue = 0

            If Me.cboQCType.Enabled = False Then
                Me.txtSN.Focus()
            Else
                Me.cboQCType.Focus()
            End If

        Catch ex As Exception
            MsgBox("Error in frmQC_Load:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*********************************************************
    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            For Each R1 In dt1.Rows
                'iGroup_ID = R1("Group_ID")
                strGroup = Trim(R1("CC_Group_Desc"))
                iLine_ID = R1("Line_ID")
                strLineNumber = Trim(R1("Line_Number"))
                strLineSide = Trim(R1("LineSide_Desc"))
                Me.icc_id = R1("cc_id")
                Me._iCC_Group_ID = R1("CC_Group_ID")
                Me.lblCostCenter.Text = R1("CC_Group_Desc").ToString.ToUpper & " CELL " & R1("CostCenter").ToString.ToUpper
            Next R1

            Me.lblGroup.Text = "Group: " & strGroup
            Me.lblLine.Text = strLineNumber
            Me.lblLineSide.Text = strLineSide
            Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
            Me.lblUserName.Text = "User: " & strUserName
            Me.lblShift.Text = "Shift: " & iShiftID
            Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            objMisc = Nothing
        End Try
    End Function

    '*********************************************************
    Private Sub LoadQCPASSNumber()
        Dim dt1 As New DataTable()
        Dim R1 As DataRow

        Try
            If Me.cboQCType.SelectedValue = 0 Or iShiftID = 0 Or iUserID = 0 Then
                Exit Sub
            End If

            dt1 = objQC.GetQCPASSNumber(iUserID, iShiftID, Me.cboQCType.SelectedValue, Me._iCC_Group_ID)
            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                Me.lblPassed.Text = "Total Passed: " & R1("PassCount")
            Else
                Me.lblPassed.Text = "Total Passed: 0"
            End If

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadQCNumbers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            R1 = Nothing
            objQC.DisposeDT(dt1)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadQCTypes()
        Dim dtUsers As New DataTable()
        Try
            dtUsers = objQC.GetQCTypeInfo(False)
            With Me.cboQCType
                .DataSource = dtUsers.DefaultView
                .DisplayMember = dtUsers.Columns("QCType").ToString
                .ValueMember = dtUsers.Columns("QCType_id").ToString
                If Me._iCC_Group_ID = 14 Then
                    Me.cboQCType.SelectedValue = 1
                Else
                    .SelectedValue = 0
                End If
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadQCTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtUsers)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadUsers()
        Dim dtUsers As New DataTable()
        Try
            dtUsers = objQC.LoadUsers()
            With Me.cboUsers
                .DataSource = dtUsers.DefaultView
                .DisplayMember = dtUsers.Columns("user_fullname").ToString
                .ValueMember = dtUsers.Columns("user_id").ToString
                .Splits(0).DisplayColumns("user_id").Visible = False
                .Splits(0).DisplayColumns("user_fullname").Width = .Width - (.VScrollBar.Width + 4)

                If Me.iUserID = 867 Then
                    Me.cboUsers.SelectedValue = iUserID
                Else
                    .SelectedValue = 0
                End If
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadUsers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtUsers)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadFailureCodes(ByVal iProdID As Integer, Optional ByVal iLoc_ID As Integer = 0)
        Dim dtCodes As New DataTable()
        Dim i As Integer
        Try
            If Me._iMenuCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                dtCodes = objQC.LoadFailureCodes_WiKo(iProdID, iLoc_ID)
                'Added by Amazech-Thanga 07.08.2021
            ElseIf Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                dtCodes = objQC.LoadFailureCodes_WingTechATT(iProdID, iLoc_ID)
                'Added by Amazech-Thanga 07.09.2021
            ElseIf Me._iMenuCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                dtCodes = objQC.LoadFailureCodes_Vinsmart(iProdID, iLoc_ID)
            Else
                dtCodes = objQC.LoadFailureCodes(iProdID)
            End If

            With Me.cboCodes
                .DataSource = dtCodes.DefaultView
                .DisplayMember = dtCodes.Columns("DCode_SLDesc").ToString
                .ValueMember = dtCodes.Columns("DCode_ID").ToString
                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).Visible = False
                Next i
                .Splits(0).DisplayColumns("DCode_SLDesc").Visible = True
                .Splits(0).DisplayColumns("DCode_SLDesc").Width = .Width - (.VScrollBar.Width + 4)
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadFailureCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtCodes)
        End Try
    End Sub

    '*****************************************************************************
    Protected Overrides Sub Finalize()
        objQC = Nothing
        MyBase.Finalize()
    End Sub

    '*****************************************************************************
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddCodeToList()
    End Sub

    '*****************************************************************************
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        RemoveItemFromList()
    End Sub

    '*****************************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim dt1 As DataTable
        Dim strCompletedTech As String
        Dim iDevice_CC As Integer = 0
        Dim objFrmMD As QualityControl.frmGetManufactureDate
        Dim drCellopt As DataRow
        Dim strTempSN As String

        If e.KeyValue = 13 Then
            Me._bIsNTF = False

            If Me.txtSN.Text.Trim.Length = 0 Then
                Exit Sub
            ElseIf Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.cboCustomers.Focus()
                Exit Sub
            ElseIf Me.cboQCType.SelectedValue = 0 Then
                MessageBox.Show("Please select QC Type.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.cboQCType.Focus()
                Exit Sub
            ElseIf Me._iCC_Group_ID = 0 Then
                MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                'Me.cboGroup.Focus()
                Exit Sub
            ElseIf iLine_ID = 0 Then
                MessageBox.Show("Line ID missing. This machine is not mapped to any Line.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                'Me.cboLine.Focus()
                Exit Sub
            End If
            ' remove (SN:) to the SN for Vivint New Model
            If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then
                strTempSN = String.Empty
                If (Me.txtSN.Text).Substring(0, 3) = "SN:" Then
                    strTempSN = (Me.txtSN.Text).Substring(3)
                Else
                    strTempSN = Me.txtSN.Text
                End If
                Me.txtSN.Text = strTempSN
            End If
            '-------------------VIVINT CHECK IF THE ORDERTYPE IS BER OR SCRAP----------------------------

            'MsgBox(objQC.GetVivintOrderType(Trim(Me.txtSN.Text)))
            Dim dtVivint As New DataTable()
            dtVivint = objQC.GetVivintOrderType(Trim(Me.txtSN.Text))
            Dim row As DataRow, bFoundBERBillCode As Boolean = False
            For Each row In dtVivint.Rows
                If Convert.ToInt16(row("BillCode_ID")) = 4614 Or Convert.ToInt16(row("BillCode_ID")) = 4630 Then
                    bFoundBERBillCode = True : Exit For
                End If
            Next
            If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID And bFoundBERBillCode Then
                MessageBox.Show("Device belongs to BER OR SCRAP and Can't be QC, ", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.txtSN.Focus()
                Exit Sub
            End If

            Try
                ResetControls()

                '******************************************
                'Get Device info and model type(Wip down/Non-WipeDown)
                ''******************************************
                dt1 = objQC.GetDeviceInfo(Trim(Me.txtSN.Text), Me.cboCustomers.SelectedValue, False)

                If dt1.Rows.Count > 0 Then
                    '************************************
                    Me._iProdID = CInt(dt1.Rows(0)("Prod_ID")) : Me._iLoc_ID = CInt(dt1.Rows(0)("Loc_ID"))
                    If (Me._iProdID = 1 OrElse Me._iProdID = 5) And Me.cboQCType.SelectedValue = 1 Then Me.cboUsers.SelectedValue = Me.iUserID
                    If Me._iProdID = 18 And Me.cboQCType.SelectedValue = 4 Then Me.pnlComponentQTY.Visible = True
                    LoadFailureCodes(Me._iProdID, Me._iLoc_ID)

                    If (Me._iProdID = 1 OrElse Me._iProdID = 2) And cboQCType.SelectedValue <> 4 And Me.icc_id = 0 Then
                        MessageBox.Show("This machine is not mapped to any 'Cost Center'.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtSN.Text = "" : Exit Sub
                    End If
                    If Not Me._objWIKO_BoxShip.GetAccount(Trim(Me.txtSN.Text), Me.cboCustomers.SelectedValue) = 1 Then
                        If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID AndAlso Me.cboQCType.SelectedValue = 2 _
                            AndAlso dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> PSS.Data.Buisness.WIKO.WIKO.WIKO_FQA_WorkStation _
                            AndAlso dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> PSS.Data.Buisness.WIKO.WIKO.WIKO_Label_WorkStation Then
                            Dim strSS As String = "Device is not in " & PSS.Data.Buisness.WIKO.WIKO.WIKO_FQA_WorkStation & _
                            " or " & PSS.Data.Buisness.WIKO.WIKO.WIKO_Label_WorkStation & "."
                            MessageBox.Show(strSS, "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.Text = "" : Exit Sub
                        End If
                    End If
                    'added By Amazech-Thanga 07.08.2021
                    If Not Me._objWingTechATT_BoxShip.GetAccount(Trim(Me.txtSN.Text), Me.cboCustomers.SelectedValue) = 1 Then
                        If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID AndAlso Me.cboQCType.SelectedValue = 2 _
                            AndAlso dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_FQA_WorkStation _
                            AndAlso dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Label_WorkStation Then
                            Dim strSS As String = "Device is not in " & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_FQA_WorkStation & _
                            " or " & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Label_WorkStation & "."
                            MessageBox.Show(strSS, "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.Text = "" : Exit Sub
                        End If
                    End If
                    If Not _iLoc_ID = _objVinsmart_Class.Vinsmart_Special_LOC_ID Then
                        'Added By Amazech-Thanga 07.09.2021
                        If Not Me._objVinsmart_BoxShip.GetAccount(Trim(Me.txtSN.Text), Me.cboCustomers.SelectedValue) = 1 Then
                            If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID AndAlso Me.cboQCType.SelectedValue = 2 _
                                AndAlso dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_FQA_WorkStation _
                                AndAlso dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Label_WorkStation Then
                                Dim strSS As String = "Device is not in " & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_FQA_WorkStation & _
                                " or " & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Label_WorkStation & "."
                                MessageBox.Show(strSS, "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtSN.Text = "" : Exit Sub
                            End If
                        End If
                    End If

                    SetBucketLotPanel()
                    Me.lblPnlLotDataDetailUpDown.Text = 0
                    '************************************

                    '************************************
                    'Get Native Instrument
                    '************************************
                    If Me._iMenuCustID = NI.CUSTOMERID Then
                        drCellopt = Generic.GetCelloptData(dt1.Rows(0)("Device_id"))
                        If IsNothing(drCellopt) Then
                            MessageBox.Show("Cellopt data is missing. Please contact IT.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        ElseIf drCellopt("OutBoundCosmGradeID").ToString.Trim = "0" AndAlso Generic.GetMaxBillRule(Convert.ToInt32(dt1.Rows(0)("Device_id"))) = 0 Then
                            MessageBox.Show("Out bound comestic grade is not defined.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        ElseIf drCellopt("WorkStation").ToString.Trim.ToUpper = "WAREHOUSE" Then
                            MessageBox.Show("Can't process unit in Warehouse station.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus() : Exit Sub
                        Else
                            Me.cboOBCosmGrade.SelectedValue = Convert.ToInt32(drCellopt("OutBoundCosmGradeID"))
                        End If
                        Me.lblRepairType.Text = NI.GetRepairType(Convert.ToInt32(dt1.Rows(0)("WO_ID")))(1)
                        If Me._iMenuQCTypeID <> 4 Then Me.cboOBCosmGrade.Enabled = False Else Me.cboOBCosmGrade.Enabled = True
                    End If
                    '************************************

                    Me.btnFail.Enabled = True : Me.btnPass.Enabled = True : Me.btnSave.Enabled = True
                    'Skullcandy Astro ------------------------------------------------------------------------------
                    If Me._iMenuCustID = PSS.Data.Buisness.Skullcandy.ASTRO_CUSTOMERID Then
                        If AstroValidation(dt1) = False Then Exit Sub Else Me.cboUsers.SelectedValue = PSS.Core.ApplicationUser.IDuser
                    End If

                    '-----------------------------------------------------------------------------------------------

                    If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        If dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper Then
                            MessageBox.Show("The device belongs to " & dt1.Rows(0)("WorkStation").ToString & " work station.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.txtSN.Text = "" : Exit Sub
                        End If
                    End If
                    Dim dtMariage As New DataTable()
                    Me.lblDeviceLoc.Text = Buisness.Generic.GetCostCenterDescOfDevice(dt1.Rows(0)("Device_id"))
                    Dim dtPretest As New DataTable()
                    'check for Pretest Information  before AQL added 0 5-04-2021 by Bonke

                    If dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID Then
                        Dim strAccount As String = dt1.Rows(0)("Account")
                        'If dt1.Rows(0)("Account") = "6K202Project" Or dt1.Rows(0)("Account") = "U318Project" Then
                        If dt1.Rows(0)("Account") = _objWIKO_Class.WIKO_SpecialProj_Type3 Or dt1.Rows(0)("Account") = _objWIKO_Class.WIKO_SpecialProj_Type4 Then
                            'check for Account and SIM card mariage for 
                            dtMariage = Me.objQC.GetDeviceSIMcard(dt1.Rows(0)("Device_id"), strAccount)
                            If Not dtMariage.Rows.Count > 0 Then
                                MessageBox.Show("The device has not SIM Card data")
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        End If
                        dtPretest = Me.objQC.GetDevicePretest(dt1.Rows(0)("Device_id"))
                        If Not dtPretest.Rows.Count > 0 Then
                            MessageBox.Show("The device has no Pretest Data", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If
                        Dim rowPretest As DataRow, boolPrestPass As Boolean = False
                        For Each row In dtPretest.Rows
                            If Convert.ToInt16(row("Pttf")) = 2515 Then
                                boolPrestPass = True : Exit For
                            End If
                        Next
                        If Not boolPrestPass Then
                            MessageBox.Show("The device had Failed the Pre-Test .", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If
                    End If
                    'Added By Amazech-Thanga 07.08.2021
                    If dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID Then
                        Dim strAccount As String = dt1.Rows(0)("Account")
                        If dt1.Rows(0)("Account") = _objWingTechATT_Class.WingTechATT_SpecialProj_Type3 Or dt1.Rows(0)("Account") = _objWingTechATT_Class.WingTechATT_SpecialProj_Type4 Then
                            'check for Account and SIM card mariage for 
                            dtMariage = Me.objQC.GetDeviceSIMcard(dt1.Rows(0)("Device_id"), strAccount)
                            If Not dtMariage.Rows.Count > 0 Then
                                MessageBox.Show("The device has not SIM Card data")
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        End If
                        dtPretest = Me.objQC.GetDevicePretest(dt1.Rows(0)("Device_id"))
                        If Not dtPretest.Rows.Count > 0 Then
                            MessageBox.Show("The device has no Pretest Data", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If
                        Dim rowPretest As DataRow, boolPrestPass As Boolean = False
                        For Each row In dtPretest.Rows
                            If Convert.ToInt16(row("Pttf")) = 2515 Then
                                boolPrestPass = True : Exit For
                            End If
                        Next
                        If Not boolPrestPass Then
                            MessageBox.Show("The device had Failed the Pre-Test .", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If
                    End If

                    'Added By Amazech-Thanga 07.09.2021
                    If dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Special_LOC_ID Then
                        Dim strAccount As String = dt1.Rows(0)("Account")
                        If dt1.Rows(0)("Account") = _objVinsmart_Class.Vinsmart_SpecialProj_Type3 Then 'Or dt1.Rows(0)("Account") = _objVinsmart_Class.Vinsmart_SpecialProj_Type4 Then
                            'check for Account and SIM card mariage for 
                            dtMariage = Me.objQC.GetDeviceSIMcard(dt1.Rows(0)("Device_id"), strAccount)
                            If Not dtMariage.Rows.Count > 0 Then
                                MessageBox.Show("The device has not SIM Card data")
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        End If
                        dtPretest = Me.objQC.GetDevicePretest(dt1.Rows(0)("Device_id"))
                        If Not dtPretest.Rows.Count > 0 Then
                            MessageBox.Show("The device has no Pretest Data", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If
                        Dim rowPretest As DataRow, boolPrestPass As Boolean = False
                        For Each row In dtPretest.Rows
                            If Convert.ToInt16(row("Pttf")) = 2515 Then
                                boolPrestPass = True : Exit For
                            End If
                        Next
                        If Not boolPrestPass Then
                            MessageBox.Show("The device had Failed the Pre-Test .", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If
                    End If
                    ' check for SIM Card mariage before AQL for 6K wiko special project

                    'Pretest check for Coolpad special project - Charles Hummer 16-Jul-2021
                    If dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.CP.CoolPad.CoolPad_Special_LOC_ID Then
                        dtPretest = Me.objQC.GetDevicePretest(dt1.Rows(0)("Device_id"))
                        If Not dtPretest.Rows.Count > 0 Then
                            MessageBox.Show("The device has no Pretest Data", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If

                        Dim rowPretest As DataRow, boolPrestPass As Boolean = False
                        For Each row In dtPretest.Rows
                            If Convert.ToInt16(row("Pttf")) = 2515 Then
                                boolPrestPass = True : Exit For
                            End If
                        Next
                        If Not boolPrestPass Then
                            MessageBox.Show("The device had Failed the Pre-Test .", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtSN.SelectAll()
                            Exit Sub
                        End If

                    End If
                    'added by Amazech - Thanga 23.07.2021
                    If cboQCType.Text = "AQL" Then
                        If dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID _
                        Or dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID Then
                            dtFlash = Me._objWIKO_BoxShip.GetDeviceFlashTestData(Me.txtSN.Text.Trim)
                            If Not dtFlash.Rows.Count > 0 Then
                                MessageBox.Show("The device either failed to pass Flash or has no Flash data. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            ElseIf dtFlash.Rows(0).IsNull("TestTResult") OrElse Trim(dtFlash.Rows(0).Item("TestTResult")).Length = 0 OrElse Not Trim(dtFlash.Rows(0).Item("TestTResult")).ToUpper = "Pass".ToUpper Then
                                MessageBox.Show("The device didn't pass Flash. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        End If
                        'Added By amazech-Thanga 26.07.2021
                    ElseIf cboQCType.Text = "FQA" Then
                        If dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID _
                        Or dt1.Rows(0)("Loc_id") = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID Then
                            dtPretest = Me.objQC.GetDevicePretest(dt1.Rows(0)("Device_id"))
                            If Not dtPretest.Rows.Count > 0 Then
                                MessageBox.Show("The device has no Pretest Data", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If

                            Dim rowPretest As DataRow, boolPrestPass As Boolean = False
                            For Each row In dtPretest.Rows
                                If Convert.ToInt16(row("Pttf")) = 2515 Then
                                    boolPrestPass = True : Exit For
                                End If
                            Next
                            If Not boolPrestPass Then
                                MessageBox.Show("The device had Failed the Pre-Test .", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        End If

                    End If

                    If Me._iProdID = 1 Or Me._iProdID = 2 Or Me._iProdID = 5 Then  'Messaging & Gaming
                        If cboQCType.SelectedValue = 4 Then     'AQL
                            Dim tLocId As Int32 = dt1.Rows(0)("Loc_id")
                            If objQC.IsQCPassed(dt1.Rows(0)("Device_id")) = False And Not _
                            ((tLocId = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID) Or (tLocId = PSS.Data.Buisness.CP.CoolPad.CoolPad_Special_LOC_ID)) Then     ' SKIP THE FQA For the 
                                '********************************
                                'Device must pass QC before AQL
                                '********************************
                                MessageBox.Show("Device has not been QC PASSED.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If
                        Else
                            '******************************************
                            'Validate DateCode for XBOX
                            '******************************************
                            If Me._iProdID = 5 And (dt1.Rows(0)("Model_ID") = 881 Or dt1.Rows(0)("Model_ID") = 1112) And cboQCType.SelectedValue <> 2 Then
                                objFrmMD = New QualityControl.frmGetManufactureDate(dt1.Rows(0)("Device_id"))
                                objFrmMD.ShowDialog(Me)
                                If objFrmMD.booReturnVal = False Then
                                    Me.txtSN.Focus()
                                    Me.txtSN.SelectAll()
                                    Exit Sub
                                End If
                            End If

                            '******************************************
                            'Validate billdata
                            '******************************************
                            If (Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID _
                                OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID) _
                                AndAlso dt1.Rows(0)("FuncRep") = 3 AndAlso dt1.Rows(0)("Incoming_NTF_Model_ID") = 0 Then
                                'If TracFone, NTF device (FuncRep=3), have not been failed in FQA (if FQA failed,device model would be changed to _FUN, incoming_NTF_Model_ID = orginal model_ID (X Model) which is greater than 0)
                                'This means NTF device. So do nothing (don't check bill data)

                                'But NTF has no cost center assinged, so just use currentFQA PC mapped costcenter
                                Buisness.Generic.UpdateCostCenterIDOfDevice(dt1.Rows(0)("Device_id"), Me.icc_id)

                                Me._bIsNTF = True

                            ElseIf _iLoc_ID = _objVinsmart_Class.Vinsmart_Special_LOC_ID Then
                                'Skip the billing test
                            Else
                                If objQC.HasBillDate(dt1.Rows(0)("Device_id")) = False Then
                                    MessageBox.Show("Device has not been Billed.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Me.txtSN.SelectAll()
                                    Exit Sub
                                End If
                            End If

                            '******************************************
                            'Can't Mix devices between cost center
                            '******************************************
                            iDevice_CC = Buisness.Generic.GetCostCenterIDOfDevice(dt1.Rows(0)("Device_id"))
                            'added by Amazech-Thanga 07.07.2021
                            If iDevice_CC = 0 AndAlso Not Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID AndAlso Not Me.cboCustomers.SelectedValue = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID AndAlso Not Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then
                                MessageBox.Show("This device does not belong to any Cost Center.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            ElseIf ((Me._iProdID = 1 AndAlso Me.cboQCType.SelectedValue = 1)) And Me.icc_id <> iDevice_CC Then
                                MessageBox.Show("This device belongs to " & Me.lblDeviceLoc.Text & ".", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtSN.SelectAll()
                                Exit Sub
                            End If

                            '*****************************************************
                            'Get total good units by cost center of scanned device
                            '*****************************************************
                            Me.lblTotalGoodUnitsByCell.Text = "Good Units" & Environment.NewLine & Me.objQC.GetTotalGoodUnitsByLocCC(dt1.Rows(0)("Loc_ID"), iDevice_CC, Me._iCC_Group_ID).ToString & " "
                            '*****************************************************
                        End If
                    End If

                    '***************************************************************************
                    iDevice_ID = dt1.Rows(0)("Device_id")
                    Me._iModelID = dt1.Rows(0)("Model_ID")
                    Me._iManufID = dt1.Rows(0)("Manuf_ID")
                    If Not IsDBNull(dt1.Rows(0)("Device_LaborLevel")) Then _iLaborLevel = dt1.Rows(0)("Device_LaborLevel") Else _iLaborLevel = 0
                    _iWO_GroupID = dt1.Rows(0)("Group_ID")
                    strCompletedTech = Generic.GetCelloptLastCompletedTech(iDevice_ID)
                    If strCompletedTech.Trim.Length > 0 AndAlso strCompletedTech.Trim.Split("-").Length > 0 Then Me.cboUsers.SelectedValue = CInt(strCompletedTech.Trim.Split("-")(0))
                    Me._iWrty = Data.Buisness.Generic.ConvertToSomething(dt1.Rows(0)("Device_ManufWrty"), 0)
                    If Me.cboCustomers.SelectedValue = 2258 Then Me._iFunRep = dt1.Rows(0)("FuncRep")

                    '******************************************
                    'WARRANTY INFORMATION and Device Type
                    ''******************************************
                    'Added By Amazech-Thanga 07.08.2021
                    If Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID AndAlso Me.cboCustomers.SelectedValue <> PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID AndAlso IsDBNull(dt1.Rows(0)("ManufDate")) AndAlso dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
                        Me.lblWrtyStatus.Visible = True
                        Me.lblDateCode.Visible = True
                        Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                        If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "IN WARRANTY" Else Me.lblWrtyStatus.Text = "OUT OF WARRANTY"
                    End If
                    If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Then
                        Me.lblTotalGoodUnitsByCell.Visible = False
                        Me.lblWrtyStatus.Visible = False
                        Me.lblDateCode.Visible = False
                        Me.lblDevRepType.Visible = False
                        Me.lblDeviceLoc.Text = "WIKO " & dt1.Rows(0)("Loc_Name") & " " & dt1.Rows(0)("WiKo_Customer_Name")
                        Me.lblDeviceLoc.Visible = True
                    End If
                    'Added By Amazech-Thanga 07.08.2021
                    If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                        Me.lblTotalGoodUnitsByCell.Visible = False
                        Me.lblWrtyStatus.Visible = False
                        Me.lblDateCode.Visible = False
                        Me.lblDevRepType.Visible = False
                        Me.lblDeviceLoc.Text = "WingTechATT " & dt1.Rows(0)("Loc_Name") & " " & dt1.Rows(0)("WingTechATT_Customer_Name")
                        Me.lblDeviceLoc.Visible = True
                    End If
                    'added by Amazech-Thanga 07.09.2021
                    If Me.cboCustomers.SelectedValue = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID Then
                        Me.lblTotalGoodUnitsByCell.Visible = False
                        Me.lblWrtyStatus.Visible = False
                        Me.lblDateCode.Visible = False
                        Me.lblDevRepType.Visible = False
                        Me.lblDeviceLoc.Text = "Vinsmart " & dt1.Rows(0)("Loc_Name") & " " & dt1.Rows(0)("Vinsmart_Customer_Name")
                        'Me.lblDeviceLoc.Text = "Vinsmart " & dt1.Rows(0)("Loc_Name") & " " & dt1.Rows(0)("Account")
                        Me.lblDeviceLoc.Visible = True
                    End If
                    If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID _
                       OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        Me.lblDevRepType.ForeColor = Color.Lime
                        If Me._bIsNTF Then 'dt1.Rows(0)("FuncRep") = 3 AndAlso dt1.Rows(0)("Incoming_NTF_Model_ID") = 0 Then
                            Me.lblDevRepType.Text = "NTF"
                        ElseIf dt1.Rows(0)("FuncRep") = 1 Then
                            Me.lblDevRepType.Text = "Functional"
                        ElseIf dt1.Rows(0)("FuncRep") = 0 Then
                            Me.lblDevRepType.Text = "Cosmetic"
                        Else
                            Me.lblDevRepType.Text = "Undetermined"
                            Me.lblDevRepType.ForeColor = Color.Red
                        End If
                        'If dt1.Rows(0)("FuncRep") = 1 Then Me.lblDevRepType.Text = "Functional" Else Me.lblDevRepType.Text = "Cosmetic"
                        Me.lblDevRepType.Visible = True
                    End If
                    ''******************************************
                Else
                    MessageBox.Show("The device scanned in does not exist.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtSN.Text = ""
                    Exit Sub
                End If

                '********************************
                'Get Device QC History
                '********************************
                LoadQCHistory()
                '********************************
                Me.cboCustomers.Enabled = False
                Me.cboQCType.Enabled = False
                Me.lblSN.Text = Trim(Me.txtSN.Text)
                If Me._iProdID = 18 Then
                    Me.txtComponentQTY.SelectAll()
                    Me.txtComponentQTY.Focus()
                Else
                    Me.txtSN.Text = ""
                    Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(objFrmMD) Then
                    objFrmMD.Dispose()
                    objFrmMD = Nothing
                End If
            End Try
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub

    '*****************************************************************************
    Private Sub LoadQCFailureRate()
        Dim dt1 As DataTable

        Try
            grdQCFailRate.DataSource = Nothing
            dt1 = objQC.LoadQCFailRate(PSS.Core.Global.ApplicationUser.Workdate, _
                                       PSS.Core.Global.ApplicationUser.IDuser, _
                                       Me.cboQCType.SelectedValue)
            Me.grdQCFailRate.ClearFields()
            Me.grdQCFailRate.DataSource = dt1.DefaultView
            SetgrdQCFailRateProperties()

        Catch ex As Exception
            Throw New Exception("frmQC.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
        Finally
            objQC.DisposeDT(dt1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub LoadQCHistory()
        Dim dt1 As DataTable

        Try
            dt1 = objQC.GetQCHistory(iDevice_ID)
            Me.grdHistory.ClearFields()
            Me.grdHistory.DataSource = dt1.DefaultView
            SetGridProperties()

        Catch ex As Exception
            Throw New Exception("frmQC.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
        Finally
            objQC.DisposeDT(dt1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub SetGridProperties()
        Dim iNumOfColumns As Integer = Me.grdHistory.Columns.Count
        Dim i As Integer

        'Heading style (Horizontal Alignment to Center)
        For i = 0 To (iNumOfColumns - 1)
            Me.grdHistory.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Next

        'Set individual column data horizontal alignment
        Me.grdHistory.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        'Set individual column data horizontal alignment
        With Me.grdHistory
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
        End With

        'Set Column Widths
        With Me.grdHistory
            .Splits(0).DisplayColumns(0).Width = 50
            .Splits(0).DisplayColumns(1).Width = 65
            .Splits(0).DisplayColumns(2).Width = 61
            .Splits(0).DisplayColumns(3).Width = 58
            .Splits(0).DisplayColumns(4).Width = 69
            .Splits(0).DisplayColumns(5).Width = 213
            .Splits(0).DisplayColumns(6).Width = 171
            .Splits(0).DisplayColumns(7).Width = 145
        End With

        'Make some columns invisible
        Me.grdHistory.Splits(0).DisplayColumns(8).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns(9).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns(10).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns(11).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns("QCType_ID").Visible = False
    End Sub

    '*****************************************************************************
    Private Sub ClearCodeList()
        Me.lstFailCodes.Items.Clear()
    End Sub

    '*****************************************************************************
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveQCInfo()
    End Sub

    '*****************************************************************************
    Private Function ConcatenateCodes() As String
        Dim i As Integer = 0
        Dim strCodes As String = ""

        For i = 0 To Me.lstFailCodes.Items.Count - 1
            'arrSplitLine = Split(Trim(lstFailCodes.Items(i)), strdelimiter) 'This fails. Split is a type and cannot be used as an expression 
            arrSplitLine = lstFailCodes.Items(i).Split(Trim(strdelimiter))
            strCodes += Trim(arrSplitLine(1))
            If i <> Me.lstFailCodes.Items.Count - 1 Then
                strCodes += ","
            End If

            ReDim arrSplitLine(0)
            arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
        Next i

        ReDim arrSplitLine(0)
        arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)

        Return strCodes
    End Function

    '*****************************************************************************
    Private Sub cboQCType_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQCType.SelectionChangeCommitted
        Try

            Me.pnlComponentQTY.Visible = False

            If Me.cboQCType.SelectedValue = 0 Then
                Me.cboQCType.Focus()
                Exit Sub
            End If

            LoadQCPASSNumber()
            LoadQCFailureRate()
            'Me.cboGroup.Focus()
            Me.txtSN.Focus()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "QC Type Selection", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*****************************************************************************
    Private Sub PassQC()

        'Skullcandy Astro ------------------------------------------------------------------------------
        If Me._iMenuCustID = PSS.Data.Buisness.Skullcandy.ASTRO_CUSTOMERID Then
            Dim objSkullcandy As New PSS.Data.Buisness.Skullcandy()
            Select Case objSkullcandy.Astro_GetModelRepairType(Me.lblSN.Text.Trim)
                Case objSkullcandy.ModelProcessType.Repair.ToString, objSkullcandy.ModelProcessType.TestOnly.ToString
                Case Else
                    MessageBox.Show("Scrap unit or undefined unit. No need to do QC!", "PassQC", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
            End Select
        End If
        '-----------------------------------------------------------------------------------------------

        If iDevice_ID = 0 Then
            MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        ElseIf Me._iProdID = 0 Then
            MessageBox.Show("Product ID is missing. Please scan in a device.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        ElseIf Me._iProdID = 18 And Me.cboQCType.SelectedValue = 4 And ValidateComponentQuantity() = False Then
            MessageBox.Show("Invalid Component Quantity ! The Component Quantity must be greater than 0", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtComponentQTY.Text = ""
            Me.txtComponentQTY.Focus()
            Exit Sub
        End If

        btnPass.BackColor = System.Drawing.Color.Red
        btnFail.BackColor = System.Drawing.Color.SteelBlue

        iQCResult = 1
        pnlFailCodes.Visible = False
        Me.cboCodes.SelectedValue = 0
        ClearCodeList()

        '****************************************
        'GAMESTOP Product and QC functional only
        '****************************************
        If Me._iProdID = 5 And Me.cboQCType.SelectedValue = 1 Then
            Me.SaveQCInfo()
        ElseIf Me.cboUsers.SelectedValue > 0 Then
            Me.SaveQCInfo()
        Else
            Me.cboUsers.Focus()
        End If
        '****************************************
    End Sub

    '*****************************************************************************
    Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
        PassQC()
    End Sub

    '*****************************************************************************
    Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
        FailQC()
    End Sub

    '*****************************************************************************
    Private Sub FailQC()
        If iDevice_ID = 0 Then
            MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If

        btnPass.BackColor = System.Drawing.Color.SteelBlue
        btnFail.BackColor = System.Drawing.Color.Red

        iQCResult = 2
        pnlFailCodes.Visible = True
        If Me.cboUsers.SelectedValue > 0 Then Me.cboCodes.Focus() Else Me.cboUsers.Focus()
    End Sub

    '*****************************************************************************
    Private Sub cboCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCodes.KeyUp

        If e.KeyValue = 13 AndAlso Me.cboCodes.SelectedValue = 3408 AndAlso Me.txtFailOther.Text = "" Then
            MsgBox("Please enter 'Fail Other' description.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
        ElseIf e.KeyValue = 13 AndAlso Me.iQCResult = 2 Then
            AddCodeToList()
        End If

    End Sub

    '*****************************************************************************
    Private Sub AddCodeToList()
        Dim i As Integer = 0


        If Me.cboCodes.SelectedValue = 0 Then
            MessageBox.Show("Please select the code again.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim strItem As String = Trim(Me.cboCodes.Text) & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & strdelimiter & Me.cboCodes.SelectedValue

        For i = 0 To Me.lstFailCodes.Items.Count - 1
            If Me.lstFailCodes.Items(i) = strItem Then     'UCase(txtDevice.Text) Then
                MsgBox("This code is already added to the list.", MsgBoxStyle.Information, "QC")
                Exit Sub
            End If
        Next

        Me.lstFailCodes.Items.Add(strItem)
        Me.cboCodes.SelectedValue = 0
    End Sub

    '*****************************************************************************
    Private Sub lstFailCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFailCodes.KeyUp
        If e.KeyValue = 13 Then     'Enter Key Pressed
            RemoveItemFromList()
        End If
    End Sub

    '*****************************************************************************
    Private Sub RemoveItemFromList()
        If Me.lstFailCodes.SelectedIndex <> -1 Then    'If nothing is selected
            Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
            Me.lstFailCodes.Refresh()
        End If
    End Sub

    '*****************************************************************************
    Private Sub btnPass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnPass.KeyUp
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub

    '*****************************************************************************
    Private Sub btnFail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnFail.KeyUp
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub

    '*****************************************************************************
    Private Sub AllControlsKeyupEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboQCType.KeyUp, cboUsers.KeyUp, cboCodes.KeyUp, lstFailCodes.KeyUp, grdHistory.KeyUp
        If e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        ElseIf e.KeyValue = 13 AndAlso sender.name = "cboUsers" AndAlso Me.iQCResult = 2 Then
            Me.cboCodes.Focus()
        End If
    End Sub

    '*****************************************************************************
    Private Sub SaveQCInfo()
        Dim i As Integer = 0, iWipOwnerID As Integer = 0, iWipOwnerSubLocID As Integer = 0
        Dim strFailCodes As String = ""
        Dim strNextWrkStation As String = ""
        Dim iStationFailed As Integer = 0
        Dim objDevice As PSS.Rules.Device
        Dim iGroupID As Integer = 0
        Dim objTFMis As PSS.Data.Buisness.TracFone.clsMisc
        Dim booSkipPSDStation As Boolean = False
        Dim booSkipSoftwareRefStation As Boolean = False
        Dim iDeviceQty As Integer = 0
        Dim booAMSSharedCust As Boolean = False

        '********************************************************************
        'Required Field validations.
        If PSS.Core.Global.ApplicationUser.IDuser = 0 Then
            MessageBox.Show("Inspector does not have a QC Stamp Number assigned.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If
        If Me._iProdID = 0 Then
            MessageBox.Show("Please select a Product.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.cboQCType.Focus()
            Exit Sub
        End If
        If iDevice_ID = 0 Then   'Adding a new Device_ID
            MessageBox.Show("Please scan in a device to do QC.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If
        If Me.cboQCType.SelectedValue = 0 Then
            MessageBox.Show("Please select QC Type.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cboQCType.Focus()
            Exit Sub
        End If

        If iQCResult = 0 Then
            MessageBox.Show("Please choose if this device passed or failed QC.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.btnPass.Focus()
            Exit Sub
        End If

        If iQCResult = 2 Then   'if failed
            iStationFailed = 1
            If Me.lstFailCodes.Items.Count = 0 Then
                MessageBox.Show("This device failed QC, so please select the QC reasons.", "QC", _
                MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCodes.Focus()
                Exit Sub
            End If
        End If
        If Me.cboUsers.SelectedValue = 0 Then
            MessageBox.Show("Please select the Tech who worked on this device.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.cboUsers.Focus()
            Exit Sub
        End If

        '**For messaging use device's group id other use machine mapped group id
        '**Change made on 2010-12-09: allows AQL machine to perform AMS and SkyTel device using the same PC
        If Me._iProdID = 1 AndAlso Me._iWO_GroupID > 0 Then iGroupID = _iWO_GroupID Else iGroupID = Me._iCC_Group_ID
        If iGroupID = 0 Then
            MessageBox.Show("Group ID missing.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            'Me.cboGroup.Focus()
            Exit Sub
        End If

        If Me._iProdID = 18 And Me.cboQCType.SelectedValue = 4 And iQCResult = 1 And ValidateComponentQuantity() = False Then
            MessageBox.Show("Invalid Component Quantity ! The Component Quantity must be greater than 0", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.txtComponentQTY.Text = "" : Me.txtComponentQTY.Focus() : Exit Sub
        ElseIf Me._iMenuCustID = NI.CUSTOMERID AndAlso iQCResult = 1 AndAlso Me.cboOBCosmGrade.SelectedValue = 0 Then
            MessageBox.Show("Please select outbound cosmetic grade.", "QC", _
            MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.cboOBCosmGrade.SelectAll() : Me.cboOBCosmGrade.Focus() : Exit Sub
        End If

        Try
            '**********************************
            'Get Wipowner for Messaging
            '**********************************
            booAMSSharedCust = Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(Me.cboCustomers.SelectedValue)
            If booAMSSharedCust _
              OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
              OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
              OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
              OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
              OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
              OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                Dim strMessScreenName As String = ""
                If Me.cboQCType.SelectedValue = 4 Then strMessScreenName = "AQL" Else strMessScreenName = "QC"
                iWipOwnerID = Data.Buisness.MessReceive.GetAMSNextWipOwner( _
                 Me.cboCustomers.SelectedValue, strMessScreenName, iStationFailed)
            End If
            '**********************************

            'Astro - Scrap all fail unit
            If Me._iMenuCustID = Data.Buisness.Skullcandy.ASTRO_CUSTOMERID AndAlso iStationFailed = 1 Then
                If Me.AstroScrapUnit() = False Then Exit Sub
            End If
            strFailCodes = ConcatenateCodes()

            If Me.txtComponentQTY.Text.Trim.Length > 0 Then
                iDeviceQty = Convert.ToInt32(Me.txtComponentQTY.Text)
            End If

            'TracFone,FQA, NTF, QC Failed, Find FUN model for this NTF X model================================================
            Me._iNTF_When_FQA_Failed_X2FUN_Model_ID = 0 'Reset
            If (Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID _
               OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID) _
               AndAlso Me.cboQCType.SelectedValue = 2 AndAlso Me._bIsNTF AndAlso iQCResult = 2 Then
                Dim iNTF_XModel_ID As Integer = Me._iModelID
                Dim dtModel As DataTable
                Dim objTriagedBox As New PSS.Data.Buisness.TracFone.TFTestBuildTriagedBox()
                Dim arrLstModelIDs As New ArrayList()
                Dim R1 As DataRow

                dtModel = objTriagedBox.GetTracfone_FUN_Model_By_NTF_XModel(iNTF_XModel_ID, "")
                If Not dtModel.Rows.Count > 0 Then
                    MessageBox.Show("Can't find FUN model. Failed to process it. See IT.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dtModel.Rows.Count > 1 Then
                    For Each R1 In dtModel.Rows
                        If Not arrLstModelIDs.Contains(R1("Model_ID")) Then
                            arrLstModelIDs.Add(R1("Model_ID"))
                        End If
                    Next
                    If arrLstModelIDs.Count = 1 Then
                        Me._iNTF_When_FQA_Failed_X2FUN_Model_ID = arrLstModelIDs(0)
                    Else
                        MessageBox.Show("Duplicate FUN models. Can't identify correct FUN model. Failed to process it. See IT.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else
                    Me._iNTF_When_FQA_Failed_X2FUN_Model_ID = dtModel.Rows(0).Item("Model_ID") 'need to use it to update tcellopt later in this SaveQCInfo SUB
                End If

                objTriagedBox = Nothing : arrLstModelIDs = Nothing
            End If '==========================================================================================================

            'Save QC data
            i = objQC.SaveQCResults(iDevice_ID, Me.cboQCType.SelectedValue, iQCResult, _
             strFailCodes, Me.cboUsers.SelectedValue, PSS.Core.Global.ApplicationUser.IDuser, _
             PSS.Core.Global.ApplicationUser.Workdate, iGroupID, iLine_ID, _
             Me._iProdID, icc_id, Me._iMenuCustID, 0, iDeviceQty, Trim(Me.txtFailOther.Text), _
             iWipOwnerID, iWipOwnerSubLocID)

            If i > 0 Then
                '**********************************
                'Set Wipowner for Messaging
                '**********************************
                If booAMSSharedCust _
                    OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Anna_CUSTOMER_ID _
                    OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Lahey_CUSTOMER_ID _
                    OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Masco_CUSTOMER_ID _
                    OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Franciscan_CUSTOMER_ID _
                    OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.Maine_CUSTOMER_ID _
                    OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.SkyTel.SMHC_CUSTOMER_ID Then
                    If iQCResult = 1 AndAlso cboQCType.Text = "AQL" Then
                        Generic.SetTmessdataWipOwnerdataForDevices(iDevice_ID, iWipOwnerID, iWipOwnerSubLocID, 0)
                    End If
                End If

                '***********************************************
                'If Pantech, select accessories to be shipped with device
                '***********************************************
                If Me._iMenuCustID = 2453 Then       'Pantech
                    Dim objAccData As New PSS.Data.Buisness.Accessories()
                    Dim strIMEI As String = objAccData.GetIMEI(Me.iDevice_ID)

                    If strIMEI.Length > 0 Then
                        Dim frmAccessories As New Gui.Pantech.Accessories( _
                         strIMEI, False, Gui.Pantech.Accessories.ShipType.QC)

                        frmAccessories.StartPosition = FormStartPosition.CenterScreen
                        frmAccessories.ShowDialog()
                    End If
                End If

                '***********************************************
                'Get and assign unit to workstation 
                '***********************************************
                If Me._iMenuCustID > 0 Then
                    If Me._iMenuCustID = 2258 Then       'TRACFONE ONLY
                        objTFMis = New PSS.Data.Buisness.TracFone.clsMisc()
                        booSkipPSDStation = objTFMis.IsNoPSDNeeded(_iModelID)
                        booSkipSoftwareRefStation = objTFMis.IsNoSoftwareRefNeeded(_iModelID)

                        '***************************
                        'Tracfone warranty
                        '***************************
                        If Me.cboQCType.SelectedValue = 2 AndAlso iQCResult = 1 AndAlso PushToRF2() = 1 Then
                            strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, , 1)
                        ElseIf Me.cboQCType.SelectedValue = 2 AndAlso iQCResult = 1 AndAlso _
                         Me._iManufID = 24 AndAlso booSkipPSDStation = True Then
                            strNextWrkStation = "SOFTWARE REFURBISH"          'Nokia phone need to go to Software refurbish
                            If booSkipSoftwareRefStation = True Then strNextWrkStation = "BOX" 'Nokia phone Android
                        ElseIf Me.cboQCType.SelectedValue = 2 AndAlso iQCResult = 1 AndAlso booSkipPSDStation = True Then
                            strNextWrkStation = "BOX"
                        ElseIf Me.cboQCType.SelectedValue = 2 Then
                            strNextWrkStation = Generic.GetNextWorkStationInWFP( _
                             Me._strScreenName, 0, Me._iMenuCustID, iStationFailed, )
                        End If

                        'NTF----------------------------------------------------------------------------------------------------
                        If Me._bIsNTF AndAlso Me.cboQCType.SelectedValue = 2 AndAlso iQCResult = 1 Then 'NTF, FQA, Passed
                            strNextWrkStation = "BOX"
                        ElseIf Me._bIsNTF AndAlso Me.cboQCType.SelectedValue = 2 AndAlso iQCResult = 2 Then 'NTF, FQA, Failed
                            strNextWrkStation = "REFURBISHED/TECH"
                        End If 'NTF----------------------------------------------------------------------------------------------

                        '***************************
                    ElseIf Me._iMenuCustID = NI.CUSTOMERID Then       'Native Instruments
                        strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, iStationFailed, )
                        If Me.lblRepairType.Text.Trim.ToLower = "repairthisunit" Then strNextWrkStation = "WAITING OBA"
                        'Save Outbound cosmetic grade
                        If Me.cboQCType.SelectedValue = 4 AndAlso Me.iQCResult = 1 Then
                            objQC.SaveOutBoundCosmGrade(Me.iDevice_ID, Me.cboOBCosmGrade.SelectedValue)
                        End If
                    End If


                    If strNextWrkStation.Trim.Length > 0 Then
                        Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, iDevice_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                        If (Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID _
                            OrElse Me.cboCustomers.SelectedValue = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID) _
                            AndAlso Me.cboQCType.SelectedValue = 2 AndAlso Me._bIsNTF AndAlso iQCResult = 2 Then
                            If Me._iNTF_When_FQA_Failed_X2FUN_Model_ID > 0 Then
                                Dim k As Integer
                                k = Generic.UpdateDevice_XModel_FUN_Model(iDevice_ID, Me._iModelID, Me._iNTF_When_FQA_Failed_X2FUN_Model_ID)
                                If k > 0 Then 'Successed
                                    lblDevRepType.Text = lblDevRepType.Text & " (X to FUN model)"
                                Else
                                    MessageBox.Show("Failled to update. Your data have been partically saved. See IT.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("iNTF_When_FQA_Failed_X2FUN_Model_ID has invalid number. Your data have been partically saved. See IT.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If

                        MessageBox.Show("QC Results are saved. Unit has been pushed to " & strNextWrkStation & " work station.", _
                        "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("QC Results are saved.", "QC", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("QC Results are saved.", "QC", _
                     MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                ''***********************************************
                ''Bill Final Functional Inspection service code
                ''***********************************************
                'If Me.cboCustomers.SelectedValue > 0 AndAlso Me.cboCustomers.SelectedValue = Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso PSS.Data.Buisness.Generic.IsBillcodeMapped(Me._iModelID, 1614) > 0 Then
                '    If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.iDevice_ID, 1614) = False Then
                '        objDevice = New PSS.Rules.Device(Me.iDevice_ID)
                '        objDevice.AddPart(1614)
                '        objDevice.Update()
                '    End If
                'End If
                '***********************************************
            End If

            LoadQCHistory()
            LoadQCPASSNumber()
            LoadQCFailureRate()

            iQCResult = 0
            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.SteelBlue

            Me.cboCodes.SelectedValue = 0
            Me.lstFailCodes.Items.Clear()
            Me.pnlFailCodes.Visible = False
            Me.iDevice_ID = 0 : Me._iFunRep = 0 : Me._iLaborLevel = 0 : Me._iManufID = 0
            Me._iModelID = 0 : Me._iWrty = 0 : Me._iWO_GroupID = 0
            If Me._iMenuCustID = 0 Then Me.cboCustomers.Enabled = True
            If Me._iMenuQCTypeID = 0 Then Me.cboQCType.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "QC", _
             MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(objDevice) Then
                objDevice.Dispose()
                objDevice = Nothing
            End If
            Me.txtSN.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Function PushToRF2() As Integer
        Dim dt As DataTable
        Dim objTFBillingData As Buisness.TracFone.TFBillingData
        Dim iPushtoRF2 As Integer = 0

        Try
            If _iLaborLevel > 2 OrElse Me._iFunRep = 1 Then
                iPushtoRF2 = 1
            Else
                'Check if device is claimable
                objTFBillingData = New Buisness.TracFone.TFBillingData()
                If Me._iWrty = 1 Then
                    dt = objTFBillingData.GetMaxClaimablePartsAndReflowTuningLevel(Me.iDevice_ID, Me._iManufID)
                    If dt.Rows.Count > 0 AndAlso dt.Rows(0)("LaborLevel") > 1 Then iPushtoRF2 = 1
                End If
            End If

            Return iPushtoRF2
        Catch ex As Exception
            Throw ex
        Finally
            objTFBillingData = Nothing
            Generic.DisposeDT(dt)
        End Try
    End Function

    '********************************************************************
    Private Sub btnSave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSave.KeyUp
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        End If
    End Sub

    '********************************************************************
    Private Sub cmdRemove_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdRemove.KeyUp
        If e.KeyValue = Keys.Return Then
            RemoveItemFromList()
        End If
        If e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        End If
    End Sub

    '*********************************************************************
    Private Sub ResetControls()
        Me.cboUsers.SelectedValue = 0
        Me._iModelID = 0
        Me._iManufID = 0
        Me._iFunRep = 0
        Me._iWrty = 0
        iQCResult = 0
        iDevice_ID = 0
        _iWO_GroupID = 0
        'Me.txtSN.Text = ""
        Me.lblSN.Text = ""
        Me.lblTotalGoodUnitsByCell.Text = ""
        Me.lblDateCode.Text = ""
        Me.lblWrtyStatus.Text = ""
        Me.lblDevRepType.Text = ""
        Me.lblDateCode.Visible = False
        Me.lblWrtyStatus.Visible = False
        Me.lblDevRepType.Visible = False
        btnPass.BackColor = System.Drawing.Color.SteelBlue
        btnFail.BackColor = System.Drawing.Color.SteelBlue
        Me.cboCodes.SelectedValue = 0
        Me.lstFailCodes.Items.Clear()
        Me.pnlFailCodes.Visible = False
        Me.grdHistory.DataSource = Nothing
        Me.pnlComponentQTY.Visible = False
        Me.txtComponentQTY.Text = ""
        Me.cboOBCosmGrade.Enabled = True
        Me.cboOBCosmGrade.SelectedValue = 0
        Me.lblSNDesc.Text = ""

        _iProdID = 0
    End Sub

    '*********************************************************************
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim i, iMaxQCID As Integer
        Dim strWorkstation As String = ""

        Try
            If Me.grdHistory.Columns.Count > 0 Then
                If Len(Me.grdHistory.Columns("QC_ID").Value) = 0 Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            iMaxQCID = CInt(Me.grdHistory.DataSource.Table.Compute("Max(QC_ID)", ""))
            If CInt(Me.grdHistory.Columns("QC_ID").Value) <> iMaxQCID Then
                MessageBox.Show("System only allows to delete the latest record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this QC result?", "Delete QC History", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                i = objQC.DeleteQCHistory(CInt(Me.grdHistory.Columns("QC_ID").Value), iUserID, System.Net.Dns.GetHostName)

                '***********************************
                'Reset QC Flag in tmessdata table
                '***********************************
                If Me._iProdID = 1 Then    'Messaging
                    If Me.grdHistory.Columns("QC Type").Value.ToString.Trim = "Functional" Or Me.grdHistory.Columns("QC Type").Value.ToString.Trim = "AQL" Then
                        i += objQC.ResetMsgQCResult(Me.iDevice_ID, Me.grdHistory.Columns("QC Type").Value.ToString.Trim)
                    End If
                ElseIf Me.cboCustomers.SelectedValue = 2258 Then    'Tracfone
                    'Reset Workstation
                    If CInt(Me.grdHistory.Columns("QCType_ID").Value) = 2 Then
                        strWorkstation = "FQA"
                    ElseIf CInt(Me.grdHistory.Columns("QCType_ID").Value) = 4 Then
                        strWorkstation = "AQL-OBA"
                    End If

                    If strWorkstation.Trim.Length > 0 Then Generic.SetTcelloptWorkStationForDevice(strWorkstation, Me.iDevice_ID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , , , , , )
                End If
                '***********************************

                If i > 0 Then
                    'MessageBox.Show("Deleted successfully", "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    LoadQCHistory()
                Else
                    MessageBox.Show("Unable to delete QC history. Contact administrators.", "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************************
    Private Sub SetgrdQCFailRateProperties()
        Dim iNumOfColumns As Integer = Me.grdQCFailRate.Columns.Count
        Dim i As Integer

        With Me.grdQCFailRate
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            'header forecolor
            .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Body Forecolor
            .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Lime
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Lime
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Lime
            .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Lime

            'Set Column Widths
            .Splits(0).DisplayColumns(0).Width = 72
            .Splits(0).DisplayColumns(1).Width = 53
            .Splits(0).DisplayColumns(2).Width = 49
            .Splits(0).DisplayColumns(3).Width = 74

            '.Splits(0).DisplayColumns(0).Visible = False
        End With
    End Sub

    '*********************************************************************
    Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Me.cboCustomers.SelectedValue > 0 Then Me.cboQCType.Focus()
        End If
    End Sub

    '*********************************************************************
    Private Sub LoadCustomers()
        Dim dt As DataTable
        Dim iCustID As Integer = 0

        Try
            '****************************************
            'Load Customer
            '***************************************
            Me.cboCustomers.DataSource = Nothing
            dt = Generic.GetCustomers(True, , )
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            If _iMenuCustID > 0 Then
                Me.cboCustomers.SelectedValue = _iMenuCustID
                Me.cboCustomers.Enabled = False
            Else
                iCustID = Generic.GetCustIDByMachine()
                Me.cboCustomers.SelectedValue = iCustID
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '*********************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            Me.ResetControls()
            If Me._iMenuCustID = 0 Then Me.cboCustomers.Enabled = True
            If Me._iMenuQCTypeID = 0 Then Me.cboQCType.Enabled = True
            Me.txtSN.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in btnClear_Click")
        End Try
    End Sub

    '*********************************************************************
    Private Sub btnSelectCustByPalletID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectCustByPalletID.Click
        Dim strPalletname As String = ""
        Try
            strPalletname = InputBox("Enter Box Name:").Trim
            If strPalletname.Length > 0 Then
                Me.cboCustomers.SelectedValue = Me.objQC.GetCustIDByPalletName(strPalletname)
                Me.cboQCType.SelectedValue = 4
                Me.txtSN.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSelectCustByPalletID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************************
    Private Sub cboProduct_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnSelectCustByPalletID.Visible = False
    End Sub

    '********************************************************************
    Private Function ValidateComponentQuantity() As Boolean

        Me.txtComponentQTY.Text = Trim(Me.txtComponentQTY.Text)

        If Me.txtComponentQTY.Text = "" Then
            Return False
        ElseIf IsNumeric(Me.txtComponentQTY.Text) = False Then
            Return False
        ElseIf CInt(Me.txtComponentQTY.Text) < 1 Then
            Return False
        Else
            Return True
        End If

    End Function

    '*********************************************************************
    Private Function IsMessagingFQA() As Boolean
        Dim iProd As Integer = 0
        Dim iQCType As Integer = 0

        'Messaging and FQA
        If IsNumeric(Me._iProdID) Then iProd = _iProdID
        If IsNumeric(Me.cboQCType.SelectedValue) Then iQCType = Me.cboQCType.SelectedValue

        If iProd = 1 And iQCType = 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    '*********************************************************************
    Private Sub SetBucketLotPanel()
        If ApplicationUser.GetPermission("QC_Delete") > 0 Then
            Me.cmdDelete.Visible = True
        Else
            Me.cmdDelete.Visible = False
        End If

        If IsMessagingFQA() And Me.EnableAQLInspectionLog Then
            Me.pnlLotData.Visible = True
            Me.cmdDelete.Visible = False
        Else
            Me.pnlLotData.Visible = False
        End If
    End Sub

    '*****************************************************************************
    Private Function AstroValidation(ByVal dt As DataTable) As Boolean
        Dim objSkullcandy As New PSS.Data.Buisness.Skullcandy()
        Dim objSkullcandyRec As New PSS.Data.Buisness.SkullcandyRec()
        Dim strDateCodeResutlt As String = ""
        Dim dtPalletInfo As New DataTable(), dtScrapPallet As DataTable

        Try
            AstroValidation = False
            strDateCodeResutlt = objSkullcandy.Astro_GetModelRepairType(Me.txtSN.Text.Trim)
            Me.lblSNDesc.Text = "Date code Status: " & strDateCodeResutlt

            If Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 Then
                dtPalletInfo = Me.objQC.GetPalletInfo(dt.Rows(0)("Pallett_ID"))    '
                If dtPalletInfo.Rows.Count = 0 Then Throw New Exception("Lot/Pallet is missing.")

                If dtPalletInfo.Rows.Count = 0 Then
                    MessageBox.Show("Device belongs to a lot but system could not define that lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Convert.ToInt16(dtPalletInfo.Rows(0)("Pallet_ShipType")) = 0 Then
                    MessageBox.Show("This unit belongs to a refurbish lot '" & dtPalletInfo.Rows(0)("Pallett_Name") & "'. Please remove it from lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Not IsDBNull(dtPalletInfo.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Device belongs to a shipped lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                End If
            End If

            Select Case strDateCodeResutlt
                Case objSkullcandy.ModelProcessType.Scrap.ToString
                    If dtPalletInfo.Rows.Count = 0 Then
                        dtScrapPallet = objSkullcandyRec.GetOpenPalletName(Me._iMenuCustID, Data.Buisness.Skullcandy.ASTRO_LOCID)

                        If dtScrapPallet.Rows.Count = 0 Then
                            MessageBox.Show("This unit is scrap by date code and no scrap pallet found. Please create scrap pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        ElseIf dtScrapPallet.Rows.Count > 1 Then
                            MessageBox.Show("This unit is scrap by date code and system found more than one open scrap pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        Else
                            Data.Production.Shipping.AssignDeviceToPallet(dt.Rows(0)("Device_ID"), dtScrapPallet.Rows(0)("Pallett_ID"))
                            MessageBox.Show("This unit is scrap by date code. Can't process perform any test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        End If
                    ElseIf Convert.ToInt16(dtPalletInfo.Rows(0)("Pallet_ShipType")) = 0 Then
                        MessageBox.Show("This unit is scrap by date code but belongs to a refurbish lot '" & dtPalletInfo.Rows(0)("Pallett_Name") & "'. Please remove it from Lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    Else
                        MessageBox.Show("This unit is scrap by date code. Can't perform any test.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If

                    Me.lblSNDesc.ForeColor = Color.Red
                    Me.btnFail.Enabled = False : Me.btnPass.Enabled = False : Me.btnSave.Enabled = False

                Case objSkullcandy.ModelProcessType.Repair.ToString, objSkullcandy.ModelProcessType.TestOnly.ToString
                    Me.lblSNDesc.ForeColor = Color.Blue
                    If dtPalletInfo.Rows.Count > 0 Then
                        MessageBox.Show("This unit belong to pallet '" & dtPalletInfo.Rows(0)("Pallett_Name") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
                Case Else
                    MessageBox.Show("Can't define date code status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.lblSNDesc.ForeColor = Color.Red
                    Me.btnFail.Enabled = False : Me.btnPass.Enabled = False : Me.btnSave.Enabled = False
                    Return False
            End Select

            Return True
        Catch ex As Exception
            Throw ex
        Finally
            objSkullcandy = Nothing : objSkullcandyRec = Nothing
            Generic.DisposeDT(dt) : Generic.DisposeDT(dtPalletInfo) : Generic.DisposeDT(dtScrapPallet)
        End Try
    End Function

    '*****************************************************************************
    Private Function AstroScrapUnit() As Boolean
        Dim objSkullcandyRec As New PSS.Data.Buisness.SkullcandyRec()
        Dim strDateCodeResutlt As String = ""
        Dim dtPalletInfo As New DataTable(), dtScrapPallet As DataTable
        Dim dt As DataTable

        Try
            AstroScrapUnit = False
            dt = objQC.GetDeviceInfo(Trim(Me.lblSN.Text), Me.cboCustomers.SelectedValue, False)

            If Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 Then
                dtPalletInfo = Me.objQC.GetPalletInfo(dt.Rows(0)("Pallett_ID"))    '
                If dtPalletInfo.Rows.Count = 0 Then
                    Throw New Exception("Lot/Pallet is missing.")
                ElseIf Convert.ToInt16(dtPalletInfo.Rows(0)("Pallet_ShipType")) = 0 Then
                    MessageBox.Show("This unit belongs to a refurbish lot '" & dtPalletInfo.Rows(0)("Pallett_Name") & "'. Please remove it from Lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf Not IsDBNull(dtPalletInfo.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Device belongs to a shipped Lot/Pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                Else
                    Return True
                End If
            End If

            dtScrapPallet = objSkullcandyRec.GetOpenPalletName(Me._iMenuCustID, Data.Buisness.Skullcandy.ASTRO_LOCID)
            If dtScrapPallet.Rows.Count = 0 Then
                MessageBox.Show("No scrap pallet found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            ElseIf dtScrapPallet.Rows.Count > 1 Then
                MessageBox.Show("System found more than one open scrap pallet.Please keep only one scrap pallet open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            Else
                Data.Production.Shipping.AssignDeviceToPallet(dt.Rows(0)("Device_ID"), dtScrapPallet.Rows(0)("Pallett_ID"))
            End If

            Return True
        Catch ex As Exception
            Throw ex
        Finally
            objSkullcandyRec = Nothing
            Generic.DisposeDT(dt) : Generic.DisposeDT(dtPalletInfo) : Generic.DisposeDT(dtScrapPallet)
        End Try
    End Function

End Class
