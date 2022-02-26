Imports System.IO
Imports PSS.Data.Buisness
Public Class frmBulkShipping
    Inherits System.Windows.Forms.Form
    Private _strScreenName As String = ""
    Private _iMenuCustID As Integer = 0
    Private objBulkShip As PSS.Data.Buisness.BulkShipping
    Private objMisc As PSS.Data.Buisness.Misc

    'Private iCust_ID As Integer = 0
    Private iLoc_ID As Integer = 0
    'Private strShipType As String = ""
    Private iShipType As Integer = 0
    Private strSKULength As String = ""
    Private iModel_ID As Integer = 0
    Private iFileCheckDone As Integer = 0
    Private strUser As String = PSS.Core.Global.ApplicationUser.User
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private iMachineGroup As Integer = PSS.Core.Global.ApplicationUser.GroupID
    'Private booVerifyShipped As Boolean = False
    Private iPallett_ID As Integer = 0
    Private strPalletName As String = ""
    Private strFilePath As String = ""
    Private strATCLEFilePath As String = "P:\Dept\ATCLE\Palet packing list\"
    Private strCellStarFilePath As String = "P:\Dept\Cellstar\Pallet packing list\"
    Private strGameStopFilePath As String = "P:\Dept\Game stop\Pallet packing list\"
    Private strTrimbleFilePath As String = "P:\Dept\Trimble\Pallet packing list\"
    Private strDyscernFilePath As String = "P:\Dept\Dyscern\Pallet packing list\"
    Private strSonitrolFilePath As String = "P:\Dept\Sonitrol\Pallet packing list\"
    Private strHTCFilePath As String = "P:\Dept\HTC\Pallet packing list\"

    'Private radioButtons(2) As RadioButton
    Private iHoldStatus As Integer = 0
    Private iFlg As Integer = 0
    Private iGroup_ID As Integer = 0
    Private iCust_ID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal strScreenName As String = "", _
                   Optional ByVal iCustID As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objBulkShip = New PSS.Data.Buisness.BulkShipping()
        objMisc = New PSS.Data.Buisness.Misc()
        'radioButtons(0) = Me.RadioRegular
        'radioButtons(1) = Me.RadioShipAndHold
        'radioButtons(2) = Me.RadioRemoveFromHold
        _strScreenName = strScreenName
        _iMenuCustID = iCustID
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
    Friend WithEvents lstRegular As System.Windows.Forms.ListBox
    Friend WithEvents lstRUR As System.Windows.Forms.ListBox
    Friend WithEvents lstRTM As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdShip As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCnt As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lstRURRTMParts As System.Windows.Forms.ListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lstWrongSKULength As System.Windows.Forms.ListBox
    Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lstDetail As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveFromHold As System.Windows.Forms.Button
    Friend WithEvents RadioRemoveFromHold As System.Windows.Forms.RadioButton
    Friend WithEvents RadioShipAndHold As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRegular As System.Windows.Forms.RadioButton
    Friend WithEvents PanelList As System.Windows.Forms.Panel
    Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProdIDs As C1.Win.C1List.C1Combo
    Friend WithEvents pnlPalletList As System.Windows.Forms.Panel
    Friend WithEvents chkPrintReport As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBulkShipping))
        Me.lstRegular = New System.Windows.Forms.ListBox()
        Me.lstRUR = New System.Windows.Forms.ListBox()
        Me.lstRTM = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.lblCnt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioRemoveFromHold = New System.Windows.Forms.RadioButton()
        Me.RadioShipAndHold = New System.Windows.Forms.RadioButton()
        Me.RadioRegular = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lstWrongModel = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lstRURRTMParts = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lstWrongSKULength = New System.Windows.Forms.ListBox()
        Me.cmdFileCheck = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lstDetail = New System.Windows.Forms.ListBox()
        Me.chkPrintReport = New System.Windows.Forms.CheckBox()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.cmdRemoveFromHold = New System.Windows.Forms.Button()
        Me.PanelList = New System.Windows.Forms.Panel()
        Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
        Me.pnlPalletList = New System.Windows.Forms.Panel()
        Me.cboProdIDs = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PanelList.SuspendLayout()
        Me.pnlPalletList.SuspendLayout()
        CType(Me.cboProdIDs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstRegular
        '
        Me.lstRegular.Location = New System.Drawing.Point(7, 29)
        Me.lstRegular.Name = "lstRegular"
        Me.lstRegular.Size = New System.Drawing.Size(120, 186)
        Me.lstRegular.TabIndex = 5
        '
        'lstRUR
        '
        Me.lstRUR.Location = New System.Drawing.Point(132, 29)
        Me.lstRUR.Name = "lstRUR"
        Me.lstRUR.Size = New System.Drawing.Size(117, 186)
        Me.lstRUR.TabIndex = 4
        '
        'lstRTM
        '
        Me.lstRTM.Location = New System.Drawing.Point(252, 29)
        Me.lstRTM.Name = "lstRTM"
        Me.lstRTM.Size = New System.Drawing.Size(117, 186)
        Me.lstRTM.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Regular Units:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(132, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "RUR Units:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(252, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 32)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "RTM/Scrap/ Cancel Units:"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Location = New System.Drawing.Point(1, 1)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(327, 56)
        Me.lbl.TabIndex = 7
        Me.lbl.Text = "SHIP PALLETS"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(8, 223)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(104, 24)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Clear"
        '
        'cmdShip
        '
        Me.cmdShip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdShip.Enabled = False
        Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShip.ForeColor = System.Drawing.Color.Blue
        Me.cmdShip.Location = New System.Drawing.Point(492, 223)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(460, 24)
        Me.cmdShip.TabIndex = 1
        Me.cmdShip.Text = "SHIP"
        '
        'lblCnt
        '
        Me.lblCnt.BackColor = System.Drawing.Color.Black
        Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblCnt.Location = New System.Drawing.Point(666, 1)
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(78, 56)
        Me.lblCnt.TabIndex = 12
        Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(671, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "COUNT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioRemoveFromHold, Me.RadioShipAndHold, Me.RadioRegular})
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(400, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 89)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hold for Parts"
        '
        'RadioRemoveFromHold
        '
        Me.RadioRemoveFromHold.BackColor = System.Drawing.Color.SteelBlue
        Me.RadioRemoveFromHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioRemoveFromHold.ForeColor = System.Drawing.Color.White
        Me.RadioRemoveFromHold.Location = New System.Drawing.Point(17, 62)
        Me.RadioRemoveFromHold.Name = "RadioRemoveFromHold"
        Me.RadioRemoveFromHold.Size = New System.Drawing.Size(306, 16)
        Me.RadioRemoveFromHold.TabIndex = 2
        Me.RadioRemoveFromHold.Text = "REMOVE FROM HOLD AND PUT IT IN IN-TRANSIT"
        '
        'RadioShipAndHold
        '
        Me.RadioShipAndHold.Location = New System.Drawing.Point(17, 40)
        Me.RadioShipAndHold.Name = "RadioShipAndHold"
        Me.RadioShipAndHold.Size = New System.Drawing.Size(162, 16)
        Me.RadioShipAndHold.TabIndex = 1
        Me.RadioShipAndHold.Text = "SHIP AND HOLD"
        '
        'RadioRegular
        '
        Me.RadioRegular.Location = New System.Drawing.Point(17, 18)
        Me.RadioRegular.Name = "RadioRegular"
        Me.RadioRegular.Size = New System.Drawing.Size(162, 16)
        Me.RadioRegular.TabIndex = 0
        Me.RadioRegular.Text = "REGULAR SHIPPING"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(492, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 18)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Wrong Model:"
        '
        'lstWrongModel
        '
        Me.lstWrongModel.Location = New System.Drawing.Point(492, 29)
        Me.lstWrongModel.Name = "lstWrongModel"
        Me.lstWrongModel.Size = New System.Drawing.Size(117, 186)
        Me.lstWrongModel.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(372, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 29)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "RUR/RTM Units with Parts:"
        '
        'lstRURRTMParts
        '
        Me.lstRURRTMParts.Location = New System.Drawing.Point(372, 29)
        Me.lstRURRTMParts.Name = "lstRURRTMParts"
        Me.lstRURRTMParts.Size = New System.Drawing.Size(117, 186)
        Me.lstRURRTMParts.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(611, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 32)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Wrong SKU Length/Incomplete:"
        '
        'lstWrongSKULength
        '
        Me.lstWrongSKULength.Location = New System.Drawing.Point(612, 29)
        Me.lstWrongSKULength.Name = "lstWrongSKULength"
        Me.lstWrongSKULength.Size = New System.Drawing.Size(117, 186)
        Me.lstWrongSKULength.TabIndex = 8
        '
        'cmdFileCheck
        '
        Me.cmdFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFileCheck.ForeColor = System.Drawing.Color.Black
        Me.cmdFileCheck.Location = New System.Drawing.Point(133, 223)
        Me.cmdFileCheck.Name = "cmdFileCheck"
        Me.cmdFileCheck.Size = New System.Drawing.Size(339, 24)
        Me.cmdFileCheck.TabIndex = 0
        Me.cmdFileCheck.Text = "FILE CHECK (DO I HAVE THE RIGHT PALLET?)"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gold
        Me.Label9.Location = New System.Drawing.Point(732, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 16)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "DETAIL:"
        '
        'lstDetail
        '
        Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lstDetail.Location = New System.Drawing.Point(732, 29)
        Me.lstDetail.Name = "lstDetail"
        Me.lstDetail.Size = New System.Drawing.Size(217, 186)
        Me.lstDetail.TabIndex = 9
        '
        'chkPrintReport
        '
        Me.chkPrintReport.Checked = True
        Me.chkPrintReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintReport.ForeColor = System.Drawing.Color.White
        Me.chkPrintReport.Location = New System.Drawing.Point(17, 22)
        Me.chkPrintReport.Name = "chkPrintReport"
        Me.chkPrintReport.Size = New System.Drawing.Size(232, 24)
        Me.chkPrintReport.TabIndex = 0
        Me.chkPrintReport.Text = "PRINT PALLET REPORT"
        '
        'grdPallets
        '
        Me.grdPallets.AllowColMove = False
        Me.grdPallets.AllowColSelect = False
        Me.grdPallets.AllowFilter = False
        Me.grdPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdPallets.AllowUpdate = False
        Me.grdPallets.AllowUpdateOnBlur = False
        Me.grdPallets.AlternatingRows = True
        Me.grdPallets.Caption = "Pallet to be Shipped :"
        Me.grdPallets.CaptionHeight = 17
        Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Location = New System.Drawing.Point(0, 6)
        Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.RowHeight = 20
        Me.grdPallets.Size = New System.Drawing.Size(383, 160)
        Me.grdPallets.TabIndex = 1
        Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Font:Tahoma, 9" & _
        ".75pt, style=Bold;AlignHorz:Near;ForeColor:White;BackColor:SteelBlue;}Style9{}No" & _
        "rmal{Font:Microsoft Sans Serif, 8.25pt;BackColor:LightSteelBlue;AlignVert:Center" & _
        ";}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Back" & _
        "Color:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
        "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
        "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
        "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
        "="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCa" & _
        "ptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
        "electorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><Height>136</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Editor" & _
        "Style parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /" & _
        "><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" " & _
        "me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""He" & _
        "ading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Ina" & _
        "ctiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Styl" & _
        "e9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle" & _
        " parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRec" & _
        "t>0, 17, 379, 136</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bor" & _
        "derStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" " & _
        "me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""" & _
        "Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Ina" & _
        "ctive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edito" & _
        "r"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenR" & _
        "ow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSel" & _
        "ector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Gro" & _
        "up"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>" & _
        "None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 379, 1" & _
        "56</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterSt" & _
        "yle parent="""" me=""Style15"" /></Blob>"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrintReport})
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(400, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 56)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(760, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'lblPallet
        '
        Me.lblPallet.BackColor = System.Drawing.Color.Black
        Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.ForeColor = System.Drawing.Color.Lime
        Me.lblPallet.Location = New System.Drawing.Point(330, 1)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(334, 56)
        Me.lblPallet.TabIndex = 67
        Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdRemoveFromHold
        '
        Me.cmdRemoveFromHold.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdRemoveFromHold.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveFromHold.ForeColor = System.Drawing.Color.Blue
        Me.cmdRemoveFromHold.Location = New System.Drawing.Point(0, 176)
        Me.cmdRemoveFromHold.Name = "cmdRemoveFromHold"
        Me.cmdRemoveFromHold.Size = New System.Drawing.Size(383, 26)
        Me.cmdRemoveFromHold.TabIndex = 4
        Me.cmdRemoveFromHold.Text = "Remove from 'Parts Hold' and put it in 'In-transit'"
        Me.cmdRemoveFromHold.Visible = False
        '
        'PanelList
        '
        Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRUR, Me.lstRegular, Me.Label9, Me.lstWrongModel, Me.cmdShip, Me.lstDetail, Me.Label13, Me.lstRTM, Me.Label1, Me.Label2, Me.Label3, Me.Label12, Me.cmdClear, Me.lstRURRTMParts, Me.cmdFileCheck, Me.Label11, Me.lstWrongSKULength})
        Me.PanelList.Location = New System.Drawing.Point(2, 296)
        Me.PanelList.Name = "PanelList"
        Me.PanelList.Size = New System.Drawing.Size(968, 256)
        Me.PanelList.TabIndex = 1
        Me.PanelList.Visible = False
        '
        'cmdReprintPalletLabel
        '
        Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(400, 176)
        Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
        Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(336, 26)
        Me.cmdReprintPalletLabel.TabIndex = 3
        Me.cmdReprintPalletLabel.Text = "REPRINT PALLET LABEL"
        '
        'pnlPalletList
        '
        Me.pnlPalletList.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRemoveFromHold, Me.grdPallets, Me.GroupBox1, Me.GroupBox2, Me.cmdReprintPalletLabel})
        Me.pnlPalletList.Location = New System.Drawing.Point(8, 88)
        Me.pnlPalletList.Name = "pnlPalletList"
        Me.pnlPalletList.Size = New System.Drawing.Size(752, 208)
        Me.pnlPalletList.TabIndex = 4
        Me.pnlPalletList.Visible = False
        '
        'cboProdIDs
        '
        Me.cboProdIDs.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboProdIDs.Caption = ""
        Me.cboProdIDs.CaptionHeight = 17
        Me.cboProdIDs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboProdIDs.ColumnCaptionHeight = 17
        Me.cboProdIDs.ColumnFooterHeight = 17
        Me.cboProdIDs.ContentHeight = 15
        Me.cboProdIDs.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboProdIDs.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboProdIDs.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProdIDs.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboProdIDs.EditorHeight = 15
        Me.cboProdIDs.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboProdIDs.ItemHeight = 15
        Me.cboProdIDs.Location = New System.Drawing.Point(96, 64)
        Me.cboProdIDs.MatchEntryTimeout = CType(2000, Long)
        Me.cboProdIDs.MaxDropDownItems = CType(5, Short)
        Me.cboProdIDs.MaxLength = 32767
        Me.cboProdIDs.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboProdIDs.Name = "cboProdIDs"
        Me.cboProdIDs.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboProdIDs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboProdIDs.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboProdIDs.Size = New System.Drawing.Size(248, 21)
        Me.cboProdIDs.TabIndex = 2
        Me.cboProdIDs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Product Type:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(472, 64)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(272, 21)
        Me.cboCustomers.TabIndex = 3
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(400, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Customer:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmBulkShipping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(984, 565)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomers, Me.Label5, Me.cboProdIDs, Me.Label4, Me.pnlPalletList, Me.PanelList, Me.lblPallet, Me.Button1, Me.Label6, Me.lblCnt, Me.lbl})
        Me.Name = "frmBulkShipping"
        Me.Text = "Auto Ship Devices"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.PanelList.ResumeLayout(False)
        Me.pnlPalletList.ResumeLayout(False)
        CType(Me.cboProdIDs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Private Sub radioOptionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRegular.CheckedChanged, RadioRemoveFromHold.CheckedChanged, RadioShipAndHold.CheckedChanged

    '    Dim Found As Boolean = False
    '    Dim i As Integer = 0

    '    While i < radioButtons.GetLength(0) And Not Found
    '        If radioButtons(i).Checked Then
    '            Found = True
    '            iHoldStatus = i

    '            If iHoldStatus = 0 Then
    '                Me.lblGridCaption.Text = "Pallets to be Shipped:"
    '                Me.cmdRemoveFromHold.Visible = False
    '            ElseIf iHoldStatus = 1 Then
    '                Me.lblGridCaption.Text = "Pallets to be Shipped:"
    '                Me.cmdRemoveFromHold.Visible = False
    '            ElseIf iHoldStatus = 2 Then
    '                Me.lblGridCaption.Text = "Pallets Shipped but on Hold:"
    '                Me.cmdRemoveFromHold.Visible = True
    '            End If
    '            LoadPallets()
    '        End If
    '        i += 1
    '    End While
    'End Sub

    Private Sub ClearListControls()
        Me.lstRegular.Items.Clear()
        Me.lstRTM.Items.Clear()
        Me.lstRUR.Items.Clear()
        Me.lstRURRTMParts.Items.Clear()
        Me.lstWrongModel.Items.Clear()
        Me.lstWrongSKULength.Items.Clear()
        Me.lstDetail.Items.Clear()
        Me.lblCnt.Text = ""
        Me.lblPallet.Text = ""
        Me.PanelList.Visible = False
    End Sub

    'Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
    '    Dim iExcelNum As Integer = 0
    '    Dim iPSSNum As Integer = 0
    '    Dim R1 As DataRow
    '    Dim i As Integer = 0

    '    Try
    '        Me.cmdShip.Enabled = False
    '        Cursor.Current = Cursors.WaitCursor

    '        Me.BackColor = System.Drawing.Color.SteelBlue
    '        System.Windows.Forms.Application.DoEvents()

    '        RequiredDataValidation()
    '        ClearListControls()

    '        Me.OpenFileDialog1.ShowDialog()

    '        If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
    '            If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
    '                MsgBox("Please select an excel file for validation.")
    '            Else
    '                '************************************************
    '                Me.lblFileName.Text = NameOnlyFromFullPath(Me.OpenFileDialog1.FileName)
    '                '************************************************
    '                'Get pallett_id
    '                iPallett_ID = objBulkShip.GetPallettID(Trim(Me.lblFileName.Text))
    '                '************************************************
    '                'Initialise Variables
    '                iCust_ID = Me.cmbCustomer.SelectedValue
    '                iLoc_ID = Me.cmbLocation.SelectedValue
    '                iModel_ID = Me.cmbModel.SelectedValue
    '                strShipType = Me.cmbShipType.SelectedItem
    '                strSKULength = Me.cmbSkuLength.SelectedItem
    '                booVerifyShipped = Me.chkVerifyShipped.Checked
    '                '*********************
    '                'objBulkShip variables
    '                Me.objBulkShip.iLoc_ID = iLoc_ID
    '                Me.objBulkShip.strWorkDt = strWorkDate
    '                Me.objBulkShip.iShiftID = iShiftID
    '                Me.objBulkShip.struser = strUser
    '                Me.objBulkShip.iBulkShipped = 1     'A flag in tpallett table to show it was Bulk Shipped
    '                Select Case strShipType
    '                    Case "REGULAR"
    '                        Me.objBulkShip.iShipType = 0
    '                    Case "RUR"
    '                        Me.objBulkShip.iShipType = 1
    '                    Case "RTM"
    '                        Me.objBulkShip.iShipType = 9
    '                End Select
    '                '*********************
    '                iFileCheckDone = 0
    '                '************************************************
    '                'Step 1 :: Extract IMEI numbers from the excel file
    '                '************************************************
    '                Me.objBulkShip.strFilePath = Me.OpenFileDialog1.FileName
    '                iExcelNum = objBulkShip.ExtractSNs(booVerifyShipped)
    '                If iExcelNum > 0 Then

    '                    '#############################################################
    '                    ''' STEP2 ::
    '                    '''Obtain and set validation data.
    '                    ''' Broken down in to pieces as far as getting data is concerned 
    '                    ''' because not all customers need all these validations.
    '                    ''' This will be easier to brach out the code.
    '                    '#############################################################

    '                    '***********************************************************
    '                    '(A) :: Get Model
    '                    '***********************************************************
    '                    iPSSNum = objBulkShip.GetModel(booVerifyShipped)
    '                    If iPSSNum <> iPSSNum Then
    '                        Throw New Exception("cmdSelectFile_Click.GetModel:: Records from excel file don't have same number of records from PSS Database.")
    '                    End If

    '                    '***********************************************************
    '                    '(B) :: Get the SKU Length
    '                    '***********************************************************
    '                    iPSSNum = objBulkShip.GetSKU(booVerifyShipped)
    '                    If iPSSNum <> iPSSNum Then
    '                        Throw New Exception("cmdSelectFile_Click.GetSKU:: Records from excel file don't have same number of records from PSS Database.")
    '                    End If

    '                    '***********************************************************
    '                    '(C) :: Get Billcoderule
    '                    '***********************************************************
    '                    iPSSNum = objBulkShip.GetBillcodeRule(booVerifyShipped)
    '                    If iExcelNum <> iPSSNum Then
    '                        Throw New Exception("cmdSelectFile_Click.GetBillcodeRule:: Records from excel file don't have same number of records from PSS Database.")
    '                    Else
    '                        Me.lblCnt.Text = iPSSNum
    '                    End If

    '                    '#############################################################
    '                    'Step 3::
    '                    'write data to controls based on the business logic
    '                    '#############################################################


    '                    '*******************************************************
    '                    For Each R1 In objBulkShip.dtExcelSNs.Rows

    '                        '*******************************************************
    '                        '(A) Model Validation (For all customers)
    '                        '*******************************************************
    '                        If R1("Model_ID") <> iModel_ID Then
    '                            Me.lstWrongModel.Items.Add(Trim(R1("IMEI")))
    '                        End If

    '                        '*******************************************************
    '                        'CHECK SKU LENGTHS ONLY FOR REGULAR PHONES NOT RUR AND RTM PHONES
    '                        '*******************************************************
    '                        'If iCust_ID = 2019 Then
    '                        If strShipType = "REGULAR" Then
    '                            If Len(R1("Sku_Number")) >= 1 And Len(R1("Sku_Number")) <= 5 Then
    '                                If UCase(strSKULength) <> "SHORT" Then
    '                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
    '                                End If
    '                            ElseIf Len(R1("Sku_Number")) >= 6 And Len(R1("Sku_Number")) <= 15 Then
    '                                If UCase(strSKULength) <> "LONG" Then
    '                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
    '                                End If
    '                            Else
    '                                Throw New Exception("SKU length out of bounds.")
    '                            End If
    '                        End If
    '                        'End If

    '                        '*******************************************************
    '                        '(C) BILLCODERULE validation    (For all customers)
    '                        '*******************************************************
    '                        If R1("Billcode_rule") = 9 Then     'RTM
    '                            Me.lstRTM.Items.Add(Trim(R1("IMEI")))
    '                        ElseIf R1("Billcode_rule") = 1 Then 'RUR
    '                            Me.lstRUR.Items.Add(Trim(R1("IMEI")))
    '                        ElseIf R1("Billcode_rule") = 0 Then 'Regular
    '                            Me.lstRegular.Items.Add(Trim(R1("IMEI")))
    '                        End If
    '                        '*******************************************************
    '                        'RUR/RTMs have parts
    '                        '*******************************************************
    '                        If R1("RURRTMHasParts") = "1" Then
    '                            Me.lstRURRTMParts.Items.Add(Trim(R1("IMEI")))
    '                        End If

    '                    Next R1
    '                    '#############################################################
    '                    'Do Validations
    '                    '*******************************************************
    '                    DoValidation()
    '                    '*******************************************************
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Ship Cell Pallets (Load File)", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
    '    Finally
    '        R1 = Nothing
    '        Me.cmdShip.Enabled = True
    '        Cursor.Current = Cursors.Default
    '    End Try


    'End Sub

    'Public Function NameOnlyFromFullPath(ByVal strFilePath As String) As String
    '    'EXAMPLE: input ="C:\winnt\system32\kernel.dll, 
    '    'output = kernel.dll
    '    Dim iPos As Integer
    '    Dim strFilename As String = ""

    '    If strFilePath <> "" Then
    '        ''output = kernel.dll
    '        iPos = strFilePath.LastIndexOfAny("\")
    '        iPos += 1
    '        strFilename = strFilePath.Substring(iPos, (Len(strFilePath) - iPos))

    '        ''output = kernel Without extension
    '        iPos = strFilename.LastIndexOfAny(".")
    '        Return strFilename.Substring(0, iPos)
    '    Else
    '        Return ""
    '    End If
    'End Function

    Protected Overrides Sub Finalize()
        objMisc = Nothing
        objBulkShip = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        Dim i As Integer = 0

        Try
            '*****************************************************
            'If booVerifyShipped = True Then
            '    Throw New Exception("This pallet has already been shipped.")
            'End If

            '*****************************************************
            DoValidation()
            '*****************************************************
            'Make sure a file has been selected and FILE CHECK done
            If iFileCheckDone = 0 Then
                Me.cmdShip.Enabled = False
                Throw New Exception("File check has not been done.")
            ElseIf iFileCheckDone = 1 Then
                Me.cmdShip.Enabled = False
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("Serial Number (IMEI) you have scanned in to do 'File Check' did not exist in the file.")
            End If
            '******************************************************
            'Bulk SHIP now.
            Me.Enabled = False
            Me.cmdShip.Enabled = True
            Cursor.Current = Cursors.WaitCursor
            i = objBulkShip.BulkShip(Me.chkPrintReport.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , )
            '******************************************************

            iFileCheckDone = 0
            Me.cmdShip.Enabled = False
            'Me.PanelList.Visible = False
            Me.RadioRegular.Checked = True
            iHoldStatus = 0
            'iFlg = 0
            'Me.lblPallet.Text = ""
            'Me.lblCnt.Text = ""
            ClearControls()
            LoadPallets(Me.cboCustomers.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearControls()
    End Sub

    Private Sub ClearControls()

        iPallett_ID = 0
        iGroup_ID = 0
        strPalletName = ""
        iLoc_ID = 0
        iModel_ID = 0
        iShipType = 0
        strSKULength = ""
        iFlg = 0
        'iHoldStatus = 0

        'Me.RadioRegular.Checked = True
        Me.objBulkShip.iLoc_ID = 0
        'Me.objBulkShip.iShiftID = 0
        'Me.objBulkShip.struser = strUser
        'Me.objBulkShip.iBulkShipped = 1
        Me.objBulkShip.iShipType = 0
        Me.objBulkShip.strFilePath = ""
        Me.objBulkShip.iPallet_ID = 0
        Me.lblPallet.Text = ""
        Me.PanelList.Visible = False


        Me.lstRegular.Items.Clear()
        Me.lstDetail.Items.Clear()
        Me.lstRTM.Items.Clear()
        Me.lstRUR.Items.Clear()
        Me.lstRURRTMParts.Items.Clear()
        Me.lstWrongModel.Items.Clear()
        Me.lstWrongSKULength.Items.Clear()
        Me.lblCnt.Text = ""
        iFileCheckDone = 0
        Me.BackColor = System.Drawing.Color.SteelBlue
        System.Windows.Forms.Application.DoEvents()

        '*********************
        'objBulkShip Variables
        objBulkShip.iLoc_ID = 0
        objBulkShip.iBulkShipped = 0

        If Not IsNothing(objBulkShip.dtExcelSNs) Then
            objBulkShip.dtExcelSNs.Dispose()
            objBulkShip.dtExcelSNs = Nothing
        End If
        If Not IsNothing(objBulkShip.dtWO) Then
            objBulkShip.dtWO.Dispose()
            objBulkShip.dtWO = Nothing
        End If
        '*********************
    End Sub

    'Private Sub RequiredDataValidation()
    '    If Me.cmbShipType.SelectedItem = "" Then
    '        Throw New Exception("'Ship Type' is not selected.")
    '    End If
    '    If Me.cmbCustomer.SelectedValue = 0 Then
    '        Throw New Exception("Customer is not selected.")
    '    End If
    '    If Me.cmbLocation.SelectedValue = 0 Then
    '        Throw New Exception("Location is not selected.")
    '    End If
    '    If Me.cmbModel.SelectedValue = 0 Then
    '        Throw New Exception("Model is not selected.")
    '    End If
    '    If Me.cmbSkuLength.SelectedItem = "" Then
    '        Throw New Exception("'Sku Length' is not selected.")
    '    End If
    'End Sub


    Private Sub DoValidation()
        '***************************
        If IsNothing(objBulkShip.dtExcelSNs) Then
            Throw New Exception("Select an Excel file to ship.")
        End If
        If objBulkShip.dtExcelSNs.Rows.Count = 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are no devices to ship in this file. Please make sure you have selected the correct file and it has valid data.")
        End If
        '***************************
        'Check the Billcode rule of the device and the Selected ShipType.
        'If they are different then don't let them ship
        If iShipType = 0 Then   'REGULAR
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with REGULAR devices. Not allowed.")
            End If
            If Me.lstRTM.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RTM devices with REGULAR devices. Not allowed.")
            End If
        ElseIf iShipType = 1 Then   'RUR
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with RUR devices. Not allowed.")
            End If
            If Me.lstRTM.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RTM devices with RUR devices. Not allowed.")
            End If
        ElseIf iShipType = 9 Then   'RTM
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with RTM devices. Not allowed.")
            End If
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with RTM devices. Not allowed.")
            End If
        ElseIf iShipType = 8 Then   'Scrap
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with SCRAP devices. Not allowed.")
            End If
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with SCRAP devices. Not allowed.")
            End If
        ElseIf iShipType = 10 Then   'Cancel
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with CANCEL devices. Not allowed.")
            End If
            If Me.lstRUR.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship RUR devices with CANCEL devices. Not allowed.")
            End If
        Else
            Throw New Exception("'Ship Type' not determined.")
        End If

        '***************************
        'Discrepancies
        If Me.lstRURRTMParts.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are RUR/RTM devices that still have parts billed. Shipping not allowed.")
        End If
        If Me.lstWrongModel.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are devices of wrong model in the file. Shipping not allowed.")
        End If
        ''''If Me.lstWrongSKULength.Items.Count > 0 Then
        ''''    Me.BackColor = System.Drawing.Color.Red
        ''''    System.Windows.Forms.Application.DoEvents()
        ''''    Throw New Exception("There are devices of wrong SKU length in the file. Shipping not allowed.")
        ''''End If

        If Me.iCust_ID = 2219 Then
            If iShipType <> 9 Then
                If Me.lstWrongSKULength.Items.Count > 0 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("You are trying to ship INCOMPLETE devices with other type of devices. Not allowed.")
                End If
            End If
        Else
            If Me.lstWrongSKULength.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("There are devices of wrong SKU length in the file. Shipping not allowed.")
            End If
        End If
        '***************************

        Me.PanelList.Visible = True
    End Sub

    '*********************************************************
    'Form Load
    Private Sub frmBulkShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable

        Try
            Me.objBulkShip.iShiftID = iShiftID
            Me.objBulkShip.struser = strUser
            iHoldStatus = 0
            If iMachineGroup = 3 Then   'Cell2
                Me.chkPrintReport.Checked = False
            End If
            Me.RadioRegular.Select()

            If Me._iMenuCustID = 0 Then
                '**************************
                'Load Production
                '**************************
                'Populate product type
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProdIDs, dt, "Prod_Desc", "Prod_ID")
                Me.cboProdIDs.SelectedValue = 0
                'LoadPallets()
            Else
                Me.cboProdIDs.Enabled = False
                dt = Generic.GetCustomers(True, Me.cboProdIDs.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = Me._iMenuCustID
                Me.cboCustomers.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:frmBulkShipping_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '********************************************************
    'GetPalletsReadyToBeShipped
    Private Sub LoadPallets(ByVal iCustID As Integer)
        Dim dtPallets As DataTable

        Try
            ClearControls()
            dtPallets = Me.objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineGroup, Me.cboCustomers.SelectedValue)
            Me.grdPallets.ClearFields()
            Me.grdPallets.DataSource = dtPallets.DefaultView
            SetPalletGridProperties()
            ResetTransfers(iCustID)
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtPallets) Then
                dtPallets.Dispose()
                dtPallets = Nothing
            End If
        End Try
    End Sub
    '********************************************************
    Private Sub SetPalletGridProperties()
        Dim iNumOfColumns As Integer = Me.grdPallets.Columns.Count
        Dim i As Integer


        With Me.grdPallets
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 140
            .Splits(0).DisplayColumns(2).Width = 45
            .Splits(0).DisplayColumns(3).Width = 69
            .Splits(0).DisplayColumns(4).Width = 81

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(5).Visible = False
            .Splits(0).DisplayColumns(6).Visible = False
            .Splits(0).DisplayColumns(7).Visible = False
            .Splits(0).DisplayColumns(8).Visible = False

        End With
    End Sub

    Private Sub ResetTransfers(ByVal iCustID As Integer)
        ' Check for cellular devices whose WIP ownership was transferred and transfer them back to the original owner.
        Me.objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineGroup, iCustID)
    End Sub

    '********************************************************
    'Private Sub LoadCustomers()
    '    Dim dtCustomers As New DataTable()
    '    Try
    '        dtCustomers = objMisc.GetCustomers
    '        With Me.cmbCustomer
    '            .DataSource = dtCustomers.DefaultView
    '            .DisplayMember = dtCustomers.Columns("cust_name1").ToString
    '            .ValueMember = dtCustomers.Columns("Cust_ID").ToString
    '            .SelectedValue = 0 '2019       'ATCLE-AWS
    '        End With
    '        LoadLocations()
    '    Catch ex As Exception
    '        MsgBox("Error in frmBulkShipping.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
    '    Finally
    '        If Not IsNothing(dtCustomers) Then
    '            dtCustomers.Dispose()
    '            dtCustomers = Nothing
    '        End If
    '    End Try
    'End Sub
    '*********************************************************
    'Private Sub LoadLocations()
    '    Dim dtLoc As DataTable

    '    Try
    '        If Me.cmbCustomer.SelectedValue = 0 Then
    '            Exit Sub
    '        End If

    '        If Not IsNothing(dtLoc) Then
    '            dtLoc.Dispose()
    '            dtLoc = Nothing
    '        End If

    '        dtLoc = objMisc.GetLocations(Me.cmbCustomer.SelectedValue)
    '        '**************************************************
    '        'Fill the Customer combo box
    '        '**************************************************
    '        With Me.cmbLocation
    '            .DataSource = dtLoc.DefaultView
    '            .ValueMember = dtLoc.Columns("Loc_id").ToString
    '            .DisplayMember = dtLoc.Columns("Loc_Name").ToString
    '            .SelectedValue = 0

    '            'If Me.cmbCustomer.SelectedValue = 2019 Then
    '            '    .SelectedValue = 2540   'ALTX02
    '            'Else
    '            '    .SelectedValue = 0
    '            'End If
    '        End With

    '        '**************************************************
    '    Catch ex As Exception
    '        MsgBox("frmBulkShipping.LoadLocations: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
    '    Finally
    '        If Not IsNothing(dtLoc) Then
    '            dtLoc.Dispose()
    '            dtLoc = Nothing
    '        End If
    '    End Try
    'End Sub
    '*********************************************************
    'Private Sub LoadModels()
    '    Dim dtModels As New DataTable()
    '    Try
    '        dtModels = objMisc.GetModels()
    '        With Me.cmbModel
    '            .DataSource = dtModels.DefaultView
    '            .DisplayMember = dtModels.Columns("Model_Desc").ToString
    '            .ValueMember = dtModels.Columns("Model_ID").ToString
    '            .SelectedValue = 0
    '        End With

    '    Catch ex As Exception
    '        MsgBox("Error in frmBulkShipping.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
    '    Finally
    '        If Not IsNothing(dtModels) Then
    '            dtModels.Dispose()
    '            dtModels = Nothing
    '        End If
    '    End Try
    'End Sub
    '*********************************************************
    'Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
    '    Try
    '        LoadLocations()          'Fill the location combo box
    '    Catch ex As Exception
    '        MsgBox("frmBulkShipping.cboCustomer_SelectionChangeCommitted: " & ex.Message.ToString)
    '    End Try
    'End Sub
    '*********************************************************

    Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
        Dim strIMEI As String = ""
        Dim R1 As DataRow
        Dim iMatch As Integer = 0

        Try
            If Not IsNothing(objBulkShip.dtExcelSNs) Then

                Select Case iCust_ID
                    Case 2019, 2249      'ATCLE, HTC
                        strIMEI = InputBox("Please scan in a 'Serial Number' (IMEI) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("IMEI")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (IMEI) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (IMEI) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2113      'Brightpoint
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("SN")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2219      'gamestop
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("Serial")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2238      'Trimble Mobile Solutions
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("SN")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2245      'Liquidity Services/Dyscern
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("IMEI")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case 2242, 2254, 2259, 2278    'Sonitrol, Plexus Corp., PSSI Exchange, Advantor Systems/Infrasafe
                        strIMEI = InputBox("Please scan in a 'Serial Number' (SN) to make sure you have selected the right file.")
                        If strIMEI <> "" Then
                            For Each R1 In objBulkShip.dtExcelSNs.Rows
                                If strIMEI = Trim(R1("SN")) Then
                                    iMatch = 1
                                    Exit For
                                End If
                            Next R1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number (SN) exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number (SN) does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Case Else
                        Throw New Exception("Cust_ID is missing.")
                End Select
            End If

        Catch ex As Exception
            MsgBox("frmBulkShipping.cmdFileCheck_Click: " & ex.Message.ToString)
        Finally
            R1 = Nothing
        End Try

    End Sub
    '*********************************************************
    Private Sub lstRURRTMParts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRURRTMParts.SelectedIndexChanged
        Dim dt1 As New DataTable()
        Dim R1 As DataRow

        Try
            dt1 = objMisc.GetPartsForDevice(Trim(Me.lstRURRTMParts.Items(Me.lstRURRTMParts.SelectedIndex)))

            Me.lstDetail.Items.Clear()

            For Each R1 In dt1.Rows
                Me.lstDetail.Items.Add(Trim(R1("PSprice_Desc")))
            Next R1

        Catch ex As Exception
            MsgBox("frmBulkShipping.lstRURRTMParts_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub lstWrongModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWrongModel.SelectedIndexChanged
        Dim dt1 As New DataTable()
        Dim R1 As DataRow

        Try
            Me.lstDetail.Items.Clear()
            dt1 = objMisc.GetDeviceInfo(Trim(Me.lstWrongModel.Items(Me.lstWrongModel.SelectedIndex)))
            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                Me.lstDetail.Items.Add(Trim(R1("Model_desc")))
            End If

        Catch ex As Exception
            MsgBox("frmBulkShipping.lstWrongModel_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub lstWrongSKULength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWrongSKULength.SelectedIndexChanged
        Dim R1 As DataRow

        Try
            Me.lstDetail.Items.Clear()
            For Each R1 In objBulkShip.dtExcelSNs.Rows
                If Trim(R1("IMEI")) = Trim(Me.lstWrongSKULength.Items(Me.lstWrongSKULength.SelectedIndex)) Then
                    Me.lstDetail.Items.Add(Trim(R1("SKU_Number")))
                    Exit For
                End If
            Next R1
        Catch ex As Exception
            MsgBox("frmBulkShipping.lstWrongSKULength_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
        End Try
    End Sub

    Private Sub Asif()
        With Me.grdPallets
            'Dim x As String = "Group: " & .Splits(0).DisplayColumns(1).Width
            MsgBox(.Splits(0).DisplayColumns(1).Width & Environment.NewLine & _
            .Splits(0).DisplayColumns(2).Width & Environment.NewLine & _
            .Splits(0).DisplayColumns(3).Width & Environment.NewLine & _
            .Splits(0).DisplayColumns(4).Width & Environment.NewLine)
        End With

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(iHoldStatus)
        'Asif()
    End Sub

    Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
        If Me.grdPallets.Columns.Count = 0 Then
            Exit Sub
        End If
        If Me.RadioRemoveFromHold.Checked = True Then
            iPallett_ID = Me.grdPallets.Columns("pallett_id").Value
            Exit Sub
        End If
        If iFlg = 0 Then
            Exit Sub
        End If
        ProcessPallet()
    End Sub

    Private Sub ProcessPallet()
        Const iPackagingServiceCode As Integer = 1757
        Dim iExcelNum As Integer = 0
        Dim iPSSNum As Integer = 0
        Dim R1 As DataRow
        Dim i As Integer = 0
        Dim strFileLocation As String = ""
        Dim objDevice As Rules.Device

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            ClearListControls()
            Me.PanelList.Visible = False
            '************************************************
            'Retrieve Grid info
            '************************************************
            iPallett_ID = Me.grdPallets.Columns("pallett_id").Value
            strPalletName = Trim(Me.grdPallets.Columns("Pallet").Value.ToString)
            iLoc_ID = Me.grdPallets.Columns("Loc_ID").Value
            iModel_ID = Me.grdPallets.Columns("Model_ID").Value
            iShipType = Me.grdPallets.Columns("Pallet_ShipType").Value
            strSKULength = Trim(Me.grdPallets.Columns("SKU Length").Value.ToString)
            iGroup_ID = Me.grdPallets.Columns("group_id").Value

            iCust_ID = Me.grdPallets.Columns("Cust_ID").Value
            Select Case iCust_ID
                Case 2019      'ATCLE
                    strFilePath = strATCLEFilePath
                Case 2113      'Brightpoint
                    strFilePath = strCellStarFilePath
                Case 2219      'gamestop
                    strFilePath = strGameStopFilePath
                Case 2238      'Trimble Mobile Solutions
                    strFilePath = strTrimbleFilePath
                Case 2245      'Liquidity Services/Dyscern
                    strFilePath = strDyscernFilePath
                Case 2242      'Sonitrol
                    strFilePath = strSonitrolFilePath
                Case 2249      'HTC
                    strFilePath = strHTCFilePath
                Case 2254      'Plexus Corp.
                    strFilePath = "P:\Dept\Plexus\Pallet packing list\"
                Case 2259      'PSS Exchange
                    strFilePath = "P:\Dept\PSS Exchange\Pallet packing list\"
                Case 2278      'Advantor Systems/Infrasafe
                    strFilePath = "P:\Dept\Advantor Systems\Pallet packing list\"
                Case Else
                    Throw New Exception("Pallet manifest file path missing (Cust_ID in tpallett needs to be updated).")
            End Select
            '************************************************
            'Check if the excel file exists
            '************************************************
            strFileLocation = strFilePath & strPalletName & ".xls"
            If Not File.Exists(strFileLocation) Then
                Throw New Exception("Pallet Excel File was not found in '" & strFilePath & "'")
            End If
            '************************************************
            Me.lblPallet.Text = strPalletName
            '*********************
            'objBulkShip variables
            Me.objBulkShip.iLoc_ID = iLoc_ID
            Me.objBulkShip.iBulkShipped = 1
            Me.objBulkShip.iShipType = iShipType
            Me.objBulkShip.strFilePath = strFileLocation
            Me.objBulkShip.iPallet_ID = iPallett_ID
            Me.objBulkShip.iGroup_ID = iGroup_ID
            Me.objBulkShip.iShiftID = iShiftID
            Me.objBulkShip.struser = strUser
            Me.objBulkShip.iCust_ID = iCust_ID
            '*********************
            iFileCheckDone = 0
            '************************************************
            'Step 1 :: Extract IMEI numbers from the excel file
            '************************************************
            iExcelNum = objBulkShip.ExtractSNs()
            If iExcelNum > 0 Then

                '#############################################################
                ''' STEP2 ::
                '''Obtain and set validation data.
                ''' Broken down in to pieces as far as getting data is concerned 
                ''' because not all customers need all these validations.
                ''' This will be easier to brach out the code.
                '#############################################################

                '***********************************************************
                '(A) :: Get Model
                '***********************************************************
                iPSSNum = objBulkShip.GetModel()
                If iExcelNum <> iPSSNum Then
                    Throw New Exception("cmdSelectFile_Click.GetModel:: Records from excel file don't have same number of records from PSS Database.")
                End If
                '***********************************************************
                '(B) :: Get the SKU Length
                '***********************************************************
                If iCust_ID = 2019 Then      'ATCLE-AWS
                    iPSSNum = objBulkShip.GetSKU("IMEI")
                    If iExcelNum <> iPSSNum Then
                        Throw New Exception("cmdSelectFile_Click.GetSKU:: Records from excel file don't have same number of records from PSS Database.")
                    End If
                End If

                '***********************************************************
                '(C) :: Get Billcoderule
                '***********************************************************
                iPSSNum = objBulkShip.GetBillcodeRule()
                If iExcelNum <> iPSSNum Then
                    Throw New Exception("cmdSelectFile_Click.GetBillcodeRule:: Records from excel file don't have same number of records from PSS Database.")
                Else
                    Me.lblCnt.Text = iPSSNum
                End If

                '#############################################################
                'Step 3::
                'write data to controls based on the business logic
                '#############################################################

                '*******************************************************
                For Each R1 In objBulkShip.dtExcelSNs.Rows
                    '***************************************************************
                    'Bill Packaging service code for Advantor Systems/Infrasafe customer only
                    '***************************************************************
                    If iCust_ID = 2278 Then
                        If Generic.IsBillcodeMapped(Me.iModel_ID, iPackagingServiceCode) > 0 Then
                            objDevice = New Rules.Device(R1("Device_ID"))
                            objDevice.AddPart(iPackagingServiceCode)
                            objDevice.Update()
                            If Not IsNothing(objDevice) Then
                                objDevice.Dispose()
                                objDevice = Nothing
                            End If
                        Else
                            Me.ClearControls()
                            Throw New Exception("Packaging service billcode is not mapped. Please contact Material department.")
                        End If
                    End If
                    '***************************************************************

                    '*******************************************************
                    '(A) Model Validation (For all customers)
                    '*******************************************************
                    If R1("Model_ID") <> iModel_ID Then
                        Select Case iCust_ID
                            Case 2019, 2249 'ATCLE , HTC, TracFone
                                Me.lstWrongModel.Items.Add(Trim(R1("IMEI")))
                            Case 2113      'Brightpoint
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case 2219      'gamestop
                                If iShipType <> 0 And (R1("Model_ID") = 881 Or R1("Model_ID") = 1112) And (iModel_ID = 881 Or iModel_ID = 1112) Then
                                    'allow to mix xbox model for non-refurb unit
                                Else
                                    Me.lstWrongModel.Items.Add(Trim(R1("Serial")))
                                End If
                            Case 2238      'Trimble Mobile Solutions
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case 2245      'Liquidity Services/Dyscern
                                Me.lstWrongModel.Items.Add(Trim(R1("IMEI")))
                            Case 2242, 2254, 2259, 2278     'Sonitrol, Plexus Corp., PSS Exchange, Advantor Systems/Infrasafe
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case Else
                                Throw New Exception("Pallet manifest file path missing (Cust_ID in tpallett needs to be updated).")
                        End Select
                    End If

                    '*******************************************************
                    'CHECK SKU LENGTHS ONLY FOR REGULAR PHONES NOT RUR AND RTM PHONES
                    '*******************************************************
                    If iCust_ID = 2019 Then        'ATCLE-AWS (TracFone iCust_ID = 2258)
                        If iShipType = 0 Then       'REGULAR
                            If Len(R1("Sku_Number")) >= 1 And Len(R1("Sku_Number")) <= 5 Then
                                If UCase(strSKULength) <> "SHORT" Then
                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
                                End If
                            ElseIf Len(R1("Sku_Number")) >= 6 And Len(R1("Sku_Number")) <= 15 Then
                                If UCase(strSKULength) <> "LONG" Then
                                    Me.lstWrongSKULength.Items.Add(Trim(R1("IMEI")))
                                End If
                            Else
                                Throw New Exception("SKU length out of bounds.")
                            End If
                        End If
                    End If

                    '*******************************************************
                    '(C) BILLCODERULE validation    (For all customers)
                    '*******************************************************
                    Select Case iCust_ID
                        Case 2019      'ATCLE
                            '*******************************************************
                            If R1("Billcode_rule") = 9 Then     'RTM
                                Me.lstRTM.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("IMEI")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("IMEI")))
                            End If

                            '*******************************************************
                        Case 2113      'Brightpoint
                            '*******************************************************
                            If R1("Billcode_rule") = 9 Then     'RTM
                                Me.lstRTM.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 10 Then 'Cancel
                                Me.lstRTM.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                        Case 2219      'gamestop
                            '*******************************************************
                            If R1("Billcode_rule") = 8 Then     'Scrap
                                Me.lstRTM.Items.Add(Trim(R1("Serial")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("Serial")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("Serial")))
                            ElseIf R1("Billcode_rule") = 9 Then 'Incomplete     added by Lan 12/04/2006
                                Me.lstWrongSKULength.Items.Add(Trim(R1("Serial")))
                            End If
                            '*******************************************************
                        Case 2238      'Trimble Mobile Solutions
                            '*******************************************************
                            If R1("Billcode_rule") = 9 Then     'RTM
                                Me.lstRTM.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 10 Then 'Cancel
                                Me.lstRTM.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                        Case 2245      'Liquidity Services/Dyscern
                            '*******************************************************
                            If R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("IMEI")))
                            End If
                            '*******************************************************
                        Case 2242, 2254, 2259, 2278       'Sonitrol, Plexus Corp., PSS Exchange, Advantor Systems/Infrasafe
                            '*******************************************************
                            If R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            End If
                        Case 2249      'HTC
                            '*******************************************************
                            If R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("IMEI")))
                            End If
                            '*******************************************************
                        Case Else
                            Throw New Exception("Pallet manifest file path missing (Cust_ID in tpallett needs to be updated).")
                    End Select


                Next R1
                '#############################################################
                'Do Validations
                '*******************************************************
                DoValidation()
                '*******************************************************
            End If
            Me.PanelList.Visible = True
        Catch ex As Exception
            Me.PanelList.Visible = False
            iFlg = 0
            MessageBox.Show(ex.Message, "Ship Cell Pallets (ProcessPallet)", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RadioRegular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRegular.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioRegular.Checked = True Then

                Me.RadioShipAndHold.Checked = False
                Me.RadioRemoveFromHold.Checked = False
                If iHoldStatus = 2 Then
                    iHoldStatus = 0
                    LoadPallets(Me.cboCustomers.SelectedValue)
                End If
                iHoldStatus = 0
                Me.grdPallets.Caption = "Pallets to be Shipped :"
                Me.cmdRemoveFromHold.Visible = False
                If iFlg > 0 Then
                    Me.PanelList.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:RadioRegular_CheckedChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RadioShipAndHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioShipAndHold.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioShipAndHold.Checked = True Then

                Me.RadioRegular.Checked = False
                Me.RadioRemoveFromHold.Checked = False
                If iHoldStatus = 2 Then
                    iHoldStatus = 1
                    LoadPallets(Me.cboCustomers.SelectedValue)
                End If
                iHoldStatus = 1
                Me.grdPallets.Caption = "Pallets to be Shipped :"
                Me.cmdRemoveFromHold.Visible = False
                If iFlg > 0 Then
                    Me.PanelList.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:RadioShipAndHold_CheckedChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RadioRemoveFromHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRemoveFromHold.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioRemoveFromHold.Checked = True Then
                Me.RadioRegular.Checked = False
                Me.RadioShipAndHold.Checked = False
                iHoldStatus = 2
                LoadPallets(Me.cboCustomers.SelectedValue)
                Me.grdPallets.Caption = "Shipped Pallets on Hold :"
                Me.cmdRemoveFromHold.Visible = True
                Me.PanelList.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:RadioRemoveFromHold_CheckedChanged()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub grdPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        If Me.RadioRemoveFromHold.Checked = False Then
            iFlg = 1
        End If
    End Sub

    Private Sub cmdRemoveFromHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromHold.Click
        Dim i As Integer = 0
        Try
            If MessageBox.Show("Are you sure you want to remove this Pallet from 'Awaiting Parts' to 'In-transit'?", "Move to In-transit", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            i = objBulkShip.MovePalletsFromAWPtoIntransit(iPallett_ID)
            LoadPallets(Me.cboCustomers.SelectedValue)
            MessageBox.Show("Done.", "Remove Pallet from Hold", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Pallets:cmdRemoveFromHold_Click()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPalletLabel.Click
        Dim str_pallett As String = ""
        Dim dtPallettInfo As DataTable
        Dim R1 As DataRow

        Try
            str_pallett = InputBox("Enter Pallet Name.", "Reprint Pallet Label")
            If str_pallett = "" Then
                Throw New Exception("Please enter a Pallet Name if you want to reprint the pallet label.")
            End If

            Me.cmdReprintPalletLabel.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
            If dtPallettInfo.Rows.Count = 0 Then
                MessageBox.Show("Pallet Name was not defined in system.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPallettInfo.Rows.Count > 1 Then
                MessageBox.Show("Pallet Name existed twice in the system.", "Reprint Pallet Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                R1 = dtPallettInfo.Rows(0)
                If Not IsDBNull(R1("Cust_ID")) Then
                    objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Pallet Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            If Not IsNothing(dtPallettInfo) Then
                dtPallettInfo.Dispose()
                dtPallettInfo = Nothing
            End If
            Me.cmdReprintPalletLabel.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '***************************************************************************
    Private Sub cboProdIDs_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProdIDs.Enter
        Try
            iFileCheckDone = 0
            Me.cmdShip.Enabled = False
            Me.RadioRegular.Checked = True
            iHoldStatus = 0
            Me.cboCustomers.DataSource = Nothing
            Me.cboCustomers.Text = ""
            Me.pnlPalletList.Visible = False
            Me.grdPallets.DataSource = Nothing
            ClearControls()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboProdIDs_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************
    Private Sub cboProdIDs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProdIDs.KeyUp
        Dim dt As DataTable

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.cboProdIDs.SelectedValue > 0 Then
                    dt = Generic.GetCustomers(True, Me.cboProdIDs.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomers.SelectedValue = 0
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboProdIDs_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '***************************************************************************
    Private Sub cboCustomers_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Enter
        Try
            iFileCheckDone = 0
            Me.cmdShip.Enabled = False
            Me.RadioRegular.Checked = True
            iHoldStatus = 0
            Me.pnlPalletList.Visible = False
            Me.grdPallets.DataSource = Nothing
            ClearControls()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomers_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************
    Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.cboCustomers.SelectedValue > 0 Then LoadPallets(Me.cboCustomers.SelectedValue)
                Me.pnlPalletList.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************

End Class

