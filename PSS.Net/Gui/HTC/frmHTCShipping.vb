Option Explicit On 

Imports System.IO

Public Class frmHTCShipping
    Inherits System.Windows.Forms.Form

    Private objBulkShip As PSS.Data.Buisness.BulkShipping
    Private objMisc As PSS.Data.Buisness.Misc

    Private iLoc_ID As Integer = 0
    Private iShipType As Integer = 0
    Private strShipTypeDesc As String = ""
    Private strSKULength As String = ""
    Private iModel_ID As Integer = 0
    Private iFileCheckDone As Integer = 0
    Private strUser As String = PSS.Core.Global.ApplicationUser.User
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private iMachineGroup As Integer = PSS.Core.Global.ApplicationUser.GroupID
    Private iPallett_ID As Integer = 0
    Private strPalletName As String = ""
    Private strFilePath As String = ""
    Private strHTCFilePath As String = "P:\Dept\HTC\Pallet packing list\"

    Private iHoldStatus As Integer = 0
    Private iFlg As Integer = 0
    Private iGroup_ID As Integer = 0
    Private iCust_ID As Integer = 0

#Region " Windows Form Designer generated code "


    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objBulkShip = New PSS.Data.Buisness.BulkShipping()
        objMisc = New PSS.Data.Buisness.Misc()
        'radioButtons(0) = Me.RadioRegular
        'radioButtons(1) = Me.RadioShipAndHold
        'radioButtons(2) = Me.RadioRemoveFromHold

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents chkNoReprot As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents cmdRemoveFromHold As System.Windows.Forms.Button
    Friend WithEvents RadioRemoveFromHold As System.Windows.Forms.RadioButton
    Friend WithEvents RadioShipAndHold As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRegular As System.Windows.Forms.RadioButton
    Friend WithEvents lblGridCaption As System.Windows.Forms.Label
    Friend WithEvents PanelList As System.Windows.Forms.Panel
    Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCShipping))
        Me.lstRegular = New System.Windows.Forms.ListBox()
        Me.lstRUR = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.chkNoReprot = New System.Windows.Forms.CheckBox()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblGridCaption = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.cmdRemoveFromHold = New System.Windows.Forms.Button()
        Me.PanelList = New System.Windows.Forms.Panel()
        Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PanelList.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstRegular
        '
        Me.lstRegular.Location = New System.Drawing.Point(7, 40)
        Me.lstRegular.Name = "lstRegular"
        Me.lstRegular.Size = New System.Drawing.Size(120, 160)
        Me.lstRegular.TabIndex = 5
        '
        'lstRUR
        '
        Me.lstRUR.Location = New System.Drawing.Point(132, 40)
        Me.lstRUR.Name = "lstRUR"
        Me.lstRUR.Size = New System.Drawing.Size(117, 160)
        Me.lstRUR.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Regular Units:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(132, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "RUR Units:"
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
        Me.lbl.Text = "SHIP BOX"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(13, 213)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(98, 34)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Clear"
        '
        'cmdShip
        '
        Me.cmdShip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdShip.Enabled = False
        Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShip.ForeColor = System.Drawing.Color.Blue
        Me.cmdShip.Location = New System.Drawing.Point(505, 213)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(330, 34)
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
        Me.GroupBox1.Location = New System.Drawing.Point(392, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 89)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hold for Parts"
        Me.GroupBox1.Visible = False
        '
        'RadioRemoveFromHold
        '
        Me.RadioRemoveFromHold.BackColor = System.Drawing.Color.SteelBlue
        Me.RadioRemoveFromHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioRemoveFromHold.ForeColor = System.Drawing.Color.White
        Me.RadioRemoveFromHold.Location = New System.Drawing.Point(17, 62)
        Me.RadioRemoveFromHold.Name = "RadioRemoveFromHold"
        Me.RadioRemoveFromHold.Size = New System.Drawing.Size(247, 16)
        Me.RadioRemoveFromHold.TabIndex = 2
        Me.RadioRemoveFromHold.Text = "SHIP AND REMOVE FROM HOLD"
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
        Me.RadioRegular.Text = "REGULAR SHIP"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(376, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 18)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Wrong Model:"
        '
        'lstWrongModel
        '
        Me.lstWrongModel.Location = New System.Drawing.Point(376, 40)
        Me.lstWrongModel.Name = "lstWrongModel"
        Me.lstWrongModel.Size = New System.Drawing.Size(117, 160)
        Me.lstWrongModel.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(256, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(111, 29)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "RUR Units with Parts:"
        '
        'lstRURRTMParts
        '
        Me.lstRURRTMParts.Location = New System.Drawing.Point(256, 40)
        Me.lstRURRTMParts.Name = "lstRURRTMParts"
        Me.lstRURRTMParts.Size = New System.Drawing.Size(117, 160)
        Me.lstRURRTMParts.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(496, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 32)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Wrong RMA/Incomplete:"
        '
        'lstWrongSKULength
        '
        Me.lstWrongSKULength.Location = New System.Drawing.Point(496, 40)
        Me.lstWrongSKULength.Name = "lstWrongSKULength"
        Me.lstWrongSKULength.Size = New System.Drawing.Size(117, 160)
        Me.lstWrongSKULength.TabIndex = 8
        '
        'cmdFileCheck
        '
        Me.cmdFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFileCheck.ForeColor = System.Drawing.Color.Black
        Me.cmdFileCheck.Location = New System.Drawing.Point(117, 213)
        Me.cmdFileCheck.Name = "cmdFileCheck"
        Me.cmdFileCheck.Size = New System.Drawing.Size(379, 34)
        Me.cmdFileCheck.TabIndex = 0
        Me.cmdFileCheck.Text = "FILE CHECK (DO I HAVE THE RIGHT BOX?)"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gold
        Me.Label9.Location = New System.Drawing.Point(616, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 18)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "DETAIL:"
        '
        'lstDetail
        '
        Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lstDetail.Location = New System.Drawing.Point(616, 40)
        Me.lstDetail.Name = "lstDetail"
        Me.lstDetail.Size = New System.Drawing.Size(217, 160)
        Me.lstDetail.TabIndex = 9
        '
        'chkNoReprot
        '
        Me.chkNoReprot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoReprot.ForeColor = System.Drawing.Color.White
        Me.chkNoReprot.Location = New System.Drawing.Point(17, 22)
        Me.chkNoReprot.Name = "chkNoReprot"
        Me.chkNoReprot.Size = New System.Drawing.Size(232, 24)
        Me.chkNoReprot.TabIndex = 0
        Me.chkNoReprot.Text = "DON'T PRINT BOX REPORT"
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
        Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Location = New System.Drawing.Point(1, 80)
        Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.RowHeight = 20
        Me.grdPallets.Size = New System.Drawing.Size(383, 170)
        Me.grdPallets.TabIndex = 1
        Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:LightSteelBlue;Al" & _
        "ignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1" & _
        "2{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}H" & _
        "eading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
        "BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cent" & _
        "er;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></" & _
        "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelec" & _
        "t=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight" & _
        "=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellB" & _
        "order"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><Height>166</Height><CaptionStyle parent=""Style2"" me=""Styl" & _
        "e10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow""" & _
        " me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pa" & _
        "rent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingSt" & _
        "yle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""" & _
        "Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""Od" & _
        "dRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" />" & _
        "<SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1" & _
        """ /><ClientRect>0, 0, 379, 166</ClientRect><BorderSide>0</BorderSide><BorderStyl" & _
        "e>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Sty" & _
        "le parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""" & _
        "Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Hea" & _
        "ding"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norm" & _
        "al"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norm" & _
        "al"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" " & _
        "me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Cap" & _
        "tion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSp" & _
        "lits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea" & _
        ">0, 0, 379, 166</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Prin" & _
        "tPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lblGridCaption
        '
        Me.lblGridCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridCaption.ForeColor = System.Drawing.Color.White
        Me.lblGridCaption.Location = New System.Drawing.Point(0, 61)
        Me.lblGridCaption.Name = "lblGridCaption"
        Me.lblGridCaption.Size = New System.Drawing.Size(280, 16)
        Me.lblGridCaption.TabIndex = 63
        Me.lblGridCaption.Text = "Boxs to be Completed:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkNoReprot})
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(392, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(269, 80)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(520, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 16)
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
        Me.cmdRemoveFromHold.Location = New System.Drawing.Point(2, 254)
        Me.cmdRemoveFromHold.Name = "cmdRemoveFromHold"
        Me.cmdRemoveFromHold.Size = New System.Drawing.Size(383, 26)
        Me.cmdRemoveFromHold.TabIndex = 5
        Me.cmdRemoveFromHold.Text = "Remove from 'Parts Hold' and put it in 'In-transit'"
        Me.cmdRemoveFromHold.Visible = False
        '
        'PanelList
        '
        Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRUR, Me.lstRegular, Me.Label9, Me.lstWrongModel, Me.cmdShip, Me.lstDetail, Me.Label13, Me.Label1, Me.Label2, Me.Label12, Me.cmdClear, Me.lstRURRTMParts, Me.cmdFileCheck, Me.Label11, Me.lstWrongSKULength})
        Me.PanelList.Location = New System.Drawing.Point(2, 282)
        Me.PanelList.Name = "PanelList"
        Me.PanelList.Size = New System.Drawing.Size(846, 262)
        Me.PanelList.TabIndex = 4
        Me.PanelList.Visible = False
        '
        'cmdReprintPalletLabel
        '
        Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(392, 256)
        Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
        Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(272, 24)
        Me.cmdReprintPalletLabel.TabIndex = 68
        Me.cmdReprintPalletLabel.Text = "REPRINT BOX LABEL"
        '
        'frmHTCShipping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(856, 565)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdReprintPalletLabel, Me.PanelList, Me.cmdRemoveFromHold, Me.lblPallet, Me.Button1, Me.GroupBox2, Me.grdPallets, Me.lblGridCaption, Me.Label6, Me.lblCnt, Me.lbl, Me.GroupBox1})
        Me.Name = "frmHTCShipping"
        Me.Text = "Auto Ship Devices"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.PanelList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub ClearListControls()
        Me.lstRegular.Items.Clear()
        Me.lstRUR.Items.Clear()
        Me.lstRURRTMParts.Items.Clear()
        Me.lstWrongModel.Items.Clear()
        Me.lstWrongSKULength.Items.Clear()
        Me.lstDetail.Items.Clear()
        Me.lblCnt.Text = ""
        Me.lblPallet.Text = ""
    End Sub

    '******************************************************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        objBulkShip = Nothing
        MyBase.Finalize()
    End Sub

    '******************************************************************
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearControls()
    End Sub

    '******************************************************************
    Private Sub ClearControls()
        iPallett_ID = 0
        iGroup_ID = 0
        strPalletName = ""
        iLoc_ID = 0
        iModel_ID = 0
        iShipType = 0
        strSKULength = ""
        Me.strShipTypeDesc = ""
        iFlg = 0

        Me.objBulkShip.iLoc_ID = 0
        Me.objBulkShip.iShipType = 0
        Me.objBulkShip.strFilePath = ""
        Me.objBulkShip.iPallet_ID = 0
        Me.lblPallet.Text = ""
        Me.PanelList.Visible = False

        Me.lstRegular.Items.Clear()
        Me.lstDetail.Items.Clear()
        Me.lstRUR.Items.Clear()
        Me.lstRURRTMParts.Items.Clear()
        Me.lstWrongModel.Items.Clear()
        Me.lstWrongSKULength.Items.Clear()
        Me.chkNoReprot.Checked = False
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

    '******************************************************************
    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        Dim i As Integer = 0
        Dim objHTC As PSS.Data.Buisness.HTC

        Try
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
                Throw New Exception("Serial Number you have scanned in to do 'File Check' did not exist in the file.")
            End If
            '******************************************************
            'Bulk SHIP now.
            Me.Enabled = False
            Me.cmdShip.Enabled = True
            Cursor.Current = Cursors.WaitCursor
            i = objBulkShip.BulkShip(Me.chkNoReprot.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , 0)
            'print license plate
            objHTC = New PSS.Data.Buisness.HTC()
            objHTC.PrintLicensePlate(Me.strPalletName, Me.iModel_ID, Me.strShipTypeDesc, Me.lblCnt.Text)
            '******************************************************
            iFileCheckDone = 0
            Me.cmdShip.Enabled = False
            Me.RadioRegular.Checked = True
            iHoldStatus = 0
           
            ClearControls()
            LoadPallets()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Cell Boxs", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

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
        ElseIf iShipType = 1 Then   'RUR
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with RUR devices. Not allowed.")
            End If
        Else
            Throw New Exception("'Ship Type' not determined.")
        End If

        '***************************
        'Discrepancies
        If Me.lstRURRTMParts.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are RUR devices that still have parts billed. Shipping not allowed.")
        End If
        If Me.lstWrongModel.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are devices of wrong model in the file. Shipping not allowed.")
        End If
        If Me.lstWrongSKULength.Items.Count > 0 Then
            Me.BackColor = System.Drawing.Color.Red
            System.Windows.Forms.Application.DoEvents()
            Throw New Exception("There are devices of wrong SKU length in the file. Shipping not allowed.")
        End If
        '***************************
        Me.PanelList.Visible = True
    End Sub

    '******************************************************************
    Private Sub frmHTCShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.objBulkShip.iShiftID = iShiftID
            Me.objBulkShip.struser = strUser
            iHoldStatus = 0
            Me.RadioRegular.Select()
            LoadPallets()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadPallets()
        Dim dtPallets As DataTable

        Try
            ClearControls()
            dtPallets = Me.objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineGroup, PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID)
            Me.grdPallets.ClearFields()
            Me.grdPallets.DataSource = dtPallets.DefaultView
            SetPalletGridProperties()
            ResetTransfers()
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtPallets) Then
                dtPallets.Dispose()
                dtPallets = Nothing
            End If
        End Try
    End Sub

    '******************************************************************
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

    '******************************************************************
    Private Sub ResetTransfers()
        ' Check for cellular devices whose WIP ownership was transferred and transfer them back to the original owner.
        Me.objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineGroup, PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID)
    End Sub

    '******************************************************************
    Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
        Dim strIMEI As String = ""
        Dim R1 As DataRow
        Dim iMatch As Integer = 0

        Try
            If Not IsNothing(objBulkShip.dtExcelSNs) Then

                Select Case iCust_ID
                    Case PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID      'HTC
                        strIMEI = InputBox("Please scan in a 'Serial Number' to make sure you have selected the right file.")
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
                            MessageBox.Show("Serial Number exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If

                    Case Else
                        Throw New Exception("Cust_ID is missing.")
                End Select
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '******************************************************************
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
            MsgBox("lstRURRTMParts_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '******************************************************************
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
            MsgBox("lstWrongModel_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '******************************************************************
    Private Sub lstWrongSKULength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWrongSKULength.SelectedIndexChanged
        Dim R1 As DataRow

        Try
            Me.lstDetail.Items.Clear()
            For Each R1 In objBulkShip.dtExcelSNs.Rows
                If Trim(R1("SN")) = Trim(Me.lstWrongSKULength.Items(Me.lstWrongSKULength.SelectedIndex)) Then
                    Me.lstDetail.Items.Add(Trim(R1("SKU_Number")))
                    Exit For
                End If
            Next R1
        Catch ex As Exception
            MsgBox("lstWrongSKULength_SelectedIndexChanged: " & ex.Message.ToString)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '******************************************************************
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

    '******************************************************************
    Private Sub ProcessPallet()
        Dim iExcelNum As Integer = 0
        Dim iPSSNum As Integer = 0
        Dim R1 As DataRow
        Dim i As Integer = 0
        Dim strFileLocation As String = ""

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
            strShipTypeDesc = Me.grdPallets.Columns("Ship Type").Value
            iCust_ID = Me.grdPallets.Columns("Cust_ID").Value
            Select Case iCust_ID
                Case PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID      'HTC
                    strFilePath = strHTCFilePath
                Case Else
                    Throw New Exception("Box manifest file path missing (Cust_ID in tpallett needs to be updated).")
            End Select
            '************************************************
            'Check if the excel file exists
            '************************************************
            strFileLocation = strFilePath & strPalletName & ".xls"
            If Not File.Exists(strFileLocation) Then
                Throw New Exception("Box Excel File was not found in '" & strFilePath & "'")
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
            'Step 1 :: Extract SN numbers from the excel file
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
                iPSSNum = objBulkShip.GetSKU("SN")
                If iExcelNum <> iPSSNum Then
                    Throw New Exception("cmdSelectFile_Click.GetSKU:: Records from excel file don't have same number of records from PSS Database.")
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

                    '*******************************************************
                    '(A) Model Validation (For all customers)
                    '*******************************************************
                    If R1("Model_ID") <> iModel_ID Then
                        Select Case iCust_ID
                            Case PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID     'ATCLE , HTC
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case Else
                                Throw New Exception("Box manifest file path missing (Cust_ID in Box needs to be updated).")
                        End Select
                    End If

                    '*******************************************************
                    '(C) BILLCODERULE validation    (For all customers)
                    '*******************************************************
                    Select Case iCust_ID
                        Case PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID      'HTC
                            '*******************************************************
                            If R1("Billcode_rule") = 1 Then 'RUR
                                Me.lstRUR.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                        Case Else
                            Throw New Exception("Box manifest file path missing (Cust_ID in tpallett needs to be updated).")
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
            MessageBox.Show(ex.Message, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub RadioRegular_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRegular.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioRegular.Checked = True Then

                Me.RadioShipAndHold.Checked = False
                Me.RadioRemoveFromHold.Checked = False
                If iHoldStatus = 2 Then
                    iHoldStatus = 0
                    LoadPallets()
                End If
                iHoldStatus = 0
                Me.lblGridCaption.Text = "Box to be Shipped:"
                Me.cmdRemoveFromHold.Visible = False
                If iFlg > 0 Then
                    Me.PanelList.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub RadioShipAndHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioShipAndHold.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioShipAndHold.Checked = True Then

                Me.RadioRegular.Checked = False
                Me.RadioRemoveFromHold.Checked = False
                If iHoldStatus = 2 Then
                    iHoldStatus = 1
                    LoadPallets()
                End If
                iHoldStatus = 1
                Me.lblGridCaption.Text = "Box to be Ship:"
                Me.cmdRemoveFromHold.Visible = False
                If iFlg > 0 Then
                    Me.PanelList.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub RadioRemoveFromHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioRemoveFromHold.CheckedChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If Me.RadioRemoveFromHold.Checked = True Then
                Me.RadioRegular.Checked = False
                Me.RadioShipAndHold.Checked = False
                iHoldStatus = 2
                LoadPallets()
                Me.lblGridCaption.Text = "Ship Box on Hold:"
                Me.cmdRemoveFromHold.Visible = True
                Me.PanelList.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub grdPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        If Me.RadioRemoveFromHold.Checked = False Then
            iFlg = 1
        End If
    End Sub

    '******************************************************************
    Private Sub cmdRemoveFromHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromHold.Click
        Dim i As Integer = 0
        Try
            If MessageBox.Show("Are you sure you want to remove this Box from 'Awaiting Parts' to 'In-transit'?", "Move to In-transit", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            i = objBulkShip.MovePalletsFromAWPtoIntransit(iPallett_ID)
            LoadPallets()
            MessageBox.Show("Done.", "Remove Box from Hold", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub cmdReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPalletLabel.Click
        Dim str_pallett As String = ""
        Dim dtPallettInfo As DataTable
        Dim R1 As DataRow

        Try
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
            If str_pallett = "" Then
                Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            End If

            Me.cmdReprintPalletLabel.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)
            If dtPallettInfo.Rows.Count = 0 Then
                MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPallettInfo.Rows.Count > 1 Then
                MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                R1 = dtPallettInfo.Rows(0)
                If Not IsDBNull(R1("Cust_ID")) Then
                    objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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

    '******************************************************************

End Class
