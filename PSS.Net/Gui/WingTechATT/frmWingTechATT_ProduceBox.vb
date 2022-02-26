Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text
Imports C1.Win.C1TrueDBGrid

Namespace Gui.WingTechATT

    Public Class frmWingTechATT_ProduceBox
        Inherits System.Windows.Forms.Form
        Private _objBulkShip As BulkShipping
        Private _objWingTechATT_SP As New PSS.Data.Buisness.WingTechATT.WingTechATT_SpecialProject()
        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = ""
        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _objWingTechATT As PSS.Data.Buisness.WingTechATT.WingTechATT
        Private _objWingTechATT_ProduceBox As PSS.Data.Buisness.WingTechATT.WingTechATT_ProduceBox
        Private iPallett_ID As Integer = 0
        Private PallettQty As Integer = 0
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


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCust_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCust_ID
            Me._strScreenName = strScreenName

            Me._objWingTechATT = New PSS.Data.Buisness.WingTechATT.WingTechATT()
            Me._objWingTechATT_ProduceBox = New PSS.Data.Buisness.WingTechATT.WingTechATT_ProduceBox()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWingTechATT = Nothing
                    Me._objWingTechATT_ProduceBox = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents btnClearList As System.Windows.Forms.Button
        Friend WithEvents lblScanBoxNbr As System.Windows.Forms.Label
        Friend WithEvents lblBoxCount As System.Windows.Forms.Label
        Friend WithEvents txtScanBoxNbr As System.Windows.Forms.TextBox
        Friend WithEvents lstBoxNbrs As System.Windows.Forms.ListBox
        Friend WithEvents rbWingTechATTSP As System.Windows.Forms.RadioButton
        Friend WithEvents rbATT As System.Windows.Forms.RadioButton
        Friend WithEvents rbCricket As System.Windows.Forms.RadioButton
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lbl As System.Windows.Forms.Label
        Friend WithEvents lblCnt As System.Windows.Forms.Label
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents lblGridCaption As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents chkManifestExcelRpt As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintBoxLabel As System.Windows.Forms.CheckBox
        Friend WithEvents PanelList As System.Windows.Forms.Panel
        Friend WithEvents lstRURRTMParts As System.Windows.Forms.ListBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents lstRUR As System.Windows.Forms.ListBox
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents cmdShip As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmdClear As System.Windows.Forms.Button
        Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents lstDetail As System.Windows.Forms.ListBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lstWrongSKULength As System.Windows.Forms.ListBox
        Friend WithEvents btnPrintManifestRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWingTechATT_ProduceBox))
            Me.btnClearList = New System.Windows.Forms.Button()
            Me.lblScanBoxNbr = New System.Windows.Forms.Label()
            Me.lblBoxCount = New System.Windows.Forms.Label()
            Me.txtScanBoxNbr = New System.Windows.Forms.TextBox()
            Me.lstBoxNbrs = New System.Windows.Forms.ListBox()
            Me.rbWingTechATTSP = New System.Windows.Forms.RadioButton()
            Me.rbATT = New System.Windows.Forms.RadioButton()
            Me.rbCricket = New System.Windows.Forms.RadioButton()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lbl = New System.Windows.Forms.Label()
            Me.lblCnt = New System.Windows.Forms.Label()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
            Me.lblGridCaption = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.chkManifestExcelRpt = New System.Windows.Forms.CheckBox()
            Me.chkPrintBoxLabel = New System.Windows.Forms.CheckBox()
            Me.PanelList = New System.Windows.Forms.Panel()
            Me.lstRURRTMParts = New System.Windows.Forms.ListBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.lstRUR = New System.Windows.Forms.ListBox()
            Me.lstRegular = New System.Windows.Forms.ListBox()
            Me.cmdShip = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cmdClear = New System.Windows.Forms.Button()
            Me.cmdFileCheck = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lstWrongModel = New System.Windows.Forms.ListBox()
            Me.lstDetail = New System.Windows.Forms.ListBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lstWrongSKULength = New System.Windows.Forms.ListBox()
            Me.btnPrintManifestRpt = New System.Windows.Forms.Button()
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.PanelList.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnClearList
            '
            Me.btnClearList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClearList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearList.Location = New System.Drawing.Point(768, 359)
            Me.btnClearList.Name = "btnClearList"
            Me.btnClearList.TabIndex = 131
            Me.btnClearList.Text = "Clear List"
            Me.btnClearList.Visible = False
            '
            'lblScanBoxNbr
            '
            Me.lblScanBoxNbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanBoxNbr.ForeColor = System.Drawing.Color.White
            Me.lblScanBoxNbr.Location = New System.Drawing.Point(584, 112)
            Me.lblScanBoxNbr.Name = "lblScanBoxNbr"
            Me.lblScanBoxNbr.Size = New System.Drawing.Size(128, 23)
            Me.lblScanBoxNbr.TabIndex = 129
            Me.lblScanBoxNbr.Text = "Scan Box Numbers"
            Me.lblScanBoxNbr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblScanBoxNbr.Visible = False
            '
            'lblBoxCount
            '
            Me.lblBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxCount.ForeColor = System.Drawing.Color.White
            Me.lblBoxCount.Location = New System.Drawing.Point(720, 112)
            Me.lblBoxCount.Name = "lblBoxCount"
            Me.lblBoxCount.Size = New System.Drawing.Size(28, 23)
            Me.lblBoxCount.TabIndex = 130
            Me.lblBoxCount.Text = "0"
            Me.lblBoxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblBoxCount.Visible = False
            '
            'txtScanBoxNbr
            '
            Me.txtScanBoxNbr.BackColor = System.Drawing.Color.White
            Me.txtScanBoxNbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtScanBoxNbr.Location = New System.Drawing.Point(584, 144)
            Me.txtScanBoxNbr.Name = "txtScanBoxNbr"
            Me.txtScanBoxNbr.Size = New System.Drawing.Size(168, 23)
            Me.txtScanBoxNbr.TabIndex = 127
            Me.txtScanBoxNbr.Text = ""
            Me.txtScanBoxNbr.Visible = False
            '
            'lstBoxNbrs
            '
            Me.lstBoxNbrs.Location = New System.Drawing.Point(584, 171)
            Me.lstBoxNbrs.Name = "lstBoxNbrs"
            Me.lstBoxNbrs.Size = New System.Drawing.Size(168, 212)
            Me.lstBoxNbrs.TabIndex = 128
            Me.lstBoxNbrs.Visible = False
            '
            'rbWingTechATTSP
            '
            Me.rbWingTechATTSP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbWingTechATTSP.ForeColor = System.Drawing.Color.White
            Me.rbWingTechATTSP.Location = New System.Drawing.Point(416, 111)
            Me.rbWingTechATTSP.Name = "rbWingTechATTSP"
            Me.rbWingTechATTSP.Size = New System.Drawing.Size(144, 24)
            Me.rbWingTechATTSP.TabIndex = 126
            Me.rbWingTechATTSP.Text = "WingTechATT PROJECT"
            '
            'rbATT
            '
            Me.rbATT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbATT.ForeColor = System.Drawing.Color.White
            Me.rbATT.Location = New System.Drawing.Point(248, 111)
            Me.rbATT.Name = "rbATT"
            Me.rbATT.Size = New System.Drawing.Size(136, 24)
            Me.rbATT.TabIndex = 125
            Me.rbATT.Text = "ATT Fedex and CTDI"
            '
            'rbCricket
            '
            Me.rbCricket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbCricket.ForeColor = System.Drawing.Color.White
            Me.rbCricket.Location = New System.Drawing.Point(128, 111)
            Me.rbCricket.Name = "rbCricket"
            Me.rbCricket.TabIndex = 124
            Me.rbCricket.Text = "CRICKET"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(248, 87)
            Me.Label4.Name = "Label4"
            Me.Label4.TabIndex = 123
            Me.Label4.Text = "0"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(24, 111)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 21)
            Me.Label3.TabIndex = 122
            Me.Label3.Text = "Location:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.grdPallets.Location = New System.Drawing.Point(24, 144)
            Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdPallets.Name = "grdPallets"
            Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdPallets.PreviewInfo.ZoomFactor = 75
            Me.grdPallets.RowHeight = 20
            Me.grdPallets.Size = New System.Drawing.Size(544, 232)
            Me.grdPallets.TabIndex = 120
            Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:" & _
            "LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1" & _
            "4{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style15{}H" & _
            "eading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;" & _
            "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
            "ol;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></" & _
            "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""16"" AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeSt" & _
            "yle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScro" & _
            "llGroup=""1"" HorizontalScrollGroup=""1""><Height>228</Height><CaptionStyle parent=""" & _
            "Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle " & _
            "parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /" & _
            "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
            "12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
            "ghlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
            "Style parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector""" & _
            " me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""No" & _
            "rmal"" me=""Style1"" /><ClientRect>0, 0, 540, 228</ClientRect><BorderSide>0</Border" & _
            "Side><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><" & _
            "NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /" & _
            "><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><S" & _
            "tyle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><St" & _
            "yle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><St" & _
            "yle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style p" & _
            "arent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><S" & _
            "tyle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horz" & _
            "Splits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth><ClientArea>0, 0, 540, 228</ClientArea><PrintPageHeaderStyle parent="""" me=""" & _
            "Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lbl
            '
            Me.lbl.BackColor = System.Drawing.Color.Black
            Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl.ForeColor = System.Drawing.Color.Yellow
            Me.lbl.Location = New System.Drawing.Point(16, 15)
            Me.lbl.Name = "lbl"
            Me.lbl.Size = New System.Drawing.Size(383, 65)
            Me.lbl.TabIndex = 114
            Me.lbl.Text = "WingTechATT PRODUCE BOX"
            Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCnt
            '
            Me.lblCnt.BackColor = System.Drawing.Color.Black
            Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblCnt.Location = New System.Drawing.Point(784, 15)
            Me.lblCnt.Name = "lblCnt"
            Me.lblCnt.Size = New System.Drawing.Size(92, 65)
            Me.lblCnt.TabIndex = 115
            Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblCnt.Visible = False
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Black
            Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Lime
            Me.lblPallet.Location = New System.Drawing.Point(392, 15)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(390, 65)
            Me.lblPallet.TabIndex = 117
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblPallet.Visible = False
            '
            'cmdReprintPalletLabel
            '
            Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(760, 223)
            Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
            Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(248, 32)
            Me.cmdReprintPalletLabel.TabIndex = 121
            Me.cmdReprintPalletLabel.Text = "REPRINT BOX LABEL"
            Me.cmdReprintPalletLabel.Visible = False
            '
            'lblGridCaption
            '
            Me.lblGridCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGridCaption.ForeColor = System.Drawing.Color.White
            Me.lblGridCaption.Location = New System.Drawing.Point(32, 87)
            Me.lblGridCaption.Name = "lblGridCaption"
            Me.lblGridCaption.Size = New System.Drawing.Size(160, 19)
            Me.lblGridCaption.TabIndex = 116
            Me.lblGridCaption.Text = "Boxes to be Completed:"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkManifestExcelRpt, Me.chkPrintBoxLabel})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(760, 135)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(248, 80)
            Me.GroupBox2.TabIndex = 113
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Options"
            Me.GroupBox2.Visible = False
            '
            'chkManifestExcelRpt
            '
            Me.chkManifestExcelRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkManifestExcelRpt.ForeColor = System.Drawing.Color.White
            Me.chkManifestExcelRpt.Location = New System.Drawing.Point(16, 40)
            Me.chkManifestExcelRpt.Name = "chkManifestExcelRpt"
            Me.chkManifestExcelRpt.Size = New System.Drawing.Size(271, 32)
            Me.chkManifestExcelRpt.TabIndex = 1
            Me.chkManifestExcelRpt.Text = "PRINT EXCE MANIFEST REPORT"
            '
            'chkPrintBoxLabel
            '
            Me.chkPrintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintBoxLabel.ForeColor = System.Drawing.Color.White
            Me.chkPrintBoxLabel.Location = New System.Drawing.Point(16, 16)
            Me.chkPrintBoxLabel.Name = "chkPrintBoxLabel"
            Me.chkPrintBoxLabel.Size = New System.Drawing.Size(271, 28)
            Me.chkPrintBoxLabel.TabIndex = 0
            Me.chkPrintBoxLabel.Text = "PRINT BOX LABEL"
            '
            'PanelList
            '
            Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRURRTMParts, Me.Label12, Me.lstRUR, Me.lstRegular, Me.cmdShip, Me.Label1, Me.cmdClear, Me.cmdFileCheck, Me.Label9, Me.lstWrongModel, Me.lstDetail, Me.Label13, Me.Label2, Me.Label11, Me.lstWrongSKULength})
            Me.PanelList.Location = New System.Drawing.Point(24, 391)
            Me.PanelList.Name = "PanelList"
            Me.PanelList.Size = New System.Drawing.Size(964, 288)
            Me.PanelList.TabIndex = 119
            Me.PanelList.Visible = False
            '
            'lstRURRTMParts
            '
            Me.lstRURRTMParts.Location = New System.Drawing.Point(288, 24)
            Me.lstRURRTMParts.Name = "lstRURRTMParts"
            Me.lstRURRTMParts.Size = New System.Drawing.Size(132, 199)
            Me.lstRURRTMParts.TabIndex = 6
            Me.lstRURRTMParts.Visible = False
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
            Me.Label12.Visible = False
            '
            'lstRUR
            '
            Me.lstRUR.Location = New System.Drawing.Point(152, 24)
            Me.lstRUR.Name = "lstRUR"
            Me.lstRUR.Size = New System.Drawing.Size(132, 199)
            Me.lstRUR.TabIndex = 4
            Me.lstRUR.Visible = False
            '
            'lstRegular
            '
            Me.lstRegular.Location = New System.Drawing.Point(16, 24)
            Me.lstRegular.Name = "lstRegular"
            Me.lstRegular.Size = New System.Drawing.Size(133, 199)
            Me.lstRegular.TabIndex = 5
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
            Me.cmdShip.Text = "PRODUCE"
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
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Gold
            Me.Label9.Location = New System.Drawing.Point(704, 0)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(131, 20)
            Me.Label9.TabIndex = 60
            Me.Label9.Text = "DETAIL:"
            Me.Label9.Visible = False
            '
            'lstWrongModel
            '
            Me.lstWrongModel.Location = New System.Drawing.Point(432, 24)
            Me.lstWrongModel.Name = "lstWrongModel"
            Me.lstWrongModel.Size = New System.Drawing.Size(132, 199)
            Me.lstWrongModel.TabIndex = 7
            Me.lstWrongModel.Visible = False
            '
            'lstDetail
            '
            Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.lstDetail.Location = New System.Drawing.Point(704, 24)
            Me.lstDetail.Name = "lstDetail"
            Me.lstDetail.Size = New System.Drawing.Size(254, 199)
            Me.lstDetail.TabIndex = 9
            Me.lstDetail.Visible = False
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
            Me.Label13.Visible = False
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
            Me.Label2.Visible = False
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
            Me.Label11.Visible = False
            '
            'lstWrongSKULength
            '
            Me.lstWrongSKULength.Location = New System.Drawing.Point(568, 24)
            Me.lstWrongSKULength.Name = "lstWrongSKULength"
            Me.lstWrongSKULength.Size = New System.Drawing.Size(132, 199)
            Me.lstWrongSKULength.TabIndex = 8
            Me.lstWrongSKULength.Visible = False
            '
            'btnPrintManifestRpt
            '
            Me.btnPrintManifestRpt.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintManifestRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintManifestRpt.ForeColor = System.Drawing.Color.Black
            Me.btnPrintManifestRpt.Location = New System.Drawing.Point(760, 263)
            Me.btnPrintManifestRpt.Name = "btnPrintManifestRpt"
            Me.btnPrintManifestRpt.Size = New System.Drawing.Size(248, 32)
            Me.btnPrintManifestRpt.TabIndex = 118
            Me.btnPrintManifestRpt.Text = "RePrint Excel Manifest Report"
            Me.btnPrintManifestRpt.Visible = False
            '
            'frmWingTechATT_ProduceBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1024, 694)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClearList, Me.lblScanBoxNbr, Me.lblBoxCount, Me.txtScanBoxNbr, Me.lstBoxNbrs, Me.rbWingTechATTSP, Me.rbATT, Me.rbCricket, Me.Label4, Me.Label3, Me.grdPallets, Me.lbl, Me.lblCnt, Me.lblPallet, Me.cmdReprintPalletLabel, Me.lblGridCaption, Me.GroupBox2, Me.PanelList, Me.btnPrintManifestRpt})
            Me.Name = "frmWingTechATT_ProduceBox"
            Me.Text = "frmWingTechATT_ProduceBox"
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.PanelList.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private dt As DataTable

        Private Sub frmWingTechATT_ProduceBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtLoc As DataTable
            Dim dtModel As DataTable
            Dim dtType As DataTable
            Dim iLoc_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iType_ID As Integer = 0
            'dtLoc = Me._objWingTechATT_ProduceBox.GetWingTechATTLocations(Me._iMenuCustID, True)
            'Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
            'If dtLoc.Rows.Count = 2 Then
            '    iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
            '    Me.cboLocation.SelectedValue = iLoc_ID
            'Else
            '    Me.cboLocation.SelectedValue = 0
            'End If
            rbCricket.Checked = True
            Label4.Text = Me.grdPallets.RowCount
        End Sub

        Private Sub ClearListControls()
            Me.lstRegular.Items.Clear()
            Me.lstRUR.Items.Clear()
            Me.lstRURRTMParts.Items.Clear()
            Me.lstWrongModel.Items.Clear()
            Me.lstWrongSKULength.Items.Clear()
            Me.lstDetail.Items.Clear()
            Me.lblCnt.Text = ""
            Me.lblPallet.Text = ""
            cmdShip.Enabled = False
        End Sub

        Private Sub ClearControls()

            Me.PanelList.Visible = False
            Me.chkPrintBoxLabel.Checked = False

            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            If rbWingTechATTSP.Checked = True AndAlso txtScanBoxNbr.Visible = True Then
                txtScanBoxNbr.Focus()
            End If

            '*********************
            'objBulkShip Variables

            '*********************

            Me.lblCnt.Text = ""
            Me.lblPallet.Text = ""
        End Sub
        Private Sub ProcessPallet()
            Dim iExcelNum As Integer = 0
            Dim iPSSNum As Integer = 0
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strFilePath As String = ""
            Dim bOtherMessCustomer As Boolean = False
            Dim cnt As Integer = 0
            Dim Qty As Integer = 0
            Dim strModel_IDs As String
            'Dim dt As DataTable
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
                PallettQty = Me.grdPallets.Columns("Quantity").Value
                cnt = Me.grdPallets.Columns("count").Value

                iModel_ID = Me.grdPallets.Columns("Model_ID").Value
                If iModel_ID = 5252 OrElse iModel_ID = 5251 Then
                    strModel_IDs = "5252,5251"
                Else
                    strModel_IDs = iModel_ID
                End If
                iShipType = Me.grdPallets.Columns("ShipType").Value
                strSKULength = Trim(Me.grdPallets.Columns("SKU Length").Value.ToString)
                strShipTypeDesc = Me.grdPallets.Columns("ShipType").Value
                iCustID = Me.grdPallets.Columns("Cust_ID").Value
                iLocID = Me.grdPallets.Columns("Loc_ID").Value


                dt = _objWingTechATT_ProduceBox.getDeviceSn(iPallett_ID, strModel_IDs)
                _objBulkShip = New BulkShipping()
                Me._objBulkShip.dtExcelSNs = dt.Clone
                Me._objBulkShip.iCust_ID = iCustID
                If dt.Rows.Count > 0 Then

                    'If dt.Rows.Count <> cnt Then
                    '    MessageBox.Show("Number of devices on Pallet," & cnt & ", is not same as actual number of devices " & dt.Rows.Count, "ProduceBox", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    '    Exit Sub
                    'End If

                    For Each R1 In dt.Rows
                        Me.lstRegular.Items.Add(Trim(R1("SN")))
                    Next

                    ''Else
                    ''    MessageBox.Show(String.Concat("No devices were found in Box Number: ", strPalletName), "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub grdPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdPallets.Click
            iFlg = 1
            If grdPallets.RowCount > 0 Then
                ProcessPallet()
            End If
        End Sub

        Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
            If iFlg = 0 Then
                Exit Sub
            End If
            If Me.grdPallets.Columns.Count = 0 OrElse Me.grdPallets.RowCount = 0 Then
                Exit Sub
            End If
            ProcessPallet()

        End Sub

        Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
            ClearControls()
        End Sub

        Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
            Dim strSN As String = ""
            Dim SN As String = ""
            Dim R1 As DataRow
            Dim iMatch As Integer = 0

            Try
                If Not IsNothing(lstRegular) Then
                    'Select Case iCustID
                    '    Case SkyTel.SKYTEL_CUSTOMER_ID, SkyTel.MorrisCom_CUSTOMER_ID, _
                    '         SkyTel.Propage_CUSTOMER_ID, SkyTel.Aquis_CUSTOMER_ID, SkyTel.CookPager_CUSTOMER_ID
                    strSN = InputBox("Please scan in a 'Serial Number' to make sure you have selected the right file.").Trim.ToUpper
                    If strSN <> "" Then
                        For Each SN In lstRegular.Items
                            If strSN = SN Then
                                iMatch = 1
                                Exit For
                            End If
                        Next
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

                    '    Case Else
                    '        Throw New Exception("Cust_ID is missing.")
                    'End Select
                End If

            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Sub

        Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click

            cmdShip.Enabled = False

            If rbWingTechATTSP.Checked = True Then
                'For WingTechATT
                WingTechATTListBoxLoop()
            Else
                'For Cricket or ATT Fedex and CTDI
                BulkShipPallets()
            End If

        End Sub

        Private Sub WingTechATTListBoxLoop()

            Dim j As Integer
            Dim listBxItem As String
            Dim listBxIndex As Integer
            Dim palletID As Integer
            Dim bGoodPallet As Boolean = False
            Dim i As Integer = 0
            Dim boxErrList As New ArrayList()

            Try

                boxErrList.Clear()

                Do While lstBoxNbrs.Items.Count > 0

                    listBxItem = lstBoxNbrs.Items(0).ToString

                    For j = 0 To grdPallets.RowCount - 1

                        If listBxItem = Me.grdPallets.Columns("Pallet").CellValue(j) Then
                            palletID = Me.grdPallets.Columns("pallett_id").CellValue(j)
                            iPallett_ID = palletID
                            iCustID = Me.grdPallets.Columns("Cust_ID").CellValue(j)
                            iLocID = Me.grdPallets.Columns("Loc_ID").CellValue(j)
                            iModel_ID = Me.grdPallets.Columns("Model_ID").CellValue(j)
                            strSKULength = Me.grdPallets.Columns("SKU Length").CellValue(j)
                            strShipTypeDesc = Me.grdPallets.Columns("ShipType").CellValue(j)
                            strPalletName = listBxItem
                            bGoodPallet = True

                            Exit For
                        End If
                    Next
                    If bGoodPallet = True Then
                        dt = _objWingTechATT_ProduceBox.getDeviceSn(iPallett_ID, iModel_ID)
                        'Filecheck is not required with this method.  Mark as done...
                        iFileCheckDone = 2
                        i = 0

                        i = BulkShipPallets()
                        'Create a list of boxed that failed to be produced
                        If i = 0 Then
                            boxErrList.Add(strPalletName)
                        End If

                        'Remove the zero indexed item from the list box - this is the box number just processed
                        lstBoxNbrs.Items.RemoveAt(0)
                        lblBoxCount.Text = lstBoxNbrs.Items.Count
                        Me.Refresh()
                        EnableProduceButton()
                    End If
                Loop

                'Show a list of the box numbers that failed to produce
                If boxErrList.Count > 0 Then
                    Dim bxName As String
                    Dim errMsg As String = "List of Box Failures"

                    For Each bxName In boxErrList
                        errMsg = String.Concat(errMsg, vbCrLf, bxName)
                    Next
                    MessageBox.Show(errMsg, "Boxes that Failed to Produce")
                End If

                If lstBoxNbrs.Items.Count = 0 Then
                    btnClearList.Visible = False
                    txtScanBoxNbr.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Function BulkShipPallets() As Integer
            Dim i As Integer = 0
            Dim s As Integer = 0
            Dim iPrintCopies As Integer = 2, iWipOwnerID As Integer
            Dim booAMSSharedCust As Boolean = False
            Dim strSimKittingMsg As String = ""
            Dim kitValidationRequired As Boolean = False


            Try
                '*****************************************************
                DoValidation()
                '*****************************************************

                'Validate SIM card kitting ***************************
                'Bypass the check if the project doesn't require kitting
                _objWingTechATT_SP.CustID = iCustID
                _objWingTechATT_SP.LocID = iLocID
                _objWingTechATT_SP.ProjectName = "6K202Project"
                strSimKittingMsg = ""
                strSimKittingMsg = _objWingTechATT_SP.CheckDevicesInBoxAreKitted(iPallett_ID)
                'Returns a zero length string if SIM Card was kitted
                If strSimKittingMsg.Length > 0 Then
                    MessageBox.Show(String.Concat("No devices found in box number: ", strPalletName), "Produce Box Failed")
                    Exit Function
                End If
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
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                'i = _objBulkShip.BulkShip(Me.chkNoReprot.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , 0)
                _objBulkShip = New BulkShipping()
                _objBulkShip.iPallet_ID = iPallett_ID
                _objBulkShip.iShiftID = "1"
                _objBulkShip.iLoc_ID = iLocID
                _objBulkShip.iCust_ID = iCustID
                _objBulkShip.strFilePath = "P:\WingTechATT\PackingSlip\" & iPallett_ID.ToString & "_" & String.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now) & ".xls"
                'i = _objBulkShip.BulkShip(Me.chkManifestExcelRpt.Checked, iHoldStatus, PallettQty, , 0, iWipOwnerID, dt)
                i = _objBulkShip.BulkShip(Me.chkManifestExcelRpt.Checked, iHoldStatus, PallettQty, , 0, iWipOwnerID, dt)
                Label4.Text = Me.grdPallets.RowCount
                ClearControls()
                Try
                    Dim dtPallets As New DataTable()
                    'If cboLocation.SelectedValue <> 0 Then
                    Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                    If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                    '  If Me.rbWingTechATTSP.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID
                    dtPallets = _objWingTechATT_ProduceBox.getAllPallets(strLoc_id)
                    'Else
                    '    dtPallets.Clear()
                    'End If
                    Me.grdPallets.ClearFields()
                    Me.grdPallets.DataSource = dtPallets.DefaultView
                    SetPalletGridProperties()
                    Label4.Text = Me.grdPallets.RowCount
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try

                'Update the SIM card records in the tdevice table **********

                If _objWingTechATT_SP.KitValidationRequired = True Then
                    s = _objWingTechATT_SP.UpdateSimCard(iPallett_ID)
                    'MessageBox.Show(String.Concat("Updated ", s.ToString, " SIM card records"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                '***********************************************************
                'An i value > 0 indicates a successful produce box 
                Return i

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ship Boxes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Function

        Private Sub LoadPallets()
            Dim dtPallets As New DataTable()
            ' Dim objBulkShip As BulkShipping

            Try
                ClearControls()
                ' Me._objBulkShip = Nothing
                Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID

                dtPallets = _objWingTechATT_ProduceBox.getAllPallets(strLoc_id)
                'Me._objCoolPad_BoxShip = New BulkShipping()
                'dtPallets = Me._objCoolPad_BoxShip.GetPalletsReadyToBeShipped(iHoldStatus, iMachineCCGroup, _iMenuCustID)
                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView
                SetPalletGridProperties()
                'objBulkShip = Nothing

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtPallets) Then
                    dtPallets.Dispose()
                    dtPallets = Nothing
                End If
            End Try
        End Sub
        Private Sub SetPalletGridProperties()
            Dim iNumOfColumns As Integer = Me.grdPallets.Columns.Count
            Dim i As Integer


            With Me.grdPallets
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(7).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(8).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(0).Width = 70
                .Splits(0).DisplayColumns(1).Width = 140
                .Splits(0).DisplayColumns(2).Width = 45
                .Splits(0).DisplayColumns(3).Width = 69
                .Splits(0).DisplayColumns(4).Width = 81
                .Splits(0).DisplayColumns(5).Width = 70
                .Splits(0).DisplayColumns(6).Width = 60
                .Splits(0).DisplayColumns(7).Width = 60
                .Splits(0).DisplayColumns(8).Width = 60

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = True
                .Splits(0).DisplayColumns(5).Visible = True
                .Splits(0).DisplayColumns(6).Visible = True
                .Splits(0).DisplayColumns(7).Visible = True
                .Splits(0).DisplayColumns(8).Visible = True

            End With
        End Sub
        Private Sub DoValidation()
            '***************************


            '***************************
            'Check the Billcode rule of the device and the Selected ShipType.
            'If they are different then don't let them ship
            'If iShipType = 0 Then   'REGULAR
            '    If Me.lstRUR.Items.Count > 0 Then
            '        Me.BackColor = System.Drawing.Color.Red
            '        System.Windows.Forms.Application.DoEvents()
            '        Throw New Exception("You are trying to ship DBR/NER devices with REGULAR devices. Not allowed.")
            '    End If
            'ElseIf iShipType = 1 OrElse iShipType = 2 Then   'BER-NER
            '    If Me.lstRegular.Items.Count > 0 Then
            '        Me.BackColor = System.Drawing.Color.Red
            '        System.Windows.Forms.Application.DoEvents()
            '        Throw New Exception("You are trying to ship REGULAR devices with DBR/NER devices. Not allowed.")
            '    End If
            'Else
            '    Throw New Exception("'Ship Type' not determined.")
            'End If

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

        Private Sub rbCricket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCricket.CheckedChanged
            Try
                If rbCricket.Checked = False Then
                    lstRegular.Items.Clear()
                    Exit Sub
                End If
                Dim dtPallets As New DataTable()
                ShowHideWingTechATTControls(False)
                'If cboLocation.SelectedValue <> 0 Then
                Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                dtPallets = _objWingTechATT_ProduceBox.getAllPallets(strLoc_id)
                'Else
                '    dtPallets.Clear()
                'End If
                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView
                SetPalletGridProperties()
                Label4.Text = Me.grdPallets.RowCount
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        Private Sub rbATT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbATT.CheckedChanged
            Try
                If rbATT.Checked = False Then
                    lstRegular.Items.Clear()
                    Exit Sub
                End If
                ShowHideWingTechATTControls(False)
                Dim dtPallets As New DataTable()
                'If cboLocation.SelectedValue <> 0 Then
                Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                dtPallets = _objWingTechATT_ProduceBox.getAllPallets(strLoc_id)
                'Else
                '    dtPallets.Clear()
                'End If
                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView
                SetPalletGridProperties()
                Label4.Text = Me.grdPallets.RowCount
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub rbWingTechATTSP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWingTechATTSP.CheckedChanged
            Try
                If rbWingTechATTSP.Checked = False Then
                    Exit Sub
                End If

                ShowHideWingTechATTControls(True)

                Dim dtPallets As New DataTable()
                'If cboLocation.SelectedValue <> 0 Then
                Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                ' If Me.rbWingTechATTSP.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID
                dtPallets = _objWingTechATT_ProduceBox.getAllPallets(strLoc_id)
                'Else
                '    dtPallets.Clear()
                'End If
                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView
                SetPalletGridProperties()
                Label4.Text = Me.grdPallets.RowCount
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ShowHideWingTechATTControls(ByVal bShow As Boolean)
            Try
                txtScanBoxNbr.Visible = bShow
                lblScanBoxNbr.Visible = bShow
                lstBoxNbrs.Visible = bShow
                lblBoxCount.Visible = bShow
                lblBoxCount.Text = lstBoxNbrs.Items.Count.ToString
                If lstBoxNbrs.Items.Count > 0 Then
                    btnClearList.Visible = bShow
                End If

                If bShow = True Then
                    cmdFileCheck.Visible = False
                    lstRegular.Visible = False
                    Label1.Visible = False
                    cmdClear.Visible = False
                    EnableProduceButton()
                    txtScanBoxNbr.Focus()
                Else
                    cmdFileCheck.Visible = True
                    lstRegular.Visible = True
                    Label1.Visible = True
                    cmdShip.Enabled = False
                    cmdClear.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub txtScanBoxNbr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanBoxNbr.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso txtScanBoxNbr.Text.Length > 0 Then
                    AddToListBox()
                    txtScanBoxNbr.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub AddToListBox()
            Dim index As Integer
            Dim dc As C1DataColumn
            Dim grdBoxNbr As String

            Try
                'Check for duplicate values
                index = lstBoxNbrs.FindString(txtScanBoxNbr.Text.ToUpper)
                If lstBoxNbrs.Items.Count > 0 AndAlso index <> -1 Then
                    MessageBox.Show(String.Concat("Box Number ", txtScanBoxNbr.Text, " is already in the list."), "Duplicate Number", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtScanBoxNbr.Text = String.Empty
                    txtScanBoxNbr.Focus()
                    Exit Sub
                End If

                'Is the box number valid.  Compare to boxes in the grid
                Dim row As Integer
                Dim i As Integer
                Dim bValidBox As Boolean
                For i = 0 To grdPallets.RowCount - 1
                    grdBoxNbr = Me.grdPallets.Columns(1).CellValue(i)
                    If grdBoxNbr.ToUpper = txtScanBoxNbr.Text.ToUpper Then
                        bValidBox = True
                        Exit For
                    End If
                Next

                If bValidBox = False Then
                    MessageBox.Show(String.Concat("Scanned box number: ", txtScanBoxNbr.Text, " was not found."), "Invalid Box Number", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtScanBoxNbr.Text = String.Empty
                    EnableProduceButton()
                    Exit Sub
                End If

                lstBoxNbrs.Items.Add(txtScanBoxNbr.Text.ToUpper)
                txtScanBoxNbr.Text = String.Empty
                lblBoxCount.Text = lstBoxNbrs.Items.Count.ToString
                If lstBoxNbrs.Items.Count > 0 Then
                    PanelList.Visible = True
                    btnClearList.Visible = True
                    EnableProduceButton()
                Else
                    btnClearList.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub

        Private Sub EnableProduceButton()
            If lstBoxNbrs.Items.Count > 0 Then
                If PanelList.Visible = False Then
                    PanelList.Visible = True
                End If
                cmdShip.Enabled = True
            Else
                cmdShip.Enabled = False
            End If
        End Sub

        Private Sub txtScanBoxNbr_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanBoxNbr.GotFocus
            txtScanBoxNbr.BackColor = Color.LightGoldenrodYellow
        End Sub

        Private Sub txtScanBoxNbr_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanBoxNbr.LostFocus
            txtScanBoxNbr.BackColor = Color.White
        End Sub




        Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
            Try

                lstBoxNbrs.Items.Clear()
                lblBoxCount.Text = lstBoxNbrs.Items.Count.ToString
                EnableProduceButton()
                btnClearList.Visible = False
                txtScanBoxNbr.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
    End Class
End Namespace