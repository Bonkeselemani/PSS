Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmProdShip
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _objTFShip As PSS.Data.Buisness.TracFone.BuildShipPallet
        Private _objBulkShip As PSS.Data.Buisness.BulkShipping
        Private _objMisc As PSS.Data.Buisness.Misc
        Private _objTFMisc As PSS.Data.Buisness.TracFone.clsMisc


        Private iShipType As Integer = 0
        Private iFileCheckDone As Integer = 0
        Private iHoldStatus As Integer = 0
        Private iGroup_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objBulkShip = New PSS.Data.Buisness.BulkShipping()
            _objMisc = New PSS.Data.Buisness.Misc()
            _objTFShip = New PSS.Data.Buisness.TracFone.BuildShipPallet()
            _iMenuCustID = iCustID
            _strScreenName = strScreenName
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
        Friend WithEvents cmdReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents PanelList As System.Windows.Forms.Panel
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents cmdShip As System.Windows.Forms.Button
        Friend WithEvents lstDetail As System.Windows.Forms.ListBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents cmdClear As System.Windows.Forms.Button
        Friend WithEvents cmdFileCheck As System.Windows.Forms.Button
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lbl As System.Windows.Forms.Label
        Friend WithEvents chkNoReport As System.Windows.Forms.CheckBox
        Friend WithEvents lstBER As System.Windows.Forms.ListBox
        Friend WithEvents lstBERParts As System.Windows.Forms.ListBox
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lstSNCheckList As System.Windows.Forms.ListBox
        Friend WithEvents pnlSNcheck As System.Windows.Forms.Panel
        Friend WithEvents btnSelectBox As System.Windows.Forms.Button
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents grbServices As System.Windows.Forms.GroupBox
        Friend WithEvents chklstServices As System.Windows.Forms.CheckedListBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblCnt As System.Windows.Forms.Label
        Friend WithEvents grbBoxToBeProduce As System.Windows.Forms.GroupBox
        Friend WithEvents lblDetails As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProdShip))
            Me.cmdReprintPalletLabel = New System.Windows.Forms.Button()
            Me.PanelList = New System.Windows.Forms.Panel()
            Me.lstBER = New System.Windows.Forms.ListBox()
            Me.lstRegular = New System.Windows.Forms.ListBox()
            Me.lblDetails = New System.Windows.Forms.Label()
            Me.lstWrongModel = New System.Windows.Forms.ListBox()
            Me.cmdShip = New System.Windows.Forms.Button()
            Me.lstDetail = New System.Windows.Forms.ListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.cmdClear = New System.Windows.Forms.Button()
            Me.lstBERParts = New System.Windows.Forms.ListBox()
            Me.cmdFileCheck = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.pnlSNcheck = New System.Windows.Forms.Panel()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lstSNCheckList = New System.Windows.Forms.ListBox()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.chkNoReport = New System.Windows.Forms.CheckBox()
            Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lbl = New System.Windows.Forms.Label()
            Me.btnSelectBox = New System.Windows.Forms.Button()
            Me.chklstServices = New System.Windows.Forms.CheckedListBox()
            Me.grbServices = New System.Windows.Forms.GroupBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblCnt = New System.Windows.Forms.Label()
            Me.grbBoxToBeProduce = New System.Windows.Forms.GroupBox()
            Me.PanelList.SuspendLayout()
            Me.pnlSNcheck.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbServices.SuspendLayout()
            Me.grbBoxToBeProduce.SuspendLayout()
            Me.SuspendLayout()
            '
            'cmdReprintPalletLabel
            '
            Me.cmdReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.cmdReprintPalletLabel.Location = New System.Drawing.Point(8, 44)
            Me.cmdReprintPalletLabel.Name = "cmdReprintPalletLabel"
            Me.cmdReprintPalletLabel.Size = New System.Drawing.Size(192, 24)
            Me.cmdReprintPalletLabel.TabIndex = 80
            Me.cmdReprintPalletLabel.Text = "REPRINT BOX LABEL"
            '
            'PanelList
            '
            Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstBER, Me.lstRegular, Me.lblDetails, Me.lstWrongModel, Me.cmdShip, Me.lstDetail, Me.Label1, Me.Label2, Me.Label12, Me.cmdClear, Me.lstBERParts, Me.cmdFileCheck, Me.Label11, Me.pnlSNcheck})
            Me.PanelList.Location = New System.Drawing.Point(5, 240)
            Me.PanelList.Name = "PanelList"
            Me.PanelList.Size = New System.Drawing.Size(875, 296)
            Me.PanelList.TabIndex = 72
            Me.PanelList.Visible = False
            '
            'lstBER
            '
            Me.lstBER.Location = New System.Drawing.Point(336, 32)
            Me.lstBER.Name = "lstBER"
            Me.lstBER.Size = New System.Drawing.Size(120, 212)
            Me.lstBER.TabIndex = 4
            '
            'lstRegular
            '
            Me.lstRegular.Location = New System.Drawing.Point(208, 32)
            Me.lstRegular.Name = "lstRegular"
            Me.lstRegular.Size = New System.Drawing.Size(120, 212)
            Me.lstRegular.TabIndex = 5
            '
            'lblDetails
            '
            Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDetails.ForeColor = System.Drawing.Color.Gold
            Me.lblDetails.Location = New System.Drawing.Point(728, 16)
            Me.lblDetails.Name = "lblDetails"
            Me.lblDetails.Size = New System.Drawing.Size(130, 16)
            Me.lblDetails.TabIndex = 60
            Me.lblDetails.Text = "DETAIL:"
            '
            'lstWrongModel
            '
            Me.lstWrongModel.Location = New System.Drawing.Point(592, 32)
            Me.lstWrongModel.Name = "lstWrongModel"
            Me.lstWrongModel.Size = New System.Drawing.Size(120, 212)
            Me.lstWrongModel.TabIndex = 7
            '
            'cmdShip
            '
            Me.cmdShip.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdShip.Enabled = False
            Me.cmdShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdShip.ForeColor = System.Drawing.Color.Blue
            Me.cmdShip.Location = New System.Drawing.Point(592, 256)
            Me.cmdShip.Name = "cmdShip"
            Me.cmdShip.Size = New System.Drawing.Size(256, 32)
            Me.cmdShip.TabIndex = 2
            Me.cmdShip.Text = "PRODUCE"
            '
            'lstDetail
            '
            Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.lstDetail.Location = New System.Drawing.Point(728, 32)
            Me.lstDetail.Name = "lstDetail"
            Me.lstDetail.Size = New System.Drawing.Size(120, 212)
            Me.lstDetail.TabIndex = 9
            '
            'Label1
            '
            Me.Label1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(208, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(116, 18)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Regular Units:"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(336, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(108, 16)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "BER Units:"
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(464, 0)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(120, 32)
            Me.Label12.TabIndex = 55
            Me.Label12.Text = "BER Units with Parts:"
            '
            'cmdClear
            '
            Me.cmdClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdClear.ForeColor = System.Drawing.Color.Black
            Me.cmdClear.Location = New System.Drawing.Point(464, 256)
            Me.cmdClear.Name = "cmdClear"
            Me.cmdClear.Size = New System.Drawing.Size(120, 32)
            Me.cmdClear.TabIndex = 3
            Me.cmdClear.Text = "Clear"
            '
            'lstBERParts
            '
            Me.lstBERParts.Location = New System.Drawing.Point(464, 32)
            Me.lstBERParts.Name = "lstBERParts"
            Me.lstBERParts.Size = New System.Drawing.Size(120, 212)
            Me.lstBERParts.TabIndex = 6
            '
            'cmdFileCheck
            '
            Me.cmdFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdFileCheck.ForeColor = System.Drawing.Color.Black
            Me.cmdFileCheck.Location = New System.Drawing.Point(8, 256)
            Me.cmdFileCheck.Name = "cmdFileCheck"
            Me.cmdFileCheck.Size = New System.Drawing.Size(440, 32)
            Me.cmdFileCheck.TabIndex = 0
            Me.cmdFileCheck.Text = "BOX CHECK (DO I HAVE THE RIGHT BOX AND RIGHT SNs?)"
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(592, 16)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(113, 16)
            Me.Label11.TabIndex = 53
            Me.Label11.Text = "Wrong Model:"
            '
            'pnlSNcheck
            '
            Me.pnlSNcheck.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblScanQty, Me.Label5, Me.lstSNCheckList, Me.txtSN, Me.Label3})
            Me.pnlSNcheck.Location = New System.Drawing.Point(3, 8)
            Me.pnlSNcheck.Name = "pnlSNcheck"
            Me.pnlSNcheck.Size = New System.Drawing.Size(189, 240)
            Me.pnlSNcheck.TabIndex = 1
            Me.pnlSNcheck.Visible = False
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
            Me.lblScanQty.Location = New System.Drawing.Point(128, 48)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(56, 35)
            Me.lblScanQty.TabIndex = 77
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Black
            Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Lime
            Me.Label5.Location = New System.Drawing.Point(128, 32)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(54, 18)
            Me.Label5.TabIndex = 78
            Me.Label5.Text = "COUNT"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lstSNCheckList
            '
            Me.lstSNCheckList.Location = New System.Drawing.Point(0, 48)
            Me.lstSNCheckList.Name = "lstSNCheckList"
            Me.lstSNCheckList.Size = New System.Drawing.Size(120, 186)
            Me.lstSNCheckList.TabIndex = 2
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(0, 24)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(120, 20)
            Me.txtSN.TabIndex = 1
            Me.txtSN.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(0, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(152, 16)
            Me.Label3.TabIndex = 62
            Me.Label3.Text = "Scan Each SNs in Box :"
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Black
            Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Lime
            Me.lblPallet.Location = New System.Drawing.Point(376, 3)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(384, 37)
            Me.lblPallet.TabIndex = 79
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkNoReport})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(8, 120)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(192, 48)
            Me.GroupBox2.TabIndex = 70
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Options"
            Me.GroupBox2.Visible = False
            '
            'chkNoReport
            '
            Me.chkNoReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoReport.ForeColor = System.Drawing.Color.White
            Me.chkNoReport.Location = New System.Drawing.Point(8, 16)
            Me.chkNoReport.Name = "chkNoReport"
            Me.chkNoReport.Size = New System.Drawing.Size(176, 28)
            Me.chkNoReport.TabIndex = 0
            Me.chkNoReport.Text = "DON'T PRINT BOX REPORT"
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
            Me.grdPallets.Location = New System.Drawing.Point(8, 16)
            Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdPallets.Name = "grdPallets"
            Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdPallets.PreviewInfo.ZoomFactor = 75
            Me.grdPallets.RowHeight = 20
            Me.grdPallets.Size = New System.Drawing.Size(368, 176)
            Me.grdPallets.TabIndex = 69
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
            "llGroup=""1"" HorizontalScrollGroup=""1""><Height>172</Height><CaptionStyle parent=""" & _
            "Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle " & _
            "parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /" & _
            "><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style" & _
            "12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hi" & _
            "ghlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRow" & _
            "Style parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector""" & _
            " me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""No" & _
            "rmal"" me=""Style1"" /><ClientRect>0, 0, 364, 172</ClientRect><BorderSide>0</Border" & _
            "Side><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><" & _
            "NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /" & _
            "><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><S" & _
            "tyle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><St" & _
            "yle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><St" & _
            "yle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style p" & _
            "arent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><S" & _
            "tyle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horz" & _
            "Splits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth><ClientArea>0, 0, 364, 172</ClientArea><PrintPageHeaderStyle parent="""" me=""" & _
            "Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lbl
            '
            Me.lbl.BackColor = System.Drawing.Color.Black
            Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl.ForeColor = System.Drawing.Color.Yellow
            Me.lbl.Location = New System.Drawing.Point(4, 3)
            Me.lbl.Name = "lbl"
            Me.lbl.Size = New System.Drawing.Size(372, 37)
            Me.lbl.TabIndex = 74
            Me.lbl.Text = "PRODUCE BOXES"
            Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSelectBox
            '
            Me.btnSelectBox.BackColor = System.Drawing.Color.Green
            Me.btnSelectBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectBox.ForeColor = System.Drawing.Color.White
            Me.btnSelectBox.Location = New System.Drawing.Point(8, 80)
            Me.btnSelectBox.Name = "btnSelectBox"
            Me.btnSelectBox.Size = New System.Drawing.Size(192, 24)
            Me.btnSelectBox.TabIndex = 81
            Me.btnSelectBox.Text = "SELECT BOX TO BE PRODUCE"
            '
            'chklstServices
            '
            Me.chklstServices.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.chklstServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.chklstServices.Location = New System.Drawing.Point(8, 15)
            Me.chklstServices.Name = "chklstServices"
            Me.chklstServices.Size = New System.Drawing.Size(264, 178)
            Me.chklstServices.TabIndex = 82
            '
            'grbServices
            '
            Me.grbServices.Controls.AddRange(New System.Windows.Forms.Control() {Me.chklstServices})
            Me.grbServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbServices.ForeColor = System.Drawing.Color.White
            Me.grbServices.Location = New System.Drawing.Point(600, 40)
            Me.grbServices.Name = "grbServices"
            Me.grbServices.Size = New System.Drawing.Size(280, 200)
            Me.grbServices.TabIndex = 83
            Me.grbServices.TabStop = False
            Me.grbServices.Text = "Services"
            Me.grbServices.Visible = False
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Black
            Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(760, 3)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(48, 37)
            Me.Label6.TabIndex = 76
            Me.Label6.Text = "QTY:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCnt
            '
            Me.lblCnt.BackColor = System.Drawing.Color.Black
            Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblCnt.Location = New System.Drawing.Point(808, 3)
            Me.lblCnt.Name = "lblCnt"
            Me.lblCnt.Size = New System.Drawing.Size(72, 37)
            Me.lblCnt.TabIndex = 75
            Me.lblCnt.Text = "0"
            Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbBoxToBeProduce
            '
            Me.grbBoxToBeProduce.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdPallets})
            Me.grbBoxToBeProduce.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbBoxToBeProduce.ForeColor = System.Drawing.Color.White
            Me.grbBoxToBeProduce.Location = New System.Drawing.Point(208, 40)
            Me.grbBoxToBeProduce.Name = "grbBoxToBeProduce"
            Me.grbBoxToBeProduce.Size = New System.Drawing.Size(384, 200)
            Me.grbBoxToBeProduce.TabIndex = 84
            Me.grbBoxToBeProduce.TabStop = False
            Me.grbBoxToBeProduce.Text = "Box To Be Produce:"
            '
            'frmProdShip
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grbBoxToBeProduce, Me.grbServices, Me.btnSelectBox, Me.cmdReprintPalletLabel, Me.PanelList, Me.lblCnt, Me.lblPallet, Me.GroupBox2, Me.Label6, Me.lbl})
            Me.Name = "frmProdShip"
            Me.Text = "frmProdShip"
            Me.PanelList.ResumeLayout(False)
            Me.pnlSNcheck.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbServices.ResumeLayout(False)
            Me.grbBoxToBeProduce.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Protected Overrides Sub Finalize()
            _objTFShip = Nothing
            _objMisc = Nothing
            _objBulkShip = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************
        Private Sub frmBulkShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me._objBulkShip.iShiftID = PSS.Core.ApplicationUser.IDShift
                Me._objBulkShip.struser = PSS.Core.ApplicationUser.User
                Me._objBulkShip.iGroup_ID = Generic.GetMachineMapGroupID
                iHoldStatus = 0
                LoadPallets()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmBulkShipping_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ClearListControls()
            Me.chklstServices.DataSource = Nothing
            Me.lstRegular.Items.Clear()
            Me.lstBER.Items.Clear()
            Me.lstBERParts.Items.Clear()
            Me.lstWrongModel.Items.Clear()
            Me.lstDetail.Items.Clear()
            Me.lstSNCheckList.Items.Clear()
            Me.txtSN.Text = ""
            Me.lblCnt.Text = ""
            Me.lblPallet.Text = ""
            Me.lblScanQty.Text = ""
            Me.lblDetails.Text = "DETAIL:"
        End Sub

        '******************************************************************
        Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
            ClearControls()
        End Sub

        '******************************************************************
        Private Sub ClearControls()
            iGroup_ID = 0
            iShipType = 0
            iFileCheckDone = 0
            iHoldStatus = 0
            Me._objBulkShip.iLoc_ID = 0
            Me._objBulkShip.iCust_ID = 0
            Me._objBulkShip.iShipType = 0
            Me._objBulkShip.strFilePath = ""
            Me._objBulkShip.iPallet_ID = 0
            Me.lblPallet.Text = ""

            Me.PanelList.Visible = False
            Me.lstRegular.Items.Clear()
            Me.lstDetail.Items.Clear()
            Me.lstBER.Items.Clear()
            Me.lstBERParts.Items.Clear()
            Me.lstWrongModel.Items.Clear()
            Me.lstSNCheckList.Items.Clear()
            Me.txtSN.Text = ""
            Me.chkNoReport.Checked = False
            Me.lblCnt.Text = ""
            Me.lblScanQty.Text = ""
            Me.BackColor = System.Drawing.Color.SteelBlue
            System.Windows.Forms.Application.DoEvents()

            Me.cmdShip.Enabled = False
            Me.grdPallets.Enabled = True

            '*********************
            'objBulkShip Variables
            _objBulkShip.iLoc_ID = 0
            _objBulkShip.iBulkShipped = 0

            If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                _objBulkShip.dtExcelSNs.Dispose()
                _objBulkShip.dtExcelSNs = Nothing
            End If
            If Not IsNothing(_objBulkShip.dtWO) Then
                _objBulkShip.dtWO.Dispose()
                _objBulkShip.dtWO = Nothing
            End If
            '*********************
            Me.chklstServices.DataSource = Nothing
            Me.grbServices.Visible = False
        End Sub

        '******************************************************************
        Private Sub cmdShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShip.Click
            Dim i As Integer = 0
            Dim strNextWrkStation As String = ""
            Dim iDevice_ID As Integer = 0
            Dim drWipWO As DataRow
            Dim strSNCheck As String = ""

            Dim strWFM_CarrierUnlockModel_IDs As String = ""
            Dim strTF_CarrierUnlockModel_IDs As String = ""
            Dim arrTF_CarrierUnlockModel_IDs As New ArrayList()
            Dim objWFMProduce As PSS.Data.Buisness.WFMProduce
            Dim row2 As DataRow

            Try
                '*****************************************************
                DoValidation()
                '*****************************************************
                'Verify IMEI check
                '*****************************************************
                If Me.iShipType <> 12 AndAlso Me.iShipType <> 1 AndAlso _objBulkShip.dtExcelSNs.Select("SNCheck = 0").Length > 0 Then
                    MessageBox.Show("This IMEI/MEID (" & _objBulkShip.dtExcelSNs.Select("SNCheck = 0")(0)("IMEI") & ") has not been checked.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cmdShip.Enabled = False : Exit Sub
                ElseIf iFileCheckDone = 0 Then
                    Me.cmdShip.Enabled = False
                    Throw New Exception("File check has not been done.")
                ElseIf iFileCheckDone = 1 Then
                    Me.cmdShip.Enabled = False
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("IMEI/MEID you have scanned in to do 'Box Check' did not exist in the Box.")
                ElseIf Me._objBulkShip.dtExcelSNs.Rows.Count = 0 Then
                    Throw New Exception("Box is empty.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                '******************************************************
                'Get TF Workorder WIP and Next Workstation
                'Update will implement after billing section below
                '******************************************************
                If Me._iMenuCustID > 0 Then
                    If Me.iShipType = 1 Then
                        strNextWrkStation = "UNWORKABLE"
                    Else
                        strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID)
                    End If
                    If Me.iShipType = 0 AndAlso Me._objBulkShip.iCust_ID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        drWipWO = Me._objTFShip.GetWipWONo(grdPallets.Columns("model_id").Value)
                        If IsNothing(drWipWO) Then Throw New Exception("Wip work order is missing.")
                    End If
                End If

                '******************************************************
                'User select services to bill
                '******************************************************
                If Me.iShipType > 0 Then
                    If Me.BillSelectedServices() = False Then Exit Sub
                End If

                '(1) Software Screen , KS removed billing. (2) NTF produce charge
                If Me._objBulkShip.dtExcelSNs.Rows.Count > 0 AndAlso Me.iShipType = 0 Then
                    '(1) Software Screen , KS removed billing.
                    Dim objTFBilling = New PSS.Data.Buisness.TracFone.TFBillingData()
                    Dim iBillCode_ID As Integer = 0
                    Dim vLaborCharge As Decimal = 0.0
                    Dim strPartNumber As String = ""
                    Dim strMsg As String = "", bRes As Boolean = False
                    Dim j As Integer = 0, row1 As DataRow
                    For Each row1 In Me._objBulkShip.dtExcelSNs.Rows
                        bRes = objTFBilling.GetSoftwareScreenKillSwitchRemovalData(Me._iMenuCustID, row1("Device_ID"), _
                                                                                 iBillCode_ID, strPartNumber, _
                                                                                 vLaborCharge, strMsg)
                        If bRes Then 'need to bill
                            j = objTFBilling.AddSoftwareScreenKillSwitchRemovalCharge(row1("Device_ID"), iBillCode_ID, _
                                                                                      strPartNumber, vLaborCharge, _
                                                                                      PSS.Core.ApplicationUser.IDuser, Format(Now, "yyyy-MM-dd"))
                        ElseIf Not bRes AndAlso strMsg.Trim.Length > 0 Then 'Need to bill, but fail
                            Throw New Exception(strMsg)
                        End If
                    Next

                    '(2) NTF
                    Dim objTFMisc As New PSS.Data.Buisness.TracFone.clsMisc()
                    Dim objTFTriageBox As New PSS.Data.Buisness.TracFone.TFTestTriage()
                    Dim objTFBuildTriageBox As New PSS.Data.Buisness.TracFone.TFTestBuildTriagedBox()
                    Dim dtNTF As DataTable
                    Dim iNTFProduce_BillCodeID = 4339
                    Dim strPartNium As String = "S0"
                    Dim k As Integer = 0
                    Dim iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
                    Dim vProduceLaborCharge As Single = 0
                    For Each row1 In Me._objBulkShip.dtExcelSNs.Rows
                        vProduceLaborCharge = 0 : k = 0
                        dtNTF = objTFMisc.GetNTFDeviceID(row1("Device_ID"), Me._iMenuCustID)
                        If dtNTF.Rows.Count > 0 Then 'NTF
                            vProduceLaborCharge = objTFBilling.getAdditionalLaborCharge(Me._iMenuCustID, iNTFProduce_BillCodeID)
                            k = objTFBilling.InsertUpdateAddionalCharges(row1("Device_ID"), iNTFProduce_BillCodeID, vProduceLaborCharge, _
                                                                         strPartNium, Format(Now, "yyyy-MM-dd HH:mm:ss"), iUserID)

                            k += objTFBuildTriageBox.UpdateNTFTotalFlatLaborCharge(row1("Device_ID"), row1("Model_ID"), Format(Now, "yyyyMM"), _
                                                                                   Format(Now, "yyyy-MM-dd HH:mm:ss"), iUserID, "")
                            k += objTFBuildTriageBox.UpdateNTFTotalFlatLaborLevel(row1("Device_ID"), 0)
                        End If
                    Next

                    objTFBilling = Nothing : objTFMisc = Nothing : objTFTriageBox = Nothing : objTFBuildTriageBox = Nothing
                End If

                'Apply Carrier Unlock Charge for Devices of those model(s) which transferred from WFM 
                objWFMProduce = New PSS.Data.Buisness.WFMProduce()
                arrTF_CarrierUnlockModel_IDs = objWFMProduce.getCarrierUnlockModelsOfTFDeviceTransferredFromWFM( _
                                                strWFM_CarrierUnlockModel_IDs, strTF_CarrierUnlockModel_IDs)
                For Each row2 In Me._objBulkShip.dtExcelSNs.Rows
                    If arrTF_CarrierUnlockModel_IDs.Contains(row2("Model_ID")) _
                       AndAlso strWFM_CarrierUnlockModel_IDs.Trim.Length > 0 _
                       AndAlso strTF_CarrierUnlockModel_IDs.Trim.Length > 0 Then
                        If objWFMProduce.IsCarrierUnlockModelOfTFDeviceTransferredFromWFM(row2("IMEI"), strWFM_CarrierUnlockModel_IDs, strTF_CarrierUnlockModel_IDs) Then
                            Dim dtCarrierUnlock As DataTable = objWFMProduce.getCarrierUnlockCharge
                            Dim vCarrierUnlockLaborCharge As Single = 0.0
                            Dim iCarrierUnlockBillCode_ID As Integer = 0
                            If dtCarrierUnlock.Rows.Count = 0 Then
                                Throw New Exception("Can't find carrier unluck labor charge data.") : Exit Sub
                            ElseIf dtCarrierUnlock.Rows.Count > 1 Then
                                Throw New Exception("Invalid carrier unluck labor charge data.") : Exit Sub
                            ElseIf objWFMProduce.IsExistCarrierUnlockCharge(row2("Model_ID"), iCarrierUnlockBillCode_ID) Then
                                Throw New Exception("Already has carrier unlock charge, See IT.") : Exit Sub
                            Else
                                vCarrierUnlockLaborCharge = dtCarrierUnlock.Rows(0).Item("tcab_Amount")
                                iCarrierUnlockBillCode_ID = dtCarrierUnlock.Rows(0).Item("Billcode_ID")
                                objWFMProduce.AddCarrierUnlockCharge(vCarrierUnlockLaborCharge, row2("Device_ID"), iCarrierUnlockBillCode_ID, PSS.Core.ApplicationUser.IDuser, Format(Now, "yyyy-MM-dd"), True)
                            End If
                        End If
                    End If
                Next
                objWFMProduce = Nothing


                '******************************************************
                'Bulk SHIP now.
                '******************************************************
                i = _objBulkShip.BulkShip(Me.chkNoReport.Checked, iHoldStatus, CInt(Me.lblCnt.Text), 0, 0)

                '***********************************************
                'Get and assign unit to workstation 
                '***********************************************
                If Me._iMenuCustID > 0 Then
                    If strNextWrkStation.Trim.Length > 0 Then _objTFShip.SetTcelloptWorkStationForPallet(strNextWrkStation, _objBulkShip.iPallet_ID)

                    If Me.iShipType = 0 Then If Me._objBulkShip.iCust_ID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then Me._objTFShip.UpdateWipWorkOrder(Me._objBulkShip.iPallet_ID, drWipWO("WIPEntity"), drWipWO("WIPWO_ID"))
                End If

                '***********************************************
                ClearControls()
                LoadPallets()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ship Cell Pallets", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                drWipWO = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub DoValidation()
            '***************************
            If IsNothing(_objBulkShip.dtExcelSNs) Then
                Throw New Exception("No data found for this Box.")
            ElseIf _objBulkShip.dtExcelSNs.Rows.Count = 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("There are no devices to ship in this box.")
            End If

            '***************************************************************
            'Check the Billcode rule of the device and the Selected ShipType.
            'If they are different then don't let them ship
            '***************************************************************
            If iShipType = 0 Then   'REGULAR
                If Me.lstBER.Items.Count > 0 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("You are trying to ship BER devices with REFURBISHED devices. Not allowed.")
                End If
            ElseIf iShipType > 0 Then   'BER/Failed/Return
                If Me.lstRegular.Items.Count > 0 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("You are trying to ship REFURBISHED devices with BER/Failed devices. Not allowed.")
                End If
            Else
                Throw New Exception("'Ship Type' not determined.")
            End If

            '***************************
            'Discrepancies
            '***************************
            If Me.lstBERParts.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("There are BER devices that still have parts billed. Shipping not allowed.")
            End If
            If Me.lstWrongModel.Items.Count > 0 Then
                Me.BackColor = System.Drawing.Color.Red
                System.Windows.Forms.Application.DoEvents()
                Throw New Exception("There are devices of wrong model in the file. Shipping not allowed.")
            End If

            '***************************
            Me.PanelList.Visible = True
        End Sub

        '******************************************************************
        Private Sub LoadPallets()
            Dim dtPallets As DataTable

            Try
                ClearControls()
                dtPallets = Me._objTFShip.GetTFPalletsReadyToBeShipped(iHoldStatus)

                Me.grdPallets.ClearFields()
                Me.grdPallets.DataSource = dtPallets.DefaultView
                SetPalletGridProperties()
                ResetTransfers()
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPallets)
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

                    'Make some columns invisible
                    .Splits(0).DisplayColumns(i).Visible = False
                Next i

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns("Box").Width = 160
                .Splits(0).DisplayColumns("Count").Width = 45
                .Splits(0).DisplayColumns("Ship Type").Width = 90
                .Splits(0).DisplayColumns("SKU Length").Width = 80

                'Make some columns Visible
                .Splits(0).DisplayColumns("Box").Visible = True
                .Splits(0).DisplayColumns("Count").Visible = True
                .Splits(0).DisplayColumns("Ship Type").Visible = True
            End With
        End Sub

        '******************************************************************
        Private Sub ResetTransfers()
            ' Check for cellular devices whose WIP ownership was transferred and transfer them back to the original owner.
            Me._objBulkShip.GetPalletsReadyToBeShipped(iHoldStatus, Me._objBulkShip.iGroup_ID, _iMenuCustID)
        End Sub

        '******************************************************************
        Private Sub cmdFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileCheck.Click
            Dim strIMEI As String = ""
            Dim R1 As DataRow
            Dim iMatch As Integer = 0

            Try
                If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                    If Me.iShipType = 12 OrElse Me.iShipType = 1 Then
                        strIMEI = InputBox("Please scan in a IMEI/MEID to make sure you have selected the right box.")
                        If strIMEI <> "" Then
                            If _objBulkShip.dtExcelSNs.Select("IMEI = '" & strIMEI & "'").Length > 0 Then iMatch = 1
                        End If
                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("IMEI/MEID exists in the file.", "Box Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! IMEI/MEID does not belong to the selected box.", "Box Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                        End If
                    Else
                        Me.pnlSNcheck.Visible = True
                        Me.txtSN.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cmdFileCheck_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub lstBerParts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBERParts.SelectedIndexChanged
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                objMisc = New PSS.Data.Buisness.Misc()
                dt1 = objMisc.GetPartsForDevice(Trim(Me.lstBERParts.Items(Me.lstBERParts.SelectedIndex)))

                Me.lstDetail.Items.Clear()
                For Each R1 In dt1.Rows
                    Me.lstDetail.Items.Add(Trim(R1("PSprice_Desc")))
                Next R1

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lstBerParts_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objMisc = Nothing
                R1 = Nothing
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '******************************************************************
        Private Sub lstWrongModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWrongModel.SelectedIndexChanged
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                objMisc = New PSS.Data.Buisness.Misc()
                dt1 = objMisc.GetDeviceInfo(Trim(Me.lstWrongModel.Items(Me.lstWrongModel.SelectedIndex)))

                Me.lstDetail.Items.Clear()
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    Me.lstDetail.Items.Add(Trim(R1("Model_desc")))
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lstWrongModel_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objMisc = Nothing : R1 = Nothing : Generic.DisposeDT(dt1)
            End Try
        End Sub

        '******************************************************************
        Private Sub ProcessPallet()
            Dim iExcelNum, iPSSNum, i, iWrtyStatus, iManufID, iInvYrMonth As Integer
            Dim row, R1, drWipWO As DataRow
            Dim strDeviceCurrentWrkStation As String = ""
            Dim objDevice As PSS.Rules.Device
            Dim objTFRec As New PSS.Data.Buisness.TracFone.Receive()
            Dim objBizTFBilling As PSS.Data.Buisness.TracFone.TFBillingData
            Dim objTFBilling As New TracFone.TFBilling()
            Dim ds As DataSet
            Dim dt, dtNTF As DataTable
            Dim booFlatRate As Boolean = False
            Dim dteToday As DateTime = Nothing
            Dim num As String = 1

            Try
                iExcelNum = 0 : iPSSNum = 0 : i = 0 : iWrtyStatus = 0 : iManufID = 0 : iInvYrMonth = 0
                dteToday = CDate(Generic.MySQLServerDateTime(1))
                iInvYrMonth = CInt(dteToday.Year & dteToday.Month.ToString("00"))

                Cursor.Current = Cursors.WaitCursor
                Me.BackColor = System.Drawing.Color.SteelBlue
                System.Windows.Forms.Application.DoEvents()

                ClearListControls()
                Me.PanelList.Visible = False

                If Me.grdPallets.Columns("AQL_QCResult_ID").Value = 2 Then
                    MessageBox.Show("This box has been failed at OBA-AQL. Please verify box quantity and reprint box label.", "AQL Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '****************************************
                'All units in box must have same BER Code
                '****************************************

                'Disabled this block 08/31/2012
                'If Me.grdPallets.Columns("Pallet_ShipType").Value = 1 Then
                '    ds = Me._objTFShip.IsBoxContainMultiBERCode(Me.grdPallets.Columns("pallett_id").Value, Me.grdPallets.Columns("SKU Length").Value)
                '    If Not IsNothing(ds) AndAlso ds.Tables.Count > 0 Then
                '        Me.lblDetails.Text = "Wrong BER codes: "
                '        For Each dt In ds.Tables
                '            For Each R1 In dt.Rows
                '                If Me.lstDetail.Items.IndexOf(R1("Device_SN")) < 0 Then Me.lstDetail.Items.Add(R1("Device_SN"))
                '            Next R1
                '        Next dt

                '        If Me.lstDetail.Items.Count > 0 Then
                '            Me.lblPallet.Text = Me.grdPallets.Columns("Box").Value
                '            Me.PanelList.Visible = True : Me.lstDetail.Refresh() : Exit Sub
                '        End If
                '    End If
                'End If

                '************************************************
                'Retrieve Grid info
                '************************************************
                Me._objBulkShip.iPallet_ID = Me.grdPallets.Columns("pallett_id").Value
                Me._objBulkShip.iLoc_ID = Me.grdPallets.Columns("Loc_ID").Value
                iShipType = Me.grdPallets.Columns("Pallet_ShipType").Value
                Me._objBulkShip.iShipType = iShipType
                Me._objBulkShip.iBulkShipped = 1
                Me._objBulkShip.iGroup_ID = Me.grdPallets.Columns("group_id").Value
                'iGroup_ID = Me.grdPallets.Columns("group_id").Value
                Me._objBulkShip.iCust_ID = Me.grdPallets.Columns("Cust_ID").Value
                Me.lblPallet.Text = Me.grdPallets.Columns("Box").Value
                iManufID = Me.grdPallets.Columns("Manuf_ID").Value

                booFlatRate = Data.Buisness.DeviceBilling.IsFlatRateModel(Me.grdPallets.Columns("Cust_ID").Value, Me.grdPallets.Columns("model_id").Value, True, )
                '************************************************
                'Verify Wip Work order
                '************************************************
                If Me.iShipType = 0 AndAlso Me._objBulkShip.iCust_ID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    drWipWO = Me._objTFShip.GetWipWONo(grdPallets.Columns("model_id").Value)
                    If IsNothing(drWipWO) Then Throw New Exception("Wip work order is missing.")
                End If

                '************************************************
                iFileCheckDone = 0
                '************************************************
                'Step 1 :: Extract IMEI numbers from the database
                '************************************************
                _objBulkShip.dtExcelSNs = Me._objTFShip.GetBoxSN(Me._objBulkShip.iPallet_ID)
                iExcelNum = _objBulkShip.dtExcelSNs.Rows.Count
                If iExcelNum > 0 Then

                    '#############################################################
                    ' STEP2 ::
                    'Obtain and set validation data.
                    ' Broken down in to pieces as far as getting data is concerned 
                    ' because not all customers need all these validations.
                    ' This will be easier to brach out the code.
                    '#############################################################

                    '***********************************************************
                    '(A) :: Get Model
                    '***********************************************************
                    iPSSNum = _objBulkShip.GetModel()
                    If iExcelNum <> iPSSNum Then
                        Throw New Exception("cmdSelectFile_Click.GetModel:: Records from box don't have same number of records from PSS Database.")
                    End If

                    '***********************************************************
                    '(C) :: Get Billcoderule
                    '***********************************************************
                    iPSSNum = _objBulkShip.GetBillcodeRule()
                    If iShipType = 0 AndAlso iExcelNum <> iPSSNum Then
                        Throw New Exception("cmdSelectFile_Click.GetBillcodeRule:: Records from box don't have same number of records from PSS Database.")
                    Else
                        Me.lblCnt.Text = iExcelNum
                    End If

                    ''************************************************
                    ''Ensure 100% AQL
                    ''************************************************
                    'If _objBulkShip.iShipType = 0 Then
                    '    For Each R1 In _objBulkShip.dtExcelSNs.Rows
                    '        If Generic.IsValidQCResults(R1("Device_ID"), 4, "AQL", False, False) = False Then
                    '            MessageBox.Show("IMEI/MEID (" & R1("IMEI") & ") has not been passed at AQL test.", "AQL Check", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '            Exit Sub
                    '        End If
                    '    Next R1
                    'End If

                    '#############################################################
                    'Step 3::Write data to controls based on the business logic
                    '#############################################################

                    '*******************************************************
                    For Each R1 In _objBulkShip.dtExcelSNs.Rows
                        strDeviceCurrentWrkStation = "" : iWrtyStatus = 0
                        '*******************************************************
                        '(A) Model Validation (For all customers)
                        '*******************************************************
                        If R1("Model_Desc") <> Me.grdPallets.Columns("Model_Desc").Value Then
                            Me.lstWrongModel.Items.Add(Trim(R1("IMEI")))
                        End If

                        '*******************************************************
                        '(C) BILLCODERULE validation    (For all customers)
                        '*******************************************************
                        dtNTF = Me._objTFMisc.GetNTFDeviceID(R1("Device_ID"), Me._iMenuCustID)
                        If Not dtNTF.Rows.Count > 0 Then 'if NTF device, skip check billcode rule
                            If R1("Billcode_rule") > 0 Then 'RUR
                                Me.lstBER.Items.Add(Trim(R1("IMEI")))
                            ElseIf R1("Billcode_rule") = 0 Then 'Regular
                                Me.lstRegular.Items.Add(Trim(R1("IMEI")))
                            Else
                                MessageBox.Show("Unable to define bill rule for this device (" & Trim(R1("IMEI")) & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        Else
                            Me.lstRegular.Items.Add(Trim(R1("IMEI")))
                        End If


                        '*******************************************************
                        'RUR/RTMs have parts
                        '*******************************************************
                        If R1("RURRTMHasParts") = num Then
                            Me.lstBERParts.Items.Add(Trim(R1("IMEI")))
                        End If

                        '*******************************************************
                        'Verify workstation
                        '*******************************************************
                        If Me.iShipType = 0 AndAlso Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            strDeviceCurrentWrkStation = Generic.GetDeviceCurrentWorkStation(R1("Device_ID"))
                            If strDeviceCurrentWrkStation.Trim.ToUpper <> Me._strScreenName.Trim.ToUpper Then
                                MessageBox.Show("This device (" & Trim(R1("IMEI")) & ") belongs to " & strDeviceCurrentWrkStation & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If

                        '*******************************************************
                        'Re-calculate Manufacturer Warranty Status
                        '*******************************************************
                        If Me.iShipType = 0 AndAlso Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID AndAlso (R1("Device_ManufWrty") = 16 Or R1("Device_ManufWrty") = 21) Then
                            If R1("Manuf_Date").ToString.Trim.Length > 0 AndAlso IsDBNull(R1("WrtyClaimReceiptDt")) Then
                                iWrtyStatus = Me._objTFShip.RecalculateWarrantyStatus(R1("Device_ID"), R1("Manuf_Date"), R1("Manuf_ID"))
                                If R1("Device_ManufWrty") <> iWrtyStatus Then
                                    R1.BeginEdit()
                                    R1("Device_ManufWrty") = iWrtyStatus
                                    R1.EndEdit() : _objBulkShip.dtExcelSNs.AcceptChanges()
                                End If
                            End If
                        End If

                        '********************************
                        'Bill Services
                        '********************************
                        dtNTF = Me._objTFMisc.GetNTFDeviceID(R1("Device_ID"), Me._iMenuCustID)
                        If Not dtNTF.Rows.Count > 0 Then
                            objTFBilling.BillServices(R1, Me.iShipType, Me._objBulkShip.iCust_ID, booFlatRate, iInvYrMonth)
                        End If
                        '********************************
                    Next R1

                    'move receipt date to 30days range and repair date in between receiving and shipping date. LG and Samsung ONLY
                    If Me.iShipType = 0 AndAlso (iManufID = 16 OrElse iManufID = 21) Then objTFBilling.FixLGSSReceiptDate(Me._objBulkShip.iPallet_ID, booFlatRate)

                    If Me.iShipType > 1 Then Me.PopulateBillingServices(grdPallets.Columns("model_id").Value)

                    If Me.iShipType = 1 Then
                        objBizTFBilling = New PSS.Data.Buisness.TracFone.TFBillingData()
                        objBizTFBilling.SetWrtyClaimableFlagForBERShipBox(Me._objBulkShip.iPallet_ID)
                    End If
                    '#############################################################
                    'Do Validations
                    '*******************************************************
                    DoValidation()
                    '*******************************************************
                End If

                Me.PanelList.Visible = True
                If Me.iShipType = 12 Or Me.iShipType = 1 Then
                    Me.cmdShip.Enabled = True
                End If

            Catch ex As Exception
                Me.PanelList.Visible = False
                MessageBox.Show(ex.Message, "ProcessPallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                drWipWO = Nothing
                Me.grdPallets.Enabled = True
                R1 = Nothing
                objTFRec = Nothing
                objBizTFBilling = Nothing : objTFBilling = Nothing
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub btnSelectBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectBox.Click
            Dim strBoxID As String = ""
            Dim i As Integer = 0
            Dim booFound As Boolean = False

            Try
                ClearControls()
                Me.grdPallets.MoveFirst()

                If Me.grdPallets.Columns.Count = 0 Then
                    MessageBox.Show("No box available to ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strBoxID = InputBox("Enter Box ID:", "Select Box ID").Trim
                    If strBoxID.Trim.Length = 0 Then Exit Sub

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    For i = 0 To Me.grdPallets.RowCount - 1
                        If Me.grdPallets.Columns("Box").CellValue(i) = strBoxID.Trim.ToUpper Then
                            booFound = True
                            Exit For
                        End If
                        Me.grdPallets.MoveNext()
                    Next i

                    If booFound = True Then
                        Me.grdPallets.Enabled = False
                        ProcessPallet()
                    Else
                        MessageBox.Show("Box ID is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
            Dim R1() As DataRow
            Dim iMatch As Integer = 0

            Try
                If e.KeyCode = Keys.Enter Then
                    If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                        R1 = _objBulkShip.dtExcelSNs.Select("IMEI = '" & Me.txtSN.Text.Trim & "'")
                        If R1.Length > 0 Then
                            If R1(0)("SNCheck") = 1 Then
                                MessageBox.Show("This unit is already scanned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtSN.Text = ""
                                Me.txtSN.Focus()
                                Exit Sub
                            Else
                                iMatch = 1
                                R1(0).BeginEdit()
                                R1(0)("SNCheck") = 1
                                R1(0).EndEdit()
                                _objBulkShip.dtExcelSNs.AcceptChanges()
                            End If
                        End If

                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            Me.lstSNCheckList.Items.Add(Me.txtSN.Text.Trim)
                            Me.lblScanQty.Text = Me.lstSNCheckList.Items.Count
                            Me.txtSN.Text = ""
                            If _objBulkShip.dtExcelSNs.Select("SNCheck = 0").Length = 0 Then
                                Me.cmdShip.Enabled = True
                                iFileCheckDone = 2
                            End If
                        ElseIf iMatch = 0 Then
                            iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! IMEI/MEID does not belong to the selected box.", "Box Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.cmdShip.Enabled = False
                            Me.txtSN.SelectAll()
                        End If

                        Me.txtSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateBillingServices(ByVal iModelID As Integer)
            Dim dt As DataTable
            Dim objItem As Object
            Dim i As Integer

            Try
                dt = Me._objTFShip.GetBillingServicesList(iModelID)

                Me.grbServices.Visible = True
                With Me.chklstServices
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .ValueMember = "Billcode_ID"
                    .DisplayMember = "Billcode_Desc"
                    For i = 0 To .Items.Count - 1
                        'Auto check Receive and Packaging services
                        If .Items.Item(i)("Billcode_ID") = 1608 Or .Items.Item(i)("Billcode_ID") = 1615 Then .SetItemChecked(i, True)
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Function BillSelectedServices() As Boolean
            Dim objDevice As Rules.Device
            Dim objServiceBillcode As Object
            Dim R1 As DataRow
            Dim booReturnVal As Boolean = False

            Try
                If Me.chklstServices.CheckedItems.Count = 0 Then
                    If MessageBox.Show("Do you want to continue to produce this box without service?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then booReturnVal = True
                Else
                    For Each R1 In Me._objBulkShip.dtExcelSNs.Rows
                        objDevice = New Rules.Device(R1("Device_ID"))
                        For Each objServiceBillcode In Me.chklstServices.CheckedItems
                            If Generic.IsBillcodeExisted(R1("Device_ID"), objServiceBillcode("Billcode_ID")) = False Then objDevice.AddPart(objServiceBillcode("Billcode_ID"))
                        Next objServiceBillcode

                        objDevice.Update()
                        If Not IsNothing(objDevice) Then
                            objDevice.Dispose()
                            objDevice = Nothing
                        End If
                    Next R1

                    booReturnVal = True
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                objServiceBillcode = Nothing : R1 = Nothing
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
                ' Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************

    End Class
End Namespace