Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.CP
    Public Class frmCoolPad_ProduceBox
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objCoolPad As PSS.Data.Buisness.CP.CoolPad
        Private _objMisc As PSS.Data.Buisness.Misc
        Private _objBulkShip As BulkShipping
        Private _objCoolPad_ProduceShip As PSS.Data.Buisness.CP.CoolPad_ProduceBox

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User


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

        Private dt As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            ' Me._iLoc_ID = iLoc_ID
            Me._strScreenName = strScreenName
            Me._objCoolPad = New PSS.Data.Buisness.CP.CoolPad()
            'Me._objCoolPad_ProduceShip = New PSS.Data.Buisness.CP._objCoolPad_ProduceShip()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objCoolPad = Nothing
                    Me._objCoolPad_ProduceShip = Nothing
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
        Friend WithEvents btnPrintManifestRpt As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents chkManifestExcelRpt As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintBoxLabel As System.Windows.Forms.CheckBox
        Friend WithEvents lblGridCaption As System.Windows.Forms.Label
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents lblCnt As System.Windows.Forms.Label
        Friend WithEvents lbl As System.Windows.Forms.Label
        Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents PanelList As System.Windows.Forms.Panel
        Friend WithEvents lstRURRTMParts As System.Windows.Forms.ListBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents lstRUR As System.Windows.Forms.ListBox
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents cmdShip As System.Windows.Forms.Button
        Friend WithEvents lstDetail As System.Windows.Forms.ListBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cmdClear As System.Windows.Forms.Button
        Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lstWrongSKULength As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCoolPad_ProduceBox))
            Me.btnPrintManifestRpt = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.chkManifestExcelRpt = New System.Windows.Forms.CheckBox()
            Me.chkPrintBoxLabel = New System.Windows.Forms.CheckBox()
            Me.lblGridCaption = New System.Windows.Forms.Label()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.lblCnt = New System.Windows.Forms.Label()
            Me.lbl = New System.Windows.Forms.Label()
            Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
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
            Me.GroupBox2.SuspendLayout()
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelList.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnPrintManifestRpt
            '
            Me.btnPrintManifestRpt.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintManifestRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintManifestRpt.ForeColor = System.Drawing.Color.Black
            Me.btnPrintManifestRpt.Location = New System.Drawing.Point(464, 216)
            Me.btnPrintManifestRpt.Name = "btnPrintManifestRpt"
            Me.btnPrintManifestRpt.Size = New System.Drawing.Size(309, 28)
            Me.btnPrintManifestRpt.TabIndex = 89
            Me.btnPrintManifestRpt.Text = "RePrint Excel Manifest Report"
            Me.btnPrintManifestRpt.Visible = False
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkManifestExcelRpt, Me.chkPrintBoxLabel})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(464, 88)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(309, 75)
            Me.GroupBox2.TabIndex = 83
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
            Me.chkManifestExcelRpt.Size = New System.Drawing.Size(271, 28)
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
            'lblGridCaption
            '
            Me.lblGridCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGridCaption.ForeColor = System.Drawing.Color.White
            Me.lblGridCaption.Location = New System.Drawing.Point(8, 72)
            Me.lblGridCaption.Name = "lblGridCaption"
            Me.lblGridCaption.Size = New System.Drawing.Size(327, 19)
            Me.lblGridCaption.TabIndex = 86
            Me.lblGridCaption.Text = "Boxs to be Completed:"
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Black
            Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Lime
            Me.lblPallet.Location = New System.Drawing.Point(376, 0)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(390, 65)
            Me.lblPallet.TabIndex = 87
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblPallet.Visible = False
            '
            'lblCnt
            '
            Me.lblCnt.BackColor = System.Drawing.Color.Black
            Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblCnt.Location = New System.Drawing.Point(768, 0)
            Me.lblCnt.Name = "lblCnt"
            Me.lblCnt.Size = New System.Drawing.Size(92, 65)
            Me.lblCnt.TabIndex = 85
            Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblCnt.Visible = False
            '
            'lbl
            '
            Me.lbl.BackColor = System.Drawing.Color.Black
            Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl.ForeColor = System.Drawing.Color.Yellow
            Me.lbl.Name = "lbl"
            Me.lbl.Size = New System.Drawing.Size(383, 65)
            Me.lbl.TabIndex = 84
            Me.lbl.Text = "CoolPad SHIP BOX"
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
            Me.grdPallets.Location = New System.Drawing.Point(0, 96)
            Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdPallets.Name = "grdPallets"
            Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdPallets.PreviewInfo.ZoomFactor = 75
            Me.grdPallets.RowHeight = 20
            Me.grdPallets.Size = New System.Drawing.Size(448, 188)
            Me.grdPallets.TabIndex = 82
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
            "Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeSt" & _
            "yle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScro" & _
            "llGroup=""1"" HorizontalScrollGroup=""1""><Height>184</Height><CaptionStyle parent=""" & _
            "Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle " & _
            "parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /" & _
            "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
            "12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
            "ghlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
            "Style parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector""" & _
            " me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""No" & _
            "rmal"" me=""Style1"" /><ClientRect>0, 0, 444, 184</ClientRect><BorderSide>0</Border" & _
            "Side><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><" & _
            "NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /" & _
            "><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><S" & _
            "tyle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><St" & _
            "yle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><St" & _
            "yle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style p" & _
            "arent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><S" & _
            "tyle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horz" & _
            "Splits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth><ClientArea>0, 0, 444, 184</ClientArea><PrintPageHeaderStyle parent="""" me=""" & _
            "Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'cmdReprintPalletLabel
            '
            Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(464, 176)
            Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
            Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(308, 28)
            Me.cmdReprintPalletLabel.TabIndex = 88
            Me.cmdReprintPalletLabel.Text = "REPRINT BOX LABEL"
            Me.cmdReprintPalletLabel.Visible = False
            '
            'PanelList
            '
            Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstRURRTMParts, Me.Label12, Me.lstRUR, Me.lstRegular, Me.Label9, Me.lstWrongModel, Me.cmdShip, Me.lstDetail, Me.Label13, Me.Label1, Me.Label2, Me.cmdClear, Me.cmdFileCheck, Me.Label11, Me.lstWrongSKULength})
            Me.PanelList.Location = New System.Drawing.Point(8, 296)
            Me.PanelList.Name = "PanelList"
            Me.PanelList.Size = New System.Drawing.Size(964, 288)
            Me.PanelList.TabIndex = 90
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
            Me.Label2.Visible = False
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
            'frmCoolPad_ProduceBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(984, 614)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelList, Me.btnPrintManifestRpt, Me.GroupBox2, Me.lblGridCaption, Me.lblPallet, Me.lblCnt, Me.lbl, Me.grdPallets, Me.cmdReprintPalletLabel})
            Me.Name = "frmCoolPad_ProduceBox"
            Me.Text = "frmCoolPad_ProduceBox"
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelList.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Protected Overrides Sub Finalize()
            _objCoolPad = Nothing
            _objCoolPad_ProduceShip = Nothing
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

        '*****************************************************************
        Private Sub ClearControls()
           

            Me.PanelList.Visible = False
            Me.chkPrintBoxLabel.Checked = False

            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            '*********************
            'objBulkShip Variables
          
            '*********************

            Me.lblCnt.Text = ""
            Me.lblPallet.Text = ""
        End Sub

        '*****************************************************************

        Private Sub frmCoolPad_ProduceBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'Dim isComputerNameMapped As Boolean = False
            'Dim tmpStr As String = ""

            Try
              

                'Me._objBulkShip.iShiftID = iShiftID
                'Me._objBulkShip.struser = strUser
                _objCoolPad_ProduceShip = New PSS.Data.Buisness.CP.CoolPad_ProduceBox()
                Dim dtPallets As DataTable = _objCoolPad_ProduceShip.getAllPallets()
                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

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

                PrintPalletBoxLabel(str_pallett)

                'Me.Enabled = False
                'Cursor.Current = Cursors.WaitCursor

                'dtPallettInfo = _objMisc.GetPalletInfo_ByPallettName(str_pallett)
                'If dtPallettInfo.Rows.Count = 0 Then
                '    MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'ElseIf dtPallettInfo.Rows.Count > 1 Then
                '    MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                '    Exit Sub
                'Else
                '    R1 = dtPallettInfo.Rows(0)

                'If R1("Pallett_ReadyToShipFlg") = 0 Then
                '    MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                '    Exit Sub
                'End If

                'If R1("Pallet_ShipType") = 0 Then
                '    strPalletType = "REFURBISHED"
                'ElseIf R1("Pallet_ShipType") = 1 Then
                '    strPalletType = "DBR"
                'ElseIf R1("Pallet_ShipType") = 2 Then
                '    strPalletType = "NER"
                'Else
                '    MessageBox.Show("System can't define Box Type.", "Information", MessageBoxButtons.OK)
                '    Exit Sub
                'End If

                'If Not IsDBNull(R1("Pallett_QTY")) Then iPalletQty = R1("Pallett_QTY")

                'If Not IsDBNull(R1("Cust_ID")) Then
                '    '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                '    PSS.Data.Production.Shipping.PrintPalletLicensePlate(str_pallett, R1("Model_ID"), strPalletType, iPalletQty, 1)
                'End If
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                'Finally
                '    R1 = Nothing
                '    If Not IsNothing(dtPallettInfo) Then
                '        dtPallettInfo.Dispose()
                '        dtPallettInfo = Nothing
                '    End If
                '    Me.Enabled = True
                '    Cursor.Current = Cursors.Default
            End Try
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
                iShipType = Me.grdPallets.Columns("ShipType").Value
                strSKULength = Trim(Me.grdPallets.Columns("SKU Length").Value.ToString)
                strShipTypeDesc = Me.grdPallets.Columns("ShipType").Value
                iCustID = Me.grdPallets.Columns("Cust_ID").Value
                iLocID = Me.grdPallets.Columns("Loc_ID").Value


                dt = _objCoolPad_ProduceShip.getDeviceSn(iPallett_ID, iModel_ID)
                _objBulkShip = New BulkShipping()
                Me._objBulkShip.dtExcelSNs = dt
                Me._objBulkShip.iCust_ID = iCustID
                If dt.Rows.Count > 0 Then

                    'If dt.Rows.Count <> cnt Then
                    '    MessageBox.Show("Number of devices on Pallet," & cnt & ", is not same as actual number of devices " & dt.Rows.Count, "ProduceBox", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    '    Exit Sub
                    'End If

                    For Each R1 In dt.Rows
                        Me.lstRegular.Items.Add(Trim(R1("SN")))
                    Next


                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Private Sub PrintPalletBoxLabel(ByVal str_pallett As String)
            Dim dtPallettInfo As DataTable
            Dim strPalletType As String = ""
            Dim iPalletQty As Integer = 0
            Dim R1 As DataRow

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

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
                MessageBox.Show(ex.ToString, "PrintPalletBoxLabel.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Generic.DisposeDT(dtPallettInfo)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************


        Private Sub LoadPallets()
            Dim dtPallets As New DataTable()
            ' Dim objBulkShip As BulkShipping

            Try
                ClearControls()
                ' Me._objBulkShip = Nothing
                _objCoolPad_ProduceShip = New PSS.Data.Buisness.CP.CoolPad_ProduceBox()
                dtPallets = _objCoolPad_ProduceShip.getAllPallets()
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
            If grdPallets.RowCount > 0 Then
                ProcessPallet()
            End If
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


        '******************************************************************
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

        '******************************************************************

        Private Sub cmdShip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdShip.Click
            Dim i As Integer = 0
            Dim iPrintCopies As Integer = 2, iWipOwnerID As Integer
            Dim booAMSSharedCust As Boolean = False

            Try
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
                '**********************************
                'Get Wipowner for Messaging
                '**********************************
                'booAMSSharedCust = Data.Buisness.MessLabel.IsAMSShareableInventoryCustomer(2627)
                'If booAMSSharedCust Then
                '    iWipOwnerID = Data.Buisness.MessReceive.GetAMSNextWipOwner(_iMenuCustID, Me._strScreenName, 0)
                '    If iWipOwnerID = 0 Then Throw New Exception("Can't define next wip location.")
                'End If

                '******************************************************
                'Bulk SHIP now.
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                'i = _objBulkShip.BulkShip(Me.chkNoReprot.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , 0)
                _objBulkShip = New BulkShipping()
                _objBulkShip.iPallet_ID = iPallett_ID
                _objBulkShip.iShiftID = "1"
                _objBulkShip.iLoc_ID = iLocID
                _objBulkShip.iCust_ID = _objCoolPad.CoolPad_CUSTOMER_ID
                _objBulkShip.strFilePath = "P:\CoolPad\PackingSlip\" & iPallett_ID.ToString & "_" & String.Format("{0:yyyyMMdd_HHmmss}", DateTime.Now) & ".xls"
                i = _objBulkShip.BulkShip(Me.chkManifestExcelRpt.Checked, iHoldStatus, PallettQty, , 0, iWipOwnerID, dt)

                '**********************************
                'Set Wipowner for Messaging
                '**********************************
                'If booAMSSharedCust Then
                '    Generic.SetTmessdataWipOwnerdataForDevices("", iWipOwnerID, 0, iPallett_ID)
                '    ' ADD DEVICE JOURNAL ENTRIES.
                '    Dim _devices As New Data.BOL.tDeviceCollectionByPallett(iPallett_ID)
                '    Dim _dr As DataRow
                '    For Each _dr In _devices.deviceDataTable.Rows()
                '        Data.BLL.MsgDeviceMovement.DeviceMovementJornalInsert(_dr("device_id"), 1, iWipOwnerID, 0, "Messaging Produce - Ship Box")
                '    Next
                '    _dr = Nothing
                '    _devices = Nothing
                'End If

                '''print license plate
                'Generic.PrintPalletLicensePlate(Me.strPalletName, Me.iModel_ID, Me.strShipTypeDesc, Me.lblCnt.Text, iPrintCopies)
                '''******************************************************
                'If Me.chkPrintBoxLabel.Checked Then PrintPalletBoxLabel(Me.strPalletName)

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

    End Class
End Namespace