Option Explicit On 

Imports PSS.Data.Buisness
Imports System.IO

Public Class frmMessProdShip
    Inherits System.Windows.Forms.Form

    Private _objSkyTel As SkyTel
    Private _objBulkShip As BulkShipping
    Private _objMisc As PSS.Data.Buisness.Misc

    Private strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate
    Private strUser As String = PSS.Core.[Global].ApplicationUser.User
    Private iShiftID As Integer = PSS.Core.[Global].ApplicationUser.IDShift
    Private iMachineCCGroup As Integer = 0
    Private iPallett_ID As Integer = 0
    Private strPalletName As String = ""
    Private iShipType As Integer = 0
    Private strShipTypeDesc As String = ""
    Private strSKULength As String = ""
    Private iModel_ID As Integer = 0
    Private iFileCheckDone As Integer = 0
    Private iHoldStatus As Integer = 0
    Private iGroup_ID As Integer = 0
    Private iCustID As Integer = 0
    Private iLocID As Integer = 0
    Private iFlg As Integer = 0

    Private _iMenuCustID As Integer = 0
    Private _strTabPageTitle As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String, ByVal iMenuCustID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSkyTel = New SkyTel()
        _objBulkShip = New BulkShipping()
        _objMisc = New PSS.Data.Buisness.Misc()

        _strTabPageTitle = strTabPageTitle
        _iMenuCustID = iMenuCustID
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objSkyTel = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PanelList As System.Windows.Forms.Panel
    Friend WithEvents lstRUR As System.Windows.Forms.ListBox
    Friend WithEvents lstRegular As System.Windows.Forms.ListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
    Friend WithEvents cmdShip As System.Windows.Forms.Button
    Friend WithEvents lstDetail As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lstRURRTMParts As System.Windows.Forms.ListBox
    Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNoReprot As System.Windows.Forms.CheckBox
    Friend WithEvents lblGridCaption As System.Windows.Forms.Label
    Friend WithEvents lblPallet As System.Windows.Forms.Label
    Friend WithEvents lblCnt As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
    Friend WithEvents lstWrongSKULength As System.Windows.Forms.ListBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnPrintManifestRpt As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessProdShip))
        Me.PanelList = New System.Windows.Forms.Panel()
        Me.lstRURRTMParts = New System.Windows.Forms.ListBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lstRUR = New System.Windows.Forms.ListBox()
        Me.lstRegular = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lstWrongModel = New System.Windows.Forms.ListBox()
        Me.cmdShip = New System.Windows.Forms.Button()
        Me.lstDetail = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdFileCheck = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lstWrongSKULength = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkNoReprot = New System.Windows.Forms.CheckBox()
        Me.lblGridCaption = New System.Windows.Forms.Label()
        Me.lblPallet = New System.Windows.Forms.Label()
        Me.lblCnt = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
        Me.btnPrintManifestRpt = New System.Windows.Forms.Button()
        Me.PanelList.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelList
        '
        Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRURRTMParts, Me.Label12, Me.lstRUR, Me.lstRegular, Me.Label9, Me.lstWrongModel, Me.cmdShip, Me.lstDetail, Me.Label13, Me.Label1, Me.Label2, Me.cmdClear, Me.cmdFileCheck, Me.Label11, Me.lstWrongSKULength})
        Me.PanelList.Location = New System.Drawing.Point(0, 280)
        Me.PanelList.Name = "PanelList"
        Me.PanelList.Size = New System.Drawing.Size(964, 288)
        Me.PanelList.TabIndex = 72
        Me.PanelList.Visible = False
        '
        'lstRURRTMParts
        '
        Me.lstRURRTMParts.Location = New System.Drawing.Point(288, 24)
        Me.lstRURRTMParts.Name = "lstRURRTMParts"
        Me.lstRURRTMParts.Size = New System.Drawing.Size(132, 199)
        Me.lstRURRTMParts.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(280, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 24)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "RUR/NER Units w/ Parts:"
        '
        'lstRUR
        '
        Me.lstRUR.Location = New System.Drawing.Point(152, 24)
        Me.lstRUR.Name = "lstRUR"
        Me.lstRUR.Size = New System.Drawing.Size(132, 199)
        Me.lstRUR.TabIndex = 4
        '
        'lstRegular
        '
        Me.lstRegular.Location = New System.Drawing.Point(16, 24)
        Me.lstRegular.Name = "lstRegular"
        Me.lstRegular.Size = New System.Drawing.Size(133, 199)
        Me.lstRegular.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gold
        Me.Label9.Location = New System.Drawing.Point(704, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 20)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "DETAIL:"
        '
        'lstWrongModel
        '
        Me.lstWrongModel.Location = New System.Drawing.Point(432, 24)
        Me.lstWrongModel.Name = "lstWrongModel"
        Me.lstWrongModel.Size = New System.Drawing.Size(132, 199)
        Me.lstWrongModel.TabIndex = 7
        '
        'cmdShip
        '
        Me.cmdShip.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdShip.Enabled = False
        Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShip.ForeColor = System.Drawing.Color.Blue
        Me.cmdShip.Location = New System.Drawing.Point(600, 232)
        Me.cmdShip.Name = "cmdShip"
        Me.cmdShip.Size = New System.Drawing.Size(344, 40)
        Me.cmdShip.TabIndex = 1
        Me.cmdShip.Text = "SHIP"
        '
        'lstDetail
        '
        Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.lstDetail.Location = New System.Drawing.Point(704, 24)
        Me.lstDetail.Name = "lstDetail"
        Me.lstDetail.Size = New System.Drawing.Size(254, 199)
        Me.lstDetail.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(568, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 27)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Wrong Frequency:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Regular Units:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(152, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "DBR/NER Units:"
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.ForeColor = System.Drawing.Color.Black
        Me.cmdClear.Location = New System.Drawing.Point(24, 232)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(112, 40)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.Text = "Clear"
        '
        'cmdFileCheck
        '
        Me.cmdFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFileCheck.ForeColor = System.Drawing.Color.Black
        Me.cmdFileCheck.Location = New System.Drawing.Point(152, 232)
        Me.cmdFileCheck.Name = "cmdFileCheck"
        Me.cmdFileCheck.Size = New System.Drawing.Size(443, 40)
        Me.cmdFileCheck.TabIndex = 0
        Me.cmdFileCheck.Text = "FILE CHECK (DO I HAVE THE RIGHT BOX?)"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(432, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 21)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Wrong Model:"
        '
        'lstWrongSKULength
        '
        Me.lstWrongSKULength.Location = New System.Drawing.Point(568, 24)
        Me.lstWrongSKULength.Name = "lstWrongSKULength"
        Me.lstWrongSKULength.Size = New System.Drawing.Size(132, 199)
        Me.lstWrongSKULength.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkNoReprot})
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(458, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(309, 63)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'chkNoReprot
        '
        Me.chkNoReprot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNoReprot.ForeColor = System.Drawing.Color.White
        Me.chkNoReprot.Location = New System.Drawing.Point(20, 26)
        Me.chkNoReprot.Name = "chkNoReprot"
        Me.chkNoReprot.Size = New System.Drawing.Size(271, 28)
        Me.chkNoReprot.TabIndex = 0
        Me.chkNoReprot.Text = "DON'T PRINT BOX REPORT"
        '
        'lblGridCaption
        '
        Me.lblGridCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridCaption.ForeColor = System.Drawing.Color.White
        Me.lblGridCaption.Location = New System.Drawing.Point(-9, 65)
        Me.lblGridCaption.Name = "lblGridCaption"
        Me.lblGridCaption.Size = New System.Drawing.Size(327, 19)
        Me.lblGridCaption.TabIndex = 77
        Me.lblGridCaption.Text = "Boxs to be Completed:"
        '
        'lblPallet
        '
        Me.lblPallet.BackColor = System.Drawing.Color.Black
        Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPallet.ForeColor = System.Drawing.Color.Lime
        Me.lblPallet.Location = New System.Drawing.Point(374, 0)
        Me.lblPallet.Name = "lblPallet"
        Me.lblPallet.Size = New System.Drawing.Size(390, 65)
        Me.lblPallet.TabIndex = 79
        Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCnt
        '
        Me.lblCnt.BackColor = System.Drawing.Color.Black
        Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblCnt.Location = New System.Drawing.Point(767, 0)
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(92, 65)
        Me.lblCnt.TabIndex = 75
        Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(383, 65)
        Me.lbl.TabIndex = 74
        Me.lbl.Text = "SHIP BOX"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.grdPallets.CaptionHeight = 19
        Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Location = New System.Drawing.Point(0, 84)
        Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.RowHeight = 20
        Me.grdPallets.Size = New System.Drawing.Size(448, 180)
        Me.grdPallets.TabIndex = 69
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
        "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""Fals" & _
        "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
        "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeSt" & _
        "yle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScro" & _
        "llGroup=""1"" HorizontalScrollGroup=""1""><Height>176</Height><CaptionStyle parent=""" & _
        "Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle " & _
        "parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /" & _
        "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
        "12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
        "ghlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
        "Style parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector""" & _
        " me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""No" & _
        "rmal"" me=""Style1"" /><ClientRect>0, 0, 444, 176</ClientRect><BorderSide>0</Border" & _
        "Side><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><" & _
        "NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /" & _
        "><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><S" & _
        "tyle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><St" & _
        "yle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><St" & _
        "yle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style p" & _
        "arent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><S" & _
        "tyle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horz" & _
        "Splits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth><ClientArea>0, 0, 444, 176</ClientArea><PrintPageHeaderStyle parent="""" me=""" & _
        "Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(776, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 19)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "COUNT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdReprintPalletLabel
        '
        Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
        Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(459, 150)
        Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
        Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(308, 28)
        Me.cmdReprintPalletLabel.TabIndex = 80
        Me.cmdReprintPalletLabel.Text = "REPRINT BOX LABEL"
        '
        'btnPrintManifestRpt
        '
        Me.btnPrintManifestRpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnPrintManifestRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintManifestRpt.ForeColor = System.Drawing.Color.Black
        Me.btnPrintManifestRpt.Location = New System.Drawing.Point(458, 196)
        Me.btnPrintManifestRpt.Name = "btnPrintManifestRpt"
        Me.btnPrintManifestRpt.Size = New System.Drawing.Size(309, 28)
        Me.btnPrintManifestRpt.TabIndex = 81
        Me.btnPrintManifestRpt.Text = "RePrint Excel Manifest Report"
        '
        'frmMessProdShip
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(968, 574)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrintManifestRpt, Me.GroupBox2, Me.lblGridCaption, Me.lblPallet, Me.lblCnt, Me.lbl, Me.grdPallets, Me.Label6, Me.cmdReprintPalletLabel, Me.PanelList})
        Me.Name = "frmMessProdShip"
        Me.Text = "frmMessProdShip"
        Me.PanelList.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*****************************************************************
    Protected Overrides Sub Finalize()
        _objMisc = Nothing
        _objBulkShip = Nothing
        MyBase.Finalize()
    End Sub

    '*****************************************************************
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearControls()
    End Sub

    '*****************************************************************
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

    '*****************************************************************
    Private Sub ClearControls()
        iPallett_ID = 0
        strPalletName = ""
        iShipType = 0
        Me.strShipTypeDesc = ""
        strSKULength = ""
        iModel_ID = 0
        iFileCheckDone = 0
        iHoldStatus = 0
        iGroup_ID = 0
        iCustID = 0
        iLocID = 0
        iFlg = 0

        Me.PanelList.Visible = False
        Me.chkNoReprot.Checked = False

        Me.BackColor = System.Drawing.Color.SteelBlue
        System.Windows.Forms.Application.DoEvents()

        '*********************
        'objBulkShip Variables
        Me._objBulkShip.iLoc_ID = 0
        Me._objBulkShip.strWorkDt = ""
        Me._objBulkShip.iBulkShipped = 0
        Me._objBulkShip.iShipType = 0
        Me._objBulkShip.strFilePath = ""
        Me._objBulkShip.iPallet_ID = 0

        If Not IsNothing(_objBulkShip.dtExcelSNs) Then
            _objBulkShip.dtExcelSNs.Dispose()
            _objBulkShip.dtExcelSNs = Nothing
        End If
        If Not IsNothing(_objBulkShip.dtWO) Then
            _objBulkShip.dtWO.Dispose()
            _objBulkShip.dtWO = Nothing
        End If
        '*********************
    End Sub

    '*****************************************************************
    Private Sub frmMessProdShip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strWD As String = ""
        Dim isComputerNameMapped As Boolean = False
        Dim tmpStr As String = ""

        Try
            '**********************************************************************************************************************************************
            'Set ScreenName
            '**********************************************************************************************************************************************
            Me.lbl.Text = Me._strTabPageTitle
            If Me._iMenuCustID = _objSkyTel.MorrisCom_CUSTOMER_ID Then Me.lbl.Font = New Font("Microsoft Sans Serif", 15, FontStyle.Bold)

            'validate work date
            If Trim(strWorkDate) = "" Then
                Throw New Exception("'Work Date' could not be determined. 'PSS User' may not have correct shift assigned.")
            End If

            strWD = PSS.Data.Buisness.Generic.GetWorkDate(PSS.Core.[Global].ApplicationUser.IDShift)
            If strWorkDate <> strWD Then
                MsgBox("Unable to determine work date.", MsgBoxStyle.Critical, "Information")
                End
            End If

            'validate group mapping
            Me.iMachineCCGroup = Generic.GetMachineCostCenterGrpID()
            ' Me.iMachineCCGroup = 1  '---------------------------
            If Me.iMachineCCGroup = 0 Then
                Throw New Exception("Machine is not mapped to any group.")
            End If
            Select Case Me._iMenuCustID
                Case Me._objSkyTel.SKYTEL_CUSTOMER_ID
                    tmpStr = "SkyTel"
                    If Me.iMachineCCGroup = Me._objSkyTel.SKYTEL_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Me._objSkyTel.MorrisCom_CUSTOMER_ID
                    tmpStr = "Morris Communcation"
                    If Me.iMachineCCGroup = Me._objSkyTel.MorrisCom_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Me._objSkyTel.Propage_CUSTOMER_ID
                    tmpStr = "Propage"
                    If Me.iMachineCCGroup = Me._objSkyTel.Propage_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Me._objSkyTel.Aquis_CUSTOMER_ID
                    tmpStr = "Aquis"
                    If Me.iMachineCCGroup = Me._objSkyTel.Aquis_GROUPID Then
                        isComputerNameMapped = True
                    End If
                Case Else
                    tmpStr = ""
                    Me.lbl.Text = "Ship Box"
                    isComputerNameMapped = True
            End Select
            '  isComputerNameMapped = True '-----------------------------
            If Not isComputerNameMapped Then 'no mapping
                MessageBox.Show("Machine is not mapped to " & tmpStr & " group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                If PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                    PSS.Gui.MainWin.MainWin.wrkArea.TabPages.RemoveAt(PSS.Gui.MainWin.MainWin.wrkArea.SelectedIndex)
                Else
                    PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                End If
            Else 'yes mapping
                Me._objBulkShip.strWorkDt = strWorkDate
                Me._objBulkShip.iShiftID = iShiftID
                Me._objBulkShip.struser = strUser

                LoadPallets()
            End If


            'Me._objBulkShip.strWorkDt = strWorkDate
            'Me._objBulkShip.iShiftID = iShiftID
            'Me._objBulkShip.struser = strUser

            'LoadPallets()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadPallets()
        Dim dtPallets As DataTable

        Try
            ClearControls()
            dtPallets = Me._objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineCCGroup)
            Me.grdPallets.ClearFields()
            Me.grdPallets.DataSource = dtPallets.DefaultView
            SetPalletGridProperties()
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
    Private Sub grdPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        iFlg = 1
    End Sub

    '******************************************************************
    Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
        If iFlg = 0 Then
            Exit Sub
        End If
        If Me.grdPallets.Columns.Count = 0 OrElse Me.grdPallets.RowCount = 0 Then
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
        Dim strFilePath As String = ""

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            ClearListControls()
            Me.PanelList.Visible = True
            '************************************************
            'Retrieve Grid info
            '************************************************
            iPallett_ID = Me.grdPallets.Columns("pallett_id").Value
            strPalletName = Trim(Me.grdPallets.Columns("Pallet").Value.ToString)
            iLocID = Me.grdPallets.Columns("Loc_ID").Value
            iModel_ID = Me.grdPallets.Columns("Model_ID").Value
            iShipType = Me.grdPallets.Columns("Pallet_ShipType").Value
            strSKULength = Trim(Me.grdPallets.Columns("SKU Length").Value.ToString)
            iGroup_ID = Me.grdPallets.Columns("group_id").Value
            strShipTypeDesc = Me.grdPallets.Columns("Ship Type").Value
            iCustID = Me.grdPallets.Columns("Cust_ID").Value
            Select Case iCustID
                Case PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID
                    strFilePath = SkyTel.SKYTEL_MANIFEST_DIR
                Case PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID
                    strFilePath = SkyTel.MorrisCom_MANIFEST_DIR
                Case PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID
                    strFilePath = SkyTel.Propage_MANIFEST_DIR
                Case PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID
                    strFilePath = SkyTel.Aquis_MANIFEST_DIR
                Case Else
                    Throw New Exception("Box manifest file path missing (Cust_ID in tpallett needs to be updated).")
            End Select
            '************************************************
            'Check if the excel file exists
            '************************************************
            strFilePath = strFilePath & strPalletName & ".xls"
            If Not File.Exists(strFilePath) Then
                Throw New Exception("Excel manifest was not found in '" & strFilePath & "'")
            End If
            '************************************************
            Me.lblPallet.Text = strPalletName
            '*********************
            'objBulkShip variables
            Me._objBulkShip.iLoc_ID = iLocID
            Me._objBulkShip.iBulkShipped = 1
            Me._objBulkShip.iShipType = iShipType
            Me._objBulkShip.strFilePath = strFilePath
            Me._objBulkShip.iPallet_ID = iPallett_ID
            Me._objBulkShip.iGroup_ID = iGroup_ID
            Me._objBulkShip.strWorkDt = strWorkDate
            Me._objBulkShip.iShiftID = iShiftID
            Me._objBulkShip.struser = strUser
            Me._objBulkShip.iCust_ID = iCustID
            '*********************
            iFileCheckDone = 0
            '************************************************
            'Step 1 :: Extract SN numbers from the excel file
            '************************************************
            iExcelNum = _objBulkShip.ExtractSNs()
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
                iPSSNum = _objBulkShip.GetModel()
                If iExcelNum <> iPSSNum Then
                    Throw New Exception("cmdSelectFile_Click.GetModel:: Records from excel file don't have same number of records from PSS Database.")
                End If
                '***********************************************************
                '(B) :: Get the SKU Length
                '***********************************************************
                Select Case Me.iCustID
                    Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID
                        If iShipType = 0 Then Me._objSkyTel.GetFreq(_objBulkShip.dtExcelSNs, Me.strSKULength, "SN", Me._objBulkShip.iLoc_ID)
                    Case Else
                        iPSSNum = _objBulkShip.GetSKU("SN")
                        If iExcelNum <> iPSSNum Then
                            Throw New Exception("cmdSelectFile_Click.GetSKU:: Records from excel file don't have same number of records from PSS Database.")
                        End If
                End Select

                '***********************************************************
                '(C) :: Get Billcoderule
                '***********************************************************
                iPSSNum = _objBulkShip.GetBillcodeRule()
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
                For Each R1 In _objBulkShip.dtExcelSNs.Rows

                    '*******************************************************
                    '(A) Model Validation (For all customers)
                    '*******************************************************
                    If R1("Model_ID") <> iModel_ID Then
                        Select Case iCustID
                            Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID   'ATCLE , HTC
                                Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            Case Else
                                Throw New Exception("Box manifest file path missing (Cust_ID in Box needs to be updated).")
                        End Select
                    End If

                    '*******************************************************
                    '(C) BILLCODERULE validation    (For all customers)
                    '*******************************************************
                    Select Case iCustID
                        Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID       'HTC
                            '*******************************************************
                            If R1("Billcode_rule") = 1 Or R1("Billcode_rule") = 2 Then 'RUR/DBR
                                Me.lstRUR.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Or R1("Billcode_rule") = 4 Or R1("Billcode_rule") = 7 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstRURRTMParts.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'Wrong Frequency
                            '*******************************************************
                            If R1("SKU_Number").ToString.Trim.Length > 0 Then
                                Me.lstWrongSKULength.Items.Add(Trim(R1("SN")))
                                Me.lstDetail.Items.Add(Trim(R1("SKU_Number")))
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub lstRURRTMParts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRURRTMParts.SelectedIndexChanged
        Dim dt1 As New DataTable()
        Dim R1 As DataRow

        Try
            dt1 = _objMisc.GetPartsForDevice(Trim(Me.lstRURRTMParts.Items(Me.lstRURRTMParts.SelectedIndex)))

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
            dt1 = _objMisc.GetDeviceInfo(Trim(Me.lstWrongModel.Items(Me.lstWrongModel.SelectedIndex)))
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
        Try
            Me.lstDetail.Items.Clear()
            If _objBulkShip.dtExcelSNs.Select("SN = '" & Trim(Me.lstWrongSKULength.Items(Me.lstWrongSKULength.SelectedIndex)) & "'").Length > 0 Then
                Me.lstDetail.Items.Add(_objBulkShip.dtExcelSNs.Select("SN = '" & Trim(Me.lstWrongSKULength.Items(Me.lstWrongSKULength.SelectedIndex)) & "'")(0)("SKU_Number"))
            End If
        Catch ex As Exception
            MsgBox("lstWrongSKULength_SelectedIndexChanged: " & ex.Message.ToString)
        End Try
    End Sub

    '******************************************************************
    Private Sub DoValidation()
        '***************************
        If Len(Trim(strWorkDate)) = 0 Then
            Throw New Exception("'Work Date' could not be determined. Shipping user may not have a 'Shift' assigned.")
        End If
        '***************************
        If IsNothing(_objBulkShip.dtExcelSNs) Then
            Throw New Exception("Select an Excel file to ship.")
        End If
        If _objBulkShip.dtExcelSNs.Rows.Count = 0 Then
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
                Throw New Exception("You are trying to ship DBR/NER devices with REGULAR devices. Not allowed.")
            End If
        ElseIf iShipType = 1 OrElse iShipType = 2 Then   'BER-NER
            If Me.lstRegular.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("You are trying to ship REGULAR devices with DBR/NER devices. Not allowed.")
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
            Throw New Exception("There are devices of wrong frequency in the file. Shipping not allowed.")
        End If
        '***************************
    End Sub

    '******************************************************************
    Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
        Dim strSN As String = ""
        Dim R1 As DataRow
        Dim iMatch As Integer = 0

        Try
            If Not IsNothing(_objBulkShip.dtExcelSNs) Then

                Select Case iCustID
                    Case PSS.Data.Buisness.SkyTel.SKYTEL_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID, _
                         PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID, PSS.Data.Buisness.SkyTel.Aquis_CUSTOMER_ID
                        strSN = InputBox("Please scan in a 'Serial Number' to make sure you have selected the right file.").Trim.ToUpper
                        If strSN <> "" Then
                            For Each R1 In _objBulkShip.dtExcelSNs.Rows
                                If strSN = Trim(R1("SN")).ToUpper Then
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
    Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
        Dim i As Integer = 0
        Dim strWD As String = ""
        Dim iPrintCopies As Integer = 2

        Try
            strWD = PSS.Data.Buisness.Generic.GetWorkDate(PSS.Core.[Global].ApplicationUser.IDShift)
            If strWorkDate <> strWD Then
                MsgBox("Unable to determine work date.", MsgBoxStyle.Critical, "Information")
                End
            End If

            '*****************************************************
            DoValidation()
            '*****************************************************
            'Make sure a file has been selected and FILE CHECK done
            Me.cmdShip.Enabled = False
            If iFileCheckDone = 0 Then
                Throw New Exception("File check has not been done.")
            ElseIf iFileCheckDone = 1 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("Serial Number you have scanned in to do 'File Check' did not exist in the file.")
            End If

            '******************************************************
            'Bulk SHIP now.
            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor
            i = _objBulkShip.BulkShip(Me.chkNoReprot.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , 0)

            ''print license plate
            'Generic.PrintPalletLicensePlate(Me.strPalletName, Me.iModel_ID, Me.strShipTypeDesc, Me.lblCnt.Text, iPrintCopies)
            ''******************************************************

            ClearControls()
            LoadPallets()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Ship Boxs", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub cmdReprintPalletLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintPalletLabel.Click
        Dim str_pallett As String = ""
        Dim dtPallettInfo As DataTable
        Dim strPalletType As String = ""
        Dim iPalletQty As Integer = 0
        Dim R1 As DataRow

        Try
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
            If str_pallett = "" Then
                Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            dtPallettInfo = _objMisc.GetPalletInfo_ByPallettName(str_pallett)
            If dtPallettInfo.Rows.Count = 0 Then
                MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf dtPallettInfo.Rows.Count > 1 Then
                MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                R1 = dtPallettInfo.Rows(0)

                If R1("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If R1("Pallet_ShipType") = 0 Then
                    strPalletType = "REFURBISHED"
                ElseIf R1("Pallet_ShipType") = 1 Then
                    strPalletType = "DBR"
                ElseIf R1("Pallet_ShipType") = 2 Then
                    strPalletType = "NER"
                Else
                    MessageBox.Show("System can't define Box Type.", "Information", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                If Not IsDBNull(R1("Cust_ID")) Then
                    '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                    PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1)
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
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************
    Private Sub btnPrintManifestRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintManifestRpt.Click
        Dim str_pallett As String = ""
        Dim filePath As String = ""

        Try
            str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")

            Select Case Me._iMenuCustID
                Case SkyTel.SKYTEL_CUSTOMER_ID
                    filePath = SkyTel.SKYTEL_MANIFEST_DIR
                Case SkyTel.MorrisCom_CUSTOMER_ID
                    filePath = SkyTel.MorrisCom_MANIFEST_DIR
                Case SkyTel.Propage_CUSTOMER_ID
                    filePath = SkyTel.Propage_MANIFEST_DIR
            End Select

            If str_pallett = "" Then
                Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            ElseIf filePath = "" Then
                Throw New Exception("Missing the report file path!")
            ElseIf File.Exists(filePath & str_pallett & ".xls") = False Then
                Throw New Exception("Report does not exist '" & filePath & str_pallett & ".xls" & "'.")
            End If

            'str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
            'If str_pallett = "" Then
            '    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            'ElseIf File.Exists(SkyTel.SKYTEL_MANIFEST_DIR & str_pallett & ".xls") = False Then
            '    Throw New Exception("Report does not exist '" & SkyTel.SKYTEL_MANIFEST_DIR & str_pallett & ".xls" & "'.")
            'End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor
            Me._objBulkShip.PrintExcelFile(filePath & str_pallett & ".xls")
            ' Me._objBulkShip.PrintExcelFile(SkyTel.SKYTEL_MANIFEST_DIR & str_pallett & ".xls")

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Box Manifest.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*****************************************************************


End Class
